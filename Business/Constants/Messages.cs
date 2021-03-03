using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {

        public static string MaintenanceTime = "Sistem Bakımda";


        public static string CarAdded = "Araba Eklendi";//Publicler pascal keys yazılır : Büyük harf
        public static string CarInvalid = "Geçersiz araba";
        public static string CarListed = "Arabalar Listelendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";



        public static string UserAdded = "Kullanıcı Eklendi";//Publicler pascal keys yazılır : Büyük harf
        public static string UserInvalid = "Geçersiz kullanıcı";
        public static string UserListed = "Kullanıcılar Listelendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";



        public static string CustomerAdded = "Müşteri Eklendi";//Publicler pascal keys yazılır : Büyük harf
        public static string CustomerInvalid = "Geçersiz kullanıcı";
        public static string CustomerListed = "Müşteri Listelendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";


        public static string RentalAdded = "Araba kiralandı";//Publicler pascal keys yazılır : Büyük harf
        public static string RentalInvalid = "Geçersiz kullanıcı";
        public static string RentalListed = "Kiralar Listelendi";
        public static string RentalDeleted = "Kira bilgisi silindi";
        public static string RentalUpdated = "Kira güncellendi";


        public static string CarImageAdded = "Araba resimi eklendi";
        public static string CarImageInvalid = "Geçersiz araba resimi";
        public static string CarImageListed = "Araba resimleri Listelendi";
        public static string CarImageDeleted = "Araba resim bilgisi silindi";
        public static string CarImageUpdated = "Araba resimi güncellendi";
        public static string NumberOfPicturesCannotBeGreaterThan = "Resim sayısı 5'den fazla olamaz";
        public static string GetErrorCarMessage="Sistemde olmayan bir araba girdiniz.";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError="Şifre Hatalı";
        public static string SuccesfulLogin="Giriş Başarılı";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Access Token başarıyla oluşturuldu";
    }
}
