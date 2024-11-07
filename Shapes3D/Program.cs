using Shapes;
using Shapes3D;
using FinalAssignment;

namespace FinalAssignmentApp
{
    static class Program
    {
        public static void Main(string[] args)
        {
            // provide the path to the csv file
            string filePath = "3Dshapes.csv";

            string result = Solver.Solve(filePath);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}

