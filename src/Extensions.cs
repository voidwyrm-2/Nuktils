namespace Nuktils
{
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
