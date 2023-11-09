using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD_23_24.Source.Gameplay.ShepardLevel
{
    public class Ghost : Basic2D
    {

        private float moveSpeed;
        public Rectangle ghostBounds;
        private Player targetPlayer;

        private const float BlindnessDistance = 100f;
        private const float DrunknessDistance = 50f;
        private TimeSpan blindnessTimer = TimeSpan.Zero;
        private TimeSpan drunknessTimer = TimeSpan.Zero;
        private bool isBlindingPlayer = false;
        private bool isMakingPlayerDizzy = false;

        public Ghost(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale, Player player) : base(PATH, POS, DIMS, shouldScale)
        {
            targetPlayer = player;
            isBlindingPlayer = false;
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
                isBlindingPlayer = true;
            }
            else
            {
                isBlindingPlayer = false;
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
