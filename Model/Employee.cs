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
