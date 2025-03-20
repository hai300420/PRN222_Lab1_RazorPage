using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalManagement_DataAccessObject
{
    public class StoreAccountDAO
    {
        private static StoreAccountDAO instance = null;
        private readonly Sp25PharmaceuticalDbContext _context;

        private StoreAccountDAO()
        {
            _context = new Sp25PharmaceuticalDbContext();
        }

        public static StoreAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new StoreAccountDAO();
                }
                return instance;
            }
        }

        public async Task<StoreAccount> Login(string email, string password)
        {
            return await _context.StoreAccounts.FirstOrDefaultAsync(acc => acc.EmailAddress == email && acc.StoreAccountPassword == password);
        }


    }
}
