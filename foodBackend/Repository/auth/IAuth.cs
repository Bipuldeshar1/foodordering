using foodBackend.Dtos.auth;
using foodBackend.models;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Repository.auth
{
    public interface IAuth
    {
        public Task<IActionResult> Register( RegisterModel model);
        public Task<IActionResult> login( LoginModel model);
        public  Task<IActionResult> Logout();
        public IEnumerable<UserModel> get();
    
    }
}
