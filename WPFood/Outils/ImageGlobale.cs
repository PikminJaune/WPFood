using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace WPFood.Outils
{
    internal class ImageGlobale
    {
        public const string PATH_IMAGES_ITEMS = @"../../../Assets/Images/items";

        public const string FTP_ITEM_IMAGE = @"ftp://techinfo-cstj.ca/public_html/Assets/Images/items/";

        public const string PATH_ASSET = "https://wpfood.techinfo-cstj.ca/Assets/Images/items/";

        public const string UTILISATEUR = "wpfood";
        public const string MDP = "KccY99a79k";

        public static void TeleverserFichier(string source, string nomImage)
        {
            Uri serveurUri = new Uri(FTP_ITEM_IMAGE + nomImage);
            try
            {
                if (serveurUri.Scheme != Uri.UriSchemeFtp)
                {
                    MessageBox.Show("Mauvais URI");
                    return;
                }

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serveurUri);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Proxy = null;
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(UTILISATEUR, MDP);

                FileInfo ff = new FileInfo(source);
                byte[] fileContents = new byte[ff.Length];

                using(FileStream fr = ff.OpenRead())
                {
                    fr.Read(fileContents, 0, Convert.ToInt32(ff.Length));
                }


                using (Stream writer = request.GetRequestStream())
                {
                    writer.Write(fileContents, 0, fileContents.Length);
                }

                //Obtenir la response de l'opération
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                MessageBox.Show("L'insertion de " + nomImage + " c'est fait avec succès !", "Super !", MessageBoxButton.OK);
            }
            catch (WebException webex)
            {
                MessageBox.Show("L'image n'a pas pu être téléversée: " + webex.Message);
                Debug.WriteLine(webex.Message);
            }
        }
    }

}
