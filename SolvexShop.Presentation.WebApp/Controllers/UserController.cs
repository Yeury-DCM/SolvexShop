using AutoMapper;
using SolvexShop.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolvexShop.Core.Application.Dtos;
using SolvexShop.Core.Domain.Enums;
using SolvexShop.Core.Application.ViewModels.Users;
using SolvexShop.Core.Application.Dtos.User;

namespace InternetBanking.Web.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        IAccountService _accountService;
        IMapper _mapper;
        
        public UserController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
         
        }
        public async Task<IActionResult> Index()
        {
            var userDtos = await _accountService.GetAllUserDtosAsync();
            var userViewModels = _mapper.Map<List<UserViewModel>>(userDtos);
            return View(userViewModels);
        }


        public IActionResult Add()
        {
            ViewBag.UserTypes = Enum.GetValues<Roles>();

            return View("SaveUser", new SaveUserViewModel());
        }



        [HttpPost]
        public async Task<IActionResult> Add(SaveUserViewModel saveUserViewModel)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                ViewBag.UserTypes = Enum.GetValues<Roles>();

                return View("SaveUser", saveUserViewModel);
            }

            SaveUserRequest request = _mapper.Map<SaveUserRequest>(saveUserViewModel);
            SaveUserResponse response = await _accountService.CreateUser(request);

            if (!response.IsSucess)
            {
                saveUserViewModel.ErrorMessage = response.ErrorMessage;
                saveUserViewModel.IsSucess = false;
                ViewBag.UserTypes = Enum.GetValues<Roles>();

                return View("SaveUser", saveUserViewModel);
            }

           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ActivateUser(string id)
        {
            await _accountService.ActivateUser(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DesactivateUser(string id)
        {
            await _accountService.DeactivateUser(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.UserTypes = Enum.GetValues<Roles>();

            UserDto user = await _accountService.GetUserDtoByIdAsync(id);

            SaveUserViewModel saveUserViewModel = _mapper.Map<SaveUserViewModel>(user);

            return View("SaveUser", saveUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveUserViewModel saveUserViewModel)
        {
            if (string.IsNullOrEmpty(saveUserViewModel.Password) && string.IsNullOrEmpty(saveUserViewModel.ConfirmPassword))
            {
                ModelState.Remove("Password");
                ModelState.Remove("ConfirmPassword");
            }

        
            if (!ModelState.IsValid)
            {
                ViewBag.UserTypes = Enum.GetValues<Roles>();
                return View("SaveUser", saveUserViewModel);
            }

            var saveUserDto = _mapper.Map<SaveUserDto>(saveUserViewModel);

            await _accountService.UpdateUserAsync(saveUserDto);
        

            return RedirectToAction("Index");
        }


    }
}
