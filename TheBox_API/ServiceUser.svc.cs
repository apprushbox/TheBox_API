using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;

namespace TheBox_API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class ServiceUser : IServiceUser
    {
        public List<User> FindAll()
        {
            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {
                return theBoxEntities.UserEntities.Select(u => new User
                {
                    ID_User = u.ID_User,
                    TX_Name = u.TX_Name,
                    TX_LastName = u.TX_LastName,
                    TX_Email = u.TX_Email,
                    TX_PhoneNumber = u.TX_PhoneNumber,
                    TX_UserName = u.TX_UserName,
                    TX_Password = u.TX_Password,
                    BO_Provider = u.BO_Provider,
                    BO_Active = u.BO_Active,
                    DT_Register = u.DT_Register,
                    IM_Image = u.IM_Image
                }).ToList();
            }
        }

        public User Find(string id)
        {
            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {
                long nid = Convert.ToInt64(id);
                return theBoxEntities.UserEntities.Where(u => u.ID_User == nid).Select(u => new User
                {
                    ID_User = u.ID_User,
                    TX_Name = u.TX_Name,
                    TX_LastName = u.TX_LastName,
                    TX_Email = u.TX_Email,
                    TX_UserName = u.TX_UserName,
                    TX_Password = u.TX_Password,
                    TX_PhoneNumber = u.TX_PhoneNumber,
                    BO_Provider = u.BO_Provider,
                    BO_Active = u.BO_Active,
                    DT_Register = u.DT_Register,
                    IM_Image = u.IM_Image
                }).FirstOrDefault();
            }
        }

        public ResponseOperation Create(User user)
        {
            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {
                try
                {
                    UserEntity userEntity = new UserEntity();
                    userEntity.TX_Name = user.TX_Name;
                    userEntity.TX_LastName = user.TX_LastName;
                    userEntity.TX_Email = user.TX_Email;
                    userEntity.TX_UserName = user.TX_UserName;
                    userEntity.TX_Password = user.TX_Password;
                    userEntity.TX_PhoneNumber = user.TX_PhoneNumber;
                    userEntity.BO_Active = true;
                    userEntity.BO_Provider = false;
                    userEntity.DT_Register = DateTime.Now;
                    theBoxEntities.UserEntities.Add(userEntity);
                    theBoxEntities.SaveChanges();
                    User myUser = FindUser(user.TX_UserName);
                    MemoryStream stream1 = new MemoryStream();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                    ser.WriteObject(stream1, myUser);
                    stream1.Position = 0;
                    StreamReader sr = new StreamReader(stream1);
                    ResponseOperation response = new ResponseOperation(true, sr.ReadToEnd());
                    return response;
                }
                catch (DbUpdateException e)
                {
                    return new ResponseOperation(false, e.InnerException.InnerException.Message);
                }
                //catch (IOException e)
                //{
                //    return new ResponseOperation(false, "Error: " + e.Message);
                //}
            }
        }

        public bool Edit(User user)
        {
            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {
                try
                {
                    UserEntity userEntity = theBoxEntities.UserEntities.Single(u => u.ID_User == user.ID_User);
                    userEntity.TX_Name = user.TX_Name;
                    userEntity.TX_LastName = user.TX_LastName;
                    userEntity.TX_Email = user.TX_Email;
                    userEntity.TX_UserName = user.TX_UserName;
                    userEntity.TX_Password = user.TX_Password;
                    userEntity.TX_PhoneNumber = user.TX_PhoneNumber;
                    userEntity.BO_Provider = user.BO_Provider;
                    userEntity.IM_Image = user.IM_Image;
                    theBoxEntities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Delete(User user)
        {
            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {
                try
                {
                    UserEntity userEntity = theBoxEntities.UserEntities.Single(u => u.ID_User == user.ID_User);
                    theBoxEntities.UserEntities.Remove(userEntity);
                    theBoxEntities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


        public User LogIn(User user)
        {
            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {

                return theBoxEntities.UserEntities.Where(u => u.TX_UserName.Equals(user.TX_UserName) && u.TX_Password.Equals(user.TX_Password)).Select(u => new User
                {
                    ID_User = u.ID_User,
                    TX_Name = u.TX_Name,
                    TX_LastName = u.TX_LastName,
                    TX_Email = u.TX_Email,
                    TX_UserName = u.TX_UserName,
                    TX_Password = u.TX_Password,
                    TX_PhoneNumber = u.TX_PhoneNumber,
                    BO_Provider = u.BO_Provider,
                    BO_Active = u.BO_Active,
                    DT_Register = u.DT_Register,
                    IM_Image = u.IM_Image
                }).FirstOrDefault();
            }
        }


        public User FindUser(string userName)
        {
            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {

                return theBoxEntities.UserEntities.Where(u => u.TX_UserName == userName).Select(u => new User
                {
                    ID_User = u.ID_User,
                    TX_Name = u.TX_Name,
                    TX_LastName = u.TX_LastName,
                    TX_Email = u.TX_Email,
                    TX_UserName = u.TX_UserName,
                    TX_Password = u.TX_Password,
                    TX_PhoneNumber = u.TX_PhoneNumber,
                    BO_Provider = u.BO_Provider,
                    BO_Active = u.BO_Active,
                    DT_Register = u.DT_Register,
                    IM_Image = u.IM_Image
                }).FirstOrDefault();
            }
        }
    }
}
