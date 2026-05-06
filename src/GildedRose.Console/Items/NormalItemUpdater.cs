namespace GildedRose.Console.Items;

public class NormalItemUpdater : BaseItemUpdater, IItemUpdater
{
    public void Update(Item item)
    {
        DecreaseQuality(item);
        DecreaseSellIn(item);

        if (item.SellIn < 0)
        {
            DecreaseQuality(item);
        }
    }
}