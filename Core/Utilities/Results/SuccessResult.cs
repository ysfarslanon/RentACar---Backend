using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //SuccessResult başarılı gönderme için yapılıştır.
        //Data yoktur. Ve Default olarak tru değeri almalıdır.Success sonuçta :)
        //2 adet alternatifli yöntemimiz var
        //Mesaj gönderebileceği ve True değeri gösteren.
        //Mesaj göndermeyen ve sadece true değeri gösteren.
        public SuccessResult(string message) : base(true,message)
        {
            //Mesajlı
        }
        public SuccessResult() : base(true) 
        {
            //Mesajsız
        }

    }
}
