using BankBranchesIndividualMiniProject.Models;
using BankBranchesIndividualMiniProject.Models.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankBranchesIndividualMiniProject.Controllers
{
    public class BankController : Controller
    {
        private readonly BankContext _context;

        public BankController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new BankDashboardViewModel();
            viewModel.BranchList = _context.BankBranches.ToList();
            viewModel.TotalBranches = _context.BankBranches.Count();
            viewModel.BranchWithMostEmployees = _context.BankBranches.OrderByDescending(r => r.Employees.Count).FirstOrDefault();
            return View(viewModel);
        }

        public IActionResult ShowBranchesList()
        {
            var branches = _context.BankBranches.ToList();
            return View(branches);
        }

        public IActionResult BranchesDetails(int id)
        {
            var branch = _context.BankBranches.FirstOrDefault(b => b.BranchId == id);
            if (branch == null)
            {
                return NotFound();
            }
            return View(branch);
        }

        [HttpGet]
        public IActionResult NewBranchForm()
        {
            return View("AddNewBranch");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewBranchForm(NewBranchForm bankBranch)
        {
            if (ModelState.IsValid)
            {
                _context.BankBranches.Add(new BankBranch
                {
                    Name = bankBranch.Name,
                    BranchManager = bankBranch.BranchManager,
                    Location = bankBranch.Location,
                    EmployeeCount = bankBranch.EmployeeCount
                });
                _context.SaveChanges();
                return RedirectToAction("ShowBranchesList");
            }
            return View(bankBranch);
        }

        [HttpPatch("{id}")]
        public IActionResult EditBranch(int id, NewBranchForm edit)
        {
            var bank = _context.BankBranches.Find(id);
            bank.Name = edit.Name;
            bank.BranchManager = edit.BranchManager;
            bank.Location = edit.Location;
            _context.SaveChanges();
            return RedirectToAction("BranchesDetails", new { id = bank.BranchId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBranch(EditBranch form)
        {
            if (ModelState.IsValid)
            {
                var edit = new EditBranch { Name = form.Name, BranchManager = form.BranchManager, EmployeeCount = form.EmployeeCount };
                var branch = _context.BankBranches.FirstOrDefault(e => e.BranchId == form.BranchId);
                _context.Update(branch);
                _context.SaveChanges();
                return RedirectToAction("BranchesDetails", new { id = form.BranchId });
            }
            return View(form);
        }

        public IActionResult Employees()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult EmployeesDetails(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult AddEmployee(int branchId)
        {
            return View(new AddEmployeeForm { BranchId = branchId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee(AddEmployeeForm form)
        {
            if (ModelState.IsValid)
            {
                var newEmp = new Employee { Name = form.Name, CivilId = form.CivilId, Position = form.Position };
                var branch = _context.BankBranches.Include(v => v.Employees).FirstOrDefault(e => e.BranchId == form.BranchId);
                branch.Employees.Add(newEmp);
                _context.SaveChanges();
                return RedirectToAction("BranchesDetails", new { id = form.BranchId });
            }
            return View(form);
        }

        public IActionResult ChangeLanguage(string language)
        {
            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
return View(language);
        }
    }
}