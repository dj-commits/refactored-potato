using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Utilities
{
    public static class Util
    {

        public static float GetDistance(Vector2 origin, Vector2 target)
        {
            return Vector2.Distance(origin, target);
        }
    }
}
