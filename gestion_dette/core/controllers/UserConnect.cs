using GesDette.Data.Entities;

namespace GesDette.Core.Controllers
{
    public class UserConnect
    {
        private static User userConnect;

        public static User GetUserConnect() {
            return userConnect;
        }
        
        public static void SetUserConnect(User user) {
            userConnect = user;
        }
    }
}