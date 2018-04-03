using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Autofac;
using Autofac.Core;
using ESFA.DC.Data.LARS.Model;
using ESFA.DC.Data.LARS.Model.Interfaces;
using ESFA.DC.Data.Postcodes.Model;
using ESFA.DC.Data.Postcodes.Model.Interfaces;
using ESFA.DC.ILR.FundingService.ALB.ExternalData;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.OPA.Model.Interface;
using ESFA.DC.OPA.Service;
using ESFA.DC.OPA.Service.Builders;
using ESFA.DC.OPA.Service.Interface;
using ESFA.DC.OPA.Service.Interface.Builders;

namespace ESFA.DC.ILR.FundingService.ALB.Console
{
    public static class Program
    {
        private static Stream stream;

        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            IMessage message;

            try
            {
                System.Console.WriteLine("Loading file..");

                // stream = new FileStream(@"Files\ILR-10006341-1718-20180118-023456-01.xml", FileMode.Open);
                stream = new FileStream(@"Files\ILR-10006341-1718-20180118-023456-02.xml", FileMode.Open);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("File Load Error: Problem loading file... {0}", ex);
            }

            using (var reader = XmlReader.Create(stream))
            {
                var serializer = new XmlSerializer(typeof(Message));
                message = serializer.Deserialize(reader) as Message;
            }

            stream.Close();

            System.Console.WriteLine("Executing Funding Service...");

            var builder = ConfigureBuilder();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var fundingService = container.Resolve<IFundingSevice>();

                stopwatch.Reset();
                stopwatch.Start();

                var fundingOutputs = fundingService.ProcessFunding(message);

                var dataPersister = new DataPersister();
                dataPersister.PersistData(fundingOutputs);

                stopwatch.Stop();
                var inputsCreateTime = stopwatch.Elapsed;
                System.Console.WriteLine("Process completed in " + inputsCreateTime.ToString());
                stopwatch.Reset();
            }
        }

        private static ContainerBuilder ConfigureBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LARS>().As<ILARS>().InstancePerLifetimeScope();
            builder.RegisterType<Postcodes>().As<IPostcodes>().InstancePerLifetimeScope();
            builder.RegisterType<ReferenceDataCache>().As<IReferenceDataCache>().InstancePerLifetimeScope();
            builder.RegisterType<ReferenceDataCachePopulationService>().As<IReferenceDataCachePopulationService>().InstancePerLifetimeScope();
            builder.RegisterType<SessionBuilder>().As<ISessionBuilder>().InstancePerLifetimeScope();
            builder.RegisterType<OPADataEntityBuilder>().As<IOPADataEntityBuilder>().InstancePerLifetimeScope();
            builder.RegisterType<OPAService>().As<IOPAService>().WithParameters(Parameters()).InstancePerLifetimeScope();
            builder.RegisterType<AttributeBuilder>().As<IAttributeBuilder<IAttributeData>>().InstancePerLifetimeScope();
            builder.RegisterType<DataEntityBuilder>().As<IDataEntityBuilder>().InstancePerLifetimeScope();
            builder.RegisterType<Service.Implementation.FundingService>().As<IFundingSevice>();

            return builder;
        }

        private static IEnumerable<Parameter> Parameters()
        {
            IEnumerable<Parameter> parameters = new List<Parameter>
            {
               new NamedParameter("rulebaseZipPath", @".Rulebase.Loans Bursary 17_18.zip"),
               new NamedParameter("yearStartDate", new DateTime(2017, 8, 1))
            };

            return parameters;
        }
    }
}
