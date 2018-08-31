using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTestApp
{
    public enum CalculationTypes
    {
        Add,
        Minus,
        Multiply,
        Divide
    }

    public class Calculation
    {
        public CalculationTypes CurrentCalculationType;

        public string Calculate(string value1AsString, string value2AsString)
        {
            double value1 = 0;
            double value2 = 0;
            double.TryParse(value1AsString, out value1);
            double.TryParse(value2AsString, out value2);
            double result = 0;
            switch (CurrentCalculationType)
            {
                case CalculationTypes.Add:
                    result = value1 + value2;
                    break;

                case CalculationTypes.Minus:
                    result = value1 - value2;
                    break;

                case CalculationTypes.Multiply:
                    result = value1 * value2;
                    break;

                case CalculationTypes.Divide:
                    if (value2 == 0)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = value1 / value2;
                    }
                    break;
            }
            return result.ToString();
        }
    }
}