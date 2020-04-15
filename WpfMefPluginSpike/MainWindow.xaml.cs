using PublicApi;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;

namespace WpfMefPluginSpike
{
    [Export]
    internal partial class MainWindow : Window
    {
        public MainWindow(IMainWindowViewModel viewModel, IPluginMenuItem[] pluginMenuItems=null)
        {
            InitializeComponent();

            DataContext = viewModel;            

            if (pluginMenuItems==null)
            {
                PluginMenu.Items.Add(new MenuItem() { Header="There are no plugins that provide menu items",
                                                      IsEnabled=false});
                return;
            }

            foreach (var item in pluginMenuItems)
            {
                PluginMenu.Items.Add(item);
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }
    }
}
