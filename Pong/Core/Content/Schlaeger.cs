using Sharpex2D;
using Sharpex2D.Math;
using Sharpex2D.Input;
using Sharpex2D.Rendering;

namespace Pong.Core.Content
{
    public class Schlaeger : GameObject, IUpdateable, IDrawable
    {
        #region Properties

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Keys KeyMoveUp { get; set; }
        public Keys KeyMoveDown { get; set; }
        public Rectangle Bounds { get { return new Rectangle(Position, new Vector2(Texture.Width, Texture.Height)); } }
            

        #endregion
        
        #region Private Member

        private InputManager inputManager;
        private GraphicsDevice gd;

        #endregion

        #region Konstruktor

        public Schlaeger(Vector2 startPosition)
        {
            this.Position = startPosition;
            inputManager = SGL.Components.Get<InputManager>();
            gd = SGL.Components.Get<GraphicsDevice>();
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
            var state = inputManager.Keyboard.GetState();

            if (state.IsKeyDown(KeyMoveUp) && state.IsKeyUp(KeyMoveDown))
            {
                MoveOnY(-5);
            }
            if (state.IsKeyDown(KeyMoveDown) && state.IsKeyUp(KeyMoveUp))
            {
                MoveOnY(+5);
            }
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
            else if (this.Position.Y > gd.BackBuffer.Height - this.Texture.Height - 5)
            {
                this.Position = new Vector2(this.Position.X,
                                            this.Position.Y - 5);
            }

            this.Position = new Vector2(this.Position.X,
                                        this.Position.Y + value);
        }

        #endregion
    }
}

