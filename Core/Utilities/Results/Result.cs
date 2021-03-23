using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Get; read onlydir ve Constructor ile set edebiliriz
        public Result(bool success,string message):this(success)
        {
            //:this(success) This bu class yani Result classı anlamı taşımaktadır.
            //ve bu metot çalıştığında tek parametreli contructor a success i yolla
            Success = success;
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
        //set; olmamasının sebebi bu mimariyi kullanacak olan baika bir yazılımcı tarafından succes
        //ve  message bilgileri girilmesin kısıtlama yapıldı. 
        //Otomatik olarak değerler gelecektir.
    }
}
