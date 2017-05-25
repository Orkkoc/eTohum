using eTohumApplication.Models.Base;

namespace eTohumApplication.Controllers
{
    //Base User Class
    public class BsUser 
    {
        public static object Culture { get; internal set; }
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public string Email { get; internal set; }
    }
}