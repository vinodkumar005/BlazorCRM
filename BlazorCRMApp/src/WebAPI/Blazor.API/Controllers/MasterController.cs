using AutoMapper;
using Blazor.API.Data.Entities;
using Blazor.API.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Lib.Dto;
using Shared.Lib.Resources;

namespace Blazor.API.Controllers
{
    [Route("[controller]/[action]")]
    public class MasterController : BaseController
    {
        private readonly IMasterService _masterService;
        private readonly IMapper _mapper;
        public MasterController(IMasterService masterService, IMapper mapper)
        {
            _masterService = masterService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDesignations()
        {
            try
            {
                List<DesignationResponseDto> responseModel = new List<DesignationResponseDto>();

                var result = _masterService.GetDesignations();
                responseModel = _mapper.Map<List<DesignationResponseDto>>(result);

                return SuccessResult(responseModel);
            }
            catch (Exception exception)
            {
                return ExceptionErrorResult(BaseResponseMessages.EXCEPTION, exception);
            }
        }

        [HttpGet]
        public IActionResult GetDesignationById(int id)
        {
            try
            {
                DesignationResponseDto responseModel = new DesignationResponseDto();

                var result = _masterService.GetDesignationById(id);
                responseModel = _mapper.Map<DesignationResponseDto>(result);

                return SuccessResult(responseModel);
            }
            catch (Exception exception)
            {
                return ExceptionErrorResult(BaseResponseMessages.EXCEPTION, exception);
            }
        }

        [HttpPost]
        public IActionResult ManageDesignation([FromBody] DesignationRequestDto model)
        {
            try
            {
                var category = _mapper.Map<DesignationMaster>(model);
                _masterService.AddUpdate(category);

                return SuccessResult(true);
            }
            catch (Exception exception)
            {
                return ExceptionErrorResult(BaseResponseMessages.EXCEPTION, exception);
            }
        }

        [HttpDelete]
        public IActionResult DeleteDesignation([FromBody] int id)
        {
            try
            {
                _masterService.DeleteDesignationById(id);
                return SuccessResult(true);
            }
            catch (Exception exception)
            {
                return ExceptionErrorResult(BaseResponseMessages.EXCEPTION, exception);
            }
        }
    }
}
