using Microsoft.AspNetCore.Mvc;
using Practice.Models;

namespace Practice.Data
{
    public interface DataInterface
    {
        // Admin
        IEnumerable<Admin> GetAllAdmins();
        int GetAdminAuthentication(string email, string password);
        void AddAdmin(Admin admin);

        // camp 
        void AddCamp(Camp camp);
        Camp GetCampBYID(int id);
        Camp GetCampBYNAME(string name);
        IEnumerable<Camp> GetAllCamps();



        // Remarks 
        void AddRemark(Remarks remark);
        Remarks GetRemarkBYID(int id);
        IEnumerable<Remarks> GetAllRemarks();
        IEnumerable<Remarks> GetRemarkBYCampID(int campid);
        IEnumerable<Remarks> GetRemarkByUserId(int userID);


        //   Booking
        IEnumerable<Booking> GetAllBooking();
        Booking GetBookingBYID(int id);
        void AddBooking(Booking booking);
        bool IsSpotAvailable(int campID, DateTime startDate, DateTime endDate);
        IEnumerable<Booking> GetBookingByCampId(int campID);
        IEnumerable<Booking> GetBookingByUserId(int userID);


        // user
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        User GetUserBYID(int id);
        int GetAuthentication(string email, string password);
        void UpdateUser(User user);

    }
}
