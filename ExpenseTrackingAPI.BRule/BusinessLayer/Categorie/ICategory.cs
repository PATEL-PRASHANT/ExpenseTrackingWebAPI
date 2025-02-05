using ExpenseTrackingAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackingAPI.BRule.BusinessLayer.Categorie
{
    public interface ICategory
    {
        Task<List<CategoryModel>> GetCategory();

        Task InsertGetCategory(CategoryModel categoryModel);
        Task UpdateCategory(CategoryModel categoryModel);
        Task DeleteCategory(Int32 CategoryID);
    }
}
