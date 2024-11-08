using Microsoft.Maui.Controls;

namespace MobiHive
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // تسجيل الصفحات في التنقل
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(VucutKitleIndeksi), typeof(VucutKitleIndeksi)); // تسجيل صفحة VucutKitleIndeksi
        }
    }
}
