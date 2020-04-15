using PublicApi;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Example.PluginOne
{
    [Export]
    public partial class SimplePluginMenuItem : MenuItem, IPluginMenuItem
    {
        public SimplePluginMenuItem()
        {
            InitializeComponent();
        }
    }
}
