using UnityEngine;

namespace Utils
{
    public class SubClasses
    {
        public static void UpgradeSpriteDirection(Vector3 direction, Transform transform, bool isInversed)
        {

            var multiplier = isInversed ? -1 : 1;

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(multiplier, 1, 1);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1f * multiplier, 1, 1);
            }
        }
    }
}