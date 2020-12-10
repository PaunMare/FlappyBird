using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public class GameState : State
    {
        public GameState(Game1 game1, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game1, graphicsDevice, contentManager)
        {
            this._game = game1;
            this._graphicsDevice = graphicsDevice;
            this._contentManager = contentManager;
            background = _contentManager.Load<Texture2D>("backround");
            ground = _contentManager.Load<Texture2D>("ground1");
            player = new Player(_contentManager.Load<Texture2D>("smile"), new Vector2(100f, 100f), new Vector2(), obstacles);

            font = _contentManager.Load<SpriteFont>("File");

            top = new Obstacle(_contentManager.Load<Texture2D>("ground1"), new Vector2(0f, 0f - _contentManager.Load<Texture2D>("ground1").Height));
            bottom = new Obstacle(_contentManager.Load<Texture2D>("ground1"), new Vector2(0f,graphicsDevice.Viewport.Height ));

            left = new Sprite(contentManager.Load<Texture2D>("left"),new Vector2(0f-_contentManager.Load<Texture2D>("left").Width,_graphicsDevice.Viewport.Height - contentManager.Load<Texture2D>("left").Height));
            obstacles = new List<Obstacle>();
                 
        }

        public SpriteFont font;

        public float checkPoint = 100f;

        Sprite left;
   
        Obstacle top, bottom;
        Player player;

        
        List<Obstacle> obstacles = new List<Obstacle>();
        List<Obstacle> obs = new List<Obstacle>();
        float score = 0;

        float spawnTime = 3f;
        float passedTime = 0f;

        Texture2D background;
        Texture2D ground;
        Random random = new Random();
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.White);
            
            spriteBatch.Begin();
            left.Draw(spriteBatch);
            spriteBatch.Draw(background, new Vector2(0f, 0f), Color.White);
            spriteBatch.Draw(ground, new Vector2(0f, this._graphicsDevice.Viewport.Height - 100f), Color.White);
            player.Draw(spriteBatch); 
            top.Draw(spriteBatch);
            bottom.Draw(spriteBatch);
            Paint(spriteBatch);
            spriteBatch.DrawString(font, "Score: " + score.ToString("0"), new Vector2(50f, _graphicsDevice.Viewport.Height - 50f), Color.White);
            spriteBatch.End();
        }
        public override void Update(GameTime gameTime)
        {
            
            player.Update(gameTime);
            foreach (Obstacle obstacle in obs)
            {
                if (player.IsTouchingDown(obstacle))
                {
                    _game.ChangeState(new Endgame(_game, _graphicsDevice, _contentManager, score));
                }
                if (player.IsTouchingTop(obstacle))
                {
                    _game.ChangeState(new Endgame(_game, _graphicsDevice, _contentManager, score));
                }
                if (player.IsTouchingRight(obstacle))
                {
                    _game.ChangeState(new Endgame(_game, _graphicsDevice, _contentManager, score));

                }
                if (player.IsTouchingLeft(obstacle))
                {
                    _game.ChangeState(new Endgame(_game, _graphicsDevice, _contentManager, score));
                }
            }
            if (player.IsTouchingTop(bottom))
            {
                _game.ChangeState(new Endgame(_game, _graphicsDevice, _contentManager, score));
            }
            if (player.IsTouchingDown(top))
            {
                _game.ChangeState(new Endgame(_game, _graphicsDevice, _contentManager, score));
            }

            Spawn();
            Move(gameTime);
            Delete();
            passedTime += 0.01f;
            if (spawnTime > 2f)
            {
                spawnTime -= 0.0005f;
            }
            if (score > checkPoint)
            {
                Obstacle.speed += 0.3f;
                checkPoint += checkPoint;
            }

            score += 0.05f;
        }
        public void Move(GameTime gameTime)
        {
            foreach(Obstacle o in obs)
            {
                o.Update(gameTime);
            }
        }
        public void Paint(SpriteBatch spriteBatch)
        {
            foreach (Obstacle o in obs)
            {
                o.Draw(spriteBatch);
            }
        }
        public void Spawn()
        {
            if (passedTime > spawnTime)
            {
                int i = random.Next(5);
                if (i == 0)
                {
                    obs.Add(new Obstacle(_contentManager.Load<Texture2D>("obstacle210"), new Vector2(_graphicsDevice.Viewport.Width, 0f)));
                    obs.Add(new Obstacle(_contentManager.Load<Texture2D>("obstacle130"), new Vector2(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle130").Height)));
                }
                else
                    if (i == 1)
                {
                    obs.Add(new Obstacle(_contentManager.Load<Texture2D>("obstacle170"), new Vector2(_graphicsDevice.Viewport.Width, 0f)));
                    obs.Add(new Obstacle(_contentManager.Load<Texture2D>("obstacle170"), new Vector2(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle170").Height)));
                }

                else
                    if (i == 2)
                {
                    obs.Add(new Obstacle(_contentManager.Load<Texture2D>("obstacle130"), new Vector2(_graphicsDevice.Viewport.Width, 0f)));
                    obs.Add(new Obstacle(_contentManager.Load<Texture2D>("obstacle210"), new Vector2(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle210").Height)));

                }
                else
                    if(i == 3)
                {
                    obs.Add(new Obstacle(_contentManager.Load<Texture2D>("obstacle90"), new Vector2(_graphicsDevice.Viewport.Width, 0f)));
                    obs.Add(new Obstacle(_contentManager.Load<Texture2D>("obstacle250"), new Vector2(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle250").Height)));
                }
                else
                    if(i == 4)
                {
                    obs.Add(new Obstacle(_contentManager.Load<Texture2D>("obstacle250"), new Vector2(_graphicsDevice.Viewport.Width, 0f)));
                    obs.Add(new Obstacle(_contentManager.Load<Texture2D>("obstacle90"), new Vector2(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle90").Height)));
                }
                passedTime = 0f;
            }

        }
        public void Delete()
        {
            foreach(Obstacle o in obs)
            {
                if (o.IsTouchingRight(left))
                    o.isRemoved = true;
            }
            if (obs.Count > 0)
            {
                for (int i = 0; i < obs.Count; i++)
                {
                    Obstacle o = obs[i];
                    if (o.isRemoved)
                    {
                        obs.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

    }
}
