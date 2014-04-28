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
        private User _user;

        public ItemViewModel(User user)
        {
            this.Items = new ObservableCollection<User>();
            this._user = user;
        }

        public ObservableCollection<User> Items { get; private set; }
        public User User { get { return _user; } }

        private string _id;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _lineOne;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineOne
        {
            get
            {
                return _lineOne;
            }
            set
            {
                if (value != _lineOne)
                {
                    _lineOne = value;
                    NotifyPropertyChanged("LineOne");
                }
            }
        }

        private string _lineTwo;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineTwo
        {
            get
            {
                return _lineTwo;
            }
            set
            {
                if (value != _lineTwo)
                {
                    _lineTwo = value;
                    NotifyPropertyChanged("LineTwo");
                }
            }
        }

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