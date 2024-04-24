using Microsoft.EntityFrameworkCore;
using RealEstate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        IngatlanContext context = new IngatlanContext();
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public ObservableCollection<Seller> Sellers { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            context.Sellers.Load();
            context.RealEstates.Load();
            Sellers = context.Sellers.Local.ToObservableCollection();
        }

        private void adLoad_BTN_Click(object sender, RoutedEventArgs e)
        {
            Seller selected = (Seller)names_LB.SelectedItem;
            if (selected != null)
            {
                Count = context.RealEstates.Local.Where(x => x.seller.id == selected.id).Count();
                adNumResult_Lbl.Content = count;
            }
        }

        public void OnPropertyChanged(string tulajdonsagnev)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagnev));
        }
    }
}
