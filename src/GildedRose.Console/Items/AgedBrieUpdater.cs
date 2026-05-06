namespace GildedRose.Console.Items;

public class AgedBrieUpdater : BaseItemUpdater, IItemUpdater
{
    public void Update(Item item)
    {
        IncreaseQuality(item);
        DecreaseSellIn(item);

        if (item.SellIn < 0)
        {
            IncreaseQuality(item);
        }
    }
}