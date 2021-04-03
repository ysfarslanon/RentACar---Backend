using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
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
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCard)
        {
            _creditCardDal = creditCard;
        }

        //[SecuredOperation("admin",Priority =1)]
        [CacheRemoveAspect("ICreditCardService.Get")]
        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
        }
        //[SecuredOperation("admin",Priority =1)]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(cc => cc.Id == id));
        }
        [CacheAspect]
        public IDataResult<List<CreditCard>> GetByNumber(string number)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(cc => cc.Number == number));
        }

        public IResult IsExist(CreditCard creditCard)
        {
            var result = _creditCardDal.Get(cc => cc.FullName == creditCard.FullName && cc.Number == creditCard.Number && cc.CVV == creditCard.CVV);
            if (result==null)
            {
                return new ErrorResult(Messages.CreditCardNotExist);
            }
            return new SuccessResult();
        }
        //[SecuredOperation("admin",Priority =1)]
        [CacheRemoveAspect("ICreditCardService.Get")]
        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }
    }
}
