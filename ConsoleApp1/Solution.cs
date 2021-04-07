using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//1.如何获取指定目录包含的文件和子目录
//　　　　（1）.DirectoryInfo.GetFiles()：获取目录中（不包含子目录）的文件，返回类型为FileInfo[]，支持通配符查找；   
//　　　　 （2）.DirectoryInfo.GetDirectories()：获取目录（不包含子目录）的子目录，返回类型为DirectoryInfo[]，支持通配符查找；   
//　　　　（3）.DirectoryInfo.GetFileSystemInfos()：获取指定目录下（不包含子目录）的文件和子目录，返回类型为FileSystemInfo[]，支持通配符查找；
//　　2.如何获取指定文件的基本信息；   
//　　　　FileInfo.Exists：获取指定文件是否存在；   
//　　　　FileInfo.Name，FileInfo.Extensioin：获取文件的名称和扩展名；   
//　　　　FileInfo.FullName：获取文件的全限定名称（完整路径）；   
//　　　　FileInfo.Directory：获取文件所在目录，返回类型为DirectoryInfo；   
//　　　　FileInfo.DirectoryName：获取文件所在目录的路径（完整路径）；   
//　　　　FileInfo.Length：获取文件的大小（字节数）；   
//　　　　FileInfo.IsReadOnly：获取文件是否只读；   
//　　　　FileInfo.Attributes：获取或设置指定文件的属性，返回类型为FileAttributes枚举，可以是多个值的组合
//FileInfo.CreationTime、FileInfo.LastAccessTime、FileInfo.LastWriteTime：分别用于获取文件的创建时间、访问时间、修改时间；
namespace ConsoleApp1
{
    public class Solution
    {
        public string sSourcePath { get; set; }
        public Dictionary<string,string> fbxlist = new Dictionary<string, string>();
        public Dictionary<string, string> jpglist = new Dictionary<string, string>();

        public List<string> modules = new List<string>();

        public List<string> fileType = new List<string>();

        public Solution()
        {
            //Console.WriteLine("输入模板类，回车确认，00结束输入");
            //string m;
            //while ((m = Console.ReadLine()) != "00")
            //{
            //    modules.Add(m);
            //}
            Console.WriteLine("输入文件夹路径");
            sSourcePath = @Console.ReadLine();

        }

        //public List<string> FindFiles(string sourcePath)
        //{
        //    DirectoryInfo Dir = new DirectoryInfo(sourcePath);


        //    DirectoryInfo[] DirSub = Dir.GetDirectories();

        //    if (DirSub.Length <= 0)
        //    {

        //        foreach (FileInfo f in Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly)) //查找文件
        //        {

        //            //listBox1.Items.Add(Dir+f.ToString()); //listBox1中填加文件名

        //            list.Add(Dir + @"\" + f.ToString());

        //        }

        //    }


        //    int t = 1;

        //    foreach (DirectoryInfo d in DirSub)//查找子目录 
        //    {

        //        FindFiles(d.ToString());

        //        list.Add(d.ToString());

        //        if (t == 1)
        //        {

        //            foreach (FileInfo f in Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly)) //查找文件
        //            {

        //                list.Add(f.ToString());

        //            }

        //            t = t + 1;
        //        }

        //    }

        //    return list;
        //}

        public void FindFile2()

        {
            //遍历文件夹

            DirectoryInfo theFolder = new DirectoryInfo(sSourcePath);
            
            foreach (var item in theFolder.GetDirectories())
            {
                //string Foldername = item.Name;
                //Console.WriteLine(Foldername);
                //if (char.IsDigit(Foldername[0]))
                //    Foldername[0] = 'I';
                modules.Add(item.Name);
            }

            
            
            FileInfo[] thefileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo NextFile in thefileInfo)
            { //遍历文件
                
                switch (NextFile.Extension){
                    case ".FBX" :
                        fbxlist.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                        break;
                    case ".jpg" :
                        jpglist.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                        break;
                    case ".png":
                        jpglist.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                        break;
                    default:
                        fbxlist.Add(NextFile.Name.Remove(NextFile.Name.IndexOf('.')), NextFile.FullName);
                        break;
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
                }

            }

           // return list;
        }
        public void printFileList()
        {
            foreach (var item in fbxlist)
            {
                Console.WriteLine(item);
            }
            foreach (var item in jpglist)
            {
                Console.WriteLine(item);
            }
            foreach (var item in modules)
            {
                Console.WriteLine(item);
            }
        }
        public void printFileTypeList()
        {
            foreach (var item in fileType)
            {
                Console.WriteLine(item);
            }
            
        }


        public void GenerateConfJS()
        {
            Console.WriteLine("输入生成路径");
            string path = @Console.ReadLine();
            path += "/conf_1.js";
            FileStream confJS = new FileStream(path, FileMode.Create);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (StreamWriter sw = new StreamWriter(confJS))
            {
                sw.WriteLine("import base from './modules/base.js'");
                foreach (var item in modules)
                {
                    sw.WriteLine($"import {item} from \"@/xbThreeFrame/modules/{item}.js\";");
                }
                sw.WriteLine();
                sw.WriteLine("const baseURL = process.env.BASE_URL;");
                sw.WriteLine();
                sw.WriteLine("export const modelsConf = [");
                foreach (var item in fbxlist)
                {
                    sw.WriteLine($"    {{ name: '{item.Key.Remove(item.Key.IndexOf('.'))}', path: `${{baseURL}}{item.Value}`, type: 'fbx', index: 1 }},");
                }
                sw.WriteLine("];");
                sw.WriteLine();
                sw.WriteLine("export const texturesConf = [");
                foreach (var item in jpglist)
                {
                    sw.WriteLine($"    {{ name: '{item.Key.Remove(item.Key.IndexOf('.'))}', path: `${{baseURL}}{item.Value}`, type: 'jpg'}},");
                }
                sw.WriteLine("];");
                sw.WriteLine("/**");
                sw.WriteLine(" * 在意顺序");
                sw.WriteLine(" * @returns {*[]}");
                sw.WriteLine(" */");
                sw.WriteLine("let modulesConf = [");
                foreach (var item in modules)
                {
                    sw.WriteLine($"    {item},");
                }
                sw.WriteLine("];");
                sw.WriteLine("const no3d = window.location.href.includes(\"no3d\")");
                sw.WriteLine("if (no3d) {");
                sw.WriteLine("    modulesConf = [base]");
                sw.WriteLine("}");
                sw.WriteLine("export { modulesConf };");

                sw.Close();

            }
            Console.WriteLine("Done");
        }
    
        
    }
}
