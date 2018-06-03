using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace OperatingSystem
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.LightBlue200, TextShade.BLACK);
        }

        public static bool checkText(string text)
        {
            int i;
            bool x;
            x = int.TryParse(text, out i);
            if (x == true && i >= 0) return true;
            return false;
        }

        public static string parseText(int x)
        {
            if (x == -1) return "";
            return x + "";
        }

        public static string parseText(bool x)
        {
            return x + "";
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (checkText(materialSingleLineTextField1.Text)) materialListView1.Items.Add(materialSingleLineTextField1.Text);
            materialSingleLineTextField1.Focus();
            materialListView1.EnsureVisible(materialListView1.Items.Count - 1);
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            if (checkText(materialSingleLineTextField1.Text)) materialListView1.Items.Insert(materialListView1.Items.IndexOf(materialListView1.SelectedItems[0]), materialSingleLineTextField1.Text);
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < materialListView1.SelectedItems.Count; i++)
                materialListView1.Items.Remove(materialListView1.SelectedItems[i]);
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            materialListView2.Clear();
            materialListView2.Columns.Add("PAGE");
            materialListView2.Columns[0].Width = 80;
            materialListView2.Columns.Add("INT");
            materialListView2.Columns[1].Width = 70;
            materialListView2.Columns.Add("OPAGE");
            materialListView2.Columns[2].Width = 90;
            if (checkText(materialSingleLineTextField2.Text) == false)
            {
                materialLabel1.Text = "ERROR PAGE SIZE";
                return;
            }
            if (materialListView1.Items.Count <= 0)
            {
                materialLabel1.Text = "ERROR PAGE LENGTH";
                return;
            }
            int N = int.Parse(materialSingleLineTextField2.Text);
            int[] P = new int[materialListView1.Items.Count];
            int i,j;
            for (i = 0; i < N; i++)
                materialListView2.Columns.Add(i + 1 + "");
            for (i = 0; i < P.Length; i++)
                P[i] = int.Parse(materialListView1.Items[i].Text);
            PageReplacement pageReplacementFIFO = new PageReplacement(N, P);
            pageReplacementFIFO.pageReplacementFIFO();
            for (i = 0; i < P.Length; i++)
            {
                materialListView2.Items.Add(parseText(pageReplacementFIFO.pages[i]));
                materialListView2.Items[i].SubItems.Add(parseText(pageReplacementFIFO.isInterrupt[i]));
                materialListView2.Items[i].SubItems.Add(parseText(pageReplacementFIFO.outPage[i]));
                for (j = 0; j < N; j++)
                    materialListView2.Items[i].SubItems.Add(parseText(pageReplacementFIFO.pageList[i, j]));
            }
            materialLabel2.Text = $"SUMINT={pageReplacementFIFO.sumInterrupt};PAGENUM={pageReplacementFIFO.pageLength};SUFFIENT={pageReplacementFIFO.percent}";
            materialListView2.EnsureVisible(materialListView2.Items.Count - 1);
        }

        private void materialSingleLineTextField1_Enter(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Text = "";
        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            materialListView2.Clear();
            materialListView2.Columns.Add("PAGE");
            materialListView2.Columns[0].Width = 80;
            materialListView2.Columns.Add("INT");
            materialListView2.Columns[1].Width = 70;
            materialListView2.Columns.Add("OPAGE");
            materialListView2.Columns[2].Width = 90;
            if (checkText(materialSingleLineTextField2.Text) == false)
            {
                materialLabel1.Text = "ERROR PAGE SIZE";
                return;
            }
            if (materialListView1.Items.Count <= 0)
            {
                materialLabel1.Text = "ERROR PAGE LENGTH";
                return;
            }
            int N = int.Parse(materialSingleLineTextField2.Text);
            int[] P = new int[materialListView1.Items.Count];
            int i, j;
            for (i = 0; i < N; i++)
                materialListView2.Columns.Add(i + 1 + "");
            for (i = 0; i < P.Length; i++)
                P[i] = int.Parse(materialListView1.Items[i].Text);
            PageReplacement pageReplacementLRU = new PageReplacement(N, P);
            pageReplacementLRU.pageReplacementLRU();
            for (i = 0; i < P.Length; i++)
            {
                materialListView2.Items.Add(parseText(pageReplacementLRU.pages[i]));
                materialListView2.Items[i].SubItems.Add(parseText(pageReplacementLRU.isInterrupt[i]));
                materialListView2.Items[i].SubItems.Add(parseText(pageReplacementLRU.outPage[i]));
                for (j = 0; j < N; j++)
                    materialListView2.Items[i].SubItems.Add(parseText(pageReplacementLRU.pageList[i, j]));
            }
            materialLabel2.Text = $"SUMINT={pageReplacementLRU.sumInterrupt};PAGENUM={pageReplacementLRU.pageLength};SUFFIENT={pageReplacementLRU.percent}";
            materialListView2.EnsureVisible(materialListView2.Items.Count - 1);

        }

        private void materialFlatButton6_Click(object sender, EventArgs e)
        {
            materialListView2.Clear();
            materialListView2.Columns.Add("PAGE");
            materialListView2.Columns[0].Width = 80;
            materialListView2.Columns.Add("INT");
            materialListView2.Columns[1].Width = 70;
            materialListView2.Columns.Add("OPAGE");
            materialListView2.Columns[2].Width = 90;
            if (checkText(materialSingleLineTextField2.Text) == false)
            {
                materialLabel1.Text = "ERROR PAGE SIZE";
                return;
            }
            if (materialListView1.Items.Count <= 0)
            {
                materialLabel1.Text = "ERROR PAGE LENGTH";
                return;
            }
            int N = int.Parse(materialSingleLineTextField2.Text);
            int[] P = new int[materialListView1.Items.Count];
            int i, j;
            for (i = 0; i < N; i++)
                materialListView2.Columns.Add(i + 1 + "");
            for (i = 0; i < P.Length; i++)
                P[i] = int.Parse(materialListView1.Items[i].Text);
            PageReplacement pageReplacementCLOCK = new PageReplacement(N, P);
            pageReplacementCLOCK.pageReplacementCLOCK();
            for (i = 0; i < P.Length; i++)
            {
                materialListView2.Items.Add(parseText(pageReplacementCLOCK.pages[i]));
                materialListView2.Items[i].SubItems.Add(parseText(pageReplacementCLOCK.isInterrupt[i]));
                materialListView2.Items[i].SubItems.Add(parseText(pageReplacementCLOCK.outPage[i]));
                for (j = 0; j < N; j++)
                    materialListView2.Items[i].SubItems.Add(parseText(pageReplacementCLOCK.pageList[i, j]));
            }
            materialLabel2.Text = $"SUMINT={pageReplacementCLOCK.sumInterrupt};PAGENUM={pageReplacementCLOCK.pageLength};SUFFIENT={pageReplacementCLOCK.percent}";
            materialListView2.EnsureVisible(materialListView2.Items.Count - 1);
        }

        private void materialFlatButton12_Click(object sender, EventArgs e)
        {
            if (checkText(materialSingleLineTextField4.Text)) materialListView4.Items.Add(materialSingleLineTextField4.Text);
            materialSingleLineTextField4.Focus();
            materialListView4.EnsureVisible(materialListView4.Items.Count - 1);
        }

        private void materialFlatButton11_Click(object sender, EventArgs e)
        {
            if (checkText(materialSingleLineTextField4.Text)) materialListView4.Items.Insert(materialListView4.Items.IndexOf(materialListView4.SelectedItems[0]), materialSingleLineTextField4.Text);
        }

        private void materialFlatButton10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < materialListView4.SelectedItems.Count; i++)
                materialListView4.Items.Remove(materialListView4.SelectedItems[i]);
        }

        private void materialSingleLineTextField4_Enter(object sender, EventArgs e)
        {
            materialSingleLineTextField4.Text = "";
        }

        private void materialFlatButton9_Click(object sender, EventArgs e)
        {
            materialListView3.Clear();
            materialListView3.Columns.Add("DISK");
            materialListView3.Columns[0].Width = 85;
            materialListView3.Columns.Add("MOVE");
            materialListView3.Columns[1].Width = 85;
            if (checkText(materialSingleLineTextField3.Text) == false)
            {
                materialLabel3.Text = "ERROR TIME";
                return;
            }
            if (materialListView4.Items.Count <= 0)
            {
                materialLabel3.Text = "ERROR DISK LENGTH";
                return;
            }
            int T = int.Parse(materialSingleLineTextField3.Text);
            int[] D = new int[materialListView4.Items.Count];
            int i, j;
            for (i = 0; i < D.Length; i++)
                D[i] = int.Parse(materialListView4.Items[i].Text);
            DiskManagement diskManagementFIFO = new DiskManagement(D, T);
            diskManagementFIFO.diskManagementFIFO();
            for (i = 0; i < D.Length; i++)
            {
                materialListView3.Items.Add(parseText(diskManagementFIFO.cyVisit[i]));
                materialListView3.Items[i].SubItems.Add(parseText(diskManagementFIFO.moveNum[i]));
            }
            materialLabel4.Text = $"MOVELENGTH={diskManagementFIFO.moveLength};TIME={diskManagementFIFO.time}MS;AVERAGELENGTH={diskManagementFIFO.averageLength}";
        }

        private void materialFlatButton8_Click(object sender, EventArgs e)
        {
            materialListView3.Clear();
            materialListView3.Columns.Add("DISK");
            materialListView3.Columns[0].Width = 85;
            materialListView3.Columns.Add("MOVE");
            materialListView3.Columns[1].Width = 85;
            if (checkText(materialSingleLineTextField3.Text) == false)
            {
                materialLabel3.Text = "ERROR TIME";
                return;
            }
            if (materialListView4.Items.Count <= 0)
            {
                materialLabel3.Text = "ERROR DISK LENGTH";
                return;
            }
            int T = int.Parse(materialSingleLineTextField3.Text);
            int[] D = new int[materialListView4.Items.Count];
            int i, j;
            for (i = 0; i < D.Length; i++)
                D[i] = int.Parse(materialListView4.Items[i].Text);
            DiskManagement diskManagementSSTF = new DiskManagement(D, T);
            diskManagementSSTF.diskManagementSSTF();
            for (i = 0; i < D.Length; i++)
            {
                materialListView3.Items.Add(parseText(diskManagementSSTF.cyVisit[i]));
                materialListView3.Items[i].SubItems.Add(parseText(diskManagementSSTF.moveNum[i]));
            }
            materialLabel4.Text = $"MOVELENGTH={diskManagementSSTF.moveLength};TIME={diskManagementSSTF.time}MS;AVERAGELENGTH={diskManagementSSTF.averageLength}";
        }

        private void materialFlatButton7_Click(object sender, EventArgs e)
        {
            materialListView3.Clear();
            materialListView3.Columns.Add("DISK");
            materialListView3.Columns[0].Width = 85;
            materialListView3.Columns.Add("MOVE");
            materialListView3.Columns[1].Width = 85;
            if (checkText(materialSingleLineTextField3.Text) == false)
            {
                materialLabel3.Text = "ERROR TIME";
                return;
            }
            if (materialListView4.Items.Count <= 0)
            {
                materialLabel3.Text = "ERROR DISK LENGTH";
                return;
            }
            int T = int.Parse(materialSingleLineTextField3.Text);
            int[] D = new int[materialListView4.Items.Count];
            int i, j;
            for (i = 0; i < D.Length; i++)
                D[i] = int.Parse(materialListView4.Items[i].Text);
            DiskManagement diskManagementELEVU = new DiskManagement(D, T);
            diskManagementELEVU.diskManagementELEVU();
            for (i = 0; i < D.Length; i++)
            {
                materialListView3.Items.Add(parseText(diskManagementELEVU.cyVisit[i]));
                materialListView3.Items[i].SubItems.Add(parseText(diskManagementELEVU.moveNum[i]));
            }
            materialLabel4.Text = $"MOVELENGTH={diskManagementELEVU.moveLength};TIME={diskManagementELEVU.time}MS;AVERAGELENGTH={diskManagementELEVU.averageLength}";

        }

        private void materialFlatButton13_Click(object sender, EventArgs e)
        {
            materialListView3.Clear();
            materialListView3.Columns.Add("DISK");
            materialListView3.Columns[0].Width = 85;
            materialListView3.Columns.Add("MOVE");
            materialListView3.Columns[1].Width = 85;
            if (checkText(materialSingleLineTextField3.Text) == false)
            {
                materialLabel3.Text = "ERROR TIME";
                return;
            }
            if (materialListView4.Items.Count <= 0)
            {
                materialLabel3.Text = "ERROR DISK LENGTH";
                return;
            }
            int T = int.Parse(materialSingleLineTextField3.Text);
            int[] D = new int[materialListView4.Items.Count];
            int i, j;
            for (i = 0; i < D.Length; i++)
                D[i] = int.Parse(materialListView4.Items[i].Text);
            DiskManagement diskManagementELEVD = new DiskManagement(D, T);
            diskManagementELEVD.diskManagementELEVD();
            for (i = 0; i < D.Length; i++)
            {
                materialListView3.Items.Add(parseText(diskManagementELEVD.cyVisit[i]));
                materialListView3.Items[i].SubItems.Add(parseText(diskManagementELEVD.moveNum[i]));
            }
            materialLabel4.Text = $"MOVELENGTH={diskManagementELEVD.moveLength};TIME={diskManagementELEVD.time}MS;AVERAGELENGTH={diskManagementELEVD.averageLength}";

        }
    }
}
