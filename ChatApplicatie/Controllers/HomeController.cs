using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChatApplicatie.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChatApplicatie.Models;


namespace ChatApplicatie.Controllers
{
    public class HomeController : Controller
    {


        private readonly ChatMessageApi _chatMessageApi;

        public HomeController(ChatMessageApi chatMessageApi)
        {
            _chatMessageApi = chatMessageApi;
        }

        public async Task<IActionResult> Index()
        {
            var channels = await _chatMessageApi.FindAsyncChannels();
            return View(channels);
        }

        public async Task<IActionResult> CreateChannel(string channel)
        {
            await _chatMessageApi.CreateChannel(channel);
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
