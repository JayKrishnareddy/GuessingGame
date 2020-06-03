using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GuessingGame.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
       
        [BindProperty(Name = "Box")]
        public int? Box { get; set; }
        public bool Winner { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            var surprise = RandomNumberGenerator.GetInt32(1, 10);
            Winner = surprise == Box;

            _logger
                .LogInformation($"User selected Box #{Box}." +
                    $" User is a {(Winner ? "winner" : "loser")}");
        }
    }
}
