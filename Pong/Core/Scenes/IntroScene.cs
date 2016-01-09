using Sharpex2D;
using Sharpex2D.Entities;
using Sharpex2D.Rendering;
using Sharpex2D.Rendering.Scene;
using Sharpex2D.Math;
using Sharpex2D.Content;
using System;

namespace Pong.Core.Scenes
{
    public class IntroScene : Scene
    {
        #region Properties

        public UI.FadableText Text1 { get { return text1; } }
        public UI.FadableText Text2 { get { return text2; } }
        public UI.FadableText Text3 { get { return text3; } }
       
        #endregion

        #region Private Member

        private UI.FadableText text1;
        private UI.FadableText text2;
        private UI.FadableText text3;
        private GraphicsDevice GraphicsDevice;
        private SceneManager SceneManager;

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
            text1.Update(gameTime);
            if (text1.AnimationComplete)
            {
                text2.Update(gameTime);
                if (text2.AnimationComplete)
                {
                    text3.Update(gameTime);
                    if (text3.AnimationComplete)
                    {
                        SceneManager.ActiveScene = SceneManager.Get<Scenes.MenuScene>();
                    }
                }
            }
           
        }

        /// <summary>
        /// Zeichnen der Elemente
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            text1.Draw(spriteBatch, gameTime);
            if (text1.AnimationComplete)
            {
                text2.Draw(spriteBatch, gameTime);
                if (text2.AnimationComplete)
                {
                    text3.Draw(spriteBatch, gameTime);
                    if (text3.AnimationComplete)
                    {
                        
                    }
                }
            }
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
            text1 = new UI.FadableText()
            {
                Text = "Radinator presents",
                Position = new Vector2()
                {
                    X = (800 - 227) / 2,
                    Y = 100
                },
                Font = new Font("Arial", 25, TypefaceStyle.Bold),
                FadeInVelocity = 2f,
                FadeOutVelocity = 3f
            };
            text2 = new UI.FadableText()
            {
                Text = "a game powered by Sharpex2D",
                Position = new Vector2()
                {
                    X = (800 - 369) / 2,
                    Y = 100
                },
                Font = new Font("Arial", 25f, TypefaceStyle.Bold),
                FadeInVelocity = 2f,
                FadeOutVelocity = 3f
            };
            text3 = new UI.FadableText()
            {
                Text = "Pong",
                Position = new Vector2()
                {
                    X = (800 - 100) / 2,
                    Y = 100
                },
                Font = new Font("Arial", 40f, TypefaceStyle.Bold),
                FadeInVelocity = 2f,
                FadeOutVelocity = 3f
            };
        }
        #endregion
    }
}

       