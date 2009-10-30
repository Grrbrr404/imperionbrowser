using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImperionBrowser
{
    public partial class frmRaidTargets : Form
    {

        GalaxyMap _GalaxyMap;
        frmMain _ownerForm;

        public frmRaidTargets(GalaxyMap iGalaxyMap, frmMain iOwnerForm)
        {
            InitializeComponent();
            _GalaxyMap = iGalaxyMap;
            _ownerForm = iOwnerForm;
        }

        private void InitDataGrid()
        {
            DataTable dataTable = new DataTable("GalaxyMap");
            dataTable.Columns.Add(CreateDataColumn(typeof(string), "Name", "Name", false, false, false));
            dataTable.Columns.Add(CreateDataColumn(typeof(string), "Typ", "Typ", false, false, false));
            dataTable.Columns.Add(CreateDataColumn(typeof(string), "Flugzeit", "Flugzeit", false, false, false));
            dataTable.Columns.Add(CreateDataColumn(typeof(string), "Metall", "Metal", false, false, false));
            dataTable.Columns.Add(CreateDataColumn(typeof(string), "Kristall", "Kristall", false, false, false));
            dataTable.Columns.Add(CreateDataColumn(typeof(string), "Deuterium", "Deuterium", false, false, false));
            dataTable.Columns.Add(CreateDataColumn(typeof(object), "Object", "Object", false, false, false));

            progressBar.Value = 0;
            progressBar.Maximum = _GalaxyMap.Systems.Count;
            pnlProgress.Visible = true;
            for (int i = 0; i < _GalaxyMap.Systems.Count; i++)
            {
                for (int j = 0; j < _GalaxyMap.Systems[i].Comets.Count; j++)
                {
                    DataRow row = dataTable.Rows.Add();
                    row["Name"] = _GalaxyMap.Systems[i].Comets[j]._Name;
                    row["Typ"] = "Komet";
                    row["Flugzeit"] = _GalaxyMap.GetFlightTime(_GalaxyMap.Systems[i].Comets[j]._Id, typeof(Comet), SpaceShip.ssRecycler);
                    row["Metall"] = _GalaxyMap.Systems[i].Comets[j].Resources._metalFields;
                    row["Kristall"] = _GalaxyMap.Systems[i].Comets[j].Resources._crystalFields;
                    row["Deuterium"] = _GalaxyMap.Systems[i].Comets[j].Resources._deutriFields;
                    row["object"] = _GalaxyMap.Systems[i].Comets[j];
                }

                for (int j = 0; j < _GalaxyMap.Systems[i].Debris.Count; j++)
                {
                    DataRow row = dataTable.Rows.Add();
                    row["Name"] = "Trüfld. an " + _GalaxyMap.Systems[i].Debris[j]._planetId;
                    row["Typ"] = "Trümmerfeld";
                    row["Flugzeit"] = _GalaxyMap.GetFlightTime(_GalaxyMap.Systems[i].Debris[j]._planetId, typeof(Debris), SpaceShip.ssRecycler);
                    row["Metall"] = _GalaxyMap.Systems[i].Debris[j].Resource._metalFields;
                    row["Kristall"] = _GalaxyMap.Systems[i].Debris[j].Resource._crystalFields;
                    row["Deuterium"] = _GalaxyMap.Systems[i].Debris[j].Resource._deutriFields;
                    row["object"] = _GalaxyMap.Systems[i].Debris[j];
                }

                progressBar.Value = i;
                Application.DoEvents();
            }
            pnlProgress.Visible = false;
            dataGrid.DataSource = dataTable;
            dataGrid.Columns["Object"].Visible = false;
            dataGrid.Sort(dataGrid.Columns[2], ListSortDirection.Ascending);
        }

        private DataColumn CreateDataColumn(Type colType, string name, string caption, bool autoInc, bool readOnly, bool unique)
        {
            DataColumn column = new DataColumn();
            column.DataType = colType;
            column.ColumnName = name;
            column.Caption = caption;
            column.AutoIncrement = autoInc;
            column.ReadOnly = readOnly;
            column.Unique = unique;
            
            return column;
        } 

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Object target = dataGrid.Rows[e.RowIndex].Cells["object"].Value;

            Comet comet;
            Debris debris;
            string url = String.Empty;

            if (target.GetType() == typeof(Comet))
            {
                comet = (Comet)target;
                url = String.Format("http://u1.imperion.de/fleetBase/mission/1/planetId/c{0}/m/301", comet._Id);
            }
            else if (target.GetType() == typeof(Debris))
            {
                debris = (Debris)target;
                url = String.Format("http://u1.imperion.de/fleetBase/mission/1/planetId/d{0}/m/301", debris._planetId);
            }

            _ownerForm.GetCurrentBrowser().Navigate(new Uri(url));
        }

        private void frmRecyclerTargets_Shown(object sender, EventArgs e)
        {
            InitDataGrid();
        }
        
    }
}
