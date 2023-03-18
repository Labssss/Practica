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

namespace StationeryApp.Pages
{
    /// <summary>
    /// Interaction logic for ItemsPage.xaml
    /// </summary>
    public partial class ItemsPage : Page
    {
        // Конструктор класса
        public ItemsPage()
        {
            // Инициализация компонентов
            InitializeComponent();
            // Установка источника данных для ItemsLView - список продуктов из контекста приложения
            ItemsLView.ItemsSource = App.Context.Products.ToList();
        }

        // Обработчик события изменения выбранного элемента в ComboBox "Сортировка по"
        private void ComboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Вызов метода UpdateProducts()
            UpdateProducts();
        }

        // Обработчик события изменения выбранного элемента в ComboBox "Скидки"
        private void ComboDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Вызов метода UpdateProducts()
            UpdateProducts();
        }

        // Обработчик события изменения текста в TextBox "Поиск"
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Вызов метода UpdateProducts()
            UpdateProducts();
        }

        // Метод для обновления списка продуктов в ItemsLView с учетом выбранных пользователем параметров сортировки, фильтрации и поиска
        private void UpdateProducts()
        {
            // Получение списка продуктов из контекста приложения
            var products = App.Context.Products.ToList();
            // Если выбрана сортировка "По возрастанию цены со скидкой"
            if (ComboSortBy.SelectedIndex == 0)
                products = products.OrderBy(p => p.DiscountPriceNumber).ToList();
            else
                // Если выбрана сортировка "По убыванию цены со скидкой"
                products = products.OrderByDescending(p => p.DiscountPriceNumber).ToList();

            // Фильтрация по уровню скидки
            if (ComboDiscount.SelectedIndex == 1)
                products = products.Where(p => p.ProductDiscountAmount >= 0 && p.ProductDiscountAmount < 10).ToList();
            if (ComboDiscount.SelectedIndex == 2)
                products = products.Where(p => p.ProductDiscountAmount >= 10 && p.ProductDiscountAmount < 15).ToList();
            if (ComboDiscount.SelectedIndex == 3)
                products = products.Where(p => p.ProductDiscountAmount >= 15).ToList();

            // Поиск продуктов по наименованию
            products = products.Where(p => p.ProductName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            // Установка списка продуктов в ItemsLView
            ItemsLView.ItemsSource = products;
        }
    }
}
