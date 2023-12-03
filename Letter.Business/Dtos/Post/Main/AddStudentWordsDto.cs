﻿using Microsoft.AspNetCore.Http;

namespace Letter.Business.Dtos.Post.Main
{
    public class AddStudentWordsDto
    {
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public int? CountryId { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
