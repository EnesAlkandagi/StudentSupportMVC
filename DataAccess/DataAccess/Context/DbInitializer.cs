using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataAccess.Context
{
    public class DbInitializer
    {
        public static byte[] CreatePasswordHash(string password)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }


        public static void Initialize(PostgresqlContext context)
        {
            var hmac = new System.Security.Cryptography.HMACSHA512();


            if (!context.OperationClaims.Any())
            {
                var rols = new OperationClaim[]
             {
                new OperationClaim
                {
                    Id=1,
                    Name = "User"
                },
                new OperationClaim
                {
                    Id=2,
                    Name = "Admin"
                },
             };

                foreach (OperationClaim r in rols)
                {
                    context.OperationClaims.Add(r);
                }
                context.SaveChanges();
            }




            if (!context.Users.Any())
            {
                var users = new User[]
                {
                    new User
                    {
                        FirstName = "Enes",
                        LastName = "Alkandağı",
                        Email="enes.alkandagi@gmail.com",
                        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123456")),
                        PasswordSalt = hmac.Key,
                        Iban="5464654654",
                        Type = Core.Entities.EnmUserType.Ogrenci
                        
                    }
                };
                foreach (User u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();
            }

            if (!context.UserOperationClaims.Any())
            {
                var userOperationClaims = new UserOperationClaim[]
          {
                new UserOperationClaim
                {

                    UserId = 1,
                    OperationClaimId = 1
                },

          };

                foreach (UserOperationClaim kr in userOperationClaims)
                {
                    context.UserOperationClaims.Add(kr);
                }
                context.SaveChanges();
            }

        }
    }
}
