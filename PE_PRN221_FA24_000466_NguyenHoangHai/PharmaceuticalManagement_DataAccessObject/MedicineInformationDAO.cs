using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalManagement_DataAccessObject
{
    public class MedicineInformationDAO
    {
        private static MedicineInformationDAO instance = null;
        private readonly Sp25PharmaceuticalDbContext _context;

        private MedicineInformationDAO()
        {
            _context = new Sp25PharmaceuticalDbContext();
        }

        public static MedicineInformationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicineInformationDAO();
                }
                return instance;
            }
        }

        public async Task<List<MedicineInformation>> GetListGoldBracelets()
        {
            return await _context.MedicineInformations.Include(x => x.Manufacturer).ToListAsync();
        }

        public class MedicineInformationsResponse
        {
            public List<MedicineInformation> MedicineInformations { get; set; }
            public int TotalPages { get; set; }
            public int PageIndex { get; set; }
        }

        public async Task<MedicineInformationsResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            var query = _context.MedicineInformations.Include(x => x.Manufacturer).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                try
                {
                    var tempId = int.Parse(searchTerm);
                    //query = query.Where(x => x.ProductionYear == tempId);

                }
                catch (Exception e)
                {
                    //query = query.Where(x => x.BraceletName.ToLower().Contains(searchTerm.ToLower()));
                }
            }

            int count = await query.CountAsync();
            int totalPage = (int)Math.Ceiling(count / (double)pageSize);

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new MedicineInformationsResponse
            {
                MedicineInformations = await query.OrderBy(x => x.MedicineId).ToListAsync(),
                TotalPages = totalPage,
                PageIndex = pageIndex,
            };
        }

        public async Task<MedicineInformation> GetMedicineInformationsById(string id)
        {
            return await _context.MedicineInformations.Include(x => x.Manufacturer).FirstOrDefaultAsync(m => m.MedicineId.Equals(id));
        }

        public async Task AddMedicineInformation(MedicineInformation medicineInformation)
        {
            try
            {
                var isExisting = await GetMedicineInformationsById(medicineInformation.MedicineId);
                if (isExisting != null)
                {
                    throw new Exception("It is already existed");
                }
                _context.MedicineInformations.Add(medicineInformation);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateMedicineInformation(MedicineInformation medicineInformation)
        {
            try
            {
                var isExist = await GetMedicineInformationsById(medicineInformation.MedicineId);
                if (isExist == null)
                {
                    throw new Exception("Does not exist");
                }

                isExist.MedicineName = medicineInformation.MedicineName;
                isExist.ActiveIngredients = medicineInformation.ActiveIngredients;
                isExist.ExpirationDate = medicineInformation.ExpirationDate;
                isExist.DosageForm = medicineInformation.DosageForm;
                isExist.WarningsAndPrecautions = medicineInformation.WarningsAndPrecautions;
                isExist.ManufacturerId = medicineInformation.ManufacturerId;

                var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(ty => ty.ManufacturerId == medicineInformation.ManufacturerId);
                if (manufacturer == null)
                {
                    throw new Exception("Manufacturer does not exist");
                }
                isExist.Manufacturer = manufacturer;

                _context.MedicineInformations.Update(isExist);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteMedicineInformation(string id)
        {
            try
            {
                var existMedicineInformation = _context.MedicineInformations.FirstOrDefault(x => x.MedicineId.Equals(id));
                if (existMedicineInformation == null)
                {
                    throw new Exception("Medicine not found");
                }
                _context.MedicineInformations.Remove(existMedicineInformation);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Manufacturer>> GetManufacturers()
        {
            return await _context.Manufacturers.ToListAsync();
        }
    }
}
