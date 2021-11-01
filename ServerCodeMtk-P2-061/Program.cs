using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceMtk_P1_061;
using System.ServiceModel.Description;
using System.ServiceModel.Channels; //mex

//Nama  : Bagus Rinu Pangayom
//NIM   : 20190140061
//Kelas : C

namespace ServerCodeMtk_P2_061
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:8888/Matematika");
            BasicHttpBinding bind = new BasicHttpBinding();

            try
            {
                hostObj = new ServiceHost(typeof(Matematika), address);
                //Alamat Base Address
                hostObj.AddServiceEndpoint(typeof(IMatematika), bind, "");
                //Alamat Endpoint

                //WSDL
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior(); //Service Runtime Player
                smb.HttpGetEnabled = true; //untuk mengaktifkan wsdl(dibuka saat development, tidak untuk dibuka)
                hostObj.Description.Behaviors.Add(smb);

                //mex
                Binding mexbind = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange), mexbind, "mex");
                hostObj.Open();
                Console.WriteLine("Server is ready!!!!");
                Console.ReadLine();
                hostObj.Close();
            }
            catch (Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
