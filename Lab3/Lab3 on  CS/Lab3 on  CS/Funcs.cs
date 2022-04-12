namespace OP
{
    partial class Program
    {

        private static Time GenerateFirstObject(Random random)
        {
            int hours;
            int minutes;
            int seconds;

            hours = random.Next(0, 24);
            minutes = random.Next(0, 60);
            seconds = random.Next(0, 60);

            Console.WriteLine("Random numbers generated for first object :\n");
            Console.WriteLine("hours : " + hours + "\n");
            Console.WriteLine("minutes : " + minutes + "\n");
            Console.WriteLine("seconds : " + seconds + "\n");

            Time time1 = new Time(hours, minutes, seconds);

            Console.WriteLine("first object : " + time1.ToString() + "\n");
            Console.WriteLine();

            return time1;
        }

        private static Time GenerateSecondObject(Random random)
        {
            int hours;
            int minutes;

            hours = random.Next(0, 24);
            minutes = random.Next(0, 60);

            Console.WriteLine("Random numbers generated for second object :\n");
            Console.WriteLine("hours : " + hours + "\n");
            Console.WriteLine("minutes : " + minutes + "\n");

            Time time2 = new Time(hours, minutes);

            Console.WriteLine("second object : " + time2.ToString() + "\n");
            Console.WriteLine();

            return time2;
        }

        private static Time GenerateThirdObject(Random random)
        {
            int hours;

            hours = random.Next(0, 24);

            Console.WriteLine("Random numbers generated for third object :\n");
            Console.WriteLine("hours : " + hours + "\n");

            Time time3 = new Time(hours);

            Console.WriteLine("third object : " + time3.ToString() + "\n");
            Console.WriteLine();

            return time3;
        }

        private static Time GetEndTime()
        {
            Time end_time = new();
            bool success = false;

            do
            {
                Console.WriteLine("Enter a time (in format hh:mm:ss) to calculate how much time between the third object and the given time");
                string string_time = Console.ReadLine();

                if (string_time.Length != 8 || string_time[2] != ':' || string_time[5] != ':')
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid time format! Try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    continue;
                }

                try
                {
                    end_time = new Time(Convert.ToInt32(string_time[0..2]), Convert.ToInt32(string_time[3..5]), Convert.ToInt32(string_time[6..8]));
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid time format! Try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    continue;
                }

                success = true;

            }
            while (!success); ;

            return end_time;
        }

    }
}
