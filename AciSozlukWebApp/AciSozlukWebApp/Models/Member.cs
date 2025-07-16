using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AciSozlukWebApp.Models
{
    public class Member:Entity
    {
        public int MemberRole_ID {  get; set; }
        [ForeignKey("MemberRole_ID")]
        public virtual MemberRole MemberRole { get; set; }

        [Display(Name ="KullanıcıAdı")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string NickName {  get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Password { get; set; }

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Gender { get; set; }

        [Display(Name = "DoğumTarihi")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public DateTime Birthday { get; set; }

        public string Image {  get; set; }

        public DateTime CreationTime { get; set; }= DateTime.Now;
    }
}