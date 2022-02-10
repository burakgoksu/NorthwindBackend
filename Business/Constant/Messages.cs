using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
    public static class Messages
    {
        public static string ProductAdded = "Product was added successfully";
        public static string ProductDeleted = "Product was deleted successfully";
        public static string ProductUpdated = "Product was updated successfully";
        public static string CategoryAdded = "Category was added successfully";
        public static string CategoryDeleted = "Category was deleted successfullyi";
        public static string CategoryUpdated = "Category was updated successfully";
        public static string UserNotFound = "User Not Found";
        public static string PasswordError = "Password Error";
        public static string SuccessfulLogin = "Login successful";
        public static string UserAlreadyExists = "User already registered ";
        public static string UserRegistered = "User was registered successfully";
        public static string AccessTokenCreated = "Access Token was created successfully";
        public static string AuthorizationDenied = "You are not authorized";
        public static string ProductNameAlreadyExists = "Product name already exists";
        public static string CategoryRule = "Category Rule";
        public static string CategoryNameAlreadyExists = "Category name already exists";
        public static string EmailAlreadyExists = "This Email already exists";
        public static string UserAdded = "User was added successfully";
    }
}

