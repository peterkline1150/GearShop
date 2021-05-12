using GearShop.Data;
using GearShop.Models.Category_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearShop.Services
{
    public class CategoryService
    {
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Categories.Select(e => new CategoryListItem()
                {
                    CategoryId = e.CategoryId,
                    CategoryName = e.CategoryName,
                    CategoryType = e.CategoryType
                });
                return query.ToArray();
            }
        }

        public bool CreateCategory(CategoryCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Category()
                {
                    CategoryName = model.CategoryName,
                    CategoryType = model.CategoryType
                };

                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Find(id);

                return new CategoryDetail()
                {
                    CategoryId = entity.CategoryId,
                    CategoryName = entity.CategoryName,
                    CategoryType = entity.CategoryType,
                    GearInCategory = entity.GearInCategory
                };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Find(model.CategoryId);

                entity.CategoryName = model.CategoryName;
                entity.CategoryType = model.CategoryType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Find(id);

                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
