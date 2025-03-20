using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement_BusinessObject;
using PharmaceuticalManagement_Repository.Interface;

namespace PharmaceuticalManagement_NguyenHoangHai.Pages.MedicineInformations
{
    public class IndexModel : PageModel
    {
        private readonly IMedicineInformationRepo _medicineInformationRepo;

        public IndexModel(IMedicineInformationRepo medicineInformationRepo)
        {
            _medicineInformationRepo = medicineInformationRepo;
        }

        public IList<MedicineInformation> MedicineInformation { get;set; } = default!;

        //search
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }

        //paging https://localhost:7112/MedicineInformations?pageIndex=1
        public int PageIndex { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 2;

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var result = await _medicineInformationRepo.GetList(searchTerm, pageIndex, 3);

            MedicineInformation = result.MedicineInformations;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
        }
    }
}
