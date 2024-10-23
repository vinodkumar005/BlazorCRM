﻿using Shared.Lib.Dto;

namespace Blazor.Web.Services
{
    public interface IMasterService
    {
        #region [Designation]
        Task<BaseApiResponseDto<List<DesignationResponseDto>>> GetDesignations();
        Task<BaseApiResponseDto<DesignationResponseDto>> GetDesignationById(int id);
        Task<BaseApiResponseDto<bool>> ManageDesignation(DesignationRequestDto model);
        Task<BaseApiResponseDto<bool>> DeleteDesignation(int id);
        #endregion

        #region[Country State City]
        Task<BaseApiResponseDto<List<SelectListDto>>> GetCountries();
        Task<BaseApiResponseDto<List<SelectListDto>>> GetStates(int countryId);
        Task<BaseApiResponseDto<List<SelectListDto>>> GetCities(int stateId);
        #endregion
    }
    public class MasterService : IMasterService
    {
        private IHttpService httpService;

        public MasterService(HttpClient _httpClient, IHttpService _httpService)
        {
            httpService = _httpService;
            httpService.Client = _httpClient;
        }

        #region [Designation]
        public async Task<BaseApiResponseDto<List<DesignationResponseDto>>> GetDesignations()
        {
            return await httpService.GetAsync<List<DesignationResponseDto>>($"Master/GetDesignations");
        }
        public async Task<BaseApiResponseDto<DesignationResponseDto>> GetDesignationById(int id)
        {
            return await httpService.GetAsync<DesignationResponseDto>($"Master/GetDesignationById?id={id}");
        }
        public async Task<BaseApiResponseDto<bool>> ManageDesignation(DesignationRequestDto model)
        {
            return await httpService.PostAsync<bool>("Master/ManageDesignation", model);
        }

        public async Task<BaseApiResponseDto<bool>> DeleteDesignation(int id)
        {
            return await httpService.DeleteAsync<bool>($"Master/DeleteDesignation", id);
        }
        #endregion

        #region[Country State City]
        public async Task<BaseApiResponseDto<List<SelectListDto>>> GetCountries()
        {
            return await httpService.GetAsync<List<SelectListDto>>($"Master/GetCountries");
        }

        public async Task<BaseApiResponseDto<List<SelectListDto>>> GetStates(int countryId)
        {
            return await httpService.GetAsync<List<SelectListDto>>($"Master/GetStates?countryId={countryId}");
        }

        public async Task<BaseApiResponseDto<List<SelectListDto>>> GetCities(int stateId)
        {
            return await httpService.GetAsync<List<SelectListDto>>($"Master/GetCities?stateId={stateId}");
        }
        #endregion
    }
}
