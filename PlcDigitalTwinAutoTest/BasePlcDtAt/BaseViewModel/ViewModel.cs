using BasePlcDtAt.BaseCommands;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class ViewModel : INotifyPropertyChanged
{

   public enum WpfObjects
    {
        TabLaborplatte = 0,
        TabSimulation = 1,
        TabAutoTest = 2,
        ErrorAnzeige = 3
    }

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    protected abstract void ViewModelKonstuktorZusatz();
    protected abstract void ViewModelAufrufThread();
    protected abstract void ViewModelAufrufTaster(short tasterId);
    protected abstract void ViewModelAufrufSchalter(short schalterId);

    public LibDatenstruktur.Datenstruktur Datenstruktur { get; set; }
    public BaseModel.Model Model { get; set; }
    protected ViewModel()
    {

        Log.Debug("Konstruktor - startet");

        FensterTitel = "Unbekannter Titel";

        SpsSichtbar = Visibility.Hidden;
        SpsVersionLokal = "fehlt";
        SpsVersionEntfernt = "fehlt";
        SpsStatus = "x";
        SpsColor = Brushes.LightBlue;

        for (var i = 0; i < 100; i++)
        {
            ClkMode.Add(ClickMode.Press);
            SichtbarEin.Add(Visibility.Hidden);
            SichtbarAus.Add(Visibility.Visible);
            Farbe.Add(Brushes.White);
        }

        // ReSharper disable once VirtualMemberCallInConstructor
        ViewModelKonstuktorZusatz();

        System.Threading.Tasks.Task.Run(ViewModelTask);
    }


    public void SetRefModel(BaseModel.Model model) =>Model=model;



    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private ICommand _btnTaster;
    // ReSharper disable once UnusedMember.Global
    public ICommand BtnTaster => _btnTaster ??= new RelayCommand(Taster);

    private ICommand _btnSchalter;
    // ReSharper disable once UnusedMember.Global
    public ICommand BtnSchalter => _btnSchalter ??= new RelayCommand(Schalter);

}