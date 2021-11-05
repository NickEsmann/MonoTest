using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest
{
    class Enemy : GameObject
    {
        Random random;

        public Enemy()
        {
            random = new Random();
        }
        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[4];

            sprites[0] = content.Load<Texture2D>("Enemy/enemyBlack1");
            sprites[1] = content.Load<Texture2D>("Enemy/enemyBlue1");
            sprites[2] = content.Load<Texture2D>("Enemy/enemyGreen1");
            sprites[3] = content.Load<Texture2D>("Enemy/enemyRed1");

            Respawn();
        }

       

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);

            if(position.Y > GameWorld.Screensize.Y)
            {
                Respawn();
            }
        }
        private void Respawn()
        {
            int index = random.Next(0, 4);
            sprite = sprites[index];
            velocity = new Vector2(0, 1);
            speed = random.Next(10, 100);
            position.X = random.Next(0, (int)GameWorld.Screensize.X - sprite.Width);
            position.Y = 0;

        }
        public override void OnCollision(GameObject other)
        {
            if(other is Laser)
            {
                GameWorld.Destroy(other);
                Respawn();
            }
        }

    }
}
