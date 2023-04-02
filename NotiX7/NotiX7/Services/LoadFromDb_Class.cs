using NotiX7.Data;
using NotiX7.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiX7.Services
{
    public class LoadFromDb_Class
    {
      
      

        public Microsoft.EntityFrameworkCore.DbSet<NoteDB> LoadFromDb_Method()
        {
            using (NotixDbContext db = new NotixDbContext())
            {
                Microsoft.EntityFrameworkCore.DbSet<NoteDB> notes;
                notes = db.Notes;
                return notes;
            }
        }
    }
}
