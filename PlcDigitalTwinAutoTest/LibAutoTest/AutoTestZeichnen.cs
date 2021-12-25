using System.Windows;
using System.Windows.Media;

namespace LibAutoTest;

public partial class AutoTest
{
    private void AutoTestZeichnen(LibWpf.LibWpf libWpf)
    {
        libWpf.Zeichnen(50, 30, 30, 30, true);
        
        libWpf.ButtonCallback("Test Starten",1,5,1,2,20,new Thickness(2,5,2,5), TestStarten);
        

        var stackPanel = libWpf.StackPanel(1, 9, 3, 20, new Thickness(5, 5, 5, 5), Brushes.LawnGreen);
        var webBrowser = libWpf.WebBrowser(10, 20, 3, 20, new Thickness(5, 5, 5, 5), Brushes.White);
    }
}