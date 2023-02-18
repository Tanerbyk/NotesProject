using System.ComponentModel.DataAnnotations;

namespace NotesProject.Models
{
	public class NoteDto
	{
		public string Description { get; set; }

		public int? ParentId { get; set; }

	}
}
