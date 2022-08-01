using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManager.Managers
{
    public class AppConfigManager
    {
        private static AppConfigManager _active;
        public static AppConfigManager Active
        {
            get
            {
                if (_active is null)
                    _active = new AppConfigManager();

                return _active;
            }
            set
            {
                _active = value;
            }
        }
    }
}
