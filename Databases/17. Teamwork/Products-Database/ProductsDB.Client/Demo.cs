using System;
using System.Collections.Generic;
using System.Linq;
using ProductsDBMySQL.Data;
using System.Data.OleDb;
using Ionic.Zip;
using System.IO;
using System.IO.Compression;
using System.Data;
using ProductsDB.Model;
using ProductsDB.Client;
using ProductsDB.Data;
using System.Data.Entity;
using ProductsDB.Data.Migrations;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MongoDB.Driver;
using System.Web.Script.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ProductsDB.Client
{
    public class Demo
    {
        private static void UnzipFile(string zipPath, string unzipDirectory)
        {
            System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, unzipDirectory);
        }

        private static void FindExcelFiles(string directoryPath, List<SalesReport> reports)
        {
            var excelFiles = Directory.EnumerateFiles(directoryPath, "*.xls");
            string dateStr = directoryPath.Split('\\')[4];
            DateTime date = new DateTime();
            DateTime.TryParse(dateStr, out date);
            
            foreach (var file in excelFiles)
            {
                ReadExcelsFromDirectory(file, reports, date);
            }

            var directories = Directory.EnumerateDirectories(directoryPath);
            foreach (var directory in directories)
            {
                try
                {
                    FindExcelFiles(directory, reports);
                    Directory.Delete(directory, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ReadExcelsFromDirectory(string filePath, List<SalesReport> reports, DateTime date)
        {
            DataTable dt = new DataTable("newtable");
            using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;"))
            {
                connection.Open();
                string selectSql = @"SELECT * FROM [Sales$]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    adapter.FillSchema(dt, SchemaType.Source);
                    adapter.Fill(dt);
                }

                connection.Close();
            }

            for (int i = 2; i < dt.Rows.Count - 2; i++)
            {
                SalesReport report = new SalesReport()
                {
                    Date = date,
                    Location = dt.Rows[0][0].ToString(),
                    ProductId = int.Parse(dt.Rows[i][0].ToString()),
                    Quantity = int.Parse(dt.Rows[i][1].ToString()),
                    UnitPrice = decimal.Parse(dt.Rows[i][2].ToString())
                };

                reports.Add(report);
            }
        }

        private static List<SalesReport> ProcessSalesReports()
        {
            List<SalesReport> reports = new List<SalesReport>();
            UnzipFile(@"..\..\Data\Sample-Sales-Reports.zip", @"..\..\Data\ExtractedFiles\");
            FindExcelFiles(@"..\..\Data\ExtractedFiles\", reports);
            return reports;
        }

        private static void LoadSalesReports()
        {
            List<SalesReport> salesReports = ProcessSalesReports();
            using (ProductsDBContext sqlContext = new ProductsDBContext())
            {
                foreach (var salesReport in salesReports)
                {
                    sqlContext.SalesReports.Add(salesReport);
                }

                sqlContext.SaveChanges();
            }
        }

        private static void LoadMySQLEntries()
        {
            using (ProductsDBContext sqlContext = new ProductsDBContext())
            {
                ProductsDBModel mySQLContext = new ProductsDBModel(@"Server=localhost;Database=products_db;Uid=Rami;Pwd=killer91;");
                foreach (var measure in mySQLContext.Measures)
                {
                    ProductsDB.Model.Measure newMeasure = new Model.Measure()
                    {
                        MeasureId = measure.Measure_ID,
                        MeasureName = measure.Measure_Name
                    };

                    sqlContext.Measures.Add(newMeasure);
                }

                sqlContext.SaveChanges();

                foreach (var vendor in mySQLContext.Vendors)
                {
                    ProductsDB.Model.Vendor newVendor = new Model.Vendor()
                    {
                        VendorId = vendor.Vendor_ID,
                        VendorName = vendor.Vendor_Name
                    };

                    sqlContext.Vendors.Add(newVendor);
                }

                sqlContext.SaveChanges();

                foreach (var prod in mySQLContext.Products)
                {
                    ProductsDB.Model.Vendor vendor = sqlContext.Vendors.Where
                        (v => v.VendorId == prod.Vendors_Vendor_ID).First();
                    ProductsDB.Model.Measure measure = sqlContext.Measures.Where
                        (m => m.MeasureId == prod.Measures_Measure_ID).First();
                    ProductsDB.Model.Product newProd = new Model.Product()
                    {
                        ProductId = prod.Products_ID,
                        ProductName = prod.Product_Name,
                        VendorId = prod.Vendors_Vendor_ID,
                        Vendor = vendor,
                        MeasureId = prod.Measures_Measure_ID,
                        Measure = measure,
                        BasePrice = prod.BasePrice,
                    };

                    sqlContext.Products.Add(newProd);
                }

                sqlContext.SaveChanges();
            }
        }

        private static void GenerateAggregatedXMLSalesReport()
        {
            ProductsDBContext sqlContext = new ProductsDBContext();
            XElement xmlDocument = new XElement("sales");
            var vendors = sqlContext.Vendors.ToList();

            foreach (var vendor in vendors)
            {
                XElement vendorName = new XElement("sale", new XAttribute("vendor", vendor.VendorName));

                var salesReports = sqlContext.SalesReports.Where(salesReport => salesReport.Product.Vendor.VendorId == vendor.VendorId)
                    .OrderBy(salesReport => salesReport.Date).ToList();

                DateTime previousDate = new DateTime();
                decimal expenses = 0;

                foreach (var salesReport in salesReports)
                {
                    DateTime currentDate = salesReport.Date;
                    if (currentDate != previousDate)
                    {
                        if (previousDate != new DateTime())
                        {
                            XElement xmlElement = new XElement("summary",
                                new XAttribute("date", string.Format("{0:dd-MMM-yyyy}", currentDate)),
                                new XAttribute("total-sum", expenses)
                                );

                            vendorName.Add(xmlElement);

                            expenses = 0;
                        }

                        previousDate = currentDate;
                    }

                    expenses += salesReport.Quantity * salesReport.UnitPrice;
                }

                xmlDocument.Add(vendorName);
            }

            xmlDocument.Save(@"..\..\Data\Aggregated-SalesReport-ByDates.xml");
        }

        private static void GeneratePDFReports()
        {
            ProductsDBContext sqlContext = new ProductsDBContext();
            string path = @"..\..\Data" + @"\SalesReports.pdf";
            Document document = new Document();
            FileStream fileStream = File.Create(path);
            PdfWriter.GetInstance(document, fileStream);
            document.Open();
            PdfPTable mainTable = new PdfPTable(10);
            DateTime currentDate = new DateTime();
            decimal currentTotalSum = 0;
            bool isFirst = true;

            var sortedSalesReports = (from salesReport in sqlContext.SalesReports
                                      orderby salesReport.Date
                                      select salesReport).ToList();

            foreach (var salesReport in sortedSalesReports)
            {
                if (currentDate != salesReport.Date)
                {
                    if (!isFirst)
                    {
                        var totalSumCell = new PdfPCell(new Phrase("Total Sum : " + currentTotalSum.ToString()));
                        totalSumCell.BackgroundColor = BaseColor.GREEN;
                        totalSumCell.Colspan = 10;
                        totalSumCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        mainTable.AddCell(totalSumCell);
                        currentTotalSum = 0;
                    }

                    isFirst = false;
                    currentDate = salesReport.Date;
                    var dateCell = new PdfPCell(new Phrase(string.Format("Date: {0:dd-MMM-yyyy} ", currentDate)));
                    dateCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    dateCell.Colspan = 10;
                    dateCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    mainTable.AddCell(dateCell);

                    var productCell = new PdfPCell(new Phrase("Product"));
                    productCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    productCell.Colspan = 2;
                    productCell.HorizontalAlignment = 1;
                    mainTable.AddCell(productCell);

                    var quantityCell = new PdfPCell(new Phrase("Quantity"));
                    quantityCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    quantityCell.Colspan = 2;
                    quantityCell.HorizontalAlignment = 1;
                    mainTable.AddCell(quantityCell);

                    var unitPriceCell = new PdfPCell(new Phrase("UnitPrice"));
                    unitPriceCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    unitPriceCell.Colspan = 2;
                    unitPriceCell.HorizontalAlignment = 1;
                    mainTable.AddCell(unitPriceCell);

                    var locationCell = new PdfPCell(new Phrase("Location"));
                    locationCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    locationCell.Colspan = 3;
                    locationCell.HorizontalAlignment = 1;
                    mainTable.AddCell(locationCell);

                    var sumCell = new PdfPCell(new Phrase("Sum"));
                    sumCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    sumCell.Colspan = 1;
                    sumCell.HorizontalAlignment = 1;
                    mainTable.AddCell(sumCell);
                }
                else
                {
                    var productName = new PdfPCell(new Phrase(salesReport.Product.ProductName));
                    productName.Colspan = 2;
                    productName.HorizontalAlignment = 1;
                    mainTable.AddCell(productName);

                    var quantity = new PdfPCell(new Phrase(salesReport.Quantity + " " + salesReport.Product.Measure.MeasureName));
                    quantity.Colspan = 2;
                    quantity.HorizontalAlignment = 1;
                    mainTable.AddCell(quantity);

                    var unitPrice = new PdfPCell(new Phrase(salesReport.UnitPrice.ToString()));
                    unitPrice.Colspan = 2;
                    unitPrice.HorizontalAlignment = 1;
                    mainTable.AddCell(unitPrice);

                    var supermarketName = new PdfPCell(new Phrase(salesReport.Location.ToString()));
                    supermarketName.Colspan = 3;
                    supermarketName.HorizontalAlignment = 1;
                    mainTable.AddCell(supermarketName);

                    var sum = new PdfPCell(new Phrase((salesReport.Quantity * salesReport.UnitPrice).ToString()));
                    sum.Colspan = 1;
                    sum.HorizontalAlignment = 1;
                    mainTable.AddCell(sum);

                    currentTotalSum += salesReport.Quantity * salesReport.UnitPrice;
                }
            }

            var totalSumCellF = new PdfPCell(new Phrase("Total Sum : " + currentTotalSum.ToString()));
            totalSumCellF.BackgroundColor = BaseColor.GREEN;
            totalSumCellF.Colspan = 10;
            totalSumCellF.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            mainTable.AddCell(totalSumCellF);
            currentTotalSum = 0;

            mainTable.WidthPercentage = 100;
            document.Add(mainTable);
            document.Close();
        }

        private static void GenerateJSONReports()
        {
            using (ProductsDBContext sqlContext = new ProductsDBContext())
            {
                string cString = "mongodb://localhost/";
                MongoClient client = new MongoClient(cString);
                MongoServer server = client.GetServer();
                var productsDB = server.GetDatabase("ProductsDB");

                MongoCollection<JSONReport> reportsMongo = productsDB.GetCollection<JSONReport>("JSONReports");
                var products = sqlContext.Products.ToList();
                foreach (var prod in products)
                {
                    JSONReport report = new JSONReport()
                    {
                        ProductId = prod.ProductId,
                        ProductName = prod.ProductName,
                        VendorName = prod.Vendor.VendorName,
                    };

                    foreach (var salesReport in sqlContext.SalesReports)
                    {
                        if (salesReport.ProductId == prod.ProductId)
                        {
                            report.TotalQuantitySold += salesReport.Quantity;
                            report.TotalIncome += report.TotalQuantitySold * salesReport.UnitPrice;
                        }
                    }

                    reportsMongo.Insert(report);
                }
            }
        }

        private static void SaveJSONReports()
        {
            List<JSONReport> JSONReports  = new List<JSONReport>();
            using (ProductsDBContext sqlContext = new ProductsDBContext())
            {
                var products = sqlContext.Products.ToList();
                foreach (var prod in products)
                {
                    JSONReport report = new JSONReport()
                    {
                        ProductId = prod.ProductId,
                        ProductName = prod.ProductName,
                        VendorName = prod.Vendor.VendorName,
                    };

                    foreach (var salesReport in sqlContext.SalesReports)
                    {
                        if (salesReport.ProductId == prod.ProductId)
                        {
                            report.TotalQuantitySold += salesReport.Quantity;
                            report.TotalIncome += report.TotalQuantitySold * salesReport.UnitPrice;
                        }
                    }

                    JSONReports.Add(report);
                }
            }

            StreamWriter writer = new StreamWriter(@"..\..\Data\JSONReports.json");
            StringBuilder sb = new StringBuilder();

            foreach (var report in JSONReports)
            {
                var json = new JavaScriptSerializer().Serialize(report);
                sb.AppendLine(json);
            }
            using (writer)
            {
                writer.Write(sb.ToString());
            }
        }

        private static void UpdateDataBasesFromXML()
        {
            ProductsDBContext sqlContext = new ProductsDBContext();
            MongoClient client = new MongoClient("mongodb://localhost/");
            MongoServer server = client.GetServer();
            var productsDB = server.GetDatabase("ProductsDB");
            MongoCollection<Expense> expensesMongo = productsDB.GetCollection<Expense>("Expenses");

            using (XmlReader reader = XmlReader.Create(@"..\..\Data\VendorExpenses.xml"))
            {
                DateTime month = new DateTime();
                decimal amount = 0;
                string vendorName = string.Empty;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "sale")
                        {
                            vendorName = reader.GetAttribute("vendor");
                        }
                        else if (reader.Name == "expenses")
                        {
                            month = DateTime.Parse(string.Format("{0:MMM-YYYY}", reader.GetAttribute("month")));
                        }

                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        amount = decimal.Parse(reader.Value);
                        ProductsDB.Model.Vendor vendor = sqlContext.Vendors.Where(v => v.VendorName == vendorName)
                            .FirstOrDefault();
                        Expense expenseSQL = new Expense()
                        {
                            Amount = amount,
                            Vendor = vendor,
                            Date = month
                        };

                        Expense expenseMongo = new Expense()
                        {
                            Amount = amount,
                            VendorId = vendor.VendorId,
                            Date = month
                        };

                        sqlContext.Expenses.Add(expenseSQL);
                        expensesMongo.Insert(expenseMongo);
                    }
                }
            }

            sqlContext.SaveChanges();
        }

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
            <ProductsDBContext, Configuration>());
            LoadMySQLEntries();
            LoadSalesReports();
            GeneratePDFReports();
            GenerateJSONReports();
            SaveJSONReports();
            UpdateDataBasesFromXML();
        }
    }
}
