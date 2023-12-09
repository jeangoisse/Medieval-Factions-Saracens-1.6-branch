using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Saracens
{
    public class InteractionWorker_Merge : InteractionWorker
    {
        public override void Interacted(Pawn initiator, Pawn recipient, List<RulePackDef> extraSentencePacks, out string letterText, out string letterLabel, out LetterDef letterDef, out LookTargets lookTargets)
        {
            AddInitiatorToReceipentAge(initiator, recipient);
            letterText = null;
            letterLabel = null;
            letterDef = null;
            lookTargets = null;
        }

        private void AddInitiatorToReceipentAge(Pawn initiator, Pawn recipient)
        {
        }

    }
}
