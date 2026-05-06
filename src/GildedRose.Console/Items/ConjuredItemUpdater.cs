namespace GildedRose.Console.Items;

public class ConjuredItemUpdater : BaseItemUpdater, IItemUpdater
{
    public void Update(Item item)
    {
        DecreaseQuality(item, 2);
        DecreaseSellIn(item);

        if (item.SellIn < 0)
        {
            DecreaseQuality(item, 2);
        }
    }
}