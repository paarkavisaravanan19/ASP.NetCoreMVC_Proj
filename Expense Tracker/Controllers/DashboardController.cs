﻿using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {

            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            //last 7 days transactions
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;
            List<Transaction> SelectedTransactions = await _context.Transactions.Include(x=>x.Category)
                .Where(y=>y.Date>= StartDate && y.Date <= EndDate).ToListAsync();

            //Total Income
            int TotalIncome = SelectedTransactions.Where(i => i.Category.Type == "Income")
                .Sum(j => j.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("₹0");

            //Total Income
            int TotalExpense = SelectedTransactions.Where(i => i.Category.Type == "Expense")
                .Sum(j => j.Amount);
            ViewBag.TotalIncome = TotalExpense.ToString("₹0");

            //Balance Amount
            int Balance = TotalIncome - TotalExpense;
            ViewBag.Balance = Balance.ToString("₹0");


            return View();
        }
    }
}
