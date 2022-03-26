using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.Constants;
using OkulOtomasyon.Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using OkulOtomasyon.Core.CrossCuttingConcerns.Security.Jwt;
using OkulOtomasyon.Entities.Concrete;
using OkulOtomasyon.Entities.Dtos;
using AccessToken = OkulOtomasyon.Core.Utilities.Security.Jwt.AccessToken;

namespace OkulOtomasyon.Business.Concrete.Managers
{
    public class AuthManager : IAuthService
    {
        private IUsersService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUsersService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(User userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            Core.CrossCuttingConcerns.Security.Hashing.HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                EMail = userForRegisterDto.EMail,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Message.UserRegistered);
        }


        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash,
                userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Message.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Message.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Message.UserAlreadyExists);
            }

            return new SuccessResult();
        }


        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Message.AccessTokenCreated);
        }
    }
}
