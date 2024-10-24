using Blazor.Web.Resources;
using Blazor.Web.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Shared.Lib.Dto;

namespace Blazor.Web.Components.Pages.Admin.Master.Shared
{
    public partial class DesignationForm : ComponentBase
    {
        #region [Inject Service]
        [Inject] IMasterService MasterService { get; set; }
        [Inject] CustomNotificationService CustomNotification { get; set; } = default!;
        [Inject] DialogService DialogService { get; set; } = default!;
        #endregion
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
                designationModal.Colour = editDesignation.Colour;
                designationModal.IsActive = editDesignation.IsActive;
            }
            else
            {
                designationModal.Colour = "#000000";
            }
            base.OnInitialized();
        }

        public async void Save()
        {
            try
            {
                var result = await DialogService.Confirm(
                   designationModal.Id > 0 ? Resource.DESIGNATION_UPDATE_CONFIRM_MESSGAE : Resource.DESIGNATION_ADD_CONFIRM_MESSGAE,
                   designationModal.Id > 0 ? Resource.DESIGNATION_UPDATE_CONFIRM_TITLE : Resource.DESIGNATION_ADD_CONFIRM_TITLE
                    );

                if (result.HasValue && result.Value) // User clicked "Yes"
                {
                    var response = await MasterService.ManageDesignation(designationModal);
                    if (response.IsSuccess)
                    {

                        CustomNotification.ShowNotification(NotificationSeverity.Success,
                        designationModal.Id > 0 ? Resource.DESIGNATION_UPDATE_SUCCESS_MESSAGE : Resource.DESIGNATION_ADD_SUCCESS_MESSAGE
                        );
                        await OnSave.InvokeAsync();
                    }
                    else
                        CustomNotification.ShowNotification(NotificationSeverity.Error, response.Message);
                }
            }
            catch (Exception ex)
            {
                CustomNotification.ShowNotification(NotificationSeverity.Error, ex.Message);
            }
        }

        public async void CancelForm()
        {
            try
            {
                await OnCancel.InvokeAsync();
            }
            catch (Exception ex)
            {
                CustomNotification.ShowNotification(NotificationSeverity.Error, ex.Message);
            }
        }
    }
}
