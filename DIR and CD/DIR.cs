using System;
using System.IO;

namespace DIR
{
    class Program
    {
        static public string currentFolderPath = "C:";

        static void Main(string[] args)
        {

            //while (true)
            //{
            //Console.Write(currentFolderPath + (currentFolderPath.Length == 2 ? @"\>" : ">"));

            //if (ParseCommand(((Console.ReadLine()).Trim()).ToUpper()))
            //break;
            //}
            AnalyzeCommand(args);
            Console.ReadKey();
        }

        static bool ParseCommand(string st)
        {
            if (st == "")
                return false;

            string[] ParserSts = st.Split(' ');//,StringSplitOptions.RemoveEmptyEntries);

            //foreach (var ParserSt in ParserSts)
            //{
            //    Console.WriteLine(ParserSt);
            //}

            return AnalyzeCommand(ParserSts);
        }

        static bool AnalyzeCommand(string[] currentCommandAttributes)
        {
            if (currentCommandAttributes.Length == 0)
                return false;

            switch (currentCommandAttributes[0].ToUpper())
            {
                //case "EXIT":
                //return true;               
                case "DIR":
                    {
                        if (currentCommandAttributes.Length == 1)
                            AnalyzeAttributesDir("-A");

                        TakePathFolder(currentCommandAttributes[1]);
                        AnalyzeAttributesDir(currentCommandAttributes.Length == 1 ? "-A" : currentCommandAttributes[1].ToUpper());
                        return false;
                    }
                case "-?":
                    {
                        ReadFileHelpandDisplay("help.txt");
                        return false;
                    }
                default:
                    {
                        Console.WriteLine(currentCommandAttributes[0] + "не является командой");
                        return false;
                    }
            }
        }

        static bool TakePathFolder(string specifiedFolderPath)
        {
            return false;
        }

        static void AnalyzeAttributesDir(string currentAttributes)
        {
            if (currentAttributes == "-A")
                DisplayFolder(1);
            else if (currentAttributes == "-B")
                DisplayFolder(2);
            else if (currentAttributes == "-C")
                DisplayFolder(3);
            else if (currentAttributes == "-?")
            {
                ReadFileHelpandDisplay("helpdir.txt");
            }
            else
            {
                Console.WriteLine("Недопустимый ключ:" + currentAttributes);
            }
        }
        static void DisplayFolder(byte Key)
        {
            DirectoryInfo theFolder = new DirectoryInfo(currentFolderPath + (currentFolderPath.Length == 2 ? @"\" : ""));

            if (Key == 1 || Key == 2)
            {
                foreach (DirectoryInfo nextFolder in theFolder.GetDirectories())
                {
                    Console.WriteLine("{0} " + "<DIR>" + " {1} ", nextFolder.CreationTime, nextFolder.Name);
                }
            }

            if (Key == 1 || Key == 3)
            {
                foreach (FileInfo nextFile in theFolder.GetFiles())
                {
                    Console.WriteLine("{0} " + "     " + " {1} ", nextFile.CreationTime, nextFile.Name);
                }
            }
        }

        static void ReadFileHelpandDisplay(string chosenFile)
        {
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\" + chosenFile);
            string nextLine;

            while ((nextLine = sr.ReadLine()) != null)
            {
                Console.WriteLine(nextLine);
            }
            sr.Close();
        }

    }
}
