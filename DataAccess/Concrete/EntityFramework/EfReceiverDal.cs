using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfReceiverDal : EfEntityRepositoryBase<Receiver, UtaritContext>, IReceiverDal
    {
    }
}