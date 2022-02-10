using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";
        public static string CategoryAdded = "Kategori başarıyla eklendi";
        public static string CategoryDeleted = "Kategori başarıyla silindi";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Kayıtlı";
        public static string UserRegistered = "Kullanıcı Başarıyla Kaydedildi";
        public static string AccessTokenCreated = "Access Token Başarıyla Oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string ProductNameAlreadyExists = "Ürün ismi mevcut";
        public static string CategoryRule = "Category Rule";
    }
}

