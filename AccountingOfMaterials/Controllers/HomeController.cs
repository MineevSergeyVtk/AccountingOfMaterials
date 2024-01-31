using AccountingOfMaterials.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AccountingOfMaterials.Controllers
{
    public class HomeController : Controller
    {
        MaterialsContext db;
        public HomeController(MaterialsContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(string name, string nameGroupOfMaterial = "Все", SortState sortOrder = SortState.NameAsc, int page = 1)
        {
            int pageSize = 7;
            //фильтрация
            IQueryable<Material> materials = db.Materials.Include(x => x.GroupOfMaterial);
            if (nameGroupOfMaterial != "Все")
            {
                materials = materials.Where(p => p.GroupOfMaterial!.Name == nameGroupOfMaterial);
            }
            if (!string.IsNullOrEmpty(name))
            {
                materials = materials.Where(p => p.Name!.Contains(name));
            }
            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    materials = materials.OrderByDescending(s => s.Name);
                    break;
                case SortState.GroupAsc:
                    materials = materials.OrderBy(s => s.GroupOfMaterial!.Name);
                    break;
                case SortState.GroupDesc:
                    materials = materials.OrderByDescending(s => s.GroupOfMaterial!.Name);
                    break;
                default:
                    materials = materials.OrderBy(s => s.Name);
                    break;
            }
            // пагинация
            var count = await materials.CountAsync();
            var items = await materials.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new FilterViewModel(db.GroupOfMaterials.ToList(), nameGroupOfMaterial, name),
                new SortViewModel(sortOrder),
                new PageViewModel(count, page, pageSize)
                );
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Group = new SelectList(db.GroupOfMaterials.ToList(), "Name", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name, string description, string nameGroup)
        {
            db.Materials.Add(new Material() { Name = name, Description = description, GroupOfMaterialName = nameGroup});
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string name)
        {
            if (name != null)
            {
                Material? material = await db.Materials.FirstOrDefaultAsync(p => p.Name == name);
                if (material != null)
                {
                    db.Materials.Remove(material);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        public IActionResult GetFile()
        {
            string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "css/StyleSheet.css");
            string file_type = "text/css";
            string file_name = "css/StyleSheet.css";
            return PhysicalFile(file_path, file_type, file_name);
        }
    }
}
