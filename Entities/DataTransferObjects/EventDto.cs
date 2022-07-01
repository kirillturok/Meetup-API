using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class EventDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Event name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description name is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Description is 60 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Plan name is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Plan is 60 characters.")]
        public string Plan { get; set; }

        [Required(ErrorMessage = "Organizer is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Organizer is 60 characters.")]
        public string Organizer { get; set; }

        [Required(ErrorMessage = "Speaker is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Speaker is 60 characters.")]
        public string Speaker { get; set; }

        [Required(ErrorMessage = "Address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Time is a required field.")]
        public DateTime Time { get; set; }
    }
}
