using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> numbers = new Stack<string>();
            string[] parts = str.Split(' ');
            for(int i=0;i<parts.Length;i++)
            {
                if(isNumber(parts[i]))
                {
                    numbers.Push(parts[i]);
                }
                else if(isOperator(parts[i]))
                {
                    if(numbers.Count >=2)
                    {
                        string fist, second;
                        second = numbers.Peek();
                        numbers.Pop();
                        fist = numbers.Peek();
                        numbers.Pop();
                       numbers.Push(calculate(parts[i], fist, second));
                    }
                }
            
            }

            if(numbers.Count >1)
            {
                return "E";
            }
            else
            {
                return numbers.Peek();
            }
            // your code here
            //return "E";
        }
    }
}
