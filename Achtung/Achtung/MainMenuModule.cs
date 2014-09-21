using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using Microsoft.CSharp;
using System.Windows.Forms;
using System.Diagnostics;


namespace Achtung
{
    public class MainMenuModule : ModuleBase
    {
        //private Rectangle _drawRectangle;
        private Vector2 _position = new Vector2(0, 0);

        private SpriteFont font;
        private List<Color> colours;
        private int selected = 0;
        private int max = 4;
        private int tree = 0;

        public MainMenuModule(Game game)
            : base(game)
        {

        }

        #region ModuleBase Overrides


        internal override void Initialize()
        {

        }

        internal override void LoadContent(SpriteBatch batch)
        {            
            // fonts
            font = this.Game.Content.Load<SpriteFont>("font");

        }

        internal override void UnloadContent()
        {

        }

        internal override void Update(GameTime gameTime, SpriteBatch batch)
        {
            if (InputHelper.WasButtonPressed(Microsoft.Xna.Framework.Input.Keys.Enter) || InputHelper.WasButtonPressed(Microsoft.Xna.Framework.Input.Keys.Space) || InputHelper.WasPadButtonPressedP1(Buttons.A))
            {
                if (tree == 0)
                {
                    if (selected == 0)
                    {
                        GameStateManager.CurrentGameState = GameState.InGame;
                        GameStateManager.HasChanged = true;

                    }
                    else if (selected == 1)
                    {
                        ScoreHelper.NPlayers += 1;
                        if (ScoreHelper.NPlayers > 4)
                        {
                            ScoreHelper.NPlayers = 1;
                        }
                    }
                    else if (selected == 2)
                    {
                        ViewPortHelper.ToggleFullscreen();

                    }
                    else if (selected == 3)
                    {
                        tree = 1;
                        selected = 0;
                    }
                    else if (selected == 4)
                    {
                        Game.Exit();
                    }
                }

                else if (tree == 1)
                {
                    if (selected == 0)
                    {
                        GameStateManager.CurrentGameState = GameState.InGame;
                        GameStateManager.HasChanged = true;
                    }
                    else if (selected == 1)
                    {
                        GameStateManager.CurrentGameState = GameState.InGame;
                        GameStateManager.HasChanged = true;
                    }
                    else
                    {
                        tree = 0;
                        selected = 0;
                    }

                }

            }

            // exit game
            if (InputHelper.WasButtonPressed(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                Game.Exit();
            }

            // menu control
            if (InputHelper.WasButtonPressed(Microsoft.Xna.Framework.Input.Keys.Up) || InputHelper.WasPadThumbstickUpP1())
            {
                selected -= 1;
            }
            if (InputHelper.WasButtonPressed(Microsoft.Xna.Framework.Input.Keys.Down) || InputHelper.WasPadThumbstickDownP1())
            {
                selected += 1;
            }

            if (selected > max) { selected = 0; }
            if (selected < 0) { selected = max; }

          
            // toggle fullscreen

            if (InputHelper.WasButtonPressed(Microsoft.Xna.Framework.Input.Keys.F) || InputHelper.WasPadButtonPressedP1(Buttons.X))
            {
                ViewPortHelper.ToggleFullscreen();
            }

            colours = new List<Color> { Color.White, Color.White, Color.White, Color.White, Color.White };
            colours[selected] = Color.Red;
        }

        internal override void Draw(GameTime gameTime, SpriteBatch batch)
        {

            if (tree == 0)
            {
                batch.DrawString(font, "New Game", new Vector2(200, 300), colours[0], 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                batch.DrawString(font, "Players: "+ScoreHelper.NPlayers.ToString(), new Vector2(200, 350), colours[1], 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                batch.DrawString(font, "Toggle Full Screen", new Vector2(200, 400), colours[2], 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                batch.DrawString(font, "Controls", new Vector2(200, 450), colours[3], 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                batch.DrawString(font, "Exit", new Vector2(200, 500), colours[4], 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
            }
            else if (tree == 1)
            {
                batch.DrawString(font, "Show Controls", new Vector2(200, 300), colours[0], 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                batch.DrawString(font, "Toggle keys/pad", new Vector2(200, 350), colours[1], 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                batch.DrawString(font, "Back", new Vector2(200, 400), colours[2], 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);

                batch.DrawString(font, "Pad 1 Connected: " + InputHelper.CurrentGamePadStatePlayer1.IsConnected.ToString(), new Vector2(200, 450), Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                batch.DrawString(font, "Pad 2 Connected: " + InputHelper.CurrentGamePadStatePlayer2.IsConnected.ToString(), new Vector2(200, 500), Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);

                string p1 = "pad";
                string p2 = "pad";
                //if (InputHelper.Keys == 1)
                //{
                //    p1 = "keys";
                //}
                //else if (InputHelper.Keys == 2)
                //{
                //    p2 = "keys";
                //}

                batch.DrawString(font, "P1: " + p1.ToString(), new Vector2(200, 550), Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                batch.DrawString(font, "P2: " + p2.ToString(), new Vector2(200, 600), Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);

            }

        }

        #endregion
    }
}

