using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using API;

namespace R6DB_Soft
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void UDStats()
        {
            try
            {
                string jsonString = await AccessTheWebAsync(Soft.GetURL("Max-RAVN", "uplay"));
                var result = Stats.FromJson(jsonString);
                casual_wins.Text = result.Player.Stats.Casual.Wins.ToString();
                casual_losses.Text = result.Player.Stats.Casual.Losses.ToString();
                casual_wl.Text = result.Player.Stats.Casual.Wlr.ToString();
                casual_kills.Text = result.Player.Stats.Casual.Kills.ToString();
                casual_deaths.Text = result.Player.Stats.Casual.Deaths.ToString();
                casual_kd.Text = result.Player.Stats.Casual.Kd.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public async Task<string> AccessTheWebAsync(string url)
        {
            HttpClient client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync(url);
            string urlContents = await getStringTask;
            return urlContents;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UDStats();
        }
    }
}
