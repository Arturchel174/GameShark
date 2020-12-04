using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameAquaman.GameObjects
{
    class Aquaman : BaseObject
    {
        public Aquaman(Vector2 position, double alpha, float scale)
            : base(position, alpha, scale) { }

        public override void Update(double speedAquaman)
        {
            KeyboardState ks = Keyboard.GetState();
            Keys[] keys = ks.GetPressedKeys();

            Vector2 delta = new Vector2(0, 0);
            float rotate = (float)Math.PI / 180;

            foreach (var key in keys)
            {
                switch(key)
                {
                    case Keys.Left:
                        _alpha -= rotate*2;
                        break;
                    case Keys.Right:
                        _alpha += rotate*2;
                        break;
                    case Keys.Down:
                        delta.X = -(float)(speedAquaman * Math.Sin(_alpha));
                        delta.Y = (float)(speedAquaman * Math.Cos(_alpha));
                        break;
                    case Keys.Up:
                        delta.X = (float)(speedAquaman * Math.Sin(_alpha));
                        delta.Y = -(float)(speedAquaman * Math.Cos(_alpha));
                        break;

                    case Keys.B:
                        if (_scale < 1.5f)
                        {
                            _scale = _scale + 0.01f;
                        }
                        break;
                    case Keys.M:
                        if (_scale > 0.2f)
                        {
                            _scale = _scale - 0.01f;
                        }
                        break;
                }

                //Поворот назад влево и вправо
                if (ks.IsKeyDown(Keys.Down))
                {
                    if (ks.IsKeyDown(Keys.Left))
                    {
                        delta.X = -(float)(speedAquaman * Math.Sin(_alpha));
                        delta.Y = (float)(speedAquaman * Math.Cos(_alpha));
                        _alpha += rotate * 2;
                    }
                    if (ks.IsKeyDown(Keys.Right))
                    {
                        delta.X = -(float)(speedAquaman * Math.Sin(_alpha));
                        delta.Y = (float)(speedAquaman * Math.Cos(_alpha));
                        _alpha -= rotate * 2;
                    }
                }
            }

            // проверка на выход за грани карты
            if (_position.X > 1310)
            {
                _position.X = 1310;
            }

            if (_position.X < 40)
            {
                _position.X = 40;
            }

            if (_position.Y > 660)
            {
                _position.Y = 660;
            }

            if (_position.Y < 40)
            {
                _position.Y = 40;
            }

            _position += delta;
        }
    }
}
