using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace GameAquaman.GameObjects
{
    class Shark : BaseObject
    {
        public Shark(Vector2 position, double alpha, float scale)
            : base(position, alpha, scale) { }


        public new void LoadContent(ContentManager contentManager, string image)
        {
            _tex = contentManager.Load<Texture2D>(image);
        }

        public override void Update(double speedShark)
        {
            _position.X = _position.X - (int)speedShark;


            if (_position.X < 0)
            {
                RandomSpaceShark();
            }
        }

        public void RandomSpaceShark()
        {
            Random rand = new Random();
            _position.X = 1360;
            _position.Y = rand.Next(10, 600);
        }
    }
}
