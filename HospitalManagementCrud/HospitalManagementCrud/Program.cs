using System;
using System.Collections.Generic;
using static System.Console;

namespace HospitalManagementCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int patientId, roomNo;
            string patientName, attenderName;
            DateTime dateOfAdmit;
            WriteLine("Enter the number of patients to register:");
            int numberOfPatients = int.Parse(Console.ReadLine());
            List<HospitalManager> hospitalManagerList = new List<HospitalManager>();
            HospitalManager hospitalManager = new HospitalManager();
            for(int i =0 ; i < numberOfPatients; i++)
            {
                WriteLine("PatientID : ");
                patientId= int.Parse(Console.ReadLine());
                WriteLine("Room number : ");
                roomNo= int.Parse(Console.ReadLine());
                WriteLine("PatientName : ");
                patientName =Console.ReadLine();
                WriteLine("Attender name : ");
                attenderName = Console.ReadLine();
                WriteLine("Date of admit : ");
                dateOfAdmit = DateTime.Parse(ReadLine());
                hospitalManagerList.Add(new HospitalManager(patientId,roomNo,patientName,attenderName,dateOfAdmit));

            }
            WriteLine("Thankyou for entering data ...!");
            WriteLine(" Select the operation you want to do ");
            hospitalManager.managerOperations(hospitalManagerList);

        }
    }
}
