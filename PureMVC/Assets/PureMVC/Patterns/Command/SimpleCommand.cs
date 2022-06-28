using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command {

    // ICommand的實現
    // 一條命令對應一個SimpleCommand
    // 因為Command是事件發送者，所以是Notifier
    public class SimpleCommand : Notifier , ICommand {
        
        public virtual void Execute (INotification notification) {
            
        }
        
    }

}