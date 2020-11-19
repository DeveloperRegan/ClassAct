using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassAct.Website.BL;


namespace ClassAct.DatabaseAdder
{
    public partial class Form1 : Form
    {
      public  CFeatureList fList;
      public CPersonList Plist;
       public CResturantList list;
      public  CCuisineList cList;
        public Form1()
        {
            InitializeComponent();

            AdderTable.Add("Resturants");
            AdderTable.Add("People");
            TopicTable.Add("Cuisines");
            TopicTable.Add("Features");

            comboBox1.Items.AddRange(AdderTable.ToArray());
            comboBox2.Items.AddRange(TopicTable.ToArray());
        }

        private List<String> AdderTable = new List<string>();
        private List<String> TopicTable = new List<string>();
           

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedText != null && comboBox2.SelectedText!=null)
            {
                if (true)
                {
                    LoadListBoxes(listBox1, comboBox1.Text);
                    LoadListBoxes(listBox2, comboBox2.Text);




                }

            }
        }

        private void LoadListBoxes(ListBox lbo, String List)
        {
            switch (List)
            {
                case "Resturants":
                    list = new CResturantList();
                   list.Load();
                    lbo.Items.Clear();
                    
                    foreach (CResturant rest in list)
                    {
                        lbo.Items.Add(rest.ResturantName);
                    }
                break;

                case "People":
                  Plist = new CPersonList();
                    Plist.Load();
                    lbo.Items.Clear();

                    foreach (CPerson rest in Plist)
                    {
                        lbo.Items.Add(rest.FullName);
                    }

                    break;

                case "Cuisines":
                     cList = new CCuisineList();
                    cList.load();
                    lbo.Items.Clear();

                    foreach (CCuisine rest in cList)
                    {
                        lbo.Items.Add(rest.Description);
                    }
                    break;
                case "Features":
                    CFeatureList fList = new CFeatureList();
                    fList.LoadAllFeatures();

                    lbo.Items.Clear();

                    foreach (CFeature rest in fList)
                    {
                        lbo.Items.Add(rest.FeatureDescription);
                    }

                    break;
                

                default:
                    break;
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var listBox1Indexes = listBox1.SelectedIndices;
            var listbox2Indexes = listBox2.SelectedIndices;

            if (comboBox1.Text== "Resturants")
            {
                if(comboBox2.Text == "Cuisines")
                {
                  

                    for(int i=0; i<listBox1Indexes.Count; i++)
                    {
                        for (int j = 0; j < listbox2Indexes.Count; j++)
                        { 
                            CCuisine cCuisine = cList[listbox2Indexes[j]];
                            list[listBox1Indexes[i]].CusinesServed = new CCuisineList();
                            list[listBox1Indexes[i]].CusinesServed.Add(cCuisine);
                            list[listBox1Indexes[i]].AddCuisineToResturantCuisineTable(cCuisine);
                        }
                    }
                if(comboBox2.Text== "Features")
                    {
                        for (int i = 0; i < listBox1Indexes.Count; i++)
                        {
                            for (int j = 0; j < listbox2Indexes.Count; j++)
                            {
                                CFeature cFeature = fList[listbox2Indexes[j]];
                                list[listBox1Indexes[i]].FeatureRatings = new CFeatureList();
                                list[listBox1Indexes[i]].FeatureRatings.Add(cFeature);
                                //Add a SP to add Feature to Resturant Feature Table
                                list[listBox1Indexes[i]].AddFeatureToResturant(cFeature);
                            }
                        }
                    }      
                }
            }
            if(comboBox1.Text == "People")
            {
                if (comboBox2.Text == "Cuisines")
                {


                    for (int i = 0; i < listBox1Indexes.Count; i++)
                    {
                        for (int j = 0; j < listbox2Indexes.Count; j++)
                        {
                            try
                            {
                                CCuisine cCuisine = cList[listbox2Indexes[j]];
                                Plist[listBox1Indexes[i]].cuisines = new CCuisineList();
                                Plist[listBox1Indexes[i]].cuisines.Add(cCuisine);
                                Plist[listBox1Indexes[i]].AddCuisineToUser(cCuisine);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                
                            }
                  
                        }
                    }
                    if (comboBox2.Text == "Features")
                    {
                        for (int i = 0; i < listBox1Indexes.Count; i++)
                        {
                            for (int j = 0; j < listbox2Indexes.Count; j++)
                            {
                                CFeature cFeature = fList[listbox2Indexes[j]];
                                list[listBox1Indexes[i]].FeatureRatings = new CFeatureList();
                                list[listBox1Indexes[i]].FeatureRatings.Add(cFeature);
                                //Add a SP to add Feature to Resturant Feature Table
                                list[listBox1Indexes[i]].AddFeatureToResturant(cFeature);
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Updated the Values");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
