using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelAutomation
{
    public partial class frmCustomerRecord : Form
    {
        public frmCustomerRecord()
        {
            InitializeComponent();
        }

        private void frmCustomerRecord_Load(object sender, EventArgs e)
        {

        }
        ArrayList rooms = new ArrayList();

       

        void seat()
        {
            string room = "";
            for (int i = 0; i <rooms.Count; i++)
            {
                room += rooms[i].ToString() + ",";

            }
            if(rooms.Count >= 1)
            {
                room = room.Remove(room.Length - 1, 1);
            }
            txtSelectedRooms.Text = room;
        }

        private void roomClick(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Green)
            {
                ((Button)sender).BackColor = Color.Orange;
                if (!rooms.Contains(((Button)sender).Text))
                {
                    rooms.Add(((Button)sender).Text);
                }
                seat();
            }
            else if (((Button)sender).BackColor == Color.Orange)
            {
                ((Button)sender).BackColor = Color.Green;
                if (rooms.Contains(((Button)sender).Text))
                    rooms.Remove(((Button)sender).Text);

            }
            seat();


    }
        public DateTime entryDate { get; set; }
        public DateTime departureDate { get; set; }

        private void btnGive_Click(object sender, EventArgs e)
        {
           //ntryDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
      //    customerRecord r = new customerRecord();
      //    for(int=0; int<rooms.Count; int++)
      //    {
      //        int room = Convert.ToInt16(rooms[i]);
       //       r
            }
            
        }
    }
