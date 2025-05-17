using UnityEngine;
using GridGame.Interfaces;
using GridGame.Core;

namespace GridGame.Objects
{
    public abstract class GridObject : MonoBehaviour, IMovable
    {
        public Vector2Int GridPosition { get; protected set; }

        protected virtual void Start()
        {
            GridPosition = Vector2Int.RoundToInt(transform.position);
            GridManager.Instance.RegisterObject(GridPosition, this);
        }

        public virtual bool TryMove(Vector2Int direction)
        {
            return false;
        }

        public virtual bool IsBlocking()
        {
            return false;
        }

        protected void MoveTo(Vector2Int newPos)
        {
            GridManager.Instance.UpdatePosition(GridPosition, newPos, this);
            GridPosition = newPos;
            transform.position = new Vector3(newPos.x, newPos.y, 0f);
        }
    }
}