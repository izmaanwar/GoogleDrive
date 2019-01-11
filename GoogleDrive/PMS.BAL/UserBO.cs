﻿using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.BAL;

namespace PMS.BAL
{
    public class UserBO
    {
        public static int Save(UserDTO dto)
        {
            return PMS.DAL.UserDAO.Save(dto);
        }

        public static int UpdatePassword(UserDTO dto)
        {
            return PMS.DAL.UserDAO.UpdatePassword(dto);
        }
        public static int getuserID(string login,string password)
        {
            return PMS.DAL.UserDAO.getUserID(login, password);
        }

        public static UserDTO ValidateUser(String pLogin, String pPassword)
        {
            return PMS.DAL.UserDAO.ValidateUser(pLogin, pPassword);
        }
        public static UserDTO GetUserById(int pid)
        {
            return PMS.DAL.UserDAO.GetUserById(pid);
        }
        public static List<UserDTO> GetAllUsers()
        {
            return PMS.DAL.UserDAO.GetAllUsers();
        }

        public static int DeleteUser(int pid)
        {
            return PMS.DAL.UserDAO.DeleteUser(pid);
        }
        public static Boolean UserExist(string login,string password,string Email)
        {
            return PMS.DAL.UserDAO.UserExist(login,password,Email);
        }
        public static int isValidEmail(string email)
        {
            return PMS.DAL.UserDAO.isValidEmail(email);
        }
    }
}