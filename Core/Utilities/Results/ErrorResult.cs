using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        //SuccessResult başarılı gönderme için yapılıştır.
        //Data yoktur. Ve Default olarak tru değeri almalıdır.Success sonuçta :)
        //2 adet alternatifli yöntemimiz var
        //Mesaj gönderebileceği ve True değeri gösteren.
        //Mesaj göndermeyen ve sadece true değeri gösteren.
        //base() Result classını ifade eder. Result classına değerler gönderir.
        public ErrorResult(string message) : base(false, message)
        {
            //Mesajlı
        }
        public ErrorResult() : base(false)
        {
            //Mesajsız
        }
    }
}
