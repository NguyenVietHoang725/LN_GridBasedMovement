using UnityEngine;
using GridGame.Interfaces;
using GridGame.Core;

namespace GridGame.Objects
{   
    /// <summary>
    /// Lớp cơ sở trừu tượng đại diện cho mọi đối tượng trong lưới (grid).
    /// Các đối tượng kế thừa có thể di chuyển (IMovable).
    /// </summary>
    public abstract class GridObject : MonoBehaviour, IMovable
    {   
        /// <summary>
        /// Vị trí hiện tại của đối tượng trên grid (dạng Vector2Int).
        /// </summary>
        public Vector2Int GridPosition { get; protected set; }
        
        /// <summary>
        /// Khởi tạo đối tượng: lấy vị trí theo transform, đăng ký đối tượng vào GridManager.
        /// </summary>
        protected virtual void Start()
        {
            GridPosition = Vector2Int.RoundToInt(transform.position);
            GridManager.Instance.RegisterObject(GridPosition, this);
        }
        
        /// <summary>
        /// Thử di chuyển đối tượng theo hướng direction.
        /// Trả về true nếu di chuyển thành công, false nếu không.
        /// Mặc định không di chuyển được (bắt buộc override).
        /// </summary>
        /// <param name="direction">Hướng di chuyển (Vector2Int)</param>
        /// <returns>bool</returns>
        public virtual bool TryMove(Vector2Int direction)
        {
            return false;
        }
        
        /// <summary>
        /// Kiểm tra đối tượng này có chặn đường không (blocking).
        /// Mặc định trả về false, override trong các class con nếu cần.
        /// </summary>
        /// <returns>bool</returns>
        public virtual bool IsBlocking()
        {
            return false;
        }
        
        /// <summary>
        /// Thực hiện di chuyển đối tượng đến vị trí mới,
        /// cập nhật vị trí trong GridManager và vị trí vật lý (transform).
        /// </summary>
        /// <param name="newPos">Vị trí mới trên grid</param>
        protected void MoveTo(Vector2Int newPos)
        {
            GridManager.Instance.UpdatePosition(GridPosition, newPos, this);
            GridPosition = newPos;
            transform.position = new Vector3(newPos.x, newPos.y, 0f);
        }
    }
}