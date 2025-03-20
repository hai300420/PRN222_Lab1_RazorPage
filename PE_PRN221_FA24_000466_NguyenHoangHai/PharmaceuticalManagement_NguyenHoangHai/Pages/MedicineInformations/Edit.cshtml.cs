using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement_BusinessObject;
using PharmaceuticalManagement_Repository.Interface;

namespace PharmaceuticalManagement_NguyenHoangHai.Pages.MedicineInformations
{
    public class EditModel : PageModel
    {
        private readonly IMedicineInformationRepo _medicineInformationRepo;
        private readonly IManufacturerRepo _manufacturerRepo;

        public EditModel(IMedicineInformationRepo medicineInformationRepo, IManufacturerRepo manufacturerRepo)
        {
            _medicineInformationRepo = medicineInformationRepo;
            _manufacturerRepo = manufacturerRepo;
        }

        [BindProperty]
        public MedicineInformation MedicineInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineinformation =  await _medicineInformationRepo.GetById(id);
            if (medicineinformation == null)
            {
                return NotFound();
            }
            MedicineInformation = medicineinformation;
            ViewData["ManufacturerId"] = new SelectList(await _manufacturerRepo.GetList(), "ManufacturerId", "ManufacturerId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _medicineInformationRepo.Update(MedicineInformation);
                TempData["Message"] = "Update successful!";
                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = e.Message;
                return RedirectToPage("/Error");
            }

            return RedirectToPage("./Index");
        }
    }
}
