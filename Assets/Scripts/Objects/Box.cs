using UnityEngine;
using GridGame.Core;

namespace GridGame.Objects
{
    public class Box : GridObject
    {
        public override bool TryMove(Vector2Int direction)
        {
            Vector2Int targetPos = GridPosition + direction;

            if (!GridManager.Instance.IsBlocked(targetPos))
            {
                MoveTo(targetPos);
                return true;
            }

            return false;
        }

        public override bool IsBlocking()
        {
            return true;
        }
    }
}