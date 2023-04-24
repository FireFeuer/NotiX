using Microsoft.EntityFrameworkCore;
using NotiX7.Data;
using NotiX7.Data.DbEntities;
using NotiX7.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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
                        Id = note.Id,
                        X = note.X,
                        Y = note.Y,
                        Title = note.Title,
                        Text = note.Text,
                        FirstDate = note.FirstDate,
                        SecondDate = note.SecondDate,
                        ColorNavigation = note.ColorNavigation,
                        Is_open = note.Is_open,
                        Size = note.Size
                    };
                    notes.Add(addedNote);
                }
            }
            return notes;
        }

        public async Task AddUploadingNotesToTheDb(Note note)
        {
            using (NotixDbContext db = new NotixDbContext())
            {
                DbSet<NoteDB> notesDB;
                notesDB = db.Notes;
                notesDB.Add(new NoteDB
                {
                    Title = note.Title,
                    Text = note.Text,
                    FirstDate = note.FirstDate,
                    SecondDate = note.SecondDate,
                    Size = note.Size,
                    Color = note.ColorNavigation.Id,
                    X = note.X,
                    Y = note.Y,
                    Is_open = note.Is_open,
                });
                await db.SaveChangesAsync();
            }
        }
        public async Task ChangeUploadingNotesToTheDb(Note note)
        {
            if (note != null)
            {
                using (NotixDbContext db = new NotixDbContext())
                {
                    foreach (var noteDB in db.Notes)
                    {
                        if (note.Id == noteDB.Id)
                        {
                            noteDB.Title = note.Title;
                            noteDB.Text = note.Text;
                            noteDB.FirstDate = note.FirstDate;
                            noteDB.SecondDate = note.SecondDate;
                            noteDB.Size = note.Size;
                            noteDB.Color = note.ColorNavigation.Id;
                            noteDB.X = note.X;
                            noteDB.Y = note.Y;
                            noteDB.Is_open = note.Is_open;

                        }
                    }

                    await db.SaveChangesAsync();

                }
            }

        }
    }

}
















