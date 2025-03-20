using PharmaceuticalManagement_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalManagement_Repository.Interface
{
    public interface IManufacturerRepo
    {
        Task<List<Manufacturer>> GetList();
    }
}
