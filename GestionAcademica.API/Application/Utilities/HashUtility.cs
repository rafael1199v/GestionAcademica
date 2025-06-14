using System.Text;
using GestionAcademica.API.Application.Interfaces.Utilities;
using SHA3.Net;

namespace GestionAcademica.API.Application.Utilities
{
    public class HashUtility : IHashUtility
    {
        public string CreateHash(string plaintext)
        {
            var hash = Sha3.Sha3256().ComputeHash(Encoding.ASCII.GetBytes(plaintext));
            return Convert.ToHexString(hash);
        }
    }
}

