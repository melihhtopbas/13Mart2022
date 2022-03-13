using _12Mart2022.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _12Mart2022.ViewModels
{
    public class PersonelFormViewModel
    {

        public IEnumerable<Departman> Departmanlar;
        public Personel Personel { get; set; }
    }
}