namespace Lab3
{
    class Program
    {
        static void Main()
        {
            Console.Clear();

            string bin1Direct = GetValid8BitBinary("Enter first binary");
            string bin2Direct = GetValid8BitBinary("Enter second binary");

            char sign1 = bin1Direct[0];
            char sign2 = bin2Direct[0];

            string bin1 = '0' + bin1Direct.Substring(1);
            string bin2 = '0' + bin2Direct.Substring(1);

            bool shouldPrintSteps = GetConfirmation("Print intermediate steps");

            string result = MultiplyBinary(bin1, bin2, shouldPrintSteps);

            char finalSign = (sign1 == sign2) ? '0' : '1';
            string finalResult = finalSign + result.Substring(1);
            Console.WriteLine($"\nResult: {finalResult}");
        }



        static string MultiplyBinary(string bin1, string bin2, bool PrintSteps = false)
        {
            char[] row1 = bin2.ToCharArray();
            char[] row2 = (bin1 + new string('0', 8)).ToCharArray();
            char[] result = new string('0', 16).ToCharArray();

            if (PrintSteps)
            {
                Console.WriteLine();
                Console.WriteLine(row1);
                Console.WriteLine(row2);
                Console.WriteLine(result);
            }

            for (int i = 0; i < 8; i++)
            {
                if (row1[0] == '1')
                {
                    AddBinaryInPlace(row2, result);
                }

                // Shift row1 elements left by 1
                for (int j = 0; j < 7; j++)
                {
                    row1[j] = row1[j + 1];
                }
                row1[7] = '0';

                // Shift row2 elements right by 1
                for (int j = 15; j > 0; j--)
                {
                    row2[j] = row2[j - 1];
                }
                row2[0] = '0';

                if (PrintSteps)
                {
                    Console.WriteLine();
                    Console.WriteLine(row1);
                    Console.WriteLine(row2);
                    Console.WriteLine(result);
                }
            }

            return new string(result);
        }

        // Change rowResult directly
        static void AddBinaryInPlace(char[] row, char[] rowResult)
        {
            int carry = 0;
            int sum = 0;

            for (int i = 15; i >= 0; i--)
            {
                sum = carry;

                if (row[i] == '1') sum++;
                if (rowResult[i] == '1') sum++;

                rowResult[i] = (sum % 2 == 1) ? '1' : '0';
                carry = sum / 2;
            }
        }



        static bool GetConfirmation(string message)
        {
            string input;

            while (true)
            {
                Console.Write($"{message} (yes/no): ");
                input = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (input == "yes" || input == "y")
                    return true;
                else if (input == "no" || input == "n")
                    return false;

                Console.WriteLine("Invalid input. Please enter yes/no");
            }
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