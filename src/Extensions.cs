namespace Nuktils
{
    /// <summary>
    /// Extensions to existing classes
    /// </summary>
    public static class Extensions
    {
#nullable enable
        /// <summary>
        /// Checks if this Creature is a player and/or the given slugcat<br></br>
        /// <param name="creature"></param>
        /// <param name="name"></param>
        /// <return>(<paramref name="creature"/> is Player and player.slugcatStats.name == <paramref name="name"/>) if <paramref name="name"/> is not null; else <paramref name="creature"/> is Player</return>
        /// </summary>
        public static bool IsScug(this Creature creature, SlugcatStats.Name? name = null)
        {
            return name == null ? creature is Player : creature is Player player && player.slugcatStats.name == name;
        }

        /// <summary>
        /// Creature.IsScug except with an out param for the resulting Player instance
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="player"></param>
        /// <param name="name"></param>
        /// <return>(<paramref name="creature"/> is Player and player.slugcatStats.name == <paramref name="name"/>) if <paramref name="name"/> is not null; else <paramref name="creature"/> is Player</return>
        public static bool TryOutIsScug(this Creature creature, out Player? player, SlugcatStats.Name? name = null)
        {
            bool res = creature.IsScug(name);
            player = res ? creature as Player : null;
            return res;
        }
#nullable disable

        /// <summary>
        /// Checks all grasps of this Player for the specified AbstractPhysicalObject.AbstractObjectType
        /// </summary>
        /// <param name="self"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if this PhysicalObject is edible
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if this PhysicalObject is edible; otherwise false</returns>
        public static bool IsFoodObject(this PhysicalObject obj)
        {
            return obj != null && obj is IPlayerEdible && (obj as IPlayerEdible).FoodPoints != 0 && (obj as IPlayerEdible).Edible && !(obj is SSOracleSwarmer) && (!(obj is Creature) || obj.grabbedBy.Count > 0 && obj.grabbedBy[0].grabber is Player || (obj as Creature).dead);
        }
    }
}
