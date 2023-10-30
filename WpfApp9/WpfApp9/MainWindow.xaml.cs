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
        public int count = 1;
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
            int col = Convert.ToInt32(tbCol.Text);

            // Создайте массив багажа пассажира
            Baggage[] passengerBaggage = new Baggage[col];
            List<BaggageData> baggageList = new List<BaggageData>();

            if (baggageDataGrid.Items.Count < col)
            {

                int i = -1 + count;
                passengerBaggage[i].NumberOfItems = Convert.ToInt32(tbc1.Text);
                passengerBaggage[i].TotalWeight = Convert.ToDouble(tbc2.Text);

                BaggageData baggageData = new BaggageData
                {
                    BaggageId = count,
                    NumberOfItems = passengerBaggage[i].NumberOfItems,
                    TotalWeight = passengerBaggage[i].TotalWeight
                };
                // Add the baggage data to the list
                baggageList.Add(baggageData);
                baggageDataGrid.Items.Add(baggageList);

                count++;
            }
            else
            {
                MessageBox.Show("Хватит");
            }

            if (cb1.IsChecked == true)
            {
                List<BaggageDataAverageWeightPerItem> BaggageAverageWeightPerItemList = new List<BaggageDataAverageWeightPerItem>();
                // Рассчитайте средний вес каждого изделия
                double totalWeight = 0;
                double totalItems = 0;
                int i = -2 + count;

                totalWeight += passengerBaggage[i].TotalWeight;
                totalItems += passengerBaggage[i].NumberOfItems;

                BaggageDataAverageWeightPerItem baggageAverageWeightPerItem = new BaggageDataAverageWeightPerItem
                {
                    BaggageId = i + 1,
                    AverageWeightPerItem = totalWeight / totalItems
                };
                BaggageAverageWeightPerItemList.Add(baggageAverageWeightPerItem);
                baggageDataGrid2.Items.Add(BaggageAverageWeightPerItemList);

                if (cb2.IsChecked == true)
                {
                    double averageWeightPerItem = passengerBaggage[i].TotalWeight / passengerBaggage[i].NumberOfItems;
                    List<BaggageDeviation> DeviationList = new List<BaggageDeviation>();

                    BaggageDeviation BaggageDeviation = new BaggageDeviation
                    {
                        BaggageId = i + 1,
                        Deviation = Math.Abs(averageWeightPerItem - (passengerBaggage[i].TotalWeight / passengerBaggage[i].NumberOfItems))
                    };
                    DeviationList.Add(BaggageDeviation);
                    baggageDataGrid3.Items.Add(DeviationList);

                    double deviation = Math.Abs(averageWeightPerItem - (passengerBaggage[i].TotalWeight / passengerBaggage[i].NumberOfItems));

                    if (deviation <= 0.3)
                    {
                        tbRes3.Text = ($"Багаж {i + 1} - Вещей в багаже: {passengerBaggage[i].NumberOfItems}, Вес багажа: {passengerBaggage[i].TotalWeight} кг\r\n");
                    }

                }
            }


        }

        private void btnClear_click(object sender, RoutedEventArgs e)
        {
            baggageDataGrid.Items.Clear();
            baggageDataGrid2.Items.Clear();
            baggageDataGrid3.Items.Clear();
            count = 1;
        }

    }
}
