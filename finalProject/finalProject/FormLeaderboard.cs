using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace finalProject
{
    public partial class FormLeaderboard : Form
    {
        public string mode = "easy",prevMode = "";

        public FormLeaderboard()
        {
            InitializeComponent();
        }

        private void FormLeaderboard_Load(object sender, EventArgs e)
        {
            dataDownload(mode);
        }

        private string getData(string URL)
        {
            // Create a request for the URL.   
            string data = "";
            WebRequest request = WebRequest.Create(URL);
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            //textBoxResponce.Text = ((HttpWebResponse)response).StatusDescription + "\r\n";

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                data += responseFromServer;
            }
            // Close the response.  
            response.Close();
            return data;
        }
        private void buttonMode_Click(object sender, EventArgs e)
        {
            Button modeNow = (Button)sender;
            prevMode = mode;
            if(modeNow.Text =="簡單")
                mode = "easy";
            else if(modeNow.Text == "普通")
                mode = "normal";
            else if(modeNow.Text == "困難")
                mode = "hard";
            if(mode != prevMode)
                dataDownload(mode);
        }

        private void dataDownload(string mode)
        {
            listView1.Items.Clear();

           string data = getData("https://bouncingball-a3510.firebaseio.com/scoreHistory/" + mode + ".json");
           JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

           List<Record> records = javaScriptSerializer.Deserialize<List<Record>>(data);
            int i = 1;
            foreach (Record record in records)
            {
                var listview = new ListViewItem((i++).ToString("000"));

                listview.SubItems.Add(record.name.ToString());
                listview.SubItems.Add(record.score.ToString());
                listview.SubItems.Add(record.date);
                listView1.Items.Add(listview);
            }
        }

    }
}
