namespace LibUtil;

public static class Winkel
{
    public static double DegToRad(double value) => value / 180d * Math.PI;

    public static int RadToDeg(double value) => (int)(value * 180 / Math.PI);
}