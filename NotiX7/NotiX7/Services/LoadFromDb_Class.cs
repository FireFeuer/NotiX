using NotiX7.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiX7.Services
{
    public class LoadFromDb_Class
    {
        private Microsoft.EntityFrameworkCore.DbSet<NotiX7.Data.DbEntities.NoteDB> notes;

        public Microsoft.EntityFrameworkCore.DbSet<NotiX7.Data.DbEntities.NoteDB> LoadFromDb_Method()

        {

            using (NotixDbContext db = new NotixDbContext())

            {

                notes = db.Notes;

                return notes;

            }

        }
    }
}
