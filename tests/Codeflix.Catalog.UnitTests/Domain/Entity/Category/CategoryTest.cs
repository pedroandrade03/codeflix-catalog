using DomainEntity = Codeflix.Catalog.Domain.Entity;

namespace Codeflix.Catalog.UnitTests.Domain.Entity.Category;

public class CategoryTest
{
    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Domain", "Category - Aggregate")]
    public void Instantiate()
    {
        var validData = new
        {
            Name = "Category Test",
            Description = "Description Test",
        };
        var dateTimeBefore = DateTime.Now;

        var category = new DomainEntity.Category(validData.Name, validData.Description);
        var dateTimeAfter = DateTime.Now;

        Assert.NotNull(category);
        Assert.Equal(validData.Name, category.Name);
        Assert.Equal(validData.Description, category.Description);
        Assert.NotEqual(default(Guid), category.Id);
        Assert.NotEqual(default(DateTime), category.CreatedAt);
        Assert.True(category.CreatedAt > dateTimeBefore);
        Assert.True(category.CreatedAt < dateTimeAfter);
        Assert.True(category.IsActive);
    }

    [Theory(DisplayName = nameof(InstantiateWithIsActiveStatus))]
    [Trait("Domain", "Category - Aggregate")]
    [InlineData(true)]
    [InlineData(false)]
    public void InstantiateWithIsActiveStatus(bool isActive)
    {
        var validData = new
        {
            Name = "Category Test",
            Description = "Description Test",
            IsActive = isActive
        };
        var dateTimeBefore = DateTime.Now;

        var category = new DomainEntity.Category(validData.Name, validData.Description, validData.IsActive);
        var dateTimeAfter = DateTime.Now;

        Assert.NotNull(category);
        Assert.Equal(validData.Name, category.Name);
        Assert.Equal(validData.Description, category.Description);
        Assert.NotEqual(default(Guid), category.Id);
        Assert.NotEqual(default(DateTime), category.CreatedAt);
        Assert.True(category.CreatedAt > dateTimeBefore);
        Assert.True(category.CreatedAt < dateTimeAfter);
        Assert.Equal(isActive, category.IsActive);
    }
}