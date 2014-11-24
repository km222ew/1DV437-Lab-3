using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MinimalGame.View.ParticleSystems
{
    class SplitterParticle
    {
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration;
        private float splitterSize = 0.025f;

        public SplitterParticle(Vector2 velocity, Vector2 position)
        {
            this.position = position;
            this.velocity = velocity;
            acceleration = new Vector2(0, 2f);
        }

        public void Update(float timeElapsed)
        {
            Vector2 newPos = new Vector2();
            Vector2 newVel = new Vector2();

            newVel.X = velocity.X + timeElapsed * acceleration.X;
            newVel.Y = velocity.Y + timeElapsed * acceleration.Y;

            newPos.X = position.X + timeElapsed * velocity.X;
            newPos.Y = position.Y + timeElapsed * velocity.Y;

            velocity = newVel;
            position = newPos;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture, Camera camera)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(splitterTexture, camera.scaleParticle(position.X, position.Y, splitterSize), Color.White);
            spriteBatch.End();
        }
    }
}
