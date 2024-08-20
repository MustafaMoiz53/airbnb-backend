using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using System.Xml.Linq;

namespace Practice.Data
{
    public class DataLiteDB : DataInterface
    {
        LiteDatabase LiteDatabase = new LiteDatabase(@"data.db");

        // Admin
        public IEnumerable<Admin> GetAllAdmins()
        {
            return LiteDatabase.GetCollection<Admin>("Admin").FindAll();
        }
        public void AddAdmin(Admin admin)
        {
            LiteDatabase.GetCollection<Admin>("Admin").Insert(admin);
        }
        public int GetAdminAuthentication(string email, string password)
        {
            Admin admin = LiteDatabase.GetCollection<Admin>("Admin").FindOne(c => c.Email == email);
            if (admin == null)
            {
                return -1;
            }
            else if (admin.Password == password)
            {
                return admin.ID;
            }
            else
            {
                return -1;
            }

        }




        // Camp
        public void AddCamp(Camp camp)
        {
            LiteDatabase.GetCollection<Camp>("Camps").Insert(camp);
        }

        public IEnumerable<Camp> GetAllCamps()
        {
            return LiteDatabase.GetCollection<Camp>("Camps").FindAll();
        }

        public Camp GetCampBYID(int id)
        {
            return LiteDatabase.GetCollection<Camp>("Camps").FindById(id);
        }

        public Camp GetCampBYNAME(string name)
        {
            return LiteDatabase.GetCollection<Camp>("Camps").FindOne(c => c.Name == name);
        }
        






        // Remarks
        public void AddRemark(Remarks remark)
        {
            LiteDatabase.GetCollection<Remarks>("Remarks").Insert(remark);
        }

        public IEnumerable<Remarks> GetAllRemarks()
        {
            return LiteDatabase.GetCollection<Remarks>("Remarks").FindAll();
        }
        public IEnumerable<Remarks> GetRemarkBYCampID(int campid)
        {
            return LiteDatabase.GetCollection<Remarks>("Remarks").Find(c => c.CampID == campid);
        }

        public Remarks GetRemarkBYID(int id)
        {
            return LiteDatabase.GetCollection<Remarks>("Remarks").FindById(id);
        }
        public IEnumerable<Remarks> GetRemarkByUserId(int userID)
        {
            var remarks = LiteDatabase.GetCollection<Remarks>("Remarks")
                                       .Find(b => b.UserID == userID);
            return remarks;
        }









        // Booking
        public void AddBooking(Booking booking)
        {
            LiteDatabase.GetCollection<Booking>("Booking").Insert(booking);
        }

        public IEnumerable<Booking> GetAllBooking()
        {
            return LiteDatabase.GetCollection<Booking>("Booking").FindAll();
        }

        public Booking GetBookingBYID(int id)
        {
            return LiteDatabase.GetCollection<Booking>("Booking").FindById(id);
        }
        public bool IsSpotAvailable(int campID, DateTime startDate, DateTime endDate)
        {
            var bookings = LiteDatabase.GetCollection<Booking>("Booking")
                                       .Find(b => b.CampID == campID);

            if (startDate > endDate)
            {
                return false;
            }

            foreach (var booking in bookings)
            {
                DateTime bookedStartDate = DateTime.Parse(booking.StartDate);
                DateTime bookedEndDate = DateTime.Parse(booking.EndDate);

                // Check for overlap
                if (startDate <= bookedEndDate && endDate >= bookedStartDate)
                {
                    return false;
                }
            }
            return true;
        }
        public IEnumerable<Booking> GetBookingByCampId(int campID)
        {
            var bookings = LiteDatabase.GetCollection<Booking>("Booking")
                                       .Find(b => b.CampID == campID);
            return bookings;
        }
         
        public IEnumerable<Booking> GetBookingByUserId(int userID)
        {
            var bookings = LiteDatabase.GetCollection<Booking>("Booking")
                                       .Find(b => b.UserID == userID);
            return bookings;
        }



        // user
        public void AddUser(User user)
        {
            LiteDatabase.GetCollection<User>("User").Insert(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return LiteDatabase.GetCollection<User>("User").FindAll();
        }

        public User GetUserBYID(int id)
        {
            return LiteDatabase.GetCollection<User>("User").FindById(id);
        }

        public int GetAuthentication(string email, string password)
        {
            User user = LiteDatabase.GetCollection<User>("User").FindOne(c => c.Email == email);
            if(user == null)
            {
                return -1;
            }
            else if(user.Password == password)
            {
                return user.ID;
            }
            else
            {
                return -1;
            }

        }

        public void UpdateUser(User user)
        {
            // Get the collection of users
            var userCollection = LiteDatabase.GetCollection<User>("User");

            // Find the existing user by ID
            var existingUser = userCollection.FindById(user.ID);

            if (existingUser != null)
            {
                // Update the user's properties
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.Age = user.Age;

                // Update the user in the collection
                userCollection.Update(existingUser);
            }
        }



    }


}
