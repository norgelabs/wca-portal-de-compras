﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wca.reembolso.application.Common
{
    public record PaginationQuery
    (   
        int FilialId = 0,
        int Page = 1,
        int PageSize = 10
    );
    
}
