using GildedRose.Console.Items;

namespace GildedRose.Console;

public class Program
{
   public IList<Item> Items = new List<Item>();

    static void Main(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");

        var app = new Program
        {
            Items = new List<Item>
            {
                new() {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new() {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new() {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new() {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            }
        };

        app.UpdateQuality();

        System.Console.ReadKey();
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            var updater = ItemUpdaterFactory.GetUpdater(item);
            updater.Update(item);
        }
    }
}