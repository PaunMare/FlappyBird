using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public class MainMenu : State
    {
        
        public MainMenu(Game1 game1,GraphicsDevice graphicsDevice,ContentManager contentManager) : base(game1, graphicsDevice, contentManager)
        {
            
            this._game = game1;
            this._graphicsDevice = graphicsDevice;
            this._contentManager = contentManager;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(_contentManager.Load<Texture2D>("mainmenu"), new Vector2(0f, 0f), Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                Quit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                NewGame();
            }
        }
        public void Quit()
        {
            _game.Exit();
        }
        public void NewGame()
        {
            Obstacle.speed = 1.5f;
           _game.ChangeState(new GameState(_game,_graphicsDevice,_contentManager));
        }

    }
}
