using Blazor.Web.Components.Shared;
using Blazor.Web.Resources;
using Blazor.Web.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Shared.Lib.Dto;
using Shared.Lib.Enums;

namespace Blazor.Web.Components.Pages.Admin.Master
{
    public partial class Designation : ComponentBase
    {
        #region [Inject Service]
        [Inject] IMasterService MasterService { get; set; } = default!;
        [Inject] CustomNotificationService CustomNotification { get; set; } = default!;

        [Inject] DialogService DialogService { get; set; } = default!;
        #endregion

        #region [Variables]
        public List<DesignationResponseDto> designations = new List<DesignationResponseDto>();
        public DesignationResponseDto? selectDesignation = null;
        public bool process = false;
        public bool showForm = false;
        private string? _searchText = string.Empty;
        public ConfirmationPopup confirmationPopup;
        private DataListingResponseModel _listing = new();
        public int _orderColumn, _orderDirection, _pageSize = 10;
        #endregion
        protected override async Task OnInitializedAsync()
        {
            await GetDesignation();
        }

        public async Task GetDesignation(bool hasLoader = true)
        {
            try
            {
                process = true;
                var request = new ListingFilterDto
                {
                    PageIndex = _listing.PageNumber > 0 ? _listing.PageNumber : 1,
                    PageSize = _pageSize,
                    OrderColumn = _orderColumn,
                    OrderDirection = _orderDirection
                };

                if (!string.IsNullOrWhiteSpace(_searchText))
                    request.Search = _searchText;

                var result = await MasterService.GetDesignations(request);
                if (result.HasDataAvailable())
                {
                    var data = result.Data!;
                    _listing.FilterRecords = data.Items.Count();
                    _listing.HasNext = data.HasNext;
                    _listing.HasPrevious = data.HasPrevious;
                    _listing.TotalRecords = data.TotalCount;
                    _listing.FilterRecords = _listing.FilterRecords == _pageSize ? _listing.PageNumber * _listing.FilterRecords : (_listing.PageNumber - 1) * _pageSize + _listing.FilterRecords;
                    designations = data.Items;
                }
            }
            catch (Exception ex)
            {
                CustomNotification.ShowNotification(NotificationSeverity.Error, ex.Message);
            }
            finally
            {
                process = false;
                StateHasChanged();
            }
        }

        private async void ChangePageIndex(bool hasNext)
        {
            try
            {
                var maxPageNumber = _listing.TotalRecords / _pageSize;
                maxPageNumber = _listing.TotalRecords % _pageSize == 0 ? maxPageNumber : ++maxPageNumber;
                _listing.PageNumber = hasNext ? (_listing.HasNext ? _listing.PageNumber + 1 : _listing.PageNumber) : (_listing.HasPrevious ? _listing.PageNumber - 1 : _listing.PageNumber);
                if (_listing.PageNumber > maxPageNumber)
                    _listing.PageNumber -= 1;
                else if (_listing.PageNumber == 0)
                    _listing.PageNumber = 1;
                else if (_listing.PageNumber <= maxPageNumber && _listing.PageNumber > 0)
                    await GetDesignation(false);
            }
            catch { }
        }

        public async void UpdatePageSize(ChangeEventArgs e)
        {
            _pageSize = Convert.ToInt32(e.Value);
            await GetDesignation();
        }

        public async Task OnSort(Sorting sort, int column)
        {
            _orderColumn = (int)column;
            _orderDirection = (int)sort;
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
            var result = await DialogService.Confirm(Resource.DESIGNATION_DELETE_CONFIRM_TITLE, Resource.DESIGNATION_DELETE_CONFIRM_MESSAGE);
            if (result.HasValue && result.Value) // User clicked "Yes"
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

        public async void UpdateStatus(DesignationResponseDto designation)
        {
            try
            {
                var result = await DialogService.Confirm(Resource.DESIGNATION_STATUS_CAHNGE_MESSAGE, Resource.DESIGNATION_STATUS_CAHNGE_TITLE);

                if (result.HasValue && result.Value) // User clicked "Yes"
                {
                    var response = await MasterService.UpdateDesignationStatus(designation.Id, !designation.IsActive);
                    if (response.IsSuccess)
                    {
                        CustomNotification.ShowNotification(NotificationSeverity.Success,
                            designation.IsActive ? Resource.DESIGNATION_DEACTIVE_STATUS_MESSAGE.Replace("##DESIGNATION_NAME##", designation.Name) :
                             Resource.DESIGNATION_ACTIVE_STATUS_MESSAGE.Replace("##DESIGNATION_NAME##", designation.Name)
                            );
                        await GetDesignation();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomNotification.ShowNotification(NotificationSeverity.Error, ex.Message);
            }
        }
    }
}
