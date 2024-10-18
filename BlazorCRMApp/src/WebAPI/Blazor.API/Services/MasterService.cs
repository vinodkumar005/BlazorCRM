using Blazor.API.Data.Entities;
using Blazor.API.Data;

namespace Blazor.API.Services
{
    public interface IMasterService
    {
        List<DesignationMaster> GetDesignations();
        DesignationMaster? GetDesignationById(int id);
        void AddUpdate(DesignationMaster CategoryModal);
        bool DeleteDesignationById(int id);
    }
    public class MasterService : IMasterService
    {
        private readonly ApplicationDbContext _DBContext;

        public MasterService(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        public List<DesignationMaster> GetDesignations()
        {
            try
            {
                return _DBContext.DesignationMaster.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DesignationMaster? GetDesignationById(int id)
        {
            try
            {
                return _DBContext.DesignationMaster.FirstOrDefault(m => m.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddUpdate(DesignationMaster designationModal)
        {
            try
            {
                var designation = _DBContext.DesignationMaster.FirstOrDefault(m => m.Id == designationModal.Id);
                if (designation != null)
                {
                    designation.Name = designationModal.Name;
                    designation.IsActive = designationModal.IsActive;
                    designation.ModifiedDate = DateTime.Now;
                    _DBContext.DesignationMaster.Update(designation);
                }
                else
                {
                    designationModal.CreatedDate = DateTime.Now;
                    designationModal.ModifiedDate = DateTime.Now;
                    _DBContext.DesignationMaster.Add(designationModal);
                }
                _DBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteDesignationById(int id)
        {
            try
            {
                var designation = _DBContext.DesignationMaster.FirstOrDefault(m => m.Id == id);
                if (designation != null)
                {
                    _DBContext.DesignationMaster.Remove(designation);
                    _DBContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
