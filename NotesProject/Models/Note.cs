using System.ComponentModel.DataAnnotations;

namespace NotesProject.Models
{
	public class Note
	{
		[Key]
		public int Id { get; set; }

		public string Description { get; set; }

		public virtual Note? Parent { get; set; }
		public  int? ParentId { get; set; }




	}
}
