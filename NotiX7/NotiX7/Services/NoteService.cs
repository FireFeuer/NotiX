using NotiX7.Data;
using NotiX7.Data.DbEntities;
using NotiX7.Models;
using NotiX7.Views.UserControls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using Microsoft.EntityFrameworkCore;

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
                Microsoft.EntityFrameworkCore.DbSet<NoteDB> notesDB;
                notesDB = db.Notes;
                notesDB.Add(new NoteDB { 
                       Title = note.Title,
                       Text = note.Text,
                       FirstDate = note.FirstDate,
                       SecondDate = note.SecondDate,
                       Size = note.Size,
                       Color = note.Color,
                       X = note.X,
                       Y = note.Y,
                       Is_open = note.Is_open,
                });
                db.SaveChanges();
            }
        }
        public async Task ChangeUploadingNotesToTheDb(Note note)
        {
            using (NotixDbContext db = new NotixDbContext())
            {
                foreach(var noteDB in db.Notes)
                {
                    if(note.Title == noteDB.Title)
                    {

                        //noteDB.Title = "ASD";
                        //noteDB.Text = "SAD";
                        //noteDB.FirstDate = "11/11/1111";
                        //noteDB.SecondDate = "12/12/1200";
                        //noteDB.Size = 1;
                        //noteDB.Color = 1;
                        //noteDB.X = 111;
                        //noteDB.Y = 124;
                        //noteDB.Is_open = 1;
                        noteDB.Title = note.Title;
                        noteDB.Text = note.Text;
                        noteDB.FirstDate = note.FirstDate;
                        noteDB.SecondDate = note.SecondDate;
                        noteDB.Size = note.Size;
                        noteDB.Color = 1;
                        noteDB.X = note.X;
                        noteDB.Y = note.Y;
                        noteDB.Is_open = note.Is_open;
                        MessageBox.Show("sad");
                        MessageBox.Show(noteDB.Id.ToString());
                    }
                     
                }
             
                db.SaveChanges();
                
            }
        }
    }

}
















