using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Interface;
using ContactApp.Repository;

namespace ContactApp.Services
{
    internal class userService : IuserService
    {
        userRepository userrepository = new userRepository();

        public void AddUser()
        {
            userrepository.AddUser();
        }

        public void RemoveUser()
        {
            userrepository.RemoveUser();
        }

        public void UpdateUser()
        {
            userrepository.UpdateUser();
        }

        public void ViewAllDetails()
        {
            userrepository.ViewAllDetails();
        }

        public void ViewDeatailsById()
        {
            userrepository.ViewDeatailsById();
        }

    }
}
