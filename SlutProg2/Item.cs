
public class Item
{
    // Namn på item
    public string Name { get; set; }

    // sätter namn
    public Item(string name)
    {
        Name = name;
    }

    // Bestämmer hur item visas som text, om jag inte har med det här så visade items i inventoriet som "item" istället för "coolt awesome svärd"
    public override string ToString()
    {
        return Name;
    }
}