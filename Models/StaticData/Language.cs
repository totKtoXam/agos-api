using System;
using System.ComponentModel.DataAnnotations;

namespace agos_api.Models.StaticData
{
    public class Language
    {
        [Key]
        public Guid LangId { get; set; }
        public string LanguageName { get; set; }
        public string LangCode { get; set; }
    }
}