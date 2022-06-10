using Microsoft.Toolkit.Mvvm.Input;

namespace LibAlarmverwaltung.ViewModel;

public partial class VmAlarmverwaltung
{
    [ICommand]
    private void ButtonTaster(string cmd) => _alarmverwaltung.AlarmListe.Clear();
}
