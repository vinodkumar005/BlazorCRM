using Blazor.Web.Services;
using Microsoft.AspNetCore.Components;
using Shared.Lib.Dto;

namespace Blazor.Web.Components.Pages.Account
{
    public partial class Signup : ComponentBase
    {
        #region [Service]
        [Inject] IMasterService MasterService { get; set; } = default!;
        [Inject] IUserService UserService { get; set; } = default!;
        #endregion

        #region [Variables]
        public List<SelectListDto> countries = new List<SelectListDto>();
        public List<SelectListDto> states = new List<SelectListDto>();
        public List<SelectListDto> cities = new List<SelectListDto>();
        public List<SelectListDto> timeZones = new List<SelectListDto>();
        public List<SelectListItemtDto> designations = new List<SelectListItemtDto>();
        public List<SelectListItemtDto> parentList = new List<SelectListItemtDto>();

        public UsersDto model = new UsersDto();
        #endregion

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                model.FirstName = "Vinod";
                model.LastName = "Kumar";
                model.Dob = DateTime.Now.AddYears(-24);
                model.Email = "vinod005@yopmail.com";
                model.Mobile = "7014922886";
                model.Password = "Dots@123";
                model.Address = "jagatpura";
                model.ZipCode = "302017";
                model.CountryId = 101;
                model.StateId = 1657;
                model.CityId = 18849;


                model.FormType = true;
                var countryResponse = await MasterService.GetCountries();
                if (countryResponse.IsSuccess)
                {
                    countries = countryResponse.Data!;
                    StateHasChanged();
                }
            }
        }

        public async Task GetState(ChangeEventArgs e)
        {
            states = new List<SelectListDto>();
            var countryId = Convert.ToInt16(e.Value);

            if (countryId > 0)
            {
                model.CountryId = countryId;
                var countryResponse = await MasterService.GetStates(countryId);
                if (countryResponse.IsSuccess)
                {
                    states = countryResponse.Data!;
                    StateHasChanged();
                }
            }
        }


        public async Task GetCities(ChangeEventArgs e)
        {
            cities = new List<SelectListDto>();
            var stateId = Convert.ToInt16(e.Value);

            if (stateId > 0)
            {
                model.StateId = stateId;
                var countryResponse = await MasterService.GetCities(stateId);
                if (countryResponse.IsSuccess)
                {
                    cities = countryResponse.Data!;
                    StateHasChanged();
                }
            }
        }

        public async Task SignUp()
        {
            var signupResponse= await UserService.Signup(model);
            if(signupResponse.IsSuccess)
            {

            }
        }
    }
}
