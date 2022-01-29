namespace LibPlcKommunikation;

public class PlcState
{
    public string PlcBezeichnung { get; set; }
    public bool PlcError { get; set; }
    public string PlcErrorMessage { get; set; }
}
public interface IPlc
{
    PlcState State { get; }
}