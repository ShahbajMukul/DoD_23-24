#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System.Reflection.Metadata;
using DoD_23_24.Source.Gameplay.ShepardLevel;

#endregion

namespace DoD_23_24
{
    public class World
    {

        Level level;
        Player playerInstance;
        Ghost ghostInstance;
        public World()
        {
            level = new Level("Content/map.tmx", "Tiny Adventure Pack\\");
            playerInstance = new Player("2D/Sprites/Item", new Vector2(100, 100), new Vector2(16, 16), true, level);
            ghostInstance = new Ghost("2D/Sprites/Item", new Vector2(75, 75), new Vector2(16, 16), true, playerInstance);
        }

        public virtual void Update(GameTime gameTime)
        {
            playerInstance.Update(gameTime);
            ghostInstance.Update(gameTime);
        }

        public virtual void Draw()
        {
            level.Draw();
            playerInstance.Draw();
            ghostInstance.Draw();
        }

        public Player GetPlayer()
        {
            return playerInstance;
        }
    }
}

