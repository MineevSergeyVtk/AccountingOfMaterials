namespace AccountingOfMaterials.Models
{
    public class GroupOfMaterial
    {
        public string? Name { get; set; }
        public List<Material> Materials { get; set; } = new();// навигационное свойство
    }
}
