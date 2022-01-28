using aplus_back_seed.Interfaces;
using aplus_back_seed.Models;
using Microsoft.AspNetCore.Mvc;

namespace aplus_back_seed.Controllers;

 [ApiController]
// [Route("[controller]")]
  [Route("[controller]/[action]")]
public class SampleController : AplusBasedController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public SampleController(IAplusSample sample, ILogger<AplusBasedController> logger, IAplusDataAccesses data) : base(sample, logger, data)
    {
    }


    #region Users


    #region GetUsers
    [HttpGet(Name = "GetUsers")]
    public AplusListData<User> GetUsers()
    {
       return  _data.GetUsers();
    }
    #endregion


    #region GetUsersbyid

    [HttpGet(Name = "GetUsersbyid")]
    public AplusListData<User> GetUsersbyid(int id)
    {
       return  _data.GetUsersbyid(id);
    }

    #endregion


    #region  InsertUser
    
     [HttpPost(Name = "InsertUser")]
    public string InsertUser(User user)
    {
       if (_data.InsertUsers(user) == true)
       {
          return "Saving is successful.";
       }
       else
       {
           return "Saving is fail.";

       }
     
    }

    #endregion


    #region UpdateUser
        [HttpPost(Name = "UpdateUser")]
    public string UpdateUser(User user)
    {
       if (_data.UpdateUsers(user) == true)
       {
           return "Updating is successful.";
       }
       else
       {
           return "Updating is fail.";

       }
       
    }
    #endregion


    #region  DeleteUser
    [HttpPost(Name = "DeleteUser")]
    public string DeleteUser(User user)
    {
       if (_data.DeleteUsers(user) == true)
       {
           return "Deleting is successful.";
       }
       else
       {
           return "Deleting is fail.";

       }
    }
    #endregion
 

    #endregion
    
}
