using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Application
{
    public class Controller
    {
        public List<System.Windows.Forms.Form> forms;

        public Controller()
        {
            forms = new List<System.Windows.Forms.Form>();
        }

        public void HideAll()
        {
            foreach (var f in forms)
                f.Hide();
        }
        public void Show(int index)
        {
            HideAll();
            forms[index].Show();
        }
    }
}
