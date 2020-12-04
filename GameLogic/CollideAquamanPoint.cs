using GameAquaman.GameObjects;
using Microsoft.Xna.Framework;

namespace GameAquaman.GameLogic
{
    class CollideAquamanCoin : Collide
    {
        public bool CollideCoin(Aquaman aquaman, Coin coin)
        {
            aquamanSize = new Point(aquaman._tex.Width, aquaman._tex.Height);
            coinSize = new Point(coin._tex.Width, coin._tex.Height);

            Rectangle aquamanRect = new Rectangle((int)aquaman._position.X,
                (int)aquaman._position.Y, aquamanSize.X, aquamanSize.Y);
            Rectangle coinRect = new Rectangle((int)coin._position.X,
                (int)coin._position.Y, coinSize.X, coinSize.Y);

            return aquamanRect.Intersects(coinRect);
        }
    }
}
