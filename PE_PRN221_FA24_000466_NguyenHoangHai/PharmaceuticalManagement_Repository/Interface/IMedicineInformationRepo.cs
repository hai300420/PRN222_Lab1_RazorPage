using PharmaceuticalManagement_BusinessObject;
using PharmaceuticalManagement_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalManagement_Repository.Interface
{
    public interface IMedicineInformationRepo
    {
        Task Add(MedicineInformation medicineInformation);
        Task Delete(string id);
        Task<MedicineInformation> GetById(string id);
        Task<MedicineInformationDAO.MedicineInformationsResponse> GetList(string searchTerm, int pageIndex, int pageSize);
        Task Update(MedicineInformation medicineInformation);
    }
}
