using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
//using WcfSamples.DynamicProxy;

namespace ExcelAddin.Helper
{
    class ConnectionHelper
    {
        //public static DynamicProxy GetProxy()
        //{
        //    DynamicProxyFactory factory = new DynamicProxyFactory("http://service/PluralMDService/ExcelData.asmx?WSDL");

        //    foreach (ServiceEndpoint endpoint in factory.Endpoints)
        //    {
        //        endpoint.Binding.SendTimeout = new TimeSpan(1, 0, 0);
        //        endpoint.Binding.OpenTimeout = new TimeSpan(1, 0, 0);
        //        endpoint.Binding.ReceiveTimeout = new TimeSpan(1, 0, 0);
        //        endpoint.Binding.CloseTimeout = new TimeSpan(1, 0, 0);

        //        XmlDictionaryReaderQuotas myReaderQuotas = new XmlDictionaryReaderQuotas();
        //        myReaderQuotas.MaxStringContentLength = 8192000;
        //        myReaderQuotas.MaxArrayLength = 2147483647;
        //        myReaderQuotas.MaxBytesPerRead = 2147483647;
        //        myReaderQuotas.MaxDepth = 32;
        //        myReaderQuotas.MaxNameTableCharCount = 2147483647;

        //        if (endpoint.Binding.GetType().GetProperty("ReaderQuotas") != null)
        //        {
        //            endpoint.Binding.GetType().GetProperty("ReaderQuotas").SetValue(endpoint.Binding, myReaderQuotas, null);
        //        }
        //    }

        //    return factory.CreateProxy("ExcelDataSoap");
        //}
    }
}
