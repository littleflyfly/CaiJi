using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CaiJiService.ApiControllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : ApiController
    {
        private Repositories.Interfaces.IUserRepository userRepository = new Repositories.UserRepository();

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="userpwd">密码</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Login(string username, string userpwd)
        {
            var user = userRepository.GetModel(a => a.Name == username && a.Password == userpwd);
            if (user == null)
            {
                return Json(new
                {
                    Status = -1,
                    Message = "账号或密码错误",
                    Result = new { }
                });
            }
            string access_token = DateTime.Now.ToString("yyyyMMddHHmmss") + user.ID;
            user.AccessToken = access_token;
            if (userRepository.SaveChanges())
            {
                return Json(new
                {
                    Status = 1,
                    Message = "OK",
                    Result = new
                    {
                        access_token
                    }
                });
            }
            else
            {
                return Json(new
                {
                    Status = -1,
                    Message = "登陆失败，请重新尝试",
                    Result = new { }
                });
            }
        }
    }
}