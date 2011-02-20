using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Needed
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Drawing;

namespace Ming.Atf.Pictures
{
    class URLtoImage
    {
        private byte[] downloadedData;

        public URLtoImage()
        {
            downloadedData = new byte[0];
        }

        public Image getImageFromURL(String url)
        {
            //DownloadData function from here
            downloadData(url); 
            byte[] imageData = downloadedData;
            MemoryStream stream = new MemoryStream(imageData);
            Image img = Image.FromStream(stream);
            stream.Close();

            return img;
        }

        //Connects to a URL and attempts to download the file
        private void downloadData(string url)
        {
            //progressBar1.Value = 0;
            try
            {
                //Optional
                //this.Text = "Connecting...";
                Application.DoEvents();

                //Get a data stream from the url
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();

                //Download in chuncks
                byte[] buffer = new byte[1024];

                //Get Total Size
                int dataLength = (int)response.ContentLength;

                //With the total data we can set up our progress indicators
                //progressBar1.Maximum = dataLength;
                //lbProgress.Text = "0/" + dataLength.ToString();

                //this.Text = "Downloading...";
                Application.DoEvents();

                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                MemoryStream memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        //Finished downloading
                        //progressBar1.Value = progressBar1.Maximum;
                        //lbProgress.Text = dataLength.ToString() + "/" + dataLength.ToString();

                        Application.DoEvents();
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);

                        //Update the progress bar
                        /*if (progressBar1.Value + bytesRead <= progressBar1.Maximum)
                        {
                            progressBar1.Value += bytesRead;
                            lbProgress.Text = progressBar1.Value.ToString() + "/" + dataLength.ToString();

                            progressBar1.Refresh();
                            Application.DoEvents();
                        }*/
                    }
                }

                //Convert the downloaded stream to a byte array
                downloadedData = memStream.ToArray();

                //Clean up
                stream.Close();
                memStream.Close();
            }
            catch (Exception)
            {
                //May not be connected to the internet
                //Or the URL might not exist
                MessageBox.Show("There was an error accessing the URL.");
            }

            //txtData.Text = downloadedData.Length.ToString();
            //this.Text = "Download Data through HTTP";
        }

    }
}
