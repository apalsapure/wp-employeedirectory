//
//  ItemViewModel.cs
//  Appacitive Quickstart
//
//  Copyright 2014 Appacitive, Inc.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//


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
        private Employee _employee;

        public ItemViewModel(Employee employee)
        {
            this.Items = new ObservableCollection<Employee>();
            this._employee = employee;
        }

        public ObservableCollection<Employee> Items { get; private set; }
        public Employee Employee { get { return _employee; } }


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
            _employee.Manager = null;
            if (_employee.Designation != "CEO")
            {
                _employee.Manager = this.Items[0];
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