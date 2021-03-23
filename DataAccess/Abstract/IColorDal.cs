using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IColorDal:IEntityRepository<Color>
    {
        //Sen IEntityRepositoryi Color için yapılandıracaksın  
        //IEntityRepository de temel crud operasyonları vardır.
        //Özel operasyonlar için IColorDal Kullanılacaktır.??
    }
}
