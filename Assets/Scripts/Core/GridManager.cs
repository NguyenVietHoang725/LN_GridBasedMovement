using System.Collections.Generic;
using UnityEngine;
using GridGame.Objects;

namespace GridGame.Core
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance { get; private set; }

        private Dictionary<Vector2Int, List<GridObject>> gridMap = new();

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void RegisterObject(Vector2Int position, GridObject obj)
        {
            if (!gridMap.ContainsKey(position))
            {
                gridMap[position] = new List<GridObject>();
            }
            gridMap[position].Add(obj);
        }

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

        public bool IsBlocked(Vector2Int pos)
        {
            if (!gridMap.ContainsKey(pos)) return false;

            foreach (var obj in gridMap[pos])
            {
                if (obj.IsBlocking()) return true;
            }

            return false;
        }

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