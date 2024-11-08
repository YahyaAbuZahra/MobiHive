using Microsoft.Maui.Controls;

namespace MobiHive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); // تعيين AppShell كصفحة رئيسية
        }
    }
}
