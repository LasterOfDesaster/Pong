using Sharpex2D;
using Sharpex2D.Math;
using Sharpex2D.Input;
using Sharpex2D.Content;
using Sharpex2D.Rendering;
using Sharpex2D.Rendering.Scene;

using System;

namespace Pong.Core.Scenes
{
    public class GameScene : Scene
    {
        #region Properties

        public Content.Ball Ball { get { return ball; } }
        public Content.Schlaeger SL { get { return sL; } }
        public Content.Schlaeger SR { get { return sR; } }
        public Content.ScoreBoard ScoreBoard { get { return scoreBoard; } }
        public Rectangle TorLinks { get { return torLinks; } }
        public Rectangle TorRechts { get { return torRechts; } }
        public Rectangle BegrenzungOben { get { return begrenzungOben; } }
        public Rectangle BegrenzungUnten { get { return begrenzungUnten; } }

        #endregion

        #region Private Member

        private Content.Ball ball;
        private Content.Schlaeger sL;
        private Content.Schlaeger sR;
        private Rectangle torLinks;
        private Rectangle torRechts;
        private Rectangle begrenzungOben;
        private Rectangle begrenzungUnten;

        private GraphicsDevice GraphicsDevice;
        private InputManager inputManager;
        private SceneManager sceneManager;
        private Content.ScoreBoard scoreBoard;

        #endregion

        #region Implementationen

        /// <summary>
        /// Updaten der Gamelogik
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            var kbState = inputManager.Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.Escape))
            {
                sceneManager.Get<PauseScene>().SceneMode = SceneMode.Paused;
                sceneManager.ActiveScene = sceneManager.Get<PauseScene>();
            }
            if (kbState.IsKeyDown(Keys.Back))
            {
                sceneManager.ActiveScene = sceneManager.Get<MenuScene>();
            }
            ball.Update(gameTime);
            sL.Update(gameTime);
            sR.Update(gameTime);
            scoreBoard.Update(gameTime);

            CheckOnCollision();          
        }

        /// <summary>
        /// Zeichnen der Elemente
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {            
            scoreBoard.Draw(spriteBatch, gameTime);
            ball.Draw(spriteBatch, gameTime);
            sL.Draw(spriteBatch, gameTime);
            sR.Draw(spriteBatch, gameTime);
        }

        /// <summary>
        /// Initialisieren der privaten Member
        /// </summary>
        public override void Initialize()
        {
            GraphicsDevice = SGL.Components.Get<GraphicsDevice>();
            inputManager = SGL.Components.Get<InputManager>();
            sceneManager = SGL.Components.Get<SceneManager>();
            ball = new Content.Ball();
            sL = new Content.Schlaeger(new Vector2(10, 250));
            sL.KeyMoveDown = Keys.S;
            sL.KeyMoveUp = Keys.W;
            sR = new Content.Schlaeger(new Vector2(780,250));
            sR.KeyMoveDown = Keys.Down;
            sR.KeyMoveUp = Keys.Up;
            int w = GraphicsDevice.BackBuffer.Width;    //800
            int h = GraphicsDevice.BackBuffer.Height;   //600
            this.torLinks        = new Rectangle(    9, 0, 1, h);
            this.begrenzungOben  = new Rectangle(    0, 0, w, 1);
            this.torRechts       = new Rectangle(w - 9, 0, 1, h);
            this.begrenzungUnten = new Rectangle(    0, h, w, 1);
            scoreBoard = new Content.ScoreBoard()
            {
                Color = Color.White,
                Font = new Font("Arial", 15f, TypefaceStyle.Regular),
                Pen = new Pen(Color.White, 15f),
                Spieler1 = new Content.Player()
                {
                    Name = "Spieler1"
                },
                Spieler2 = new Content.Player()
                {
                    Name = "Spieler2"
                }
            };
        }

        /// <summary>
        /// Laden von Ressourcen
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            ball.Texture = content.Load<Texture2D>("ball.png");
            sL.Texture = content.Load<Texture2D>("schlaeger1.png");
            sR.Texture = content.Load<Texture2D>("schlaeger2.png");
        }

        #endregion

        private void ResetGame()
        {
            ball.Position = new Vector2(GraphicsDevice.BackBuffer.Width / 2, GraphicsDevice.BackBuffer.Height / 2);
            sL.Position = new Vector2(10, 250);
            sR.Position = new Vector2(780, 250);

            sceneManager.Get<PauseScene>().SceneMode = SceneMode.Scored;
            sceneManager.ActiveScene = sceneManager.Get<PauseScene>();
        }

        private void CheckOnCollision()
        {
            if (ball.Bounds.Intersects(sL.Bounds) || ball.Bounds.Intersects(sR.Bounds))
            {
                ball.OnCollisionWithBat();
            }

            if (ball.Bounds.Intersects(begrenzungOben) || ball.Bounds.Intersects(begrenzungUnten))
            {
                ball.OnCollisionWithBorder();
            }

            if (ball.Bounds.Intersects(torLinks) || ball.Bounds.Intersects(torRechts))
            {
                if (ball.Bounds.Intersects(torLinks))
                {
                    scoreBoard.Spieler2.Scored();
                }
                else
                {
                    scoreBoard.Spieler1.Scored();
                }
                if (ball.Position.X < 1 || ball.Position.X + 10 > 800 - 1)
                {
                    ResetGame(); 
                }
            }
        }
    }
}