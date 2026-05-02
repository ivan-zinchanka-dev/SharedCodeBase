using System;
using System.Windows;

namespace WPF.Dialogs
{
    public static class MessageBoxUtility
    {
        public static void ShowWarning(string errorMessage, string caption = "Внимание")
        {
            MessageBox.Show(errorMessage, caption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        
        public static void ShowError(Exception exception, string caption = "Ошибка")
        {
            ShowError(exception.ToString(), caption);
        }
        
        public static void ShowError(string errorMessage, string caption = "Ошибка")
        {
            MessageBox.Show(errorMessage, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}