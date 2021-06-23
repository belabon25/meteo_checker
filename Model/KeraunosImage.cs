using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KeraunosImage : ImageDownloader
    {
        public KeraunosImage()
        {
            Nom = "Prévisions Keraunos.org";
            CompleteSavingPath = SavingPath + "\\Keraunos.png";
            imageLocalisation = "https://www.keraunos.org/img/prevision-orages-tornades-keraunos.png?";
            GetRadarImage();
        }
    }
}
