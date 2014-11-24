using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MinimalGame.Model
{
    class Ball
    {
        private float centerX;
        private float centerY;
        private float diameter;
        private float speedX;
        private float speedY;
        private bool isDead;

        public Ball(float centerX, float centerY, float speedX, float speedY)
        {
            isDead = false;
            this.centerX = centerX;
            this.centerY = centerY;
            diameter = 0.06f;
            this.speedX = speedX;
            this.speedY = speedY;
        }

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }

        public float CenterX
        {
            get { return centerX; }
            set { centerX = value; }
        }

        public float CenterY
        {
            get { return centerY; }
            set { centerY = value; }
        }

        public float Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }

        public float SpeedX
        {
            get { return speedX; }
            set { speedX = value; }
        }

        public float SpeedY
        {
            get { return speedY; }
            set { speedY = value; }
        }

    }
}
