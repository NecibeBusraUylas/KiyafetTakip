using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class StaffManager : IStaffService 
    { 
        IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        [ValidationAspect(typeof(StaffValidator))]
        public IResult Add(Staff staff)
        {
            _staffDal.Add(staff);
            return new SuccessResult(Messages.StaffAdded);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(StaffValidator))]
        public IResult Delete(Staff staff)
        {
            _staffDal.Delete(staff);
            return new SuccessResult(Messages.StaffDeleted);
        }

        public IDataResult<List<Staff>> GetAll()
        {
            return new SuccessDataResult<List<Staff>>(_staffDal.GetAll());
        }

        public IDataResult<Staff> GetById(int Id)
        {
            return new SuccessDataResult<Staff>(_staffDal.Get(p => p.Id == Id));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(StaffValidator))]
        public IResult Update(Staff staff)
        {
            _staffDal.Update(staff);
            return new SuccessResult(Messages.StaffUpdated);
        }

        public IDataResult<Staff> GetByNameSurname(string nameSurname)
        {
            return new SuccessDataResult<Staff>(_staffDal.Get(p => p.NameSurname== nameSurname));
        }

        public IDataResult<Staff> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<Staff>(_staffDal.Get(p => p.CardNumber == cardNumber));
        }
    }
}
