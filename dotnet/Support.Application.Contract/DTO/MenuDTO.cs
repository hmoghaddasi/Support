namespace Support.Application.Contract.DTO {

    public class MenuDTO
    {
        public int MenuId { get; set; }
        public int MenuHdrId { get; set; }
        public string MenuLable { get; set; }
        public string MenuLink { get; set; }
       public bool IsValid { get; set; }
       public int SortIndex { get; set; }
        public string IconName { get; set; }
        public bool HaveChild { get; set; }

    }

}