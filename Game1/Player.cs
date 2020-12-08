using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Player : Sprite
    {
        public float jumpForce = 3f;
        public bool jump;
        List<Obstacle> obstacles;
        public Player(Texture2D texture, Vector2 position, Vector2 velocity, List<Obstacle> obstacles) : base(texture, position, velocity)
        {
            this.obstacles = obstacles;
            this.texture = texture;
            this.position = position;
            this.velocity = velocity;
            jump = true;
        }
        public void Update(GameTime gameTime)
        {
            
            position += velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {

                velocity.Y = -2.5f;
                jump = true;
            }
            if (jump)
            {
                float i = 1f;
                velocity.Y += 0.1f * i;
            }
            if (!jump)
            {
                velocity.Y = 0f;
            }
        }

    }
}
