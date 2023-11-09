using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD_23_24.Source.Gameplay.ShepardLevel
{
    public class Ghost : Basic2D
    {
        private bool isBlinding;
        private bool isWeakening;
        private float moveSpeed;
        public Rectangle ghostBounds;
        private Player targetPlayer;


        public Ghost(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale, Player player) : base(PATH, POS, DIMS, shouldScale)
        {
            targetPlayer = player;
            isBlinding = false;
            moveSpeed = 10.0f;
        }

        public override void Update(GameTime gameTime)
        {
            MoveTowardPlayer(gameTime);
            CheckPlayerInteraction();

            base.Update(gameTime); 
        }

        private void CheckPlayerInteraction()
        {
            if (Vector2.Distance(pos,targetPlayer.pos) < 50)
            {
                isBlinding = true;
            }
            else
            {
                isBlinding = false;
            }
        }

        public override void Draw()
        {
            base.Draw();
        }

        private void MoveTowardPlayer(GameTime gameTime)
        {
            Vector2 direction = targetPlayer.pos - pos;
            direction.Normalize();
            pos += direction * moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
