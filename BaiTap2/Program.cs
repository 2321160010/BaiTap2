using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2
{
    class Sanpham
    {
        private string _ten;
        private double _giamua;
        public Sanpham()
        {
        }
        public Sanpham(string ten, double giamua)
        {
            this._ten = ten;
            this._giamua = giamua;
        }
        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }

        public double Giamua
        {
            get { return _giamua; }
            set
            {
                if (value >= 0)
                    _giamua = value;
            }
        }
        public virtual double Tinhgiaban()
        {
            return 0;
        }
        public virtual string Inchitiet()
        {
            return _ten;
        }
        public virtual void Nhap()
        {
            Console.WriteLine("Cho biet ten san pham: ");
            _ten = Console.ReadLine();
            Console.WriteLine("Cho biet gia ban: ");
            _giamua = double.Parse(Console.ReadLine());
        }
    }
    class Socola : Sanpham
    {
        private double _loinhuan;
        public Socola() : base() { }
        public Socola(string ten, double giamua) : base(ten, giamua)
        {
            _loinhuan = Giamua * 0.2;
        }
        public override double Tinhgiaban()
        {
            return Giamua + _loinhuan;
        }
        public override string Inchitiet()
        {
            return string.Format("`Ten: {0} -Gia ban: {1 :#.##0}", Ten, Tinhgiaban());
        }
        public override void Nhap()
        {
            base.Nhap();
            _loinhuan = Giamua * 0.2;
        }
    }
    class Nuocuong : Sanpham
    {
        private double _loinhuon;
        private double _Chiphigiulanh;
        public Nuocuong() : base() { }
        public Nuocuong(string ten, double giamua) : base(ten, giamua)
        {
            _loinhuon = Giamua * 0.15;
            _Chiphigiulanh = Giamua * 0.1;
        }
        public override double Tinhgiaban()
        {
            return Giamua + _loinhuon + _Chiphigiulanh;
        }
        public override string Inchitiet()
        {
            return string.Format("Ten: {0} - Gia ban: {1 :#.##0}", Ten, Tinhgiaban());
        }
        public override void Nhap()
        {
            base.Nhap();
            _loinhuon = Giamua * 0.15;
            _Chiphigiulanh = Giamua * 0.1;
        }
    }
    class Quanlysanpham
    {
        private string _ten;
        private Sanpham[] dssp;
        private int n;
        public Quanlysanpham()
        {
            _ten = "Cua hang ban le";
            dssp = new Sanpham[100];
            n = 0;
        }
        public Quanlysanpham(int size)
        {
            _ten = "Cua hang ban le";
            dssp = new Sanpham[size];
            n = 0;
        }
        public void Nhap()
        {
            int chon;
            Sanpham sp;
            while (true)
            {
                Console.Write("Ban muon them san pham loai nao (1.socola - 2,nuoc uong): ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        sp = new Socola();
                        sp.Nhap();
                        dssp[n++] = sp;
                        break;
                    case 2:
                        sp = new Nuocuong();
                        sp.Nhap();
                        dssp[n++] = sp;
                        break;
                }
                Console.Write("Ban co tiep tuc? (0.thoat): ");
                chon = int.Parse(Console.ReadLine());
                if (chon == 0)
                    break;
            }
        }
        public void Indanhsachsp()
        {
            Console.WriteLine("*****Ten cua hang: " + _ten);
            Console.WriteLine("*****Danh sach cac san pham*****");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(dssp[i].Inchitiet());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Quanlysanpham pl = new Quanlysanpham();
            pl.Nhap();
            pl.Indanhsachsp();
            Console.ReadLine();
        }
    }
}