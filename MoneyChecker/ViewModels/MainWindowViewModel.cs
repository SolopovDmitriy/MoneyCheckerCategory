using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.ViewModels
{
    public class MainWindowViewModel
    {
        private string _dbPath;
        SQLiteORM.SQLiteDBEngine _SQLiteDBEngine;

        public CategoryViewModel CategoryViewModel;
        public MainWindowViewModel(string dbPath)
        {
            _dbPath = dbPath;
            _SQLiteDBEngine = new SQLiteORM.SQLiteDBEngine(_dbPath, SQLiteORM.SQLIteMode.EXISTS); // SQLiteORM.SQLiteMode.EXISTS
            CategoryViewModel = new CategoryViewModel(_SQLiteDBEngine);
        }
        public string DBPath
        {
            get
            {
                return _dbPath;
            }
        }
    }
}
