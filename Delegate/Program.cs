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
        public event AlertHandler AlertOtherClasses;

        public void ImposterDetection()
        {
            //codes codes
            Console.WriteLine("Imposter detection in progress");
            System.Threading.Thread.Sleep(10000);
            //when imposter is detected
            OnImposterDetected();
        }
        protected virtual void OnImposterDetected()
        {
            AlertOtherClasses?.Invoke();  //raise event
        }

    }

    public class Inspector   //subscriber
    {
        public void ActOnImposter()
        {
            var stateAn = new StatementAnalysis();
            stateAn.AlertOtherClasses += ImposterDetectionActions;
            stateAn.AlertOtherClasses += () => Console.WriteLine("Alert police to catch suspects");

            stateAn.ImposterDetection();
        }



        public void ImposterDetectionActions()
        {
            Console.WriteLine("Alert police to catch suspects");
            Console.ReadLine();
        }
    }
}
