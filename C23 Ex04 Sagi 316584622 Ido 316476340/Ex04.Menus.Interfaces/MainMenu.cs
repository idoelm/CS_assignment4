using System;
using Tools;

namespace Ex04.Menus.Interfaces
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
            DateAndTime dateAndTime = new DateAndTime();
            VersionAndCapitals versionAndCapitals = new VersionAndCapitals();
            m_Current = new Menu("Main Menu");
            Menu ShowDateTime = new Menu("Show Date/Time");
            Menu ShowTime = new Menu("Show Time");
            ShowTime.SetAction(dateAndTime, dateAndTime.ArrayOfMethod().IndexOf("Show Time"));
            ShowTime.AddToMenu(ShowDateTime);
            Menu ShowDate = new Menu("Show Date");
            ShowDate.SetAction(dateAndTime, dateAndTime.ArrayOfMethod().IndexOf("Show Date"));
            ShowDate.AddToMenu(ShowDateTime);
            ShowDateTime.AddToMenu(m_Current);
            Menu menuVersionAndCapitals = new Menu("Version and Capitals");
            Menu countCapitals = new Menu("Count Capitals");
            countCapitals.SetAction(new VersionAndCapitals(), versionAndCapitals.ArrayOfMethod().IndexOf("Count Capitals"));
            countCapitals.AddToMenu(menuVersionAndCapitals);
            Menu getVersion = new Menu("Get Version");
            getVersion.SetAction(new VersionAndCapitals(), versionAndCapitals.ArrayOfMethod().IndexOf("Get Version"));
            getVersion.AddToMenu(menuVersionAndCapitals);
            menuVersionAndCapitals.AddToMenu(m_Current);
        }
        public void Start()
        {
            Initialize();
            do
            {
                if (m_Current.SubMenu.Count == m_ThisLeaf)
                {
                    m_Current.Action();
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
                catch(FormatException)
                {
                    Console.WriteLine("Invald input");
                }
               
            } while (!m_Exit);
        }
    }

}
