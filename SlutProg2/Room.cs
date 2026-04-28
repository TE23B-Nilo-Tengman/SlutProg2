
public class Room
{
    // Namn på rummet
    public string Name { get; set; }

    // Beskrivning av rummet
    public string Description { get; set; }

    // Fienden i rummet
    public Enemy Enemy { get; set; }

    // Loot som finns i rummet
    public Item Loot { get; set; }

    // sätter alla värden
    public Room(string name, string description, Enemy enemy, Item loot)
    {
        Name = name;
        Description = description;
        Enemy = enemy;
        Loot = loot;
    }
}