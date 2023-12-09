using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Saracens
{
    [DefOf]
    public static class JobDefOf
    {
        public static JobDef Merge;

        static JobDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(JobDefOf));
        }
    }
}
