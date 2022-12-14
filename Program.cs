using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KetNoiSQL
{
    internal class Program
    {
        
        static void Main(string[] args)
        {            
            Console.Title = "Parameters";
            var connectionString = @"Data Source=THINKPAD-T495S\THUAN;Initial Catalog=Students;Integrated Security=True";

            while (true)
            {
                Console.WriteLine("\n\t\tCHUONG TRINH QUAN LY SINH VIEN C#");
                Console.WriteLine("*******************************************************");
                Console.WriteLine("**  1. Them sinh vien.                               **");
                Console.WriteLine("**  2. Cap nhat thong tin sinh vien boi ID.          **");
                Console.WriteLine("**  3. Xoa sinh vien boi ID.                         **");
                Console.WriteLine("**  4. Tim kiem sinh vien theo ten.                  **");
                Console.WriteLine("**  5. Sap xep sinh vien theo diem trung binh (GPA). **");
                Console.WriteLine("**  6. Sap xep sinh vien theo ten.                   **");
                Console.WriteLine("**  7. Sap xep sinh vien theo ID.                    **");
                Console.WriteLine("**  8. Hien thi danh sach sinh vien.                 **");
                Console.WriteLine("**  0. Thoat                                         **");
                Console.WriteLine("*******************************************************");
                Console.Write("Nhap tuy chon: ");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine("\n1. Them sinh vien.");
                        do
                        {
                            Console.WriteLine("Dien thong tin sinh vien: ten + gioi tinh + tuoi + toan + ly + hoa");
                            try
                            {
                                Console.WriteLine("Create new contact:");
                                Console.Write("Ten: ");
                                var ten = Console.ReadLine();
                                Console.Write("GioiTinh: ");
                                var gioiTinh = Console.ReadLine();
                                Console.Write("Tuoi: ");
                                var tuoi = Console.ReadLine();
                                Console.Write("Toan: ");
                                float toan = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Ly: ");
                                float ly = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Hoa: ");
                                float hoa = Convert.ToInt32(Console.ReadLine());

                                float diemtB = (float)(toan + ly + hoa) / 3;
                                var diemtb = Math.Round(diemtB, 1);
                                var hocluc = HocLuc();
                                string HocLuc()
                                {
                                    float diem = (float)diemtb;
                                    if (diem >= 8)
                                    {
                                        return "Gioi";
                                    }
                                    else if (diem < 8 && diem >= 6.5)
                                    {
                                        return "Kha";
                                    }
                                    else if (diem < 6.5 && diem >= 5)
                                    {
                                        return "Trung binh";
                                    }
                                    else
                                    {
                                        return "Yeu";
                                    }
                                }
                                var query = "INSERT INTO [dbo].[DSSV] ( [Ten], [GioiTinh], [Tuoi], [Toan], [Ly], [Hoa], [diemTB], [hocLuc]) VALUES ( @Ten, @GioiTinh, @Tuoi, @Toan, @Ly, @Hoa, @diemTB, @hocLuc)";
                                using (var connection = new SqlConnection(connectionString))
                                using (var command = new SqlCommand { Connection = connection })
                                {
                                    command.CommandText = query;
                                    command.Parameters.AddWithValue("Ten", ten);
                                    command.Parameters.AddWithValue("GioiTinh", gioiTinh);
                                    command.Parameters.AddWithValue("Tuoi", tuoi);
                                    command.Parameters.AddWithValue("Toan", toan);
                                    command.Parameters.AddWithValue("Ly", ly);
                                    command.Parameters.AddWithValue("Hoa", hoa);
                                    command.Parameters.AddWithValue("diemTB", diemtb);
                                    command.Parameters.AddWithValue("hocLuc", hocluc);

                                    connection.Open();
                                    var count = command.ExecuteNonQuery();
                                    Console.WriteLine("Da them thanh cong!");
                                }
                                
                            Console.WriteLine("Neu nhap them SV an phim so 1 -- neu muon thoat nhan so 0 ");
                            int exit = Convert.ToInt32(Console.ReadLine());
                            if (exit == 0)
                            {
                                break;
                            }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("<<<LOI~!>>> " + ex.Message);
                            }
                        } while (true);  

                        Console.WriteLine("\nThem sinh vien thanh cong!");
                        break;
                    case 2:
                        Console.WriteLine("\n2.Cap nhat thong tin theo ID.");
                        using (var connection = new SqlConnection(connectionString))
                        using (var command = new SqlCommand { Connection = connection })
                        {
                            connection.Open();
                            CapNhatTT(command);
                        }
                        Console.WriteLine("\nCap nhat thanh cong!");
                        break;
                    case 3:
                        Console.WriteLine("\n3.ID sinh vien can xoa");
                        using (var connection = new SqlConnection(connectionString))
                        using (var command = new SqlCommand { Connection = connection })
                        {
                            connection.Open();
                            XoaTen(command);
                        }
                        Console.WriteLine("\nDa xoa sinh vien");
                        break;
                    case 4:
                        Console.WriteLine("\n4.Tim sinh vien theo ten!");
                        using (var connection = new SqlConnection(connectionString))
                        using (var command = new SqlCommand { Connection = connection })
                        {
                            connection.Open();
                            TimTen(command);
                        }
                        Console.WriteLine("\nDa xong");
                        break;
                    case 5:
                        Console.WriteLine("\n5.Sap xep sinh vien theo diem TB GPA!");
                        using (var connection = new SqlConnection(connectionString))
                        using (var command = new SqlCommand { Connection = connection })
                        {
                            connection.Open();
                            SapXepDiem(command);
                        }
                        Console.WriteLine("\nDa xong");
                        break;
                    case 6:
                        Console.WriteLine("\n6.Sap xep sinh vien theo Ten!");
                        using (var connection = new SqlConnection(connectionString))
                        using (var command = new SqlCommand { Connection = connection })
                        {
                            connection.Open();
                            SapXepTen(command);
                        }
                        Console.WriteLine("\nDa xong");
                        break;
                    case 7:
                        Console.WriteLine("\n7.Sap xep sinh vien theo ID!");
                        using (var connection = new SqlConnection(connectionString))
                        using (var command = new SqlCommand { Connection = connection })
                        {
                            connection.Open();
                            SapXepID(command);
                        }
                        Console.WriteLine("\nDa xong");
                        break;
                    case 8:
                        using (var connection = new SqlConnection(connectionString))
                        using (var command = new SqlCommand { Connection = connection })
                        {
                            connection.Open();
                            Retrieve(command);
                        }
                        break;
                    case 0:
                        Console.WriteLine("\nDa thoat chuong trinh!");
                        return;
                }
            }            
        }
        static void CapNhatTT(SqlCommand command)
        {
            Console.WriteLine("Nhap ID can sua");
            var IdSua = Console.ReadLine();
            Console.WriteLine("Nhap thong tin cot can sua!");
            var cotSua = Console.ReadLine();
            Console.WriteLine("Cap nhat lai thong tin");
            var noiDung = Console.ReadLine();
            command.CommandText = $"Update dbo.DSSV Set {cotSua} = '{noiDung}' where ID = '{IdSua}'";
            var capNhatID = command.ExecuteNonQuery();
        }
        static void SapXepID(SqlCommand command)
        {
            command.CommandText = "Select * from dbo.DSSV order by ID";
            var sapXep = command.ExecuteReader();
            if (sapXep.HasRows)
            {
                while (sapXep.Read())
                {
                    var ID = sapXep["ID"];
                    var Ten = sapXep["Ten"] as string;
                    var gioiTinh = sapXep["GioiTinh"] as string;
                    var Tuoi = sapXep["Tuoi"];
                    var Toan = sapXep["Toan"];
                    var Ly = sapXep["Ly"];
                    var Hoa = sapXep["Hoa"];
                    var diemTB = sapXep["diemTB"];
                    var hocLuc = sapXep["hocLuc"];
                    Console.WriteLine($"[{ID}]\t {Ten}\t {gioiTinh}\t ({Tuoi})\t {Toan} {Ly} {Hoa}\t ({diemTB})\t ({hocLuc})");
                }
            }
            sapXep.Close();
        }
        static void SapXepTen(SqlCommand command)
        {
            command.CommandText = "Select * from dbo.DSSV order by Ten";
            var sapXep = command.ExecuteReader();
            if (sapXep.HasRows)
            {
                while (sapXep.Read())
                {
                    var ID = sapXep["ID"];
                    var Ten = sapXep["Ten"] as string;
                    var gioiTinh = sapXep["GioiTinh"] as string;
                    var Tuoi = sapXep["Tuoi"];
                    var Toan = sapXep["Toan"];
                    var Ly = sapXep["Ly"];
                    var Hoa = sapXep["Hoa"];
                    var diemTB = sapXep["diemTB"];
                    var hocLuc = sapXep["hocLuc"];
                    Console.WriteLine($"[{ID}]\t {Ten}\t {gioiTinh}\t ({Tuoi})\t {Toan} {Ly} {Hoa}\t ({diemTB})\t ({hocLuc})");
                }
            }
            sapXep.Close();
        }
        static void SapXepDiem(SqlCommand command)
        {
            command.CommandText = "Select * from dbo.DSSV order by diemTB DESC";
            var sapXep = command.ExecuteReader();
            if (sapXep.HasRows)
            {
                while (sapXep.Read())
                {
                    var ID = sapXep["ID"];
                    var Ten = sapXep["Ten"] as string;
                    var gioiTinh = sapXep["GioiTinh"] as string;
                    var Tuoi = sapXep["Tuoi"];
                    var Toan = sapXep["Toan"];
                    var Ly = sapXep["Ly"];
                    var Hoa = sapXep["Hoa"];
                    var diemTB = sapXep["diemTB"];
                    var hocLuc = sapXep["hocLuc"];
                    Console.WriteLine($"[{ID}]\t {Ten}\t {gioiTinh}\t ({Tuoi})\t {Toan} {Ly} {Hoa}\t ({diemTB})\t ({hocLuc})");
                }
            }
            sapXep.Close();
        }        
        static void XoaTen(SqlCommand command)
        {
            var Idxoa = Console.ReadLine();
            command.CommandText = $"Delete from dbo.DSSV where ID = '{Idxoa}'";
            var xoaId = command.ExecuteNonQuery();
        }
        static void TimTen(SqlCommand command)
        {
            var tenCanTim = Console.ReadLine();
            command.CommandText = $"Select * from dbo.DSSV where Ten = '{tenCanTim}'";
            var tenTim = command.ExecuteReader();
            while (tenTim.Read())
            {
                var ID = tenTim["ID"];
                var Ten = tenTim["Ten"] as string;
                var gioiTinh = tenTim["GioiTinh"] as string;
                var Tuoi = tenTim["Tuoi"];
                var Toan = tenTim["Toan"];
                var Ly = tenTim["Ly"];
                var Hoa = tenTim["Hoa"];
                var diemTB = tenTim["diemTB"];
                var hocLuc = tenTim["hocLuc"];
                Console.WriteLine($"[{ID}]\t {Ten}\t {gioiTinh}\t ({Tuoi})\t {Toan} {Ly} {Hoa}\t ({diemTB})\t ({hocLuc})");
            }
            tenTim.Close();
        }
        static void Retrieve(SqlCommand command)
        {
            command.CommandText = "SELECT * FROM dbo.DSSV";
            var sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var ID = sqlDataReader["ID"];
                    var Ten = sqlDataReader["Ten"] as string;
                    var gioiTinh = sqlDataReader["GioiTinh"] as string;
                    var Tuoi = sqlDataReader["Tuoi"];
                    var Toan = sqlDataReader["Toan"];
                    var Ly = sqlDataReader["Ly"];
                    var Hoa = sqlDataReader["Hoa"];
                    var diemTB = sqlDataReader["diemTB"];
                    var hocLuc = sqlDataReader["hocLuc"];
                    Console.WriteLine($"[{ID}]\t {Ten}\t {gioiTinh}\t ({Tuoi})\t {Toan} {Ly} {Hoa}\t ({diemTB})\t ({hocLuc})");
                }
            }
            sqlDataReader.Close();
        }           
    }
}
