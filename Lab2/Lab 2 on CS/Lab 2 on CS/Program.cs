namespace OP
{
    partial class Program
    {
        static void Main(string[] args)
        {
            int size = GetSize();

            List<Train> trains = CreateList(size);

            Console.WriteLine();
            Console.WriteLine();
            string target_destination = GetDestination();
            Console.WriteLine();

            int? number = LatestTrain(trains, target_destination);

            PrintResult(number, trains);
        }
    }
}