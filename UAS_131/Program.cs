using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_131
{
    class Node
    {
        public int HargaBarang;
        public string NamaBarang;
        public string JenisBarang;
        public int IdBarang;
        public Node next;
        
    }
    class list
    {
        Node START;
        public list()
        {
            START = null;
        }
        public void insert()
        {
            int hb, Idb;
            string nb, jb;
            Console.WriteLine("Masukkann Id Barang : ");
            Idb = Convert.ToInt32(Console.ReadLine());  
            Console.WriteLine("Masukkan Nama Barang : ");
            nb = Console.ReadLine();
            Console.WriteLine("Masukkan Jenis Barang : ");
            jb = Console.ReadLine();
            Console.WriteLine("Masukkan Harga Barang : ");
            hb = Convert.ToInt32(Console.ReadLine());

            Node newnode = new Node();

            newnode.HargaBarang = hb;
            newnode.NamaBarang = nb;
            newnode.JenisBarang = jb;
            newnode.IdBarang = Idb;

            if(START == null || Idb <= START.IdBarang)
            {
                if((START != null) && (Idb == START.IdBarang))
                {
                    Console.WriteLine("\nId Barang Tidak Boleh Sama\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;


            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (Idb >= current.IdBarang))
            {
                if(Idb == current.IdBarang)
                {
                    Console.WriteLine("\nId Barang Tidak Boleh Sama\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
            
        }
        public bool search(int Idb, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            
            while((current != null) && (Idb != current.IdBarang))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("List Barang Masih Kosong");
            else
            {
                Console.WriteLine("\nList Barang Dagangan");
                Console.WriteLine("Nama Barang" + "   " + "Id Barang" + "   " + "Jenis Barang" + "   " + "Harga Barang" + "\n");
                Node currentnode;
                for(currentnode = START; currentnode != null; currentnode = currentnode.next)
                {
                    Console.Write(currentnode.NamaBarang + "   " + currentnode.IdBarang + "   " + currentnode.JenisBarang + "   " + currentnode.HargaBarang + "\n");
                }
                    
            }
        }
       
    }

     class Program
    {
        static void Main(string[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Menambahkan Data Barang Dalam List");
                    Console.WriteLine("2. Melihat Semua Data Barang Dalam List");
                    Console.WriteLine("3. Mencari Data Barang Dalam LIst");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("\n Enter Your Choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insert();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if(obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList Masih Kosong");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan Id Barang yang Ingin Dicari : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Node IDB;
                                    for(IDB = current; IDB != null; IDB = IDB.next)
                                    {
                                        Console.WriteLine("\nRecord Found");
                                        Console.WriteLine("\nIdBarang : " + current.IdBarang);
                                        Console.WriteLine("\nNama Barang : " + current.NamaBarang);
                                        Console.WriteLine("\nJenis Barang : " + current.JenisBarang);
                                        Console.WriteLine("\nHarga Barang : " + current.HargaBarang);
                                    }
                                }
                                   
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }   
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck Nilai Yang Anda Masukkan");
                }
            }
        }
    }
}

/*
 2. Singly Lingked List, Dikarenakan bisa untuk mengurutkan data dan mencari data 
 3. FRONT dan REAR
 4. a.4
    b.Menggunakan preorder yaitu dari akar kiri, kanan
        50,48,30,20,15,25,32,31,35,70,65,67,66,69,90,98,94,99
*/
/**/
