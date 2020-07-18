using System;
using System.Threading.Tasks;
using PracticeAppAPI.Models;

namespace PracticeAppAPI.Data
{
    public interface IAuthRepository
    {
        Task<User> Login(string username, string password);

        Task<User> Register(User user, string password);

        Task<bool> UserExists(string username);
    }
}