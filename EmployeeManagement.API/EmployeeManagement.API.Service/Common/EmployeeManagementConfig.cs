using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.API.Service.Common
{
    public class EmployeeManagementConfig
    {
        public string BaseURL { get; set; }
        public string LookupEndpoint { get; set; }
        public string AutoCompleteEndpoint { get; set; }
        public string EmployeeManagementAPILimit { get; set; }
        public string LatitudeSouth { get; set; }
        public string LatitudeMidlands { get; set; }
        public EmployeeManagementConfig(IConfiguration configuration)
        {
            BaseURL = configuration.GetSection("EmployeeManagementConfig:BaseURL").Value;
            LookupEndpoint = configuration.GetSection("EmployeeManagementConfig:LookupEndpoint").Value;
            AutoCompleteEndpoint = configuration.GetSection("EmployeeManagementConfig:AutoCompleteEndpoint").Value;
            EmployeeManagementAPILimit = configuration.GetSection("EmployeeManagementConfig:EmployeeManagementAPILimit").Value;
            LatitudeSouth = configuration.GetSection("EmployeeManagementConfig:LatitudeSouth").Value;
            LatitudeMidlands = configuration.GetSection("EmployeeManagementConfig:LatitudeMidlands").Value;
        }
    }
}
