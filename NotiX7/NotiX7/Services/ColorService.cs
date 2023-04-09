using NotiX7.Data;
using NotiX7.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiX7.Services
{
    public class ColorService
    {
        public ObservableCollection<ColorsCategory> LoadAllColorsFromDb()
        {
            ObservableCollection<ColorsCategory> colors = new ObservableCollection<ColorsCategory>();
            using (NotixDbContext db = new NotixDbContext())
            {

                Microsoft.EntityFrameworkCore.DbSet<ColorsCategory> colorsDB;
                colorsDB = db.ColorsCategories;
                foreach (ColorsCategory color in colorsDB)
                {
                    ColorsCategory addedColors = new ColorsCategory
                    {
                      Id = color.Id,
                      Text = color.Text,
                      Hex = color.Hex
                    };
                    colors.Add(addedColors);
                }
                return colors;
            }
        }
        public ObservableCollection<ColorsCategory> LoadNotAllColorsFromDb()
        {
            ObservableCollection<ColorsCategory> colors = new ObservableCollection<ColorsCategory>();
            using (NotixDbContext db = new NotixDbContext())
            {

                Microsoft.EntityFrameworkCore.DbSet<ColorsCategory> colorsDB;
                colorsDB = db.ColorsCategories;
                foreach (ColorsCategory color in colorsDB)
                {
                    ColorsCategory addedColors = new ColorsCategory
                    {
                        Id = color.Id,
                        Text = color.Text,
                        Hex = color.Hex
                    };
                    if(color.Text != "")
                    {
                        colors.Add(addedColors);
                    }                    
                }
                return colors;
            }
        }
    }
}
