using System;
using System.IO;
using System.Text;

namespace AlgorithmIntro
{
    class File
    {
        /// <summary>
        /// Prints the file informations on to console
        /// </summary>
        /// <param name="path">Path to the file</param>
        public static void FileInfo(string path)
        {
            try
            {
                FileInfo info = new FileInfo(path);
                Console.WriteLine($"\n\n  " +
                    $"Name                : {info.Name}\n  " +
                    $"Full File Extension : {info.FullName}\n\n\n  " +
                    $"Created        : {info.CreationTime}\n  " +
                    $"Modified       : {info.LastWriteTime}\n  " +
                    $"Accessed       : {info.LastAccessTime}\n\n\n  " +
                    $"Size           : {info.Length} Bytes");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t-> File.FileInfo(string path)");
            }
        }




        /// <summary>
        /// Creates a new file with type of "extension" in the project with given name
        /// </summary>
        /// <param name="fileName">Name to new file</param>
        /// <param name="extension">Extension of new file</param>
        /// <remarks>Replaces the file with a new one if it already exists</remarks>
        public static void Create(string fileName, string extension)
        {
            try
            {
                string[] path = Directory.GetCurrentDirectory().Split('\\');
                string trimedPath = "";
                for (int i = 0; i < path.Length - 3; i++)
                {
                    trimedPath += path[i] + "\\";
                }
                trimedPath += fileName + "." + extension;
                using (StreamWriter sw = new StreamWriter(trimedPath)) { }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t-> File.Create(string fileName, string extension)");
            }
        }

        /// <summary>
        /// Creates a new file with type of "extension" in the given path with given name
        /// </summary>
        /// <param name="fileName">New name to file</param>
        /// <param name="path">Path to create</param>
        /// <param name="extension">Extension of new file</param>
        /// <remarks>Replaces the file with a new one if it already exists</remarks>
        public static void Create(string fileName, string path, string extension)
        {
            try
            {
                path += "\\" + fileName + "." + extension;
                using (StreamWriter sw = new StreamWriter(path)) {}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t-> File.Create(string fileName, string path, string extension)");
            }
        }




        /// <summary>
        /// Creates a new .txt file and fill it with given text
        /// </summary>
        /// <param name="txtPath"></param>
        /// <param name="text"></param>
        /// <remarks>If the file already exists delete all the content in the file and write the given text inside!</remarks>
        public static void Write(string path, string fileName, string text)
        {
            try
            {
                path += "\\" + fileName + ".txt";
                using (StreamWriter sw = new StreamWriter(path)) 
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t-> File.Write(string path, string fileName, string text)");
            }
        }

        /// <summary>
        /// Creates a new .txt file and fill it with given string matrix
        /// </summary>
        /// <param name="txtPath"></param>
        /// <param name="texts"></param>
        /// <remarks>If the file already exists delete all the content in the file and write the given text inside!</remarks>
        public static void Write(string path, string fileName, string[] texts)
        {
            try
            {
                path += "\\" + fileName + ".txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (string text in texts)
                        sw.WriteLine(text);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t-> File.Write(string path, string fileName, string[] texts)");
            }
        }




        /// <summary>
        /// Adds the given text to end of the given file in one line
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <param name="text">Text to fill</param>
        /// <remarks>Creates a new file if the given file does not exist!</remarks>
        public static void Add(string filePath, string text)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    byte[] write = Encoding.UTF8.GetBytes(text);
                    fs.Write(write);
                    fs.WriteByte(13);
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t-> File.Add(string filePath, string text)");
            }
        }

        /// <summary>
        /// Adds given texts to end of the given file with one line space
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <param name="texts">Text matrix to fill</param>
        /// <remarks>Creates a new file if the given file does not exist!</remarks>
        public static void Add(string filePath, string[] texts)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    foreach (string item in texts)
                    {
                        byte[] write = Encoding.UTF8.GetBytes(item);
                        fs.Write(write);
                        fs.WriteByte(13);
                    }
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t-> File.Add(string filePath, string[] texts)");
            }
        }




        /// <summary>
        /// Reads .txt file
        /// </summary>
        /// <param name="txtPath">Path to .txt file</param>
        public static void Read(string txtPath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(txtPath))
                {
                    string line;
                    int i = 1;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($" {i,-2} >  {line}");
                        i++;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t-> File.Read(string txtPath)");
            }
        }
        



        /// <summary>
        /// Copies the file to the given destination
        /// </summary>
        /// <param name="filePath">Path of file to copy</param>
        /// <param name="copyTo_Path">Path to copy</param>
        /// <param name="newFileName">Name of new file</param>
        public static void CopyTo(string filePath, string copyTo_Path, string newFileName)
        {
            try
            {
                FileInfo fI = new FileInfo(filePath);
                fI.CopyTo(copyTo_Path + "\\" + newFileName + fI.Extension);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t-> File.CopyTo(string filePath, string copyTo_Path, string newFileName)");
            }
        }




        /// <summary>
        /// Deletes the file in the path
        /// </summary>
        /// <param name="path">Path of file to delete</param>
        /// <remarks>Path must have file extension</remarks>
        public static void Delete(string path)
        {
            try
            {
                FileInfo fI = new FileInfo(path);
                fI.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t-> File.Delete(string path)");
            }
        }
    }
}