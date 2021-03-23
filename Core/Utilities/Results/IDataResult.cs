using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
//IResult den message ve success gelecek
//Özel olarak da data istiyoruz
//Her türden olacağı için generic yaptık
//Her türden olacağı için kısıtlama yazılmadı.