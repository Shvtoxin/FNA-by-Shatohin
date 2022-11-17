using FNA1._0.Properties;
using FNA1._0.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Resources;

namespace FNAshato
{
    public class Solution : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager Screen;
        SpriteBatch PaintScreen;
        Texture2D BackgroundImg, SnowImg;
        public List<Snow> SnowList = new List<Snow>();
        private KeyboardState currentState = Keyboard.GetState();
        private KeyboardState State;
        private Random rand = new Random();

        public Solution()
        {
            Screen = new GraphicsDeviceManager(this);
            Screen.IsFullScreen = true;
            IsMouseVisible = false;
            generateSnow();
            Screen.ApplyChanges(); 
            Content.RootDirectory= "..\\..\\img";
        }
        protected override void LoadContent()
        {
            PaintScreen = new SpriteBatch(GraphicsDevice);
            BackgroundImg = TextureLoader.Load("background", Content);
            SnowImg = TextureLoader.Load("snowflake", Content);
        }

        public void generateSnow()
        {
            for (int i = 0; i < 4000; i++)
            {
                SnowList.Add(new Snow
                {
                    X = rand.Next(Screen.PreferredBackBufferWidth),
                    Y = -rand.Next(Screen.PreferredBackBufferHeight),
                    Size = rand.Next(3, 13),
                });
            }
        }

        protected override void Update(GameTime gameTime)
        {
            State = currentState;
            currentState = Keyboard.GetState();

            if (State.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var snow in SnowList)
            {
                if (snow.Size < 9)
                {
                    snow.Y += rand.Next(1, 3);               
                }
                else
                {
                    snow.Y += rand.Next(2, 4);
                }
                if (snow.Y > Screen.PreferredBackBufferHeight)
                {
                   snow.Y = -rand.Next(0, 50);
                   snow.X = rand.Next(0, Screen.PreferredBackBufferWidth);
                }
            }
        }

       protected override void Draw(GameTime gameTime)
       {
           PaintScreen.Begin();
           PaintScreen.Draw(BackgroundImg, new Rectangle(0, 0, Screen.PreferredBackBufferWidth, Screen.PreferredBackBufferHeight),Color.White);
           foreach (var snowflake in SnowList)
           {
               PaintScreen.Draw(SnowImg, new Rectangle(snowflake.X, snowflake.Y, snowflake.Size, snowflake.Size), Color.White);
           }
           PaintScreen.End();
        }
    } 

}