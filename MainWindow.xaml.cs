using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string m_version = ProductVersion.VersionInfo.Version;

        public MainWindow()
        {
            GenericUpdater.Updater.DoUpdate("Installer", m_version, "Installer_Version.xml", "Installer.msi", new GenericUpdater.Updater.UpdateFiredDelegate(UpdateFired));
            InitializeComponent();
        }

        private void UpdateFired()
        {
            this.Close();
        }
    }
}
