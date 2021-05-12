using MoneyChecker.Models;
using SQLiteORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoneyChecker.ViewModels
{
    public class CategoryViewModel
    {
        private SQLiteDBEngine _SQLiteDBEngine; // движок, через него происходят все операции с базой данных
        private SQLiteTable _categoriesTable; // объект для связи с таблицей categories в базе данных
        private List<Category> _сategories;


        //  my code 2 ---------------------------------------------------------------------
        public void addCategory(Category category)
        {
            _categoriesTable.AddOneRow(new List<string> { category.Categ, category.Parent_Id.ToString() });//  Categ - имя категории, название столбца в базе данных
            _SQLiteDBEngine.Async();

            //try
            //{
            //    //_сategories.Add(category); // my code 2
            //    if (category.Parent_Id == 0) 
            //    {
            //        _categoriesTable.AddOneRow(new List<string> { category.Categ, "0" });
            //    }
            //    else
            //    {
            //        _categoriesTable.AddOneRow(new List<string> { category.Categ, category.Parent_Id.ToString() });
            //    }
            //    _SQLiteDBEngine.Async();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    throw;
            //}
        }

        public CategoryViewModel(SQLiteDBEngine SQLiteDBEngine)
        {

            _SQLiteDBEngine = SQLiteDBEngine;
            _categoriesTable = _SQLiteDBEngine["categories"]; // получаем из движка объект SQLiteTable _categories для работы с таблицей categories
            //LoadCategoriesFromDB();

        }
        // my code 2 --------------------------------------------------
        private void LoadCategoriesFromDB() // загружаем из базы данных список категорий в переменную  _сategories
        {
            _сategories = new List<Category>(); // создаём пустой список List<Category> для считывания данных из таблицы categories
            foreach (var row in _categoriesTable.BodyRows) // проходим по всем строкам таблицы categories, var row - один рядок в таблице
            {
                int id = Convert.ToInt32(row.Key); // в ключе объекта row хранится первичный ключ id 
                string name = row.Value[0]; // в значении объекта row список строк, в котором хранятся остальные столбцы (кроме первичного ключа id)
                // int? parentId = null; // если не получится сконвертировать row.Value[1] в число, то в int? parentId должно хранится null
                int parentId = Convert.ToInt32(row.Value[1]); // конвертируем строку row.Value[1] в число -----  my code 2
                
                _сategories.Add(new Category { Id = id, Categ = name, Parent_Id = parentId }); // создаем объект класса Category и добавляем этот объект в список сategoriesFromDB
            }
        }

        // my code 2-----------------------------

        public List<Category> DataSource //создает список категорий с подкатегориями
        {
            get 
            {
                LoadCategoriesFromDB();  // my code 2
                return GoDownRecursive(0); // my code 2 
            }
        }

        private List<Category> GoDownRecursive(int parentId) // получить список категорий, у которых родитель = parentId
        {
            List<Category> res = new List<Category>(); // создаём пустой список
            foreach (Category subcategory in _сategories.Where(c => c.Parent_Id == parentId)) // сategoriesFromDB.Where(c => c.ParentId == parentId) ищет в списке сategoriesFromDB все категории у которых родитель == parentId
            {
                res.Add(subcategory); // добавляем в список категорию
                subcategory.SubCategories = new List<Category>(); // создаём пустой список для подкатегорий 
                subcategory.SubCategories.AddRange(GoDownRecursive(subcategory.Id)); // рекурсивно находим и добавляем в список подкатегории для категории subcategory 
            }
            return res; // метод возвращает список категорий
        }

       



    }
}
