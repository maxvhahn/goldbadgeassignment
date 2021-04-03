using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepositoryConsoleApp
{
    public class MenuContent_Repository
    {
        //Only MenuContent objects can go into the list
        private List<MenuContent> _listOfMenuContent = new List<MenuContent>();

        //CRUD
        //Methods to add, read, update, and delete from the list
        //These will be called to the programUI
        //The list should be able to be accessed

        //Create
        public void AddMenuContent(MenuContent content)
        {
            _listOfMenuContent.Add(content);
        }

        //Read
        public List<MenuContent> GetMenuList()
        {
            //body or logic of the method
            return _listOfMenuContent;
        }

        //Update -- Not needed right now


        //Delete
        public bool RemoveMenuContent(string mealName)
        {
            MenuContent content = GetMenuContent(mealName);
            if(content == null)
            {
                return false;
            }

            int initialCount = _listOfMenuContent.Count;
            _listOfMenuContent.Remove(content);

            if(initialCount > _listOfMenuContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method that helps get the MenuContent
        public MenuContent GetMenuContent(string mealName)
        {
            foreach(MenuContent content in _listOfMenuContent)
            {
                if (content.MealName.ToLower() == mealName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
    }
}
