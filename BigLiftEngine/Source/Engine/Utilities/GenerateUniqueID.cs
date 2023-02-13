using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Utilities
{
    public static class GenerateUniqueID
    {
        public static int ID;
        public static int GetUniqueID()
        {
            // Incremental ID generator
            return ID++;
        }
    }
}
