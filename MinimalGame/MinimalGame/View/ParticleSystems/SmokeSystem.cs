using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MinimalGame.View.ParticleSystems
{
    class SmokeSystem
    {
        private Texture2D smokeTexture;
        private List<SmokeParticle> particles = new List<SmokeParticle>();
        private float totalTime = 0;
        private static float delay = 0.15f;
        private static float MAX_PARTICLES = 50;
        private Camera camera;
        private Vector2 position;

        public SmokeSystem(Vector2 position, ContentManager content, Camera camera)
        {
            this.camera = camera;
            this.position = position;
            smokeTexture = content.Load<Texture2D>("particlesmoke");            
        }

        public void Update(float timeElapsed)
        {
            totalTime += timeElapsed;

            if (totalTime >= delay)
            {
                totalTime = 0;

                if (particles.Count < MAX_PARTICLES)
                {
                    particles.Add(new SmokeParticle(position));
                }
            }

            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Update(timeElapsed);

                if (particles[i].IsDead())
                {
                    particles[i].Respawn();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(spriteBatch, smokeTexture, camera);
            }
        }
    }
}
