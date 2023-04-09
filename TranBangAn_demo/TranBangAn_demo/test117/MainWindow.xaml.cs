using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using test117.TestModels;
using System.Globalization;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace test117
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        QLSinhVienContext db = new QLSinhVienContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            Thread.CurrentThread.CurrentCulture = ci;
            HienThi();
        }
        public void HienThi()
        {
            var query = from sv in db.SinhViens
                        select new
                        {
                            sv.Masv,
                            sv.Tensv,
                            sv.Gioitinh,
                            sv.Ngaysinh,
                            sv.Khoa,
                            sv.Diemtb,
                            sv.tuoi,
                            sv.hocbong

                        };
            danhsach.ItemsSource = query.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var query = db.SinhViens.SingleOrDefault(r => r.Masv.Equals(txtmasv.Text));
            if( query!= null)
            {
                MessageBox.Show("Bi Trung ma sinh vien ");
                HienThi();
            }else
            {
                SinhVien sv = new SinhVien();
                sv.Tensv = txtten.Text;
                sv.Masv = txtmasv.Text;
                sv.Ngaysinh = txtngaysinh.SelectedDate.Value;
                if (Namx.IsChecked == true)
                {
                    sv.Gioitinh = "Nam";
                }
                else
                {
                    sv.Gioitinh = "Nu";
                }
                sv.Khoa = txtkhoa.Text;
                sv.Diemtb = Single.Parse(txtdiem.Text);
                db.SinhViens.Add(sv);
                db.SaveChanges();
                MessageBox.Show("Da Them ");
                HienThi();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var xoa = db.SinhViens.SingleOrDefault(r => r.Masv.Equals(txtmasv.Text));
            if(xoa != null)
            {
                MessageBoxResult rs = MessageBox.Show("Ban co dong y muon xoa hay khum ", "thong bao", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.Yes)
                {
                    db.SinhViens.Remove(xoa);
                    db.SaveChanges();
                    HienThi();
                }
            }else
            {
                MessageBox.Show("khong co gif de xoa");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var sua = db.SinhViens.SingleOrDefault(r => r.Masv.Equals(txtmasv.Text));
            if (sua != null)
            {
                sua.Tensv = txtten.Text;
                sua.Ngaysinh = txtngaysinh.SelectedDate.Value;
                if (Namx.IsChecked == true)
                {
                    sua.Gioitinh = "Nam";
                }
                else
                {
                    sua.Gioitinh = "Nu";
                }
                sua.Khoa = txtkhoa.Text;
                sua.Diemtb = Single.Parse(txtdiem.Text);
               
                db.SaveChanges();
                MessageBox.Show("Da sua ");
                HienThi();
            }else
            {
                MessageBox.Show("khong co gif de sua");
            }
        }

        private void btntimkiem_Click(object sender, RoutedEventArgs e)
        {
            var tim = db.SinhViens.SingleOrDefault(r => r.Masv.Equals(txtmasv.Text));
            if (tim != null)
            {
                var item = from sv in db.SinhViens
                           where sv.Masv == txtmasv.Text
                           select new
                           {
                               sv.Masv,
                               sv.Tensv,
                               sv.Gioitinh,
                               sv.Ngaysinh,
                               sv.Khoa,
                               sv.Diemtb,
                               sv.tuoi,
                               sv.hocbong

                           };
                danhsach.ItemsSource = item.ToList();

            }else
            {
                MessageBox.Show("Khong co me gi de tim ");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 n = new Window1();
            n.Show();
        }
    }
    }
    

