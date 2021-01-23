using System;
using System.Collections.Generic;
using System.Text;

namespace Code_Snippets
{
    class EventHandlerDelegateSubscriber
    {
        public static void Main()
        {
            EventHandlerDelegateProcessBusinessLogic bl = new EventHandlerDelegateProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted;
            bl.StartProcess();
        }

        // event handler
        public static void bl_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Process Completed!");
        }
    }

    public class EventHandlerDelegateProcessBusinessLogic
    {
        public event EventHandler ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            
            OnProcessCompleted(EventArgs.Empty);
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }
}
