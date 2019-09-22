using System.Collections.Generic;

namespace Support.Domain.Model
{

    public class Menu
    {
        public int MenuId { get; set; }
        public int MenuHdrId { get; set; }
        public string MenuLabel { get; set; }
        public string MenuLink { get; set; }
        public bool IsValid { get; set; }
        public int SortIndex { get; set; }
        public string IconName { get; set; }

        public virtual Menu MenuHdr { get; set; }
        public virtual List<Menu> Menus { get; set; }

        public Menu(int menuId, int menuHdrId, string menuLabel, string menuLink, bool isValid, int sortIndex, string iconName)
        {
            MenuId = menuId;
            MenuHdrId = menuHdrId;
            MenuLabel = menuLabel;
            MenuLink = menuLink;
            IsValid = isValid;
            SortIndex = sortIndex;
            IconName = iconName;

        }

        public Menu()
        {

        }

    }

}