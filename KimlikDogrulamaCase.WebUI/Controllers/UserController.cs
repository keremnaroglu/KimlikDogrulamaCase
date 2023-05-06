using AutoMapper;
using KimlikDogrulamaCase.BLL.Abstract;
using KimlikDogrulamaCase.DTOs;
using KimlikDogrulamaCase.Entities;
using KimlikDogrulamaCase.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KimlikDogrulamaCase.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO userDTO)
        {
            var result = await _userService.Create(userDTO);
            if (result.Item1)
            {
                TempData["Message"] = result.Item2;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = result.Item2;
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            _userService.Delete(user);
            return View(user);
        }

    }
}
