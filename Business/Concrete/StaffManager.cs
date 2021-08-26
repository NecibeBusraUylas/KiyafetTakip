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

        [CacheRemoveAspect("IStaffService.Get")]
        [ValidationAspect(typeof(StaffValidator))]
        public IResult Add(Staff staff)
        {
            _staffDal.Add(staff);
            return new SuccessResult(Messages.StaffAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IStaffService.Get")]
        [ValidationAspect(typeof(StaffValidator))]
        public IResult Delete(Staff staff)
        {
            _staffDal.Delete(staff);
            return new SuccessResult(Messages.StaffDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Staff>> GetAll()
        {
            return new SuccessDataResult<List<Staff>>(_staffDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Staff> GetById(int Id)
        {
            return new SuccessDataResult<Staff>(_staffDal.Get(p => p.Id == Id));
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IStaffService.Get")]
        [ValidationAspect(typeof(StaffValidator))]
        public IResult Update(Staff staff)
        {
            _staffDal.Update(staff);
            return new SuccessResult(Messages.StaffUpdated);
        }

        [CacheAspect]
        public IDataResult<Staff> GetByNameSurname(string nameSurname)
        {
            return new SuccessDataResult<Staff>(_staffDal.Get(p => p.NameSurname== nameSurname));
        }
    }
}