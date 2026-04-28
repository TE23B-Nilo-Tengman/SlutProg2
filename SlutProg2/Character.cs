
public class Character
{
    public string Name { get; set; }

    
    public int Health { get; set; }

    // sätter namn och HP, just nu är hp alltid 100
    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    // virtual så att den kan ändras i subklasser
    public virtual int Attack()
    {
        return 5;
    }
}