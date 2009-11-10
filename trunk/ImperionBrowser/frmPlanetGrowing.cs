using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImperionBrowser
{
    public partial class frmPlanetGrowing : Form
    {
        GalaxyMap _GalaxyMap;
        frmMain _ownerForm;
        
        public frmPlanetGrowing(GalaxyMap iGalaxyMap, frmMain iOwnerForm)
        {
            InitializeComponent();
            _GalaxyMap = iGalaxyMap;
            _ownerForm = iOwnerForm;
        }

        private void InitListView()
        {
            ListViewItem curItem;
            string flightTime;

            //DataListView.Clear();

            progressBar.Value = 0;
            progressBar.Maximum = _GalaxyMap.Systems.Count;
            pnlProgress.Visible = true;

            DataListView.BeginUpdate();
            for (int i = 0; i < _GalaxyMap.Systems.Count; i++)
            {
                for (int j = 0; j < _GalaxyMap.Systems[i].Planets.Count; j++)
                {
                    //skip planet if it is not owned by someone
                    if (_GalaxyMap.Systems[i].Planets[j]._player_name == "")
                        continue;

                    //skip planet if it is a gas planet
                    if (_GalaxyMap.Systems[i].Planets[j].Type == PlanetType.ptGas)
                        continue;

                    curItem = DataListView.Items.Add(_GalaxyMap.Systems[i].Planets[j]._player_name);
                    curItem.SubItems.Add(_GalaxyMap.Systems[i].Planets[j]._planet_name);
                    curItem.SubItems.Add(_GalaxyMap.Systems[i].Planets[j].Type.ToString("g"));
                    curItem.SubItems.Add(_GalaxyMap.Systems[i].Planets[j]._inhabitants);

                    flightTime = FlightTime.GetFlightTime(_ownerForm._CurSystemId, _GalaxyMap.Systems[i]._system_id, _GalaxyMap.Systems[i].Planets[j]._planet_id, (int)TerranSpaceShip.ssKleinerTransporter, typeof(Planet));
                    curItem.SubItems.Add(flightTime);
                    curItem.Group = DataListView.Groups[0];
                }

                progressBar.Value = i;
                Application.DoEvents();
            }
            DataListView.EndUpdate();
            DataListView.Refresh();
            pnlProgress.Visible = false;
        }

        private void frmPlanetGrowing_Load(object sender, EventArgs e)
        {
            InitListView();
        }
    }
}
