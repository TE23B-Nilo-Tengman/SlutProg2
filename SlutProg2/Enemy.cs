
public class Enemy : Character
{
    // samma som player klassen
    public Enemy(string name, int health) : base(name, health)
    {
    }

    // samma som player classen, stavas det med c eller k????
    public override int Attack()
    {
        return 7;
    }
}