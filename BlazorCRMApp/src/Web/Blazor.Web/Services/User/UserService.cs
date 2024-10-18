using Shared.Lib.Dto;

namespace Blazor.Web.Services
{
    public interface IUserService
    {
        #region [User]
        Task<BaseApiResponseDto<bool>> Signup(UsersDto model);
        #endregion
    }
    public class UserService: IUserService
    {
        private IHttpService httpService;

        public UserService(HttpClient _httpClient, IHttpService _httpService)
        {
            httpService = _httpService;
            httpService.Client = _httpClient;
        }

        public async Task<BaseApiResponseDto<bool>> Signup(UsersDto model)
        {
            return await httpService.PostAsync<bool>("Account/Signup", model);
        }
    }
}
