using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Clothe : IEntity
    {
        public int Id { get; set; }

        public string Type { get; set; }
    }
}