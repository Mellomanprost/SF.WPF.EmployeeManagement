using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SF.WPF.EmployeeManagement.Models;

namespace SF.WPF.EmployeeManagement.ViewModels
{
    class EmployeesViewModel
    {
        private EmployeeRepository _employeeRepository;

        public EmployeesViewModel()
        {
            _employeeRepository = new EmployeeRepository();
            FillListView();
        }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
            }
        }

        private string _filter;
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                FillListView();
            }
        }

        private void FillListView()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                _employees =
                    new ObservableCollection<Employee>(_employeeRepository.GetAll()
                        .Where(v => v.FirstName.Contains(_filter)));
            }
            else
                _employees = new ObservableCollection<Employee>(
                    _employeeRepository.GetAll());
        }
    }
}
