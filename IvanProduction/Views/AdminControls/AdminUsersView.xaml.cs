using IvanProduction.Model;
using IvanProduction.Model.ModelsStatic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.IO;
using System.Drawing.Printing;
using System.Drawing;

namespace IvanProduction.Views.AdminControls
{
    /// <summary>
    /// Логика взаимодействия для AdminUsersView.xaml
    /// </summary>
    public partial class AdminUsersView : UserControl
    {


        public List<Account> accounts { get; set; }
        public AdminUsersView()
        {
            InitializeComponent();
            UpdateTable();

        }
        public void UpdateTable()
        {
            accounts = Elements.AccountElements.GetAll().Result.ToList();
            foreach (var item in accounts)
            {
                item.historyTransactions = Elements.HistoryElements.GetAll().Result.Where(x => x.Account.Id == item.Id).ToList();
            }
            listviewUsers.ItemsSource = accounts;
        }



        private void listviewUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listviewHistory.ItemsSource = ((listviewUsers.SelectedItem) as Account).historyTransactions;
            listviewHistory.SelectedIndex = 0;
        }

        private void Button_Word(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                app.Visible = true;
                Microsoft.Office.Interop.Word.Document worddoc;
                object wordobj = System.Reflection.Missing.Value;
                worddoc = app.Documents.Add(ref wordobj);

                if (listviewHistory.SelectedIndex > -1)
                {
                    Account acc = ((Account)listviewUsers.SelectedItem);
                    string info = $"|{acc.AccountHolder.Surname} {acc.AccountHolder.Name} Почта:{acc.AccountHolder.Email}|\n";
                    foreach (var item in ((Account)listviewUsers.SelectedItem).historyTransactions)
                    {
                        info += $"Книга:|Название:{item.Book.Name}, Автор:{item.Book.Author}, Осталось:{(item.ReturnTime.Date - DateTime.Today).Days} Дней|\n";
                    }
                    app.Selection.TypeText(info);
                }
                else
                {
                    MessageBox.Show("Вы не выбрали элемент!");
                }


            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }


        }

        private void Button_Txt(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                using (StreamWriter stream = new StreamWriter(fs))
                {
                    if (listviewHistory.SelectedIndex > -1)
                    {
                        Account acc = ((Account)listviewUsers.SelectedItem);
                        string info = $"|{acc.AccountHolder.Surname} {acc.AccountHolder.Name} Почта:{acc.AccountHolder.Email}|\n";
                        stream.WriteLine(info);
                        foreach (var item in ((Account)listviewUsers.SelectedItem).historyTransactions)
                        {
                            string info1 = $"Книга:|Название:{item.Book.Name}, Автор:{item.Book.Author}, Осталось:{(item.ReturnTime.Date - DateTime.Today).Days} Дней|\n";
                            stream.WriteLine(info1);
                        }

                        MessageBox.Show("Успешно сохранено!");
                    }
                    else
                    {
                        MessageBox.Show("Вы не выбрали элемент!");
                    }


                }
            }
            
        }

        private void Button_Print(object sender, RoutedEventArgs e)
        {


            string result = "Строка 1\n\n";
            result += "Строка 2\nСтрока 3";
            // объект для печати
            PrintDocument printDocument = new PrintDocument();
            // обработчик события печати
            printDocument.PrintPage += PrintPageHandler;
            // диалог настройки печати
            PrintDialog printDialog = new PrintDialog();
            // установка объекта печати для его настройки

            // если в диалоге было нажато ОК
            if (printDialog.ShowDialog() == true)
                printDocument.Print(); ; // печатаем

        }
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            if (listviewHistory.SelectedIndex > -1)
            {
                Account acc = ((Account)listviewUsers.SelectedItem);
                string info = $"|{acc.AccountHolder.Surname} {acc.AccountHolder.Name} Почта:{acc.AccountHolder.Email}|\n";
               
                foreach (var item in ((Account)listviewUsers.SelectedItem).historyTransactions)
                {
                    info += $"Книга:|Название:{item.Book.Name}, Автор:{item.Book.Author}, Осталось:{(item.ReturnTime.Date - DateTime.Today).Days} Дней|\n";
                    
                }
                e.Graphics.DrawString(info, new Font("Arial", 14), System.Drawing.Brushes.Black, 0, 0);
                MessageBox.Show("Успешно сохранено!");
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент!");
            }
            
        }

        private void Button_Excel(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;

            ExcelApp.Cells[1, 1] = "Имя";
            ExcelApp.Cells[1, 2] = "Фамилия";
            ExcelApp.Cells[1, 3] = "Email";
            ExcelApp.Cells[1, 4] = "Login";
            ExcelApp.Cells[1, 5] = "Кол-во взятых книг";
           
            for (int i = 0; i < accounts.Capacity; i++)
            {
                ExcelApp.Cells[i + 2, 1] = accounts[i].AccountHolder.Name;
                ExcelApp.Cells[i + 2, 2] = accounts[i].AccountHolder.Surname;
                ExcelApp.Cells[i + 2, 3] = accounts[i].AccountHolder.Email;
                ExcelApp.Cells[i + 2, 4] = accounts[i].AccountHolder.Username;
                ExcelApp.Cells[i + 2, 5] = accounts[i].historyTransactions.ToList().Capacity;

            }


            ExcelApp.Visible = true;
        }
    }
}



