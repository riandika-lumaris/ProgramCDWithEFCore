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
using System.Windows.Shapes;


using CDClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MasterCdWindow.xaml
    /// </summary>
    public partial class MasterCdWindow : Window,INotifyPropertyChanged
    {
        private List<Cd> _data;
        private CdContext context = new CdContext();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Cd> Data {
            get => _data;
            set {
                _data = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Data"));
            }
        }

        public MasterCdWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private async Task LoadDataAsync()
        {
            Data = new List<Cd>(await context.Cd.ToArrayAsync());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataAsync();
        }

        private async void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            Cd cd = new Cd()
            {
                Kodecd = txtKodecd.Text,
                Judulcd = txtJudulcd.Text,
                Hrgsewa = Convert.ToInt16(txtHrgsewa.Text),
                Lamasw = Convert.ToByte(txtLamasw.Text)
            };
            if ((bool)cbStatusB.IsChecked)
                cd.Status = "B";
            else if ((bool)cbStatusR.IsChecked)
                cd.Status = "R";
            else if ((bool)cbStatusH.IsChecked)
                cd.Status = "H";

            context.Cd.Add(cd);
            await context.SaveChangesAsync();
            LoadDataAsync();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirm Delete","Confirmation",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Cd cd = dataGrid.SelectedItem as Cd;
                context.Cd.Remove(cd);
                await context.SaveChangesAsync();
                LoadDataAsync();
            }
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Cd cd = context.Cd.Find(txtKodecd.Text);
            cd.Judulcd = txtJudulcd.Text;
            cd.Hrgsewa = Convert.ToInt16(txtHrgsewa.Text);
            cd.Lamasw = Convert.ToByte(txtLamasw.Text);
            if ((bool)cbStatusB.IsChecked)
                cd.Status = "B";
            else if ((bool)cbStatusR.IsChecked)
                cd.Status = "R";
            else if ((bool)cbStatusH.IsChecked)
                cd.Status = "H";

            context.Cd.Update(cd);
            await context.SaveChangesAsync();
            LoadDataAsync();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Cd cd = dataGrid.SelectedItem as Cd;
            txtKodecd.Text = cd.Kodecd;
            txtJudulcd.Text = cd.Judulcd;
            txtHrgsewa.Text = cd.Hrgsewa.ToString();
            txtLamasw.Text = cd.Lamasw.ToString();
            switch (cd.Status)
            {
                case "B":
                    cbStatusB.IsChecked = true;
                    break;
                case "R":
                    cbStatusR.IsChecked = true;
                    break;
                case "H":
                    cbStatusH.IsChecked = true;
                    break;
            }
        }
    }
}
