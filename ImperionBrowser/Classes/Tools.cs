using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ImperionBrowser
{
    class Tools
    {
        public static void SaveCookies(WebBrowser wb, string iDestinationPath)
        {
            StreamWriter sw = new StreamWriter(iDestinationPath,false);

            try
            {
                char[] sep = { ';' };
                string[] elements = wb.Document.Cookie.Split(sep);

                foreach (string s in elements)
                    sw.WriteLine(s);
            }
            catch { }

            sw.Close();
            sw.Dispose();
        }

        public static CookieContainer ReadCookiesAsCollection(Uri iUri, string iSourcePath)
        {
            StreamReader sr = new StreamReader(iSourcePath);
            CookieContainer cc = new CookieContainer();
            
            Cookie c;
            char[] sep = {'='};
            string[] elements;
            string curLine;
            try
            {
                while (!sr.EndOfStream)
                {
                    curLine = sr.ReadLine();
                    if (curLine != String.Empty)
                    {
                        elements = curLine.Split(sep);
                        c = new Cookie(elements[0], elements[1]);
                        cc.Add(iUri, c);
                    }
                }
            }
            catch {}

            sr.Close();
            sr.Dispose();

            return cc;
        }


    }
}
