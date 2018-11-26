using quaneu.datalayer.Models;
using quaneu.datalayer.Models.Image;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace quaneu.datalayer.Entities.Extensions
{
    public class WordPressTemplateExtended
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Html)]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<WordPressCategory> Categories { get; set; }
        public int ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }


        public WordPressTemplateExtended()
        {
        }

        public WordPressTemplateExtended(WordPressTemplate wordPressTemplate)
        {
            Id = wordPressTemplate.Id;
            Title = wordPressTemplate.Title;
            Description = wordPressTemplate.Description;
            CreationDate = wordPressTemplate.CreationDate;
            UpdatedDate = wordPressTemplate.UpdatedDate;
            ImageId = wordPressTemplate.ImageId;
            Image = wordPressTemplate.Image;
        }
    }
}
