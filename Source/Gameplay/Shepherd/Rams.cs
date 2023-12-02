using System;
using System.Numerics;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace DoD_23_24;

public class Rams : Entity
{
    float speed = 50f;
    TransformComponent transform;
    private TransformComponent PlayerTransform;

    

    public Rams(string name, string PATH, Vector2 POS, float ROT, Vector2 DIMS) : base(name, Layer.NPC)
    {
        transform = (TransformComponent)AddComponent(new TransformComponent(this, POS, ROT, DIMS));
        AddComponent(new RenderComponent(this, PATH));
        AddComponent(new CollisionComponent(this, true, true));
    }

    public void Movement(GameTime gameTime)
    {
        
    }

    public override void Update(GameTime gameTime)
    {
        
        
        base.Update(gameTime);
       // PlayerTransform = GetComponent<TransformComponent>();
        //transform.pos = PlayerTransform.pos + new Vector2(10,10)
        // Console.WriteLine(PlayerTransform.pos.ToString());


    }

    // public override void Draw()
    // {
    //     base.Draw();
    //     
    // }
    
}