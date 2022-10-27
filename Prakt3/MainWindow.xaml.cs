using Lib_12;
using Libmas;
using Microsoft.Win32;
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

namespace Prakt3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] arr;
        public MainWindow()
        {
            InitializeComponent();
            rowsCount.Focus();
        }

        private void ClearArr_Click(object sender, RoutedEventArgs e)
        {
            rowsCount.Clear();
			rowsCount.Focus();
            columnsCount.Clear();
            NumbersApp.ItemsSource = null;
            ResultBox.Clear();
            LibTask.ClearArr(ref arr);
        }

        private void UploadArr_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openArr = new OpenFileDialog();
            openArr.Filter = "Текстовые файлы | *.txt";
            openArr.FilterIndex = 1;
            if (openArr.ShowDialog() == true)
            {
                LibTask.UploadArr(ref arr, openArr.FileName);
                NumbersApp.ItemsSource = VisualArray.ToDataTable(arr).DefaultView;
            }
        }

        private void SaveArr_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveArr = new SaveFileDialog();
            saveArr.Filter = "Текстовые файлы | *.txt";
            saveArr.FilterIndex = 1;
            if (arr == null)
            {
                MessageBox.Show("Массив не может быть пустым!");
            }
            else if (saveArr.ShowDialog() == true)
            {
                LibTask.SaveArr(arr, saveArr.FileName);
            }
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AppTask_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nВариант 12\nЗадание: Дана матрица размера M × N.\nНайти минимальный среди максимальных элементов ее столбцов.");
        }

        private void columnsCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(int.TryParse(rowsCount.Text, out int rows) && int.TryParse(columnsCount.Text, out int columns))
            {
                arr = new int[rows, columns];
                LibTask.FillArr(ref arr, 20);
                NumbersApp.ItemsSource = VisualArray.ToDataTable(arr).DefaultView;
            }
        }

        private void resButton_Click(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                ResultBox.Text = $"{LibArr.MinOfMaxColumnArr(arr)}";
            }
            else
            {
                MessageBox.Show("Массив не может быть пустым!");
            }
        }
    }
}
