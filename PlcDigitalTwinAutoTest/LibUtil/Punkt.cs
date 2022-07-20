namespace LibUtil;

public class Punkt
{
    public enum ModusPunkt
    {
        ModusXy,
        MousRad
    }
    public double X { get; set; }
    public double Y { get; set; }

    public Punkt(double x, double y)
    {
        X = x;
        Y = y;
    }

    public Punkt(double radius, double winkel, ModusPunkt modusPunkt)
    {
        _ = modusPunkt; // es müssen die beiden Punkte unterschieden
        // Winkel in Grad --> für Synchronisiereinrichtung
        X = radius * Math.Cos(Winkel.DegToRad(winkel));
        Y = radius * Math.Sin(Winkel.DegToRad(winkel));
    }

    public Punkt Clone()
    {
        var p = new Punkt(X, Y);
        return p;
    }
}