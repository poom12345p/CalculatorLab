using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
/// <summary>
/// The main alculatorEngine class.
/// Contains all methods for performing basic  CalculatorEngine functions.
/// </summary>
{
    public class CalculatorEngine
    {
        /// <summary>
        /// Check str is can be number
        /// </summary>
        /// <returns>
        /// boolean true if str can be number else return false
        /// </returns>
        ///  /// <param name="str">An String.</param>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        /// <summary>
        /// Check str is can be Operator
        /// </summary>
        /// <returns>
        /// boolean true if str can be Operator else return false
        /// </returns>
        ///  /// <param name="str">An String.</param>
        public bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Process String to result
        /// </summary>
        /// <returns>
        /// string of result
        /// </returns>
        /// <param name="str">An String.</param>

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            try
            {
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
            catch(Exception ex)
            {
                Console.WriteLine( ex);
                return "E";
            }

        }


        /// <summary>
        /// calculate unaryoperrator
        /// </summary>
        /// <returns>
        /// string of result
        /// </returns>
        /// <param name="operate">An String.</param>
        /// <param name="operand">An String.</param>
        /// <param name="maxOutputSize">An String.</param>
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
           
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        
                        if (parts.Length ==1||parts[1].Length + parts[0].Length < maxOutputSize)
                        {
                            return Math.Sqrt(Convert.ToDouble(operand)).ToString();
                        }
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                case "1/x":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        if (parts.Length == 1 || parts[1].Length + parts[0].Length < maxOutputSize)
                        {
                            return (1.0 / Convert.ToDouble(operand)).ToString();
                        }
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }


        /// <summary>
        /// calculate 
        /// </summary>
        /// <returns>
        /// string of result
        /// </returns>
        /// <param name="operate">An String.</param>
        /// <param name="firstOperand">An String.</param>
        /// <param name="secondOperand">An String.</param>
        /// <param name="maxOutputSize">An String.</param>

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        if (parts.Length == 1 || parts[1].Length + parts[0].Length < maxOutputSize)
                        {
                            return (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                        }
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    return ((Convert.ToDouble(firstOperand) / 100) * Convert.ToDouble(secondOperand)).ToString();
                    //your code here
                    break;
            }
            return "E";
        }
    }
}