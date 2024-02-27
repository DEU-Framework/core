using DEU_Lib.Model.Service;
using System.Reflection;

namespace DEU_Backend.Services
{
    public class CustomServiceImplFetcherService(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public IWaKaDataFetchService GetWaKaDataFetchService()
        {
            string customAssemblyPath = _configuration.GetValue<string>("CustomAssemblyPaths:WaKaDataFetchServiceAssemblyPath") ?? throw new Exception("WaKaDataFetchServiceAssemblyPath not found in appsettings.json");

            try
            {
                Assembly customAssembly = Assembly.LoadFrom(customAssemblyPath);
                foreach (Type type in customAssembly.GetTypes())
                {
                    if (typeof(IWaKaDataFetchService).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        var instance = Activator.CreateInstance(type) as IWaKaDataFetchService;
                        return instance ?? throw new Exception("Failed to create instance of custom implementation");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Custom implementation for WaKaDataFetchService not found or failed to load: {ex.Message}");
            }

            throw new Exception("Custom implementation for WaKaDataFetchService not found or failed to load");
        }

        public IOperationDataFetchService GetOperationFetchService()
        {
            string customAssemblyPath = _configuration.GetValue<string>("CustomAssemblyPaths:OperationFetchServiceAssemblyPath") ?? throw new Exception("OperationDataFetchServiceAssemblyPath not found in appsettings.json");

            try
            {
                Assembly customAssembly = Assembly.LoadFrom(customAssemblyPath);
                foreach (Type type in customAssembly.GetTypes())
                {
                    if (typeof(IOperationDataFetchService).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        var instance = Activator.CreateInstance(type) as IOperationDataFetchService;
                        return instance ?? throw new Exception("Failed to create instance of custom implementation");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Custom implementation for OperationDataFetchService not found or failed to load: {ex.Message}");
            }

            throw new Exception("Custom implementation for OperationDataFetchService not found or failed to load");
        }
    }
}
