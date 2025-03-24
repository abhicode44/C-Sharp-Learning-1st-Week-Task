using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Interface
{
    internal interface IContactService
    {
        public void AddContact();
        public void RemoveContact();
        public void UpdateContact();
        public void ViewContactDeatailsById();
        
    }
}
