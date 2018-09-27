using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelAutomation
{
    class customerRecord
    {
        public string customerName_Surname { get; set; }
        Database db = new Database();
        public static void updateRoom(int room, string nameSurname)

        {
            Database db = new Database();
            if (db.connection.State== System.Data.ConnectionState.Open)
            {
                db.connection.Close();
            }
            try
            {
                db.connection.Open();
                SqlCommand update = new SqlCommand("update rooms set name=@getRoom, availability=@availability, roomNo=@roomNo", db.connection);
                     update.Parameters.AddWithValue("@getRoom", nameSurname);
                update.Parameters.AddWithValue("@availability", "Full");
                update.Parameters.AddWithValue("@roomNo", room);
                update.ExecuteNonQuery();
                update.Dispose();
            }
            catch { }

            finally
            {
                db.connection.Close();

            }
            {

              
            }

        }

        public void record(string name, string surname, string phone, string mail, string tcNo, int roomNo, string fee, DateTime entry, DateTime departure, string gender, string birthday)
        {
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                db.connection.Close();
            }
            try
            {
                db.connection.Open();
                SqlCommand get_record = new SqlCommand("insert into customers values(@name, @surname,@birthday, @gender, @phone, @mail, @tc, @fee, @entry, @departure, @room)", db.connection);
                get_record.Parameters.AddWithValue("@name", name);
                get_record.Parameters.AddWithValue("@surname", surname);
                get_record.Parameters.AddWithValue("@birthday", birthday);
                get_record.Parameters.AddWithValue("@gender", gender);
                get_record.Parameters.AddWithValue("@phone", phone);
                get_record.Parameters.AddWithValue("@mail", mail);
                get_record.Parameters.AddWithValue("@tc", tcNo);
                get_record.Parameters.AddWithValue("fee", fee);
                get_record.Parameters.AddWithValue("@entry", entry);
                get_record.Parameters.AddWithValue("@departure", departure);
                get_record.Parameters.AddWithValue("@room", roomNo);
                get_record.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Customer registration successfully:  " + name  +  surname + "room number is: "  + roomNo  );
                get_record.Dispose();
                ////////////////////////////////////////////////
                customerName_Surname = name + "" + surname;
                updateRoom(roomNo, customerName_Surname);



            }
            catch { }
            finally
            {
                db.connection.Close();
            }



    }
    }
    }

