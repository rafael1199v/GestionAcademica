using GestionAcademica.API.Application.Abstractions;
using SHA3.Net;
using System.Text;

namespace GestionAcademica.API.Application
{
    public class HashUseCase : IHashUseCase
    {
        public string CreateHash(string plaintext)
        {
            //TODO: añadir función Salting

            var hash = Sha3.Sha3256().ComputeHash(Encoding.ASCII.GetBytes(plaintext));
            return Convert.ToHexString(hash);
        }
    }
}

