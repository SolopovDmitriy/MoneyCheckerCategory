using MoneyChecker.Models;
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

namespace MoneyChecker.Pages
{
    /// <summary>
    /// Логика взаимодействия для CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        public CategoriesPage()
        {
            InitializeComponent();
            Categories_TreeView.ItemsSource = MainWindow.WindowViewModel.CategoryViewModel.DataSource;

            parentCategoryComboBox.Items.Add(" ");
            foreach (var item in MainWindow.WindowViewModel.CategoryViewModel.DataSource)
            {
                parentCategoryComboBox.Items.Add(item);
            }
        }

        private void Categories_TreeView_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string newCategoryName = newCategoriesTextBox.Text;
            Category parent = null;
            if (newCategoryName.Length >= 3)
            {
                if (parentCategoryComboBox.SelectedItem is Category)
                {
                    parent = (Category)parentCategoryComboBox.SelectedItem;
                    MainWindow.WindowViewModel.CategoryViewModel.addCategory(new Category() { 
                        Categ = newCategoryName, Parent_Id = parent.Id });
                }
                else
                {
                    MainWindow.WindowViewModel.CategoryViewModel.addCategory(new Category() { 
                        Categ = newCategoryName, Parent_Id = 0}); // my code 2
                }
                //Categories_TreeView.ItemsSource = null; // my code 2
                Categories_TreeView.ItemsSource = MainWindow.WindowViewModel.CategoryViewModel.DataSource;

            }
        }
    }
}
