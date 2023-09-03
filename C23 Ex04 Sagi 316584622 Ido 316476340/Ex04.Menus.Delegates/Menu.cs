using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public delegate void MenuAction();
    internal class Menu
    {
        private string m_Name;
        private List<Menu> m_SubMenu = new List<Menu>();
        private Menu m_PreMenu;
        private object m_MyObject;
        public event MenuAction SetAction;

        public String Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public List<Menu> SubMenu
        {
            get { return (List<Menu>)m_SubMenu; }
            set { m_SubMenu = value; }
        }
        public Menu PreMenu
        {
            get { return m_PreMenu; }
        }
        public void AddToMenu(Menu MyMenu)
        {
            m_PreMenu = MyMenu;
            m_PreMenu.m_SubMenu.Add(this);
        }
        public void RemoveMenu()
        {
            this.m_PreMenu = null;
        }
        public void StartAction()
        {
            if (SetAction != null)
            {
                SetAction.Invoke();
            }
        }
    }
}

