using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomTask.Model;
using System.Threading;
using Domain;
using System.Data.Entity.Migrations;
using Domain.Model;
using Newtonsoft.Json;

namespace CustomTask
{
    public class AccessTokenRefreshWork
    {
        public void RunSync()
        {
            Task.Run(() =>
            {
                Run();
            });
        }

        private void Run()
        {
            while (true)
            {
                string url = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={WeiXinApi.WeiXinConst.Appid}&secret={WeiXinApi.WeiXinConst.Secret}";
                var response = new Common.HttpHelper().Get<AccessTokenRespoonse>(url);
                using (var db=new WeiXinDbContext())
                {
                    db.SysSetting.AddOrUpdate(new SysSetting
                    {
                        Id=1,
                        Access_token=response.Access_token
                    });
                    db.SaveChanges();
                }
                Thread.Sleep(TimeSpan.FromSeconds(7000));
            }
        }
    }
}
