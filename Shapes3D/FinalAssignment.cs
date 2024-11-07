using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes3D;

namespace FinalAssignment
{
    public static class Solver
    {
        public static string Solve(string filePath) 
        {
            List<Shape3D> carlosList = new List<Shape3D>();
            double total = 0;

            foreach (var line in File.ReadAllLines(filePath)) 
            {
                var tokens = line.Split(',');

                switch (tokens[0].ToLower()) 
                {
                    case "cube":
                        carlosList.Add(new Cube(double.Parse(tokens[1])));
                        break;
                    case "cuboid":
                        carlosList.Add(new Cuboid(
                            double.Parse(tokens[1]),
                            double.Parse(tokens[2]),
                            double.Parse(tokens[3])));
                        break;
                    case "cylinder":
                        carlosList.Add(new Cylinder(
                            double.Parse(tokens[1]),
                            double.Parse(tokens[2])));
                        break;
                    case "sphere":
                        carlosList.Add(new Sphere(double.Parse(tokens[1])));
                        break;
                    case "prism":
                        carlosList.Add(new Prism(
                            double.Parse(tokens[1]),
                            int.Parse(tokens[2]),
                            double.Parse(tokens [3])));
                        break;
                    case "area":
                        int areaScale = int.Parse(tokens[1]);
                        double areaSum = 0;
                        foreach (var area in carlosList)
                            areaSum += area.GetSurfaceArea;

                        total += areaSum * areaScale;
                        carlosList.Clear();
                        break;
                    case "volume":
                        int volumeScale = int.Parse(tokens[1]);
                        double volumeSum = 0;
                        foreach (var volume in carlosList)
                            volumeSum += volume.GetVolume;

                        total += volumeSum * volumeScale;
                        carlosList.Clear();
                        break;
                }
            }

            return $"The sum of measurements is {total.ToString("N2")}";
        }
    }
}
