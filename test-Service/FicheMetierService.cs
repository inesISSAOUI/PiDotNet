﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_data;
using test_data.Infrastructure;
using test_ServicePattern;

namespace test_Service
{
    
    public class FicheMetierService : Service<fichemetier> , IFicheMetierService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public FicheMetierService() : base(UOW)
        {

        }

    }
}
