using System;

namespace InvalidRange
{
    class TestINvalidRangeProgram
    {
        static int ReadIntNumber(int startRange, int endRange)
        {
            Console.Write("Enter a number in the interval [{0}, {1}]: ", startRange, endRange);
            int number = int.Parse(Console.ReadLine());
            if (number < startRange || number > endRange)
            {
                throw new InvalidRangeException<int>(startRange, endRange, String.Format("The number is out of the required range [{0}, {1}]!", startRange, endRange));
            }
            else
            {
                return number;
            }
        }

        static DateTime ReadDate(DateTime startDate, DateTime endDate)
        {
            Console.Write("Enter a date between [{0}, {1}]: ", startDate, endDate);
            DateTime date = DateTime.Parse(Console.ReadLine());
            if (date < startDate || date > endDate)
            {
                throw new InvalidRangeException<DateTime>(startDate, endDate, String.Format("The date is out of the required range [{0}, {1}]!", startDate, endDate));
            }
            else
            {
                return date;
            }
        }
        static void Main()
        {
            try
            {
                int num = ReadIntNumber(1,100);
                Console.WriteLine("Your number is: {0}", num);

                DateTime date = ReadDate(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                Console.WriteLine("Your date is {0}", date);
            }
            catch (InvalidRangeException<int> ire)
            {
                Console.WriteLine(ire.Message);
                Console.WriteLine("Range: [{0}, {1}]", ire.StartRange, ire.EndRange);
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                Console.WriteLine(ire.Message);
                Console.WriteLine("Range: [{0}, {1}]", ire.StartRange, ire.EndRange);
            }
        }
    }
}
