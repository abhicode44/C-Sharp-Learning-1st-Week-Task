using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Interface
{
    internal interface IuserService
    {
        public void AddUser();
        public void RemoveUser();
        public void UpdateUser();
        public void ViewDeatailsById();
        public void ViewAllDetails();

    }
}
