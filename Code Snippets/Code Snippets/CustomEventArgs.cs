using System;
using System.Collections.Generic;
using System.Text;

namespace Code_Snippets
{
    public class ProcessEventArgs : EventArgs
    {
        public bool IsSuccessful { get; set; }
        public DateTime CompletionTime { get; set; }
    }

    class CustomEventArgsSubscriber
    {
        public static void Main()
        {
            CustomEventArgsProcessBusinessLogic bl = new CustomEventArgsProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted;
            bl.StartProcess();
        }

        // event handler
        public static void bl_ProcessCompleted(object sender, ProcessEventArgs e)
        {
            Console.WriteLine("Process " + (e.IsSuccessful ? "Completed Successfully" : "failed"));
            Console.WriteLine("Completion Time: " + e.CompletionTime.ToLongDateString());
        }
    }

    public class CustomEventArgsProcessBusinessLogic
    {
        // declaring an event using built-in EventHandler
        public event EventHandler<ProcessEventArgs> ProcessCompleted;

        public void StartProcess()
        {
            var data = new ProcessEventArgs();

            try
            {
                Console.WriteLine("Process Started!");

                data.IsSuccessful = true;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
            catch (Exception)
            {
                data.IsSuccessful = false;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
        }

        protected virtual void OnProcessCompleted(ProcessEventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }
}
