using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ClassAct.Website.BL;
using System.Collections;
using System.Threading;

namespace ClassAct.DatabaseAdder
{
    public partial class ExcelSheetSerializer : Form
    {
        int count = 0;
        int resturantCount = 1;
        private string start = @"C:\Users\trega\Desktop\ClassActResturant\Round1\Middle.xlsx";
        private string cats = @"C:\Users\trega\Desktop\ClassActResturant\Round1\Flags.xlsx";
        public static string[,] Data;
        object[,] Resturant;
        object[,] Flags;
        object[,] Features;
        object[,] Cuisines;
        List<object[]> GoodResturants = new List<object[]>();
        object[,] CleanedResturants;
        int MessageSender = 0;
        public ExcelSheetSerializer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewMethod();

        }

        private void NewMethod()
        {
            try
            {
                Flags = CExcel.ImportObjectArray(cats, 1);
                Features = CExcel.ImportObjectArray(cats, 2);
                Cuisines = CExcel.ImportObjectArray(cats, 3);
                Resturant = CExcel.ImportObjectArray(start, 1);
                CleanedResturants = new object[Resturant.GetLength(0) + 1, Resturant.GetLength(1) + 1];
                object[] ResturantArray;
                int flags = 0;
                int cuisines = 0;
                int features = 0;
         
                int skipcount = 0;
                for (int i = 1; i < Resturant.GetLength(0); i++)
                {
                    //  ResturantArray = new object[Resturant.GetLength(0) + 1];
                    MessageSender++;
                    flags = 0;
                    cuisines = 0;
                    features = 0;

                    for (int j = 1; j < Resturant.GetLength(1); j++)
                    {
                        if (Resturant[i, j] != null)
                        {
                            if (Resturant[i, 1].ToString() != "Delete")
                            {
                                foreach (object flag in Flags)
                                {
                                    if (Resturant[i, j].ToString().Trim() == flag.ToString().Trim())
                                    {
                                        flags++;
                                        Resturant[i, 1] = "Delete";
                                        //    MessageBox.Show(cat + " is a flag");
                                        break;
                                    }
                                }
                                if (Resturant[i, 1].ToString() != "Delete")
                                {
                                    foreach (object feature in Features)
                                    {
                                        if (Resturant[i, j].ToString().Trim() == feature.ToString().Trim())
                                        {
                                            features++;
                                            //      MessageBox.Show(cat + " is a feature" + feature);
                                            break;
                                        }
                                    }
                                    if (Resturant[i, 1].ToString() != "Delete")
                                    {
                                        foreach (object cuisine in Cuisines)
                                        {
                                            if (Resturant[i, j].ToString().Trim() == cuisine.ToString().Trim())
                                            {
                                                cuisines++;
                                                //        MessageBox.Show(cat + " is a cuisine" + cuisine);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //   MessageBox.Show(Resturant[1, 4].ToString());
                    }
                    //MessageBox.Show(Resturant[i, 1].ToString() + " has " + flags.ToString() + " flags " + 
                    //    (cuisines + features).ToString() + "Feautes//Cuisines" );
                    /*
                    if (flags < 22)
                    {
                        for (int j = 1; j < Resturant.GetLength(1); j++)
                        {
                            CleanedResturants[resturantCount, j] = Resturant[i, j];

                        }
                     //   resturantCount++;
                    }
                    else
                    {
                        skipcount++;
                        Resturant[i, 1] = "Delete";
                 //       MessageBox.Show("Skipped " + Resturant[i, 1] + "Total skipped is " + skipcount.ToString());
                    } */
                    if (flags == 0 && (cuisines + features) > 0)
                    {
                        resturantCount++;

                    }
                    if (MessageSender % 2000 == 0)
                    {
                        MessageBox.Show("You are a nice person " + MessageSender.ToString());
                    }
                }
            }



            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Finish");
        }

        int x = 0;


   
        private void btnClean_Click(object sender, EventArgs e)
        {
         int columns =   CleanedResturants.GetUpperBound(0);
            int Rows = CleanedResturants.GetUpperBound(1);
            int resCol = Resturant.GetUpperBound(0);
            int resRow = Resturant.GetUpperBound(1);
            int cleanedRow = GoodResturants.Count;
            MessageBox.Show(columns.ToString() + " by " + Rows.ToString() +" vs "
                + resCol.ToString()+ " by " +resRow.ToString() + " vs " + columns.ToString() +" by "
                + cleanedRow.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            for (int i = 1; i < Resturant.GetLength(0); i++)
            {
                if(Resturant[i,1].ToString().Trim() != "Delete")
                {
                    try
                    {

                    
                        resturantCount--;
                        string name = Resturant[i,1].ToString();
                        double.TryParse(Resturant[i,2].ToString(), out double Lat);
                        double.TryParse(Resturant[i,3].ToString(), out double lon);
                        string website = Resturant[i,4].ToString();

                        List<string> FeatureList = new List<string>();
                        List<string> CuisineList = new List<string>();

                    for(int k =1; k<Resturant.GetLength(1);k++)
                    {
                        if(Resturant[i,k] == null)
                        {

                        }
                    }
                        for (int j = 5; j< 26; j++)
                        {
                            if (Resturant[i,j] != null)
                            {
                                foreach (var feature in Features)
                                {
                                    if (feature.ToString().Trim() == Resturant[i,j].ToString().Trim())
                                    {
                                        FeatureList.Add(feature.ToString().Trim());
                                    }
                                }
                                foreach (var cuisine in Cuisines)
                                {
                                    if (cuisine.ToString().Trim() == Resturant[i,j].ToString().Trim())
                                    {
                                        CuisineList.Add(cuisine.ToString().Trim());
                                    }
                                }
                            }
                        }
                        string city = Resturant[i,27].ToString();
                        string phoneNumber = Resturant[i,28].ToString();
                        string state = "WI";
                        string Hours = Resturant[i,31].ToString();

                        string addressNumber = Resturant[i,32].ToString();
                        string AddressRoute = Resturant[i,33].ToString();
                        string AddressPost = Resturant[i,34].ToString();
                        string addressPostStuff = Resturant[i,35].ToString();
                        string POBOX = Resturant[i,36].ToString();
                        //      string subPremise = rest[37].ToString();

                        CResturant oREsturant = new CResturant();
                        CAddress oAddress = new CAddress();
                        oAddress.AddressID = Guid.NewGuid();
                        oREsturant.ResturantID = Guid.NewGuid();
                        oREsturant.ResturantName = name;
                        oAddress.ZipCode = AddressPost;
                        oAddress.StreetAddress = addressNumber + " " + AddressRoute;
                        oAddress.Latitude = Lat;
                        oAddress.Longitude = lon;
                        oAddress.State = state;
                        oAddress.City = city;
                        oREsturant.Address = oAddress;
                        oREsturant.hours = Hours;
                        oREsturant.webaddress = website;
                        oREsturant.phone = phoneNumber;
                        oREsturant.CusinesServed = new CCuisineList();
                        oREsturant.FeatureRatings = new CFeatureList();

                        try
                        {
                            oREsturant.AddResturanttoDB();
                            foreach (string cuisine in CuisineList)
                            {
                                oREsturant.AddCuisineToResturantCuisineTableByName(cuisine);
                            }
                            foreach (string feature in FeatureList)
                            {
                                  oREsturant.AddFeatureToResturantByName(feature);
                            }

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                        
                        if (resturantCount % 23 == 0)
                        {
                            if (resturantCount % 19 == 0)
                            {
                                if (resturantCount % 17 == 0)
                                {
                                    if (resturantCount % 13 == 0)
                                    {
                                        if (resturantCount % 11 == 0)
                                        {
                                            if(resturantCount % 7 ==0)
                                            {
                                                if(resturantCount % 5 ==0)
                                                {
                                                    if (resturantCount % 3 == 0)
                                                    {
                                                        if (resturantCount % 2 == 0)
                                                        {
                                                            MessageBox.Show(resturantCount.ToString());
                                                            label1.Text = resturantCount.ToString();
                                                        }
                                                    }
                                                }
                                            }
                               
                                        }
                                    }
                                }

                            }
                         
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
                   
            foreach (var rest in Resturant)
            {
                
            }
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            Features = CExcel.ImportObjectArray(cats, 2);
            CFeature oFeature;
            foreach (var feature in Features)
            {
                try
                {
                    if (feature != null)
                    {
                        if (feature.ToString() != "")
                        {
                            feature.ToString().Trim();
                            oFeature = new CFeature();
                            oFeature.FeatureDescription = feature.ToString().Trim();
                            oFeature.AddFeatureToDB();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
              
            }
        }

        private void btnAddFeaturesToResturants_Click(object sender, EventArgs e)
        {
            try
            {
                Resturant = CExcel.ImportObjectArray(start, 1);
                MessageBox.Show("Imported Resturant Sheet");
                CResturantList resturants = new CResturantList();
                resturants.Load();
                CFeatureList featureList = new CFeatureList();
                featureList.LoadAllFeatures();
                int remaining = resturants.Count;
                foreach (CResturant res in resturants)
                {
                    remaining--;

                    for (int i = 1; i < Resturant.GetLength(0); i++)
                    {
                        if (res.phone == Resturant[i, 28].ToString())
                        {
                            for (int j = 5; j < 25; j++)
                            {
                                foreach (CFeature feat in featureList)
                                {
                                    if (Resturant[i, j] != null)
                                    {
                                        if (Resturant[i, j].ToString() == feat.FeatureDescription)
                                        {
                                            try
                                            {
                                                res.AddFeatureToResturantNoCheck(feat);
                                                //    res.AddFeatureToResturant(feat);
                                            }
                                            catch (Exception)
                                            {

                                              
                                            }
                                       
                                        }
                                    }
                                }
                               
                            }
                            break;
                            }
                     
                        
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
            MessageBox.Show("Finished");
            }
        }
    }