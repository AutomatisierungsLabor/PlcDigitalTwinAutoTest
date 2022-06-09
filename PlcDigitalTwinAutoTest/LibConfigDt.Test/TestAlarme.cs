using Contracts;
using Xunit;

namespace LibConfigDt.Test;

public class TestAlarme
{
    [Theory]
    [InlineData("Alarme", 0, EaConfigError.None)]
    [InlineData("Alarme", 1, EaConfigError.BezeichnungFehlt)]
    [InlineData("Alarme", 2, EaConfigError.KommentarFehlt)]
    [InlineData("Alarme", 3, EaConfigError.ByteKollision)]
    [InlineData("Alarme", 4, EaConfigError.BitKollision)]
    [InlineData("Alarme", 5, EaConfigError.BitKollision)]


    public void TestAlarm(string pfad, int id, EaConfigError eaConfigError)
    {
        var config = new ConfigDt(pfad);
        Assert.Equal(config.GetAlarmConfigError(id), eaConfigError);
    }
}