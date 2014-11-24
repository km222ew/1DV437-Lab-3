using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace MinimalGame.Model
{
    class BallSimulation
    {
        private List<Ball> balls;        
        private int NUM_BALLS = 10;

        public BallSimulation()
        {
            balls = new List<Ball>();

            Random rand = new Random();

            for (int i = 0; i < NUM_BALLS; i++)
            {
                //(maxpos, minpos)
                float centerX = (float)rand.NextDouble() * (0.9f - 0.1f) + 0.1f;
                float centerY = (float)rand.NextDouble() * (0.9f - 0.1f) + 0.1f;

                //(maxspeed, minspeed)
                float speedX = (float)rand.NextDouble() * (1f - 0.2f) + 0.1f;
                float speedY = (float)rand.NextDouble() * (1f - 0.1f) + 0.1f;

                balls.Add(new Ball(centerX, centerY, speedX, speedY));
            }            
        }

        public void didBallsIntersect(Vector2 mousePos)
        {
            float mouseArea = 0.08f;


            foreach (var ball in balls)
            {
                if (ball.CenterX + ball.Diameter / 2 > mousePos.X - mouseArea && 
                    ball.CenterX - ball.Diameter / 2 < mousePos.X + mouseArea && 
                    ball.CenterY + ball.Diameter / 2 > mousePos.Y - mouseArea && 
                    ball.CenterY - ball.Diameter / 2 < mousePos.Y + mouseArea)
                {
                    ball.IsDead = true;
                }
            }

           //Rectangle mouseArea = new Rectangle(mousePos.X, mousePos.Y, 1, 1).Intersects(rectangle)
        }

        public void Update(GameTime gameTime)
        {
            float timeElapsedInSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var ball in balls)
            {
                if (!ball.IsDead)
                {
                    ball.CenterX += ball.SpeedX * timeElapsedInSeconds;

                    if (ball.CenterX + ball.Diameter / 2 > 1.0f || ball.CenterX - ball.Diameter / 2 < 0.0f)
                    {
                        ball.SpeedX = ball.SpeedX * -1.0f;
                    }

                    ball.CenterY += ball.SpeedY * timeElapsedInSeconds;

                    if (ball.CenterY + ball.Diameter / 2 > 1.0f || ball.CenterY - ball.Diameter / 2 < 0.0f)
                    {
                        ball.SpeedY = ball.SpeedY * -1.0f;
                    }
                }                
            }            
        }

        internal ReadOnlyCollection<Ball> Balls
        {
            get { return balls.AsReadOnly(); }
        }

    }
}
