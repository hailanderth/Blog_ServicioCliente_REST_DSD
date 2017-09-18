using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioREST;
using System.Web.Script.Serialization;
using System.Text;
using System.Net;
using System.IO;

namespace RESTTest
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void TestRegistrar()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ClienteEntidad cliente = new ClienteEntidad();
            cliente.Nom_Cliente = "Williams";
            cliente.Ape_Cliente = "Morales Caballero";
            cliente.Dir_Cliente = "Av. El Sol S/N";
            cliente.Tel_Cliente = "753123";
            cliente.Edad = 32;
            cliente.Sexo = "M";
            cliente.Email = "williams.morales.caballero@gmail.com";
            string postdata = js.Serialize(cliente);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:12968/ClienteService.svc/Cliente");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            bool estado = false;
            estado = js.Deserialize<bool>(tramaJson);

            Assert.AreEqual(true, estado);

        }

        [TestMethod]
        public void TestModificar()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ClienteEntidad cliente = new ClienteEntidad();
            cliente.Cod_Cliente = 1;
            cliente.Nom_Cliente = "Eduardo";
            cliente.Ape_Cliente = "Cruz Torvisco";
            cliente.Dir_Cliente = "Av. El Cesar Vallejo 753";
            cliente.Tel_Cliente = "8527412";
            cliente.Edad = 28;
            cliente.Sexo = "M";
            cliente.Email = "eduardo@gmail.com";
            string postdata = js.Serialize(cliente);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:12968/ClienteService.svc/Cliente");
            request.Method = "PUT";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            bool estado = false;
            estado = js.Deserialize<bool>(tramaJson);

            Assert.AreEqual(true, estado);
        }

        [TestMethod]
        public void TestEliminar()
        {
            //Url con Codigo de Cliente
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:12968/ClienteService.svc/Cliente/1");
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            bool estado = false;
            JavaScriptSerializer js = new JavaScriptSerializer();
            estado = js.Deserialize<bool>(tramaJson);
            Assert.AreEqual(true, estado);
        }

        [TestMethod]
        public void TestBuscar()
        {
            //Url con Codigo de Cliente
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:12968/ClienteService.svc/Cliente/1");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            ClienteEntidad OClienteEntidad = new ClienteEntidad();
            JavaScriptSerializer js = new JavaScriptSerializer();
            OClienteEntidad = js.Deserialize<ClienteEntidad>(tramaJson);
            Assert.AreEqual(1, OClienteEntidad.Cod_Cliente);
        }

    }
}
