using UnityEngine;
using GridGame.Core;

namespace GridGame.Objects
{
    /// <summary>
    /// Lớp đại diện cho người chơi.
    /// Có thể nhận input WASD để di chuyển theo lưới,
    /// và có thể đẩy các Box nếu phía trước không bị chặn.
    /// </summary>
    public class Player : GridObject
    {
        private bool isReady = true; // trạng thái sẵn sàng nhận lệnh di chuyển

        /// <summary>
        /// Kiểm tra input người dùng mỗi frame,
        /// nếu có input hợp lệ thì thực hiện di chuyển.
        /// Giới hạn tốc độ di chuyển với biến isReady.
        /// </summary>
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
                    Invoke(nameof(ResetMove), 0.1f); // delay để giới hạn tốc độ di chuyển
                else
                    isReady = true;
            }
        }

        /// <summary>
        /// Reset trạng thái isReady để tiếp tục nhận lệnh di chuyển mới.
        /// </summary>
        void ResetMove()
        {
            isReady = true;
        }

        /// <summary>
        /// Ghi đè phương thức TryMove để thực hiện logic di chuyển.
        /// Nếu phía trước không bị chặn thì di chuyển thẳng.
        /// Nếu gặp Box, thử đẩy Box đi tiếp theo hướng di chuyển,
        /// nếu thành công thì người chơi di chuyển vào vị trí Box.
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
