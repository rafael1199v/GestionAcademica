namespace GestionAcademica.Test;

public class ExampleTest
{
    //Usar este tipo de plantilla para las pruebas
    //Usamos "FakeItEasy" para los mocks
    [Fact]
    public void UseCaseToTest_Function_ExpectedResultOrResponse()
    {
        //Arrange: Configurar el test
        var expectedResult = true;
        
        //Act: El test en sí
        var result = expectedResult;

        //Assert: Verificar que ambas respuestas sean correctas
        Assert.Equal(expectedResult, result);
    }
}