using MyBoutique.Common.BaseModels;

namespace MyBoutique.Models
{
    public class Color : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
