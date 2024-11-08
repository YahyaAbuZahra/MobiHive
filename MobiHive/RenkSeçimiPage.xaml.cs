using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace MobiHive
{
    public partial class RenkSecimiPage : ContentPage
    {
        public RenkSecimiPage()
        {
            InitializeComponent();
        }

        private void OnColorSliderChanged(object sender, ValueChangedEventArgs e)
        {
            // جلب قيم الأحمر، الأخضر، والأزرق من الـ Sliders
            int red = (int)RedSlider.Value;
            int green = (int)GreenSlider.Value;
            int blue = (int)BlueSlider.Value;

            // إنشاء اللون الجديد باستخدام قيم RGB
            var selectedColor = new Color(Convert.ToSingle(red) / 255, Convert.ToSingle(green) / 255, Convert.ToSingle(blue) / 255);

            // تحديث خلفية الـ Frame باللون الجديد
            ColorDisplayFrame.BackgroundColor = selectedColor;

            // تحديث كود اللون في الـ Label
            ColorCodeLabel.Text = $"Renk Kodu: #{red:X2}{green:X2}{blue:X2}";
        }
    }
}
