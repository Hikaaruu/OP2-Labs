namespace Lab
{
    partial class Program
    { 

        static void Main(string[] args)
        {
            ClearOrContinue();
            Populate();
            PrintRecordings();
            FindAndPrintGaps(timePeriodsList);
        }

    }
}