namespace LibHighResTimer;

public class HighResStopwatch : System.Diagnostics.Stopwatch
{
    private readonly double _microSecPerTick = 1000000D / Frequency;

    public HighResStopwatch()
    {
        if (!IsHighResolution) throw new Exception("On this system the high-resolution performance counter is not available");
    }

    public long ElapsedMicroseconds => (long)(ElapsedTicks * _microSecPerTick);
}
public class HighResTimer
{
    public delegate void MicroTimerElapsedEventHandler(object sender, MicroTimerEventArgs timerEventArgs);
    public event MicroTimerElapsedEventHandler MicroTimerElapsed;

    private Thread _threadTimer;
    private long _ignoreEventIfLateBy = long.MaxValue;
    private long _timerIntervalInMicroSec;
    private bool _stopTimer = true;

    public HighResTimer() { }
    // ReSharper disable once UnusedMember.Global
    public HighResTimer(long timerIntervalInMicroseconds) => Interval = timerIntervalInMicroseconds;

    public long Interval
    {
        get => Interlocked.Read(ref _timerIntervalInMicroSec);
        set => Interlocked.Exchange(ref _timerIntervalInMicroSec, value);
    }
    // ReSharper disable once UnusedMember.Global
    public long IgnoreEventIfLateBy
    {
        get => Interlocked.Read(ref _ignoreEventIfLateBy);
        set => Interlocked.Exchange(ref _ignoreEventIfLateBy, value <= 0 ? long.MaxValue : value);
    }
    public bool Enabled
    {
        set
        {
            if (value) Start();
            else Stop();
        }
        get => _threadTimer is { IsAlive: true };
    }
    public void Start()
    {
        if (Enabled || Interval <= 0) return;

        _stopTimer = false;

        // ReSharper disable once ConvertToLocalFunction
        ThreadStart threadStart = delegate
        {
            NotificationTimer(ref _timerIntervalInMicroSec, ref _ignoreEventIfLateBy, ref _stopTimer);
        };

        _threadTimer = new Thread(threadStart)
        {
            Priority = ThreadPriority.Highest
        };
        _threadTimer.Start();
    }
    public void Stop() => _stopTimer = true;
    // ReSharper disable once UnusedMember.Global
    public void StopAndWait() => StopAndWait(Timeout.Infinite);
    public bool StopAndWait(int timeoutInMilliSec)
    {
        _stopTimer = true;

        if (!Enabled || _threadTimer.ManagedThreadId ==
            Environment.CurrentManagedThreadId)
        {
            return true;
        }

        return _threadTimer.Join(timeoutInMilliSec);
    }
    private void NotificationTimer(ref long timerIntervalInMicroSec, ref long ignoreEventIfLateBy, ref bool stopTimer)
    {
        var timerCount = 0;
        long nextNotification = 0;

        var highResStopwatch = new HighResStopwatch();
        highResStopwatch.Start();

        while (!stopTimer)
        {
            var callbackFunctionExecutionTime = highResStopwatch.ElapsedMicroseconds - nextNotification;
            var timerIntervalInMicroSecCurrent = Interlocked.Read(ref timerIntervalInMicroSec);
            var ignoreEventIfLateByCurrent = Interlocked.Read(ref ignoreEventIfLateBy);

            nextNotification += timerIntervalInMicroSecCurrent;
            timerCount++;
            long elapsedMicroseconds;

            while ((elapsedMicroseconds = highResStopwatch.ElapsedMicroseconds) < nextNotification)
            {
                Thread.SpinWait(10);
            }

            var timerLateBy = elapsedMicroseconds - nextNotification;

            if (timerLateBy >= ignoreEventIfLateByCurrent)
            {
                continue;
            }

            var microTimerEventArgs = new MicroTimerEventArgs(timerCount, elapsedMicroseconds, timerLateBy, callbackFunctionExecutionTime);
            MicroTimerElapsed?.Invoke(this, microTimerEventArgs);
        }

        highResStopwatch.Stop();
    }
}
public class MicroTimerEventArgs : EventArgs
{
    public int TimerCount { get; } // Simple counter, number times timed event (callback function) executed
    public long ElapsedMicroseconds { get; } // Time when timed event was called since timer started
    public long TimerLateBy { get; }// How late the timer was compared to when it should have been called
    public long CallbackFunctionExecutionTime { get; }// Time it took to execute previous call to callback function (OnTimedEvent)
    public MicroTimerEventArgs(int timerCount, long elapsedMicroseconds, long timerLateBy, long callbackFunctionExecutionTime)
    {
        TimerCount = timerCount;
        ElapsedMicroseconds = elapsedMicroseconds;
        TimerLateBy = timerLateBy;
        CallbackFunctionExecutionTime = callbackFunctionExecutionTime;
    }
}