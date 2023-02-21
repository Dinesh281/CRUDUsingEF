using CRUDUsingEF.Data;

namespace CRUDUsingEF.Models
{
    public class CategoryDAL
    {
        private readonly ApplicationDbContext db;
        public CategoryDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Category> GetAllCategory()
        {
            return db.Categories.ToList();
        }
        public Category GetCategoryById(int id)
        {
            var cat = db.Categories.Find(id);
            return cat;

        }
        public int AddCategory(Category cat)
        {
            db.Categories.Add(cat);
            int result = db.SaveChanges();

            return result;

        }
        public int UpdateCategory(Category cat)
        {
            // p contains old data
            int result = 0;
            var c = db.Categories.Where(x => x.CId == cat.CId).FirstOrDefault();
            if (c != null)
            {
                c.CName = cat.CName;
                result = db.SaveChanges();
            }
            return result;

        }
        public int DeleteCategory(int id)
        {
            int result = 0;
            var c = db.Categories.Where(x => x.CId == id).FirstOrDefault();
            if (c != null)
            {
                db.Categories.Remove(c);
                result = db.SaveChanges();
            }
            return result;

        }
    }
}
