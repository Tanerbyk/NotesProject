using AutoMapper;
using NotesProject.Models;

namespace NotesProject.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<NoteDto, Note>();
		}
	}
}
