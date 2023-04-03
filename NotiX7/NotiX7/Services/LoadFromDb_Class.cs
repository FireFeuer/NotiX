using NotiX7.Data;
using NotiX7.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotiX7.Models;
using NotiX7.Views.UserControls;


namespace NotiX7.Services
{
    public class LoadFromDb_Class
    {
        public List<Note> LoadFromDb_Method()
        {
            List<Note> notes = new List<Note>();
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
                return notes.ToList();

        }
    }

}
   
    
      
        
            
            
                 
               

              
            
            
               
            
        
    
