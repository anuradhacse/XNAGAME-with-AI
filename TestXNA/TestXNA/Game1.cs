using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace TestXNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public struct PlayerData
    {
        public Vector2 Position;
        public bool IsAlive;
        public Color Color;
        public int type;
        public String Direction;
        public int user;
        public double harm;

    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {



        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D back;
        int screenWidth;
        int screenHight;
        Texture2D carriageTexture;
        Texture2D profilepic;
        Texture2D logo;
         Network_Component.Network net;
         SpriteFont Font1;
         SpriteFont logofont;
         Vector2 FontPos;
         public String health;
         public String coins;
         public String points;
         Texture2D pixel;
         KeyboardState oldState;
       
        GameTime gt;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 750;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Tank Game - War By Team Codex";
            net = new Network_Component.Network();
            net.StartConnection();
           

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            oldState = Keyboard.GetState();
        }

        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            /*String stri="brick";
             // Create a new SpriteBatch, which can be used to draw textures.
             spriteBatch = new SpriteBatch(GraphicsDevice);
             back = Content.Load<Texture2D>("post-138925-1233469168");
             carriageTexture = Content.Load<Texture2D>(stri);
             screenWidth = graphics.PreferredBackBufferWidth;
             screenHight = graphics.PreferredBackBufferHeight;
             SetUpPlayers();*/
            // TODO: use this.Content to load your game content here
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            this.gt = gameTime;
            // TODO: Add your update logic here
            //String stri = "brick";
            spriteBatch = new SpriteBatch(GraphicsDevice);
            back = Content.Load<Texture2D>("background");
            Font1 = Content.Load<SpriteFont>("textfont");
            logofont = Content.Load<SpriteFont>("textfont");
            FontPos = new Vector2(550,150);
            profilepic = Content.Load<Texture2D>("profileicon");
            logo = Content.Load<Texture2D>("gamelogo");
            Vector2 pos = new Vector2(550, 45);
            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
            //carriageTexture = Content.Load<Texture2D>(stri);
            screenWidth = graphics.PreferredBackBufferWidth;
            screenHight = graphics.PreferredBackBufferHeight;
            //DrawPlayers();
            //SetUpPlayers();
            Draw(gameTime);
            UpdateInput();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            DrawScenery();
            DrawPlayers();
            string output = "Your Id: " + net.play + "\n" + "Coins   : " + net.coins + "\n" + "Health : " + net.health + "\n" + "Points  : " + net.points;
            String logoname = "   Team Codex" + "\n"  + "CS 2212";
            Vector2 logotextpos = new Vector2(510, 420);
            // Find the center of the string
            Vector2 FontOrigin = Font1.MeasureString(output) / 2;
            // Draw the string
            spriteBatch.DrawString(Font1, output, FontPos, Color.White,
                0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(Font1, logoname, logotextpos, Color.DarkRed,
                0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            Vector2 pos = new Vector2(510, 45);
            spriteBatch.Draw(profilepic, pos, Color.White);
            Vector2 logoposition = new Vector2(510, 300);
            spriteBatch.Draw(logo, logoposition, Color.White);
            Rectangle titleSafeRectangle = GraphicsDevice.Viewport.TitleSafeArea;

            // Call our method (also defined in this blog-post)
            DrawBorder(titleSafeRectangle, 4, Color.Silver);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        private void DrawScenery()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHight);
            spriteBatch.Draw(back, screenRectangle, Color.White);
        }

        
        public void set(){
            Update(gt);
        }
        private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(480, 35,150, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(480, 35, thicknessOfBorder, 170), borderColor);

            spriteBatch.Draw(pixel, new Rectangle(480, 205, 150, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(630, 35, thicknessOfBorder, 174), borderColor);

            // Draw right line
           /* spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(480,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);*/

        }
        private void DrawprofileBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }

        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();

            // Is the SPACE key down?
            if (newState.IsKeyDown(Keys.Right))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    net.massage = "RIGHT#";
                }
            }
            else if (newState.IsKeyDown(Keys.Left))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    net.massage = "LEFT#";
                }
            }
            else if (newState.IsKeyDown(Keys.Up))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    net.massage = "UP#";
                }
            }
            else if (newState.IsKeyDown(Keys.Down))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    net.massage = "DOWN#";
                }
            }
            else if (newState.IsKeyDown(Keys.Space))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Space))
                {
                    net.massage = "SHOOT#";
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (net.map[i][j].type==4 && net.map[i][j].user == 1)
                            {
                                net.map[i][j].settype(7);
                            break;
                            }
                        }
                    }

                        
                }
            }
          
            // Update saved state.
            oldState = newState;
        }

        private void DrawPlayers()
        {
            /* foreach (PlayerData player in players)
             {
                 if (player.IsAlive)
                 {
                     carriageTexture = Content.Load<Texture2D>("brick");
                     spriteBatch.Draw(carriageTexture, player.Position, Color.White);
                 }
             }*/
           
            
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {

                        if ((net.map[i][j].type) != 0)
                        {
                            PlayerData player = new PlayerData();
                            String str = null;
                            player.type = net.map[i][j].type;
                            player.user=net.map[i][j].user;
                            player.Direction=net.map[i][j].Direction;
                            player.Position = new Vector2((i * 45)+4, ((j * 45)+5));
                            if (player.type == 1)
                            {
                                str = "brick";
                            }
                            else if (player.type == 2)
                            {
                                str = "stone";
                            }
                            else if (player.type == 3)
                            {
                                str = "water";
                            }
                            else if (player.type == 4)
                            {
                                if (player.user == 1)
                                {
                                    if (player.Direction.Equals("West"))
                                    {
                                        str = "tank_left";
                                    }
                                    else if (player.Direction.Equals("South"))
                                    {
                                        str = "tank_down";
                                    }
                                    else if (player.Direction.Equals("East"))
                                    {
                                        str = "tank_right";
                                    }
                                    else
                                    {
                                        str = "tank_up";
                                    }
                                }
                                if (player.user == 0)
                                {
                                    if (player.Direction.Equals("West"))
                                    {
                                        str = "enemy_left";
                                    }
                                    else if (player.Direction.Equals("South"))
                                    {
                                        str = "enemy_down";
                                    }
                                    else if (player.Direction.Equals("East"))
                                    {
                                        str = "enemy_right";
                                    }
                                    else
                                    {
                                        str = "enemy_up";
                                    }
                                }

                            }
                            else if (player.type == 5)
                            {
                                str = "coins";
                            }
                            else if (player.type == 6)
                            {
                                str = "life";
                            }
                            else if (player.type == 7)
                            {
                                str = "bullet";
                            }
                            carriageTexture = Content.Load<Texture2D>(str);
                            spriteBatch.Draw(carriageTexture, player.Position, Color.White);
                            

                        }
                        else
                        {
                            PlayerData player = new PlayerData();
                            //String str = null;
                            player.type = net.map[i][j].type;
                            player.Position = new Vector2((i * 45)+4, ((j * 45)+5));
                            carriageTexture = Content.Load<Texture2D>("blank");
                            try
                            {
                                //spriteBatch.Begin();
                                spriteBatch.Draw(carriageTexture, player.Position, Color.Green);
                                //spriteBatch.End();
                            }
                            catch (Exception e) { Console.WriteLine(e); }
                        
                    }
                }

            } 
        }
    }
}


