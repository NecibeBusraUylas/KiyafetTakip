using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ClotheManager : IClotheService
    {
        IClotheDal _clotheDal;

        public ClotheManager(IClotheDal clotheDal)
        {
            _clotheDal = clotheDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IClotheService.Get")]
        [ValidationAspect(typeof(ClotheValidator))]
        public IResult Add(Clothe clothe)
        {
            _clotheDal.Add(clothe);
            return new SuccessResult(Messages.ClotheAdded);
        }

        [CacheRemoveAspect("IClotheService.Get")]
        [ValidationAspect(typeof(ClotheValidator))]
        public IResult Delete(Clothe clothe)
        {
            _clotheDal.Delete(clothe);
            return new SuccessResult(Messages.ClotheDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Clothe>> GetAll()
        {
            return new SuccessDataResult<List<Clothe>>(_clotheDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Clothe> GetById(int Id)
        {
            return new SuccessDataResult<Clothe>(_clotheDal.Get(p => p.Id == Id));
        }

        [CacheRemoveAspect("IClotheService.Get")]
        [ValidationAspect(typeof(ClotheValidator))]
        public IResult Update(Clothe clothe)
        {
            _clotheDal.Update(clothe);
            return new SuccessResult(Messages.ClotheUpdated);
        }
    }
}