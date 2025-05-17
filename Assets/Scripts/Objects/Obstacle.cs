using UnityEngine;

namespace GridGame.Objects
{
    /// <summary>
    /// Vật cản tĩnh không thể di chuyển và chặn đường.
    /// </summary>
    public class Obstacle : GridObject
    {
        /// <summary>
        /// Luôn chặn đường đi qua.
        /// </summary>
        /// <returns>bool</returns>
        public override bool IsBlocking()
        {
            return true;
        }
    }
}