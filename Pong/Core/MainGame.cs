using System;
using Sharpex2D;
using Sharpex2D.Surface;
using Sharpex2D.GameService;
using Rendering = Sharpex2D.Rendering;

namespace Pong.Core 
{
    public class Pong : Game 
    {
        public override EngineConfiguration OnInitialize(LaunchParameters launchParameters)
        {
            this.GameComponentManager.Add(this.SceneManager);

            return new EngineConfiguration(new Rendering.DirectX11.DirectXGraphicsManager());
        }
         
        public override void OnLoadContent()
        {
            this.SceneManager.AddScene(new Scenes.IntroScene());
            this.SceneManager.AddScene(new Scenes.MenuScene());
            this.SceneManager.AddScene(new Scenes.GameScene());
            this.SceneManager.AddScene(new Scenes.PauseScene());
            this.SceneManager.ActiveScene = this.SceneManager.Get<Scenes.IntroScene>();
            SGL.Components.Get<Rendering.GraphicsDevice>().ClearColor = Rendering.Color.Black;
        }
        
    }
}