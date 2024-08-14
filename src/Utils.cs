using UnityEngine;

namespace Nuktils
{
    /// <summary>
    /// Utilities that aren't extensions and aren't remix option menu related
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Quick and dirty struct for returning two values at once
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        public readonly struct ResultDuo<T, U>
        {
            /// <summary>
            /// The first return value
            /// </summary>
            public readonly T one;

            /// <summary>
            /// The second return value
            /// </summary>
            public readonly U two;

            /// <summary>
            /// Quick and dirty struct for returning two values at once
            /// </summary>
            public ResultDuo(T one, U two)
            {
                this.one = one;
                this.two = two;
            }
        }

        /// <summary>
        /// Intervals for Rain World's update loops
        /// </summary>
        public static class Ticks
        {
            /// <summary>
            /// The amount of Rain World update ticks equal to a second
            /// </summary>
            public const int Second = 40;

            /// <summary>
            /// The amount of Rain World update ticks equal to a minute
            /// </summary>
            public const int Minute = Second * 60;

            /// <summary>
            /// The amount of Rain World update ticks equal to an hour
            /// </summary>
            public const int Hour = Minute * 60;
        }

        /*
        public interface ICreatureEffect
        {
            public void ApplyToCreature(Creature creature);
        }
        */

        /// <summary>
        /// A timer for Rain World's update loops
        /// </summary>
        public class Ticker
        {
            private int ticks;

            /// <summary>
            /// A timer for Rain World's update loops
            /// </summary>
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

            /// <summary>
            /// A class for creatures effected with poison
            /// <br></br>
            /// damageType defaults to Creature.DamageType.Bite
            /// <br></br><br></br>
            /// Meant to be used in a CWT and updated with Creature.Update, but can be used for anything
            /// </summary>
            public CreaturePoison(int ticks, float damageDelt = 0, int stun = 0, Creature.DamageType damageType = null) : base(ticks)
            {
                this.damageDelt = damageDelt;
                this.stun = stun;
                this.damageType = damageType ?? Creature.DamageType.Bite;
            }

            /// <summary>
            /// Apply the effect to the given creature
            /// </summary>
            public void ApplyToCreature(Creature creature)
            {
                creature.Violence(creature.bodyChunks[0], Vector2.zero, creature.bodyChunks[0], null, damageType, damageDelt, stun);
            }
        }
    }
}
