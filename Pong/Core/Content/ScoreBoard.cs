using System;
using Sharpex2D;
using Sharpex2D.Math;
using Sharpex2D.Rendering;

namespace Pong.Core.Content
{
    public class ScoreBoard : IDrawable, IUpdateable
    {
        #region Properties

        public Content.Player Spieler1 { get; set; }
        public Content.Player Spieler2 { get; set; }
        public Font Font { get; set; }
        public Color Color { get; set; }
        public Pen Pen { get; set; }


        #endregion

        #region Private Member

        private string scoreBoardPlayer1;
        private string scoreBoardPlayer2;
        private Rectangle p1Bounds;
        private Rectangle p2Bounds;
        private GraphicsDevice GraphicsDevice;


        #endregion

        #region Konstruktor

        public ScoreBoard()
        {
            this.scoreBoardPlayer1 = "";
            this.scoreBoardPlayer2 = "";
            p1Bounds.X = 0; p1Bounds.Y = 0;
            p2Bounds.X = 0; p2Bounds.Y = 0;
            GraphicsDevice = SGL.Components.Get<GraphicsDevice>();
        }

        #endregion

        #region Implementation

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            p1Bounds = new Rectangle(new Vector2(0, 0), spriteBatch.MeasureString(scoreBoardPlayer1, Font));
            p2Bounds = new Rectangle(new Vector2(GraphicsDevice.BackBuffer.Width - spriteBatch.MeasureString(scoreBoardPlayer2, Font).X, 0), spriteBatch.MeasureString(scoreBoardPlayer2, Font));
            spriteBatch.DrawString(scoreBoardPlayer1, Font, p1Bounds, Color);
            spriteBatch.DrawString(scoreBoardPlayer2, Font, p2Bounds, Color);
        }

        public void Update(GameTime gameTime)
        {
            scoreBoardPlayer1 = string.Format("{0}: {1:000}", this.Spieler1.Name, this.Spieler1.Score);
            scoreBoardPlayer2 = string.Format("{0}: {1:000}", this.Spieler2.Name, this.Spieler2.Score);
        }

        #endregion
    }
}