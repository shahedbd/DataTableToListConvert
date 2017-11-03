using System;
using System.Collections.Generic;
using System.Data;

namespace DataTableToList
{
    class Program
    {
        static void Main(string[] args)
        {
            ConversionProcess _ConversionProcess = new ConversionProcess();

            //Using Loop
            Console.WriteLine("Using Loop***************\n\n");
            var listPersonalInfo1 = _ConversionProcess.UsingLoop();
            foreach (var item in listPersonalInfo1)
            {
                Console.WriteLine(item.FirstName + " *** " + item.LastName + " *** " + item.Country);
            }


            //Using UsingLINQ
            Console.WriteLine("Using LINQ***************\n\n");
            var listPersonalInfo2 = _ConversionProcess.UsingLINQ();
            foreach (var item in listPersonalInfo2)
            {
                Console.WriteLine(item.FirstName + " *** " + item.LastName + " *** " + item.Country);
            }


            //Using Extension Method: Generics
            Console.WriteLine("Using Extension Method: Generics***************\n\n");
            DataTable dt = DataPreparations.GetDataTableData();
            List<PersonalInfo> listPersonalInfo3 = dt.DataTableToList<PersonalInfo>();
            foreach (var item in listPersonalInfo3)
            {
                Console.WriteLine(item.FirstName + " *** " + item.LastName + " *** " + item.Country);
            }


            //Using Reader from MSSQL DB
            Console.WriteLine("Using Reader from MSSQL DB***************\n\n");
            List<PersonalInfo> listPersonalInfo4 = _ConversionProcess.UsingReader();
            foreach (var item in listPersonalInfo4)
            {
                Console.WriteLine(item.FirstName.Trim() + " *** " + item.LastName.Trim() + " *** " + item.Country.Trim());
            }



            Console.ReadLine();
        }
    }
}
