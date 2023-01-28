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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        private readonly FileService file = new();
        

        public MainWindow()
        {
            InitializeComponent();
            file.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
            Menu();
            PopulateEmployeesList();
        }

        public void Menu()
        {
            Console.WriteLine("====== VÄLKOMMEN TILL ADRESSBOKEN ======");
            Console.WriteLine("1. Skapa en kontakt");
            Console.WriteLine("2. Ta bort en specifik kontakt");
            Console.WriteLine("Välj ett av alternativen ovan: ");
            bool loop = true;
            while (loop)
            {

                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        CreatingUser();
                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":
                        Console.WriteLine("Programmet stängs, hej då");
                        break;
                }
            }
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

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            CreatingUser();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (lv_Employees.SelectedItems != null!)
            {
                employees.RemoveAt(lv_Employees.SelectedIndex);
                //Clear_Add();
            }
        }

        //private void Clear_Add()
        //{
        //    lv_Employees.Items.Clear();
        //    foreach (var employee in employees)
        //    {
        //        lv_Employees.Items.Add(employee.FirstName + " " + employee.LastName + " " + employee.Email + " " + employee.Phone.ToString() + " " + employee.Address);
        //    }
        //}
        

        private void ClearForm()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_Phone.Text = "";
            tb_Address.Text = "";
        }
    }
}
