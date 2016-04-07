using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using RSL.MSP.MVC.Web.UI.Areas.FrameWork.Controllers;
using RSL.MSP.MVC.Utility;
using RSL.MSP.MVC.Model;
using RSL.MSP.MVC.Model.Enums;
using RSL.MSP.MVC.Model.EinvModel;
using RSL.MSP.MVC.BLL.EinvBLL;
using RSL.MSP.MVC.Model.Common;
using RSL.MSP.MVC.Common.ControllerHelper;
using System.Data;
using RSL.MSP.MVC.Web.UI.Areas.Einv.Models;

namespace RSL.MSP.MVC.Web.UI.Areas.Einv.Controllers
{
    public class EinvInfoController : BaseController
    {
        //
        // GET: /Einv/Einv/
        public ActionResult Index()
        {
            ViewBag.data = null;
            ViewBag.Buttonlist = this.LoginedUserAuthAction;
            EinvUtilBLL EuBll = new EinvUtilBLL();
            ViewBag.ddlInvM = EuBll.ListGetInvYm(DateTime.Now.Month.ToString());//selectList;
            
            BindEinvInfoList(DateTime.Now.Year.ToString(), EuBll.strGetInvYm(DateTime.Now.Month.ToString()));
            return View();
        }

        public void BindEinvInfoList(string txtInvY, string ddlInvM)
        {
            //QueryModel<CompanyModel> 查询实体类
            QueryModel<EinvModel> queryModel = new QueryModel<EinvModel>();
            queryModel.Entity = new EinvModel(); //發票Model
            queryModel.Entity.INV_YM = txtInvY + ddlInvM;
            //txtInvYm.Text.Trim() == "" ? DateTime.Now.Year.ToString() : txtInvYm.Text.Trim(); //公司名称
            // queryModel.Entity.TRACK = txtTrack.Text.Trim();
            queryModel.Entity.USER_ID = this.LoginedUserNumber;
            queryModel.rows = 10;
            EinvBLL MyCompanyBLL = new EinvBLL(); //逻辑层处理
            //List<EinvModel> tmp = new List<EinvModel>();
            //tmp = MyCompanyBLL.GetEinvListByPage(queryModel);
            ViewBag.einvList = MyCompanyBLL.GetEinvListByPage(queryModel);
        }

        [HttpPost]
        public ActionResult jsBindEinvInfoList(string txtInvY, string ddlInvM)
        {
            //QueryModel<CompanyModel> 查询实体类
            QueryModel<EinvModel> queryModel = new QueryModel<EinvModel>();
            queryModel.Entity = new EinvModel(); //發票Model
            queryModel.Entity.INV_YM = txtInvY + ddlInvM;
            //txtInvYm.Text.Trim() == "" ? DateTime.Now.Year.ToString() : txtInvYm.Text.Trim(); //公司名称
            // queryModel.Entity.TRACK = txtTrack.Text.Trim();
            queryModel.Entity.USER_ID = this.LoginedUserNumber;
            queryModel.rows = 10000;
            EinvBLL MyCompanyBLL = new EinvBLL(); //逻辑层处理
            List<EinvModel> tmp = new List<EinvModel>();
            tmp = MyCompanyBLL.GetEinvListByPage(queryModel);
            
            return Json(tmp);
        }


        public ActionResult update()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit( int iTKey)
        {
            
            ViewBag.txtReadOnly = false;
            ViewBag.txtDisabled = false;
            ViewBag.ddlDisabled = false;
            ViewBag.btnDisabled = false;
            EinvUtilBLL EuBll = new EinvUtilBLL();
            EinvBLL EinvBLL = new EinvBLL();
           
            ViewBag.hdfInvTKey = iTKey;

            EinvModel EinvInfo = EinvBLL.GetEinvListByTkey(iTKey);

            //寫入暫存
            ViewBag.txtCenterId = EinvInfo.CENTER_ID.ToString();
            ViewBag.txtInvY = EinvInfo.INV_YM.Substring(0, 4);
            ViewBag.txtTrack = EinvInfo.TRACK.ToString();
            ViewBag.txtInvNoB = EinvInfo.INV_NO_B.ToString();
            ViewBag.txtInvNoE = EinvInfo.INV_NO_E.ToString();
            ViewBag.txtInvroll = EinvInfo.INV_ROLL.ToString();
            ViewBag.ddlInvM = EuBll.ListGetInvYm(EinvInfo.INV_YM.Substring(4));//selectList;
            ViewBag.ddlInvType = EuBll.GetInvType(EinvInfo.INV_TYPE.ToString());//selectList;

            //寫入暫存資料
            ViewBag.hdInvYm = EinvInfo.INV_YM.ToString();
            ViewBag.hdInvType = EinvInfo.INV_TYPE.ToString();
            ViewBag.hdTrack = EinvInfo.TRACK.ToString();
            ViewBag.hdInvNoB = EinvInfo.INV_NO_B.ToString();
            ViewBag.hdInvNoE = EinvInfo.INV_NO_E.ToString();

            //若已配號不可修改
            int iInvRoll = iGetInvRoll(ViewBag.txtInvNoB, ViewBag.txtInvNoE, EinvInfo.INV_TYPE.ToString());
            if (iInvRoll - int.Parse(EinvInfo.INV_ROLL.ToString()) != 0)
            {
                ViewBag.txtReadOnly = true;
                ViewBag.txtDisabled = true;
                ViewBag.ddlDisabled = true;
                ViewBag.btnDisabled = true;
                
            }

            return View();
        }

        public ActionResult Add()
        {
            EinvUtilBLL EuBll = new EinvUtilBLL();
            EinvBLL EinvBLL = new EinvBLL();
           
            ViewBag.ddlInvM = EuBll.ListGetInvYm(DateTime.Now.Month.ToString());//selectList;
            ViewBag.ddlInvType = EuBll.GetInvType("");//selectList;
            return View();
        }
        [HttpPost]
        public JsonResult AddModel(EinvModel Emodel) 
        {
            var result = new Result<string>();
            
            EinvModel model = new EinvModel();
            EinvBLL EinvBLL = new EinvBLL();
            EinvUtilBLL EinvUtilBLL = new EinvUtilBLL();            
            string strInvFormat;

            try
            {
                if (Emodel == null) { throw new ArgumentException("參數錯誤"); }

                model.INV_YM = Emodel.INV_YM;
                model.TRACK = Emodel.TRACK;
                model.INV_NO_B = Emodel.INV_NO_B;
                model.INV_NO_E = Emodel.INV_NO_E;
                model.INV_TYPE = Emodel.INV_TYPE;
                model.INV_ROLL = Emodel.INV_ROLL;

                switch (Emodel.INV_TYPE.ToString())
                {
                    case "1":
                    case "2":
                        strInvFormat = "32";
                        break;
                    case "3":
                    case "4":
                        strInvFormat = "31";
                        break;
                    case "5":
                    case "6":
                        strInvFormat = "35";
                        break;
                    default:
                        strInvFormat = "32";
                        break;
                }
                model.INV_FORMAT = strInvFormat.ToString();
                model.SITE_ID = EinvUtilBLL.GetCenterSiteId(Emodel.CENTER_ID);
                if (!string.IsNullOrWhiteSpace(model.SITE_ID))
                {
                    if (iCheckInvBaseHq(model) == 0)
                    {
                        model.BUSER = this.LoginedUserID;
                        int iresult = EinvBLL.intAddInvBaseHq(model);//新增
                        if (iresult > 0)
                        {
                            result.flag = true;
                        }
                        if (result.flag)
                        {
                            ActionLog("Sys_User", model, MVCActionTypeEnum.Insert, LoginedUserInfo);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("新增發票資料失败！發票區間已被使用！");
                    }

                }
                else
                {
                    throw new ArgumentException("新增發票資料失败！總公司統編錯誤！");
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditModel(EinvEditModel Editmodel)
        {
            var result = new Result<string>();
            
            EinvModel model = new EinvModel();
            EinvBLL EinvBLL = new EinvBLL();
            EinvUtilBLL EinvUtilBLL = new EinvUtilBLL();            
            string strInvFormat;

            try
            {
                if (Editmodel == null) { throw new ArgumentException("參數錯誤"); }
                model.INV_YM = Editmodel.INV_YM;
                model.TRACK = Editmodel.TRACK;
                model.INV_NO_B = Editmodel.INV_NO_B;
                model.INV_NO_E = Editmodel.INV_NO_E;
                model.INV_TYPE = Editmodel.INV_TYPE;
                model.INV_ROLL = Editmodel.INV_ROLL;

                switch (Editmodel.INV_TYPE.ToString())
                {
                    case "1":
                    case "2":
                        strInvFormat = "32";
                        break;
                    case "3":
                    case "4":
                        strInvFormat = "31";
                        break;
                    case "5":
                    case "6":
                        strInvFormat = "35";
                        break;
                    default:
                        strInvFormat = "32";
                        break;
                }
                model.INV_FORMAT = strInvFormat.ToString();
                model.SITE_ID = EinvUtilBLL.GetCenterSiteId(Editmodel.CENTER_ID);
                if (!string.IsNullOrWhiteSpace(model.SITE_ID))
                {
                    if (GetInvBaseCount(Editmodel) == 0)
                    {

                        model.T_KEY = Editmodel.T_KEY;
                        model.CUSER = this.LoginedUserID;

                        int iresult = EinvBLL.UpdatInvHqData(model);//修改
                        if (iresult > 0)
                        {
                            result.flag = true;
                        }
                        if (result.flag)
                        {
                            ActionLog("Sys_User", model, MVCActionTypeEnum.Insert, LoginedUserInfo);
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("修改發票資料失败！總公司統編錯誤！");
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                result.msg = ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        

        private int iGetInvRoll(string _strInvNoB, string _strInvNoE, string strInvType)
        {
            int iInvRoll = 0;
            int iInvDefaultRoll = 1;
            switch (strInvType.ToString())
            {
                case "1":
                case "2":
                    iInvDefaultRoll = 50;
                    break;
                case "3":
                case "4":
                    iInvDefaultRoll = 50;
                    break;
                case "5":
                case "6":
                    iInvDefaultRoll = 50;
                    break;
                default:
                    iInvDefaultRoll = 250;
                    break;
            }
            iInvRoll = ((int.Parse(_strInvNoE) - int.Parse(_strInvNoB)) + 1) / iInvDefaultRoll;

            return iInvRoll;
        }

        private int iCheckInvBaseHq(EinvModel _eModel)
        {
            int iCount = 0;
            EinvModel EModel = new EinvModel();
            EinvBLL EinvBLL = new EinvBLL();

            EModel.INV_YM = _eModel.INV_YM;
            EModel.TRACK = _eModel.TRACK;
            EModel.INV_NO_B = _eModel.INV_NO_B;
            EModel.INV_NO_E = _eModel.INV_NO_B;
            EModel.INV_TYPE = _eModel.INV_TYPE;
            EModel.SITE_ID = _eModel.SITE_ID;

            try
            {
                iCount = EinvBLL.CheckInvBaseHq(EModel);
            }
            catch (Exception ex)
            {
                iCount = -1;
                Log(ex);
                    
            }

            return iCount;
        }

        private int GetInvBaseCount(EinvEditModel _EditModel)
        {
            int iCount = 0;
            EinvModel EModel = new EinvModel();
            EinvUtilBLL EuBll = new EinvUtilBLL();
            EinvBLL EinvBLL = new EinvBLL();

            EModel.INV_YM = _EditModel.OLD_INV_YM;
            EModel.TRACK = _EditModel.OLD_TRACK;
            EModel.INV_NO_B = _EditModel.OLD_INV_NO_B;
            EModel.INV_NO_E = _EditModel.OLD_INV_NO_E;
            EModel.INV_TYPE = _EditModel.OLD_INV_TYPE;
            EModel.SITE_ID = EuBll.GetCenterSiteId(_EditModel.OLD_CENTER_ID);
            if (!string.IsNullOrWhiteSpace(EModel.SITE_ID))
            {
                try
                {
                    iCount = EinvBLL.GetInvBaseCount(EModel);
                }
                catch (Exception ex)
                {
                    iCount = -1;
                    Log(ex);
                    throw;
                }
            }
            else
            {
                throw new ArgumentException("總公司統編錯誤！");
                iCount = -1;
            }
            return iCount;
        }

    }
}
