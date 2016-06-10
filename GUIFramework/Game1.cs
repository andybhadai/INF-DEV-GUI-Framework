using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GUIFramework
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        List<Label> LabelList = new List<Label>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Default_Font");
            LabelList.Add(new Label("Label 1", new Vector2(0, 0)));
            LabelList.Add(new Label("Label 2", new Vector2(50, 0)));
            LabelList.Add(new Label("Label 3", new Vector2(100, 0)));
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Draw every label
            foreach(var label in LabelList)
            {
                Option<Label> LabelOption = new Some<Label>(label);
                LabelOption.Visit<object>
                    (() => { throw new Exception("Expecting a label!"); }, l => { l.Draw(spriteBatch, font); return null; });
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
