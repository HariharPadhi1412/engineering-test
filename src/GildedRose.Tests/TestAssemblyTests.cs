using Xunit;

namespace GildedRose.Tests;

public class GildedRoseTests
{
    [Fact]
    public void Normal_Item_Quality_Decreases_By_One()
    {
        // Arrange
        var item = new Item
        {
            Name = "+5 Dexterity Vest",
            SellIn = 10,
            Quality = 20
        };

        var updater = new NormalItemUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(19, item.Quality);
        Assert.Equal(9, item.SellIn);
    }

    [Fact]
    public void Normal_Item_Quality_Decreases_Twice_After_SellDate()
    {
        // Arrange
        var item = new Item
        {
            Name = "+5 Dexterity Vest",
            SellIn = 0,
            Quality = 20
        };

        var updater = new NormalItemUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(18, item.Quality);
        Assert.Equal(-1, item.SellIn);
    }

    [Fact]
    public void Quality_Never_Goes_Below_Zero()
    {
        // Arrange
        var item = new Item
        {
            Name = "Elixir of the Mongoose",
            SellIn = 5,
            Quality = 0
        };

        var updater = new NormalItemUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void AgedBrie_Quality_Increases()
    {
        // Arrange
        var item = new Item
        {
            Name = "Aged Brie",
            SellIn = 2,
            Quality = 0
        };

        var updater = new AgedBrieUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(1, item.Quality);
        Assert.Equal(1, item.SellIn);
    }

    [Fact]
    public void AgedBrie_Quality_Never_Exceeds_50()
    {
        // Arrange
        var item = new Item
        {
            Name = "Aged Brie",
            SellIn = 2,
            Quality = 50
        };

        var updater = new AgedBrieUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void BackstagePass_Quality_Increases_By_Two_When_10_Days_Or_Less()
    {
        // Arrange
        var item = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 10,
            Quality = 20
        };

        var updater = new BackstagePassUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void BackstagePass_Quality_Increases_By_Three_When_5_Days_Or_Less()
    {
        // Arrange
        var item = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 5,
            Quality = 20
        };

        var updater = new BackstagePassUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(23, item.Quality);
    }

    [Fact]
    public void BackstagePass_Quality_Drops_To_Zero_After_Concert()
    {
        // Arrange
        var item = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 0,
            Quality = 20
        };

        var updater = new BackstagePassUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void Sulfuras_Never_Changes()
    {
        // Arrange
        var item = new Item
        {
            Name = "Sulfuras, Hand of Ragnaros",
            SellIn = 0,
            Quality = 80
        };

        var updater = new SulfurasUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(80, item.Quality);
        Assert.Equal(0, item.SellIn);
    }

    [Fact]
    public void Conjured_Items_Degrade_Twice_As_Fast()
    {
        // Arrange
        var item = new Item
        {
            Name = "Conjured Mana Cake",
            SellIn = 3,
            Quality = 10
        };

        var updater = new ConjuredItemUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(8, item.Quality);
        Assert.Equal(2, item.SellIn);
    }
}