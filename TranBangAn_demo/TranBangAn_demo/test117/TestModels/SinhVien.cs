using System;
using System.Collections.Generic;

#nullable disable

namespace test117.TestModels
{
    public partial class SinhVien
    {
        public string Masv { get; set; }
        public string Tensv { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
        public string Khoa { get; set; }
        public double Diemtb { get; set; }

    public double hocbong { 
            
            get
            {
                double hb =0 ;
                if (this.Diemtb==4 )
                {
                    hb = 40000000000;
                }
                if(this.Diemtb>=3 && this.Diemtb<4)
                {
                    hb = 100000000;
                }
                if (this.Diemtb < 3)
                {
                    hb = 500000;
                }
                return hb;
            }
        }
        public int tuoi
        {
            get
            {
                DateTime ns = DateTime.Now;
                int age = ns.Year - Ngaysinh.Year;
                return age;
            }
        }

    }
}
