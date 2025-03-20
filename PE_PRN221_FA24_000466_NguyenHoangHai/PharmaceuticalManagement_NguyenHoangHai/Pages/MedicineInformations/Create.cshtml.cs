using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PharmaceuticalManagement_BusinessObject;
using PharmaceuticalManagement_Repository.Interface;

namespace PharmaceuticalManagement_NguyenHoangHai.Pages.MedicineInformations
{
    public class CreateModel : PageModel
    {
        private readonly IMedicineInformationRepo _medicineInformationRepo;
        private readonly IManufacturerRepo _manufacturerRepo;

        public CreateModel(IMedicineInformationRepo medicineInformationRepo, IManufacturerRepo manufacturerRepo)
        {
            _medicineInformationRepo = medicineInformationRepo;
            _manufacturerRepo = manufacturerRepo;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["ManufacturerId"] = new SelectList(await _manufacturerRepo.GetList(), "ManufacturerId", "ManufacturerId");
            MedicineInformation = new MedicineInformation();
            
            return Page();
        }

        [BindProperty]
        public MedicineInformation MedicineInformation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _medicineInformationRepo.Add(MedicineInformation);
                TempData["Message"] = "Add successful!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToPage("/Error");
            }
        }
    }
}
