using ClassRoomManager.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManager.Additional
{
    public enum ClassRoomTypeEnum
    {
        [Description("Лекционная")]
        Lection = 0,

        [Description("Лабораторная")]
        Laboratory = 1,

        [Description("Практическая")]
        Practice = 2
    }
}

