using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Model
{

    public class Manager
    {
        private readonly string savingPath = Path.Combine(Directory.GetCurrentDirectory(), "../AnalyzedImage"); // do NOT modify this
        public ObservableList<ImageDownloader> Images
        {
            get => images;
            set
            {
                if (value != null)
                {
                    images = value;
                }
            }
        }
        private ObservableList<ImageDownloader> images;

        public Manager()
        {
            ImageDeleter();
            images = new ObservableList<ImageDownloader>();
            images.Add(new KeraunosImage());
            images.Add(new MeteocielImage());
        }

        public void ImageDeleter()
        {
            if (Directory.Exists(savingPath))
            {
                Directory.Delete(savingPath, true);
            }
        }
    }
}
