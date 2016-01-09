using System;
using Sharpex2D;
using Sharpex2D.UI;
using Sharpex2D.Math;
using Sharpex2D.Rendering;


namespace Pong.Core.UI
{
    public class MenuButton : UIControl
    {
        public Font Font { get; set; }
        public Pen Pen { get; set; }

        public string Text { get; set; }

        public MenuButton(UIManager uiManager)
            :base(uiManager)
        {
            this.Font = new Font("Arial", 20, TypefaceStyle.Regular);
            this.Pen = new Pen(Color.White, 1f);
        }
        public override void OnDraw(SpriteBatch spriteBatch)
        {
            if (this.IsMouseHoverState)
            {
                this.Pen.Color = Color.Yellow;
            }
            else
            {
                this.Pen.Color = Color.White;
            }

            float x = (float)(this.Position.X + (double)(this.Size.Width / 2) - spriteBatch.MeasureString(this.Text, this.Font).X / 2.0);
            float y = (float)(this.Position.Y + (double)(this.Size.Height / 2) - spriteBatch.MeasureString(this.Text, this.Font).Y / 2.0);
            Vector2 center = new Vector2(x, y);

            spriteBatch.DrawRectangle(this.Pen, Sharpex2D.Common.Extensions.UIBoundsExtension.ToRectangle(this.Bounds));
            spriteBatch.DrawString(this.Text, this.Font, center, Color.White);
        }
    }
}