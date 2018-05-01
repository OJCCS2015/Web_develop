using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.Dao;
using VoteSystem.Models;

namespace VoteSystem.Controllers
{
    [Authentication]
    public class HomeController : Controller
    {
        // GET: Homes
        [AllowAnonymous]
        public ActionResult Index()
        {
            IndexModel model = new IndexModel();
            TypeDao typedao = new TypeDao();
            model.types = typedao.getTypeList();

            QuestionDao questiondao = new QuestionDao();
            model.questions=questiondao.getAll(0,6);
            for (int i = 0; i < model.questions.Count; i++) {
                model.questions[i].optionData = questiondao.getOptionData(model.questions[i]).Replace(" ","").Replace("\n","").Replace("\t","").Replace("\r","");
                model.questions[i].voteCount = questiondao.getVoteCount(model.questions[i]);
            }
            return View(model);
        }
        //搜索页面
        [HttpPost]
        public ActionResult Search(String searchText) {
            SearchModel model = new Models.SearchModel();
            model.search_content = "";
            model.questions = new List<Question>();
            if (searchText != null ||!searchText.Equals("")) {
                model.search_content = searchText;
                QuestionDao questiondao = new Dao.QuestionDao();
                model.questions = questiondao.search_title(searchText);
            }
            return View(model);
        }
        //发布问题
        public ActionResult Publish() {
            publishModel model = initPublishModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Publish(publishModel model)
        {
            if(!ModelState.IsValid){
                model = initPublishModel();
                return View(model);
            }
            //添加问题
            Question question = new Models.Question();
            question.userID =new UserDao().getById(model.userID);
            question.title = model.title;
            question.queDes = model.queDes;
            question.postTime = model.postTime;
            question.endTime = model.endTime;
            question.optionNum = model.optionNum;
            question.tags = model.tags;
            question.queOption = model.options;

            QuestionDao questiondao = new QuestionDao();
            questiondao.add(question);

            return RedirectToAction("MyPublish");
        }
        //发布的模型初始化
        public publishModel initPublishModel()
        {
            publishModel model = new Models.publishModel();
            //获取类型列表
            List<SelectListItem> items = new List<SelectListItem>();
            TypeDao typedao = new Dao.TypeDao();
            List<Models.Type> types = typedao.getTypeList();
            foreach (Models.Type t in types)
            {
                SelectListItem item = new SelectListItem();
                item.Text = t.typeName;
                item.Value = t.ID.ToString();
                items.Add(item);
            }
            model.types = items;
            //设置选项数
            model.optionNum = 1;
            //设置用户
            model.userID = int.Parse(Request.Cookies["Menber"].Values["ID"]);

            return model;
        }
        //投票页面
        public ActionResult Vote(int questionID) {
            VoteModel model = initVoteModel(questionID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Vote(VoteModel model) {
            if (!ModelState.IsValid) {
                model = initVoteModel(model.questionID);
                return View(model);
            }
            VoteDao votedao = new VoteDao();
            //检查用户是否已经投过票了 否则在原来的基础上更改
            User u = new UserDao().getById(model.userID);
            Question q = new QuestionDao().getById(model.questionID);

            Vote v = votedao.getByUserAndQuestion(u,q);
            if (v == null)
                v = new Models.Vote();
            v.queID = new QuestionDao().getById( model.questionID);
            v.userID = u;
            v.voteComment = model.voteComment;
            v.voteTime = DateTime.Now;
            v.voteRecord = model.voteRecord;
            if (v.ID != 0)
                votedao.update(v);
            else
                votedao.add(v);
            return RedirectToAction("Index");
        }
        //投票模型初始化
        public VoteModel initVoteModel(int questionID) {
            VoteModel model = new Models.VoteModel();
            QuestionDao questiondao = new Dao.QuestionDao();
            Question q = questiondao.getById(questionID);
            model.questionID = questionID;
            model.userID = int.Parse(Request.Cookies["Menber"].Values["ID"]);
            model.tags = q.tags.Split('#');
            model.postTime = q.postTime.ToLongDateString();
            model.endTime = q.endTime.ToLongDateString();
            model.title = q.title;
            model.options = q.queOption.Split('#');
            model.optionNum = q.optionNum;

            model.votes = new VoteDao().getByQuestion(q);

            return model;
        }
        //注销
        [HttpPost]
        public ActionResult LogOff() {
            Response.Cookies["Menber"].Expires = DateTime.Now;//cookie将马上过期
            return RedirectToAction("Index");
        }
        //查看已发布的问题
        public ActionResult MyPublish() {
            MyPublishModel model = new MyPublishModel();

            UserDao userdao = new UserDao();
            User user = userdao.getById(int.Parse(Request.Cookies["Menber"].Values["ID"]));
            QuestionDao questiondao = new QuestionDao();
            model.questions = questiondao.getByUser(user);

            TypeDao typedao = new TypeDao();
            model.types = typedao.getTypeList();

            return View(model);
        }
        //查看已投票的问题
        public ActionResult MyVote() {
            MyVoteModel model = new MyVoteModel();

            UserDao userdao = new UserDao();
            User user = userdao.getById(int.Parse(Request.Cookies["Menber"].Values["ID"]));
            VoteDao votedao = new VoteDao();
            List<Vote> votes = votedao.getByUser(user);
            QuestionDao questiondao = new Dao.QuestionDao();
            model.questions = new List<Question>();
            foreach (Vote v in votes) {
                Question q =v.queID;
                model.questions.Add(q);
            }
            TypeDao typedao = new TypeDao();
            model.types = typedao.getTypeList();

            return View(model);
        }
        //获取更多问题
        [HttpGet]
        public JsonResult GetMore(Models.Type t, int start,int size) {
            QuestionDao questiondao = new Dao.QuestionDao();
            List<Question> list = null;
            if (t.ID == 0)
            {
                list = questiondao.getAll(start, size);
            }
            else {
                list = questiondao.getAll(t,start, size);
            }
            
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        
    }
}