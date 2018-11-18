using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class PwWorldObject : PwObject
    {
        public float distance;
        public String name;
        public Location loc;

        public PwWorldObject() : base() {}
        public PwWorldObject(Character CHR) : base(CHR) {}
        public PwWorldObject(Character CHR, int ptr) : base(CHR, ptr) {}

        public void CalculateDistance()
        {
            CHR.LoadLocation();
            distance = (float)CHR.LOC.GetDistance(loc);
        }

        public void Approach(double dist = 2.0)
        {
            CalculateDistance();
            if (distance > dist + 0.5)
                CHR.Move(loc.Approach(CHR.LOC, dist), true, 0.5);
        }
    }
}
