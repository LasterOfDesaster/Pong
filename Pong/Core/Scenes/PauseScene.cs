using Sharpex2D;
using Sharpex2D.Math;
using Sharpex2D.Input;
using Sharpex2D.Content;
using Sharpex2D.Rendering;
using Sharpex2D.Rendering.Scene;

namespace Pong.Core.Scenes
{
    public class PauseScene : Scene
    {
        #region Properties

        public SceneMode SceneMode { get; set; }

        #endregion

        #region Private Member

        private string text;
        private Font font;
        private Vector2 position;
        private Color color;
        private GameScene gameScene;

        private InputManager inputManager;
        private SceneManager sceneManager;
        private GraphicsDevice graphicsDevice;

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
            var state = inputManager.Keyboard.GetState();

            if (state.IsKeyDown(Keys.Space))
            {
                sceneManager.ActiveScene = sceneManager.Get<GameScene>();
            }
            if (state.IsKeyDown(Keys.Back))
            {
                sceneManager.ActiveScene = sceneManager.Get<MenuScene>();
            }
        }

        /// <summary>
        /// Zeichnen der Elemente
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (SceneMode)
            {
                case SceneMode.FirstStart:
                    text = "Bereit?";
                    gameScene.Draw(spriteBatch, gameTime);
                    break;

                case SceneMode.Paused:
                    text = "Pausiert";
                    break;

                case SceneMode.WonLost:
                    break;

                case SceneMode.Scored:
                    text = "Bereit?";
                    gameScene.Draw(spriteBatch, gameTime);
                    break;

                default:
                    break;
            }
            font = new Font("Arial", 50, TypefaceStyle.Bold);
            position = new Vector2()
            {
                X = (graphicsDevice.BackBuffer.Width - spriteBatch.MeasureString(text, font).X) / 2,
                Y = 100
            };
            color = Color.White;
            spriteBatch.DrawString(text, font, position, color);
        }

        /// <summary>
        /// Initialisieren der privaten Member
        /// </summary>
        public override void Initialize()
        {
            inputManager = SGL.Components.Get<InputManager>();
            sceneManager = SGL.Components.Get<SceneManager>();
            graphicsDevice = SGL.Components.Get<GraphicsDevice>();
            gameScene = this.sceneManager.Get<GameScene>();
        }

        /// <summary>
        /// Laden von Ressourcen
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {

        }

        #endregion
    }

    public enum SceneMode { FirstStart, Paused, WonLost, Scored }
}