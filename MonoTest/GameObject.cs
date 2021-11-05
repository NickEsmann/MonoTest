using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest
{
    public abstract class GameObject
    {
        protected Vector2 position;
        protected Texture2D[] sprites;
        protected Texture2D sprite;
        protected float fps;
        protected Vector2 origin;
        private float timeElapsed;
        private int currentIndex;
        protected float speed;
        protected Vector2 velocity;
        protected Vector2 offset;
        protected Color color;

        public Color GetColor
        {
            get { return color; }
            set { color = value; }
        }
        public Rectangle Collision
        {
            get { return new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), sprite.Width, sprite.Height); }
        }
        public abstract void LoadContent(ContentManager content);
        

        public abstract void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, 1, SpriteEffects.None, 0);
        }

        public abstract void Update(GameTime gameTime);

        

        protected void Animate(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            currentIndex = (int)(timeElapsed * fps);
            sprite = sprites[currentIndex];

            if(currentIndex >= sprites.Length -1)
            {
                timeElapsed = 0;
                currentIndex = 0;
            }
        }

        protected void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += ((velocity * speed) * deltaTime);
        }
        public abstract void OnCollision(GameObject other);
        

        
        public abstract void CheckCollision(GameObject other)
        {
            if(Collision.Intersects(other.Collision))
            {
                OnCollision(other);
            }
        }

    }
}
