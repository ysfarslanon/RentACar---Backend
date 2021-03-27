using Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages //Newlenmesin diye static. Public variable PascalCase yazılır
    {
        //Car Messages
        public static string CarAdded = "Araç eklendi."; 
        public static string CarDeleted = "Araç silindi.";
        public static string CarUpdated = "Araç güncellendi.";
        public static string CarListed = "Araç listelendi.";
        public static string CarNameInvalid = "Geçersiz araç ismi girildi. Araç isimi en az iki karakter olmalıdır.";
        public static string CarDailyPriceInvalid = "Geçersiz araç günlük fiyatı girildi. Araç günlük fiyatı sıfır TL den düşük olamaz.";

        //Brand Messages
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandListed = "Marka listelendi.";
        public static string BrandInvalid = "Marka geçersiz";

        //Color Messages
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorListed = "Renk Listelendi.";
        public static string ColorInvalid = "Renk geçersiz.";

        //User Messages
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserListed = "Kullanıcı listelendi.";

        //Customer Messages
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerListed = "Müşteri listelendi.";


        //Rental Messages
        public static string RentalAdded = "eklendi.";
        public static string RentalDeleted = " silindi.";
        public static string RentalUpdated = " güncellendi.";
        public static string RentalListed = " listelendi.";

        //System Messages
        public static string SystemMaintanceTime = "Sistem bakımdadır.";
        public static string SystemFailed = "Başaramadık...";

        public static string CarImageAdded = "Araç resmi eklendi.";

        public static string CarImageLimit = "Bir aracın en fazla 5 adet resmi olabilir.";
        public static string AuthorizationDenied="Erişim reddebildi.";

        public static string UserRegistered = "Kullanıcı Kayıt edildi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatası.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı var.";
        public static string AccessTokenCreated = "Giriş token oluşturuldu.";
    }
}
