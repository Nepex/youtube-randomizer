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

namespace YouTubeRandomizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = tbxVideoId.Text;

            YouTubeVideo video = new YouTubeVideo(searchQuery);
            lblVideoTitle.Content = video.query;


            System.Uri uri = new System.Uri(video.query);
            wbYouTubePlayer.Source = uri;
            wbYouTubePlayer.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
