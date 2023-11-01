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
                passengerBaggage[i].AverageWeightPerItem = passengerBaggage[i].TotalWeight / passengerBaggage[i].NumberOfItems;

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
                if (baggageDataGrid2.Items.Count < col)
                {
                    List<BaggageDataAverageWeightPerItem> BaggageAverageWeightPerItemList = new List<BaggageDataAverageWeightPerItem>();
                    // Рассчитайте средний вес каждого изделия
                    int i = -2 + count;

                    BaggageDataAverageWeightPerItem baggageAverageWeightPerItem = new BaggageDataAverageWeightPerItem
                    {
                        BaggageId = i + 1,
                        AverageWeightPerItem = passengerBaggage[i].AverageWeightPerItem
                    };
                    BaggageAverageWeightPerItemList.Add(baggageAverageWeightPerItem);
                    baggageDataGrid2.Items.Add(BaggageAverageWeightPerItemList);
                }
                    
                if (cb2.IsChecked == true)
                {
                    if (baggageDataGrid2.Items.Count == col)
                    {
                        double allItems = 0;
                        double allWeight = 0;
                        for (int j = 0; j < col; j++)
                        {
                            allItems += passengerBaggage[j].NumberOfItems;
                            allWeight += passengerBaggage[j].TotalWeight;
                        }
                        double AllAverageWeight = allItems / allWeight;
                        
                        for (int k = 0; k < col; k++)
                        {
                            List<BaggageDeviation> DeviationList = new List<BaggageDeviation>();

                            BaggageDeviation BaggageDeviation = new BaggageDeviation
                            {
                                BaggageId = k + 1,
                                Deviation = Math.Abs(AllAverageWeight - passengerBaggage[k].AverageWeightPerItem)
                            };
                            DeviationList.Add(BaggageDeviation);
                            baggageDataGrid3.Items.Add(DeviationList);

                            double deviation = Math.Abs(AllAverageWeight - passengerBaggage[k].AverageWeightPerItem);

                            if (deviation <= 0.3)
                            {
                                lb1.Items.Add($"Багаж {k + 1} - Вещей в багаже: {passengerBaggage[k].NumberOfItems}, Вес багажа: {passengerBaggage[k].TotalWeight} кг");
                            }
                        }                      
                    }                   
                }
            }
        }

        private void btnClear_click(object sender, RoutedEventArgs e)
        {
            baggageDataGrid.Items.Clear();
            baggageDataGrid2.Items.Clear();
            baggageDataGrid3.Items.Clear();
            lb1.Items.Clear();
            count = 1;
        }

    }
}
