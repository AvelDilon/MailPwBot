using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class Location
    {
        public float x;
        public float y;
        public float z;
        public double gx;
        public double gy;
        public double gz;

        public Location(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            Recalculate();
        }

        public void Add(float x, float y, float z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
            Recalculate();
        }

        private void Recalculate(bool direction = true)
        {
            if (direction)
            {
                gx = (double)x / 10.0 + 400.0;
                gy = (double)y / 10.0 + 550.0;
                gz = (double)z / 10.0;
            }
            else
            {
                x = (float)(gx - 400.0) * 10;
                y = (float)(gy - 550.0) * 10;
                z = (float)gz * 10;
            }
        }

        public double GetDistance(Location L)
        {
            return Math.Sqrt(Math.Pow(L.x - x, 2) + Math.Pow(L.y - y, 2) + Math.Pow(L.y - y, 2));
        }

        public static Location ByGameCoordinates(double gx, double gy, double gz)
        {
            Location L = new Location(0, 0, 0);
            L.gx = gx;
            L.gy = gy;
            L.gz = gz;
            L.Recalculate(false);
            return L;
        }

        public Location Approach(Location FROM, double distance)
        {
            double lx = (x < FROM.x ? 1 : -1) * distance / Math.Sqrt(1 + Math.Pow((FROM.y - y) / (FROM.x - x), 2) + Math.Pow((FROM.z - z) / (FROM.x - x), 2)) + x;
            double ly = (y < FROM.y ? 1 : -1) * distance / Math.Sqrt(1 + Math.Pow((FROM.x - x) / (FROM.y - y), 2) + Math.Pow((FROM.z - z) / (FROM.y - y), 2)) + y;
            double lz = (z < FROM.z ? 1 : -1) * distance / Math.Sqrt(1 + Math.Pow((FROM.x - x) / (FROM.z - z), 2) + Math.Pow((FROM.y - y) / (FROM.z - z), 2)) + z;
            return new Location((float)lx, (float)ly, (float)lz);
        }

        public String DebugString()
        {
            return "RX: [" + x + "]; RY: [" + y + "]; RZ: [" + z + "]; GX: [" + gx + "]; GY: [" + gy + "]; GZ: [" + gz + "]\r\n";
        }
    }
}
