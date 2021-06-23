using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SurveillanceMeteo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Manager manager;
        public MainWindow()
        {
            InitializeComponent();
            manager = new Manager();
            DataContext = manager;
            listeImages.SelectionChanged += ListeImages_SelectionChanged;
            listeImages.SelectedItem = manager.Images[0];
            DispatcherTimer dispacher = new DispatcherTimer();
            dispacher.Tick += Dispacher_Tick;
            dispacher.Interval = new TimeSpan(0, 1, 0);
            dispacher.Start();
        }

        private void Dispacher_Tick(object sender, EventArgs e)
        {
            MeteocielImage image = new MeteocielImage();
            if (!string.Equals(image.ImageLocalisation, manager.Images.Last().ImageLocalisation))
            {
                manager.Images.Add(image);
                listeImages.SelectedItem = manager.Images.Last();
            }        
        }

        private void ListeImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listeImages.SelectedItem is MeteocielImage)
            {
                CCDetail.Content = new RadarUC();
                CCDetail.DataContext = listeImages.SelectedItem as MeteocielImage;
            }
            if (listeImages.SelectedItem is KeraunosImage)
            {
                CCDetail.Content = new KeraunosUC();
                CCDetail.DataContext = listeImages.SelectedItem as KeraunosImage;
            }
        }
    }
}
