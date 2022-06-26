using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command {

    public class MacroCommand : Notifier , ICommand {
        public readonly IList<Func<ICommand>> subcommands;
        
        public MacroCommand () {
            subcommands = new List<Func<ICommand>> ();
            InitializeMacroCommand ();
        }

        protected virtual void InitializeMacroCommand () { }

        protected void AddSubCommand (Func<ICommand> factory) {
            subcommands.Add(factory);
        }
        
        public virtual void Execute (INotification notification) {
            while (subcommands.Count > 0) {
                var factory = subcommands[0];
                var commandInstance = factory ();
                commandInstance.Execute (notification);
                subcommands.RemoveAt (0);
            }
        }
        
    }

}