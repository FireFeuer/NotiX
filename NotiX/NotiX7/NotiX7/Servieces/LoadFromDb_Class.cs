using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotiX7.Data;

namespace NotiX7.Servieces
{
    public class LoadFromDb_Class
    {
      
        
            private Microsoft.EntityFrameworkCore.DbSet<NotiX7.Data.DbEntities.Note> notes;

            public Microsoft.EntityFrameworkCore.DbSet<NotiX7.Data.DbEntities.Note> LoadFromDb_Method()
            {
                using (NotixDbContext db = new NotixDbContext())
                {
                    notes = db.Notes;
                    return notes;
                }
            }
        
    }
}
