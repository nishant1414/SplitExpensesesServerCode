using Microsoft.AspNetCore.Http;
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
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        public AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        [Route("login")]
        public Participant Login(SignInModel signInModel)
        {
            var result = _authService.Login(signInModel);
            return result;
        }

        [HttpPost]
        [Route("signUp")]
        public Participant SignUp(SignUpModel signUpModel)
        {
            var result = _authService.SignUp(signUpModel);
            return result;
        }
    }
}
