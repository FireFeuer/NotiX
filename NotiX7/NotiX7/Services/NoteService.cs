using NotiX7.Data;
using NotiX7.Data.DbEntities;
using NotiX7.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace NotiX7.Services
{
    public class NoteService
    {
        public ObservableCollection<Note> LoadNotesFromDb()
        {
            ObservableCollection<Note> notes = new ObservableCollection<Note>();
            using (NotixDbContext db = new NotixDbContext())
            {
                db.ColorsCategories.ToList();
                Microsoft.EntityFrameworkCore.DbSet<NoteDB> notesDB;
                notesDB = db.Notes;
                foreach (NoteDB note in notesDB)
                {
                    Note addedNote = new Note
                    {
                        X = note.X,
                        Y = note.Y,
                        Title = note.Title,
                        Text = note.Text,
                        FirstDate = note.FirstDate,
                        SecondDate = note.SecondDate,
                        ColorNavigation = note.ColorNavigation
                    };
                    notes.Add(addedNote);
                }
            }
            return notes;

        }
    }

}
















