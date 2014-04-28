//
//  Employee.cs
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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory
{
    public class Employee : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get { return String.Format("{0} {1}", FirstName, LastName).Trim(); } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string FaceUrl { get; set; }
        public string Department { get; set; }

        private string _cellphone;
        public string CellPhone
        {
            get { return _cellphone; }
            set
            {
                _cellphone = value;
                HasCellPhone = string.IsNullOrWhiteSpace(value) == false;
            }
        }
        private bool _hasCellPhone;
        public bool HasCellPhone
        {
            get { return _hasCellPhone; }
            set
            {
                _hasCellPhone = value;
                NotifyPropertyChanged("HasCellPhone");
            }
        }


        private string _officephone;
        public string OfficePhone
        {
            get { return _officephone; }
            set
            {
                _officephone = value;
                HasOfficePhone = string.IsNullOrWhiteSpace(value) == false;
            }
        }
        private bool _hasOfficePhone;
        public bool HasOfficePhone
        {
            get { return _hasOfficePhone; }
            set
            {
                _hasOfficePhone = value;
                NotifyPropertyChanged("HasOfficePhone");
            }
        }


        private Employee _manager;
        public Employee Manager
        {
            get { return _manager; }
            set
            {
                _manager = value;
                HasManager = value != null;
            }
        }
        private bool _hasManager;
        public bool HasManager
        {
            get { return _hasManager; }
            set
            {
                _hasManager = value;
                NotifyPropertyChanged("HasManager");
            }
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
