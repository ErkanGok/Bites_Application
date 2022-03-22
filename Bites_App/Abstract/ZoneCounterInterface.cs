﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erkan_GOK
{
    //İsimlendirme kuralları nedeniyle IZoneCounter denilebilirdi.
    public interface ZoneCounterInterface
    {
        // Feeds map data into solution class, then get ready for Solve() method.
        void Init(MapInterface map);
        // Counts zones in map provided with Init() method, then return the result.
        int Solve();
    }


}