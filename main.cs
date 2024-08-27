using System;

namespace IMEIConversion
{
    class Program
    {
        static string GetFullIMEI(string imeisv)
        {
            // Remove the last 2 digits (SVN) from IMEISV
            string imeiWithoutSVN = imeisv.Substring(0, imeisv.Length - 2);

            // Compute the check digit
            int sum = 0;
            for (int i = 0; i < imeiWithoutSVN.Length; i++)
            {
                int digit = int.Parse(imeiWithoutSVN[i].ToString());
                if (i % 2 == 0)
                    digit *= 2;
                sum += digit / 10 + digit % 10;
            }

            int checkDigit = (10 - (sum % 10)) % 10;

            // Construct the full IMEI
            string fullIMEI = imeiWithoutSVN + checkDigit;

            return fullIMEI;
        }

        static void Main(string[] args)
        {
            string imeisv = "35576205279323"; // Example IMEISV
            string fullIMEI = GetFullIMEI(imeisv);
            Console.WriteLine($"Full IMEI: {fullIMEI}");
        }
    }
}
