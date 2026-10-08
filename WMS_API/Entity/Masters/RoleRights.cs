using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Masters
{
    public class RoleRights
    {
        public int RoleRightsSno { get; set; }
        public int RoleSno { get; set; }
        public string RoleName { get; set; }
        public int MenuSno { get; set; }
        public string MenuName { get; set; }
        public string ParentMenuName { get; set; }
        public string Creopr { get; set; }
        public bool? Sts { get; set; }
        public int ID { get; set; }
        public string ActionName { get; set; }
        public string IPNumber { get; set; }
        public string URL { get; set; }
        public string TokenNo { get; set; }
        public string ReqLog { get; set; }
    }
    public class RolerightsDet
    {
        public int RoleRightsSno { get; set; }
        public int MenuSno { get; set; }
        public string MenuName { get; set; }
        public bool Sts { get; set; }
        public bool AddFlag { get; set; }
        public bool EditFlag { get; set; }
        public bool DeleteFlag { get; set; }
        public bool ViewFlag { get; set; }
    }
    public class RoleRightSave
    {
        public RoleRights ObjRoleRights { get; set; }
        public List<RolerightsDet> ArrRoleRights { get; set; }
    }
    public class RoleRightResult
    {
        public int RoleSno { get; set; }

        public string Result { get; set; }

    }
    public class ScreenRights
    {
        public int PageId { get; set; }
        public bool AddFlag { get; set; }
        public bool EditFlag { get; set; }
        public bool DeleteFlag { get; set; }
        public bool ViewFlag { get; set; }
    }



}
