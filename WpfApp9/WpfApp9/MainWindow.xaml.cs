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

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил лучший разработчик: Девяткин Вадим Евгеньевич\r\nПрактическая №9\r\nСоздать интерфейс - человек, у которого есть имя, функция печати. \r\nСоздать класс" +
                    "отец, у которого функция печати выводит имя.\r\nСоздать класс ребенок, у которого" +
                    "есть отец, отчество, функция печати выводит имя и отчество.Классы должны" +
                    "включать конструкторы.Сравнение производить по фамилии");
        }

        private void btnRes_Click(object sender, RoutedEventArgs e)
        {
            // Создайте массив багажа пассажира
            Baggage[] passengerBaggage = new Baggage[5];

            // Считайте данные о багаже каждого пассажира
            for (int i = 0; i < passengerBaggage.Length; i++)
            {
                passengerBaggage[i].NumberOfItems = Convert.ToInt32(tbc1.Text);
                passengerBaggage[i].TotalWeight = Convert.ToDouble(tbc2.Text);
            }
            if (rb1.IsChecked == true) 
            {
                // Рассчитайте средний вес каждого изделия
                double totalWeight = 0;
                int totalItems = 0;

                foreach (var baggage in passengerBaggage)
                {
                    totalWeight += baggage.TotalWeight;
                    totalItems += baggage.NumberOfItems;
                }
                double averageWeightPerItem = totalWeight / totalItems;
                tbRes2.Text = ($"Средний вес каждого изделия {averageWeightPerItem}");
                if (rb2.IsChecked == true)
                {
                    Console.WriteLine("List of baggages within accepted average weight deviation:");
                    for (int i = 0; i < passengerBaggage.Length; i++)
                    {
                        double deviation = Math.Abs(averageWeightPerItem - (passengerBaggage[i].TotalWeight / passengerBaggage[i].NumberOfItems));

                        if (deviation <= 0.3)
                        {
                            tbRes3.Text = ($"Passenger {i + 1} - Number of Items: {passengerBaggage[i].NumberOfItems}, Total Weight: {passengerBaggage[i].TotalWeight} kg");
                        }
                    }
                }
            }            
        }
    }
}
