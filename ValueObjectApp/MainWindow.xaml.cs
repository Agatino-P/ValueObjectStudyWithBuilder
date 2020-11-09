using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ValueObjectApp
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

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            //** Invalid because of private constructor
            //CoupleDouble coupleDouble1 = new CoupleDouble(5, 7);
            
            CoupleDouble coupleDouble1  = new CoupleDouble.Builder().WithX(1).WithY(2).Build();

            //** Non ha senso, si usa direttamente coupleDouble1 
            //coupleDouble2 = new CoupleDouble(coupleDouble1); //if co

            //**Invalid, private setter 
            //coupleDouble2.X = 4;

            CoupleDouble coupleDouble2 = new CoupleDouble.Builder().WithCopy(coupleDouble1).WithX(10).Build();

            CoupleDouble coupleDouble3 = new CoupleDouble.Builder().WithY(-1).Build();

            CoupleDouble coupleDouble4 = new CoupleDouble.Builder().WithX(1).WithY(2).Build();
            
            CoupleDouble coupleDouble5 = coupleDouble4;

            bool areEqual1and2 = (coupleDouble1 == coupleDouble2);
            bool areEqual1and3 = (coupleDouble1 == coupleDouble2);
            bool areEqual1and4 = (coupleDouble1 == coupleDouble4);
            bool areEqual4and5 = (coupleDouble1 == coupleDouble4);

        }
    }
}
