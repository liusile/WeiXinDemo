﻿using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public class HttpHelper
    {
        private string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31";//"Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
        Encoding WebEncoding = Encoding.UTF8;

        public HttpHelper() { }
        public HttpHelper(Encoding _encoding)
        {
            WebEncoding = _encoding;
        }

        /// <summary>
        /// 处理网络连接
        /// </summary>
        /// <param name="Url">Url连接</param>
        /// <param name="PostData">参数</param>
        /// <param name="Method">访问类型（GET/POST）</param>
        /// <param name="select">数据访问类型（select/update/insert/delete）</param>
        /// <returns></returns>
        public string QueryData(string Url, string PostData, string Method, SelectType select = SelectType.Select, string guid = null)
        {
            var begTime = DateTime.Now;

            int TryCount = 0;
            reTry:
            try
            {
                HttpWebRequest httpRequest;

                if (Method.ToLower() == "post")
                {
                    httpRequest = (HttpWebRequest)HttpWebRequest.Create(Url);
                }
                else
                {
                    if (string.IsNullOrEmpty(PostData))
                    {
                        httpRequest = (HttpWebRequest)HttpWebRequest.Create(Url);
                    }
                    else
                    {
                        httpRequest = (HttpWebRequest)HttpWebRequest.Create(Url + "?" + PostData.Trim());
                    }

                }

                httpRequest.Method = Method.ToUpper();
                //httpRequest.CookieContainer = cc;
                // httpRequest.Headers.Set("Accept-Language", "en-us");
                if (Method.ToLower() == "post")
                {
                    httpRequest.ContentLength = PostData.Length;
                }
                //httpRequest.Timeout = 60000;
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                //httpRequest.Headers.Add("UA-CPU", "x86");
                httpRequest.Accept = "*/*";
                httpRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                //httpRequest.Headers.Add("Accept-Encoding", "deflate,sdch");
                httpRequest.UserAgent = userAgent;
                if (!Url.Contains("FeesBiling"))
                {
                    httpRequest.AutomaticDecompression = DecompressionMethods.GZip;
                }
                //httpRequest.KeepAlive = true;
                //httpRequest.AllowWriteStreamBuffering = true;

                if (Method.ToLower() == "post")
                {
                    //Encoding encoding = Encoding.GetEncoding("utf-8");
                    byte[] bytesToPost = WebEncoding.GetBytes(PostData);
                    httpRequest.ContentLength = bytesToPost.Length;
                    Stream requestStream = httpRequest.GetRequestStream();
                    requestStream.Write(bytesToPost, 0, bytesToPost.Length);
                    requestStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();

                Stream responseStream = Gzip(response);

                //response.Cookies = cc.GetCookies(httpRequest.RequestUri);
                StreamReader sr = new StreamReader(response.GetResponseStream(), WebEncoding);
                string reStr = sr.ReadToEnd();
                sr.Close();
                response.Close();

                return reStr;
            }
            catch (Exception ex)
            {
                TryCount++;
                if (TryCount < 2 && select == SelectType.Select)
                {
                    Thread.CurrentThread.Join(500);
                    goto reTry;
                }
                else
                {
                    return string.Empty;
                }
            }

        }

        private Stream Gzip(HttpWebResponse HWResp)
        {
            Stream stream1 = null;
            if (HWResp.ContentEncoding == "gzip")
            {
                stream1 = new GZipInputStream(HWResp.GetResponseStream());
            }
            else
            {
                if (HWResp.ContentEncoding == "deflate")
                {
                    stream1 = new InflaterInputStream(HWResp.GetResponseStream());
                }
            }
            if (stream1 == null)
            {
                return HWResp.GetResponseStream();
            }

            return stream1;
        }

        public enum SelectType
        {
            Select = 0,
            Update = 1,
            Insert = 2,
            Delete = 3
        }

        /// <summary>
        /// 处理网络连接
        /// </summary>
        /// <param name="Url">Url连接</param>
        /// <param name="PostData">参数</param>
        /// <param name="Method">访问类型（GET/POST）</param>
        /// <param name="select">数据访问类型（select/update/insert/delete）</param>
        /// <returns></returns>
        public MemoryStream QueryDataStream(string Url, string PostData, string Method, SelectType select = SelectType.Select, string guid = null)
        {
            var begTime = DateTime.Now;
            //int TryCount = 0;
            try
            {
                HttpWebRequest httpRequest;

                if (Method.ToLower() == "post")
                {
                    httpRequest = (HttpWebRequest)HttpWebRequest.Create(Url);
                }
                else
                {
                    if (string.IsNullOrEmpty(PostData))
                    {
                        httpRequest = (HttpWebRequest)HttpWebRequest.Create(Url);
                    }
                    else
                    {
                        httpRequest = (HttpWebRequest)HttpWebRequest.Create(Url + "?" + PostData.Trim());
                    }
                }
                httpRequest.Method = Method.ToUpper();
                if (Method.ToLower() == "post")
                {
                    httpRequest.ContentLength = PostData.Length;
                }
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                httpRequest.Accept = "*/*";
                httpRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                httpRequest.UserAgent = userAgent;
                if (!Url.Contains("FeesBiling"))
                {
                    httpRequest.AutomaticDecompression = DecompressionMethods.GZip;
                }
                HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
                Stream stream = response.GetResponseStream();
                if (stream != null)
                {
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Dispose();
                    response.Close();
                    return new MemoryStream(bytes);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        internal T ReadStreamListFromBase64String<T>(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                return JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(Convert.FromBase64String(sr.ReadToEnd())));
            }
        }

        internal void WriteStreamToBase64String(string path, object data)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.Write(Convert.ToBase64String(Encoding.Default.GetBytes(JsonConvert.SerializeObject(data))));
                sw.Flush();
            }
        }

        public T Post<T>(string url, object param) where T : class
        {
            var begTime = DateTime.Now;
            var json = JsonConvert.SerializeObject(param, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var byteData = Encoding.UTF8.GetBytes(json);
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "post";
            httpRequest.KeepAlive = false;
            httpRequest.ContentType = "application/json;charset=utf-8";
            httpRequest.ContentLength = byteData.Length;
            httpRequest.GetRequestStream().Write(byteData, 0, byteData.Length);
            httpRequest.Timeout = 2 * 60 * 1000 * 300;
            var strResponse = string.Empty;
            TryMultiTime(() =>
            {
                var responseStream = httpRequest.GetResponse().GetResponseStream();
                if (responseStream == null) return;
                using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    strResponse = reader.ReadToEnd();
                }
            }, 3);
            return JsonConvert.DeserializeObject<T>(strResponse);
        }
        public T Get<T>(string url) where T : class
        {
            string result = QueryData(url, "", "Get");
            var obj = JsonConvert.DeserializeObject<T>(result);
            return obj;
        }
        private void TryMultiTime(Action act, int tryTimes, int interval = 2000)
        {
            var i = 0;
            while (true)
            {
                try
                {
                    i++;
                    act();
                    break;
                }
                catch (Exception ex)
                {
                    if (i >= tryTimes)
                    {
                        throw new Exception("请求超时", ex);
                    }
                    Thread.Sleep(interval);
                }
            }
        }
    }
}
