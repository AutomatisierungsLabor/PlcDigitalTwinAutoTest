namespace LibPlcKommunikation;

public class PlcState
{
    public string PlcBezeichnung { get; set; }
    public string PlcVersion { get; set; }
    public string PlcStatus { get; set; }
    public bool PlcError { get; set; }
    public string PlcModus { get; set; }
}
public interface IPlc
{
  PlcState State { get; }
  public bool PlcTask();
}