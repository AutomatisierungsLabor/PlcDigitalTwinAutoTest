namespace LibSilkAutoTester.TestAutomat;

public enum TestBefehle
{
    // ReSharper disable UnusedMember.Global
    Default = 0,
    Init,
    EingaengeTesten,
    Pause
    // ReSharper restore UnusedMember.Global
}

public enum TestErgebnis
{
    // ReSharper disable UnusedMember.Global
    Default = 0,
    Init,
    Erfolgreich,
    Timeout,
    Fehler
    // ReSharper restore UnusedMember.Global
}