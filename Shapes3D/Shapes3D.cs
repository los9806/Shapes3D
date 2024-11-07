using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace Shapes3D
{
    public abstract class Shape3D
    {
        // Method for surface area
        public abstract double GetSurfaceArea { get; }
        // Method for volume
        public abstract double GetVolume { get; }
    }
    public class Cuboid : Shape3D
    {
        public double Depth { get; }
        public double Width { get; }
        public double Height { get; }
        
        public override double GetSurfaceArea { get; }
        public override double GetVolume { get; }

        public Cuboid(double depth, double width, double height)
        {
            Depth = depth;
            Width = width;
            Height = height;
            GetSurfaceArea = 2 * (width * height + width * depth + height * depth);
            GetVolume = width * height * depth;
        }
    }
    public class Cube : Cuboid
    {
        public Cube(double sideLength) : base (sideLength, sideLength, sideLength) { }
    }
    public class Cylinder : Shape3D
    {
        public double Height { get; }
        public double Radius { get; }

        public override double GetSurfaceArea { get; }
        public override double GetVolume { get; }

        public Cylinder(double height, double radius)
        {
            Height = height;
            Radius = radius;
            GetSurfaceArea = 2 * Math.PI * radius * (radius + height);
            GetVolume = Math.PI * radius * radius * height;
        }
    }
    public class Sphere : Shape3D
    {
        public double Radius { get; }
        public override double GetSurfaceArea { get; }
        public override double GetVolume { get; }

        public Sphere(double radius)
        {
            Radius = radius;
            GetSurfaceArea = 4 * Math.PI * radius * radius;
            GetVolume = (4.0 / 3.0) * Math.PI * radius * radius * radius;
        }
    }
    
    public class Prism : Shape3D 
    {
        public double SideLength { get; }
        public int Faces { get; }
        public double Height { get; }

        public override double GetSurfaceArea { get; }
        public override double GetVolume { get; }

        public Prism(double sideLength, int faces, double height)
        {
            SideLength = sideLength;
            Faces = faces;
            Height = height;
            GetSurfaceArea = CalculteSurfaceArea();
            GetVolume = CalculateVolume();
        }

        private double CalculteSurfaceArea() 
        { 
            // surface area calculation for n-gonal prism 
            return Faces * SideLength * Height + 2 * (0.25 * Faces * Math.Pow(SideLength, 2) / Math.Tan(Math.PI / Faces));
        }

        private double CalculateVolume() 
        {
            // volume calculation for n-gonal prism 
            return (0.5 * Faces * Math.Pow(SideLength, 2) / Math.Tan(Math.PI / Faces)) * Height;
        }
    }
}

