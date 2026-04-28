
public class Player : Character
{
    // lista av the OH SO Precious items
    public Inventory<Item> Inventory { get; set; }

    // Efter som att jag hade get; set; i charachter pappa klassen så kan jag enkelt skriva in dem här, jag andvänder ett string från spelaren när man börjar spelet
    public Player(string name) : base(name, 100)
    {
        Inventory = new Inventory<Item>();
    }

    // Override ändrar the big boss klass (character),s virtual, behövde jag verkligen den här? nae, men den var cool att andvända
    public override int Attack()
    {
        return 10;
    }
}