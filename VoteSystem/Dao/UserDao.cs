﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.Dao
{
    public class UserDao
    {
        private VoteSystemDB db = new VoteSystemDB();
        //保存用户
        public void addUser(User user) {
            db.users.Add(user);
            db.SaveChanges();
        }
        //获得指定id的用户
        public User getById(int id) {
            User user = db.users.Where(u => u.ID == id).FirstOrDefault();
            return user;
        }
        //获取指定userEmail的用户
        public User getByUserEmail(String email)
        {
            User user = db.users.Where(u => u.userEmail == email).FirstOrDefault();
            return user;
        }
        //登录校验用户是否存在
        public User checkUser(User user) {
            User res = db.users.Where(u => u.userEmail == user.userEmail && u.userPsw == user.userPsw).FirstOrDefault();
            return res;
        }
    }
}