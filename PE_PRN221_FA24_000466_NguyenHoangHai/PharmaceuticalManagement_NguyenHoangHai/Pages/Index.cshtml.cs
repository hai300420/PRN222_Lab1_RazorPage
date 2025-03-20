
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmaceuticalManagement_Repository.Interface;

namespace PharmaceuticalManagement_NguyenHoangHai.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IStoreAccountRepo _accountRepo;

        public IndexModel(ILogger<IndexModel> logger, IStoreAccountRepo accountRepo)
        {
            _logger = logger;
            _accountRepo = accountRepo;
        }

        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var account = await _accountRepo.Login(email, password);
                if (account != null && (account.Role == 3 || account.Role == 2))
                {
                    TempData["Message"] = "Login Success";

                    // set session
                    HttpContext.Session.SetString("Email", email);
                    HttpContext.Session.SetInt32("RoleId", account.Role ?? default(int));

                    return RedirectToPage("/MedicineInformations/Index");
                }
                else
                {
                    TempData["Message"] = "You do not have permission to do this function";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Page();
            }
        }

    }
}
