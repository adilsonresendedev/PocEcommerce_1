﻿namespace PocEcommerce_1.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
