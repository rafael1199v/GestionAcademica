namespace GestionAcademica.Test;

public class ExampleTest
{
    //Usar este tipo de plantilla para las pruebas
    //Usamos "FakeItEasy" para los mocks
    [Fact]
    public void UseCaseToTest_Function_ExpectedResultOrResponse()
    {
        //Arrange
        var expectedResult = true;
        
        //Act
        var result = expectedResult;

        //Assert
        Assert.Equal(expectedResult, result);
    }
}