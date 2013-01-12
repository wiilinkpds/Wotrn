using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System.Configuration;

namespace Jeux
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        PlayerSystem playerSystem;
        TextureManager textureManager;
        Map map;
        Camera cam;
        CameraSystem camSys;
        SpriteFont font;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            textureManager = new TextureManager(Content);
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1440;
            graphics.PreferredBackBufferHeight = 900;
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
            player = new Player(new Vector2(0,0));
            player.ColisionRectangleIsVisible = false;
            player.Colision = true;
            playerSystem = new PlayerSystem();
            map = new Map(new Vector2(100,100));
            cam = new Camera();
            camSys = new CameraSystem();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player.LoadContent(textureManager, "ss-m", 4, 4, "h");
            Random rand = new Random();
            map.DefaultLoadContent(textureManager, "grass");
            for (int i = 0; i  < 500; i ++)
            {
                int randX = rand.Next(0, (int)map.Size.X);
                int randY = rand.Next(0, (int)map.Size.Y);
                Tile thisTile = map.Tiles[randX, randY];
                thisTile.AssetName = "three";
                thisTile.ColisionRectangle = new Rectangle((int)thisTile.PixelPosition.X + 10, (int)(thisTile.PixelPosition.Y + (thisTile.Size.Y /2.5)) , (int)thisTile.Size.X - 20, (int)(thisTile.Size.Y /2.5) );
                thisTile.CollisionRectangleIsVisible = false;
            }
            map.LoadContent(textureManager);
            font = Content.Load<SpriteFont>("sf");

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
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            
            // TODO: Add your update logic here
            KeyboardState kState = Keyboard.GetState();
            playerSystem.Update(gameTime,kState, player, map);
            camSys.Update(cam, player,map,graphics, kState);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, cam.GetTransformation(GraphicsDevice));
                map.Draw(spriteBatch);
                player.Draw(spriteBatch);
                spriteBatch.DrawString(font,"X : " + Convert.ToString(Convert.ToInt32(player.Position.X))+ "\n" + 
                                            "Y : " + Convert.ToString(Convert.ToInt32(player.Position.Y)) + "\n" +
                                            Convert.ToString(Convert.ToInt32(cam.ToWorldLocation(new Vector2(graphics.PreferredBackBufferWidth/2,graphics.PreferredBackBufferHeight/2)).X)), cam.ToWorldLocation(new Vector2(10,10)), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
