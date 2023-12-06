using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace DoD_23_24;

public class Rams : Entity
{
    float speed = 50f;
    private TransformComponent transform;
    private TransformComponent playertransform;
    private Entity playerinstance;
    private float POSX = 0;
    private float POSY = 0;
    private bool shouldLaunch = false;
    private Vector2 direction;

    public Rams(string name, string PATH, Vector2 POS, float ROT, Vector2 DIMS, Entity player) : base(name, Layer.NPC)
    {
        playerinstance = player;
        
        transform = (TransformComponent)AddComponent(new TransformComponent(this, POS, ROT, DIMS));
        
        AddComponent(new RenderComponent(this, PATH));
        AddComponent(new CollisionComponent(this, true, true));
        playerinstance = player;
        playertransform = player.GetComponent<TransformComponent>();
      POSX =   playerinstance.GetComponent<TransformComponent>().pos.X + 50;
      POSY =   playerinstance.GetComponent<TransformComponent>().pos.Y + 50;


        // transform = player.GetComponent<TransformComponent>();
        //PlayerTransform = player.GetParent().GetComponent<TransformComponent>();


    }

    public void Move(GameTime gameTime)
    {
        KeyboardState kstate = Keyboard.GetState();
        MouseState mstate = Mouse.GetState();
        
            Vector2 RamPosition = mstate.Position.ToVector2(); // Set the X and Y coordinates

// Set the direction
             // 45 degrees in radians
            direction = RamPosition;
            direction.Normalize();

// Set the speed
            float speed = .01f;

// In your Update method, update the position

            shouldLaunch = true;
        
    }

    

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        MouseState mstate = Mouse.GetState();
        if (mstate.LeftButton != ButtonState.Pressed)
        {
            POSX =   playerinstance.GetComponent<TransformComponent>().pos.X + 50;
            POSY =   playerinstance.GetComponent<TransformComponent>().pos.Y + 50;
            transform.pos.Y = POSY;
            transform.pos.X = POSX; 
        }
        
        else if (mstate.LeftButton == ButtonState.Pressed)
        {
            Move(gameTime);
        }

        if (shouldLaunch)
        {
            transform.pos += direction * speed;
        }

    }

    // public override void Draw()
    // {
    //     base.Draw();
    //     
    // }
    
}