using System;
using FunctionData;
using BooksLibrary;
using LibraryData;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BooksLibrary
{
    class Program
    {
        static void Main(string[] args)
        {

            string Studentname;
            string Contactno;
            int Bookid;
            string Bookname;
            DateTime Issuedate;
            DateTime returndate;
            string Author;
            int Price;

            Connection1.CreateConnection();
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("\t\t**********WELCOME TO THE LIBRARY SYSTEM**********");
            Console.WriteLine("                                                         ");
            Console.WriteLine("\t\t\t1.Display Data");
            Console.WriteLine("\t\t\t2.Insert Data");
            Console.WriteLine("\t\t\t3.Update Data");
            Console.WriteLine("\t\t\t4.Delete Data");
            Console.WriteLine("\t\t\t5.Display selected Book Authors Data");
            Console.WriteLine("\t\t\t6.Exit");

            do
            {
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Display Data");
                        Connection1.DisplayData();
                        break;

                    case 2:

                        Console.WriteLine("Enter you details:");
                        //Console.WriteLine("Enter the Student Id:");
                        //Studentid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Student Name:");

                        Studentname = Console.ReadLine();
                        while (String.IsNullOrEmpty(Studentname))
                        {
                            Console.WriteLine("please enter The Address name it cannot be blank");
                            Console.WriteLine("Enter the Address again");
                            Studentname = Console.ReadLine();

                        }



                        do
                        {
                            Console.WriteLine("Enter the Student Contact no:");
                            Contactno = Console.ReadLine();
                            long Cno1 = (long)Convert.ToDouble(Contactno);

                            bool check = isValidContactNumber(Cno1);


                            if (check == true)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Length of Contact number must be 10!!!");
                                continue;
                            }
                        } while (true);




                        bool isValidContactNumber(long inputContactNumber)
                        {
                            string strRegex;
                            strRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9] {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";


                            Regex re = new Regex(strRegex);


                            if (re.IsMatch(Convert.ToString(inputContactNumber)))
                            {
                                return (true);
                            }

                            else
                            {
                                return (false);
                            }

                        }





                        Console.WriteLine("Enter the Book Id:");
                        Bookid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Book Name:");
                        Bookname = Console.ReadLine();
                        while (String.IsNullOrEmpty(Bookname))
                        {
                            Console.WriteLine("please enter The Book name it cannot be blank");
                            Console.WriteLine("Enter the Bookname again");
                            Bookname = Console.ReadLine();

                        }
                        Console.WriteLine("Enter the Issue Date:");
                        Issuedate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter the Return Date:");
                        returndate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter the Author Name:");
                        Author = Console.ReadLine();
                        while (String.IsNullOrEmpty(Author))
                        {
                            Console.WriteLine("please enter The Author name it cannot be blank");
                            Console.WriteLine("Enter the Author again");
                            Author = Console.ReadLine();

                        }

                        Console.WriteLine("Enter the Price:");
                        Price = Convert.ToInt32(Console.ReadLine());
                        Connection1.InsertData(Studentname, Contactno, Bookid, Bookname, Issuedate, returndate, Author, Price);


                        Connection1.DisplayData();
                        break;
                    case 3:
                        Console.WriteLine("Enter Student id");
                        int sid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Student new name");
                        String name = Console.ReadLine();
                        while (String.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("please enter the name it cannot be blank");
                            Console.WriteLine("Enter the name again");
                            name = Console.ReadLine();

                        }

                        Connection1.UpdateData(sid, name);
                        Connection1.DisplayData();

                        break;
                    case 4:
                        Console.WriteLine("Enter Student id");
                        int x = Convert.ToInt32(Console.ReadLine());
                        Connection1.DeleteData(x);
                        Connection1.DisplayData();
                        break;
                
                    case 5:
                        Console.WriteLine("Enter Author name");
                        Author = Console.ReadLine();
                        Connection1.DisplayselectedBookAuthorData(Author);
                        Connection1.DisplayData();
                        break;
                    case 6:
                        Console.WriteLine("Exiting From Application");
                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine("Enter correct option");
                        break;
                }


            }
            while (true);

        
                Console.ReadLine();
            }
           

        }
    }

