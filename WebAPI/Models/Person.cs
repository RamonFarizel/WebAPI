using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Base;

namespace WebAPI.Models
{
    public class Person : BaseEntity
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressPerson { get; set; }
        public string Gender { get; set; }

    }
}
