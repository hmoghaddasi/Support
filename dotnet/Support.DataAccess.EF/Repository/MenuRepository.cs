using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Support.Domain.Exception;
using Support.Domain.IRepository;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly dbContext context;
        public MenuRepository(dbContext context)
        {
            this.context = context;
        }

        public List<Menu> Get(Expression<Func<Menu, bool>> predicate)
        {
            return context.Menus
                           .Include(a => a.MenuHdr)
                           .Include(a=>a.Menus)
                           .Where(predicate).ToList();
        }

        public void Create(Menu menu)
        {
            context.Menus.Add(menu);
        }

        public void Edit(Menu menu)
        {
            
        }

        public void Delete(Menu menu)
        {
            context.Menus.Remove(menu);
        }
        


        List<Menu> IMenuRepository.GetAll()
        {
            return context.Menus.Include(a => a.MenuHdr).Include(a => a.Menus).ToList();
        }

        public Menu GetById(int menuId)
        {
            return context.Menus.Find(menuId);
        }
        public void Delete(int menuId)
        {

            var model = GetForDelete(menuId);
            GaurdDeleteForignKey(model);
            context.Menus.Remove(model);

        }

        private static void GaurdDeleteForignKey(Menu model)
        {
            if (model.Menus.Any())
            {
                throw new ForignkeyDeleteException();
            }
        }

        private Menu GetForDelete(int menuId)
        {
            return context.Menus.Where(a => a.MenuId == menuId)
                             .Include(a => a.Menus)
                             .First();
        }
    }
}
