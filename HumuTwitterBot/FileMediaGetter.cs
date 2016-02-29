using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HumuTwitterBot
{
    public static class FileMediaGetter
    {

        public static string getFileItem(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            Random rand = new Random();
            int randomLineNumber = rand.Next(0, lines.Length);
            string ChosenItem = lines[randomLineNumber];
            return ChosenItem;
        }
    }
}
