using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;

namespace GameShark
{
    class Shark
    {
        private Texture2D _shark;
        
        private Vector2 _position;
        private Vector2 _velocity;
        private double _alpha;
        private Vector2 _origin;
        private float _scale;


        public Shark()
        {
            _shark = null;
        
            _position = new Vector2(600, 300);
            _velocity = new Vector2(0, 0);
            _alpha = 0;
            _scale = 0.16f;
            //_origin = new Vector2(_shark.Width / 2, _shark.Height / 2);
            _origin = new Vector2(0, 0);
        }

        public void LoadContent(ContentManager contentManager)
        {
            _shark = contentManager.Load<Texture2D>("shark");
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_shark,
                _position,
                null,  // прямоугольник
                Color.White,
                (float)_alpha, // угол вращения
                _origin, // точка вращения
                _scale, // коэф масштаб
                SpriteEffects.None,
                1);
        }

        public void Update()
        {
            KeyboardState ks = Keyboard.GetState();
     

            if (ks.IsKeyDown(Keys.Up))
            {
                if (_position.Y > 0)
                {
                    _velocity.Y = _velocity.Y - (float)0.03;
                    _alpha = 0;
                }

            }

            if (ks.IsKeyDown(Keys.Down))
            {
                if (_position.Y < 600)
                {
                    _velocity.Y = _velocity.Y + (float)0.03;
                    _alpha = Math.PI;
                }

            }


            if (_position.X > 1200)
            {
                _position.X = 0;
            }

            if (_position.X < 0)
            {
                _position.X = 1200;
            }

            if (_position.Y > 600)
            {
                _position.Y = 0;
            }

            if (_position.Y < 0)
            {
                _position.Y = 600;
            }


            /*
            _position.X++;
            _position.Y++;
            */
            _position += _velocity;
        }


    }
}
