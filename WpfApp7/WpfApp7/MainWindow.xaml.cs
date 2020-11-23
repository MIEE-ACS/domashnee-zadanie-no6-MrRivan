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

namespace WpfApp7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        abstract class Currency
        {

            public double Money { get; set; }
            public string Type { get; set; }
            public abstract string ToString();
            // public abstract double Equals();
        }
        class Dollar : Currency
        {
            public  Dollar(string dollars)
            {
                try
                {
                    double number;
                    bool beacon;
                    string input = dollars.Replace(',', '.');
                    beacon = double.TryParse(input, out number);
                    if (beacon == false)
                    {
                        input = input.Replace('.', ',');
                        beacon = double.TryParse(input, out number);
                    }
                    if (beacon)
                    {
                        Money = number;
                        Type = "Доллары";
                    }
                    else
                        MessageBox.Show("Проверьте коректность введеных значений");
                }
                catch
                {
                    MessageBox.Show("Проверьте коректность введеных значений");
                }
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                Dollar m = obj as Dollar;
                if (m as Dollar == null)
                {
                    return false;
                }
                return m.Money == this.Money;
            }
            public override string ToString()
            {
                return $"Кол-во рублей: {Math.Round(Money * 75.89, 2)}\tКол-во долларов: {Money}";//Коэффицент перевода из доллоров 75.89
            }
        }
        class Euro : Currency
        {
            public Euro(string euros)
            {
                try
                {
                    double number;
                    bool beacon;
                    string input = euros.Replace(',', '.');
                    beacon = double.TryParse(input, out number);
                    if (beacon == false)
                    {
                        input = input.Replace('.', ',');
                        beacon = double.TryParse(input, out number);
                    }
                    if (beacon)
                    {
                        Money = number;
                        Type = "Евро";
                    }
                    else
                        MessageBox.Show("Проверьте коректность введеных значений");
                }
                catch
                {
                    MessageBox.Show("Проверьте коректность введеных значений");
                }
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                Euro m = obj as Euro;
                if (m as Euro == null)
                {
                    return false;
                }
                return m.Money == this.Money;
            }
            public override string ToString()
            {
                return $"Кол-во рублей: {Math.Round(Money * 90.14, 2)}\tКол-во евро: {Money}";//Коэффицент перевода из Евро 90.14
            }
        }
        class Yuan : Currency
        {
            public Yuan(string yuans)
            {
                try
                {
                    double number;
                    bool beacon;
                    string input = yuans.Replace(',', '.');
                    beacon = double.TryParse(input, out number);
                    if (beacon == false)
                    {
                        input = input.Replace('.', ',');
                        beacon = double.TryParse(input, out number);
                    }
                    if (beacon)
                    {
                        Money = number;
                        Type = "Юани";
                    }
                    else
                        MessageBox.Show("Проверьте коректность введеных значений");
                }
                catch
                {
                    MessageBox.Show("Проверьте коректность введеных значений");
                }
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                Yuan m = obj as Yuan;
                if (m as Yuan == null)
                {
                    return false;
                }
                return m.Money == this.Money;
            }
            public override string ToString()
            {
                return $"Кол-во рублей: {Math.Round(Money * 11.54, 2)}\tКол-во Юаней: {Money}"; //Коэффицент перевода из Юаней 11.54
            }

        }
        List<Currency> currencies = new List<Currency>();
        public MainWindow()
        {
            InitializeComponent();
            
            currencies.Add(new Dollar("58.4"));
            currencies.Add(new Dollar("158.8"));
            currencies.Add(new Dollar("664.5"));
            currencies.Add(new Euro("58.4"));
            currencies.Add(new Euro("158.8"));
            currencies.Add(new Euro("664.5"));
            currencies.Add(new Yuan("58.4"));
            currencies.Add(new Yuan("158.8"));
            currencies.Add(new Yuan("664.5"));
        }
        
        private void Money_RB_Checked(object sender, RoutedEventArgs e)
        {
            if(Dollar_RB.IsChecked==true)
            {
                Rubel_Lb.Content = "Доллары";
                Main_LB.Items.Clear();
            }
            if (Euro_RB.IsChecked == true)
            {
                Rubel_Lb.Content = "Евро";
                Main_LB.Items.Clear();
            }
            if(Yuan_RB.IsChecked==true)
            {
                Rubel_Lb.Content = "Юани";
                Main_LB.Items.Clear();
            }
        }

        private void Main_Bt_Click(object sender, RoutedEventArgs e)
        {
            Main_LB.Items.Clear();
            if (Dollar_RB.IsChecked == true)
            {
                currencies.Add(new Dollar(Rubel_Tb.Text));
                foreach(var cur in currencies)
                {
                    Main_LB.Items.Add(cur.ToString());
                }
            }
            if (Euro_RB.IsChecked == true)
            {
                currencies.Add(new Euro(Rubel_Tb.Text));
                foreach (var cur in currencies)
                {
                    Main_LB.Items.Add(cur.ToString());
                }
            }
            if (Yuan_RB.IsChecked == true)
            {
                currencies.Add(new Yuan(Rubel_Tb.Text));
                foreach (var cur in currencies)
                {
                    Main_LB.Items.Add(cur.ToString());
                }
            }
            if (Yuan_RB.IsChecked == false && Euro_RB.IsChecked == false && Dollar_RB.IsChecked == false)
            {
                MessageBox.Show("Выберете один из вариантов валюты!");
            }
        }
        private void Main_Delete_Bt_Click(object sender, RoutedEventArgs e)
        {
           
            Main_LB.Items.Clear();
            Dollar_RB.Visibility = Visibility.Hidden;
            Euro_RB.Visibility = Visibility.Hidden;
            Yuan_RB.Visibility = Visibility.Hidden;
            Delete_Lb.Visibility = Visibility.Visible;
            Delete_Tb.Visibility = Visibility.Visible;
            Delate_Bt.Visibility = Visibility.Visible;
            Rubel_Lb.Visibility = Visibility.Hidden;
            Rubel_Tb.Visibility = Visibility.Hidden;
            Main_Bt.Visibility = Visibility.Hidden;
            foreach (var cur in currencies)
            {
                Main_LB.Items.Add(cur.ToString());
            }
        }
        private void Main_Add_Bt_Click(object sender, RoutedEventArgs e)
        {
            Main_LB.Items.Clear();
            Dollar_RB.Visibility = Visibility.Visible;
            Euro_RB.Visibility = Visibility.Visible;
            Yuan_RB.Visibility = Visibility.Visible;
            Delete_Lb.Visibility = Visibility.Hidden;
            Delete_Tb.Visibility = Visibility.Hidden;
            Delate_Bt.Visibility = Visibility.Hidden;
            Rubel_Lb.Visibility = Visibility.Visible;
            Rubel_Tb.Visibility = Visibility.Visible;
            Main_Bt.Visibility = Visibility.Visible;
        }
        private void Delate_Bt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = currencies[int.Parse(Delete_Tb.Text)-1];
                currencies.Remove(item);
                Main_LB.Items.Clear();
                foreach (var cur in currencies)
                {
                    Main_LB.Items.Add(cur.ToString());
                }
            }
            catch
            {
                if (Main_LB.Items.Count == 0)
                {
                    MessageBox.Show("Вы удалили все значения!");
                }
                else
                {
                    MessageBox.Show("Проверьте коректность введеных значений"); 
                }
            }
        }

        private void Equals_Bt_Click(object sender, RoutedEventArgs e)
        {
            Main_LB.Items.Clear();
            Dollar_RB.Visibility = Visibility.Visible;
            Euro_RB.Visibility = Visibility.Visible;
            Yuan_RB.Visibility = Visibility.Visible;
            Delete_Lb.Visibility = Visibility.Hidden;
            Delete_Tb.Visibility = Visibility.Hidden;
            Delate_Bt.Visibility = Visibility.Hidden;
            Rubel_Lb.Visibility = Visibility.Hidden;
            Rubel_Tb.Visibility = Visibility.Hidden;
            Main_Bt.Visibility = Visibility.Hidden;

            if (Dollar_RB.IsChecked == true)
            {
                foreach (var cur in currencies)
                {
                    if (cur.Type == "Доллары")
                    {
                        Main_LB.Items.Add($"Сравнение {cur.ToString()} с остальными\n");
                        foreach (var j in currencies)
                        {
                            if (j.Type == "Доллары")
                            {
                                
                                Main_LB.Items.Add(cur.ToString());
                                Main_LB.Items.Add(cur.Equals(j));
                            }
                        }
                        Main_LB.Items.Add("\n");
                    }
                }
            }
            if (Euro_RB.IsChecked == true)
            {
                foreach (var cur in currencies)
                {
                    if (cur.Type == "Евро")
                    {
                        Main_LB.Items.Add($"Сравнение {cur.ToString()} с остальными\n");
                        foreach (var j in currencies)
                        {
                            if (j.Type == "Евро")
                            {
                                
                                Main_LB.Items.Add(cur.ToString());
                                Main_LB.Items.Add(cur.Equals(j));
                            }
                        }
                        Main_LB.Items.Add("\n");
                    }
                }
            }

            if (Yuan_RB.IsChecked == true)
            {
                foreach (var cur in currencies)
                {
                    if (cur.Type == "Юани")
                    {
                        Main_LB.Items.Add($"Сравнение {cur.ToString()} с остальными\n");
                        foreach (var j in currencies)
                        {
                            if (j.Type == "Юани")
                            {
                                Main_LB.Items.Add(cur.ToString());
                                Main_LB.Items.Add(cur.Equals(j));  
                            }
                        }
                        Main_LB.Items.Add("\n");
                    }
                }
            }
            if (Yuan_RB.IsChecked == false && Euro_RB.IsChecked == false && Dollar_RB.IsChecked == false)
            {
                MessageBox.Show("Выберете один из вариантов валюты!");
            }
        } 
    }
}

