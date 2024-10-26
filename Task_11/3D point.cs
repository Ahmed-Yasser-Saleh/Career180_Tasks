using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11
{
    internal class point_3d
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public point_3d(double x)
        {
            this.x = x;
        }
        public point_3d(double x, double y) : this(x)
        {
            this.y = y;
        }
        public point_3d(double x = 0, double y = 0, double z = 0) : this(x, y)
        {
            this.z = z;
        }
        public static implicit operator string(point_3d point)
        {
            return point.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var p1 = obj as point_3d;
            if (p1 == null)
                return false;

            return this.x == p1.x && this.y == p1.y && this.z == p1.z;
        }
        public override string ToString()
        {
            return $"Point Coordinates: ({x}, {y}, {z})";
        }
    }
}
