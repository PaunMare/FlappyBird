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

            spawningPositionUp = new Vector2(_graphicsDevice.Viewport.Width, 0f);
            spawningPositionUp1 = new Vector2(_graphicsDevice.Viewport.Width + 200f, 0f);
            spawningPositionUp2 = new Vector2(_graphicsDevice.Viewport.Width + 400f, 0f);
            spawningPositionUp3 = new Vector2(_graphicsDevice.Viewport.Width + 600f, 0f);
            spawningPositionDown = new Vector2(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle210").Height);
            spawningPositionDown1 = new Vector2(_graphicsDevice.Viewport.Width + 200f, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle170").Height);
            spawningPositionDown2 = new Vector2(_graphicsDevice.Viewport.Width + 400f, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle130").Height);
            spawningPositionDown3 = new Vector2(_graphicsDevice.Viewport.Width + 600f, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle170").Height);
            spawningPositionDown12 = new Vector2(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle170").Height);
            spawningPositionDown22 = new Vector2(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height - _contentManager.Load<Texture2D>("obstacle130").Height);
            

            font = _contentManager.Load<SpriteFont>("File");

            up1 = new Obstacle(_contentManager.Load<Texture2D>("obstacle130"), spawningPositionUp);
            up2 = new Obstacle(_contentManager.Load<Texture2D>("obstacle170"), spawningPositionUp1);
            up3 = new Obstacle(_contentManager.Load<Texture2D>("obstacle210"), spawningPositionUp2);
            up4 = new Obstacle(_contentManager.Load<Texture2D>("obstacle170"), spawningPositionUp3);
            down1 = new Obstacle(_contentManager.Load<Texture2D>("obstacle210"), spawningPositionDown);
            down2 = new Obstacle(_contentManager.Load<Texture2D>("obstacle170"), spawningPositionDown1);
            down3 = new Obstacle(_contentManager.Load<Texture2D>("obstacle130"), spawningPositionDown2);
            down4 = new Obstacle(_contentManager.Load<Texture2D>("obstacle170"), spawningPositionDown3);
            left = new Sprite(contentManager.Load<Texture2D>("wall2"),new Vector2(0f-_contentManager.Load<Texture2D>("wall2").Width,_graphicsDevice.Viewport.Height - contentManager.Load<Texture2D>("wall2").Height));
            obstacles = new List<Obstacle>();
            obstacles.Add(down1);
            obstacles.Add(up1);
            obstacles.Add(down2);
            obstacles.Add(up2);
            obstacles.Add(down3);
            obstacles.Add(up3);
            obstacles.Add(down4);
            obstacles.Add(up4);
        }

        public SpriteFont font;

      

        public Vector2 spawningPositionUp, spawningPositionUp1, spawningPositionUp2,spawningPositionUp3;
        public Vector2 spawningPositionDown, spawningPositionDown1, spawningPositionDown2,spawningPositionDown3;
        public Vector2 spawningPositionDown12, spawningPositionDown22;
        public Vector2 leftSide;

        Sprite left;
        

        Obstacle up3, down3, up1, up2, down1, down2,up4,down4;

        Player player;

        
        List<Obstacle> obstacles = new List<Obstacle>();
        float score = 0;

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
            left.Draw(spriteBatch);
            down1.Draw(spriteBatch);
            up1.Draw(spriteBatch);
            down2.Draw(spriteBatch);
            up2.Draw(spriteBatch);
            down3.Draw(spriteBatch);
            up3.Draw(spriteBatch);
            down4.Draw(spriteBatch);
            up4.Draw(spriteBatch);
           
            
            spriteBatch.DrawString(font, "Score: " + score.ToString("0"), new Vector2(50f, _graphicsDevice.Viewport.Height - 50f), Color.White);
            spriteBatch.End();
        }
        public override void Update(GameTime gameTime)
        {
            
            player.Update(gameTime);
            if (down1.IsTouchingRight(left))
            {
                down1.position = spawningPositionDown;
                up1.position = spawningPositionUp;
            }
            if (down2.IsTouchingRight(left))
            {
                down2.position = spawningPositionDown12;
                up2.position = spawningPositionUp;
            }
            if (down3.IsTouchingRight(left))
            {
                down3.position = spawningPositionDown22;
                up3.position = spawningPositionUp;
            }
            if (down4.IsTouchingRight(left))
            {
                down4.position = spawningPositionDown12;
                up4.position = spawningPositionUp;
            }
            foreach (Obstacle obstacle in obstacles)
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


            down1.Update(gameTime);
            up1.Update(gameTime);
            down2.Update(gameTime);
            up2.Update(gameTime);
            down3.Update(gameTime);
            up3.Update(gameTime);
            down4.Update(gameTime);
            up4.Update(gameTime);
            //foreach(Obstacle o in obs)
            //{
            //    o.Update(gameTime);
            //}
            //for(int i = 0; i < obs.Count; i++)
            //{
            //    Obstacle o = obs[i];
            //    if (o.isRemoved)
            //    {
            //        obs.RemoveAt(i);
            //        i--;
            //    }
            //}

            score += 0.05f;
        }

        //public void SpawnObstacle(List<Obstacle> obs, Sprite[] sprites)
        //{
           
        //   int i = random.Next(3);
        //   switch (i)
        //    {
        //        case 0:
        //            {
        //                Obstacle o = new Obstacle(sprites[0], sprites[3]);
        //                obs.Add(o);
        //                return;
        //            }
        //        case 1: 
        //            {
        //                Obstacle o = new Obstacle(sprites[1], sprites[4]);
        //                obs.Add(o);
        //                return;
        //            }
        //        case 2:
        //            {
        //                Obstacle o = new Obstacle(sprites[2], sprites[5]);
        //                obs.Add(o);
        //                return;
        //            }
        //    }
        //}

    }
}
