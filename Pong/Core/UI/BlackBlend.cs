using Sharpex2D;
using Sharpex2D.Math;
using Sharpex2D.Rendering;


namespace Pong.Core.UI
{
    public class BlackBlend : IDrawable, IUpdateable
    {
        private bool fadeIn;
        private Rectangle display;
        private float currentAlpha;

        public bool FadeIn
        {
            get
            {
                return fadeIn;
            }
            set
            {
                fadeIn = value;
                currentAlpha = value ? 0 : 255;
            }
        }
        public bool IsEnabled { get; set; }
        public float FadeVelocity { get; set; }
        public bool AnimationComplete { get; private set; }
        public Rectangle Display { get { return display; } }
        public float CurrentAlpha { get { return currentAlpha; } }

        public BlackBlend()
        {
            display = new Rectangle(0, 0, 800, 600);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!IsEnabled)
            {
                return;
            }
            spriteBatch.FillRectangle(Color.FromArgb((int)currentAlpha, 0, 0, 0), display);
        }

        public void Update(GameTime gameTime)
        {
            if (!IsEnabled)
            {
                return;
            }

            if (fadeIn)
            {
                currentAlpha += FadeVelocity;
                if (currentAlpha >= 255)
                {
                    currentAlpha = 255;
                    AnimationComplete = true;
                }
            }
            else
            {
                currentAlpha -= FadeVelocity;
                if (currentAlpha <= 0)
                {
                    currentAlpha = 0;
                    AnimationComplete = true;
                }
            }
        }
    }
}