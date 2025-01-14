﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.WebConfig;

namespace ViewModel.Home
{
    public class HomeViewModel
    {
        /// <summary>
        /// 最新消息總筆數
        /// </summary>
        public int LatestNewsNumber { get; set; }
        /// <summary>
        /// 案例介紹總筆數
        /// </summary>
        public int CaseNumber { get; set; }
        /// <summary>
        /// 聯絡我們總筆數
        /// </summary>
        public int ContactNumber { get; set; }

        public WebConfigViewModel WebConfig { get; set; }
    }
}
