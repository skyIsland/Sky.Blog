using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Sky.Common;
using Sky.Models;

namespace Sky.Blog.Controllers
{
    public class UploadController : Controller
    {
        /// <summary>
        /// 上传文件--目前只支持单文件,上传图片未做裁剪处理,上传文件信息未记录
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase f)
        {

            var curFile = Request.Files[0];
            if (curFile == null|| curFile.ContentLength==0)
            {
                var json = new
                {
                    code = 1,
                    msg = "没有找到要上传的图片呢(或者图片大小为0啵)，请重新选择吧。"
                };
                return Json(json);
            }
            try
            {               
                int intDocLen = curFile.ContentLength;
                byte[] Docbuffer = new byte[intDocLen];
                curFile.InputStream.Read(Docbuffer, 0, intDocLen);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] bytHash = md5.ComputeHash(Docbuffer);
                string fileHash = BitConverter.ToString(bytHash);
                var files = UploadFiles.FindByMd5(fileHash);
                if (files != null)
                {
                    return Json(new
                    {
                        code = 0,
                        msg = "咦？已经存在了呢。",
                        data = new
                        {
                            src = files.FilePath,
                            title = files.FileName
                        }
                    });
                }
                //保存路径
                var extPath = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/";
                //获取图片文件保存的完整路径
                var fileSavePath = Server.MapPath("~/uploads/images/" + extPath);
                //路径不存在则创建
                if (!Directory.Exists(fileSavePath))
                    Directory.CreateDirectory(fileSavePath);

                //获取文件名
                var fileName = Path.GetFileName(curFile?.FileName);
                //获取文件后缀名
                var filePostfixName = fileName.Substring(fileName.LastIndexOf('.'));
                //获取新文件名
                var newFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + filePostfixName;
                //合并路径
                var path = Path.Combine(fileSavePath, newFileName);
                //保存文件
                curFile.SaveAs(path);


                return Json(new
                {
                    code = 0,
                    msg = "咦？好像上传成功了呢。",
                    data = new
                    {
                        src = "/uploads/images/" + extPath + newFileName,
                        title = "这是图片的标题啊。"
                    }
                });
            }
            catch (Exception ex)
            {

                var json = new
                {
                    code = 1,
                    msg = "出错了，错误信息：" + ex.Message
                };
                return Json(json);
            }
        }

        public ActionResult WangEditor()
        {
            return View();
        }
    }
}