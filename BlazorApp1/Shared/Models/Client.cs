using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        [StringLength(100)]
        public string ClientName { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string ClientSurname { get; set; } = null!;
        [Required] [StringLength(500)]
        public string Address { get; set; } = null!;
        public string CellNumber { get; set; } = null!;
        public string EmailId { get; set; } = null!;

        public string FullName
        {
            get
            {
                return ClientName + ", " + ClientSurname;
            }
        }
    }
}
