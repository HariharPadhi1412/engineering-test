namespace GildedRose.Console.Items;

public class BackstagePassUpdater : BaseItemUpdater, IItemUpdater
{
    public void Update(Item item)
    {
        IncreaseQuality(item);

        if (item.SellIn < 11)
            IncreaseQuality(item);

        if (item.SellIn < 6)
            IncreaseQuality(item);

        DecreaseSellIn(item);

        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
    }
}