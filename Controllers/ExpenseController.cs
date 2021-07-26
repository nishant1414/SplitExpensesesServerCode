using Microsoft.AspNetCore.Mvc;
using SplitExpenses.Entities;
using SplitExpenses.Models;
using SplitExpenses.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitExpenses.Controllers
{
    [ApiController]
    [Route("api/expense")]
    public class ExpenseController : Controller
    {
        private ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }



        [Route("expenses")]
        [HttpGet]
        public ActionResult<List<Expense>> GetAllExpense()
        {
            return _expenseService.GetAllExpense();
        }

        [Route("id/{id}")]
        [HttpGet]
        public ActionResult<Expense> GetExpenseById(int id)
        {
            return _expenseService.GetExpenseById(id);
        }

        [Route("")]
        [HttpPost]
        public ActionResult CreateExpense(Expense expense)
        {
            _expenseService.CreateExpense(expense);
            return Ok();
        }

        [Route("addExpense")]
        [HttpPost]
        public ActionResult CreateExpenseAndTransaction(ExpenseModel expenseModel)
        {
            _expenseService.CreateExpenseAndTransaction(expenseModel);
            return Ok();
        }



        [HttpGet]
        [Route("groupId/{groupId}")]
        public List<Expense> GetExpensesByGroup(int groupId)
        {
            return _expenseService.GetExpenseByGroup(groupId);
        }

        //get expenses by emailId
        [Route("participant/email")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<Expense>> GetExpensesByParticipantEmail(string email)
        {
            try
            {
                var expenses = _expenseService.getAllExpenseByParticipantEmail(email);
                return expenses;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }

        }

        //get expenses by participantId
        [Route("participant/{participantId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<Expense>> GetExpensesByParticipantId(int participantId)
        {
            try
            {
                var expenses = _expenseService.getAllExpenseByParticipantId(participantId);
                return expenses;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }

        }

        // divide group expenses
        [Route("group/groupId")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<SplitExpensecs>> SplitGroupExpenses(int groupId)
        {
           var data =  _expenseService.SplitGroupExpenses(groupId);
            return data;
        }
    }

}
