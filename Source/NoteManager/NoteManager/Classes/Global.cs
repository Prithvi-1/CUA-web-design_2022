using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace NoteManager
{
	using DB;

	public static class Global
	{
		public static Database Database { get; private set; }

		public static void Init(IWebHostEnvironment env)
		{
			Database = new Database(Path.Combine(env.ContentRootPath, "DB.db3"));
		}

		public static void AddNote(string text)
		{
			var now = DateTime.Now;
			Database.Add(new Note
			{
				Text = text,
				InsertDate = now,
				UpdateDate = now
			});
		}

		public static void EditNote(int id, string text)
		{
			var db = Database;
			var note = db.FindById(id);

			note.Text = text;
			note.UpdateDate = DateTime.Now;

			db.Edit(note);
		}
	}
}
