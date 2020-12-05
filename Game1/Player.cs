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
        public float jumpForce = 5f;
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
            Collision();
            position += velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                position.Y -= jumpForce;
                velocity.Y = -5f;
                jump = true;
            }
            if (jump)
            {
                float i = 1f;
                velocity.Y += 0.15f * i;
            }
            if (!jump)
            {
                velocity.Y = 0f;
            }
        }
        public void Collision()
        {
            foreach (Obstacle obstacle in obstacles)
            {
                if (this.IsTouchingDown(obstacle))
                {
                    
                }
                if (this.IsTouchingTop(obstacle))
                {

                }
                if (this.IsTouchingRight(obstacle))
                {

                }
                if (this.IsTouchingLeft(obstacle))
                {

                }
            }
        }

    }
}
