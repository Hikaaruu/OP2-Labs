using System;
namespace Lab
{
    public partial class Program
    {
        static List<TimePeriod> timePeriodsList = new List<TimePeriod>();
        const string path = "records.dat";
        static TimeOnly dayStart = new TimeOnly(9, 0);
        static TimeOnly dayEnd = new TimeOnly(17, 0);
        static bool addInfoAboutFinish = false;

        struct TimePeriod
        {
            public TimeOnly tStart;
            public TimeOnly tEnd;
        }


        // FULL PROCESS OF PUPULATING BINARY FILE
        private static void Populate()
        {

            ConsoleKeyInfo key;
            bool overlaping = false;
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append));

            while (true)
            {
                TimeOnly tStart;
                TimeOnly tEnd;
                overlaping = false;

                if (addInfoAboutFinish)
                {
                    Console.WriteLine(@"Enter a surname of your client (press ""Home"" button to finish) :");
                }
                else
                {
                    Console.WriteLine("Enter a surname of your client :");
                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Home)
                {
                    break;
                }

                string surname = key.KeyChar.ToString() + Console.ReadLine();
                Console.WriteLine();


                Console.WriteLine("Enter a customer arrival time (in format hh:mm) :");
                string? startTime = Console.ReadLine();
                try
                {
                    tStart = new TimeOnly(Convert.ToInt32(startTime[0..2]), Convert.ToInt32(startTime[3..5]));
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect time format. Record could not be added!");
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine();



                Console.WriteLine("Enter a customer service end time (in format hh:mm) :");
                string? endTime = Console.ReadLine();
                try
                {
                    tEnd = new TimeOnly(Convert.ToInt32(endTime[0..2]), Convert.ToInt32(endTime[3..5]));
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect time format. Record could not be added!");
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine();



                if (tEnd <= tStart)
                {
                    Console.WriteLine("Start time cannot be greater then or equal to end time! Record could not be added!");
                    Console.WriteLine();
                    continue;
                }

                if (tStart < dayStart || tEnd > dayEnd)
                {
                    Console.WriteLine("Working day starts at 09:00 and ends at 17:00. Record could not be added! ");
                    Console.WriteLine();
                    continue;
                }

                foreach (var span in timePeriodsList)
                {
                    if (tStart < span.tEnd && span.tStart < tEnd)
                    {
                        Console.WriteLine("This time period overlaps the existing one. Record could not be added!");
                        Console.WriteLine();
                        overlaping = true;
                        break;
                    }

                }

                if (overlaping)
                {
                    continue;
                }

                timePeriodsList.Add(new TimePeriod { tEnd = tEnd, tStart = tStart });
                MakeRecord(surname, tStart, tEnd, writer);
                addInfoAboutFinish = true;

            }
            writer.Close();

        }


        // ASK USER (CLEAR FIlE OR CONTINUE) IF FILE ALREADY EXIST
        private static void ClearOrContinue()
        {
            if (File.Exists(path))
            {
                Console.WriteLine("records.bat already exists. Clear it (1) or continue populating (2) ?   (1/2) ");
                int ans = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (ans == 1)
                {
                    File.Delete(path);
                }
                else
                {
                    addInfoAboutFinish = true;
                    AddExistingRecordsToList();
                }
                Console.Clear();
            }
        }

        // WRITE A RECORD IN A BINARY FILE
        private static void MakeRecord(string surname, TimeOnly tStart, TimeOnly tEnd, BinaryWriter writer)
        {

            writer.Write(surname);
            writer.Write(tStart.ToString("HH:mm"));
            writer.Write(tEnd.ToString("HH:mm"));

        }

        private static void AddExistingRecordsToList()
        {
            using (BinaryReader reader = new BinaryReader(File.Open("records.dat", FileMode.Open)))
            {

                while (reader.PeekChar() > -1)
                {
                    string surname = reader.ReadString();
                    string startTime = reader.ReadString();
                    string endTime = reader.ReadString();

                    TimeOnly tEnd = new TimeOnly(Convert.ToInt32(endTime[0..2]), Convert.ToInt32(endTime[3..5]));
                    TimeOnly tStart = new TimeOnly(Convert.ToInt32(startTime[0..2]), Convert.ToInt32(startTime[3..5]));

                    timePeriodsList.Add(new TimePeriod { tEnd = tEnd, tStart = tStart });

                }
            }
        }


        // PRINT ALL RECORDINGS FROM A BINARY FILE IN CONSOLE
        private static void PrintRecordings()
        {
            Console.Clear();
            Console.WriteLine("All records :");
            Console.WriteLine();
            using (BinaryReader reader = new BinaryReader(File.Open("records.dat", FileMode.Open)))
            {
                // пока не достигнут конец файла
                // считываем каждое значение из файла
                while (reader.PeekChar() > -1)
                {
                    string surname = reader.ReadString();
                    string startTime = reader.ReadString();
                    string endTime = reader.ReadString();
                    //TimeOnly tEnd = new TimeOnly(Convert.ToInt32(endTime[0..2]), Convert.ToInt32(endTime[3..5]));
                    //TimeOnly tStart = new TimeOnly(Convert.ToInt32(startTime[0..2]), Convert.ToInt32(startTime[3..5]));
                    //timePeriodsList.Add(new TimePeriod { tEnd = tEnd, tStart = tStart });
                    Console.WriteLine("Surname: " + surname);
                    Console.WriteLine("Service start time: " + startTime);
                    Console.WriteLine("Service end time: " + endTime);
                    Console.WriteLine();

                }
            }
        }

        private static void FindAndPrintGaps(List<TimePeriod> timePeriodsList)
        {
            Console.WriteLine();
            Console.WriteLine("Time when manager was free :");
            Console.WriteLine();
            List<TimePeriod> sorted = timePeriodsList.OrderBy(x => x.tStart).ToList();
            bool freeTime = false;
            int count = 0;
            TimeOnly position = dayStart;
            foreach (var period in sorted)
            {
                if (position < period.tStart)
                {
                    count++;
                    Console.WriteLine(position + " - " + period.tStart);
                }
                position = period.tEnd;

            }
            if (sorted.Last().tEnd < dayEnd)
            {
                count++;
                Console.WriteLine(sorted.Last().tEnd + " - " + dayEnd);
            }
            Console.WriteLine();
            Console.WriteLine("A total amout of gaps : " + count);
        }
    }
}