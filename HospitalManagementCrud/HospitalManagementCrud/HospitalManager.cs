using System;
using System.Collections.Generic;

namespace HospitalManagementCrud
{
    internal class HospitalManager
    {
        private int patientId;
        private int roomNo;
        private string patientName;
        private string attenderName;
        private DateTime dateOfAdmit;
        public static HospitalManager kk = new HospitalManager();
        public HospitalManager()
        {
        }

        public HospitalManager(int patientId, int roomNo, string patientName, string attenderName, DateTime dateOfAdmit)
        {
            this.patientId = patientId;
            this.roomNo = roomNo;
            this.patientName = patientName;
            this.attenderName = attenderName;
            this.dateOfAdmit = dateOfAdmit;
        }

        internal void managerOperations(List<HospitalManager> hospitalManagerList)
        {
            Console.WriteLine(" 1.display all patient details \n" +
                "2.find the patient data \n" +
                "3.Update patient data \n" +
                "4.delete patient data \n" +
                "5.exit");
             HospitalManager hospital = new HospitalManager();
            Console.WriteLine("Enter your choice : ");
            int choice = int.Parse(Console.ReadLine());
            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        hospital.displayAll(hospitalManagerList);
                        break;
                    case 2:
                        hospital.findPatient(hospitalManagerList);
                        break;
                    case 3:
                        hospital.updatePatient(hospitalManagerList);
                        break;
                    case 4:
                        hospital.deletePatient(hospitalManagerList);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Enter your choice : ");
                 
                Console.WriteLine(" 1.display all patient details \n" +
               "2.find the patient data \n" +
               "3.Update patient data \n" +
               "4.delete patient data \n" +
               "5.exit");
                choice = int.Parse(Console.ReadLine());

            }
           
        }

        public void deletePatient(List<HospitalManager> hospitalManagerList)
        {
            try
            {
                Console.WriteLine("Enter the id of the patient to delete: ");
                int idfind = int.Parse(Console.ReadLine());
                for (int i = 0; i < hospitalManagerList.Count; i++)
                {
                    if (hospitalManagerList[i].patientId == idfind)
                    {
                        hospitalManagerList.RemoveAt(i);
                    }

                }
            }
            catch (Exception e)
            {
                if (e.Message != null)
                {
                    kk.HandleError("id not found");
                }
            }
        }

        public void HandleError(string v)
        {
            Console.WriteLine("message is "+v);
        }

        private void updatePatient(List<HospitalManager> hospitalManagerList)
        {
            Console.WriteLine("Enter the id of the patient : ");
            int idfind = int.Parse(Console.ReadLine());
            foreach (var item in hospitalManagerList)
            {
                if (item.patientId == idfind)
                {
                    Console.WriteLine("choose which one to update : 1.patient name 2.room number");
                    int opt = int.Parse(Console.ReadLine());
                    switch (opt)
                    {
                        case 1:
                            Console.WriteLine("enter the new patient name : ");
                            string tempName = Console.ReadLine();
                            item.patientName = tempName;
                            Console.WriteLine("Name updated successfully");
                            break;
                        case 2:
                            Console.WriteLine("enter new room no");
                            item.roomNo = int.Parse(Console.ReadLine());
                            Console.WriteLine("room number updated successfully");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("patient details not found !");
                }
            }
        }

        public void displayAll(List<HospitalManager> hospitalManagerList)
        {
            Console.WriteLine("##########     Patient Details Record            ########");
            foreach (var item in hospitalManagerList)
            {
                Console.WriteLine($" patient id : {item.patientId} patientName : {item.patientName} Attender name :: {item.attenderName} Room number :: {item.roomNo} Date of admit :: {item.dateOfAdmit.ToShortDateString()}");
            }
        }

        public void findPatient(List<HospitalManager> hospitalManagerList)
        {
            Console.WriteLine("Enter the id of the patient : ");
            int idfind = int.Parse(Console.ReadLine());
           foreach(var item in hospitalManagerList)
            {
                if (item.patientId == idfind)
                {
                    Console.WriteLine($" patient id : {item.patientId} patientName : {item.patientName} Attender name :: {item.attenderName} Room number :: {item.roomNo} Date of admit :: {item.dateOfAdmit.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine("patient details not found !");
                }
            }

        }


    }
}
