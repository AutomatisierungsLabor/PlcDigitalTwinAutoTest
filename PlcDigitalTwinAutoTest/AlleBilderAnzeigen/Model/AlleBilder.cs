using System;
using System.Collections.Generic;
using System.IO;

namespace AlleBilderAnzeigen.Model;

public class AlleBilder
{
    private readonly List<(string name, string nameMitPfad)> _alleBilder;
    public AlleBilder() => _alleBilder=new List<(string name, string nameMitPfad)>();

    public void BilderEinlesen(string baseplcdtatBilder)
    {
        var pictureDirectory = Path.Combine(Directory.GetParent(Environment.CurrentDirectory )!.Parent!.Parent!.Parent!.FullName , baseplcdtatBilder);

        if (!Directory.Exists(pictureDirectory)) return;
            
        foreach (var bilderPfad in Directory.GetFiles(pictureDirectory))
        {
            var bilderName = Path.GetFileName(bilderPfad);
            _alleBilder.Add((bilderName, bilderPfad));
        }
    }
    public List<(string name, string nameMitPfad)> GetAlleBilder() => _alleBilder;
}