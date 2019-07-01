using System;
using System.IO;
using SensorAPI.Models;

namespace SensorAPI.Service
{
    public class SensorService
    {
        public void Write(SensorItem item)
        {
            string text = item.Id.ToString() + ";" + 
                          item.Tag + ";" + 
                          item.Timestamp.ToString() + ";" + 
                          item.Valor + Environment.NewLine;

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            File.AppendAllText(Path.Combine(docPath, "SensorLog.txt"), text);
        }
    }
}