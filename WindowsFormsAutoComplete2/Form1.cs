using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsAutoComplete2
{
    public partial class Form1 : Form
    {
        private static string favorites = @"C:\Users\zohal\Favorites\Links\Android Debugging";
        AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
        List<Uri> dirUris = new List<Uri>();
        PersonalUris myUris = new PersonalUris();
        public Form1()
        { 
            InitializeComponent();
            acsc = new AutoCompleteStringCollection();
            personalUrisTextBox.AutoCompleteCustomSource = acsc;
            personalUrisTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            personalUrisTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            myUris.ProcessDirectory(favorites, ref dirUris);            
            acsc.AddRange(myUris.convertToArray(dirUris));
        }
        
        private void personalUrisTextBox_TextChanged(object sender, EventArgs e)
        {
            acsc.AddRange(myUris.convertToArray(dirUris));
        }

    }
}
