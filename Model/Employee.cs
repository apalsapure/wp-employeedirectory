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
    public class Employee : Appacitive.Sdk.APObject
    {
        public Employee()
            : base("employees")
        { }

        //special constructor
        public Employee(Appacitive.Sdk.APObject existing)
            : base(existing)
        { }

        public string Email
        {
            get
            {
                return this.Get<string>("email");
            }
            set
            {
                if (value == this.Designation) return;
                this.Set<string>("email", value);
                base.FirePropertyChanged("Email");
            }
        }
        public string Name { get { return String.Format("{0} {1}", FirstName, LastName).Trim(); } }
        public string FirstName
        {
            get
            {
                return this.Get<string>("firstname");
            }
            set
            {
                if (value == this.FirstName) return;
                this.Set<string>("firstname", value);
                base.FirePropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return this.Get<string>("lastname");
            }
            set
            {
                if (value == this.LastName) return;
                this.Set<string>("lastname", value);
                base.FirePropertyChanged("LastName");
            }
        }

        public string Designation
        {
            get
            {
                return this.Get<string>("title");
            }
            set
            {
                if (value == this.Designation) return;
                this.Set<string>("title", value);
                base.FirePropertyChanged("Designation");
            }
        }
        public string FaceUrl
        {
            get
            {
                return "http://cdn.appacitive.com/devcenter/root/emp-directory/" + this.Get<string>("pic");
            }
            set
            {
                if (value == this.FaceUrl) return;
                this.Set<string>("pic", value);
                base.FirePropertyChanged("FaceUrl");
            }
        }
        public string Department
        {
            get
            {
                return this.Get<string>("department");
            }
            set
            {
                if (value == this.Department) return;
                this.Set<string>("department", value);
                base.FirePropertyChanged("Department");
            }
        }

        public string CellPhone
        {
            get { return this.Get<string>("cellphone"); }
            set
            {
                if (value == this.CellPhone) return;
                this.Set<string>("cellphone", value);
                base.FirePropertyChanged("CellPhone");
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
                base.FirePropertyChanged("HasCellPhone");
            }
        }

        public string OfficePhone
        {
            get { return this.Get<string>("officephone"); ; }
            set
            {
                if (value == this.OfficePhone) return;
                this.Set<string>("officephone", value);
                base.FirePropertyChanged("OfficePhone");
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
                base.FirePropertyChanged("HasOfficePhone");
            }
        }

        private Employee _manager;
        public Employee Manager
        {
            get { return _manager; }
            set
            {
                _manager = value;
                base.FirePropertyChanged("Manager");
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
                base.FirePropertyChanged("HasManager");
            }
        }
    }
}
