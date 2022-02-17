namespace LibPlcKommunikation;

public class IpAdressenBeckhoff
{
    public string IpAdresse { get; set; }
    public string AmsNetId { get; set; }
    public int Port { get; set; }
    public string Description { get; set; }

    public IpAdressenBeckhoff()
    {
        IpAdresse = string.Empty;
        AmsNetId = string.Empty;
        Port = 0;
        Description = string.Empty;
    }
}