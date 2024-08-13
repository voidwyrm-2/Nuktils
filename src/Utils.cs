using System.Collections.Generic;
using UnityEngine;

namespace Nuktils
{
    public static class Utils
    {
        /// <summary>
        /// Intervals for Rain World's update loops
        /// </summary>
        public static class Ticks
        {
            public const int Second = 40;
            public const int Minute = Second * 60;
            public const int Hour = Minute * 60;
        }

        /// <summary>
        /// A timer for Rain World's update loops
        /// </summary>
        public class Ticker
        {
            private int ticks;

            public Ticker(int ticks)
            {
                this.ticks = ticks;
            }

            /// <summary>
            /// Decrements the ticker by one
            /// </summary>
            /// <returns>true if the ticker has reached zero; otherwise, false.</returns>
            public bool Decrement()
            {
                ticks--;
                return ticks == 0;
            }

            /// <summary>
            /// Increments the ticker by one
            /// </summary>
            public void Increment()
            {
                ticks++;
            }

            /// <summary>
            /// Gets the current ticks of the ticker
            /// </summary>
            /// <returns>The current about of ticks</returns>
            public int Get()
            {
                return ticks;
            }
        }

        /// <summary>
        /// A class for creatures effected with poison
        /// <br></br>
        /// damageType defaults to Creature.DamageType.Bite
        /// <br></br><br></br>
        /// Meant to be used in a CWT and updated with Creature.Update, but can be used for anything
        /// </summary>
        public class CreaturePoison : Ticker
        {
            private readonly float damageDelt;
            private readonly int stun;
            private readonly Creature.DamageType damageType;

            public CreaturePoison(int ticks, float damageDelt = 0, int stun = 0, Creature.DamageType damageType = null) : base(ticks)
            {
                this.damageDelt = damageDelt;
                this.stun = stun;
                this.damageType = damageType ?? Creature.DamageType.Bite;
            }

            public void ApplyToCreature(Creature creature)
            {
                creature.Violence(creature.bodyChunks[0], Vector2.zero, creature.bodyChunks[0], null, damageType, damageDelt, stun);
            }
        }
    }

    public static class Extensions
    {
#nullable enable
        public static bool IsScug(this Creature creature, SlugcatStats.Name? name = null)
        {
            return name == null ? creature is Player : creature is Player && (creature as Player)?.slugcatStats?.name == name;
        }

        public static bool TryOutIsScug(this Creature creature, out Player? player, SlugcatStats.Name? name = null)
        {
            bool res = creature.IsScug(name);
            player = res ? creature as Player : null;
            return res;
        }
#nullable disable

        public static int GraspsHasType(this Player self, AbstractPhysicalObject.AbstractObjectType type)
        {
            for (int i = 0; i < self.grasps.Length; i++)
            {
#nullable enable
                Creature.Grasp? grasp = self.grasps[i];

                if (grasp == null) continue;

                if (grasp.grabbed.abstractPhysicalObject.type == type)
                    return i;
#nullable disable
            }

            return -1;
        }

        public static bool IsFoodObject(this PhysicalObject obj)
        {
            return obj != null && obj is IPlayerEdible && (obj as IPlayerEdible).FoodPoints != 0 && (obj as IPlayerEdible).Edible && !(obj is SSOracleSwarmer) && (!(obj is Creature) || obj.grabbedBy.Count > 0 && obj.grabbedBy[0].grabber is Player || (obj as Creature).dead);
        }
    }
}
