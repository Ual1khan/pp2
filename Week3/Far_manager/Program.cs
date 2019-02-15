using System;
using System.IO;

namespace Ex1
{
    class FarManager
    {
        public int cursor;
        public string path;
        public int sz;
        public bool ok;
        DirectoryInfo directory = null;
        FileSystemInfo currentFs = null;

        public FarManager()
        {
            cursor = 0;
        }

        public FarManager(string path)
        {
            this.path = path;
            cursor = 0;
            directory = new DirectoryInfo(path);
            sz = directory.GetFileSystemInfos().Length;
            ok = true;
        }

        public void Color(FileSystemInfo fs, int index)
        {
            if (cursor == index)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                currentFs = fs;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            directory = new DirectoryInfo(path);


            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            FileSystemInfo[] curfs = directory.GetFileSystemInfos();
            int pos = 0;
            int tt = 1;
            for (int i = 0; i < curfs.Length; ++i)
            {
                if (ok == false && curfs[i].Name[0] == '.')
                {
                    continue;
                }
                if (curfs[i] is DirectoryInfo)
                {
                    fs[pos++] = curfs[i];
                }
            }
            for (int i = 0; i < curfs.Length; ++i)
            {
                if (ok == false && curfs[i].Name[0] == '.')
                {
                    continue;
                }
                if (curfs[i] is FileInfo)
                {
                    fs[pos++] = curfs[i];
                }
            }


            for (int i = 0; i < fs.Length; i++)
            {
                if (ok == false && fs[i].Name[0] == '.')
                {
                    continue;
                }
                if (fs[i] is DirectoryInfo)
                {
                    string ss = Convert.ToString(tt);
                    Color(fs[i], i);
                    Console.WriteLine(ss + ". " + fs[i].Name);
                    tt++;

                }
            }

            for (int i = 0; i < fs.Length; i++)
            {
                if (ok == false && fs[i].Name[0] == '.')
                {
                    continue;
                }
                if (fs[i] is FileInfo)
                {
                    string ss = Convert.ToString(tt);
                    Color(fs[i], i);
                    Console.WriteLine(ss + ". " + fs[i].Name);
                    tt++;

                }
            }


        }

        public void Delete()
        {
            for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
            {
                if (cursor == i)
                {
                    try
                    {
                        directory.GetFileSystemInfos()[i].Delete();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.Write("Cannot get an access");
                        Console.ReadKey();
                    }
                }
            }
        }

        public void Open()
        {
            FileInfo fileinf = new FileInfo(path);


            Console.Clear();
            try
            {
                using (StreamReader reader = new StreamReader(@"" + fileinf.FullName + "" + @"\" + directory.GetFileSystemInfos()[cursor]))
                {

                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }


                        Console.WriteLine(line); // Use line.

                    }
                    Console.ReadKey();
                }
            }

            catch (Exception )
            {
                Console.Write("Not txt file");
                Console.ReadKey();
            }

        }


        public void Rename()
        {

            FileInfo fileinf = new FileInfo(path);
            FileSystemInfo fn = directory.GetFileSystemInfos()[cursor];
            if (fn is DirectoryInfo)
            {
                Console.WriteLine("Set name for " + fileinf.FullName + @"\" + directory.GetFileSystemInfos()[cursor]);
                string str = Console.ReadLine();
                string old_name = @"" + fileinf.FullName + @"\" + directory.GetFileSystemInfos()[cursor];
                string new_name = @"" + fileinf.FullName + @"\" + str;
                Directory.Move(old_name, new_name);
            }
            else
            {
                try
                {
                    Console.WriteLine("Set name for " + fileinf.FullName + @"\" + directory.GetFileSystemInfos()[cursor]);
                    string str = Console.ReadLine();

                    File.Move(@"" + fileinf.FullName + @"\" + directory.GetFileSystemInfos()[cursor], @"" + fileinf.FullName + @"\" + str);



                    Console.ReadKey();
                }
                catch (Exception )
                {
                    Console.Write("Cannot get an access");
                    Console.ReadKey();
                }
            }


        }

        public void Up()
        {
            cursor--;
            if (cursor < 0)
                cursor = sz - 1;
        }
        public void Down()
        {
            cursor++;
            if (cursor == sz)
                cursor = 0;
        }



        public void CalcSz()
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            sz = fs.Length;
            if (ok == false)
                for (int i = 0; i < fs.Length; i++)
                    if (fs[i].Name[0] == '.')
                        sz--;
        }

        public void Start()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            while (consoleKey.Key != ConsoleKey.Escape)
            {
                CalcSz();
                Show();
                consoleKey = Console.ReadKey();

                if (consoleKey.Key == ConsoleKey.Delete)
                    Delete();



                if (consoleKey.Key == ConsoleKey.O)
                    Open();

                if (consoleKey.Key == ConsoleKey.R)
                    Rename();


                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.RightArrow)
                {
                    ok = false;
                    cursor = 0;
                }
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                {
                    cursor = 0;
                    ok = true;
                }
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        path = currentFs.FullName;
                    }
                }
                if (consoleKey.Key == ConsoleKey.Backspace)
                {
                    try
                    {
                        cursor = 0;
                        path = directory.Parent.FullName;
                    }
                    catch (Exception )
                    {
                        Console.Write("Cannot move back");
                        Console.ReadKey();
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/users";
            FarManager farManager = new FarManager(path);
            farManager.Start();
        }
    }
}