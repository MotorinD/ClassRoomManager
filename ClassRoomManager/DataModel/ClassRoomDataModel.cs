using ClassRoomManager.Additional;
using ClassRoomManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManager.DataModel
{
    public class ClassRoomDataModel : ClassRoom
    {
        public ClassRoomDataModel()
        {
        }

        public ClassRoomDataModel(ClassRoom classRoom)
        {
            this.Id = classRoom.Id;
            this.Number = classRoom.Number;
            this.Type = classRoom.Type;
            this.Description = classRoom.Description;
            this.IsOccupied = classRoom.IsOccupied;
        }

        public bool IsOccupiedBool
        {
            get { return (this.IsOccupied ?? 0) == 1; }
            set { this.IsOccupied = value ? 1 : 0; }
        }

        public ClassRoomTypeEnum TypeEnum
        {
            get { return (ClassRoomTypeEnum)(this.Type ?? 0); }
            set { this.Type = (int)value; }
        }
    }
}
