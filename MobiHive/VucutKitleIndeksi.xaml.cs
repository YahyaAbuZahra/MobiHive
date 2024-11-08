using Microsoft.Maui.Controls;
using System;

namespace MobiHive
{
    public partial class VucutKitleIndeksi : ContentPage
    {
        public VucutKitleIndeksi()
        {
            InitializeComponent();
        }

        // تزامن القيم بين إدخال الطول و Slider الخاص به
        private void OnHeightEntryChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(e.NewTextValue, out double height))
                HeightSlider.Value = height;
        }

        private void OnHeightSliderChanged(object sender, ValueChangedEventArgs e)
        {
            HeightEntry.Text = e.NewValue.ToString("F1");
        }

        // تزامن القيم بين إدخال الوزن و Slider الخاص به
        private void OnWeightEntryChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(e.NewTextValue, out double weight))
                WeightSlider.Value = weight;
        }

        private void OnWeightSliderChanged(object sender, ValueChangedEventArgs e)
        {
            WeightEntry.Text = e.NewValue.ToString("F1");
        }

        // حساب BMI وعرض النتيجة
        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            try
            {
                double height = HeightSlider.Value / 100;  // تحويل الطول من سم إلى متر
                double weight = WeightSlider.Value;

                double bmi = weight / (height * height);  // حساب مؤشر كتلة الجسم

                // عرض قيمة مؤشر كتلة الجسم في BMIResultLabel
                BMIResultLabel.Text = $"BMI: {bmi:F1}";

                string bmiCategory = GetBMICategory(bmi);
                DisplayBMIResults(bmiCategory);
            }
            catch (Exception)
            {
                AdviceLabel.Text = "Hata: Lütfen geçerli bir değer giriniz.";
                BMIImage.Source = string.Empty;
                BMIResultLabel.Text = string.Empty;
            }
        }

        private string GetBMICategory(double bmi)
        {
            if (bmi < 18.5)
                return "underweight";
            else if (bmi >= 18.5 && bmi < 24.9)
                return "normal";
            else if (bmi >= 25 && bmi < 29.9)
                return "overweight";
            else
                return "obese";
        }

        private void DisplayBMIResults(string bmiCategory)
        {
            switch (bmiCategory)
            {
                case "underweight":
                    BMIImage.Source = "underweight_image.jifi";
                    AdviceLabel.Text = "Kilo almanız önerilir. Daha sağlıklı bir kilo hedefleyin.";
                    break;
                case "normal":
                    BMIImage.Source = "normal_weight_image.jifi";
                    AdviceLabel.Text = "Sağlıklı bir kilonuz var. Düzenli egzersiz yapmaya devam edin.";
                    break;
                case "overweight":
                    BMIImage.Source = "overweight_image.jifi";
                    AdviceLabel.Text = "Kiloyu kontrol etmek için sağlıklı bir diyet ve egzersiz önerilir.";
                    break;
                case "obese":
                    BMIImage.Source = "obese_image.png";
                    AdviceLabel.Text = "Fazla kilonuz var. Sağlık sorunlarını önlemek için uzmanla görüşün.";
                    break;
                default:
                    BMIImage.Source = string.Empty;
                    AdviceLabel.Text = "Bilinmeyen hata.";
                    break;
            }
        }
    }
}
