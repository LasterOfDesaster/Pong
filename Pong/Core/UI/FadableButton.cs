using Sharpex2D;
using Sharpex2D.UI;
using Sharpex2D.Math;
using Sharpex2D.Rendering;

namespace Pong.Core.UI
{
    public class FadableButton : UIControl
    {
        private bool fadeIn;
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
        public Pen Pen { get; set; }
        public Font Font { get; set; }
        public string Text { get; set; }
        public float FadeVelocity { get; set; }
        public bool AnimationComplete { get; private set; }
        public float CurrentAlpha { get { return currentAlpha; } }

        public FadableButton(UIManager uiManager)
            :base(uiManager)
        {
            this.Font = new Font("Arial", 20, TypefaceStyle.Regular);
            this.Pen = new Pen(Color.White, 1f);
            this.Text = "Button";
            FadeVelocity = 2;
        }
        public override void OnDraw(SpriteBatch spriteBatch)
        {
            //if (AnimationComplete)
            //    return;

            if (this.IsMouseHoverState)
            {
                this.Pen.Color = Color.FromArgb((int)currentAlpha, 255, 255, 0);
            }
            else
            {
                this.Pen.Color = Color.FromArgb((int)currentAlpha, 255, 255, 255);
            }

            float x = (float)(this.Position.X + (double)(this.Size.Width / 2) - spriteBatch.MeasureString(this.Text, this.Font).X / 2.0);
            float y = (float)(this.Position.Y + (double)(this.Size.Height / 2) - spriteBatch.MeasureString(this.Text, this.Font).Y / 2.0);
            Vector2 center = new Vector2(x, y);

            spriteBatch.DrawRectangle(this.Pen, Sharpex2D.Common.Extensions.UIBoundsExtension.ToRectangle(this.Bounds));
            spriteBatch.DrawString(this.Text, this.Font, center, Color.FromArgb((int)currentAlpha, 255, 255, 255));
        }

        public override void OnUpdate(GameTime gameTime)
        {
            if (AnimationComplete)
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