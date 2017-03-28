using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CSICDemoDec.Models
{
    public class WebGLDataModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Filename { get; set; }
    }
}