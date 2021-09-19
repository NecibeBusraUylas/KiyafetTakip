using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ReceiverManager : IReceiverService
    {
        IReceiverDal _receiverDal;

        public ReceiverManager(IReceiverDal receiverDal)
        {
            _receiverDal = receiverDal;
        }

        [ValidationAspect(typeof(ReceiverValidator))]
        public IResult Add(Receiver receiver)
        {
            var receiverExist = _receiverDal.Get(p => p.Id == receiver.Id);
            if (receiverExist==null)
            {
                _receiverDal.Add(receiver);
                return new SuccessResult(Messages.ReceiverAdded);
            }
            return new ErrorResult("Personele kıyafet teslim edilmiş. Başka kıyafet verilemez.");
        }

        [ValidationAspect(typeof(ReceiverValidator))]
        public IResult Delete(Receiver receiver)
        {
            _receiverDal.Delete(receiver);
            return new SuccessResult(Messages.ReceiverDeleted);
        }

        public IDataResult<List<Receiver>> GetAll()
        {
            return new SuccessDataResult<List<Receiver>>(_receiverDal.GetAll());
        }

        public IDataResult<Receiver> GetById(int Id)
        {
            return new SuccessDataResult<Receiver>(_receiverDal.Get(r => r.Id == Id));
        }

        public IDataResult<Receiver> GetByNameSurname(string nameSurname)
        {

            return new SuccessDataResult<Receiver>(_receiverDal.Get(p => p.NameSurname == nameSurname));
        }

        public IDataResult<Receiver> GetByCardNumber(string cardNumber)
        {

            return new SuccessDataResult<Receiver>(_receiverDal.Get(p => p.CardNumber== cardNumber));
        }

        public IDataResult<Receiver> GetByClothe(string clothe)
        {

            return new SuccessDataResult<Receiver>(_receiverDal.Get(p => p.Clothe == clothe));
        }

        [ValidationAspect(typeof(ReceiverValidator))]
        public IResult Update(Receiver receiver)
        {
            _receiverDal.Update(receiver);
            return new SuccessResult(Messages.ReceiverUpdated);
        }
    }
}
