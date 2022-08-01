using System.ComponentModel.DataAnnotations;

namespace ClassRoomManager.Entities
{
    public class ClassRoom : BaseEntity
    {
        public int? Number { get; set; }

        public int? Type { get; set; }

        public string Description { get; set; }

        public int? IsOccupied { get; set; }
    }
}
