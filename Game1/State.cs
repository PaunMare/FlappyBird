using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
     public abstract class State
    {
        public ContentManager _contentManager;
        public GraphicsDevice _graphicsDevice;
        public Game1 _game;

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
       

        public State(Game1 game1,GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            this._game = game1;
            this._graphicsDevice = graphicsDevice;
            this._contentManager = contentManager;
        }
    }
}
