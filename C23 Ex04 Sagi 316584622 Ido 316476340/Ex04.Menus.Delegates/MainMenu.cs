using System;
using Tools;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private Menu m_Current;
        private int m_InPut;
        private Boolean m_Exit = false;
        private String m_BackOrExite;
        private int m_ThisLeaf = 0;
        private string m_SignLine = "---------------------------------------";

        public int InPut
        {
            get { return m_InPut; }
            set { m_InPut = value; }
        }
        public void PrintMenu()
        {
            if (m_Current.SubMenu.Count != m_ThisLeaf)
            {
                Console.WriteLine(string.Format("**{0}**", m_Current.Name));
            }
            Console.WriteLine(m_SignLine);
            if (m_Current.PreMenu == null)
            {
                m_BackOrExite = "Exit";
            }
            else
            {
                m_BackOrExite = "Back";
            }
            int index = 1;
            foreach (Menu menu in m_Current.SubMenu)
            {
                Console.WriteLine(string.Format("{0} -> {1}", index, menu.Name));
                index++;
            }
            Console.WriteLine(string.Format(@"0 -> {0}
{1}", m_BackOrExite, m_SignLine));
        }
        public void Initialize()
        {
            m_Current = new Menu();
            m_Current.Name = "Main Menu";
            Menu menu1 = new Menu();
            menu1.Name = "Show Date/Time";
            Menu menu1_1 = new Menu();
            menu1_1.Name = "Show Time";
            menu1_1.SetAction += new DateAndTime().ShowTime;
            menu1_1.AddToMenu(menu1);
            Menu menu1_2 = new Menu();
            menu1_2.Name = "Show Date";
            menu1_2.SetAction += new DateAndTime().ShowDate;
            menu1_2.AddToMenu(menu1);
            menu1.AddToMenu(m_Current);
            Menu menu2 = new Menu();
            menu2.Name = "Version and Capitals";
            Menu menu2_1 = new Menu();
            menu2_1.Name = "Count Capitals";
            menu2_1.SetAction += new VersionAndCapitals().CountCapitals;
            menu2_1.AddToMenu(menu2);
            Menu menu2_2 = new Menu();
            menu2_2.Name = "Get Version";
            menu2_2.SetAction += new VersionAndCapitals().GetVersion;
            menu2_2.AddToMenu(menu2);
            menu2.AddToMenu(m_Current);
        }
        public void Start()
        {
            Initialize();
            do
            {
                if (m_Current.SubMenu.Count == m_ThisLeaf)
                {
                    m_Current.StartAction();
                    m_Current = m_Current.PreMenu;
                }
                PrintMenu();
                Console.WriteLine("Enter your request");
                try
                {
                    InPut = int.Parse(Console.ReadLine());
                    if (InPut > 0 && InPut <= m_Current.SubMenu.Count)
                    {
                        m_Current = m_Current.SubMenu[InPut - 1];
                    }
                    else if (InPut == 0 && m_Current.PreMenu != null)
                    {
                        m_Current = m_Current.PreMenu;
                    }
                    else if (InPut == 0 && m_Current.PreMenu == null)
                    {
                        m_Exit = true;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invald input");
                }
            } while (!m_Exit);
        }
    }

}
