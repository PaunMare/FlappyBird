using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
namespace Game1
{
    public class Endgame : State
    {
        SpriteFont font;
        float score;
        public Endgame(Game1 game1, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game1, graphicsDevice, contentManager)
        {

            this._game = game1;
            this._graphicsDevice = graphicsDevice;
            this._contentManager = contentManager;
            
            
        }
        public Endgame(Game1 game1, GraphicsDevice graphicsDevice, ContentManager contentManager,float score) : base(game1, graphicsDevice, contentManager)
        {

            this._game = game1;
            this._graphicsDevice = graphicsDevice;
            this._contentManager = contentManager;
            font = _contentManager.Load<SpriteFont>("File");
            
            this.score = score;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(_contentManager.Load<Texture2D>("endgame"), new Vector2(0f, 0f), Color.White);
            spriteBatch.DrawString(font, "Your score is: " + score.ToString("0")+".\nPress \"Enter\" to return to the start menu.", new Vector2(166f,124f), Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter)){
                _game.ChangeState(new MainMenu(_game, _graphicsDevice, _contentManager));
            }
        }
    }
}
