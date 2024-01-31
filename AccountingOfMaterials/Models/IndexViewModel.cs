namespace AccountingOfMaterials.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Material> Materials { get; }
        public FilterViewModel FilterViewModel { get; }
        public SortViewModel SortViewModel { get; }
        public PageViewModel PageViewModel { get; }
        public IndexViewModel(IEnumerable<Material> materials, FilterViewModel filterViewModel, SortViewModel sortViewModel, PageViewModel pageViewModel)
        {
            Materials = materials;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
            PageViewModel = pageViewModel;
        }
    }
}
