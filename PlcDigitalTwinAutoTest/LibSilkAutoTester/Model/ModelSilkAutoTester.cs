using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibConfigPlc;

namespace LibSilkAutoTester.Model;

public class ModelSilkAutoTester
{
    private readonly TestAusgabeFenster _testAusgabeFenster;
    private readonly ConfigPlc _configPlc;

    private const int ZeilenAbstand = 10;
    private const int SpaltenBreite = 300 - 15; // rechter Rand

    public ModelSilkAutoTester(TestAusgabeFenster testAusgabeFenster, ConfigPlc configPlc)
    {
        _testAusgabeFenster = testAusgabeFenster;
        _configPlc = configPlc;

        System.Threading.Tasks.Task.Run(ModelTask);
    }

    internal void ModelTask()
    {

        while (true)
        {
           
            Thread.Sleep(10);
        }
    }

    
}