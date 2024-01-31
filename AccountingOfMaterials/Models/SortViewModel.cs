namespace AccountingOfMaterials.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; } // значение для сортировки по имени
        public SortState GroupSort { get; }   // значение для сортировки по компании
        public SortState Current { get; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            GroupSort = sortOrder == SortState.GroupAsc ? SortState.GroupDesc : SortState.GroupAsc;
            Current = sortOrder;
        }
    }
}
