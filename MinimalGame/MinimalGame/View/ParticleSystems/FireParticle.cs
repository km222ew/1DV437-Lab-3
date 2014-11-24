using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MinimalGame.View.ParticleSystems
{
    class FireParticle
    {
        Texture2D explosionTexture;

        private Vector2 position;
        private float timeElapsed;
        private float maxTime = 0.5f;
        private int numberOfFrames = 24;
        private int numFramesX = 4;
        private int frameSize;
        private float scaledFrameSize = 0.2f;

        Camera camera;

        public FireParticle(Vector2 position, ContentManager content, Camera camera)
        {            
            this.camera = camera;
            this.position = position;
            explosionTexture = content.Load<Texture2D>("explosion");
            frameSize = explosionTexture.Bounds.Width / numFramesX;
            scaledFrameSize = scaledFrameSize * camera.Scale;          
        }

        public void Update(float elapsedTime)
        {
            timeElapsed += elapsedTime;
            //if (timeElapsed >= maxTime)
            //{
            //    timeElapsed = 0;
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float percentAnimated = timeElapsed / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);

            int frameX = frame % numFramesX;
            int frameY = frame / numFramesX;

            Vector2 scalePos = camera.scaleparticleVector(position.X, position.Y);

            spriteBatch.Begin();
            //camera.scaleParticle(position.X, position.Y, frameSize)
            spriteBatch.Draw(explosionTexture, new Rectangle((int)scalePos.X - (int)scaledFrameSize / 2, (int)scalePos.Y - (int)scaledFrameSize / 2, (int)scaledFrameSize, (int)scaledFrameSize), new Rectangle(frameX * frameSize, frameY * frameSize, frameSize, frameSize), Color.White);

            spriteBatch.End();
        }
    }
}
