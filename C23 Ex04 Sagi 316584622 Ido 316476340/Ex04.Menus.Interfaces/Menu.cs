using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal interface IMenu
    {
        void AddToMenu(Menu MyMenu);
    }
    internal class Menu : IMenu
    {
        private string m_Name;
        private List<Menu> m_SubMenu = new List<Menu>();
        private Menu m_PreMenu;
        private object m_MyObject;
        private int m_IndexOfMethod;
        public Menu(String i_MyName)
        {
            m_Name = i_MyName;
        }
        public object MyObject
        {
            set { m_MyObject = value; }
        }
        public String Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public Menu PreMenu
        {
            get { return m_PreMenu; }
        }
        public List<Menu> SubMenu
        {
            get { return (List<Menu>)m_SubMenu; }
            set { m_SubMenu = value; }
        }
        public void AddToMenu(Menu MyMenu)
        {
            m_PreMenu = MyMenu;
            m_PreMenu.m_SubMenu.Add(this);
        }
        public void SetAction(object i_MyType, int i_IndexOfMethod)
        {
            m_MyObject = i_MyType;
            Type objectType = m_MyObject.GetType();
            m_IndexOfMethod = i_IndexOfMethod;
        }

        public void Action()
        {
            Type objectType = m_MyObject.GetType();
            MethodInfo getInputMethod = objectType.GetMethod("GetInput", BindingFlags.Public | BindingFlags.Instance);
            if (getInputMethod != null)
            {
                try
                {
                    object[] InPut = new object[] { m_IndexOfMethod };
                    getInputMethod.Invoke(m_MyObject, InPut);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Error invoking GetInput: {0}", ex.Message));
                }
            }
            else
            {
                Console.WriteLine("GetInput not found.");
            }
        }
    }
}
