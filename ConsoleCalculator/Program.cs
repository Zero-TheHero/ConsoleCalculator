using System;

namespace ConsoleCalculator
{

    public class Calculator
    {


        [Serializable]
        class NegativesNotAllowedException : Exception
        {
            public NegativesNotAllowedException() { }

            public NegativesNotAllowedException(string numbers)
                : base(String.Format("Negatives not allowed:{0}",numbers))
            {

            }
        }


        static public int Add(string numbers)
        {
            int value = 0;
            string negativeValues = "";

            if (numbers != "")
            {
                string delimiter=",";

                if (numbers.Length > 3)
                {
                    if (numbers.Substring(0, 2) == "//")
                    {
                        delimiter = numbers.Substring(2, 1);
                        numbers = numbers.Substring(4).Replace(delimiter, ",");
                    }
                }
                string format = numbers.Replace("\n", ",");

                string[] values = format.Split(",");

                int[] ints = Array.ConvertAll(values, s => int.Parse(s));

                foreach (int x in ints)
                {
                    if (x < 0)
                        negativeValues += " "+x.ToString();
                    else
                        value += x;
                }
                if (negativeValues.Length>0)
                {
                    throw new NegativesNotAllowedException(negativeValues);
                }
            }
            return value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int value;
            try
            {
                value = Calculator.Add("-1, 1, -3");
                Console.WriteLine(value.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
            

            Console.ReadLine();
        }
    }
}
