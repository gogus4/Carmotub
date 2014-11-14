using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmotub.Data
{
    public class CarmotubServerEntities
    {
        private static CarmotubEntities _instance;
        public static CarmotubEntities Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CarmotubEntities();

                return _instance;
            }
        }

        public CarmotubServerEntities() { }
    }
}
