using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public class MeteocielImage : ImageDownloader, INotifyPropertyChanged
    {
        public static int NbImages => nbImages;
        private static int nbImages;

        public MeteocielImage()
        {
            nbImages++;
            CompleteSavingPath = SavingPath + "\\Radar" + NbImages + ".jpg";

            DateTime dateImage = DateTime.Now;
            TimeSpan dateHeures = DateTime.Now.TimeOfDay;
            int intermediary = dateHeures.Minutes - (dateHeures.Minutes % 5); // Taking the picture 10 min earlier, to be sure that it exists.
            TimeSpan timeOfDay = new TimeSpan(DateTime.Now.TimeOfDay.Hours - 2, intermediary, 0); // the date of the image is two hours earlier than the french timezone for some reasons
            HourPic = (timeOfDay+TimeSpan.FromHours(2)).ToString();
            Nom = HourPic;
            if (Int32.Parse(dateImage.ToString("dd")) > 10)
            { 
            
            imageLocalisation = "http://modeles14.meteociel.fr/radar/tiles/" + dateImage.ToString("yyyy/M/dd") + "/1/" + dateImage.ToString("yyyyMMdd") + $"{timeOfDay.Hours.ToString("00")}" + $"{timeOfDay.Minutes.ToString("00")}" + "-0-0.png?";
            }
            else
            {              
            imageLocalisation = "http://modeles14.meteociel.fr/radar/tiles/" + dateImage.ToString("yyyy/M/d") + "/1/" + dateImage.ToString("yyyyMMdd") + $"{timeOfDay.Hours.ToString("00")}" + $"{timeOfDay.Minutes.ToString("00")}" + "-0-0.png?";
            }
            try
            {
                GetRadarImage();
            }
            catch (Exception e)
            {
                _ = e;
                timeOfDay = new TimeSpan(DateTime.Now.TimeOfDay.Hours - 2, intermediary-5, 0); // the date of the image is two hours earlier than the french timezone for some reasons
                imageLocalisation = "http://modeles14.meteociel.fr/radar/tiles/" + dateImage.ToString("yyyy/M/dd") + "/1/" + dateImage.ToString("yyyyMMdd") + $"{timeOfDay.Hours.ToString("00")}" + $"{timeOfDay.Minutes.ToString("00")}" + "-0-0.png?";
                try
                {
                    GetRadarImage();
                }
                catch (Exception e2)
                {
                    Debug.WriteLine(e2.ToString());
                }
            }
            
        }
    }
}
