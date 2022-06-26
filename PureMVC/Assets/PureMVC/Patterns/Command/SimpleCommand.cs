using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command {

    public class SimpleCommand : Notifier , ICommand {
        
        public virtual void Execute (INotification notification) {
            
        }
        
    }

}