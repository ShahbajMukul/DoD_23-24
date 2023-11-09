using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Includes
using System.Xml.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace DoD_23_24
{
    public class Wolf : Basic2D
    {
        float speed = 45f;
        public Rectangle wolfBounds;
        private float zoom = 2.0f;
        float playerXPos;
        float playerYPos;
        float distanceFromPlayer;
        private Player player;

        public Wolf(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale, Player player) : base(PATH, POS, DIMS, shouldScale)
        {
            wolfBounds = new Rectangle((int)pos.X - (int)(dims.X / 2), (int)pos.Y - (int)(dims.Y / 2), (int)dims.X, (int)dims.Y);
            this.player = player;
        }

        public void getPlayerLocation()
        {
            playerXPos = player.pos.X;
            playerYPos = player.pos.Y;
            distanceFromPlayer = Vector2.Distance(wolfBounds.Center.ToVector2(), player.pos);
        }

        public void Update(GameTime gametime)
        {
            getPlayerLocation();

            Vector2 direction = player.pos - pos;
            direction.Normalize();

            pos += direction * speed * (float)gametime.ElapsedGameTime.TotalSeconds;
        }
    }
}

