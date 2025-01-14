﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViewModel.WebConfig;
using ViewModels.Share;
using webTemplate.Utility;
using WebTemplateDB.Interface;
using WebTemplateDB.Models;
using WebTemplateDB.Service;

namespace webTemplate.Controllers
{
    public class WebConfigController : BaseController
    {
        protected IWebConfigService _webconfig;

        public WebConfigController()
        {
            _db = new WebTemplateEntities();
            _webconfig = new WebConfigService();
        }

        // GET: WebConfig
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 取得網站設定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ValidateJsonAntiForgeryToken]
        public async Task<JsonResult> GetWebConfig(int Id) 
        {
            ResponseViewModel res = new ResponseViewModel();

            try 
            {
                var data = await _webconfig.GetWebConfig(Id);
                res.Data = data;
                res.Success = true;
                res.Message = "取得網頁設定成功";
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
        /// <summary>
        /// 編輯網站設定
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public async Task<JsonResult> EditWebConfig(WebConfigViewModel model) 
        {
            ResponseViewModel res = new ResponseViewModel();

            try
            {
                var result = await _webconfig.EditWebConfig(model);
                res.Success = result.Success;
                res.Message = result.Message;
                res.HttpStatusCode = System.Net.HttpStatusCode.OK;
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