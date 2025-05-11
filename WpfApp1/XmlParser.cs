using System.Data;
using System.Xml.Linq;

namespace WpfApp1
{
    class XmlParser
    {
        public static DataView ?GetXmlData(string path, DateTime ?startDate, DateTime ?endDate)
        {
            XElement db = XElement.Load(path);
            List<string> usedNames = [];

            if (db.HasElements && startDate.HasValue && endDate.HasValue)
            {
                List<CarSales> carSales = [];
                DataTable dataTable = new();
                
                string[] columns = ["Název modelu\nCena bez DPH", "Cena s DPH"];
                foreach (var col in columns)
                {
                    dataTable.Columns.Add(col, typeof(string));
                }

                foreach (var car in db.Elements())
                {
                    string name = car.Element("name").Value;
                    string dph = car.Element("dph").Value;
                    string price = car.Element("price").Value;
                    DateTime date = DateTime.Parse(car.Element("date").Value);

                    if (!usedNames.Contains(name))
                    {
                        CarSales newCarSale = new(name);
                        if (date >= startDate && date <= endDate)
                        {
                            newCarSale.AddSale(dph, price);
                        }
                        carSales.Add(newCarSale);
                        usedNames.Add(name);
                    }
                    else
                    {
                        if (date >= startDate && date <= endDate)
                        {
                            carSales.Find(sale => sale.GetName() == name)?.AddSale(dph, price);
                        }
                    }
                }
                foreach (var sale in carSales)
                {
                    dataTable.Rows.Add(sale.GetName() + "\n" + sale.GetSalesNonDPH(), "\n" + sale.GetSalesDPH());
                }

                return dataTable.DefaultView;
            }
            else
            {
                return null;
            }
        }

    }
}
