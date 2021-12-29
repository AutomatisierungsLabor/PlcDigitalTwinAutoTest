using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LibAutoTest.Commands;

namespace LibAutoTest.ViewModel;

public partial class VmAutoTest
{
    public enum WpfObjects
    {
        TasterStart = 10
    }

    private readonly AutoTest _autoTest;

    public VmAutoTest(AutoTest autoTest)
    {
        _autoTest = autoTest;

        for (var i = 0; i < 100; i++)
        {
            ClkMode.Add(ClickMode.Press);
            SichtbarEin.Add(Visibility.Hidden);
            SichtbarAus.Add(Visibility.Visible);
            Farbe.Add(Brushes.White);
            Text.Add("");
        }

        SichtbarEin[3] = Visibility.Visible;

        Text[(int)WpfObjects.TasterStart] = "Test Starten";

        System.Threading.Tasks.Task.Run(VisuAnzeigenTask);
    }


    #region Taster, Schalter, OnPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private ICommand _btnTaster;
    // ReSharper disable once UnusedMember.Global
    public ICommand BtnTaster => _btnTaster ??= new RelayCommand(Taster);

    private ICommand _btnSchalter;
    // ReSharper disable once UnusedMember.Global
    public ICommand BtnSchalter => _btnSchalter ??= new RelayCommand(Schalter);
    #endregion
}