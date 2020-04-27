using System;

namespace ClientCentralRevised
{

    // *************************************************************
    // Application:     Client Central
    // Author:          Atkinson, Nathan D
    // Description:     WinForm app that can add contacts to a 
    //                  list for future reference and use.
    // Date Created:    04/26/2020
    // Date Revised:    04/26/2020
    // *************************************************************



    class Contact
    {
        //how data is going to be processed (meat and potatoes)
        
        private string firstName;
        private string lastName;
        private string contactNo;
        


        //where we get our info from user
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string ContactNo
        {
            get { return contactNo; }
            set
            {
                if (value.Length == 10)
                {
                    contactNo = value;
                }
                else
                {
                    contactNo = "0000000000";
                }
            }
        }



        public Contact()
        {
            FirstName = "John";
            LastName = "Doe";
            ContactNo = "0000000000";

        }

        public Contact(string firstName, string lastName, string contactNo)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNo = contactNo;
        }
        

        //get output from user
        public override string ToString()
        {
            string output = String.Empty;

            output += String.Format("{0}, {1} ", LastName, FirstName);
            output += String.Format("({0}) {1}-{2}", ContactNo.Substring(0, 3), ContactNo.Substring(3, 3), ContactNo.Substring(6, 4));

            return output;
        }
    }
}