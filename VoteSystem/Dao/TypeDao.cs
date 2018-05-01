using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.Dao
{
    public class TypeDao
    {
        private VoteSystemDB db = (VoteSystemDB)DBContextFactory.GetCurrentContext();
        //保存类型
        public void add(Models.Type t) {
            db.types.Add(t);
            db.SaveChanges();
        }
        //获取指定id的类型
        public Models.Type getById(int id) {
            Models.Type type = db.types.Where(t => t.ID == id).FirstOrDefault();
            return type;
        }
        //获取全部类型集合
        public List<Models.Type> getTypeList() {
            return db.types.ToList();
        }
    }
}