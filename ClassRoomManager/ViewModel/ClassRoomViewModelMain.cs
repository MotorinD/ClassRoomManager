using ClassRoomManager.Additional;
using ClassRoomManager.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManager.ViewModel
{
    class ClassRoomViewModelMain
    {
        public ClassRoomDataModel DataModel;

        public int Number { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public bool IsOccupiedBool { get; set; }

        public ClassRoomViewModelMain(ClassRoomDataModel dataModel)
        {
            this.DataModel = dataModel;
            this.Number = dataModel.Number ?? 0;
            this.Type = dataModel.TypeEnum.GetDescription();
            this.Description = dataModel.Description;
            this.IsOccupiedBool = dataModel.IsOccupiedBool;
        }
    }
}
