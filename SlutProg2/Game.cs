
using System;
using System.Collections.Generic;

public class Game
{
    // Spelar objekt
    private Player player;

    // Lista med alla rum i spelet
    private List<Room> rooms = new List<Room>();

    // Håller koll på vilket rum spelaren är i
    private int currentRoomIndex = 0;

    public void Start()
    {
        // frågar vad du vill heta och shickar skiten till player
        Console.WriteLine("Ange ditt namn:");
        string name = Console.ReadLine();

        // ifall du skriver något som mitt program inte gillar eller tomt, så kommer den tvinga dig att heta Hugo den tredje
        if (string.IsNullOrWhiteSpace(name))
            name = "Hugo den tredje";

        // Skapar spelaren
        player = new Player(name);

        // Skapar alla rum, dem är inte random, jag måsta lägga till dem seperat och skapa namn och descriptions och loot och nytt namn för fiende plus deras hp, eftersommatt jag e en fet chud som inte skriver bättre kod som på nått sätt randomisar sånt, det e nog inte ens så svårt men palla
        rooms.Add(new Room("Grottan", "En mörk grotta",
            new Enemy("Goblin", 30), new Item("Svärd")));

        rooms.Add(new Room("Korridoren", "En kall korridor",
            new Enemy("Skelett", 40), new Item("Sköld")));

        rooms.Add(new Room("Bossrum", "Ett farligt rum",
            new Enemy("Drake", 80), new Item("Legendärt svärd")));

        // Startar spelets huvudloop
        GameLoop();
    }
    // Är spelets huvudloop
    private void GameLoop()
    {
        // Kör spelet tills spelaren dör
        while (player.Health > 0)
        {
            // Kollar rummet du är i just nu
            Room currentRoom = rooms[currentRoomIndex];

            // Skriver ut mina fina rum namn och beskrivningar
            Console.WriteLine($"\nDu är i: {currentRoom.Name}");
            Console.WriteLine(currentRoom.Description);

            // Tvingar dig fighta fienden i rummet, bara när fienden är död kan man börja gå till andra rum, du kan fortfarande checka ditt inventory dock
            if (currentRoom.Enemy != null && currentRoom.Enemy.Health > 0)
            {
                EnterRoom(currentRoom);
            }

            // Skriver ut dina val
            Console.WriteLine("\n1. Gå framåt\n2. Gå bakåt\n3. Visa inventory");
            string choice = Console.ReadLine();

            // Gör spelarens val, ifall du skriver något som inte specifikt är 1, 2 eller 3 så kommer den skriva ogiltigt val
            switch (choice)
            {
                case "1":
                    MoveForward();
                    break;
                case "2":
                    MoveBackward();
                    break;
                case "3":
                    player.Inventory.ShowAll();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val!");
                    break;
            }
        }

        // Game over om HP = 0, inte för att man hinner se medelandet, eftersomatt skiten stängs direkt
        Console.WriteLine("Game Over!");
    }

    private void MoveForward()
    {
        // gå fram om du kan, aka till nästa rum
        if (currentRoomIndex < rooms.Count - 1)
            currentRoomIndex++;
        else
            Console.WriteLine("Du kan inte gå längre fram!");
    }

    private void MoveBackward()
    {
        // samma som fram fast bak
        if (currentRoomIndex > 0)
            currentRoomIndex--;
        else
            Console.WriteLine("Du kan inte gå längre bak!");
    }

    private void EnterRoom(Room room)
    {
        // när du kommer till ett rum skriver den ut rummets namn, beskrivning och fiendens namn
        Console.WriteLine($"Du möter en {room.Enemy.Name}!");

        // Allt händer så länge antingen spelaren eller enemyn? enemien? fienden lever
        while (room.Enemy.Health > 0 && player.Health > 0)
        {
            // Visar alla stats och sånt
            Console.WriteLine("\n--- Status ---");
            Console.WriteLine($"{player.Name} HP: {player.Health}");
            Console.WriteLine($"{room.Enemy.Name} HP: {room.Enemy.Health}");

            // Spelarens val
            Console.WriteLine("\n1. Attackera\n2. Visa inventory");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Din attack och dmg nummer
                int dmg = player.Attack();
                room.Enemy.Health -= dmg;
                Console.WriteLine($"Du gör {dmg} skada!");

                // Onda snubbens attack och dmg nummer
                if (room.Enemy.Health > 0)
                {
                    int enemyDmg = room.Enemy.Attack();
                    player.Health -= enemyDmg;
                    Console.WriteLine($"Fienden gör {enemyDmg} skada!");
                }
            }
            else if (choice == "2")
            {
                // Visar ditt inventory
                player.Inventory.ShowAll();
            }
            // ifall du inte skrev 1 eller 2 så säger den till dig på skarpen
            else
            {
                Console.WriteLine("Ogiltigt val!");
            }
        }

        // När du dödar elaka snubben så får du looten, och efter du får den tar spelet bort den så man inte kan gå fram och tilbaka och samla på sig fett med epsik loot
        if (player.Health > 0 && room.Loot != null)
        {
            Console.WriteLine($"Du hittade: {room.Loot.Name}");
            player.Inventory.Add(room.Loot);
            room.Loot = null; // här e inte loot längre
        }
    }
}