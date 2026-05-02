using System.Diagnostics;
using System.Text;
using WPF.Dialogs;

namespace WPF.Configuration
{
    public class BindingErrorTraceListener : TraceListener
    {
        private readonly StringBuilder _messageBuilder = new StringBuilder();

        public override void Write(string message)
        {
            _messageBuilder.Append(message);
        }

        public override void WriteLine(string message)
        {
            Write(message);
            MessageBoxUtility.ShowError(_messageBuilder.ToString(), "Ошибка привязки");
            _messageBuilder.Clear();
        }
    }
}