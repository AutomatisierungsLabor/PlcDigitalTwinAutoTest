using System;
using System.Collections.Generic;
using System.IO;

namespace AlleBilderAnzeigen.Model;

public class AlleBilder
{
    private readonly List<string> _alleBilder;
    public AlleBilder() => _alleBilder = new List<string>();
    public void BilderEinlesen(string baseplcdtatBilder)
    {
        var dir1 = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.Parent!.FullName;
        var pictureDirectory = Path.Combine(dir1, "LibWpf", baseplcdtatBilder);


        if (!Directory.Exists(pictureDirectory)) return;

        foreach (var bilderPfad in Directory.GetFiles(pictureDirectory))
        {
            var bilderName = Path.GetFileName(bilderPfad);
            _alleBilder.Add(bilderName);
        }
    }
    public List<string> GetAlleBilder() => _alleBilder;
}