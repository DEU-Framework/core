namespace DEU_Lib.Model.Service
{
    public interface IOperationDataFetchService
    {
        Task<bool> CreateConfig(string Path);
        Task<IEnumerable<List<IOperation>>> FetchDataAsync(string configPath);
    }
}
