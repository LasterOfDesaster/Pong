using System;
using System.Windows.Forms;
using Sharpex2D;
using Sharpex2D.Surface;
using Sharpex2D.Rendering;

namespace Pong
{ 
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BackBuffer backBuffer = new BackBuffer(800,600);
            Game game = new Pong.Core.Pong();
            RenderTarget renderTarget = RenderTarget.Create();
            renderTarget.Window.Position = new Sharpex2D.Math.Vector2()
            {
                X = (Screen.PrimaryScreen.Bounds.Width - backBuffer.Width) / 2,
                Y = (Screen.PrimaryScreen.Bounds.Height - backBuffer.Height) / 2
            };
            Configurator config = new Configurator(backBuffer, game, renderTarget);
            SGL.Initialize(config);
        }
    }
}
