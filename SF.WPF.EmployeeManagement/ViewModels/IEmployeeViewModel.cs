using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.WPF.EmployeeManagement.Models;

namespace SF.WPF.EmployeeManagement.ViewModels
{
    public interface IEmployeeViewModel
    {
        Employee Employee { get; set; }
    }
}
