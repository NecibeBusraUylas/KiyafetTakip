using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IClotheService
    {
        IDataResult<List<Clothe>> GetAll();
        IDataResult<Clothe> GetById(int Id);
        IResult Add(Clothe clothe);
        IResult Update(Clothe clothe);
        IResult Delete(Clothe clothe);
    }
}