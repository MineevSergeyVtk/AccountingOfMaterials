using Microsoft.AspNetCore.Mvc.Rendering;
namespace AccountingOfMaterials.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<GroupOfMaterial> groupOfMaterial, string nameGroupOfMaterial, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            groupOfMaterial.Insert(0, new GroupOfMaterial { Name = "Все" });
            GroupOfMaterials = new SelectList(groupOfMaterial, "Name", "Name", nameGroupOfMaterial);
            SelectedGroupOfMaterial = nameGroupOfMaterial;
            SelectedName = name;
        }
        public SelectList GroupOfMaterials { get; } // список груп
        public string SelectedGroupOfMaterial { get; } // выбранная компания
        public string SelectedName { get; } // введенное имя
    }
}
