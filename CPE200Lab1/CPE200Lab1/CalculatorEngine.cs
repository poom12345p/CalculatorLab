using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : TheCalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;

        public void setFirstOperand(String num)
        {
            if(isNumber(num))
            {
                firstOperand = Convert.ToDouble(num);
            }
        }

        public void setsecondOperand(String num)
        {
            if (isNumber(num))
            {
                secondOperand = Convert.ToDouble(num);
            }
        }
        public string calculator(string str)
        {
            string[] parts = str.Split(' ');
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            else
            {
                if (parts.Length >= 4 && parts[3] == "%")
                {
                    return calculate(parts[1], parts[0], calculate(parts[3], parts[0], parts[2], 4), 4);
                }
                return calculate(parts[1], parts[0], parts[2], 4);
            }

        }
    }
        
}