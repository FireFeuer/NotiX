using NotiX7.Data;
using NotiX7.Data.DbEntities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
                List<ColorsCategory> colorsDB;
                colorsDB = db.ColorsCategories.Where(c => c.Text != "").ToList();

                foreach (ColorsCategory color in colorsDB)
                {
                    colors.Add(color);
                }

                return colors;
            }
        }
    }
}
