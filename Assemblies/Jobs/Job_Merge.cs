using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse.AI;
using Verse;

namespace Saracens
{
    public class JobGiver_Merge : ThinkNode_JobGiver
    {
        private const float MaxMergeDistance = 60f;

        protected override Job TryGiveJob(Pawn pawn)
        {
            if (!(from p in pawn.Map.mapPawns.AllPawnsSpawned                  
                  where p.def == pawn.def && p.GetComp<CompMergable>() != null && p != pawn && p.Position.InHorDistOf(pawn.Position, MaxMergeDistance)                   select p).TryRandomElement(out var result))
            {
                return null;
            }
            Job job = JobMaker.MakeJob(JobDefOf.Merge, result);
            job.locomotionUrgency = LocomotionUrgency.Walk;
            job.expiryInterval = 3000;
            return job;
        }
    }

    public class JobDriver_Merge : JobDriver
    {
        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return true;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnDespawnedNullOrForbidden(TargetIndex.A);
            this.FailOnNotCasualInterruptible(TargetIndex.A);
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
            yield return Toils_Interpersonal.WaitToBeAbleToInteract(pawn);
            Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch).socialMode = RandomSocialMode.Off;
        }
    }

}
