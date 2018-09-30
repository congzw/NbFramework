using System.Windows.Forms;
using NbFramework.CodeGenerate.NbRefs;

namespace NbFramework.CodeGenerate
{
    public partial class NbRefForm : Form
    {
        public NbRefForm()
        {
            InitializeComponent();
        }

        private void NbRefForm_Load(object sender, System.EventArgs e)
        {

        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            //var readAllLines = System.IO.File.ReadAllLines("C:\\test.txt");
            //this.txtResult.Text = DicRegistryCode.Temp(readAllLines);
            this.txtResult.Text = NbRefCodeHelper.Generate();
        }
    }
}
