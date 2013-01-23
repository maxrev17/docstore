﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace Ildss
{
    public class IldssModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IQueue>().To<EventQueue>().InSingletonScope();
            this.Bind<IIndexer>().To<Indexer>();
            this.Bind<IHash>().To<HashSHA512>();
            this.Bind<IFileIndexContext>().To<FileIndexContext>().InSingletonScope();
            this.Bind<IMonitor>().To<DirectoryMonitor>().InSingletonScope();
            this.Bind<IEvent>().To<SecurityLogEvent>();//.Named("Security");
        }
    }
}