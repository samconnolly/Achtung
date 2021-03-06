﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Achtung
{
    public abstract class ModuleBase
    {
        private Texture2D _backgroundTexture;
        private Game _game;

        public ModuleBase(Game game)
        {
            _game = game;
        }

        public Texture2D BackgroundTexture
        {
            get { return this._backgroundTexture; }
            set { this._backgroundTexture = value; }
        }

        
        public Game Game
        {
            get { return this._game; }
            set { this._game = value; }
        }

        #region GameLoop

        internal abstract void Initialize();

        internal abstract void LoadContent(SpriteBatch batch);

        internal abstract void UnloadContent();

        internal abstract void Update(GameTime gameTime, SpriteBatch batch);

        internal abstract void Draw(GameTime gameTime, SpriteBatch batch);

        #endregion
    }
}
