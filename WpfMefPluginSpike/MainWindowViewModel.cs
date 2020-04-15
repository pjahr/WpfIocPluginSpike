using PublicApi;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace WpfMefPluginSpike
{
    [Export]
    internal class MainWindowViewModel : IMainWindowViewModel
    {
        public MainWindowViewModel(IEnumerable<IRightSideTab> rightSideTabs)
        {
            RightSideTabs = rightSideTabs.ToArray();
        }

        public string Title => "WPF MEF Demo";

        public IEnumerable<IRightSideTab> RightSideTabs { get; }
    }
}
