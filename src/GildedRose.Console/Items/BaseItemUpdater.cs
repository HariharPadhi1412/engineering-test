
namespace GildedRose.Console.Items;

public abstract class BaseItemUpdater
{
    protected void IncreaseQuality(Item item, int amount = 1)
    {
        item.Quality = Math.Min(50, item.Quality + amount);
    }

    protected void DecreaseQuality(Item item, int amount = 1)
    {
        item.Quality = Math.Max(0, item.Quality - amount);
    }

    protected void DecreaseSellIn(Item item)
    {
        item.SellIn--;
    }
}