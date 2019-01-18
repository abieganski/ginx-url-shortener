using System;
using HashidsNet;

namespace ginx.me.Services
{
    public class HashIdsHashGenerator : IHashGenerator
    {
        public UniqueIdWithSalt GetNext() {

            var salt = CreateSalt();
            var input = new Random().Next(Int32.MaxValue);

            var hashids = new Hashids(salt, 3);
            var encoded = hashids.Encode(input);

            return new UniqueIdWithSalt { UniqueId = encoded, Salt = salt };
        }

        private string CreateSalt()
        {
            var random = new Random();
            byte[] salt = new byte[16];
            random.NextBytes(salt);
            return Convert.ToBase64String(salt);
        }
    }
}