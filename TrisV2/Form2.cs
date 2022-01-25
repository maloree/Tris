using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrisV2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            lbl_info.Text =
                "Versione 3:\n\n● Il codice è stato velocizzato.\n\n" +
                "● E' stata aggiunto un timer che conta il tempo in partita.\n\n" +
                "● E' stato aggiunto il collegamento al profilo GitHub del creatore\n   nel menù \"Altro...\".\n\n" +
                "● E' stato aggiunta una finestra informazioni.";
        }
    }
}
