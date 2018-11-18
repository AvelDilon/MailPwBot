using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public abstract class UserClassObject
    {
        public Type TOT;
        public Character CHR;

        public UserClassObject(Character CHR) { this.CHR = CHR; }
    }
}
