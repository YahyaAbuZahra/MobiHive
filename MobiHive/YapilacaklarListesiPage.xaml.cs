using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace MobiHive
{
    public partial class YapilacaklarListesiPage : ContentPage
    {
        // مجموعة لتخزين المهام
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public YapilacaklarListesiPage()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskItem>(); // إنشاء مجموعة المهام
            ToDoListView.ItemsSource = Tasks; // ربط القائمة مع الـ ListView
        }

        // عند الضغط على زر إضافة مهمة
        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            // عرض مربع حوار لإدخال المهمة
            string taskName = await DisplayPromptAsync("Yeni Görev", "Görevinizi girin:");
            if (!string.IsNullOrEmpty(taskName))
            {
                // إضافة المهمة إلى قائمة المهام
                Tasks.Insert(0, new TaskItem { TaskName = taskName, IsCompleted = false });
            }
        }

        // عند تغيير حالة المهمة (تم الانتهاء من المهمة)
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as TaskItem;
            if (selectedItem != null)
            {
                if (selectedItem.IsCompleted)
                {
                    selectedItem.TaskName = $"✓ {selectedItem.TaskName}"; // إضافة علامة صح
                }
                else
                {
                    selectedItem.TaskName = selectedItem.TaskName.Replace("✓ ", ""); // إزالة الخط
                }
            }
        }

        // عند الضغط على زر تعديل
        private async void OnEditTaskClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var task = button?.CommandParameter as TaskItem;

            if (task != null)
            {
                string newTaskName = await DisplayPromptAsync("Düzenle", "Görevinizi güncelleyin:", initialValue: task.TaskName);
                if (!string.IsNullOrEmpty(newTaskName))
                {
                    task.TaskName = newTaskName;
                }
            }
        }

        // عند الضغط على زر حذف
        private void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var task = button?.CommandParameter as TaskItem;

            if (task != null)
            {
                Tasks.Remove(task); // حذف المهمة من القائمة
            }
        }

        // عند الضغط على زر الحفظ
        private void OnSaveClicked(object sender, EventArgs e)
        {
            DisplayAlert("Başarıyla Kaydedildi", "Görevler başarıyla kaydedildi.", "Tamam");
        }
    }

    // فئة تمثل المهمة
    public class TaskItem
    {
        public string TaskName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
