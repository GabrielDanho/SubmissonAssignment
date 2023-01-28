using Newtonsoft.Json;
using SubmissonAssignment.Models;
using SubmissonAssignment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace SubmissonAssignment
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        private readonly FileService file = new();
        

        public MainWindow()
        {
            InitializeComponent();
            file.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
            PopulateEmployeesList();
        }

        private void PopulateEmployeesList()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(file.Read());
                if (items != null)
                    employees = items;
            }
            catch { }

            lv_Employees.ItemsSource = employees;
        }
        
        private void CreatingUser()
        {
            employees.Add(new Employee
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                Phone = tb_Phone.Text,
                Address = tb_Address.Text
            });

            file.Save(JsonConvert.SerializeObject(employees));
            ClearForm();
        }

        private void DeletingUser()
        {
            if (lv_Employees.SelectedItems != null!)
            {
                employees.RemoveAt(lv_Employees.SelectedIndex);
            }
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            CreatingUser();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            DeletingUser();
        }

        private void ClearForm()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_Phone.Text = "";
            tb_Address.Text = "";
        }

        private void Btn_List_Click(object sender, RoutedEventArgs e)
        {
            int count = 1;
            foreach (var employee in employees)
            {
                Console.WriteLine($"{count} firstname:{tb_FirstName}, lastname:{tb_LastName}, email:{tb_Email}, phone:{tb_Phone}, add");
            }
        }
    }
}
