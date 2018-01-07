using EmotionWeb.Models;
using EmotionWeb.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmotionWeb.Controllers
{
    public class EmoUploadController : Controller
    {
        string serverFolderPath;
        EmotionHelper emoHelper;
        string key;
        private EmotionWebContext db = new EmotionWebContext();
        public EmoUploadController()
        {
            serverFolderPath = ConfigurationManager.AppSettings["UPLOAD_DIR"];
            key = ConfigurationManager.AppSettings["WEB_KEY"];
            emoHelper = new EmotionHelper(key);
        }


        // GET: EmoUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase file)
        {
            if (file?.ContentLength > 0 ) 
            {
                var pictureName = Guid.NewGuid().ToString();
                pictureName += Path.GetExtension(file.FileName);

                var route = Server.MapPath(serverFolderPath);
                route = route +"/"+ pictureName;

                file.SaveAs(route);

                var emoPicture = await emoHelper.DetectAndExtractFacesAsync(file.InputStream);
                emoPicture.Name = file.FileName;
                emoPicture.Path = serverFolderPath+"/"+pictureName;

                db.EmoPictures.Add(emoPicture);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}