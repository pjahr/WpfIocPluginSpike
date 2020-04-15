using PublicApi;
using System.ComponentModel.Composition;

namespace Example.PluginOne
{
    [Export]
    public class ExampleRightSideTab : IRightSideTab
    {
        public string Header => "Example Plugin Tab.";
        public string Text => "I am provided by a view model inside Example.Plugin.dll\r\nMy view (XAML) is specified in a data template inside the same assembly.\r\nThe resource is exported and merged into the main applications resources during composition time (see App.xaml.cs).\r\n The style of this text block is defined in the application resources but stated in the plugin.";
    }
}
