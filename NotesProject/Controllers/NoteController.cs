using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotesProject.Context;
using NotesProject.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace NotesProject.Controllers
{

	[ApiController]
	[Route("api/[controller]")]

	public class NoteController : ControllerBase
	{
		private readonly NotesDbContext _context;
		private readonly IMapper _mapper;
		private readonly JsonSerializerOptions _options;

		public NoteController(NotesDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
			_options = new()
			{
				ReferenceHandler = ReferenceHandler.IgnoreCycles,
				WriteIndented = true
			};
		}

		[HttpGet("GetAllNotes")]
		public string GetAllNotes()
		{
			var data = _context.Notes.Where(x => x.ParentId == null).ToList();
			string tt = "";
			foreach (var item in data)
			{
				recursive(item, ref tt);

			}
			return tt;
		}

		[HttpGet("GetById")]
		public IActionResult GetByIdNote(int id)
		{
			var data = _context.Notes.FirstOrDefault(x => x.Id == id);


			if (data is null)
			{
				return NotFound();
			}

			string tt = "";

			recursive(data, ref tt);

			return Ok(tt);
		}


		[HttpPost("CreateNote")]
		public IActionResult AddNote(NoteDto n)
		{
			var data = _mapper.Map<Note>(n);
			_context.Add(data);
			_context.SaveChanges();
			return Ok();


		}

		[HttpDelete("DeleteNote{id:int}")]
		public IActionResult DeleteNote(int id)
		{
			var data = _context.Notes.FirstOrDefault(x => x.Id == id);

			if (data is null)
			{
				return BadRequest();
			}

			_context.Notes.Remove(data);
			_context.SaveChanges();
			return Ok();

		}

	
		private void recursive(Note note, ref string result, string prefix = "")
		{
			note.Description = $"{prefix} {note.Description}";
			result += note.Description + Environment.NewLine;
			var temp = _context.Notes.Where(x => x.ParentId == note.Id).ToList();

			foreach (var item in temp)
			{
				recursive(item, ref result, prefix + "-");
			}
		}




	}
}
