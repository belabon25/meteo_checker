using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ImageDownloader : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal string SavingPath { get => savingPath; }
        private string savingPath = Path.Combine(Directory.GetCurrentDirectory(), "../AnalyzedImage");

        public string ImageLocalisation { get => imageLocalisation; }
        internal string imageLocalisation;
        public string HourPic
        {
            get => hourPic;
            set
            {
                hourPic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HourPic)));
            }
        }
        private string hourPic;
        public string Nom
        {
            get => nom;

            set
            {
                nom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nom)));
            }
        }
        private string nom;

        public string CompleteSavingPath
        {
            get => completeSavingPath;

            set
            {
                completeSavingPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CompleteSavingPath)));
            }
        }
        private string completeSavingPath;

        public void GetRadarImage()
        {
            WebClient request = new WebClient();
            if (!Directory.Exists(savingPath))
            {
                Directory.CreateDirectory(savingPath);
            }
            request.DownloadFile(imageLocalisation, CompleteSavingPath);
        }
    }


}
