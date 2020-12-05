using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Obstacle:Sprite
    {
        float time=10f;
        float nextStep = 10f;
        float speed = 1.5f;
        public Obstacle(Texture2D texture,Vector2 position):base(texture,position)
        {
            this.texture = texture;
            this.position = position;
        }
        public void Update(GameTime gameTime)
        {
            if(gameTime.TotalGameTime.TotalSeconds >= time)
            {
                speed += 0.3f;
                time += nextStep;
            }
            position.X -= speed;
        }
       
    }
}
