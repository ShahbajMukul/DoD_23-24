using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoD_23_24;

namespace DoD_23_24.Source.Gameplay.ShepardLevel
{
    public class Ram : Basic2D
    {

        float speed = 50f;
        Matrix translation;
        public Rectangle rambounds;
        private float zoom = 2.0f;
        private Player player;
        private Player targetPlayer;


        public Ram(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale, Player player) : base(PATH, POS, DIMS, shouldScale)
        {
            rambounds = new Rectangle((int)pos.X - (int)(DIMS.X / 2), (int)POS.Y - (int)(DIMS.Y / 2), (int)DIMS.X, (int)DIMS.Y);
        }

        public override void Update(GameTime gameTime)
        {
            Movement(gameTime);
            CalculateTranslation();

            base.Update(gameTime);
        }

        public override void Draw()
        {
            base.Draw();
        }

        public void Movement(GameTime gameTime)
        {
           }

        private void CalculateTranslation()
        {
            var dx = Globals.WIDTH / (zoom * 2) - rambounds.X;
            var dy = Globals.HEIGHT / (zoom * 2) - rambounds.Y;
            translation = Matrix.CreateTranslation(dx, dy, 0f) * Matrix.CreateScale(zoom);
        }

        public Vector2 getPos()
        {
            return pos;
        }

        public void setPos(Vector2 pos)
        {
            this.pos = pos;
        }

        public Matrix GetTranslation()
        {
            return translation;
        }
    }
}

