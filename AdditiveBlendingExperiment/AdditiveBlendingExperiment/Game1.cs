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

namespace AdditiveBlendingExperiment
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class ColorsTest : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Color spheres
        private Texture2D blue;
        private Texture2D green;
        private Texture2D orange;
        private Texture2D purps;
        private Texture2D red;
        private Texture2D turq;

        //Color sphere angle variables
        private float blueAngle = 0;
        private float greenAngle = 0;
        private float orangeAngle = 0;
        private float purpsAngle = 0;
        private float redAngle = 0;
        private float turqAngle = 0;

        //Color sphere velocity variables
        private float blueSpeed = 0.01f;
        private float greenSpeed = 0.02f;
        private float orangeSpeed = 0.025f;
        private float purpsSpeed = 0.015f;
        private float redSpeed = 0.005f;
        private float turqSpeed = 0.018f;

        private float distance = 100;

        public ColorsTest()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            blue = Content.Load<Texture2D>("blue");
            green = Content.Load<Texture2D>("green");
            orange = Content.Load<Texture2D>("orange");
            purps = Content.Load<Texture2D>("purps");
            red = Content.Load<Texture2D>("red");
            turq = Content.Load<Texture2D>("turq");
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

            //Creates movement of color spheres
            blueAngle += blueSpeed;
            greenAngle += greenSpeed;
            orangeAngle += orangeSpeed;
            purpsAngle += purpsSpeed;
            redAngle += redSpeed;
            turqAngle += turqSpeed;

            //Make color spheres move towards cursor
            MouseState ms = Mouse.GetState();
            Vector2 bluePosition = new Vector2(
                ms.X*.095f, ms.Y*.095f);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //Determine color sphere position
            Vector2 bluePosition = new Vector2(
                (float)Math.Cos(blueAngle) * distance, (float)Math.Sin(blueAngle) * distance);
            Vector2 greenPosition = new Vector2(
                (float)Math.Cos(greenAngle) * distance, (float)Math.Sin(greenAngle) * distance);
            Vector2 orangePosition = new Vector2(
                (float)Math.Cos(orangeAngle) * distance, (float)Math.Sin(orangeAngle) * distance);
            Vector2 purpsPosition = new Vector2(
                (float)Math.Cos(purpsAngle) * distance, (float)Math.Sin(purpsAngle) * distance);
            Vector2 redPosition = new Vector2(
                (float)Math.Cos(redAngle) * distance, (float)Math.Sin(redAngle) * distance);
            Vector2 turqPosition = new Vector2(
                (float)Math.Cos(turqAngle) * distance, (float)Math.Sin(turqAngle) * distance);

            Vector2 center = new Vector2(300, 140);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

            spriteBatch.Draw(blue, center + bluePosition, Color.White);
            spriteBatch.Draw(green, center + greenPosition, Color.White);
            spriteBatch.Draw(orange, center + orangePosition, Color.White);
            spriteBatch.Draw(purps, center + purpsPosition, Color.White);
            spriteBatch.Draw(red, center + redPosition, Color.White);
            spriteBatch.Draw(turq, center + turqPosition, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
