﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
namespace Game1
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private State currentState;
        private State nextState;

        public void ChangeState(State state)
        {
            nextState = state;
        }

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            currentState = new MainMenu(this, _graphics.GraphicsDevice, Content);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            currentState.Update(gameTime);
            if (nextState != null)
            {
                currentState = nextState;
                nextState = null;
            }
            currentState.Update(gameTime);
            //// TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            currentState.Draw(gameTime, _spriteBatch);
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
