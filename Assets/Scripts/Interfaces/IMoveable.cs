namespace GridGame.Interfaces
{
    using UnityEngine;

    public interface IMovable
    {
        bool TryMove(Vector2Int direction);
    }
}