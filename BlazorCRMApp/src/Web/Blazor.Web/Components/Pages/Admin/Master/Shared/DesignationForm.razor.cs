using Blazor.Web.Services;
using Microsoft.AspNetCore.Components;
using Shared.Lib.Dto;

namespace Blazor.Web.Components.Pages.Admin.Master.Shared
{
    public partial class DesignationForm : ComponentBase
    {

        [Inject] IMasterService MasterService { get; set; }

        [Parameter] public EventCallback OnSave { get; set; }

        [Parameter] public EventCallback OnCancel { get; set; }

        [Parameter]
        public DesignationResponseDto? editDesignation { get; set; }


        public DesignationRequestDto designationModal = new DesignationRequestDto();

        protected override void OnInitialized()
        {
            if (editDesignation != null)
            {
                designationModal.Id = editDesignation.Id;
                designationModal.Name = editDesignation.Name;
                designationModal.IsActive = editDesignation.IsActive;
            }
            base.OnInitialized();
        }

        public async void Save()
        {
            try
            {
                var response = await MasterService.ManageDesignation(designationModal);
                if (response.IsSuccess)
                {
                    await OnSave.InvokeAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void CancelForm()
        {
            try
            {
                await OnCancel.InvokeAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
