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
    public bool isalreadyhealed = false; bool alreadyattacked = false;
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
    public MouseState mstate;
    private bool canAttack = true;
    private double elapsedCooldownTime = 0.0;

    public Rams(string name, string PATH, Vector2 POS, float ROT, Vector2 DIMS, Entity player) : base(name, Layer.NPC)
    {
        mstate = Mouse.GetState();
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

    public void Attack(GameTime gameTime , MouseState state)
    {


        Vector2 RamPosition = playerinstance.Transform.pos;



        // direction.Normalize(); // Set the X and Y coordinates
        direction = RamPosition;
//        direction.Normalize();

        float speed = 2f;
        // shouldLaunch = true;
       
        while (mstate.LeftButton  != ButtonState.Released)
        {
            transform.pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            
        }
    }




    //
        // if (collision)
        // {
        //     
        // }
        
        

    

    public void resetPosition()
    {
        transform.pos = playerinstance.GetComponent<TransformComponent>().pos + new Vector2(50,50);
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








    Double time = 0;


    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        mstate = Mouse.GetState();


        if (Vector2.Distance(playerinstance.GetComponent<TransformComponent>().pos, transform.pos) > 100)
        {
            alreadyattacked = true;
        }
        else
        {
            alreadyattacked = false;
        }


        if (alreadyattacked)
        {
            elapsedCooldownTime = (elapsedCooldownTime >= 5.0) ? 0.0 : elapsedCooldownTime + gameTime.ElapsedGameTime.TotalSeconds;
            
        }
        
        
        Console.WriteLine("gametime is:" + elapsedCooldownTime);

      
        if (elapsedCooldownTime == 0.0){

            if (mstate.LeftButton == ButtonState.Pressed)
            {
                Attack(gameTime, mstate);

               
            }
           
            
            
            canAttack = true;
        }
        else
        {
            resetPosition();

        }
        
        
        Console.WriteLine("alreadyattacked is" + alreadyattacked);
    


        // Rest of your existing code...
    }






}

// public override void Draw()
// {
//     base.Draw();
//     
// }

