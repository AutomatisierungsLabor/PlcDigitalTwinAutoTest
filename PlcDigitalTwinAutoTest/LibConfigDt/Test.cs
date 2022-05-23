
namespace LibConfigDt
{

    public class Rootobject
    {
        public Analogeausgaenge AnalogeAusgaenge { get; set; }
        public Analogeeingaenge AnalogeEingaenge { get; set; }
        public Digitaleausgaenge DigitaleAusgaenge { get; set; }
        public Digitaleeingaenge DigitaleEingaenge { get; set; }
        public Textbausteine1[] Textbausteine { get; set; }
    }

    public class Analogeausgaenge
    {
        public Eaconfig[] EaConfig { get; set; }
    }

    public class Eaconfig
    {
        public int StartByte { get; set; }
        public int StartBit { get; set; }
        public string Type { get; set; }
        public string Bezeichnung { get; set; }
        public string Kommentar { get; set; }
    }

    public class Analogeeingaenge
    {
        public Eaconfig1[] EaConfig { get; set; }
    }

    public class Eaconfig1
    {
        public int StartByte { get; set; }
        public int StartBit { get; set; }
        public string Type { get; set; }
        public string Bezeichnung { get; set; }
        public string Kommentar { get; set; }
    }

    public class Digitaleausgaenge
    {
        public Eaconfig2[] EaConfig { get; set; }
    }

    public class Eaconfig2
    {
        public int StartByte { get; set; }
        public int StartBit { get; set; }
        public string Type { get; set; }
        public string Bezeichnung { get; set; }
        public string Kommentar { get; set; }
    }

    public class Digitaleeingaenge
    {
        public Eaconfig3[] EaConfig { get; set; }
    }

    public class Eaconfig3
    {
        public int StartByte { get; set; }
        public int StartBit { get; set; }
        public string Type { get; set; }
        public string Bezeichnung { get; set; }
        public string Kommentar { get; set; }
    }

    public class Textbausteine1
    {
        public string BausteinId { get; set; }
        public string PrefixH1 { get; set; }
        public string PrefixH2 { get; set; }
        public string VorbereitungId { get; set; }
        public string Test { get; set; }
        public string Kommentar { get; set; }
        public string WasAnzeigen { get; set; }
    }




}
