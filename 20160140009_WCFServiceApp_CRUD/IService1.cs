using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _20160140009_WCFServiceApp_CRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Insert(InsertUser user); /*create insert method*/
        [OperationContract]
        GetTestData GetInfo(); /*create method getinfo*/
        [OperationContract]
        string Update(UpdateUser u); //create update method
        [OperationContract]
        string Delete(DeleteUser d); //create method delete
        // TODO: Add your service operations here
    }

    [DataContract]
    public class GetTestData //create class getTestData 
    {
        [DataMember]
        public DataTable userTable //create properties userTable
        {
            get;
            set;
        }

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class InsertUser //create class InsertUser 
    {
        string name = string.Empty;
        string email = string.Empty;

        [DataMember]
        public string Name //create properties Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string Email //create properties Email
        {
            get { return email; }
            set { email = value; }
        }
    }

    [DataContract]
    public class UpdateUser //create class UpdateUser 
    {
        int uID;
        string name;
        string email;
        [DataMember]
        public int UID //create properties UID
        {
            get { return uID; }
            set { uID = value; }
        }
        [DataMember]
        public string Name //create properties Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string Email //create properties Email
        {
            get { return email; }
            set { email = value; }
        }
    }

    [DataContract]
    public class DeleteUser //create class DeleteUser 
    {
        int uID;
        [DataMember]
        public int UID //properties UID
        {
            get { return uID; }
            set { uID = value; }
        }
    }
}