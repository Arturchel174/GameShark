using GameAquaman.GameObjects;
using Microsoft.Xna.Framework;

namespace GameAquaman.GameLogic
{
    class CollideAquamanShark : Collide
    {
        public bool CollideShark(Aquaman aquaman, Shark shark)
        {
            aquamanSize = new Point(aquaman._tex.Width, aquaman._tex.Height);
            sharkSize = new Point(shark._tex.Width, shark._tex.Height);

            Rectangle aquamanRect = new Rectangle((int)aquaman._position.X,
                (int)aquaman._position.Y, aquamanSize.X, aquamanSize.Y);
            Rectangle sharkRect = new Rectangle((int)shark._position.X,
                (int)shark._position.Y, sharkSize.X, sharkSize.Y);

            return aquamanRect.Intersects(sharkRect);
        }
    }
}
