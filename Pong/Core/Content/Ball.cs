using Sharpex2D;
using Sharpex2D.Math;
using Sharpex2D.Input;
using Sharpex2D.Rendering;

namespace Pong.Core.Content
{
    public class Ball : GameObject, IUpdateable, IDrawable
    {
        #region Properties

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int Speed { get { return speed; } }
        public int DirectionX { get { return directionX; } }
        public int DirectionY { get { return directionY; } }
        public Rectangle Bounds { get { return new Rectangle(Position, new Vector2(Texture.Width, Texture.Height)); } }

        #endregion

        #region Private Member

        private int speed;
        private int directionX;
        private int directionY;

        private GameRandom gr;
        private GraphicsDevice GraphicsDevice;
        private InputManager inputManager;

        #endregion

        #region Konstruktor

        public Ball()
        {
            gr = new GameRandom();
            GraphicsDevice = SGL.Components.Get<GraphicsDevice>();
            inputManager = SGL.Components.Get<InputManager>();

            this.speed = 5;
            this.Position = new Vector2(GraphicsDevice.BackBuffer.Width / 2, GraphicsDevice.BackBuffer.Height / 2);
            this.directionX = gr.Next(0, 100) <= 50 ? -1 : +1;
            this.directionY = gr.Next(0, 100) <= 50 ? -1 : +1;
        }

        #endregion

        #region Implementationen

        /// <summary>
        /// Zeichnen der Elemente
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawTexture(Texture, Position);
        }

        /// <summary>
        /// Updaten der GameLogik
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            int offSetX = speed * directionX;
            int offsetY = speed * directionY;

            MoveOnX(offSetX);
            MoveOnY(offsetY);
        }

        #endregion

        #region Public Methods

        public void MoveOnY(int value)
        {
            if (this.Position.Y < 1)
            {
                this.Position = new Vector2(this.Position.X,
                                            this.Position.Y + 5);
            }
            else if (this.Position.Y > GraphicsDevice.BackBuffer.Height - this.Texture.Height - 5)
            {
                this.Position = new Vector2(this.Position.X,
                                            this.Position.Y - 5);
            }

            this.Position = new Vector2(this.Position.X,
                                        this.Position.Y + value);
        }

        public void MoveOnX(int value)
        {
            if (this.Position.X < 1)
            {
                this.Position = new Vector2(this.Position.X + 5,
                                            this.Position.Y);
            }
            if (this.Position.X > GraphicsDevice.BackBuffer.Width - this.Texture.Width - 5)
            {
                this.Position = new Vector2(this.Position.X - 5,
                                            this.Position.Y);
            }
            this.Position = new Vector2(this.Position.X + value,
                                        this.Position.Y);
        }

        public void OnCollisionWithBorder()
        {
            this.directionY *= -1;
        }

        public void OnCollisionWithBat()
        {
            this.directionX *= -1;
        }


        #endregion
    }
}
