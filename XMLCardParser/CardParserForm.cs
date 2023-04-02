using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace XMLCardParser
{
    public partial class XMLCardParserForm : Form
    {
        public XMLCardParserForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lptToolStripStatusLabel.Text = "Waiting...";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CultureInfo ciEnUs = new CultureInfo("en-us");

                XmlDocument docXML = new XmlDocument();
                docXML.Load(openFileDialog1.FileName);

                string forestry = docXML.GetElementsByTagName("_forestry")[0].InnerText;
                lptForestryBox.Text = forestry;

                string forestryArea = docXML.GetElementsByTagName("_forestryArea")[0].InnerText;
                lptForestryAreaBox.Text = forestryArea;

                string subForestry = docXML.GetElementsByTagName("_subForestry")[0].InnerText;
                lptSubForestryBox.Text = subForestry;

                string kvartal = docXML.GetElementsByTagName("_kvartal")[0].InnerText;
                lptKvartalBox.Text = kvartal;

                string patch = docXML.GetElementsByTagName("_patch")[0].InnerText;
                lptPatchBox.Text = patch;

                string forestPatologySection = docXML.GetElementsByTagName("_forestPatologySection")[0].InnerText;
                lptForestPatologySectionBox.Text = forestPatologySection;

                string pathArea = docXML.GetElementsByTagName("_path_area")[0].InnerText;
                lptPathAreaBox.Text = pathArea;

                string forestPatologySectionArea = docXML.GetElementsByTagName("_forestPatologySectionS")[0].InnerText;
                lptForestPatologySectionAreaBox.Text = forestPatologySectionArea;

                string latitude = docXML.GetElementsByTagName("_lat")[0].InnerText;
                lptLatitudeBox.Text = latitude;

                string longitude = docXML.GetElementsByTagName("_lon")[0].InnerText;
                lptLongitudeBox.Text = longitude;

                string altitude = docXML.GetElementsByTagName("_altitude")[0].InnerText;
                double doubleAltitude = Double.Parse(altitude, ciEnUs);
                lptAltitudeBox.Text = doubleAltitude.ToString("#.#").Replace(',', '.');

                string age = docXML.GetElementsByTagName("_age")[0].InnerText;
                lptAgeBox.Text = age;

                string density = docXML.GetElementsByTagName("_density")[0].InnerText;
                lptDensityBox.Text = density;

                string bonitet = docXML.GetElementsByTagName("_bonitet")[0].InnerText;
                lptBonitetBox.Text = bonitet;

                string forestType = docXML.GetElementsByTagName("_forest_type")[0].InnerText;
                lptForestTypeBox.Text = forestType;

                string stock = docXML.GetElementsByTagName("_stock")[0].InnerText;
                lptStockBox.Text = stock;

                string forestPurpose = docXML.GetElementsByTagName("_forestPurpose")[0].InnerText;
                lptForestPurposeBox.Text = forestPurpose;

                string landuse = docXML.GetElementsByTagName("_landuse")[0].InnerText;
                int cmpLanduse = String.Compare(landuse, "0");
                landuse = (cmpLanduse == 0) ? "нет" : landuse;
                lptLanduseBox.Text = landuse;

                string compliance = docXML.GetElementsByTagName("_mismatch")[0].InnerText;
                int cmpCompliance = String.Compare(compliance, "false");
                compliance = (cmpCompliance == 0) ? "да" : "нет";
                lptComplianceBox.Text = compliance;

                string mainDamage = docXML.GetElementsByTagName("_mainDamages")[0].InnerText;
                lptMainDamageBox.Text = mainDamage;

                string pest = docXML.GetElementsByTagName("_focusRate")[0].InnerText;
                int cmpPest = String.Compare(pest, "0");
                pest = (cmpPest == 0) ? "очаги отсутствуют" : pest;
                lptPestBox.Text = pest;

                string worker = docXML.GetElementsByTagName("_worker")[0].InnerText;
                lptWorkerBox.Text = worker;

                string description = docXML.GetElementsByTagName("_description")[0].InnerText;
                lptDescriptionBox.Text = description;

                string lptDate = docXML.GetElementsByTagName("_lpt_date")[0].InnerText;
                int lptDateYear = Convert.ToInt32(lptDate.Substring(0, 4));
                int lptDateMonth = Convert.ToInt32(lptDate.Substring(5, 2));
                int lptDateDay = Convert.ToInt32(lptDate.Substring(8, 2));
                lptDatePicker.Value = new DateTime(lptDateYear, lptDateMonth, lptDateDay);

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("Доля", typeof(string));
                dt1.Columns.Add("Порода", typeof(string));
                dt1.Columns.Add("Высота", typeof(string));
                dt1.Columns.Add("Возраст", typeof(string));


                XmlNodeList nodeList1 = docXML.SelectNodes("/LPT/_taxation/_taxTrees/TaxTree");
                foreach (XmlNode node in nodeList1)
                {
                    DataRow dtrow = dt1.NewRow();
                    dtrow["Доля"] = node["_coef"].InnerText;
                    dtrow["Порода"] = node["_species"].InnerText;
                    dtrow["Высота"] = node["_h"].InnerText;
                    dtrow["Возраст"] = node["_age"].InnerText;

                    dt1.Rows.Add(dtrow);
                }

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("Мероприятие", typeof(string));
                dt2.Columns.Add("Площадь", typeof(string));
                dt2.Columns.Add("Интенсивность", typeof(string));
                dt2.Columns.Add("Запас", typeof(string));
                XmlNodeList nodeList2 = docXML.SelectNodes("/LPT/_curSanAction");
                foreach (XmlNode node in nodeList2)
                {
                    DataRow dtrow = dt2.NewRow();
                    dtrow["Мероприятие"] = node["_actions"].InnerText;
                    dtrow["Площадь"] = node["_s"].InnerText;
                    dtrow["Интенсивность"] = node["_intensity"].InnerText;
                    dtrow["Запас"] = node["_stock"].InnerText;
                    dt2.Rows.Add(dtrow);
                }

                DataTable dt3 = dt1.Clone();  
                foreach (DataColumn col in dt2.Columns)
                {
                    string newColumnName = col.ColumnName;
                    dt3.Columns.Add(newColumnName, col.DataType);
                }

                IEnumerable<object[]> crossJoin =
                    from r1 in dt1.AsEnumerable()
                    from r2 in dt2.AsEnumerable()
                    select r1.ItemArray.Concat(r2.ItemArray).ToArray();

                foreach (object[] allFields in crossJoin)
                {
                    dt3.Rows.Add(allFields);
                }

                lptDataGridView.DataSource = dt3;


                lptToolStripStatusLabel.Text = "Done";
            }
            else lptToolStripStatusLabel.Text = "Cancelled";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About newAbout = new About();
            newAbout.Show();
        }
    }
}


