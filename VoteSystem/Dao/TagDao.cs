using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.Dao
{
    public class TagDao
    {
        private VoteSystemDB db = new VoteSystemDB();
        //保存标签
        public void add(Tag t) {
            db.tags.Add(t);
            db.SaveChanges();
        }
        //获取指定id标签
        public Tag getById(int id) {
            Tag tag = db.tags.Where(t => t.ID == id).FirstOrDefault();
            return tag;
        }
        //获取全部标签集合
        public List<Tag> getTagList() {
            return db.tags.ToList();
        }
        //获取指定数目的标签集合
        public List<Tag> getTagList(int start,int size) {
            return db.tags.OrderBy(t => t.ID).Skip(start).Take(size).ToList();
        }
    }
}