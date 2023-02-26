using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.WebRequestMethods;

namespace CockatriceDMcards
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            string imgpath = projectDirectory + "\\data\\pics\\CUSTOM";
            Console.WriteLine(imgpath);
            string[] noms = Directory.GetFiles(imgpath, "*.JPG");
            XmlDocument cardsXml = new XmlDocument();
            XmlNode docNode = cardsXml.CreateXmlDeclaration("1.0", "UTF-8", null);
            cardsXml.AppendChild(docNode);
            XmlElement cockatrice_carddatabase = cardsXml.CreateElement("cockatrice_carddatabase");
            cockatrice_carddatabase.SetAttribute("version", "3");
            cardsXml.AppendChild(cockatrice_carddatabase);
            try
            {
                int reste = noms.Count();
                XmlElement cards = cardsXml.CreateElement("cards");
                for (int i = 0; i < noms.Length; i++)
                {
                    XmlElement card = cardsXml.CreateElement("card");
                    cards.AppendChild(card);
                    XmlElement name = cardsXml.CreateElement("name");
                    card.AppendChild(name);
                    string nom = Path.GetFileNameWithoutExtension(noms[i]);
                    name.InnerText = nom;
                    XmlElement manacost = cardsXml.CreateElement("manacost");
                    card.AppendChild(manacost);
                    manacost.InnerText = string.Empty;
                    XmlElement set = cardsXml.CreateElement("set");
                    card.AppendChild(set);
                    set.InnerText = string.Empty;
                    XmlElement tablerow = cardsXml.CreateElement("tablerow");
                    card.AppendChild(tablerow);
                    tablerow.InnerText = string.Empty;
                    XmlElement type = cardsXml.CreateElement("type");
                    card.AppendChild(type);
                    type.InnerText = string.Empty;
                    XmlElement color = cardsXml.CreateElement("color");
                    card.AppendChild(color);
                    color.InnerText = string.Empty;
                    cardsXml.DocumentElement.AppendChild(card);
                    cardsXml.DocumentElement.AppendChild(cards).AppendChild(card);
                    Console.WriteLine(nom);
                    reste --;
                    Console.WriteLine(reste);
                }
                cardsXml.Save(projectDirectory + "\\data\\cards.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem");
                throw ex;
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
