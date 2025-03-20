using PharmaceuticalManagement_BusinessObject;
using PharmaceuticalManagement_DataAccessObject;
using PharmaceuticalManagement_Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalManagement_Repository
{
    public class StoreAccountRepo : IStoreAccountRepo
    {
        public async Task<StoreAccount> Login(string email, string password)
        {
            return await StoreAccountDAO.Instance.Login(email, password);
        }
    }
}
