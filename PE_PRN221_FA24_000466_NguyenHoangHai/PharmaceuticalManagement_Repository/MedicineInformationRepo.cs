using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaceuticalManagement_BusinessObject;
using PharmaceuticalManagement_DataAccessObject;
using PharmaceuticalManagement_Repository.Interface;
using static PharmaceuticalManagement_DataAccessObject.MedicineInformationDAO;

namespace PharmaceuticalManagement_Repository
{
    public class MedicineInformationRepo : IMedicineInformationRepo
    {
        public async Task<MedicineInformationsResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            return await MedicineInformationDAO.Instance.GetList(searchTerm, pageIndex, pageSize);
        }
        public async Task<MedicineInformation> GetById(string id)
        {
            return await MedicineInformationDAO.Instance.GetMedicineInformationsById(id);
        }
        public async Task Add(MedicineInformation medicineInformation)
        {
            await MedicineInformationDAO.Instance.AddMedicineInformation(medicineInformation);
            return;
        }
        public async Task Update(MedicineInformation medicineInformation)
        {
            await MedicineInformationDAO.Instance.UpdateMedicineInformation(medicineInformation);
            return;
        }
        public async Task Delete(string id)
        {
            await MedicineInformationDAO.Instance.DeleteMedicineInformation(id);
        }
    }
}
