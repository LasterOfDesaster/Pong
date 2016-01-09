using Sharpex2D;
using Sharpex2D.Entities;
using Sharpex2D.Rendering;
using Sharpex2D.Rendering.Scene;
using Sharpex2D.Math;
using Sharpex2D.Content;
using System;

namespace Pong.Core.Scenes
{
    public class MenuScene : Scene
    {
        #region Properties

        public UI.MenuButton Button1 { get { return button1; } }
        public UI.MenuButton Button4 { get { return button2; } }

        #endregion

        #region Private Member

        private UI.MenuButton button1;
        private UI.MenuButton button2;
        private SceneManager SceneManager;
        private GraphicsDevice GraphicsDevice;

        #endregion

        #region Konstruktor

        #endregion

        #region Implementationen

        /// <summary>
        /// Updaten der Gamelogik
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            button1.Update(gameTime);
            button2.Update(gameTime);

            if (button1.IsMouseDown(Sharpex2D.Input.MouseButtons.Left))
            {
                SceneManager.Get<PauseScene>().SceneMode = SceneMode.FirstStart;
                SceneManager.ActiveScene = SceneManager.Get<PauseScene>();
            }
            if (button2.IsMouseDown(Sharpex2D.Input.MouseButtons.Left))
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        /// <summary>
        /// Zeichnen der Elemente
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            button1.OnDraw(spriteBatch);
            button2.OnDraw(spriteBatch);
        }

        /// <summary>
        /// Initialisieren der privaten Member
        /// </summary>
        public override void Initialize()
        {
            GraphicsDevice = SGL.Components.Get<GraphicsDevice>();
            SceneManager = SGL.Components.Get<SceneManager>();
        }

        /// <summary>
        /// Laden von Ressourcen
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            button1 = new UI.MenuButton(this.UIManager)
            {
                Text = "Spielen",
                Size = new Sharpex2D.UI.UISize(200,50),
                Position = new Vector2()
                {
                    X = (800 - 200) / 2,
                    Y = 200
                }
            };
            button2 = new UI.MenuButton(this.UIManager)
            {
                Text = "Beenden",
                Size = new Sharpex2D.UI.UISize(200, 50),
                Position = new Vector2()
                {
                    X = (800 - 200) / 2,
                    Y = 275
                }
            };
        }

        #endregion
    }
}

       