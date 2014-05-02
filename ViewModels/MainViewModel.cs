//
//  MainViewModel.cs
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
using EmployeeDirectory.Resources;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EmployeeDirectory
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<Employee>();
        }

        /// <summary>
        /// A collection for User objects.
        /// </summary>
        public ObservableCollection<Employee> Items { get; private set; }
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
        public async Task LoadData()
        {
            this.IsDataLoaded = false;
            this.Items.Clear();

            //Get all objects of type employees
            var results = await Appacitive.Sdk.APObjects.FindAllAsync("employee",
                                                                       fields: new List<string> { "firstname", "lastname", "title", "pic" },
                                                                       orderBy: "__id",
                                                                       sortOrder: Appacitive.Sdk.SortOrder.Descending);

            //Iterate over the result object till all the movies are fetched
            while (true)
            {
                //converting appacitive object to model
                results.ForEach(r => this.Items.Add(new Employee(r)));

                //check if its last set of record
                if (results.IsLastPage)
                    break;

                //fetch next set of record
                results = await results.NextPageAsync();
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