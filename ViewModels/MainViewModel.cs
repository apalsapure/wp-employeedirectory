using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using EmployeeDirectory.Resources;

namespace EmployeeDirectory
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<User>();
        }

        /// <summary>
        /// A collection for User objects.
        /// </summary>
        public ObservableCollection<User> Items { get; private set; }
        private bool _isDataLoaded;
        public bool IsDataLoaded
        {
            get { return _isDataLoaded; }
            private set
            {
                _isDataLoaded = value;
                NotifyPropertyChanged("IsDataLoaded");
            }
        }

        /// <summary>
        /// Creates and adds a few User objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            this.IsDataLoaded = false;
            this.Items.Clear();

            // Sample data; replace with real data
            this.Items.Add(new User() { Id = "0", FirstName = "one", LastName = "employee", Designation = "CEO", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "1", FirstName = "two", LastName = "employee", Designation = "General Manager", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "2", FirstName = "three", LastName = "employee", Designation = "Sales Manager", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "3", FirstName = "four", LastName = "employee", Designation = "CTO", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "4", FirstName = "five", LastName = "employee", Designation = "Sales Executive", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "5", FirstName = "six", LastName = "employee", Designation = "HR", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "6", FirstName = "seven", LastName = "employee", Designation = "Finance Head", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "7", FirstName = "eight", LastName = "employee", Designation = "Project Manager", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "8", FirstName = "nine", LastName = "employee", Designation = "Team Lead", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "9", FirstName = "ten", LastName = "employee", Designation = "Developer", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "10", FirstName = "eleven", LastName = "employee", Designation = "Developer", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "11", FirstName = "twelve", LastName = "employee", Designation = "Accountant", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "12", FirstName = "thirteen", LastName = "employee", Designation = "Accountant", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "13", FirstName = "fourteen", LastName = "employee", Designation = "Developer", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "14", FirstName = "fifteen", LastName = "employee", Designation = "Developer", FaceUrl = "/Assets/DefaultImage.png" });
            this.Items.Add(new User() { Id = "15", FirstName = "sixteen", LastName = "employee", Designation = "Developer", FaceUrl = "/Assets/DefaultImage.png" });

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