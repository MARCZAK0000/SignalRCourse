using Microsoft.AspNetCore.Identity;
using SignalRCourse.Database;
using SignalRCourse.Helper;
using SignalRCourse.Model;

namespace SignalRCourse.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _userManager;
        private readonly IPasswordHasher<Account> _passwordHasher;

        public AccountRepository(DatabaseContext databaseContext, 
            IPasswordHasher<Account> passwordHasher,
            SignInManager<Account> signInManager,
            UserManager<Account> userManager)
        {
            _databaseContext = databaseContext;
            _passwordHasher = passwordHasher;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> RegisterAccount(RegisterAccountDto register)
        {
            await using var transaction = await _databaseContext.Database.BeginTransactionAsync();
            try
            {
                var newUser = new Account()
                {
                    UserName = register.Login,
                    Email = register.Email,
                    PhoneNumber = register.PhoneNumber,
                    User = new User()
                    {
                        Name = register.Name,
                        Email = register.Email,
                        PhoneNumber = register.PhoneNumber,
                        Surname = register.Surname,
                    }
                };
                newUser.PasswordHash = _passwordHasher.HashPassword(newUser, register.Password);
                newUser.User.AccountID = newUser.Id;
                await _userManager.CreateAsync(newUser);
                await _databaseContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Dispose();
                return false;
            }

        }

        public async Task<bool> LoginAccount(LoginAccountDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Login)??
                throw new Exception("NotFound");

            //var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, login.Password);
            //if(verifyPassword == PasswordVerificationResult.Failed)
            //{
            //    throw new Exception("Wrong password or username");
            //}

            var verifyPassword = await _signInManager.CheckPasswordSignInAsync(user, login.Password, lockoutOnFailure: false);
            if (!verifyPassword.Succeeded)
            {
                throw new Exception("Invalid UserName or Password");
            }
            await _signInManager.SignInAsync(user, false);

            return true;
        }

        public async Task<bool> SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            return true;
        }
    }
}
