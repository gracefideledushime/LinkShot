using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShot.Services
{
    public class AuthService
    {
        public bool IsAuthenticated { get; private set; }

        public async Task<bool> LoginAsync(string username, string password)
        {
            await Task.Delay(1000);

            // Mock authentication
            if (username == "stud3nt" && password == "p@ssw08d")
            {
                IsAuthenticated = true;
                return true;
            }

            return false;
        }

        public void Logout()
        {
            IsAuthenticated = false;
        }
    }
}
