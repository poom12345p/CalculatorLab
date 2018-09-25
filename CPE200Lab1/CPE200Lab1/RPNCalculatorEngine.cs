using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CPE200Lab1
{

    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        public string calculator(string str)
        {
            
            try
            {

                Stack<string> numbers = new Stack<string>();
                string[] parts = str.Split(' ');
                if (parts.Length == 1)
                {
                    return "E";
                }
                for (int i = 0; i < parts.Length; i++)
                {

                    if (isNumber(parts[i]))
                    {
                        numbers.Push(parts[i]);
                    }
                    else if (isOperator(parts[i]))
                    {
                       
                            string fist, second;
                            second = numbers.Pop(); ;

                            fist = numbers.Pop(); ;

                            numbers.Push(calculate(parts[i], fist, second));
                    }

                }

                if (numbers.Count > 1)
                {
                    return "E";
                }
                else
                {

                    return numbers.Peek();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return "E";
            }
            // your code here
        }
    }
}
