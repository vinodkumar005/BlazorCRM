using Blazor.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Lib.Dto;
using System.Reflection;

namespace Blazor.Web.Components.Pages.Admin.Account
{
    public partial class Signup : ComponentBase
    {
        [Inject] IUserService UserService { get; set; }
        private UsersDto registrationModel = new();

        protected override void OnInitialized()
        {
            registrationModel.FormType = true;
            registrationModel.DesignationId = 4;
            base.OnInitialized();
        }

        public async Task HandleValidSubmit()
        {
            
            var response = await UserService.Signup(registrationModel);
            if (response.IsSuccess)
            {

            }
            // Handle form submission
        }

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            // Handle file input change
        }
    }
}
