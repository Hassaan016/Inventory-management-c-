﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory_Management
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_new_user au = new add_new_user();
            au.Show();
        }

        private void addNewUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unit objUnit = new unit();

            objUnit.Show();
        }

        private void addProductNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_product_name objProductName = new add_product_name();
            objProductName.Show();
        }

        private void dealerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dealer_info objDealerInfo = new dealer_info();
            objDealerInfo.Show();
        }

        private void purchaseProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchase_master objPurchaseMaster = new purchase_master();
            objPurchaseMaster.Show();
        }

        private void makeSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sales objSales = new sales();
            objSales.Show();
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchaseReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //             genereate_purchase_report objGeneratePurchaseReport = new genereate_purchase_report();
            //             objGeneratePurchaseReport.Show();

            purchase_report objPurchaseReport = new purchase_report();
            objPurchaseReport.Show();
        }
    }
}
