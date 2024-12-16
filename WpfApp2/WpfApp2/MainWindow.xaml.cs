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

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private List<Product> products;
        public MainWindow()
        {
            InitializeComponent();
            products = new List<Product>();
            LoadProducts();
        }

        private void LoadProducts()
        {
            //тестовые товары
            products.Add(new Product("Товар №1", 100, "Описание товара...", 42));
            products.Add(new Product("Товар №2", 200, "Описание товара...", 52));
            RefreshProductList();
        }

        private void RefreshProductList()
        {
            ProductListView.Items.Clear();
            foreach (var product in products)
            {
                ProductListView.Items.Add(product);
            }
        }

        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            // Проверка на валидность ввода
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                !decimal.TryParse(PriceTextBox.Text, out decimal price) ||
                string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ||
                !int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newProduct = new Product(NameTextBox.Text, price, DescriptionTextBox.Text, quantity);
            products.Add(newProduct);
            RefreshProductList();

            NameTextBox.Clear();
            PriceTextBox.Clear();
            DescriptionTextBox.Clear();
            QuantityTextBox.Clear();
        }

        private void ProductListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ProductListView.SelectedItem is Product selectedProduct)
            {
                var (name, price, description, quantity) = selectedProduct;
                MessageBox.Show($"Имя: {name}\nЦена: {price}\nОписание: {description}\nКоличество: {quantity}", "Детали товара");
            }
        }

    }
}
