namespace OP
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            Time time1 = GenerateFirstObject(rand);
            Time time2 = GenerateSecondObject(rand);
            Time time3 = GenerateThirdObject(rand);

            time1--;
            Console.WriteLine("First object after decrementing (adding 1 min) : " + time1.ToString() + "\n");

            time2++;
            Console.WriteLine("Second object after incrementing (adding 1 sec) : " + time2.ToString() + "\n");

            if (time1>time2)
            {
                Console.WriteLine("First object time is greater than second ");
            }
            else if (time1 == time2)
            {
                Console.WriteLine("First object time is equal to the  second ");
            }
            else
            {
                Console.WriteLine("Second object time is greater than first ");
            }
            Console.WriteLine();
            Time end_time = GetEndTime();
            Console.WriteLine();
            Console.WriteLine("From the third object time to the specified time left: " + time3.TimeLeftFor(end_time).ToString());

        }
    }
}