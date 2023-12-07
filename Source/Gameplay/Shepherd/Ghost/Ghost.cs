using DoD_23_24;
using Microsoft.Xna.Framework;

public class Ghost : Entity
{
    TransformComponent transform;
    Entity player;
    bool hasPassedThrough = false;

    public Ghost(string name, Vector2 POS, string spritePath, Entity player) : base(name, Layer.NPC)
    {
        this.player = player;
        transform = (TransformComponent)AddComponent(new TransformComponent(this, POS, 0.0f, new Vector2(16, 16)));
        AddComponent(new RenderComponent(this, spritePath));
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        float distanceToPlayer = Vector2.Distance(transform.pos, player.GetComponent<TransformComponent>().pos);
        if (distanceToPlayer < 30 && !hasPassedThrough)
        {
            hasPassedThrough = true; 
            Player playerComponent = player as Player;
            playerComponent.Disorient(5.0f); 
        }

        if (hasPassedThrough)
        {
            MoveAwayFromPlayer(gameTime);
        }
        else
        {
            MoveTowardsPlayer(gameTime);
        }
    }

    private void MoveTowardsPlayer(GameTime gameTime)
    {
        Vector2 direction = player.GetComponent<TransformComponent>().pos - transform.pos;
        direction.Normalize();

        float speed = 20f;
        transform.pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
    private void MoveAwayFromPlayer(GameTime gameTime)
    {
        Vector2 direction = transform.pos - player.GetComponent<TransformComponent>().pos;
        direction.Normalize();

        float speed = 20f;
        transform.pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (Vector2.Distance(transform.pos, player.GetComponent<TransformComponent>().pos) > 100) 
        {
            hasPassedThrough = false;
        }

    }
}
