using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_5___C__Familiarization.Calculators
{
    public abstract class Calculator
    {
        private double number1;
        public double N1
        {
            get { return number1; }
            set { number1 = value; }
        }

        private double number2;

        public double N2
        {
            get { return number2; }
            set { number2 = value; }
        }

        public abstract double Calculate();

        public virtual void DisplayOperation()
        {
            Console.WriteLine("Calculating...");
        }
    }
}
