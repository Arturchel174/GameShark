using GameAquaman.GameLogic;
using GameAquaman.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GameShark
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //(Местоположение, угол поворота, размер)
        Aquaman aquaman = new Aquaman(new Vector2(670, 350), 0 , 1f);

        static Random rand = new Random();
        //(Местоположение, угол поворота, размер)
        Coin coin1 = new Coin(new Vector2(rand.Next(40, 1300), rand.Next(30, 700)), Math.PI, 1.2f);
        Coin coin2 = new Coin(new Vector2(rand.Next(40, 1300), rand.Next(30, 700)), Math.PI / 2, 1.2f);
        Coin coin3 = new Coin(new Vector2(rand.Next(40, 1300), rand.Next(30, 700)), Math.PI, 1.2f);

        //(Местоположение, угол поворота, размер)
        Shark shark = new Shark(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI/180, 1f);
        Shark shark2 = new Shark(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI / 180, 0.9f);
        Shark shark3 = new Shark(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI / 180, 1f);
        Shark shark4 = new Shark(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI / 180, 1.5f);
        Shark shark5 = new Shark(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI / 180, 0.8f);
        Shark shark6 = new Shark(new Vector2(rand.Next(1200, 1300), rand.Next(30, 700)), Math.PI / 180, 1.2f);

        CollideAquamanShark collideAquamanShark = new CollideAquamanShark();      //Класс столкновения
        CollideAquamanCoin collideAquamanCoin = new CollideAquamanCoin();   //Класс столкновения

        private Texture2D background;   //фон
        SpriteFont gameOver;            //шрифт для GameOver
        int cosm=0;                     //счетчик Coins
        int HP=100;                       //счетчик HP
        private Texture2D _coin;        //картинка coin
        SpriteFont textCosm;            //шрифт для очков

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1350;
            graphics.PreferredBackBufferHeight = 700;
            //graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            base.Initialize(); // здесь загружается текстура
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("background");
            gameOver = Content.Load<SpriteFont>("FontGameOver");
            textCosm = Content.Load<SpriteFont>("Font");
            _coin = Content.Load<Texture2D>("point");

            aquaman.LoadContent(Content, "aquaman");

            coin1.LoadContent(Content, "point");
            coin2.LoadContent(Content, "point");
            coin3.LoadContent(Content, "point");

            shark.LoadContent(Content, "shark_1");
            shark2.LoadContent(Content, "shark_2");
            shark3.LoadContent(Content, "shark_2");
            shark4.LoadContent(Content, "shark_1");
            shark5.LoadContent(Content, "shark_2");
            shark6.LoadContent(Content, "shark_1");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            aquaman.Update(4);

            coin1.Update(0.01);
            coin2.Update(-0.005);
            coin3.Update(-0.003);

            shark.Update(3);
            shark2.Update(4);
            shark3.Update(5);
            shark4.Update(6);
            shark5.Update(5);
            shark6.Update(4);

            #region

            List<Coin> coins = new List<Coin>();
            coins.Add(coin1);
            coins.Add(coin2);
            coins.Add(coin3);

            foreach (Coin coin in coins)
            {
                if (collideAquamanCoin.CollideCoin(aquaman, coin))
                {
                    aquaman._color = Color.Green;
                    coin.RandomSpaceCoin();
                    cosm++;
                }
                else
                {
                    aquaman._color = Color.White;
                }
            }
            #endregion

            #region

            List<Shark> sharks = new List<Shark>();
            sharks.Add(shark);
            sharks.Add(shark2);
            sharks.Add(shark3);
            sharks.Add(shark4);
            sharks.Add(shark5);
            sharks.Add(shark6);

            foreach (Shark shark in sharks)
            {
                if (collideAquamanShark.CollideShark(aquaman, shark))
                {
                    aquaman._color = Color.Red;
                    shark.RandomSpaceShark();
                    HP--;
                }
                else
                {
                    aquaman._color = Color.White;
                }
            }
            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 1350, 700), Color.Gray);
            spriteBatch.Draw(_coin, new Rectangle(10, 10, 30, 30), Color.White);

            aquaman.Draw(spriteBatch);

            coin1.Draw(spriteBatch);
            coin2.Draw(spriteBatch);
            coin3.Draw(spriteBatch);

            shark.Draw(spriteBatch);
            shark2.Draw(spriteBatch);
            shark3.Draw(spriteBatch);
            shark4.Draw(spriteBatch);
            shark5.Draw(spriteBatch);
            shark6.Draw(spriteBatch);

            string stringCosm = $"{cosm}";
            spriteBatch.DrawString(textCosm, stringCosm, new Vector2(50, 7), Color.WhiteSmoke); // вывод очков

            if (HP<1)          // Конец игры
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, 1350, 700), Color.Black);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
