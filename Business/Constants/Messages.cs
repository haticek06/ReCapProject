﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba başarıyla eklendi.";
        public static string CarsListed = "Arabalar başarıyla listelendi.";
        public static string CarUpdated = "Araba başarıyla güncellendi.";
        public static string CarDeleted = "Araba başarıyla silindi.";
        public static string CarIdListed = "Araba id'ye göre başarıyla listelendi";
        public static string CarsByColorId = "Arabalar renk id'sine göre başarıyla listelendi";
        public static string CarsByBrandId = "Arabalar marka id'sine göre başarıyla listelendi";
        public static string CarPriceInvalid = "Günlük fiyat değeri 0'dan büyük olmalıdır. Girdiğiniz değer geçersiz.";

        public static string BrandAdded = "Marka Başarıyla Eklendi.";
        public static string BrandNameInvalid = "Marka ismi minimum uzunluğu 2 karakterden fazla olmalıdır. Girdiğiniz marka ismi geçersiz";
        public static string BrandDeleted = "Marka başarıyla silindi.";
        public static string BrandUpdated = "Marka başarıyla güncellendi.";
        public static string BrandsListed = "Markalar başarıyla listelendi.";
        public static string BrandIdListed = "Marka id'ye göre başarıyla listelendi.";

        public static string ColorAdded = "Renk başarıyla eklendi.";
        public static string ColorDeleted = "Renk başarıyla silindi.";
        public static string ColorsListed = "Renkler başarıyla listelendi.";
        public static string ColorIdListed = "Renk id'ye göre başarıyla listelendi.";
        public static string ColorUpdated = "Renk başarıyla güncellendi";

        public static string MaintenanceTime = "Sistem şu anda bakımda";

        public static string CustomerAdded = "Müşteri başarıyla eklendi.";
        public static string CustomersListed = "Müşteriler başarıyla listelendi.";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi.";
        public static string CustomerDeleted = "Müşteri başarıyla silindi.";
        public static string CustomerIdListed = "Müşteri id'ye göre başarıyla listelendi.";

        public static string UserAdded = "Kullanıcı başarıyla eklendi.";
        public static string UsersListed = "Kullanıcılar başarıyla listelendi.";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi.";
        public static string UserDeleted = "Kullanıcı başarıyla silindi.";
        public static string UserIdListed = "Kullanıcı id'ye göre başarıyla listelendi.";

        public static string AddUserMessage = "Üye başarıyla eklendi.";

        public static string DeleteUserMessage = "Üye başarıyla silindi.";
        public static string EditUserMessage = "Üye başarıyla güncellendi.";
        public static string GetSuccessUserMessage = "Üye bilgisi / bilgileri getirildi.";
        public static string GetErrorUserMessage = "Üye bilgisi / bilgileri getirilemedi.";

        public static string RentalAddedError = "Aracın kiraya verilebilmesi için önce teslim edilmesi gerekir.";
        public static string RentalAdded = "Kiralama işlemi başarılı";
        public static string RentalDelete = "Kiralama işlemi başarıyla silindi";
        public static string RentalUpdate = "Kiralama işlemi başarıyla güncellendi";
        public static string RentalListed = "Tüm kiralama işlemleri başarıyla listelendi";

        public static string FailedImageLimit = "Araç resim ekleme limitine ulaştınız";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImagesListed ="Resim listelendi";
        public static string CarImageUpdated = "Resim güncellendi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";

        public static string Registered = "Başarıyla kayıt olundu";

        public static string WrongPassword = "Yanlış parola";
 
        public static string UserAvailable = "Kullanıcı mevcut";
        public static string TokenCreated = "Token oluşturuldu.";

    }
}
