namespace OP
{
    partial class Program
    {


        private static List<Train> CreateList(int size)
        {
            List<Train> trains = new List<Train>();

            for (int i = 0; i < size; i++)
            {
                CreateTrain(trains);
            }

            return trains;
        }


        private static void CreateTrain(List<Train> trains)
        {
            int number;
            string destination;
            string s_departure_time;
            TimeOnly departure_time;

            Train train = new Train();

            Console.WriteLine();

            do
            {
                Console.WriteLine("Enter train number :");
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number! Try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    continue;
                }

                if (number <= 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number! Try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    continue;
                }

                if (numbers_set.Contains(number))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Train with this number already exists! Try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    continue;
                }

                train.Number = number;
                numbers_set.Add(number);

            }
            while (train.Number == null);


            Console.WriteLine();


            do
            {
                Console.WriteLine("Enter train destination :");
                destination = Console.ReadLine().Trim();

                if (destination == String.Empty)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid destination! Try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    continue;
                }

                train.Destination = destination;
            }
            while (train.Destination == null);


            Console.WriteLine();

            do
            {
                Console.WriteLine("Enter train departure time in format hh:mm :");
                s_departure_time = Console.ReadLine();

                if (s_departure_time.Length != 5 || s_departure_time[2] != ':')
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
                    departure_time = new TimeOnly(Convert.ToInt32(s_departure_time[0..2]), Convert.ToInt32(s_departure_time[3..5]));
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

                train.DepartureTime = departure_time;
            }
            while (train.DepartureTime == null);


            trains.Add(train);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Train added successfully");
            Console.ForegroundColor = ConsoleColor.White;
        }


        private static int? LatestTrain(List<Train> trains, string destination)
        {
            return trains.Where(x => String.Equals(destination, x.Destination, StringComparison.CurrentCultureIgnoreCase)).OrderBy(x => x.DepartureTime).Last().Number;
        }


        private static int GetSize()
        {
            int size = 0;

            do
            {
                Console.WriteLine("Enter the size of array :");

                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Invalid size! Try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    continue;
                }

                if (size <= 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid size! Try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    continue;
                }

            }
            while (size <= 0);

            return size;
        }


        private static string GetDestination()
        {
            string destination = string.Empty;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the train destination for search :");
                Console.ForegroundColor = ConsoleColor.White;

                destination = Console.ReadLine().Trim();

                if (destination == String.Empty)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid destination! Try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    continue;
                }
            }
            while (destination == string.Empty);

            return destination;
        }


        private static void PrintResult(int? number, List<Train> trains)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The number of the latest train that goes to specified destination : " + number);
            Console.WriteLine();
            Console.WriteLine("Departure time of this train : " + trains.Where(x => x.Number == number).SingleOrDefault().DepartureTime.ToString());
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
