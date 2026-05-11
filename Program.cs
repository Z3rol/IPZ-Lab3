namespace Lab3
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
        }



        static string MultiplyBinary(string bin1, string bin2)
        {
            string result = new string('0', 16);
            bin1 = bin1 + new string('0', 8);

            for (int step = 0; step < 8; step++)
            {
                if (bin2[0] == '1')
                    AddBinary(bin2, result);

                bin2 = bin2.Substring(1) + "0";
            }

            return result;
        }

        static string AddBinary(string bin1, string bin2)
        {
            string result = "";
            int carry = 0;
            int num = 0;

            for (int i = bin1.Length - 1; i >= 0; i--)
            {
                num = carry;

                if (bin1[i] == '1')
                    num++;
                if (bin2[i] == '1')
                    num++;

                result = num % 2 + result;
                carry = num / 2;
            }

            return result;
        }



        static string GetValid8BitBinary(string message)
        {
            while (true)
            {
                Console.Write($"{message}: ");
                string input = Console.ReadLine()?.Trim() ?? "";

                if (!IsBinaryValid(input))
                {
                    Console.WriteLine("Invalid input. Please enter a valid binary");
                    continue;
                }
                else if (input.Length != 8)
                {
                    Console.WriteLine("Invalid length. Please enter 8bit binary");
                    continue;
                }

                return input;
            }
        }

        static bool IsBinaryValid(string binary)
        {
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] != '0' && binary[i] != '1')
                    return false;
            }

            return true;
        }
    }
}