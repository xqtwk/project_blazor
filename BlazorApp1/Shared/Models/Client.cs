using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string ClientName { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string ClientSurname { get; set; } = null!;
        [Required] [StringLength(500)]
        public string Address { get; set; } = null!;
        [Required]
        [Phone]
        public string CellNumber { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string EmailId { get; set; } = null!;
        [ForeignKey(nameof(FileModel))]
        public byte[] FileModel { get; set; }

        public string FullName
        {
            get
            {
                return ClientName + ", " + ClientSurname;
            }
        }
    }
}
