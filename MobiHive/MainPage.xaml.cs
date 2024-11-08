using Microsoft.Maui.Controls;

namespace MobiHive
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnMenuButtonClicked(object sender, EventArgs e)
        {
            // تفعيل القائمة الجانبية (Flyout) لـ Shell
            Shell.Current.FlyoutIsPresented = true;
        }
    }
}
