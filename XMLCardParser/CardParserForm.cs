using System;
using System.Globalization;
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


                lptToolStripStatusLabel.Text = "Done";
            }
            else lptToolStripStatusLabel.Text = "Cancelled";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
