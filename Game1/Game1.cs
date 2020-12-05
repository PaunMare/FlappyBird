using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Vector2 spawningPositionUp, spawningPositionUp1, spawningPositionUp2;
        public Vector2 spawningPositionDown, spawningPositionDown1, spawningPositionDown2;
        public Vector2 spawningPositionDown12, spawningPositionDown22;
        public Vector2 leftSide;

        Sprite left;

        Obstacle down1,down2,down3;
        Obstacle up1,up2,up3;

        float score;

        Texture2D background;
        Texture2D ground;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            background = Content.Load<Texture2D>("backround");
            ground = Content.Load<Texture2D>("ground1");


            spawningPositionUp = new Vector2(GraphicsDevice.Viewport.Width, 0f);
            spawningPositionUp1 = new Vector2(GraphicsDevice.Viewport.Width + 267f, 0f);
            spawningPositionUp2 = new Vector2(GraphicsDevice.Viewport.Width + 534f, 0f);

            spawningPositionDown = new Vector2(GraphicsDevice.Viewport.Width , GraphicsDevice.Viewport.Height - Content.Load<Texture2D>("obstacle240").Height );
            spawningPositionDown1 = new Vector2(GraphicsDevice.Viewport.Width + 267f, GraphicsDevice.Viewport.Height - Content.Load<Texture2D>("obstacle190").Height);
            spawningPositionDown2 = new Vector2(GraphicsDevice.Viewport.Width + 534f, GraphicsDevice.Viewport.Height - Content.Load<Texture2D>("obstacle").Height);
            spawningPositionDown12 = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height - Content.Load<Texture2D>("obstacle190").Height);
            spawningPositionDown22 = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height - Content.Load<Texture2D>("obstacle").Height);
            leftSide = new Vector2(0 - Content.Load<Texture2D>("wall2").Width, 350f);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            left = new Sprite(Content.Load<Texture2D>("wall2"), leftSide);
            
            down1 = new Obstacle(Content.Load<Texture2D>("obstacle240"), spawningPositionDown);
            up1 =  new Obstacle(Content.Load<Texture2D>("obstacle"),spawningPositionUp);

            down2 = new Obstacle(Content.Load<Texture2D>("obstacle190"), spawningPositionDown1);
            up2 = new Obstacle(Content.Load<Texture2D>("obstacle190"), spawningPositionUp1);

            down3 = new Obstacle(Content.Load<Texture2D>("obstacle"), spawningPositionDown2);
            up3 = new Obstacle(Content.Load<Texture2D>("obstacle240"), spawningPositionUp2);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (down1.IsTouchingLeft(left))
            {
                down1.position = spawningPositionDown;
                up1.position = spawningPositionUp;
            }
            if (down2.IsTouchingLeft(left))
            {
                down2.position = spawningPositionDown12;
                up2.position = spawningPositionUp;
            }
            if (down3.IsTouchingLeft(left))
            {
                down3.position = spawningPositionDown22;
                up3.position = spawningPositionUp;
            }

            down1.Update(gameTime);
            up1.Update(gameTime);
            down2.Update(gameTime);
            up2.Update(gameTime);
            down3.Update(gameTime);
            up3.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(background,new Vector2(0f,0f),Color.White);
            _spriteBatch.Draw(ground, new Vector2(0f, GraphicsDevice.Viewport.Height - 100f), Color.White);
            left.Draw(_spriteBatch);
            down1.Draw(_spriteBatch);
            up1.Draw(_spriteBatch);
            down2.Draw(_spriteBatch);
            up2.Draw(_spriteBatch);
            down3.Draw(_spriteBatch);
            up3.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
