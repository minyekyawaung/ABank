using aplus_back_seed.Models;
namespace aplus_back_seed.Interfaces
{
    public interface IAplusDataAccesses
    {
       IEnumerable<WeatherForecast> getWeather();

        #region Users

       AplusListData<User> GetUsers();  

        AplusListData<User> GetUsersbyid(int id); 

       bool InsertUsers(User user);  

       bool UpdateUsers(User user);  

        bool DeleteUsers(User user);  
        #endregion


      

    }
}