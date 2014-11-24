using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using MinimalGame.Model;
using MinimalGame.View;

namespace MinimalGame.Controller
{
    public class MasterController : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private BallSimulation model;
        private BallView view;
        private Camera camera;
        private GameController gameController;

        public MasterController()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;

            this.IsMouseVisible = true;
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

            // TODO: use this.Content to load your game content here
            camera = new Camera(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);   
            model = new BallSimulation();
            gameController = new GameController(Content, camera, model);                     
            view = new BallView(GraphicsDevice, Content, camera);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            gameController.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            model.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkCyan);

            // TODO: Add your drawing code here            
            gameController.Draw(spriteBatch);
            view.DrawBorder();

            foreach (var ball in model.Balls)
            {
                view.DrawBall(ball.CenterX, ball.CenterY, ball.Diameter, ball.IsDead);
            }
            //view.DrawBall(model.GetBallCenterX(), model.GetBallCenterY(), model.GetBallDiameter());
            base.Draw(gameTime);
        }
    }
}
