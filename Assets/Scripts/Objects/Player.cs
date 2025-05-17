using UnityEngine;
using GridGame.Core;

namespace GridGame.Objects
{
    public class Player : GridObject
    {
        private bool isReady = true;

        void Update()
        {
            if (!isReady) return;

            Vector2Int input = Vector2Int.zero;

            if (Input.GetKeyDown(KeyCode.W)) input = Vector2Int.up;
            else if (Input.GetKeyDown(KeyCode.S)) input = Vector2Int.down;
            else if (Input.GetKeyDown(KeyCode.A)) input = Vector2Int.left;
            else if (Input.GetKeyDown(KeyCode.D)) input = Vector2Int.right;

            if (input != Vector2Int.zero)
            {
                isReady = false;
                if (TryMove(input))
                    Invoke(nameof(ResetMove), 0.1f);
                else
                    isReady = true;
            }
        }

        void ResetMove()
        {
            isReady = true;
        }

        public override bool TryMove(Vector2Int direction)
        {
            Vector2Int targetPos = GridPosition + direction;

            if (!GridManager.Instance.IsBlocked(targetPos))
            {
                MoveTo(targetPos);
                return true;
            }

            GridObject obj = GridManager.Instance.GetObjectAt(targetPos);
            if (obj is Box box)
            {
                Vector2Int boxTargetPos = targetPos + direction;
                if (!GridManager.Instance.IsBlocked(boxTargetPos))
                {
                    box.TryMove(direction);
                    MoveTo(targetPos);
                    return true;
                }
            }

            return false;
        }
    }
}