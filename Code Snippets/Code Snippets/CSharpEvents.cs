using System;

namespace Code_Snippets
{
    public delegate void Notify();
    class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted;
        public void StartProcess()
        {
            Console.WriteLine("Process Started!");

            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }
    }

    class Subscriber
    {
        public static void Main()
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted;
            bl.StartProcess();
        }

        // event handler
        public static void bl_ProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
        }
    }
}
