﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages.classes
{
    public class Editform
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
