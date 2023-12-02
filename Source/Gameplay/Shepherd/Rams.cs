using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
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
        //transform = playerinstance.GetComponent<TransformComponent>();

    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        POSX =   playerinstance.GetComponent<TransformComponent>().pos.X + 50;
        POSY =   playerinstance.GetComponent<TransformComponent>().pos.Y + 50;
        transform.pos.Y = POSY;
        transform.pos.X = POSX;

    }

    // public override void Draw()
    // {
    //     base.Draw();
    //     
    // }
    
}