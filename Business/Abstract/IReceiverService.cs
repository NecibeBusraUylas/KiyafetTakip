using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IReceiverService
    {
        IDataResult<List<Receiver>> GetAll();
        IDataResult<Receiver> GetById(int Id);
        IDataResult<Receiver> GetByNameSurname(string nameSurname);
        IDataResult<Receiver> GetByCardNumber(string cardNumber);
        IDataResult<Receiver> GetByClothe(string clothe);
        IResult Add(Receiver receiver);
        IResult Update(Receiver receiver);
        IResult Delete(Receiver receiver);
    }
}
