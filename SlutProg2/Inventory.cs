
using System.Collections.Generic;

public class Inventory<T>
{
    // Privat lista som lagrar items, behövde det här för inkapsling betygsaken 
    private List<T> items = new List<T>();

    // Lägger till ett item i inventory
    public void Add(T item)
    {
        items.Add(item);
    }

    // Visar alla items i inventory
    public void ShowAll()
    {
        // Kollar om inventory är tomt, och ifall det e det skriver
        if (items.Count == 0)
        {
            Console.WriteLine("Inventory är tomt.");
            return;
        }

        // Loopar igenom alla items och skriver ut dem för spelaren att njuta av sin episka loot
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}