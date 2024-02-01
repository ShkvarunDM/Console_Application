using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Console_Application
{
    static class Program
    {
        public static Controller fc;
        public static Connect_DB.Connect DB;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Connect_DB.EnvConnect.Load("C:/Users/User/source/repos/WindowsFormsApp2/WindowsFormsApp2/t.env");

            fc = new Controller();
            DB = new Connect_DB.Connect();

            Form log_form = new Log_Form(); 
            Form base_form = new Base_Form(); 
            Form customers_form = new Сustomer_Form();
            Form appl_form = new Application_Form();
            Form appl_info_form = new Appl_Info_Form();
            Form compl_work = new Compl_Work_Form();
            Form  tech_special = new Tech_Form();

            fc.forms.Add(log_form); 
            fc.forms.Add(base_form);  
            fc.forms.Add(customers_form); 
            fc.forms.Add(appl_form);        
            fc.forms.Add(appl_info_form);   
            fc.forms.Add(compl_work);   
            fc.forms.Add(tech_special);  

            Application.Run(log_form);

        }
            public class AssociateButton : Button
            {
                public AssociateButton() : base() 
                { 
                    AutoSize = false; 
                }
                public int Recid;
            }
    }
}
