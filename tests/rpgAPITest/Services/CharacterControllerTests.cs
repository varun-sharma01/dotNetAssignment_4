using Moq;
using rpgAPI.Controller;
using rpgAPI.Model;
using rpgAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoFixture;

namespace rpgAPI.Tests
{
    public class CharacterControllerTests
    {
        #region Property
        public Mock<ICharacterService> mockService =  new Mock<ICharacterService>();
        #endregion

        [Fact]
        public void GetAllCharacter_ReturnsOkResult_WithAllCharacters()
        {
            //Arrange
            var characterList = new List<Character>()
            {
                new Character(),
                new Character(){Name = "Varun", Id=2}
            };

            var serviceResponse = new ServiceResponse<List<Character>>()
            {
                Data = characterList
            };

            mockService.Setup(x=>x.GetAllCharacter()).Returns(serviceResponse);
            var charController = new CharacterController(mockService.Object);

            //Act
            var result = charController.GetCharacter();
            var okResult = (ObjectResult)result.Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);

        }

        [Fact]

        public void GetCharacterById_ReturnsOkResult_WithCharacterAtThatId(){
            //Arrange

            var fixture = new Fixture();
            var serviceResponse = fixture.Create<ServiceResponse<Character>>();

            mockService.Setup(x=>x.GetCharacterById(0)).Returns(serviceResponse);

            var charController = new CharacterController(mockService.Object);

            //Act

            var result = charController.GetId(serviceResponse.Data.Id);

            //Assert

            Assert.NotNull(result);

        }

    }
}