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
using work_recorder.DataProviders;
using work_recorder.Modells;
using work_recorder.Validators;

namespace work_recorder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private readonly Work _work;

        public WorkWindow(Work work)
        {
            InitializeComponent();

            if (work != null)
            {
                _work = work;

                NameOfCustomerTextBox.Text = _work.NameOfCustomer;
                CarLicensePlateTextBox.Text = _work.CarLicensePlate;
                TypeOfCarTextBox.Text = _work.TypeOfCar;
                DetailOfIssues.Text = _work.DetailOfIssues;

                CreateButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                _work = new Work();
                UpdateButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateWork())
            {
                _work.NameOfCustomer = NameOfCustomerTextBox.Text;
                _work.CarLicensePlate = CarLicensePlateTextBox.Text;
                _work.TypeOfCar = TypeOfCarTextBox.Text;
                _work.DetailOfIssues = DetailOfIssues.Text;
                _work.RecordingDate = DateTime.Now;
                _work.StateOfWork = "FELVETT MUNKA";

                WorkDataProvider.CreateWork(_work);

                DialogResult = true;
                Close();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateWork())
            {
                _work.NameOfCustomer = NameOfCustomerTextBox.Text;
                _work.CarLicensePlate = CarLicensePlateTextBox.Text;
                _work.TypeOfCar = TypeOfCarTextBox.Text;
                _work.DetailOfIssues = DetailOfIssues.Text;

                WorkDataProvider.UpdateWork(_work);

                DialogResult = true;
                Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztos hogy törölni szeretnéd?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Console.WriteLine(_work);
                WorkDataProvider.DeleteWork(_work.Id);

                DialogResult = true;
                Close();
            }
        }

        public bool ValidateWork() 
        {
            string error = WorkValidator.ValidateWork(NameOfCustomerTextBox.Text, CarLicensePlateTextBox.Text, TypeOfCarTextBox.Text, DetailOfIssues.Text);
            switch (error)
            {
                case "EMPTY_NAMEOFCUSTOMER":
                    MessageBox.Show("A vásárló neve nem lehet üres!");
                    return false;
                case "EMPTY_CARLICENSEPLATE":
                    MessageBox.Show("Az autó rendszáma nem lehet üres!");
                    return false;
                case "EMPTY_TYPEOFCAR":
                    MessageBox.Show("Az autó típusa nem lehet üres!");
                    return false;
                case "TOO_SHORT_DETAILOFISSUES":
                    MessageBox.Show("Az hiba leírásának legalább 3 karakternek kell lennie");
                    return false;
                default:
                    return true;
            }
        }
    }
}

