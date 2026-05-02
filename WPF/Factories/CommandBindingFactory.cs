using System.Collections.Generic;
using System.Windows.Input;

namespace WPF.Factories
{
    public static class CommandBindingFactory
    {
        public static CommandBinding Create(
            RoutedCommand routedCommand, 
            ICommand viewModelCommand, 
            ICollection<CommandBinding> commandBindings = null)
        {
            var commandBinding = new CommandBinding(routedCommand, (sender, eventArgs) =>
            {
                viewModelCommand.Execute(eventArgs.Parameter);

            }, (sender, eventArgs) =>
            {
                eventArgs.CanExecute = viewModelCommand.CanExecute(eventArgs.Parameter);
            });
            
            commandBindings?.Add(commandBinding);
            return commandBinding;
        }
        
    }
}