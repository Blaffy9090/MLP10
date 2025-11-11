using Microsoft.EntityFrameworkCore;
using MLP10.Data;
using Xunit;

namespace MLP10.Tests.Data;

public class ApartamentTests
{
    [Fact]
    public void Apartament_CanBeCreated_WithValidProperties()
    {
        // Arrange & Act
        var apartament = new Apartament
        {
            ApartamentNumber = 101,
            ApartamentType = "Standard",
            Cost = 1500
        };

        // Assert
        Assert.Equal(101, apartament.ApartamentNumber);
        Assert.Equal("Standard", apartament.ApartamentType);
        Assert.Equal(1500, apartament.Cost);
    }

    [Fact]
    public void Apartament_PropertiesCanBeNull()
    {
        // Arrange & Act
        var apartament = new Apartament();

        // Assert
        Assert.Null(apartament.ApartamentNumber);
        Assert.Null(apartament.ApartamentType);
        Assert.Null(apartament.Cost);
    }
}