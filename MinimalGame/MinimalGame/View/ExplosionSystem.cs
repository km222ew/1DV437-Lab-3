using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MinimalGame.View.ParticleSystems;

namespace MinimalGame.View
{
    class ExplosionSystem
    {
        private SmokeSystem smokeSystem;
        private SplitterSystem splitterSystem;
        private FireParticle fireParticle;

        public ExplosionSystem(ContentManager content, Vector2 position, Camera camera)
        {
            smokeSystem = new SmokeSystem(position, content, camera);
            splitterSystem = new SplitterSystem(position, content, camera);
            fireParticle = new FireParticle(position, content, camera);
        }

        public void Update(float timeElapsed)
        {
            smokeSystem.Update(timeElapsed);
            splitterSystem.Update(timeElapsed);
            fireParticle.Update(timeElapsed);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            smokeSystem.Draw(spriteBatch);
            splitterSystem.Draw(spriteBatch);
            fireParticle.Draw(spriteBatch);
        }
    }
}
