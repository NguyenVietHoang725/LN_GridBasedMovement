using UnityEngine;

namespace GridGame.Objects
{
    public class Obstacle : GridObject
    {
        public override bool IsBlocking()
        {
            return true;
        }
    }
}