using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinDemo.Service.Handler
{
    public interface IMsgHandler
    {
        object Execute(string postData);

    }
}
