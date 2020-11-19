using System.Data;
using System.Data.SqlClient;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ClassAct.Website.PL
{
    public  class ImageSerilaizer
    {
        public static byte[] imgageToDB(FileInfo info)
        {
            byte[] content = new byte[info.Length];
            FileStream imageStream = info.OpenRead();
            imageStream.Read(content, 0, content.Length);
            imageStream.Close();
            return content;
        }
    }
    }