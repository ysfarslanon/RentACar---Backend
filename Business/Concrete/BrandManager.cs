using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    //todo Her metot 5 sn den fazla işlem süresi olunca Debugdan uyarı gösterecektir.
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("admin", Priority = 1)]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            //ekleme kuralları buraya eklenecek
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactional(Brand brand)
        {
            throw new NotImplementedException();
        }

        [SecuredOperation("admin",Priority =1)]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<List<Brand>> GetAll()
        {
            // Thread.Sleep(7500);
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Brand> GetById(int id)
        {          
          return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id), Messages.BrandListed);           

        }
        [SecuredOperation("admin", Priority = 1)]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            if (brand.Name.Length > 0)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            return new ErrorResult(Messages.SystemFailed);
        }



    }
}
