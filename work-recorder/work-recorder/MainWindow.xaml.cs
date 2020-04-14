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

namespace work_recorder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<Work> _works;

        public MainWindow()
        {
            InitializeComponent();

            UpdateWorks();
        }

        private void AddWorkButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new WorkWindow(null);
            if (window.ShowDialog() ?? false)
            {
                UpdateWorks();
            }
        }

        private void WorksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedWork = worksListBox.SelectedItem as Work;

            if (selectedWork != null)
            {
                var window = new WorkWindow(selectedWork);
                if (window.ShowDialog() ?? false)
                {
                    UpdateWorks();
                }

                worksListBox.UnselectAll();
            }
        }

        private void UpdateWorks()
        {
            _works = WorkDataProvider.GetAll();
            worksListBox.ItemsSource = _works;
        }
    }
}
