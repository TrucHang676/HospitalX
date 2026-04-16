using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalX.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }

        public UserDTO(string username, string status, string createdDate)
        {
            this.Username = username;
            this.Status = status;
            this.CreatedDate = createdDate;
        }
    }
}