using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Busines;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        //[SecuredOperation("admin",Priority =1)]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run(MaintenceTime(22)
                );
            if (result!=null)
            {
                return result;
            }
                _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
            
        }

        //[SecuredOperation("admin", Priority = 1)]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color color)
        {
            IResult result = BusinessRules.Run(MaintenceTime(18)
               );
            if (result != null)
            {
                return result;
            }
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        [CacheAspect]
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        //[SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        //Busines Rule(s)
        private IResult MaintenceTime(int maintanceTime) 
        {
            if (DateTime.Now.Hour==maintanceTime)
            {
                return new ErrorResult(Messages.SystemMaintanceTime);
            }
            return new SuccessResult();
        }
    }
}
