using System;
using System.IO;
using CryptoPerformers.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace CryptoPerformers.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}