﻿using System;
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

namespace elevregwpf
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        protected void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Du er en taber!");   

                       Dal datamanager = new Dal();

            if (datamanager.ValidateUser(textBox.Text, passwordBox.Password.ToString()))
            {
                datamanager.Checkind(textBox.Text.ToString());
                datamanager.addpersontoday(textBox.Text.ToString());

                MainWindow window = new MainWindow();
          
                this.Close();
                CheckinWindow windows2 = new CheckinWindow();

                windows2.Show();
            }



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
