using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp2.model;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyDbContext context;
        private ObservableCollection<User> UsersFromDb { get; } = new ObservableCollection<User>();
       
        public MainWindow()
        {
            InitializeComponent();
            context = new MyDbContext();

            context.Users.Load();
            context.Books.Load();
            context.Tickets.Load();


            UserDataGrid.ItemsSource = context.Users.Local.ToObservableCollection();
            BookDataGrid.ItemsSource = context.Books.Local.ToObservableCollection();
            TicketDataGrid.ItemsSource = context.Tickets.Local.ToObservableCollection();

            TicketUserComboBox.ItemsSource = context.Users.Local.ToObservableCollection();
            BookUserComboBox.ItemsSource = context.Users.Local.ToObservableCollection();
        }

        private void UserSaveButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show($"Успешно сахраненно { context.SaveChanges<User>()}");
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Ошибка при сохранении");
            }

        }

        private void BookSaveButtonClick(object sender, RoutedEventArgs e)
        {
            try { 
            MessageBox.Show($"Успешно сахраненно { context.SaveChanges<Book>()}");
        }
          catch (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Ошибка при сохранении");
            }
}

        private void TicketSaveButtonClick(object sender, RoutedEventArgs e)
        {
            try {
            MessageBox.Show($"Успешно сахраненно { context.SaveChanges<Ticket>()}");
            }
            catch
            (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Ошибка при сохранении");
            }
        }
    }
}
