using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace WPF.Configuration
{
    public class WpfConfigUtility
    {
        private static readonly CultureInfo Culture = CultureInfo.CurrentCulture;
        private static bool _isWpfConfigured;

        public static void ConfigureWpfIfNeed()
        {
            if (!_isWpfConfigured)
            {
                FrameworkElement.LanguageProperty.OverrideMetadata(
                    typeof(FrameworkElement), new FrameworkPropertyMetadata(
                        XmlLanguage.GetLanguage(Culture.IetfLanguageTag)));
            
                PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());
                PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;
                
                _isWpfConfigured = true;
            }
        }
    }
}