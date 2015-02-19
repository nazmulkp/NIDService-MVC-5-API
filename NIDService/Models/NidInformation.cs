using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NIDService.Models
{
    public class NidInformation
    {
        [Key]
        public int NidInformationId { get; set; }
        public string Name { get; set; }
        public string FatherName { set; get; }
        public string MotherName { set; get; }
        public DateTime DateOfBirth{ set; get; }
        public int NidNO { set; get; }
        public string Address { set; get; }
        public string BloodGrop { set; get; }

    }
}