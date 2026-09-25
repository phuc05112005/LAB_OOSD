using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void FrmDanhMuc_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmDanhMuc())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnPhongTienNghi_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmPhongTienNghi())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
