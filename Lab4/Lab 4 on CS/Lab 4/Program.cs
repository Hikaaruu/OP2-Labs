

namespace Lab4
{
    public class TPrism
    {

        public TPrism(double sideLength, double heigth, int baseSidesCount)
        {
            Height = heigth;
            SideLength = sideLength;
            BaseSidesCount = baseSidesCount;
        }

        public double Height { get; protected set; }
        public int BaseSidesCount { get; protected set; }
        public double SideLength { get; protected set; }

        public double SurfaceArea()
        {
            double angleRad = (180.0 / BaseSidesCount) * Math.PI / 180.0;


            double baseArea =
                (BaseSidesCount * Math.Pow(SideLength, 2)) / (4 * Math.Tan(angleRad));

            double sideFaceArea = Height * SideLength;

            return 2 * baseArea + sideFaceArea * BaseSidesCount;
        }

        public double Volume()
        {
            double angleRad = (180.0 / BaseSidesCount) * Math.PI / 180.0;

            double baseArea =
                (BaseSidesCount * Math.Pow(SideLength, 2)) / (4 * Math.Tan(angleRad));

            return baseArea * Height;
        }

    }


    public class TPrism3 : TPrism
    {

        public TPrism3(double sideLength, double heigth) : base(sideLength, heigth, 3)
        {

        }

    }


    public class TPrism4 : TPrism
    {
        public TPrism4(double sideLength, double heigth) : base(sideLength, heigth, 4)
        {

        }

    }

    internal class Program
    {
        private static List<TPrism> Input()
        {
            int m = 0;
            int sides = 0;
            double side_length = 0;
            double heigth = 0;

            #region validating and parsing of m
            Console.WriteLine("Enter the amount of prisms you want to create");
            string temp = Console.ReadLine();
            while (!int.TryParse(temp, out m) || m <= 0)
            {
                Console.WriteLine("Incorrect format! Try again!");
                temp = Console.ReadLine();
            }
            #endregion

            List<TPrism> prisms = new List<TPrism>();

            for (int i = 0; i < m; i++)
            {
                #region validating and parsing of sides count
                Console.WriteLine("Enter the amount of base sides (3 or 4)");
                temp = Console.ReadLine();
                while (!int.TryParse(temp, out sides) || (sides != 3 && sides != 4))
                {
                    Console.WriteLine("Incorrect format! Try again!");
                    temp = Console.ReadLine();
                }
                #endregion

                #region validating and parsing of base side length
                Console.WriteLine("Enter the length of base side");
                temp = Console.ReadLine();
                while (!double.TryParse(temp, out side_length) || side_length <= 0)
                {
                    Console.WriteLine("Incorrect format! Try again!");
                    temp = Console.ReadLine();
                }
                #endregion

                #region validating and parsing of prism height
                Console.WriteLine("Enter the height of prism");
                temp = Console.ReadLine();
                while (!double.TryParse(temp, out heigth) || heigth <= 0)
                {
                    Console.WriteLine("Incorrect format! Try again!");
                    temp = Console.ReadLine();
                }
                #endregion

                #region adding prisms to List
                if (sides == 3)
                {
                    prisms.Add(new TPrism3(side_length, heigth));
                }
                else
                {
                    prisms.Add(new TPrism4(side_length, heigth));
                }
                #endregion
            }


            return prisms;

        }

        private static double Sum(List<TPrism> prisms, out double areaSum)
        {
            double volumeSum = 0;
            areaSum = 0;

            foreach (var item in prisms)
            {
                if (item.BaseSidesCount == 3)
                {
                    volumeSum += item.Volume();
                }
                else
                {
                    areaSum += item.SurfaceArea();
                }
            }

            return volumeSum;
        }


        static void Main(string[] args)
        {
            double areaSum = 0;
            List<TPrism> prisms = Input();
            double volumeSum = Sum(prisms, out areaSum);
            Console.WriteLine("Total volume of triangular prisms : {0}", volumeSum);
            Console.WriteLine("Total surface area of quadrangular prisms : {0}", areaSum);

        }
    }
}