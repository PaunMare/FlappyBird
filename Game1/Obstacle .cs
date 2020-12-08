using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    [Serializable]
    public class Obstacle:Sprite
    {
        public float time=10f;
        public float nextStep = 10f;
        public static float speed = 1.5f;
        public bool isRemoved = false;
       
        public Obstacle(Texture2D texture,Vector2 position):base(texture,position)
        {
           
            this.texture = texture;
            this.position = position;
        }
        public void Update(GameTime gameTime)
        {
            if(gameTime.TotalGameTime.TotalSeconds >= time)
            {
                speed += 0.15f;
                time += nextStep;
            }
            this.position.X -= speed;

        }

        //public void RemoveObstacle()
        //{
           
        //    if(up.position.X == -20f)
        //    {
        //        this.isRemoved = true;
        //    }
        //}
        
       
    }
}
