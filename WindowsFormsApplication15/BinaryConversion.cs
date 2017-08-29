using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication15
{
    class BinaryConversion
    {
        //static void Main(string[] args)
        //{
        //    string binaryNumberToConvert;
        //    Console.WriteLine("Enter the binary number you would like to see the signed and unsigned decimal values of");
        //    binaryNumberToConvert = Console.ReadLine();

        //    Console.WriteLine("the unsigned binary number {0} has a decimal value of {1}", binaryNumberToConvert, GetUnsignedBinaryValue(binaryNumberToConvert));

        //    Console.WriteLine("the signed binary number {0} has a decimal value of {1}", binaryNumberToConvert, GetSignedBinaryValue(binaryNumberToConvert));

        //    Console.ReadKey();
        //}

        //unsigned
        public static int GetUnsignedBinaryValue(string binaryString)
        {
            int[] array = new int[binaryString.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = binaryString[i] - '0';//subtract the ascii character '0' so that "0" and "1" become the integers 0 and 1 and not 48 and 49 
            }

            double sum = 0;
            double temp;
            int exponent = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                temp = (array[i] * Math.Pow(2, exponent++));
                sum += temp;
            }
            return (int)sum;
        }

        //helper method for signed
        public static bool CheckForTwos(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > 1)
                {
                    return true;
                }
            }
            return false;
        }

        //signed
        public static int GetSignedBinaryValue(string binaryString)
        {
            int[] array = new int[binaryString.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = binaryString[i] - '0';
            }
            bool isNegative = false;
            if (array[0] == 1)//that is, if this is a negative binary number
            {
                isNegative = true; //Console.WriteLine(isNegative);
                for (int i = 0; i < array.Length; i++)//flip the values
                {
                    if (array[i] == 0)
                        array[i] = 1;
                    else
                        array[i] = 0;
                }
                //add 1 to the final position in the array
                array[array.Length - 1] += 1;

                //check if adding that above 1 in the last spot of the array has increased the value to 2, and adjust the array accordingly so long as it is not in proper binary format
                while (CheckForTwos(array))
                {
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i] > 1)
                        {
                            array[i] = 1;
                            array[i - 1] += 1;
                        }
                    }
                }
            }

            double sum = 0;
            double temp;
            int exponent = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                temp = (array[i] * Math.Pow(2, exponent++));
                sum += temp;
            }
            return (int)(sum * (isNegative ? -1 : 1));
        }
    }
}
