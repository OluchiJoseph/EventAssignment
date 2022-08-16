using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    internal class StatementAnalysis  //publisher
    {
        public delegate void AlertHandler();
        public event AlertHandler AlertTheClasses;

        public void ForgeryDetection()
        {
            //codes codes
            Console.WriteLine("Forgery detection in progress");
            System.Threading.Thread.Sleep(10000);
            //when forgery is detected
            OnForgeryDetected();
        }
        protected virtual void OnForgeryDetected()
        {
            AlertTheClasses?.Invoke();  //raise event
        }

    }

    public class Inspector   //subscriber
    {
        public void ActOnImposter()
        {
            var stateAn = new StatementAnalysis();
            stateAn.AlertTheClasses += ForgeryDetectionActions;
            stateAn.AlertTheClasses += () => Console.WriteLine("Alert police to catch suspects");

            stateAn.ForgeryDetection();
        }



        public void ForgeryDetectionActions()
        {
            Console.WriteLine("Alert police to catch suspects");
            Console.ReadLine();
        }
    }
}
