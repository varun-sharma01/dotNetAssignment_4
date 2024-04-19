using rpgAPI.Model;
using rpgAPI.Service;

namespace rpgAPI.Tests.Services;

public class CharacterServiceTest
{
    [Fact]

    public void GetAllCharacter_GivenValidRequest_GiveResult()
    {
        //Arrange

        var cs = new CharacterService();

        //Act

        var result = cs.GetAllCharacter();

        //Assert

        Assert.NotNull(result);
    }

    [Fact]
    public void AddCharacter_WhenCalled_AddsCharacterToList()
    {
        //Arrange
        var character = new Character()
        {
            Name = "Varun",
            Id = 2
        };

        var cs = new CharacterService();

        //Act

        var result = cs.AddCharacter(character);

        //Assert

        Assert.NotNull(result);
        Assert.NotNull(result.Data.FirstOrDefault(x=>x.Id==2));
    }

    [Fact]
        public void GetCharacterById_ExistingId_ReturnsCharacter()
        {
            // Arrange
            var id = 1;
            var service = new CharacterService();

            // Act
            var result = service.GetCharacterById(id);

            // Assert
            Assert.True(result.Success);
        }

    [Fact]
    public void GetCharacterById_NonExistingId_ReturnsErrorMessage()
    {
        // Arrange
        var id = 3;
        var service = new CharacterService();

        // Act
        var result = service.GetCharacterById(id);

        // Assert
        Assert.False(result.Success);
        Assert.Equal("Id Doesn't Exist", result.Message);
    }
}

