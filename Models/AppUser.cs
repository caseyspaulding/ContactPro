﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ContactPro.Models;




namespace ContactPro.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50,ErrorMessage = "The {0} must be at least {2} and a max {1} characters."),MinLength(2)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and a max {1} characters."), MinLength(2)]
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }
        //allows a user to include its related contacts
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

        //allows a user to include its related categories
        public virtual ICollection <Category> Categories { get; set; } = new HashSet<Category>();
    }
}
