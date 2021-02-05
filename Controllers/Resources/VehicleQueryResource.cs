using vega.Extensions;

namespace vega.Controllers.Resources
{
    public class VehicleQueryResource: IQueryObject
    {
        public int? MakeId { get; set; }  
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }  
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}