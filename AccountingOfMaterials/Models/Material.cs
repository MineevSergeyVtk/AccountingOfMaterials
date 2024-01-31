namespace AccountingOfMaterials.Models
{
    public class Material
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string GroupOfMaterialName { get; set; } = null!;   // внешний ключ
        public GroupOfMaterial? GroupOfMaterial { get; set; }// навигационное свойство
    }
}
