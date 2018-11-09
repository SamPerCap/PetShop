using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CompanyName.PetShop.RestApi.Data;
using CompanyName.PetShop.RestApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace CompanyName.PetShop.RestApi.Controllers
{
    [Route("/token")]
    //[Route("api/[controller]")]
    //[ApiController]

    public class TokenController : Controller
    {
        private readonly IOwnerRepository repository;

        public TokenController(IOwnerRepository repos)
        {
            repository = repos;
        }

        // POST api/token
        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var owner = repository.ReadOwners().FirstOrDefault(u => u.FirstName == model.Username);

            // check if username exists
            if (owner == null)
                return Unauthorized();

            // check if password is correct
            if (!VerifyPasswordHash(model.Password, owner.PasswordHash, owner.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = owner.FirstName,
                token = GenerateToken(owner)
            });
        }

        // This method verifies that the password entered by a user corresponds to the stored
        // password hash for this user. The method computes a Hash-based Message Authentication
        // Code (HMAC) using the SHA512 hash function. The inputs to the computation is the
        // password entered by the user and the stored password salt for this user. If the
        // computed hash value is identical to the stored password hash, the password entered
        // by the user is correct, and the method returns true.
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }

        // This method generates and returns a JWT token for a user.
        private string GenerateToken(Owner owner)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, owner.FirstName)
            };

            if (owner.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    JwtSecurityKey.Key,
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null, // issuer - not needed (ValidateIssuer = false)
                               null, // audience - not needed (ValidateAudience = false)
                               claims.ToArray(),
                               DateTime.Now,               // notBefore
                               DateTime.Now.AddMinutes(10)));  // expires

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}