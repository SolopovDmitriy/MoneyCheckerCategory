using Microsoft.Win32;
using MoneyChecker.Pages;
using MoneyChecker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneyChecker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string dbPath;
        TabViewController _tabViewController;
        public static MainWindowViewModel WindowViewModel; 
        public MainWindow()
        {
            InitializeComponent();

            if (WindowViewModel == null) return;
        }
        private void initUI()
        {
            _tabViewController = new TabViewController();
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.research, "Обзор"), new SearchPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.money_transfer, "Транзакции"), new TransactionPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.calendar, "Календарь"), new CalendarPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.cash_flow, "Валюты"), new CurrenciesPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.debt, "Долги"), new DebtsPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.bill, "Счета"), new InvoicesPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.schedule, "Планировщик"), new SchedulerPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.categories, "Категории"), new CategoriesPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.group, "Пользователи"), new UsersPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.calculator, "Бюджет"), new BudgetPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.analysis, "Отчеты"), new ReportsPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.settings, "Опции"), new OptionsPage()));

            MainWindowGrid.Children.Add(_tabViewController.Body);
            Grid.SetRow(_tabViewController.Body, 1);
            Grid.SetColumn(_tabViewController.Body, 0);
        }
        private void MenuItem_CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_SecurityClick(object sender, RoutedEventArgs e)
        {
            
        }
        private void MenuItem_CreateDatabaseClick(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_OpenDatabaseClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openFileDialog.ShowDialog() == true)
            {
                dbPath = openFileDialog.FileName;
                WindowViewModel = new MainWindowViewModel(dbPath);
                if(_tabViewController != null)
                {
                    _tabViewController.Body.Children.Clear();
                }
                initUI();
            }
        }
        private void MenuItem_SaveDatabaseClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
