using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaceuticalManagement_BusinessObject;
using PharmaceuticalManagement_DataAccessObject;
using PharmaceuticalManagement_Repository.Interface;

namespace PharmaceuticalManagement_Repository
{
    public class ManufacturerRepo : IManufacturerRepo
    {
        public async Task<List<Manufacturer>> GetList()
        {
            return await MedicineInformationDAO.Instance.GetManufacturers();
        }
    }
}
