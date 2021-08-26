using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForRegisterDto : IDto
    {
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}