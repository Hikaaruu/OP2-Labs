namespace OP
{
    partial class Program
    {

        public class Train
        {

            private int? number;
            public int? Number
            {
                get { return number; }
                set { number = value; }
            }


            private string? destination;
            public string? Destination
            {
                get { return destination; }
                set { destination = value; }
            }


            private TimeOnly? departure_time;
            public TimeOnly? DepartureTime
            {
                get { return departure_time; }
                set { departure_time = value; }
            }

        }

        private static HashSet<int> numbers_set = new HashSet<int>();

    }
}
