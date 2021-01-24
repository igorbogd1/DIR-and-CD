using System;
using System.IO;

namespace CD
{
    class CD
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
            //
            AnalyzeCommand(args);
            Console.WriteLine(currentFolderPath);
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
                case "CD":
                    {

                        AnalyzeAttributesCD(currentCommandAttributes.Length == 1 ? "" : currentCommandAttributes[1]);
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

        static void AnalyzeAttributesCD(string currentAttributes)
        {

            if (currentAttributes == "")
                return;
            else if (currentAttributes == "-?")
            {
                ReadFileHelpandDisplay("helpcd.txt");
            }
            else
            {
                TakePathFolder(currentAttributes);
            }
        }

        static void TakePathFolder(string specifiedFolderPath)
        {
            int position = specifiedFolderPath.LastIndexOf('\\');
            if (specifiedFolderPath == "..")
                currentFolderPath = position < 0 ? currentFolderPath : currentFolderPath.Substring(0, position);
            else
            {
                if (position == (specifiedFolderPath.Length - 1))
                    specifiedFolderPath = specifiedFolderPath.Substring(0, specifiedFolderPath.Length - 1);

                if (!Directory.Exists(specifiedFolderPath))
                {
                    Console.WriteLine("Папка не найдена " + specifiedFolderPath);
                    return;
                }

                currentFolderPath = specifiedFolderPath;
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
