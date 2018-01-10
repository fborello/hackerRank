using ExcelDna.Integration;
using System;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Security;
//using WcfSamples.DynamicProxy;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Globalization;

namespace ExcelBTCAddin
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class MarketData
    {
        //private static DynamicProxy proxy = Helper.ConnectionHelper.GetProxy();

        private static ExcelDataService.ExcelDataSoapClient _ExcelService;
        private static ExcelDataService.ExcelDataSoapClient ExcelService
        {
            get
            {
                if (_ExcelService == null)
                {
                    //_ExcelService = new ExcelDataService.ExcelDataSoapClient();

                    var binding = new BasicHttpBinding();
                    binding.Name = "ExcelDataSoap";
                    binding.CloseTimeout = TimeSpan.FromMinutes(1);
                    binding.OpenTimeout = TimeSpan.FromMinutes(1);
                    binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
                    binding.SendTimeout = TimeSpan.FromMinutes(1);
                    binding.AllowCookies = false;
                    binding.BypassProxyOnLocal = false;
                    binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
                    binding.MaxBufferSize = 2147483647;
                    binding.MaxReceivedMessageSize = 2147483647;
                    binding.MaxBufferPoolSize = 2147483647;
                    binding.MessageEncoding = WSMessageEncoding.Text;
                    binding.TextEncoding = System.Text.Encoding.UTF8;
                    binding.TransferMode = TransferMode.Buffered;
                    binding.UseDefaultWebProxy = true;

                    binding.ReaderQuotas.MaxDepth = 32;
                    binding.ReaderQuotas.MaxStringContentLength = 2147483647;
                    binding.ReaderQuotas.MaxArrayLength = 2147483647;
                    binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                    binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;

                    binding.Security.Mode = BasicHttpSecurityMode.None;
                    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                    binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
                    binding.Security.Transport.Realm = "";
                    binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                    binding.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Default;

                    string endpointURL = "http://service/PluralMDService/ExcelData.asmx";
                    EndpointAddress endpoint = new EndpointAddress(endpointURL);
                    _ExcelService = new ExcelDataService.ExcelDataSoapClient(binding, endpoint);
                }
                return _ExcelService;
            }
        }

        private static ABOUService.PluralAssetBackOfficeUtilityServiceSoapClient _ABOUService;
        private static ABOUService.PluralAssetBackOfficeUtilityServiceSoapClient ABOUService
        {
            get
            {
                if (_ABOUService == null)
                {
                    var binding = new BasicHttpBinding();
                    binding.Name = "PluralAssetBackOfficeUtilityServiceSoap";
                    binding.CloseTimeout = TimeSpan.FromMinutes(1);
                    binding.OpenTimeout = TimeSpan.FromMinutes(1);
                    binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
                    binding.SendTimeout = TimeSpan.FromMinutes(1);
                    binding.AllowCookies = false;
                    binding.BypassProxyOnLocal = false;
                    binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
                    binding.MaxBufferSize = 2147483647;
                    binding.MaxReceivedMessageSize = 2147483647;
                    binding.MaxBufferPoolSize = 2147483647;
                    binding.MessageEncoding = WSMessageEncoding.Text;
                    binding.TextEncoding = System.Text.Encoding.UTF8;
                    binding.TransferMode = TransferMode.Buffered;
                    binding.UseDefaultWebProxy = true;

                    binding.ReaderQuotas.MaxDepth = 32;
                    binding.ReaderQuotas.MaxStringContentLength = 2147483647;
                    binding.ReaderQuotas.MaxArrayLength = 2147483647;
                    binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                    binding.ReaderQuotas.MaxNameTableCharCount = 2147483647;

                    binding.Security.Mode = BasicHttpSecurityMode.None;
                    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                    binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
                    binding.Security.Transport.Realm = "";
                    binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                    binding.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Default;

                    string endpointURL = "http://service/PluralAssetBackOfficeUtilityService/PluralAssetBackOfficeUtilityService.asmx";
                    EndpointAddress endpoint = new EndpointAddress(endpointURL);
                    _ABOUService = new ABOUService.PluralAssetBackOfficeUtilityServiceSoapClient(binding, endpoint);
                }
                return _ABOUService;
            }
        }

        private static object ConvertObjectOutput(object Output)
        {
            decimal Decimal;
            if (Decimal.TryParse(Output.ToString(), out Decimal))
            {
                return Decimal;
            }
            else
            {
                return Output.ToString();
            }
        }

        //Nome da função no Excel Addin antigo. Mantida para efeito de compatibilidade (parâmetros são os mesmos)
        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static object PluralMDFIHS(string FinancialInstrumentHistoryField, string Code, double DoubleDate)
        {
            XlCall.Excel(XlCall.xlfVolatile, true);
            return GetFinancialInstrumentData(FinancialInstrumentHistoryField, Code, DoubleDate);
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static object PluralMDFILastTick(string FinancialInstrument)
        {
            XlCall.Excel(XlCall.xlfVolatile, true);
            return ExcelService.GetFinancialInstrumentData_LastTick(FinancialInstrument);
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static object PluralGetTransactions([ExcelArgument(Description = "Ticker Bloomberg do fundo no Market Data")] string fundMarketDataCode
            , [ExcelArgument(Description = "Data")] DateTime date
            , [ExcelArgument(Description = "'APL' (Aplicação), 'RES' (Resgate), 'NET' (Saldo)")] string type
            , [ExcelArgument(Description = "'DIA' (Movimentações do Dia), 'COT' (Cotizações do Dia), 'LIQ' (Liquidações do Dia) ")] string dateType)
        {
            XlCall.Excel(XlCall.xlfVolatile, true);
            return ABOUService.TransactionsToExcelAddin(fundMarketDataCode, date, type, dateType);
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static object PluralTest(Decimal LastPrice, string Code)
        {
            XlCall.Excel(XlCall.xlfVolatile, true);

            return ExcelService.Test(LastPrice.ToString(), Code);
            //return (Code + "_" + Cotacao).ToString();
        }


        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static object GetFinancialInstrumentData(string FinancialInstrumentHistoryField, string Code, double DoubleDate)
        {
            XlCall.Excel(XlCall.xlfVolatile, true);
            object Output = ExcelService.GetFinancialInstrumentData_New(FinancialInstrumentHistoryField, Code, DoubleDate, false);
            return ConvertObjectOutput(Output);
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static object GetFinancialInstrumentData_ExactDate(string FinancialInstrumentHistoryField, string Code, double DoubleDate)
        {
            XlCall.Excel(XlCall.xlfVolatile, true);
            object Output = ExcelService.GetFinancialInstrumentData_New(FinancialInstrumentHistoryField, Code, DoubleDate, true);
            return ConvertObjectOutput(Output);
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static object GetCETIPAccumulatedCDI(double StartDate, double EndDate, decimal Percentage)
        {
            XlCall.Excel(XlCall.xlfVolatile, true);

            try
            {
                DateTime DateStart = DateTime.FromOADate(StartDate);
                DateTime DateEnd = DateTime.FromOADate(EndDate);
                object Output = ExcelService.GetCETIPAccumulatedCDI(DateStart, DateEnd, Percentage);
                return ConvertObjectOutput(Output);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static object GetCETIPAccumulatedCDIWithSpread(DateTime StartDate, DateTime EndDate, decimal SpreadPercentage)
        {
            XlCall.Excel(XlCall.xlfVolatile, true);

            object Output = ExcelService.GetCETIPAccumulatedCDIWithSpread(StartDate, EndDate, SpreadPercentage);
            return ConvertObjectOutput(Output);
        }

        [ComRegisterFunctionAttribute]
        public static void RegisterFunction(System.Type t)
        {
            Microsoft.Win32.Registry.ClassesRoot.CreateSubKey
                ("CLSID\\{" + t.GUID.ToString().ToUpper() + "}\\Programmable");
        }

        [ComUnregisterFunctionAttribute]
        public static void UnregisterFunction(System.Type t)
        {
            Microsoft.Win32.Registry.ClassesRoot.DeleteSubKey
                ("CLSID\\{" + t.GUID.ToString().ToUpper() + "}\\Programmable");
        }


        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static string PluralInpuCorporateDesk(Decimal LastPrice, string Code)
        {
            XlCall.Excel(XlCall.xlfVolatile, true);

            ExcelService.PluralInpuCorporateDesk(LastPrice.ToString(), Code);
            return "OK";
            //return (Code + "_" + Cotacao).ToString();
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static object FXTradingSpotInsert(string financialInstrumentExchangeCode, DateTime date, decimal buyPriceD0, decimal buyPriceD1, decimal buyPriceD2,
            decimal sellPriceD0, decimal sellPriceD1, decimal sellPriceD2)
        {
            XlCall.Excel(XlCall.xlfVolatile, true);
            try
            {
                return ExcelService.FXTradingSpotInsert(financialInstrumentExchangeCode, date, buyPriceD0, buyPriceD1, buyPriceD2, sellPriceD0, sellPriceD1, sellPriceD2);
            }
            catch (Exception ex)
            {
                return "ERRO";
            }
            //return (Code + "_" + Cotacao).ToString();
            //=FXTradingSpotInsert("USD/BRL";TODAY();A3;A4;A5;B3;B4;B5)
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static decimal FXTradingPendingOccurrenceValueSelect(DateTime date,
            [ExcelArgument(Description = "USD ou EUR")] string Currency,
            [ExcelArgument(Description = "ENTRADA ou SAIDA ou NET")]string Type)
        {
            try
            {
                return ExcelService.FXTradingPendingOccurrenceValueSelect(date, Currency, Type);
            }
            catch (Exception ex)
            {
                return -9;
            }
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, Name = "TOMORROW")]
        public static DateTime Tomorrow()
        {
            return DateTime.Today.AddDays(1);
        }


        private const string URL = "https://bittrex.com/api/v1.1/public/getticker";

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static decimal GetBittrexTicker(string ticker)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            string urlParameters = "?market=" + ticker;
            decimal Last = 0;
            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                string a = "a";
                // Parse the response body. Blocking!
                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                //foreach (var d in dataObjects)
                //{
                //    Console.WriteLine("{0}", d.Name);
                //}

                var result = JsonConvert.DeserializeObject<JsonReturn>(response.Content.ReadAsStringAsync().Result);
                //{ "success":true,"message":"","result":{ "Bid":0.01443899,"Ask":0.01444241,"Last":0.01444442} }

                var t = JsonConvert.DeserializeObject<CryptoCoinTicker>(result.result.ToString());

                Last = t.Last;
            }

            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return Last;
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static decimal GetFlowBTCTicker(string ticker)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.flowbtc.com:8405/GetTicker/" + ticker + "/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            string urlParameters = "?market=";
            decimal Last = 0;
            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                string a = "a";
                // Parse the response body. Blocking!
                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                //foreach (var d in dataObjects)
                //{
                //    Console.WriteLine("{0}", d.Name);
                //}

                var result = JsonConvert.DeserializeObject<FlowBTCTicker>(response.Content.ReadAsStringAsync().Result);
                //{ "success":true,"message":"","result":{ "Bid":0.01443899,"Ask":0.01444241,"Last":0.01444442} }

                Last = decimal.Parse(result.last, new CultureInfo("en-US"));

                
            }

            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return Last;
        }

        [ComRegisterFunctionAttribute]
        [ExcelFunction(IsVolatile = true, IsMacroType = true)]
        public static decimal GetDolar()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.promasters.net.br/cotacao/v1/valores");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            string urlParameters = "?moedas=USD&alt=json";
            decimal Last = 0;
            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                string a = "a";
                // Parse the response body. Blocking!
                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                //foreach (var d in dataObjects)
                //{
                //    Console.WriteLine("{0}", d.Name);
                //}

                var result = JsonConvert.DeserializeObject<JsonDolar>(response.Content.ReadAsStringAsync().Result);
                //{ "success":true,"message":"","result":{ "Bid":0.01443899,"Ask":0.01444241,"Last":0.01444442} }

                var t = JsonConvert.DeserializeObject<Dolar>(result.valores.ToString());
                var info = JsonConvert.DeserializeObject<DolarInfo>(t.USD.ToString());

                Last = decimal.Parse(info.valor, new CultureInfo("en-US"));

            }

            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return Last;
        }




    }

    public class JsonDolar
    {
        public string status { get; set; }
        public object valores { get; set; }
    }

    public class Dolar
    {
        public object USD { get; set; }
    }

    public class DolarInfo
    {
        public string nome { get; set; }
        public string valor { get; set; }
    }

    public class JsonReturn
    {
        public string success { get; set; }
        public string message { get; set; }
        public object result { get; set; }
    }

    public class CryptoCoinTicker
    {
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Last { get; set; }
    }

    public class FlowBTCTicker
    {
        public string last { get; set; }
    }


}