using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace BusinessLogic
{
   public class RoleBL: IRoleOperation
    {
        public List<RoleModel> RoleList = new List<RoleModel>();

        public RoleBL()
        { }

        public void Add(RoleModel role)
        {
            RoleList.Add(role);
        }

        public List<RoleModel> Get()
        {
            return RoleList;
        }
        public RoleModel Get(int rid)
        {
            RoleModel roleModel = new RoleModel();
            for (int i = 0; i < RoleList.Count; i++)
            {
                if (rid == RoleList[i].roleId)
                {
                    roleModel = RoleList[i];
                    return roleModel;
                }
            }
            return roleModel;
        }
        public bool Remove(int eid)
        {

            for (int i = 0; i < RoleList.Count; i++)
            {
                if (eid == RoleList[i].roleId)
                {
                    RoleList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public bool IsExists(int rid)
        {
            for (int i = 0; i < RoleList.Count; i++)
            {
                if (rid == RoleList[i].roleId)
                {
                    return true;
                }
            }
            return false;
        }
        public RoleModel GetById(int rid)
        {
            RoleModel role = new RoleModel();
            for (int i = 0; i < RoleList.Count; i++)
            {
                if (rid == RoleList[i].roleId)
                {
                    role = RoleList[i];
                    return role;
                }
            }
            return role;
        }
        public void RoleXmlSerialize(List<RoleModel> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<RoleModel>));
            using (TextWriter writer = new StreamWriter("C:\\Users\\W10\\source\\repos\\ProlificsProjectManagement_2\\Role_XML.xml"))
            {
                xmlSerializer.Serialize(writer, list);
                Console.WriteLine("Data Saved ");
            }

        }
    }
}
