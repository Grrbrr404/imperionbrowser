using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Web.UI.WebControls;

namespace ImperionBrowser
{
    public partial class frmPlanetGrowing : Form
    {
        #region members
        /// <summary>
        /// Contains Galaxy Map Data
        /// </summary>
        private GalaxyMap _GalaxyMap;
        
        /// <summary>
        /// reference to frmMain.cs Form object for callbacks
        /// </summary>
        private frmMain _ownerForm;

        /// <summary>
        /// Cache for Planets. Will also be used for sorting before data will be passed to list view component
        /// </summary>
        private List<Planet> _lstPlanet;
        
        /// <summary>
        /// Reference to the last Column that has been sorted
        /// </summary>
        private ColumnHeader _LastSortedColumn;

        /// <summary>
        /// Last sorting direction of _LastSortedColumn
        /// </summary>
        private SortDirection _LastSortDirection = SortDirection.Ascending;
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="iGalaxyMap">GalaxyMap with Data that should be shown in List View component</param>
        /// <param name="iOwnerForm">reference to frmMain.cs Form object for callbacks</param>
        public frmPlanetGrowing(GalaxyMap iGalaxyMap, frmMain iOwnerForm)
        {
            InitializeComponent();
            _GalaxyMap = iGalaxyMap;
            _ownerForm = iOwnerForm;
        }

        /// <summary>
        /// Load the GalaxyMap Data into the Listview
        /// </summary>
        private void InitListView()
        {
            ListViewItem curItem;

            
            DataListView.BeginUpdate();
            DataListView.Items.Clear();
            
            InitProgressBar("Daten werden vorbereitet", _lstPlanet.Count);
            for (int i = 0; i < _lstPlanet.Count; i++)
            {
                curItem = DataListView.Items.Add(_lstPlanet[i]._player_name);
                curItem.SubItems.Add(_lstPlanet[i]._planet_name);
                curItem.SubItems.Add(_lstPlanet[i].Type.ToString("g"));
                curItem.SubItems.Add(_lstPlanet[i]._inhabitants);
                curItem.SubItems.Add(_lstPlanet[i]._tag.ToString()); //_tag should be the flighttime duration, definition above
                
                curItem.Group = DataListView.Groups[0];
                
                progressBar.Value = i;
                Application.DoEvents();
            }
            ResetProgressBar();
                
            DataListView.EndUpdate();
            DataListView.Refresh();
            pnlProgress.Visible = false;
        }

        /// <summary>
        /// Sort the list view component by a given header coloum
        /// </summary>
        /// <param name="iSortColumn"></param>
        private void SortListByColumn(ColumnHeader iSortColumn)
        {
            SortDirection iSorting = SortDirection.Ascending;

            if (iSortColumn == _LastSortedColumn)
                if (_LastSortDirection == SortDirection.Ascending)
                    iSorting = SortDirection.Descending;
                else
                    iSorting = SortDirection.Ascending;

            _LastSortedColumn = iSortColumn;
            _LastSortDirection = iSorting;
            
            if (iSortColumn == colFlightTime)
                _lstPlanet.Sort(delegate(Planet p1, Planet p2) {
                    if (iSorting == SortDirection.Ascending)
                        return p1._tag.ToString().CompareTo(p2._tag.ToString()); 
                    else
                        return p2._tag.ToString().CompareTo(p1._tag.ToString()); 
                });

            if (iSortColumn == colPlanet)
                _lstPlanet.Sort(delegate(Planet p1, Planet p2)
                {
                    if (iSorting == SortDirection.Ascending)
                        return p1._planet_name.CompareTo(p2._planet_name);
                    else
                        return p2._planet_name.CompareTo(p1._planet_name);
                });
            
            if (iSortColumn == colOwner)
                _lstPlanet.Sort(delegate(Planet p1, Planet p2) {
                    if (iSorting == SortDirection.Ascending)
                        return p1._player_name.CompareTo(p2._player_name); 
                    else
                        return p2._player_name.CompareTo(p1._player_name); 
                });

            if (iSortColumn == colPlanetPoints)
                _lstPlanet.Sort(delegate(Planet p1, Planet p2) {
                    if (iSorting == SortDirection.Ascending)
                        return p1.Inhabitants.CompareTo(p2.Inhabitants);
                    else
                        return p2.Inhabitants.CompareTo(p1.Inhabitants); 
                });

            InitListView();
        }

        private void frmPlanetGrowing_Load(object sender, EventArgs e)
        {
            LoadGalaxyData();
            InitListView();
        }

        /// <summary>
        /// Load all planets off GalaxyMap wich have an owner
        /// </summary>
        private void LoadGalaxyData()
        {
            
            _lstPlanet = _GalaxyMap.GetPlanets(PlanetFilterCondition.hasOwner, PlanetType.Desert, PlanetType.Earth, PlanetType.Ice, PlanetType.Vulcan, PlanetType.Water);

            pnlProgress.Visible = true;

            InitProgressBar("Loading Planet Data", _lstPlanet.Count);
            for (int i = 0; i < _lstPlanet.Count; i++)
            {
                //store flight time at planet because of sorting reasons
                _lstPlanet[i]._tag = FlightTime.GetFlightTime(_ownerForm._CurSystemId, _lstPlanet[i]._system_id, _lstPlanet[i]._planet_id, (int)TerranSpaceShip.ssKleinerTransporter, typeof(Planet));
                progressBar.Value = i;
                Application.DoEvents();
            }
            ResetProgressBar();

            SortListByColumn(colFlightTime);

            SaveGalaxyDataInDatabase();
        }

        private void InitProgressBar(string iProgressText, int iMaxValue)
        {
            pnlProgress.Visible = true;
            lblProgress.Text = iProgressText;
            progressBar.Maximum = iMaxValue;
        }

        private void ResetProgressBar()
        {
            pnlProgress.Visible = false;
            progressBar.Value = 0;
        }

        /// <summary>
        /// Save the data of List<Planet> _lstPlanet into the sql light datatable PlanetGrowing
        /// </summary>
        private void SaveGalaxyDataInDatabase()
        {
            using (SqLight sqlight = new SqLight())
            {
                //remove todays data to replace it with actual new one
                if (!IsFirstGalaxyScanToday())
                    DeleteTodaysCollectedData();

                
            }
        }

        /// <summary>
        /// returns true if table PlanetGrowing does not containing data from today
        /// </summary>
        /// <returns>bool</returns>
        private bool IsFirstGalaxyScanToday()
        {
            bool result = false;
            using (SqLight sqlight = new SqLight())
            {
                string sql = "select count(id) from PlanetGrowing where ScanDate = '" + DateTime.Now.ToString("dd.MM.yyyy") + "'";
                result = sqlight.SqlGetIntValue(sql) == 0;
            }
            return result;
        }


        private void DeleteTodaysCollectedData()
        {
            throw new NotImplementedException();
        }
        

        private void DataListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortListByColumn(DataListView.Columns[e.Column]);
        }
    }
}
