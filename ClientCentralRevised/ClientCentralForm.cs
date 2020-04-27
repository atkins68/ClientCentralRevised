using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//implementing code from contact.cs communicates with form and txt file
namespace ClientCentralRevised
{
    public partial class ClientCentralForm : Form
    {
        private Contact[] phoneBook = new Contact[1];

        public ClientCentralForm()
        {
            InitializeComponent();
        }
        //sends to txt file
        private void Write(Contact obj)
        {
            StreamWriter sw = new StreamWriter("Contacts.txt");
            sw.WriteLine( phoneBook.Length + 1 );
            sw.WriteLine(obj.FirstName);
            sw.WriteLine(obj.LastName);
            sw.WriteLine(obj.ContactNo);

            for( int x = 0; x < phoneBook.Length; x++)
            {
                sw.WriteLine(phoneBook[x].FirstName);
                sw.WriteLine(phoneBook[x].LastName);
                sw.WriteLine(phoneBook[x].ContactNo);
            }

            sw.Close();

        }



        //reads from text file
        private void Read()
        {
            StreamReader sr = new StreamReader("Contacts.txt");
            phoneBook = new Contact[Convert.ToInt32(sr.ReadLine())];

            for( int x = 0; x < phoneBook.Length; x++)
            {
                phoneBook[x] = new Contact();
                phoneBook[x].FirstName = sr.ReadLine();
                phoneBook[x].LastName = sr.ReadLine();
                phoneBook[x].ContactNo = sr.ReadLine();
            }

            sr.Close();

        }

        //display collected user input into the displayed list in CCform
        private void Display()
        {
            lstContacts.Items.Clear();
        //call 'ToString' method to add to the list
            for(int x = 0; x < phoneBook.Length; x++)
            {
                lstContacts.Items.Add(phoneBook[x].ToString());
            }

        }
        //clears boxes
        private void ClearForm()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtContactNo.Text = String.Empty;
        }


        //allows add button to work
        //creates object
        //gets text from text boxes
        
        private void Contact_Click(object sender, EventArgs e)
        {
            Contact obj = new Contact();
            obj.FirstName = txtFirstName.Text;
            obj.LastName = txtLastName.Text;
            obj.ContactNo = txtContactNo.Text;


            //write, read and load, sort, display info, clear form to enable new user input
            Write(obj);
            Read();
            SortList();
            Display();
            ClearForm();

            
        }

        private void ClientCentralForm_Load(object sender, EventArgs e)
        {
            Read();
            Display();
        }
        //sorts contacts
        private void btnSort_Click(object sender, EventArgs e)
        {
            SortList();
            Display();
        }

        private void SortList()
        {
            Contact temp;
            bool swap;

            do
            {
                swap = false;

                for(int x = 0; x < (phoneBook.Length - 1); x++)
                {
                    if( phoneBook[x].LastName.CompareTo( phoneBook[x+1].LastName) > 0)
                    {
                        temp = phoneBook[x];
                        phoneBook[x] = phoneBook[x + 1];
                        phoneBook[x + 1]= temp;
                        swap = true;
                    }
                }

            } while (swap == true);
            
        }
    }
}
