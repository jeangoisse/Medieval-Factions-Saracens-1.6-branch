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
    public static class InteractionDefOf
    {
        public static InteractionDef Merge;

        static InteractionDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InteractionDefOf));
        }
    }
}
