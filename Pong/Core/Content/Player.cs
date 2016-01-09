using System;
using Sharpex2D;
using Sharpex2D.GameService;
using Sharpex2D.Rendering;

namespace Pong.Core.Content
{
    public class Player 
    {
        #region Properties
        public string Name { get; set; }
        public int Score { get; private set; }
        #endregion

        #region Private Member

        #endregion

        #region Konstruktor

        #endregion

        #region Implementationen

        #endregion

        #region Public Methods

        public void Scored()
        {
            this.Score++;
        }

        #endregion
    }
}