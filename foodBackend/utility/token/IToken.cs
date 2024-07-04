using foodBackend.models;

namespace foodBackend.utility.token
{
    public interface IToken
    {
        public string GenerateToken(UserModel user);
    }
}
