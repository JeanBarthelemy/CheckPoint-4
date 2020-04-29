using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using System.IO;
using Newtonsoft.Json;

namespace Checkpoint4
{
    public class DataBaseModule : NancyModule
    { /*
        public DataBaseModule()
        {
            Get("/file/get/{path}", parameters => ReturnFileSelected(parameters.path));
            Get("/file/put/{path}", parameters => AddNewFile(parameters.path));
        }

        public static string ReturnFileSelected(string path)
        {
            Files file = new Files(path);
            string filePath = "test-files/" + path;
            if (File.Exists(filePath))
            {
                file.Name = Path.GetFileNameWithoutExtension(path);
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var streamReader = new StreamReader(fileStream, Encoding.UTF8);
                string fileContent = streamReader.ReadToEnd();
                file.Content = fileContent;
                string fileJson = JsonConvert.SerializeObject(file);
                streamReader.Close();
                return fileJson;
            }
            else
            {
                return "File not existing";
            }
        } */
    }
}
