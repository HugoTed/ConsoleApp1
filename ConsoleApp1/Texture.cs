using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Texture
    {
        public string name;
        public string sourcepath;
        public List<string> map = new List<string>();
        public List<string> normalMap = new List<string>();
        public List<string> meMap = new List<string>();
        public List<string> roughnessMap = new List<string>();
        public List<string> heightMap = new List<string>();
        public List<string> lightMap = new List<string>();
        public Dictionary<string, string> fbxlist = new Dictionary<string, string>();
        public Dictionary<string, string> jpglist = new Dictionary<string, string>();

        public Texture()
        {

        }
        public void createMaterial()
        {
            Console.WriteLine("输入生成文件名，省略.js");
            name = Console.ReadLine();
            Console.WriteLine("输入需要遍历路径");
            sourcepath = Console.ReadLine();
        }

        public void recordFile()

        {
            //遍历文件夹

            DirectoryInfo theFolder = new DirectoryInfo(sourcepath);




            FileInfo[] thefileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo NextFile in thefileInfo)
            { //遍历文件

                switch (NextFile.Extension)
                {
                    case ".FBX":
                        fbxlist.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                        break;
                    case ".jpg":
                        jpglist.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                        break;
                    case ".png":
                        jpglist.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                        break;
                    default:
                        fbxlist.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                        break;
                }
                if (NextFile.Name.Contains("Base_map"))
                {
                    map.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')));
                }
                if (NextFile.Name.Contains("Base_map"))
                {
                    map.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')));
                }
                if (NextFile.Name.Contains("Base_map"))
                {
                    map.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')));
                }
                if (NextFile.Name.Contains("Base_map"))
                {
                    map.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')));
                }
                if (NextFile.Name.Contains("Base_map"))
                {
                    map.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')));
                }

            }



            //遍历子文件夹

            DirectoryInfo[] dirInfo = theFolder.GetDirectories();

            foreach (DirectoryInfo NextFolder in dirInfo)

            {

                //list.Add(NextFolder.ToString());

                FileInfo[] fileInfo = NextFolder.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (FileInfo NextFile in fileInfo)  //遍历文件
                {

                    switch (NextFile.Extension)
                    {
                        case "FBX":
                            fbxlist.TryAdd(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                            break;
                        case "jpg":
                            jpglist.TryAdd(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                            break;
                        case ".png":
                            jpglist.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                            break;
                        default:
                            fbxlist.TryAdd(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                            break;
                    }
                    if (NextFile.Name.Contains("Base_map"))
                    {
                        map.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')));
                    }
                    if (NextFile.Name.Contains("Base_map"))
                    {
                        map.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')));
                    }
                    if (NextFile.Name.Contains("Base_map"))
                    {
                        map.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')));
                    }
                    if (NextFile.Name.Contains("Base_map"))
                    {
                        map.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')));
                    }
                    if (NextFile.Name.Contains("Base_map"))
                    {
                        map.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')));
                    }
                }

            }
        }
    }
}
