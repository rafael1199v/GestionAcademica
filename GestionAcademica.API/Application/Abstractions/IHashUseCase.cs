namespace GestionAcademica.API.Application.Abstractions
{
    public interface IHashUseCase
    {
        public string CreateHash(string plaintext);
    }
}
