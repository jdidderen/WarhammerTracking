using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WarhammerTracking.Data
{
    public class UserDataAccessProvider
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UserDataAccessProvider(ILoggerFactory loggerFactory,ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logger Army Data Access");
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<ApplicationUser> GetUser(string id)
        {
            return Task.FromResult(_context.ApplicationUsers.First(a => a.Id == id));
        }

        public Task<ApplicationUser[]> ListUser()
        {
            return Task.FromResult(_context.ApplicationUsers.ToArray());
        }
        
        public Task<bool> AddUser(ApplicationUser user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> UpdateUser(ApplicationUser user)
        {
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> DeleteUser(string id)
        {
            try
            {
                ApplicationUser deleteUser = _context.Users.Find(id);
                _context.Users.Remove(deleteUser);
                _context.SaveChanges();
            }
            catch
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
            
        }

        public Task<ApplicationUser> GetCurrentUser()
        {
            var username = _httpContextAccessor.HttpContext?.User.Identity.Name; 
            return Task.FromResult(_context.ApplicationUsers.First(u => u.UserName == username));
        }
    }
}