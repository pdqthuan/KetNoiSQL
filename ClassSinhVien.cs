//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace KetNoiSQL
//{
//    public class LopSinhVien
//    {
//        public int ID { get; set; }
//        public string Ten { get; set; }
//        public string GioiTinh { get; set; }
//        public int Tuoi { get; set; }
//        public int Toan { get; set; }
//        public int Ly { get; set; }
//        public int Hoa { get; set; }

//        public LopSinhVien()
//        {

//        }

//        public LopSinhVien(int id, string ten, string gioiTinh, int tuoi, int toan, int ly, int hoa)
//        {
//            this.ID = id;
//            this.Ten = ten;
//            this.GioiTinh = gioiTinh;
//            this.Tuoi = tuoi;
//            this.Toan = toan;
//            this.Ly = ly;
//            this.Hoa = hoa;
//            //this.diemTB();
//            //this.hocLuc();
//        }
//        public static int globalSVid;
//        ID = Interlocked.Increment(ref globalSVid);
//        //public float diemTB()
//        //{
//        //    return (float)(this.Toan + this.Ly + this.Hoa) / 3;
//        //}

//        //public string hocLuc()
//        //{
//        //    float diem = diemTB();
//        //    if (diem >= 8)
//        //    {
//        //        return "Gioi";
//        //    }
//        //    else if (diem < 8 && diem >= 6.5)
//        //    {
//        //        return "Kha";
//        //    }
//        //    else if (diem < 6.5 && diem >= 5)
//        //    {
//        //        return "Trung binh";
//        //    }
//        //    else
//        //    {
//        //        return "Yeu";
//        //    }
//        //}
//    }
//}