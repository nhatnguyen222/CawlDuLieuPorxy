using System;
using System.IO;
using System.Text;
using xNet;

namespace ConsoleApp6
{
    class Program
    {
     
        static void Main(string[] args)
        {

            var http = new HttpRequest();
            http.AddHeader(HttpHeader.UserAgent, Http.ChromeUserAgent());
            string codeHtml = http.Get("https://spys.one/en/socks-proxy-list/").ToString();
            string[] mangIP = new string[30];
            string[] mangTocDo = new string[30];
            string htmlTam = codeHtml;
            for (int i=0;i<30;i++)
            {
                mangIP[i] = htmlTam.Substring(htmlTam.IndexOf("<td colspan=1><font class=spy14>") + 32, htmlTam.IndexOf(@"<script type=""text/javascript"">document.write(") - htmlTam.IndexOf("<td colspan=1><font class=spy14>") - 32);
                htmlTam= htmlTam.Remove(htmlTam.IndexOf("<td colspan=1><font class=spy14>") , htmlTam.IndexOf(@"<script type=""text/javascript"">document.write(") - htmlTam.IndexOf("<td colspan=1><font class=spy14>")+48);
               // Console.WriteLine(mangIP[i]);
            }
            htmlTam = codeHtml;
            for (int i = 0; i < 30; i++)
            {
                mangTocDo[i] = htmlTam.Substring(htmlTam.IndexOf("/td><td colspan=1><TABLE width='") + 32, htmlTam.IndexOf("' height='8' CELLPADDING=0 CELLSPACING=0>") - htmlTam.IndexOf("/td><td colspan=1><TABLE width='") - 32);
                htmlTam = htmlTam.Remove(htmlTam.IndexOf("/td><td colspan=1><TABLE width='"), htmlTam.IndexOf("' height='8' CELLPADDING=0 CELLSPACING=0>") - htmlTam.IndexOf("/td><td colspan=1><TABLE width='") + 73);
               // Console.WriteLine(mangTocDo[i]);
               
            }
            htmlTam = codeHtml;
         string portGiaiMa = htmlTam.Substring(htmlTam.IndexOf(@"<tr><td>&nbsp;</td></tr><tr><td>&nbsp;</td></tr></td></tr></table><script type=""text/javascript"">")+97,htmlTam.IndexOf(";</script>")- htmlTam.IndexOf(@"<tr><td>&nbsp;</td></tr><tr><td>&nbsp;</td></tr></td></tr></table><script type=""text/javascript"">")-97);
            string[] codeMaHoa = portGiaiMa.Split(";");
           
            string[] mangPortMaHoa = new string[10];

            for(int i=10;i< codeMaHoa.Length;i++)
            {
                mangPortMaHoa[i - 10] = codeMaHoa[i].Remove(codeMaHoa[i].IndexOf("=") , 2);
            }
            string[] mangPort = new string[30];
            for (int i = 0; i < 30; i++)
            {
                mangPort[i] = htmlTam.Substring(htmlTam.IndexOf(@"<script type=""text/javascript"">document.write(""<font class=spy2>:<\/font>""") + 76, htmlTam.IndexOf("</script></font></td><td colspan=1>") - htmlTam.IndexOf(@"<script type=""text/javascript"">document.write(""<font class=spy2>:<\/font>""")-78);
              htmlTam= htmlTam.Remove(htmlTam.IndexOf(@"<script type=""text/javascript"">document.write(""<font class=spy2>:<\/font>"""), htmlTam.IndexOf("</script></font></td><td colspan=1>") - htmlTam.IndexOf(@"<script type=""text/javascript"">document.write(""<font class=spy2>:<\/font>""") +76);

               

             
            }
            for (int i = 0; i < 30; i++)
            {
                string[] mangNoiPort = mangPort[i].Split(")+(");
                string ketQuaNoi = "";
                for(int j=0;j<mangNoiPort.Length;j++)
                {
                               for(int z = 0; z < 10; z++)
                    {
                        if(mangNoiPort[j]==mangPortMaHoa[z])
                        {
                            ketQuaNoi = ketQuaNoi + z.ToString();
                            break;
                        }    
                    }       
                        

                }
                mangPort[i] = ketQuaNoi;
                    
            }
            for(int i=0;i<=30; i++)
            {
 
               for(int j=i+1; j<30;j++)
                {
                    int soTruoc = Convert.ToInt32(mangTocDo[i]);
                    int soSau = Convert.ToInt32(mangTocDo[j]);
                    if (soTruoc < soSau)
                    {
                        string temp;
                        temp = mangTocDo[i];
                        mangTocDo[i] = mangTocDo[j];
                        mangTocDo[j] = temp;
                        temp = mangIP[i];
                        mangIP[i] = mangIP[j];
                        mangIP[j] = temp;
                        temp = mangPort[i];
                        mangPort[i] = mangPort[j];
                        mangPort[j] = temp;
                    } 
                       
                }    
            }    
           
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(mangIP[i] + ":" + mangPort[i]);// chỗ này có thể thay bằng nối chuỗi, xong return lại 1 mảng kết quả
            }



        }
    }
}
