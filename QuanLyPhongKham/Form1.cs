using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKham
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DTOBenhNhan BenhNhan = new DTOBenhNhan();
            BenhNhan.Ten = "Tri";
            BenhNhan.NgheNghiep = "IT";
            BenhNhan.SDT = "01687226446";
            BenhNhan.Tuoi = 18;
            BenhNhan.DiaChi = "HCM";
            BenhNhan.CMND = "312247075";
            DAOBenhNhan daoBenhNhan = new DAOBenhNhan();
            daoBenhNhan.Them(BenhNhan);
        }
    }
}
