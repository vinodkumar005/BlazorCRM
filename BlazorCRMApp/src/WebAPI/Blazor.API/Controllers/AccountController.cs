using AutoMapper;
using Blazor.API.Data.Entities;
using Blazor.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Lib.Dto;
using Shared.Lib.Enums;
using Shared.Lib.Resources;
using static Azure.Core.HttpHeader;
using System.Linq;
using Blazor.API.Infrastructure;

namespace Blazor.API.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : BaseController
    {
        private readonly IUserLoginService _userLoginService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AccountController(IUserLoginService userLoginService, IUserService userService, IMapper mapper)
        {
            _userLoginService = userLoginService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Signup([FromBody] UsersDto model)
        {

            if (model.FormType)
            {
                if (model.DesignationId == null)
                {
                    ModelState.Remove("DesignationId");
                }
                if (model.ParentId == null)
                {
                    ModelState.Remove("ParentId");
                }
            }
            if (model.Id > 0)
            {
                ModelState.Remove("Password");
            }

            try
            {
                bool isExist = model.Id != 0;

                bool isUserNameExist = _userLoginService.IsUserNameExist(model.Email, model.UserLoginId);
                bool isEmailExist = _userService.IsEmailExist(model.Email, model.Id);

                if (isUserNameExist && isEmailExist)
                {
                    return BadRequest(isUserNameExist ? "User name already exist" : "Email already exist");
                }

                var userLogin = new UserLogin();
                var user = new Users();
                if (isExist)
                {
                    userLogin = _userLoginService.GetUserById(model.UserLoginId);
                    user = _userService.GetUserById(model.Id);
                }

                //string profilePic = "";
                //if (model.ProfilePic != null)
                //{
                //    if (model.ProfilePic.Length > 0)
                //    {
                //        var profileExten = new[] { ".jpg", ".png", ".jpeg" };
                //        var ext = Path.GetExtension(model.ProfilePic.FileName).ToLower();

                //        if (!profileExten.Contains(ext))
                //        {
                //            ModelState.AddModelError("", $"Profile image not valid, Please choose jpg,png,jpeg format");
                //            return CreateModelStateErrors();
                //        }
                //        else
                //        {
                //            profilePic = await this.UploadFiles(env, model.ProfilePic, "", "UserProfilePic", "");
                //        }
                //    }
                //}

                if (model.Id == 0)
                {
                    string salt = PasswordHasher.GenerateSalt();
                    userLogin.Password = PasswordHasher.GeneratePassword(model.Password, salt);
                    userLogin.PasswordSalt = salt;
                }
                userLogin.RoleType = (int)UserRoleType.User;
                userLogin.IsVerified = model.IsActive;
                userLogin.IsActive = model.IsVerified;
                userLogin.Username = model.Email;

                var result = isExist ? _userLoginService.UpdateUserLogin(userLogin) : _userLoginService.SaveUserLogin(userLogin);

                user.UserLoginId = result;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Mobile = model.Mobile;
                user.Dob = model.Dob;
                user.ShortUrl = model.ShortUrl;
                user.TimeZoneId = model.TimeZoneId;
                user.StateId = model.StateId;
                user.City = model.City;
                user.Address = model.Address;
                user.ZipCode = model.ZipCode;
                //user.ProfilePic = !string.IsNullOrEmpty(profilePic) ? profilePic : user.ProfilePic;
                user.DesignationId = model.DesignationId == 0 ? null : model.DesignationId;
                user.ParentId = model.ParentId == Guid.Empty ? null : model.ParentId;

                var result2 = isExist ? _userService.UpdateUsers(user) : _userService.SaveUsers(user);
                if (model.Id == 0)
                {
                    return SuccessResult("SignUpThanks");
                }
                return BadRequest(BaseResponseMessages.EXCEPTION);
            }
            catch (Exception exception)
            {
                return ExceptionErrorResult(BaseResponseMessages.EXCEPTION, exception);
            }

        }
    }
}
