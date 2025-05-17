using System.Collections.Generic;
using UnityEngine;
using GridGame.Objects;

namespace GridGame.Core
{
    /// <summary>
    /// Quản lý toàn bộ các đối tượng trong grid,
    /// lưu trữ vị trí và trạng thái của chúng,
    /// hỗ trợ đăng ký, cập nhật vị trí, kiểm tra vật cản.
    /// </summary>
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance { get; private set; }

        /// <summary>
        /// Lưu danh sách các đối tượng tại từng vị trí (Vector2Int).
        /// Một vị trí có thể chứa nhiều đối tượng (danh sách).
        /// </summary>
        private Dictionary<Vector2Int, List<GridObject>> gridMap = new();

        /// <summary>
        /// Đảm bảo singleton instance.
        /// </summary>
        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        /// <summary>
        /// Đăng ký đối tượng mới vào vị trí trên grid.
        /// </summary>
        /// <param name="position">Vị trí trên grid</param>
        /// <param name="obj">Đối tượng GridObject</param>
        public void RegisterObject(Vector2Int position, GridObject obj)
        {
            if (!gridMap.ContainsKey(position))
            {
                gridMap[position] = new List<GridObject>();
            }
            gridMap[position].Add(obj);
        }

        /// <summary>
        /// Cập nhật vị trí đối tượng trên grid:
        /// Xóa khỏi vị trí cũ, thêm vào vị trí mới.
        /// Nếu vị trí cũ không còn đối tượng nào, xoá khỏi map.
        /// </summary>
        /// <param name="oldPos">Vị trí cũ</param>
        /// <param name="newPos">Vị trí mới</param>
        /// <param name="obj">Đối tượng GridObject</param>
        public void UpdatePosition(Vector2Int oldPos, Vector2Int newPos, GridObject obj)
        {
            if (gridMap.ContainsKey(oldPos))
            {
                gridMap[oldPos].Remove(obj);
                if (gridMap[oldPos].Count == 0)
                    gridMap.Remove(oldPos);
            }

            if (!gridMap.ContainsKey(newPos))
            {
                gridMap[newPos] = new List<GridObject>();
            }
            gridMap[newPos].Add(obj);
        }

        /// <summary>
        /// Kiểm tra vị trí có bị chặn hay không,
        /// dựa trên các đối tượng tại vị trí đó có thuộc loại blocking.
        /// </summary>
        /// <param name="pos">Vị trí cần kiểm tra</param>
        /// <returns>True nếu có vật cản, false nếu không</returns>
        public bool IsBlocked(Vector2Int pos)
        {
            if (!gridMap.ContainsKey(pos)) return false;

            foreach (var obj in gridMap[pos])
            {
                if (obj.IsBlocking()) return true;
            }

            return false;
        }

        /// <summary>
        /// Lấy một đối tượng ở vị trí nhất định,
        /// trả về đối tượng đầu tiên tìm thấy (không null).
        /// </summary>
        /// <param name="pos">Vị trí cần lấy</param>
        /// <returns>GridObject hoặc null nếu không có</returns>
        public GridObject GetObjectAt(Vector2Int pos)
        {
            if (!gridMap.ContainsKey(pos)) return null;

            foreach (var obj in gridMap[pos])
            {
                if (obj != null) return obj;
            }

            return null;
        }
    }
}
