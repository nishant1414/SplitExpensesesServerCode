using SplitExpenses.Entities;
using SplitExpenses.Models;
using SplitExpenses.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitExpenses.Services
{
    public class AuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ParticipantService _participantService;
        public AuthService(IUnitOfWork unitOfWork, ParticipantService participantService)
        {
            _unitOfWork = unitOfWork;
            _participantService = participantService;
        }

        public Participant Login(SignInModel loginModel)
        {
            if (loginModel.UserName == null || loginModel.UserName.Length == 0)
                throw new Exception("Invalid UserName");
            if (loginModel.Password == null || loginModel.Password.Length == 0)
                throw new Exception("Incorrect Password");
            var existingUser = _participantService.GetParticipantByUserNameAndPassword(loginModel.UserName,loginModel.Password);
            if (existingUser == null)
                throw new Exception("No user found with this user name");
            return existingUser;

        }

        public Participant SignUp(SignUpModel signUpModel)
        {
            if (signUpModel.Name == null || signUpModel.Name.Length == 0)
                throw new Exception("please enter the name");
            if (signUpModel.Password == null || signUpModel.Password.Length == 0)
                throw new Exception("please enter the password Password");
            if (signUpModel.Mobile.ToString().Length != 10)
                throw new Exception("please enter the valid number");
            if (signUpModel.Email == null || signUpModel.Email.Length == 0)
                throw new Exception("please enter the email");
            if (signUpModel.Address == null || signUpModel.Address.Length == 0)
                throw new Exception("please enter the address");
            var existingParticipantByUserName = _participantService.GetParticipantBYUserNameOrEmailId(signUpModel.UserName);
            if (existingParticipantByUserName != null)
                throw new Exception("this username is already registered please choose another one");
            var existingParticipantByEmail = _participantService.GetParticipantBYUserNameOrEmailId(signUpModel.Email);
            if (existingParticipantByEmail != null)
                throw new Exception("this email is already registered please login intstead of signup");
            var existingParticipantByMobile = _participantService.GetParticipantByMobile(signUpModel.Mobile);
            if (existingParticipantByMobile != null)
                throw new Exception("this mobile number is already registered please either try to login or signup with another one");
            var participant = new Participant();
            participant.Mobile = signUpModel.Mobile;
            participant.EmailId = signUpModel.Email;
            participant.Name = signUpModel.Name;
            participant.ExtraInfo1 = signUpModel.UserName;
            participant.ExtraInfo2 = signUpModel.Password;
            participant.ExtraInfo3 = signUpModel.Address;
            _unitOfWork.Repository<Participant>().Insert(participant);
            _unitOfWork.Commit();
            return participant;




        }

    }
}
