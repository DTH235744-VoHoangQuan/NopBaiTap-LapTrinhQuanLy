using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.Data;
using QuanLyBanHang.Data.Entity;
using QuanLyBanHang.Forms;
using QuanLyBanHang.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace QuanLyBanHang.Forms
{
    public partial class frmMain : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        frmLoaiSanPham loaiSanPham = null;
        frmHangSanXuat hangSanXuat = null;
        frmSanPham sanPham = null;
        frmKhachHang khachHang = null;
        frmNhanVien nhanVien = null;
        frmHoaDon hoaDon = null;
        frmDangNhap dangNhap = null;
        string hoVaTenNhanVien = ""; // Lấy tên người dùng hiển thị vào thanh Status
        public frmMain()
        {
            InitializeComponent();
        }

        private void DangNhap()
        {
        LamLai:
            if (dangNhap == null || dangNhap.IsDisposed)
                dangNhap = new frmDangNhap();
            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                string tenDangNhap = dangNhap.txtTenDangNhap.Text;
                string matKhau = dangNhap.txtMatKhau.Text;
                if (tenDangNhap.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtTenDangNhap.Focus();
                    goto LamLai;
                }
                else if (matKhau.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtMatKhau.Focus();
                    goto LamLai;
                }
                else
                {
                    var nhanVien = context.NhanVien.Where(r => r.TenDangNhap == tenDangNhap).SingleOrDefault();
                    if (nhanVien == null)
                    {
                        MessageBox.Show("Tên đăng nhập không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtTenDangNhap.Focus();
                        goto LamLai;
                    }
                    else
                    {
                        if (BC.Verify(matKhau, nhanVien.MatKhau))
                        {
                            hoVaTenNhanVien = nhanVien.HoVaTen;
                            if (nhanVien.QuyenHan == true)
                                QuyenQuanLy();
                            else if (nhanVien.QuyenHan == false)
                                QuyenNhanVien();
                            else
                                ChuaDangNhap();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dangNhap.txtMatKhau.Focus();
                            goto LamLai;
                        }
                    }
                }
            }
        }
        public void ChuaDangNhap()
        {
            // Sáng đăng nhập
            mnuDangNhap.Enabled = true;
            // Mờ tất cả
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;
            mnuLoaiSanPham.Enabled = false;
            mnuHangSanXuat.Enabled = false;
            mnuSanPham.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuHoaDon.Enabled = false;
            mnuThongKeSanPham.Enabled = false;
            mnuThongKeDoanhThu.Enabled = false;
            // Hiển thị thông tin trên thanh trạng thái
            lblTrangThai.Text = "Chưa đăng nhập.";
        }
        public void QuyenQuanLy()
        {
            // Mờ đăng nhập
            mnuDangNhap.Enabled = false;
            // Mờ các chức năng quản lý không được phép
            // Sáng đăng xuất và các chức năng quản lý được phép
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuLoaiSanPham.Enabled = true;
            mnuHangSanXuat.Enabled = true;
            mnuSanPham.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuNhanVien.Enabled = true;
            mnuHoaDon.Enabled = true;
            mnuThongKeSanPham.Enabled = true;
            mnuThongKeDoanhThu.Enabled = true;// Hiển thị thông tin trên thanh trạng thái
            lblTrangThai.Text = "Quản lý: " + hoVaTenNhanVien;
        }
        public void QuyenNhanVien()
        {
            // Mờ đăng nhập
            mnuDangNhap.Enabled = false;
            // Mờ các chức năng nhân viên không được phép
            mnuLoaiSanPham.Enabled = false;
            mnuHangSanXuat.Enabled = false;
            mnuSanPham.Enabled = false;
            mnuNhanVien.Enabled = false;
            // Sáng đăng xuất và các chức năng nhân viên được phép
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuHoaDon.Enabled = true;
            mnuThongKeSanPham.Enabled = true;
            mnuThongKeDoanhThu.Enabled = true;
            // Hiển thị thông tin trên thanh trạng thái
            lblTrangThai.Text = "Nhân viên: " + hoVaTenNhanVien;
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (loaiSanPham == null || loaiSanPham.IsDisposed)
            {
                loaiSanPham = new frmLoaiSanPham();
                loaiSanPham.MdiParent = this;
                loaiSanPham.Show();
            }
            else
                loaiSanPham.Activate();

            if (hangSanXuat == null || hangSanXuat.IsDisposed)
            {
                hangSanXuat = new frmHangSanXuat();
                hangSanXuat.MdiParent = this;
                hangSanXuat.Show();
            }
            else
                hangSanXuat.Activate();

            if (sanPham == null || sanPham.IsDisposed)
            {
                sanPham = new frmSanPham();
                sanPham.MdiParent = this;
                sanPham.Show();
            }
            else
                khachHang.Activate();

            if (khachHang == null || khachHang.IsDisposed)
            {
                khachHang = new frmKhachHang();
                khachHang.MdiParent = this;
                khachHang.Show();
            }
            else
                khachHang.Activate();

            if (nhanVien == null || nhanVien.IsDisposed)
            {
                nhanVien = new frmNhanVien();
                nhanVien.MdiParent = this;
                nhanVien.Show();
            }
            else
                nhanVien.Activate();

            if (hoaDon == null || hoaDon.IsDisposed)
            {
                hoaDon = new frmHoaDon();
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
            else
                hoaDon.Activate();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lblLienKet_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer.exe";
            info.Arguments = "https://fit.agu.edu.vn";
            Process.Start(info);
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
            DangNhap();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
            ChuaDangNhap();
        }
    }
}
