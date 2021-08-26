using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Staff : IEntity
    {
        public int Id { get; set; }

        public Int64 EmployeeNumber { get; set; }

        public string NameSurname { get; set; }

        public string CardNumber { get; set; }

        public string Division { get; set; }

        public string Department { get; set; }

        public Boolean IsActive { get; set; }
    }
}