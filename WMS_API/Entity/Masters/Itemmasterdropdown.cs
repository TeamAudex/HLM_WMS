using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMS.Entity
{
    public class ItemCategoryDropdown
    {
        public int ItemCategorySno { get; set; }
        public string ItemCategoryName { get; set; }
    }

    //public class RotationDropdown
    //{
    //    public int RotationSno { get; set; }
    //    public string RotationName { get; set; }

    //}

    public class WeightUOMDropdown
    {
        public int WeightUOMSno { get; set; }
        public string WeightUOMName { get; set; }

    }

    public class MovementDropdown
    {
        public int MovementSno { get; set; }
        public string MovementName { get; set; }
    }

    public class ValueDropdown
    {
        public int ValueSno { get; set; }
        public string ValueName { get; set; }
    }

    public class NeedDropdown
    {
        public int NeedSno { get; set; }
        public string NeedName { get; set; }
    }

    public class lbhUOMDropdown
    {
        public int lbhUOMSno { get; set; }
        public string lbhUOMName { get; set; }
    }

    public class ItemCategoryDropdownList
    {
        public List<ItemCategoryDropdown> objItemCategoryDropdown { get; set; }
    }
    //public class RotationDropdownList
    //{
    //    public List<RotationDropdown> objRotationDropdown { get; set; }
    //}
    public class WeightUOMDropdownList
    {
        public List<WeightUOMDropdown> objWeightUOMDropdown { get; set; }
    }
    public class MovementDropdownList
    {
        public List<MovementDropdown> objMovementDropdown { get; set; }
    }

    public class ValueDropdownList
    {
        public List<ValueDropdown> objValueDropdown { get; set; }
    }
    public class NeedDropdownList
    {
        public List<NeedDropdown> objNeedDropdown { get; set; }
    }

    public class lbhUOMDropdownList
    {
        public List<lbhUOMDropdown> objlbhUOMDropdown { get; set; }
    }

}
