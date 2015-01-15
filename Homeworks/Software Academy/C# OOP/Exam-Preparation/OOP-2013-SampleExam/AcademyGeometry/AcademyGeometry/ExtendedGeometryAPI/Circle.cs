using System;
using GeometryAPI;

namespace AcademyGeometry.ExtendedGeometryAPI
{
    public class Circle : Figure, IAreaMeasurable, IFlat
    {
        private double radius;
        public Circle(Vector3D center, double radius) 
            : base(center)
        {
            this.radius = radius;
            this.Center = center;
        }

        public double Radius 
        { 
            get 
            {
                return this.radius;
            } 
        }

        private Vector3D Center { get; set; }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }

        public double GetArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public Vector3D GetNormal()
        {
            Vector3D normal = Vector3D.CrossProduct(new Vector3D(this.Center.X + this.Radius, this.Center.Y, this.Center.Z), new Vector3D(this.Center.X, this.Center.Y + this.Radius, this.Center.Z));
            normal.Normalize();
            return normal;
        }
    }
}