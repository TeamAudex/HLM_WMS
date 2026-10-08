using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Repository
{
  public class RequestResponseLog
    {

        public void FileCreate(string filepath,string fileName, string Request, string Action)
        {

            try
            {
               
                if (!File.Exists(fileName))
                {
                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }


                    using (FileStream fs = File.Create(fileName))
                    {
                    
                        Byte[] title = new UTF8Encoding(true).GetBytes(Action+"\n");
                        fs.Write(title, 0, title.Length);
                        byte[] req = new UTF8Encoding(true).GetBytes(Request+"\n");
                        fs.Write(req, 0, req.Length);
                    }


                    using (StreamReader sr = File.OpenText(fileName))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }


                }

                else
                {
                    using (StreamWriter sw = new StreamWriter(fileName, append: true))
                    {
                        sw.WriteLine("\n"+Action+"\n"+Request);
                        sw.Flush();
                    }
                }
                   
              
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

        }

        public void FileCreate1(string fileName, string Request, string Action)
        {

            try
            {
                FileInfo f = new FileInfo(fileName);
                if (!f.Exists)
                {
                    string FilePath = Path.GetDirectoryName(fileName);
                    Directory.CreateDirectory(FilePath);
                }
                if (!File.Exists(fileName))
                {
                    using (FileStream fs = File.Create(fileName))
                    {

                        Byte[] title = new UTF8Encoding(true).GetBytes(Action + " :" + "\n");
                        fs.Write(title, 0, title.Length);
                        byte[] req = new UTF8Encoding(true).GetBytes(Request + "\n");
                        fs.Write(req, 0, req.Length);
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(fileName, append: true))
                    {
                        sw.WriteLine("\n" + Action + " :" + "\n" + Request);
                        sw.Flush();
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

        }

        public void FileCreate2(string fileName, string Request, string Action)
        {

            try
            {
                FileInfo f = new FileInfo(fileName);
                if (!f.Exists)
                {
                    string FilePath = Path.GetDirectoryName(fileName);
                    Directory.CreateDirectory(FilePath);
                }
                if (!File.Exists(fileName))
                {
                    using (FileStream fs = File.Create(fileName))
                    {

                        Byte[] title = new UTF8Encoding(true).GetBytes(Action + "" + "\n");
                        fs.Write(title, 0, title.Length);
                        byte[] req = new UTF8Encoding(true).GetBytes(Request + "\n");
                        fs.Write(req, 0, req.Length);
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(fileName, append: true))
                    {
                        sw.WriteLine("\n" + Action + "" + "\n" + Request);
                        sw.Flush();
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

        }

    }
}
