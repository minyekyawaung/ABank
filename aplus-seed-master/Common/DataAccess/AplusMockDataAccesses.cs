using aplus_back_seed.Interfaces;
using aplus_back_seed.Models;

namespace aplus_back_seed.Common
{
    public class AplusMockDataAccesses : IAplusDataAccesses
    {
         private readonly AplusContext _context; 
         public AplusMockDataAccesses(AplusContext context)  
        {  
            _context = context;  
        }  
        private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


        IEnumerable<WeatherForecast> IAplusDataAccesses.getWeather()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
       .ToArray();
        }


        #region Users


        #region GetUsers

          public AplusListData<User> GetUsers()
        {
            List<User> _rows = new List<User>();
           int _count =_context.users.Count();
           if(_count > 0)
           _rows =  _context.users.OrderBy(u=>u.UID).Skip(0).Take(20).Where(x => x.DeleteFlag == false).ToList();
           
           return new AplusListData<User>{
               rows =_rows,
               page = 1,
               total = _count,
               pageSize = 20
           };
        }

        #endregion

      
        #region GetUsersbyid
        public AplusListData<User> GetUsersbyid(int id)
            {
                List<User> _rows = new List<User>();
            int _count =_context.users.Count();
            if(_count > 0)
            _rows =  _context.users.Where(x => x.UID == id).OrderBy(u=>u.UID).Skip(0).Take(20).ToList();
            
            return new AplusListData<User>{
                rows =_rows,
                page = 1,
                total = _count,
                pageSize = 20
            };
            }

        #endregion

        
        #region InsertUsers
        public bool InsertUsers(User user)
                {
            
                    try
                    {
                        _context.Add(user);
                        _context.SaveChanges();
                    }
                    catch (System.Exception e)
                    {
                        
                        throw;
                    }

                    return true;
                
                
                }
        #endregion
    
        
        #region UpdateUsers
        public bool UpdateUsers(User _user)
                {
            
                    if (_user != null)
                    {
                        User? updateduser = (from c in _context.users
                                                where c.UID == _user.UID
                                                select c).FirstOrDefault();

                            if (updateduser != null)
                            {
                                updateduser.NRC = _user.NRC;
                                updateduser.Mobile_no = _user.Mobile_no;
                                updateduser.Email = _user.Email;
                                updateduser.PIN = _user.PIN;
                                updateduser.UserType = _user.UserType;
                                updateduser.Status = _user.Status;
                                updateduser.ForcedChangePIN = _user.ForcedChangePIN;
                                updateduser.EditedAt = _user.EditedAt;
                                
                            }   
                            else{
                                return false;
                            }                 

                    _context.SaveChanges();
                    return true;
                    }
                    else{
                        return false;
                    }
            
            
                
                }
        #endregion
       

        #region DeleteUsers

        public bool DeleteUsers(User _user)
        {
      
             if (_user != null)
            {
                   User? updateduser = (from c in _context.users
                                        where c.UID == _user.UID
                                        select c).FirstOrDefault();
                                        

                  if (updateduser != null)
                    {
                    
                        //soft delete
                        updateduser.DeleteFlag = _user.DeleteFlag;
                        
                    }   
                    else{
                        return false;
                    }   
                 
          
             _context.SaveChanges();
             return true;
            }
            else{
                return false;
            }
        
          
        }
        #endregion

        #endregion

        
    }
}