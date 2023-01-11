using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UAS_035;

namespace UAS_035
{
    class Node
    {
        public int Id;
        public string Nama;
        public string Jenis;
        public int Harga;
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
            int id, hrg;
            string nm, jn;
            Console.Write("Masukkan Id Barang : ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Barang : ");
            nm = Console.ReadLine();
            Console.Write("Masukkan Harga Barang : ");
            hrg = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan jenis Barang : ");
            jn = Console.ReadLine();

            Node newnode = new Node();

            newnode.Id = id;
            newnode.Nama = nm;
            newnode.Harga = hrg;
            newnode.Jenis = jn;

            if (START == null || id <= START.Id)
            {
                if ((START != null) && (id == START.Id))
                {
                    Console.WriteLine("Id barang sudah terpakai");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (id >= current.Id))
            {
                if (id == current.Id)
                {
                    Console.WriteLine("\nId barang sudah terpakai");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool search(string jn, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;


            while ((current != null) && (jn != current.Jenis))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);

        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nList data barang : ");
                Console.Write("Id Barang" + "   " + "Nama Barang" + "    " + "Harga Barang" + "   " + "Jenis Barang" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.Id + "             " + currentNode.Nama + "              " + currentNode.Harga + "              " + currentNode.Jenis + "\n");
                }
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
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
                    Console.WriteLine("1. Masukkan List Barang");
                    Console.WriteLine("2. Melihat semua List Barang");
                    Console.WriteLine("3. Cari Barang");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4) : ");
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
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList kosong");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nmasukkan jenis barang yang ingin dicari : ");
                                string jns = Convert.ToString(Console.ReadLine());
                                if (obj.search(jns, ref previous, ref current) == false)
                                    Console.WriteLine("\nList tidak ditemukan");
                                else
                                {
                                        Console.WriteLine("\nList ditemukan");
                                        Console.WriteLine("\nId Barang: " + current.Id);
                                        Console.WriteLine("\nHarga Barang : " + current.Harga);
                                        Console.WriteLine("\nNama Barang: " + current.Nama);
                                        Console.WriteLine("\nJenis: " + current.Jenis);                                   
                                }
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nOpsi Pilihan tidak valid");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nMohon cek kembali");
                }
            }
        }
    }
}
//2.Single linked list, karena data dibaca dari kiri ke kanan atau atas ke bawah. 
//  dan in a doubly-linked list holds the address of its previous node also.
//3.Rear,Front
//4. a.4 level
//   b.Metode Inorder,Data tersebut dapat dibaca dengan cara :
//      1.  Traverse the left subtree
//      2.  Visit root
//      3.  Traverse the right subtree
//     hasil dari contoh soal : 15,20,25,30,31,32,35,48,50,65,66,67,69,70,90,94,98,99