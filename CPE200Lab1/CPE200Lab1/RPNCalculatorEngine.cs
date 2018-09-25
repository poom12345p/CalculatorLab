using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CPE200Lab1
{

    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        protected Stack<string> myStack = new Stack<string>();


        public string calculator(string str)
        {
            
            try
            {

                string[] parts = str.Split(' ');
                if (parts.Length == 1)
                {
                    return "E";
                }
                for (int i = 0; i < parts.Length; i++)
                {

                    if (isNumber(parts[i]))
                    {
                        myStack.Push(parts[i]);
                    }
                    else if (isOperator(parts[i]))
                    {
                       
                            string fist, second;
                            second = myStack.Pop(); ;

                            fist = myStack.Pop(); ;

                            myStack.Push(calculate(parts[i], fist, second));
                    }

                }

                if (myStack.Count > 1)
                {
                    return "E";
                }
                else
                {

                    return myStack.Peek();
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
