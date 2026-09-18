using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void BtnDanhMuc_Click(object sender, EventArgs e)
        {
            FrmDanhMuc f = new FrmDanhMuc();
            f.ShowDialog();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            FrmSach f = new FrmSach();
            f.ShowDialog();
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            FrmDocGia f = new FrmDocGia();
            f.ShowDialog();
        }

        private void btn_Thoat(object sender, EventArgs e)
        {
            Close();
        }
    }
}
