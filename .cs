using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ObservableCo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListofPerson per
        {
            get;
            set;
        }
       
        
        
        public MainWindow()
        {
          
            InitializeComponent();

            this.per = new ListofPerson();
            this.Source = CollectionViewSource.GetDefaultView(this.per.Persons);
            this.Main.DataContext = this.per;
            this.IsNames.DataContext = this.Source;

        }
       
        ICollectionView Source { get; set; }
        public IEnumerable<string> ListOfPerson
        {
            get
            {
                return this.per.AvaialbleName;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class ListofPerson
    {
        private ObservableCollection<Person> person;
        public ObservableCollection<Person> Persons
        {
            get
            {
                this.person = this.LoadItems() ?? this.person;
                return this.person;
            }
        }
        public IEnumerable<string> AvaialbleName
        {
            get
            {
                return (from d in this.Persons select d.Student);
            }
        }
        private ObservableCollection<Person> LoadItems()
        {
            ObservableCollection<Person> items = new ObservableCollection<Person>();
            items.Add(new Person { Student = "A", Address = "HCM" });
            items.Add(new Person { Student = "B", Address = "DN" });
            return items;
        }

    }
    public class Person
    {
        public string Student { get; set; }
        public string Address { get; set; }
    }
}
