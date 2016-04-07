using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSL.MSP.MVC.Web.UI.Areas.FrameWork.Models
{
    public class LoginForm
    {
        //切換站台編號
        public string choose_ID { get; set; }
        //登入帳號
        public string User_Account { get; set; }
        //登入密碼
        public string User_PWD { get; set; }
        //群組編號(第一銀行:特店編號)
        public string Group_ID { set; get; }
        //圖形認證碼
        public string Image_Code { set; get; }
    }
}