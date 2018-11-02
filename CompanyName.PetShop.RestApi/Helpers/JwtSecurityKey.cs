using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyName.PetShop.RestApi.Helpers
{
    public static class JwtSecurityKey
    {
        private static byte[] secretsBytes = Encoding.UTF8.GetBytes("A secret for HmacSha256");

        public static SymmetricSecurityKey Key
        {
            get { return new SymmetricSecurityKey(secretsBytes); }
        }

        public static void SetSecret(string secret)
        {
            secretsBytes = Encoding.UTF8.GetBytes(secret);
        }
    }
}
