using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Achtung
{

    class GameModule : ModuleBase
    {
        private List<CirclePlayer> players;
        private Tracks tracks;
        private List<Color> colours = new List<Color> { Color.Green, Color.Red, Color.Blue, Color.Yellow };

        private SpriteFont font;
        private SpriteFont sfont;

        private bool end = false;
        private int endTime = 500;
        private int endTimer = 0;

        private bool paused = false;

        public GameModule(Game game)
            : base(game)
        {
            tracks = new Tracks(Color.Green);
            players = new List<CirclePlayer> { };
            Random random = new Random();
            int x;
            int y;

            for (int i = 0; i < ScoreHelper.NPlayers; i++)
            {
                x = (int)(random.NextDouble() * 880 + 100);
                y = (int)(random.NextDouble() * 520 + 100);
                players.Add(new CirclePlayer(new Vector2(x, y), 5, colours[i], i));
            }
        }

        internal override void LoadContent(SpriteBatch batch)
        {
            font = this.Game.Content.Load<SpriteFont>("font");
            sfont = this.Game.Content.Load<SpriteFont>("sfont");
        }

        internal override void UnloadContent()
        {
        }

        internal override void Initialize()
        {
            ScoreHelper.Players = new List<CirclePlayer> { };

            foreach (CirclePlayer player in players)
            {
                ScoreHelper.Players.Add(player);
            }   
        }

        internal override void Update(GameTime gameTime, SpriteBatch batch)
        {
            if (paused == false)
            {
                if (InputHelper.WasButtonPressed(Keys.Escape) | InputHelper.WasPadButtonPressedP1(Buttons.Start))
                {
                    paused = true;
                }


                foreach (CirclePlayer player in players)
                {
                    player.Update();
                }

                tracks.Update();

                if (DeathHelper.KillPlayer.Count > 0)
                {
                    foreach (CirclePlayer player in DeathHelper.KillPlayer)
                    {
                        players.Remove(player);
                    }
                }

                if (players.Count() < 2)
                {
                    if (end == false)
                    {
                        end = true;
                        int p = players[0].player;
                        ScoreHelper.Scores[p] += 1;
                    }

                    endTimer += gameTime.ElapsedGameTime.Milliseconds;

                    if (endTimer >= endTime)
                    {
                        GameStateManager.CurrentGameState = GameState.InGame;
                        GameStateManager.HasChanged = true;
                    }
                }

                DeathHelper.KillPlayer = new List<CirclePlayer> { };
            }

            else
            {
                if (InputHelper.WasButtonPressed(Keys.Escape) | InputHelper.WasPadButtonPressedP1(Buttons.Start))
                {
                    paused = false;
                }

                if (InputHelper.WasButtonPressed(Keys.Q) | InputHelper.WasPadButtonPressedP1(Buttons.Back))
                {

                    GameStateManager.CurrentGameState = GameState.MainMenu;
                    GameStateManager.HasChanged = true;
                }
            }
        }

        internal override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (CirclePlayer player in players)
            {
                player.Draw(spriteBatch);
            }
            tracks.Draw(spriteBatch);

            int i = 0;
            foreach (CirclePlayer player in ScoreHelper.Players)
            {
                if (player.dead == false)
                {
                    spriteBatch.DrawString(font, "Player " + (player.player + 1).ToString() + " - " + ScoreHelper.Scores[player.player].ToString() , new Vector2(100 + i * 250, 20), colours[player.player]);
                }
                else
                {
                    spriteBatch.DrawString(font, "Player " + (player.player + 1).ToString() + " - " + ScoreHelper.Scores[player.player].ToString(), new Vector2(100 + i * 250, 20), Color.Gray);
                }
                i += 1;
            }

            if (paused == true)
            {
                spriteBatch.DrawString(font, "Paused", new Vector2(500, 500), Color.White);
            }
        }
    }
}
