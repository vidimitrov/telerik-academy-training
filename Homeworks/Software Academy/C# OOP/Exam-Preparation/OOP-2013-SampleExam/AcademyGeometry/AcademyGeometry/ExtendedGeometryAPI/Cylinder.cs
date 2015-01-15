using System;
using GeometryAPI;

namespace AcademyGeometry.ExtendedGeometryAPI
{
    public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        public Cylinder(Vector3D bottom, Vector3D top, double radius)
            :base(bottom, top)
        {
            this.BottomCircle = new Circle(bottom, radius);
            this.TopCircle = new Circle(top, radius);
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public Circle BottomCircle { get; private set; }

        public Circle TopCircle { get; private set; }

        public double GetVolume()
        {
            double height = (this.vertices[0] - this.vertices[1]).Magnitude;
            return 2 * Math.PI * this.Radius * this.Radius * height;
        }

        public double GetArea()
        {
            double height = (this.vertices[0] - this.vertices[1]).Magnitude;
            return 2 * Math.PI * ((this.Radius * this.Radius) + (this.Radius * height));
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }
    }
}
