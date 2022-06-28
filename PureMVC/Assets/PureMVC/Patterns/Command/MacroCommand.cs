using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Command {

    // ICommand的實現
    // Command的集合，能一次執行多條Command，當執行後會將Command從列表中刪除
    // 列表中保存的並不是具體的Command，而是一個創建Command的方法
    // 在實際調用時才會逐一創建
    // 因為Command是事件發送者，所以是Notifier
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