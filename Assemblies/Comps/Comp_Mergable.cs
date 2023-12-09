using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Saracens
{

    public class CompProperties_Mergable : CompProperties
    {

        public CompProperties_Mergable()
        {
            compClass = typeof(CompMergable);
        }

    }

    public class CompMergable : ThingComp
    {
        public CompProperties_Mergable Props => props as CompProperties_Mergable;
    }

}
