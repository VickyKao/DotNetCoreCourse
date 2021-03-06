﻿using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FileLab
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputFileSystemInfo();
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

            WorkWithFiles();
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }


        public static void OutputFileSystemInfo()
        {
            Console.WriteLine($"正在執行作業系統的資訊");
            Console.WriteLine($"OS:                        {RuntimeInformation.OSDescription}");
            Console.WriteLine($"Framework:                 {RuntimeInformation.FrameworkDescription}");
            Console.WriteLine($"OS Architecture            {RuntimeInformation.OSArchitecture}");
            Console.WriteLine($"Process Architecture       {RuntimeInformation.ProcessArchitecture}");
            Console.WriteLine($"{Environment.NewLine}正在執行作業系統的檔案系統相關資訊");
            Console.WriteLine($"Path.PathSeparator:              {Path.PathSeparator}");
            Console.WriteLine($"Path.DirectorySeparatorChar:     {Path.DirectorySeparatorChar}");
            Console.WriteLine($"Directory.GetCurrentDirectory(): {Directory.GetCurrentDirectory()}");
            Console.WriteLine($"Environment.CurrentDirectory:    {Environment.CurrentDirectory}");
            Console.WriteLine($"Environment.SystemDirectory:     {Environment.SystemDirectory}");
            Console.WriteLine($"Path.GetTempPath():              {Path.GetTempPath()}");
            Console.WriteLine($"GetFolderPath(SpecialFolder):");
            Console.WriteLine($"  System:                        {Environment.GetFolderPath(Environment.SpecialFolder.System)}");
            Console.WriteLine($"  ApplicationData:               {Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}");
            Console.WriteLine($"  MyDocuments:                   {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}");
            Console.WriteLine($"  Personal:                      {Environment.GetFolderPath(Environment.SpecialFolder.Personal)}");
        }

        public static void WorkWithFiles()
        {
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}目錄與檔案的操作");

            // 定義要存取的自訂路徑 
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var customFolder = new string[]
                { userFolder, "MiniASP", "NETCore", "OutputFiles" };

            // 善用 Path.Combine 產生跨作業系統平台的路徑分隔字元
            string dir = Path.Combine(customFolder);
            Console.WriteLine($"{Environment.NewLine}產生目錄");
            Console.WriteLine($"Directory Path: {dir}");
            Directory.CreateDirectory(dir);

            // 定義要處理檔案的完整工作路徑
            string textFile = Path.Combine(dir, "Dummy.txt");
            string backupFile = Path.Combine(dir, "Dummy.bak");

            // 檢查檔案是否存在 
            Console.WriteLine($"{Environment.NewLine}檢查檔案是否存在");
            Console.WriteLine($"檔案名稱: {textFile}");
            Console.WriteLine($"Does it exist? {File.Exists(textFile)}  ");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

            // 產生新的檔案與寫入內容
            Console.WriteLine($"{Environment.NewLine}產生新的檔案與寫入內容");
            Console.WriteLine($"檔案名稱: {textFile}");
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Close(); // close file and release resources

            Console.WriteLine($"Does it exist? {File.Exists(textFile)}  ");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

            // 複製檔案 
            Console.WriteLine($"{Environment.NewLine}複製檔案");
            Console.WriteLine($"來源檔案名稱: {textFile}");
            Console.WriteLine($"目的檔案名稱: {backupFile}");
            File.Copy(
                sourceFileName: textFile,
                destFileName: backupFile,
                overwrite: true);

            Console.WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

            Console.WriteLine("Confirm the files exist, and then press ENTER: ");
            Console.ReadKey();

            // 刪除檔案 
            Console.WriteLine($"{Environment.NewLine}刪除檔案");
            Console.WriteLine($"檔案名稱: {textFile}");
            File.Delete(textFile);

            Console.WriteLine($"Does {textFile}  exist? {File.Exists(textFile)}");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

            // 讀取檔案內容
            Console.WriteLine($"{Environment.NewLine}讀取檔案內容");
            Console.WriteLine($"檔案名稱: {backupFile}");
            StreamReader textReader = File.OpenText(backupFile);
            Console.WriteLine(textReader.ReadToEnd());
            textReader.Close();

            Console.WriteLine($"File Name: {Path.GetFileName(textFile)}");
            Console.WriteLine($"File Name without Extension: {Path.GetFileNameWithoutExtension(textFile)}");
            Console.WriteLine($"File Extension: {Path.GetExtension(textFile)}");
            Console.WriteLine($"Random File Name: {Path.GetRandomFileName()}");
            Console.WriteLine($"Temporary File Name: {Path.GetTempFileName()}");

            var info = new FileInfo(backupFile);
            Console.WriteLine($"{backupFile}:");
            Console.WriteLine($"  Contains {info.Length} bytes");
            Console.WriteLine($"  Last accessed {info.LastAccessTime}");
            Console.WriteLine($"  Has readonly set to {info.IsReadOnly}");

            Console.WriteLine($"Compressed? {info.Attributes.HasFlag(FileAttributes.Compressed)}");

        }


    }
}
