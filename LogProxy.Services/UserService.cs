using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogProxy.Models;
using LogProxy.Models.Extensions;

namespace LogProxy.Services
{
    public class UserService : IUserService
    {
        private IList<User> _users = new List<User>
        {
            new User { Id = 1, Username = "test", Password = "12345" }
        };

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            if (user == null)
                return null;

            return user.WithoutPassword();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _users.WithoutPasswords());
        }
    }
}
