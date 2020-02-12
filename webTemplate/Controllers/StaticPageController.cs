﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViewModel.StaticPage;
using ViewModels.Share;
using WebTemplateDB.Interface;
using WebTemplateDB.Service;

namespace webTemplate.Controllers
{
    public class StaticPageController : BaseController
    {
        protected IStaticPageService _staticPageService;

        public StaticPageController()
        {
            _staticPageService = new StaticPageService();
        }

        // GET: StaticPage
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetStaticPageList()
        {
            ResponseViewModel res = new ResponseViewModel();

            try
            {
                var data = await _staticPageService.GetStaticPageList();
                res.Data = data;
                res.Success = true;
                res.Message = "取得靜態頁列表內容成功";
                res.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch
            {
                res.Success = false;
                res.Message = "與伺服器連線發生錯誤";
                res.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            res.ResponseTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> CreateStaticPage(StaticPageViewModel model)
        {
            ResponseViewModel res = new ResponseViewModel();

            try
            {
                model.CreateUser = CurrendUserid;
                var result = await _staticPageService.CreateStaticPage(model);
                if (result.Success)
                {
                    res.Data = result.Data;
                    res.Success = result.Success;
                    res.Message = result.Message;
                    res.HttpStatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    res.Success = result.Success;
                    res.Message = result.Message;
                    res.HttpStatusCode = System.Net.HttpStatusCode.OK;
                }
            }
            catch
            {
                res.Success = false;
                res.Message = "與伺服器連線發生錯誤";
                res.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            res.ResponseTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return Json(res, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public async Task<JsonResult> EditStaticPage(StaticPageViewModel model)
        {
            ResponseViewModel res = new ResponseViewModel();

            try
            {
                model.UpdateUser = CurrendUserid;
                var result = await _staticPageService.EditStaticPage(model);
                if (result.Success)
                {
                    res.Data = result.Data;
                    res.Success = result.Success;
                    res.Message = result.Message;
                    res.HttpStatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    res.Success = result.Success;
                    res.Message = result.Message;
                    res.HttpStatusCode = System.Net.HttpStatusCode.OK;
                }
            }
            catch
            {
                res.Success = false;
                res.Message = "與伺服器連線發生錯誤";
                res.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            res.ResponseTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return Json(res, JsonRequestBehavior.DenyGet);
        }

    }

}