using LibPlcTools;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public uint GetDigtalInputWord() => Simatic.Digital_CombineTwoByte(_datenstruktur.Di[0], _datenstruktur.Di[1]);
}