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
    public class DeleteModel : PageModel
    {
        private readonly IMedicineInformationRepo _medicineInformationRepo;

        public DeleteModel(IMedicineInformationRepo medicineInformationRepo)
        {
            _medicineInformationRepo = medicineInformationRepo;
        }

        [BindProperty]
        public MedicineInformation MedicineInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineinformation = await _medicineInformationRepo.GetById(id);

            if (medicineinformation == null)
            {
                return NotFound();
            }
            else
            {
                MedicineInformation = medicineinformation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _medicineInformationRepo.Delete(id);
            TempData["Message"] = "Delete successful!";

            return RedirectToPage("./Index");
        }
    }
}
