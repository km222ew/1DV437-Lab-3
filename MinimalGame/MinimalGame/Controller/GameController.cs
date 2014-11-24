using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using MinimalGame.Model;
using MinimalGame.View;

namespace MinimalGame.Controller
{
    class GameController
    {
        private MouseView mouse;
        private List<ExplosionSystem> particles;
        private ContentManager content;
        private Camera camera;
        private SoundEffect shot;
        private BallSimulation model;

        public GameController(ContentManager content, Camera camera, BallSimulation model)
        {
            this.content = content;
            this.camera = camera;
            this.model = model;
            mouse = new MouseView(camera);

            shot = content.Load<SoundEffect>("fire");


            particles = new List<ExplosionSystem>();
        }

        public void Update(float timeElapsed)
        {
            if (mouse.IsButtonPressed())
            {
                Vector2 mousePos = mouse.GetMousePos();

                particles.Add(new ExplosionSystem(content, mousePos, camera));
                shot.Play();
                model.didBallsIntersect(mousePos);
            }
            
            foreach (var particle in particles)
            {
                particle.Update(timeElapsed);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var particle in particles)
            {
                particle.Draw(spriteBatch);
            }
        }
    }
}
