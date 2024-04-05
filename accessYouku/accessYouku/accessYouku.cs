using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;

namespace accessYouku
{
    public partial class accessYouku : Form
    {
        crifanLib crl = null;

        public accessYouku()
        {
            InitializeComponent();

            crl = new crifanLib();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string youkuUrl = txbYoukuLink.Text;

            string respHtml = "";
            respHtml = crl.getUrlRespHtml(youkuUrl);

            string videoId, videoId2;

            //var videoId = '55313411';
            //var videoId2= 'XMjIxMjUzNjQ0';
            string idP = @"var\s+?videoId\s*?=\s*?'(?<videoId>\d+)';\s+?var\s+?videoId2\s*?=\s*?'(?<videoId2>\w+)';";
            Match foundId = (new Regex(idP)).Match(respHtml);
            if (foundId.Success)
            {
                videoId = foundId.Groups["videoId"].Value;
                videoId2 = foundId.Groups["videoId2"].Value;

                //http://v.youku.com/QVideo/~ajax/getVideoPlayInfo?__rt=1&__ro=&id=107551613&type=vv
                //{"vv":43935,"ss":"8lw9lTcgOgczNgwRAqAKbMM"}
                string getInfoUrl = "http://v.youku.com/QVideo/~ajax/getVideoPlayInfo?__rt=1&__ro=&id=" + videoId + "&type=vv";
                respHtml = crl.getUrlRespHtml(getInfoUrl);

                //http://v.youku.com/player/getPlayList/VideoIDS/XMjIxMjUzNjQ0/timezone/+08/version/5/source/video?ran=1386&password=&n=3
                string getPlayListUrl = "http://v.youku.com/player/getPlayList/VideoIDS/" + videoId2 +"/timezone/+08/version/5/source/video?ran=1386&password=&n=3";
                string playListRespJson = crl.getUrlRespHtml(getPlayListUrl);

                string filesdP = @"""data"":\[\{""ct"":""(?<ct>.+?)"",""cs"":""(?<cs>\d+)"",.+?""videoid"":""(?<videoid>\d+)"",""vidEncoded"":""(?<vidEncoded>\w+)"",""username"":"".+?"",""userid"":""(?<userid>\d+)"",.+?""ts"":""(?<ts>.+?)"",.+?""videoSource"":"".+?"",""seconds"":""(?<seconds>\d+).\d+"",";
                Match foundFields = (new Regex(filesdP)).Match(playListRespJson);
                if (foundFields.Success)
                {
                    string ct, cs, videoid,vidEncoded, seconds, userid, ts;
                    ct = foundFields.Groups["ct"].Value;
                    cs = foundFields.Groups["cs"].Value;
                    videoid = foundFields.Groups["videoid"].Value;
                    vidEncoded = foundFields.Groups["vidEncoded"].Value;
                    userid = foundFields.Groups["userid"].Value;
                    ts = foundFields.Groups["ts"].Value;
                    seconds = foundFields.Groups["seconds"].Value;

                    //http://stat.youku.com/player/addPlayerStaticReport
                    string addStaticUrl = "http://stat.youku.com/player/addPlayerStaticReport";
                    //videoid=55313411&sid=134330543048914899547&source=video&h=XpsDXBxUnSJ4eTFC&referer=null&t=Xe9gvzIlB7yNNhEBjlPaaA&uid=0&totalseg=5&url=http%3A%2F%2Fv%2Eyouku%2Ecom%2Fv%5Fshow%2Fid%5FXMjIxMjUzNjQ0%2Ehtml&fullflag=0&ikuflag=y1&totalsec=1817
                    string sid = "";
                    string source = "video";
                    string h = ""; //XpsDXBxUnSJ4eTFC
                    string referer = "null";
                    string t = ts;
                    string uid = "0";
                    string totalseg = "5"; // TODO: update
                    
                    //string url = HttpUtility.UrlPathEncode(youkuUrl);//TODO: update
                    string url = youkuUrl;
                    url = url.Replace(":", "%3A");
                    url = url.Replace("/", "%2F");
                    url = url.Replace(".", "%2E");
                    url = url.Replace("_", "%5F");

                    string fullflag = "0";
                    string ikuflag = "y1";
                    string totalsec = seconds;

                    Dictionary<string, string> postDict = new Dictionary<string, string>();
                    postDict.Add("videoid", videoid);
                    postDict.Add("sid", sid);
                    postDict.Add("source", source);
                    //postDict.Add("h", h);
                    postDict.Add("referer", referer);
                    postDict.Add("t", t);
                    postDict.Add("uid", uid);
                    //postDict.Add("totalseg", totalseg);
                    //postDict.Add("url", url);
                    postDict.Add("fullflag", fullflag);
                    postDict.Add("ikuflag", ikuflag);
                    postDict.Add("totalsec", totalsec);

                    respHtml = crl.getUrlRespHtml(addStaticUrl,null, postDict);  



                    string v, u, fileid, winType, partnerid, paid, s, td, k;
                    v = videoid;
                    t = seconds;
                    u = userid;

                    fileid = "";//TODO: update
                    winType = "interior";
                    partnerid = "null";
                    paid = "0";
                    fullflag = "0";
                    s = "";
                    td = "0";
                    k = "%u71D5%u5C71%u5927%u8BB2%u5802%7C%u516C%u6C11%u793E%u4F1A"; //TODO: update

                    string getFlvFlashUrl = "http://valf.atm.youku.com/valf";
                    getFlvFlashUrl += "?ct=" + ct;
                    getFlvFlashUrl += "&cs=" + cs;
                    getFlvFlashUrl += "&v=" + v;
                    getFlvFlashUrl += "&t=" + t;
                    getFlvFlashUrl += "&u=" + u;
                    //getFlvFlashUrl += "&fileid=" + fileid;
                    getFlvFlashUrl += "&winType=" + winType;
                    getFlvFlashUrl += "&partnerid=" + partnerid;
                    getFlvFlashUrl += "&paid=" + paid;
                    getFlvFlashUrl += "&fullflag=" + fullflag;
                    getFlvFlashUrl += "&s=" + s;
                    getFlvFlashUrl += "&td=" + td;
                    //getFlvFlashUrl += "&k=" + k;
                    string flvFlashRespJson = crl.getUrlRespHtml(getFlvFlashUrl);

                    //{"AT":"0","A2":{"RS":"http://f.youku.com/player/getFlvPath/fileid/030002010050098AE4043E003E88033C86A236-E2C3-5045-BBF7-4B705830D82B?K=c12ba03396d0fe942827db15&yad=1&ts=14","OU":"http://vid.atm.youku.com/over?v=55313411&p=1&ct=t&cs=251&ca=73302&ie=79609&uid=34988573&pl=2&bl=1&s=&td=0","COU":"","CU":"http://vid.atm.youku.com/click?v=55313411&p=1&ct=t&cs=251&ca=73302&ie=79609&uid=34988573&pl=2&bl=1&s=&td=0&u=http://v.youku.com/v_show/id_XNDI5Njk2Nzg4.html&md5=53f2ba7a7388260779be8e7b94e61aa0","SU":"","VCU":"","SCU":"","VT":"","VC":"","ATMSU":"http://valf.atm.youku.com/show?v=55313411&p=1&ct=t&cs=251&ca=73302&ie=79609&uid=34988573&pl=2&bl=1&s=&td=0&cookie=1343309181495O29&vl=14","ISOSU":"","F1":"","F2":"","F3":"0","F4":"0","VL":"14"}}
                    string flvPathP = @"""RS"":""(?<getFlvPathUrl>http:.+?)"",";
                    Match foundFlvPath = (new Regex(flvPathP)).Match(flvFlashRespJson);
                    if (foundFlvPath.Success)
                    {
                        string getFlvPathUrl = foundFlvPath.Groups["getFlvPathUrl"].Value;

                        HttpWebResponse resp = crl.getUrlResponse(getFlvPathUrl);
                        //http://114.80.185.16/youku/6961580E833C813EA93E26B72/030002010050019915509A003E8803CC652C2D-5754-72B4-0194-7744D27D93A2.flv
                        string flvAbsoluteUrl = resp.ResponseUri.AbsoluteUri;

                        resp = crl.getUrlResponse(flvAbsoluteUrl);

                        //http://f.youku.com/player/getFlvPath/sid/134330543048914899547_00/st/flv/fileid/03000205004CD949A7CBC50215E21DAA6811EC-11DF-380D-A63B-F780E01DF4F9?K=26064669c890f002241114bd&hd=0&myp=8909&ts=426
                        //resp Location	http://127.0.0.1:8909/180.96.38.41/youku/6573834855A4D81E3C0C3825F3/03000205004CD949A7CBC50215E21DAA6811EC-11DF-380D-A63B-F780E01DF4F9.flv

                        //http://v.youku.com/v_vpactionInfo/id/55313411/pm/1?__rt=1&__ro=info_stat
                        string getStatUrl = "http://v.youku.com/v_vpactionInfo/id/" + videoId + "/pm/1?__rt=1&__ro=info_stat";
                        respHtml = crl.getUrlRespHtml(getStatUrl);    
                    }
                    
            
                }


            }

            rtbInfo.Text = "";
        }
    }
}
