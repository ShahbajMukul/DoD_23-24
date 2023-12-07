using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace DoD_23_24;

public class Rams : Entity
{
    bool isalreadyhealed = false;
    float speed = 50f;
    private TransformComponent transform;
    private TransformComponent playertransform;
    public Player playerinstance;
    private float POSX = 0;
    private float POSY = 0;
    private bool shouldLaunch = false;
    private Vector2 direction;
    private int playerhealth;
    private CollisionComponent collision;

    public Rams(string name, string PATH, Vector2 POS, float ROT, Vector2 DIMS, Entity player) : base(name, Layer.NPC)
    {
        playerinstance = (Player)player;
        
        transform = (TransformComponent)AddComponent(new TransformComponent(this, POS, ROT, DIMS));

        AddComponent(new RenderComponent(this, PATH));
        AddComponent(collision = new CollisionComponent(this, true, true));
                
        playertransform = player.GetComponent<TransformComponent>();
        POSX = playerinstance.GetComponent<TransformComponent>().pos.X + 50;
        POSY = playerinstance.GetComponent<TransformComponent>().pos.Y + 50;
        
        playerhealth = playerinstance.Health;
        // transform = player.GetComponent<TransformComponent>();
        //PlayerTransform = player.GetParent().GetComponent<TransformComponent>();
        
        

    }

    public void Attack(GameTime gameTime)
    {

        MouseState mstate = Mouse.GetState();

        Vector2 RamPosition = mstate.Position.ToVector2(); // Set the X and Y coordinates
        direction = RamPosition;
        direction.Normalize();

        float speed = 0.001f;
        shouldLaunch = true;
        //
        // if (collision)
        // {
        //     
        // }
        
        

    }

    public void HealPlayer(GameTime gametime)
    {
        
        
        KeyboardState kstate = Keyboard.GetState();
        if (kstate.IsKeyDown(Keys.Space) && isalreadyhealed == false)
        {
            playerhealth += 50;
            isalreadyhealed = true;
        }

        

    }











    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        
        MouseState mstate = Mouse.GetState();
        
        if (mstate.LeftButton != ButtonState.Pressed)
        {
            POSX = playerinstance.GetComponent<TransformComponent>().pos.X + 50;
            POSY = playerinstance.GetComponent<TransformComponent>().pos.Y + 50;
            transform.pos.Y = POSY;
            transform.pos.X = POSX;
        }
        
        else if (mstate.LeftButton == ButtonState.Pressed)
        {
            
            Attack(gameTime);
        }

        if (shouldLaunch)
        {
            transform.pos += direction * speed;
        }

        HealPlayer(gameTime);


    }
}

// public override void Draw()
    // {
    //     base.Draw();
    //     
    // }
    
