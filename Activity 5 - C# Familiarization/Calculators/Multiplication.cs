using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_5___C__Familiarization.Calculators
{
    public class Multiplication : Calculator
    {
        public override double Calculate() => N1 * N2;

        public override void DisplayOperation()
        {
            Console.WriteLine($"\nAnswer: {N1} * {N2} = {Calculate()}");
        }
    }
}
