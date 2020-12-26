using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folder_Tree
{
    class Program
    {
        private const int TREE_DRAW_OFFSET = 4;
        private const char CHAR_HLINE = (char)0x2500;
        private const char CHAR_VLINE = (char)0x2502;
        private const char CHAR_TJOINT = (char)0x251C;
        private const char CHAR_ANGLE = (char)0x2514;

        static void Main(string[] args)
        {
            string path = @"D:\Materiale Programare";
            string drive = path.Split('\\')[0];
            DirectoryInfo dir = new DirectoryInfo(path);
            Console.WriteLine("{0}.", drive);
            ShowTree(dir.GetDirectories(), "");

            Console.ReadLine();
        }

        private static void ShowTree(DirectoryInfo[] directories, string padding)
        {
            for (int i = 0; i < directories.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(padding);

                StringBuilder padBuilder = new StringBuilder();
                padBuilder.Append(padding);

                if (i < directories.Length - 1)
                {
                    sb.Append(CHAR_TJOINT);
                    padBuilder.Append(CHAR_VLINE);
                    padBuilder.Append(' ', TREE_DRAW_OFFSET - 1);
                }
                else
                {
                    sb.Append(CHAR_ANGLE);
                    padBuilder.Append(' ', TREE_DRAW_OFFSET);
                }

                sb.Append(CHAR_HLINE, TREE_DRAW_OFFSET - 1);
                sb.Append(directories[i]);

                Console.WriteLine(sb.ToString());
                ShowTree(directories[i].GetDirectories(), padBuilder.ToString());
            }
        }
    }
}
