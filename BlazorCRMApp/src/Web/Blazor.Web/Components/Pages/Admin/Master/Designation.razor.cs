using Blazor.Web.Components.Shared;
using Blazor.Web.Services;
using Microsoft.AspNetCore.Components;
using Shared.Lib.Dto;
using System;
using System.Diagnostics;

namespace Blazor.Web.Components.Pages.Admin.Master
{
    public partial class Designation : ComponentBase
    {
        [Inject] IMasterService MasterService { get; set; }

        public List<DesignationResponseDto> designations = new List<DesignationResponseDto>();
        public DesignationResponseDto? selectDesignation = null;
        public bool process = false;
        public bool showForm = false;

        public ConfirmationPopup confirmationPopup;

        protected override async Task OnInitializedAsync()
        {
            await GetDesignation();
        }

        public void ShowCreateForm()
        {
            showForm = true;
        }

        public void CancelForm()
        {
            showForm = false;
        }

        public async Task OnFormSave()
        {
            showForm = false;
            await GetDesignation();
        }

        private async Task DeleteDesignation(int id, bool confirm)
        {
            if (!confirm)
            {
                confirmationPopup.Configure("Delete Designation", "Are you sure you want to delete this designation", "Yes").OnSubmit(async () => await DeleteDesignation(id, true)).Show();
            }
            else
            {
                var response = await MasterService.DeleteDesignation(id);
                if (response.IsSuccess)
                    await GetDesignation();
            }
        }


        public void EditDesignation(DesignationResponseDto designation)
        {
            selectDesignation = designation;
            showForm = true;
        }

        public async Task GetDesignation()
        {
            try
            {
                process = true;
                StateHasChanged();
                var response = await MasterService.GetDesignations();
                if (response.IsSuccess)
                {
                    designations = response.Data;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                process = false;
                StateHasChanged();
            }

        }
    }
}
