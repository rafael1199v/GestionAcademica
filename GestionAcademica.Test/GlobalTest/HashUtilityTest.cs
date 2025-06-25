using FakeItEasy;
using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.Repositories;
using GestionAcademica.API.Application.Interfaces.UseCases;
using GestionAcademica.API.Application.Interfaces.Utilities;
using GestionAcademica.API.Application.Utilities;
using GestionAcademica.API.Domain.Enums;

namespace GestionAcademica.Test.GlobalTest;

public class HashUtilityTest
{
    private readonly IHashUtility _hashUtility;
    public HashUtilityTest()
    {
        _hashUtility = A.Fake<IHashUtility>();
    }
    [Fact]
    public void CreateHash_SmallHashWorks()
    {
        // Arrange
        string input = "A";
        string expectedResult = "1c9ebd6caf02840a5b2b7f0fc870ec1db154886ae9fe621b822b14fd0bf513d6";
        A.CallTo(() => _hashUtility.CreateHash(input))
            .Returns(expectedResult);
        // Act
        var result = _hashUtility.CreateHash(input);
        // Assert
        Assert.Equal(expectedResult, result);
    }
    [Fact]
    public void CreateHash_BigHashWorks()
    {
        // Arrange
        string input = "The longest word in any of the major English language dictionaries is pneumonoultramicroscopicsilicovolcanoconiosis.";
        string expectedResult = "29eec57f0403f01ef50060f8c87fcb6dd4d874eb4b2fb007281820e6bf853742";
        A.CallTo(() => _hashUtility.CreateHash(input))
            .Returns(expectedResult);
        // Act
        var result = _hashUtility.CreateHash(input);
        // Assert
        Assert.Equal(expectedResult, result);
    }
    [Fact]
    public void CreateHash_WrongProcessing()
    {
        // Arrange
        string input = "Input";
        string expectedResult = "36ecb4f8669133ce744c21982ba4abe2ecd7086e1dc2226ccd6f266f3a5005f8"; //SHA-256, not SHA3-256
        A.CallTo(() => _hashUtility.CreateHash(input))
            .Returns("63cbe51fc247dce2cba955b6cd70d448a93cb0c2ea383e5cbd3e4c8e21b61f18");
        // Act
        var result = _hashUtility.CreateHash(input);
        // Assert
        Assert.NotEqual(expectedResult, result);
    }
}