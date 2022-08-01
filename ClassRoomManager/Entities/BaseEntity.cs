﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManager.Entities
{
    public class BaseEntity
    {
        [KeyAttribute]
        public int Id { get; set; }
    }
}
