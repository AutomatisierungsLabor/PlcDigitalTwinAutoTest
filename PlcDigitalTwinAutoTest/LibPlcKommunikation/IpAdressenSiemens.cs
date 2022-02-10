namespace LibPlcKommunikation;

public class IpAdressenSiemens
{
    public string Adress { get; set; }
    public string Mask { get; set; }
    public string Description { get; set; }

    public IpAdressenSiemens()
    {
        Adress = string.Empty;
        Mask = string.Empty;
        Description = string.Empty;
    }
}