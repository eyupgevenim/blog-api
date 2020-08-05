using Blog.Core.Domain.Users;

namespace Blog.Services.Users
{
    /// <summary>
    /// Sign in manager service
    /// </summary>
    public interface ISignInManager
    {
        /// <summary>
        /// Sign in with user name and password
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        bool SignIn(string userName, string password);

        /// <summary>
        /// Create user password
        /// </summary>
        /// <param name="user">user entity</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        User CreatePassword(User user, string password);
    }
}
