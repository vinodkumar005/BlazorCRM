using Blazor.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Shared.Lib.Dto;
using Shared.Lib.Helper;

namespace Blazor.Web.Components.Pages.Account
{
    public partial class Login : ComponentBase
    {
        #region [Service]        
        [Inject] IUserService UserService { get; set; } = default!;

        [Inject] NavigationManager NavigationManager { get; set; } = default!;

        [Inject] IDialogService DialogService { get; set; } = default!;
        #endregion

        #region [Variables]       

        public LoginDto loginModal { get; set; } = new();
        public string errorMessage = string.Empty;
        public bool loading = false;
        #endregion


        public async Task UserLogin()
        {
            try
            {
                loading = true;
                var loginResponse = await UserService.Login(loginModal);
                if (loginResponse.IsSuccess)
                {
                    string loginDetails = System.Text.Json.JsonSerializer.Serialize(loginResponse.Data);

                    string link = CommonService.EncryptText(loginDetails, "sblw-3hn8-sqoy19");
                    NavigationManager!.NavigateTo($"/identity/account/authentication?q={link}", true);
                }
                else
                {
                    await DialogService.ShowInfoAsync(loginResponse.Message);
                    loading = false;
                }
            }
            catch (Exception ex)
            {
                await DialogService.ShowErrorAsync(ex.Message);
                loading = false;
            }
        }
    }
}
