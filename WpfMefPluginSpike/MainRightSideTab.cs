using PublicApi;
using System.ComponentModel.Composition;

namespace WpfMefPluginSpike
{
    [Export]
    internal class MainRightSideTab : IRightSideTab
    {
        public string Header => "Internal Tab";
        public string Text => "I am provided by a view model inside the program assembly\r\nMy view (XAML) is found automatically.";
    }
}
