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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
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

        public ItemViewModel(Employee user)
        {
            this.Items = new ObservableCollection<Employee>();
            this._employee = user;
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

        private bool _noDirectReports;
        public bool NoDirectReports
        {
            get
            {
                return _noDirectReports;
            }
            set
            {
                if (value != _noDirectReports)
                {
                    _noDirectReports = value;
                    NotifyPropertyChanged("NoDirectReports");
                }
            }
        }

        public async Task LoadData()
        {
            this.Items.Clear();
            this.IsDataLoaded = false;

            //perform a graph query and fetch all data for the user, 
            //manager info and person to whom current reports
            var queryName = "manages";
            var userIds = new List<string> { _employee.Id };
            var results = await Appacitive.Sdk.Graph.Select(queryName, userIds);
            if (results.Count > 0)
            {
                var rootNode = results[0];
                //update the current employee object
                var context = rootNode.Object as Employee;
                _employee.Email = context.Email;
                _employee.CellPhone = context.CellPhone;
                _employee.OfficePhone = context.OfficePhone;


                //get the manager for current employee
                var managerNode = rootNode.GetChildren("managedby");
                if (managerNode != null && managerNode.Count > 0)
                    _employee.Manager = managerNode[0].Object as Employee;

                //get the direct reports
                var reportsToNode = rootNode.GetChildren("reports");
                if (reportsToNode != null && reportsToNode.Count > 0)
                {
                    reportsToNode.ForEach(r => this.Items.Add(r.Object as Employee));
                }
                else this.NoDirectReports = true;
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