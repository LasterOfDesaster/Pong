using System;
using Sharpex2D;
using Sharpex2D.Math;
using Sharpex2D.Rendering;

namespace Pong.Core.UI
{
    public class FadableText : IDrawable, IUpdateable
    {
        private bool flag;
        private float currentAlpha;

        public Font Font { get; set; }
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public float FadeInVelocity { get; set; }
        public float FadeOutVelocity { get; set; }
        public bool FadeOut { get { return !flag; } }
        public bool AnimationComplete { get; private set; }
        public float CurrentAlpha { get { return currentAlpha; } }

        public FadableText()
        {
            Text = "Fadable Text 1";
            Font = new Font("Arial", 20f, TypefaceStyle.Regular);
            Position = new Vector2(0, 0);
            FadeInVelocity = 1;
            FadeOutVelocity = 2;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (AnimationComplete)
            {
                return;
            }
            spriteBatch.DrawString(Text, Font, Position, Color.FromArgb((int)currentAlpha, 255, 255, 255));
        }

        public void Update(GameTime gameTime)
        {
            if (AnimationComplete)
            {
                return;
            }

            if (!flag)
            {
                currentAlpha += FadeInVelocity;
                if (currentAlpha >= 255)
                {
                    currentAlpha = 255;
                    flag = true;
                }
            }
            else
            {
                currentAlpha -= FadeOutVelocity;
                if (currentAlpha <= 0)
                {
                    currentAlpha = 0;
                    AnimationComplete = true;
                }
            }
        }

        
    }
}