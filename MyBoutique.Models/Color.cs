using MyBoutique.Common.BaseModels;

namespace MyBoutique.Models
{
    public class Color : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
