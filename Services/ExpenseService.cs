using SplitExpenses.Entities;
using SplitExpenses.Models;
using SplitExpenses.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitExpenses.Services
{
    public class ExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GroupService _groupService;
        private readonly ParticipantService _participantService;
        public ExpenseService(IUnitOfWork unitOfWork, GroupService groupService, ParticipantService participantService)
        {
            _unitOfWork = unitOfWork;
            _groupService = groupService;
            _participantService = participantService;
        }

        public List<Expense> GetAllExpense()
        {
            return _unitOfWork.Repository<Expense>().GetAll().ToList();
        }

        public Expense GetExpenseById(int id)
        {
            return _unitOfWork.Repository<Expense>().GetById(id);
        }

        public List<Expense> GetExpenseByGroup(int groupId)
        {
            return _unitOfWork.Repository<Expense>().FindBy(x => x.GroupId == groupId).ToList();
        }

        public void CreateExpense(Expense expense)
        {
            _unitOfWork.Repository<Expense>().Insert(expense);
            _unitOfWork.Commit();
        }

        public void CreateExpenseAndTransaction(ExpenseModel expenseModel)
        {
            var paidParticipant = _unitOfWork.Repository<Participant>().FindBy(p => p.Id == expenseModel.PaidParticipantId).FirstOrDefault();
            var group = _groupService.GetGroupById(expenseModel.GroupId);
            if (paidParticipant == null)
                throw new Exception("participant can not add expenses");
            else
            {
                var expense = new Expense();
                expense.Item = expenseModel.Item;
                expense.Amount = expenseModel.Amount;
                expense.GroupId = expenseModel.GroupId;
                expense.ExtraInfo = expenseModel.Date.ToString();
                expense.InvolveParticipants = expenseModel.ExpenseParticipants.Count();
                expense.PaidParticipantId = expenseModel.PaidParticipantId;
                expense.WhoPaid = paidParticipant.Name;
                expense.Remarks = expenseModel.Remarks;
                _unitOfWork.Repository<Expense>().Insert(expense);
                _unitOfWork.Commit();
                expenseModel.ExpenseParticipants.ForEach(p =>
                {
                    var participant = _unitOfWork.Repository<Participant>().FindBy(a => a.Id == p).FirstOrDefault();
                    var transaction = new Transaction();
                    transaction.PaidParticipantId = paidParticipant.Id;
                    transaction.PaidParticipantName = paidParticipant.Name;
                    transaction.TotalAmount = expenseModel.Amount;
                    transaction.Amount = expenseModel.Amount/ expenseModel.ExpenseParticipants.Count();
                    transaction.ExpenseId = expense.Id;
                    transaction.GroupId = expenseModel.GroupId;
                    transaction.ParticipantId = p;
                    transaction.GroupName = group.Name;
                    transaction.ParticipantName = participant.Name;
                    transaction.IsActive = true;
                    _unitOfWork.Repository<Transaction>().Insert(transaction);
                    _unitOfWork.Commit();



                });

            }
            
        }

        public List<Expense> getAllExpenseByParticipantEmail(string email)
        {
            var participant = _unitOfWork.Repository<Participant>().FindBy(p => p.EmailId == email).FirstOrDefault();
            if (participant == null)
                throw new Exception($"No Paticipant found by this email {email}");
            var transactions = _unitOfWork.Repository<Transaction>().FindBy(t => t.ParticipantId == participant.Id).ToList();
            if (transactions.Count() == 0)
                throw new Exception($"No Transaction found by email {email}");
            var expenseIds = transactions.Select(s => s.ExpenseId).Distinct().ToList();
            var expenses = _unitOfWork.Repository<Expense>().FindBy(e => expenseIds.Contains(e.Id)).ToList();
            return expenses;
        }

        public List<Expense> getAllExpenseByParticipantId(int participantId)
        {
            var participant = _unitOfWork.Repository<Participant>().FindBy(p => p.Id == participantId).FirstOrDefault();
            if (participant == null)
                throw new Exception($"No Paticipant found by this participantId {participantId}");
            var expenses = _unitOfWork.Repository<Expense>().FindBy(e => e.PaidParticipantId == participantId).ToList();
            return expenses;
        }

        public List<SplitExpensecs> SplitGroupExpenses(int groupId)
        {
            var data = new List<SplitExpensecs>(); 
            var group = _groupService.GetGroupById(groupId);
            if (group == null)
                throw new Exception("group not found");
            var participants = _participantService.GetParticipantsByGroup(groupId);
            if (participants.Count() == 0)
                throw new Exception("No participant found");
            var expenses = GetExpenseByGroup(groupId);
            if (expenses.Count() == 0)
                throw new Exception("no expenses added yet");
            var expenseIds = expenses.Select(s => s.Id).ToList();
            var transactions = _unitOfWork.Repository<Transaction>().FindBy(t => expenseIds.Contains(t.Id) && t.GroupId == groupId).ToList();
            if (transactions.Count() == 0)
                throw new Exception("No transactions found");
            var groupExpenses = transactions.GroupBy(g => new
            {
                g.PaidParticipantName,
                g.ParticipantName
            }).ToList();
            groupExpenses.ForEach(g => {
                var model = new SplitExpensecs();
                model.WhoPaid = g.Key.PaidParticipantName;
                model.TotalAmount = g.Sum(e => e.TotalAmount);
                model.AmountToBePaid = g.Sum(e => e.Amount);
                model.GroupName = g.FirstOrDefault().GroupName;
                model.GroupId = groupId;
                model.ForWHom = g.Key.ParticipantName;
                data.Add(model);
            
            });
            return data;

        }

    }
}
