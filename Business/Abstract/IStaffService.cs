using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IStaffService
    {
        IDataResult<List<Staff>> GetAll();
        IDataResult<Staff> GetById(int Id);
        IDataResult<Staff> GetByNameSurname(string nameSurname);
        IResult Add(Staff Staff);
        IResult Update(Staff Staff);
        IResult Delete(Staff Staff);
    }
}