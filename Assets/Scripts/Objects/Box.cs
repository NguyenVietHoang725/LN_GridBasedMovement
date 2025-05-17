using UnityEngine;
using GridGame.Core;

namespace GridGame.Objects
{
    /// <summary>
    /// Lớp đại diện cho hộp (Box) có thể đẩy được.
    /// </summary>
    public class Box : GridObject
    {
        /// <summary>
        /// Ghi đè phương thức TryMove.
        /// Hộp chỉ di chuyển nếu vị trí đích không bị chặn.
        /// </summary>
        /// <param name="direction">Hướng di chuyển</param>
        /// <returns>bool</returns>
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

        /// <summary>
        /// Hộp là vật cản, không cho phép di chuyển qua.
        /// </summary>
        /// <returns>bool</returns>
        public override bool IsBlocking()
        {
            return true;
        }
    }
}