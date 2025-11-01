using Microsoft.EntityFrameworkCore;
using MLP10.Data;
using Xunit;

namespace MLP10.Tests.Data;

public class ApplicationDbContextTests
{
    [Fact]
    public async Task ApplicationDbContext_CanSaveAndRetrieveApartament()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_Database")
            .Options;

        // Act - Save
        using (var context = new ApplicationDbContext(options))
        {
            var apartament = new Apartament
            {
                ApartamentNumber = 102,
                ApartamentType = "Deluxe",
                Cost = 2500
            };

            context.Apartaments.Add(apartament);
            await context.SaveChangesAsync();
        }

        // Act - Retrieve
        using (var context = new ApplicationDbContext(options))
        {
            var savedApartament = await context.Apartaments
                .FirstOrDefaultAsync(a => a.ApartamentNumber == 102);

            // Assert
            Assert.NotNull(savedApartament);
            Assert.Equal("Deluxe", savedApartament.ApartamentType);
            Assert.Equal(2500, savedApartament.Cost);
        }
    }
}