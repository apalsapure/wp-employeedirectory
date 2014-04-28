using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace EmployeeDirectory
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private Employee _user;

        public ItemViewModel(Employee user)
        {
            this.Items = new ObservableCollection<Employee>();
            this._user = user;
        }

        public ObservableCollection<Employee> Items { get; private set; }
        public Employee User { get { return _user; } }


        private bool _isDataLoaded;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public bool IsDataLoaded
        {
            get
            {
                return _isDataLoaded;
            }
            set
            {
                if (value != _isDataLoaded)
                {
                    _isDataLoaded = value;
                    NotifyPropertyChanged("IsDataLoaded");
                }
            }
        }
        
        public void LoadData()
        {
            this.Items.Clear();
            this.IsDataLoaded = false;

            //Adding dummy data
            this.Items.Add(new Employee() { Id = "0", FirstName = "one", LastName = "employee", Designation = "CEO", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "1", FirstName = "two", LastName = "employee", Designation = "General Manager", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "2", FirstName = "three", LastName = "employee", Designation = "Sales Manager", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "3", FirstName = "four", LastName = "employee", Designation = "CTO", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "4", FirstName = "five", LastName = "employee", Designation = "Sales Executive", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "5", FirstName = "six", LastName = "employee", Designation = "HR", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "6", FirstName = "seven", LastName = "employee", Designation = "Finance Head", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "7", FirstName = "eight", LastName = "employee", Designation = "Project Manager", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "8", FirstName = "nine", LastName = "employee", Designation = "Team Lead", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "9", FirstName = "ten", LastName = "employee", Designation = "Developer", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "10", FirstName = "eleven", LastName = "employee", Designation = "Developer", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "11", FirstName = "twelve", LastName = "employee", Designation = "Accountant", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "12", FirstName = "thirteen", LastName = "employee", Designation = "Accountant", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "13", FirstName = "fourteen", LastName = "employee", Designation = "Developer", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "14", FirstName = "fifteen", LastName = "employee", Designation = "Developer", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new Employee() { Id = "15", FirstName = "sixteen", LastName = "employee", Designation = "Developer", FaceUrl = "/Assets/DefaultImage.png" });

            //Modify following logic depending upon response from Appacitive
            _user.Manager = null;
            if (_user.Designation != "CEO")
            {
                _user.Manager = this.Items[0];
            }
            



            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}