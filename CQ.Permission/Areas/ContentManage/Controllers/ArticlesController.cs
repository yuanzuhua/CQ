﻿using CQ.Application.BusinessData;
using CQ.Core;
using CQ.Domain.Entity.BusinessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CQ.Permission.Areas.ContentManage.Controllers
{
    public class ArticlesController : BaseController
    {
        [ValidateInput(false)]
        public override ActionResult Form()
        {
            return View();
        }
        private ArticleApp articleApp = new ArticleApp();

        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = articleApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = articleApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SubmitForm(ArticleEntity articleEntity, string keyValue)
        {
            articleApp.SubmitForm(articleEntity, keyValue);
            return Success("操作成功。");
        }
    }
}