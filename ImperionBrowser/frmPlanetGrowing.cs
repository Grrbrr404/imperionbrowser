using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data.SQLite;

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

        /// <summary>
        /// Hotkey wrapper
        /// </summary>
        private HotKey _Hotkeys = new HotKey();
        
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
        /// Init Hotkeywrapper and define hotkeys
        /// </summary>
        private void InitHotkeys()
        {
            _Hotkeys = new HotKey();
            _Hotkeys.OwnerForm = this;
            _Hotkeys.HotKeyPressed += new HotKey.HotKeyPressedEventHandler(_Hotkeys_HotKeyPressed);
            
            _Hotkeys.AddHotKey(Keys.R, HotKey.MODKEY.MOD_CONTROL, "hkResetView");
            _Hotkeys.AddHotKey(Keys.B, HotKey.MODKEY.MOD_CONTROL, "hkUserFilter");
        }

        /// <summary>
        /// Hotkey event that will be fired if a predefined hotkey was pressed. Take a
        /// look at InitHotkeys() to define a new hotkey
        /// </summary>
        /// <param name="HotKeyID"></param>
        void _Hotkeys_HotKeyPressed(string HotKeyID)
        {
            if (ActiveForm == this)
            {
                if (HotKeyID == "hkResetView")
                    btnResetView.PerformClick();

                if (HotKeyID == "hkUserFilter")
                    btnUserFilter.PerformClick();
            }
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
                curItem.SubItems.Add(_lstPlanet[i]._alliance_name);
                curItem.SubItems.Add(_lstPlanet[i]._planet_name);
                curItem.SubItems.Add(_lstPlanet[i].Type.ToString("g"));
                curItem.SubItems.Add(_lstPlanet[i]._inhabitants);
                
                //_tag should be the flighttime duration, defined in LoadGalaxyData()
                curItem.SubItems.Add(_lstPlanet[i]._tag.ToString());
                
                //store the planet object for later use
                ListViewItem.ListViewSubItem SoureListIndexItem = new ListViewItem.ListViewSubItem();
                SoureListIndexItem.Name = "PlanetObject";
                SoureListIndexItem.Tag = _lstPlanet[i];
                curItem.SubItems.Add(SoureListIndexItem); 
                
                curItem.Group = DataListView.Groups[0];
                
                progressBar.Value = i;
                Application.DoEvents();
            }
            ResetProgressBar();

            LoadLastSixDays();

            DataListView.EndUpdate();
            DataListView.Refresh();
            pnlProgress.Visible = false;
        }

        /// <summary>
        /// Load the last 6 days from database
        /// </summary>
        private void LoadLastSixDays()
        {
            DateTime Yesterday = DateTime.Now.AddDays(-1);
            DateTime TwoDaysAgo = DateTime.Now.AddDays(-2);
            DateTime ThreeDaysAgo = DateTime.Now.AddDays(-3);
            DateTime FourDaysAgo = DateTime.Now.AddDays(-4);
            DateTime FiveDaysAgo = DateTime.Now.AddDays(-5);
            DateTime SixDaysAgo = DateTime.Now.AddDays(-6);

            LoadDataOfDate(Yesterday, DataListView.Groups["Yesterday"]);
            LoadDataOfDate(TwoDaysAgo, DataListView.Groups["TwoDaysAgo"]);
            LoadDataOfDate(ThreeDaysAgo, DataListView.Groups["ThreeDaysAgo"]);
            LoadDataOfDate(FourDaysAgo, DataListView.Groups["FourDaysAgo"]);
            LoadDataOfDate(FiveDaysAgo, DataListView.Groups["FiveDaysAgo"]);
            LoadDataOfDate(SixDaysAgo, DataListView.Groups["SixDaysAgo"]);
        }

        /// <summary>
        /// Loads the data from database by the given date param
        /// </summary>
        /// <param name="iDateOfScan">The Date of Scan</param>
        private void LoadDataOfDate(DateTime iDateOfScan, ListViewGroup iDestinationGroup)
        {
            using (SqLight sqlight = new SqLight())
            {
                string sql = @"Select * from PlanetGrowing where ScanDate = '" + iDateOfScan.ToString("dd.MM.yyyy") + "'";

                using (SQLiteDataReader reader = sqlight.ExecuteQuery(sql))
                {
                    ListViewItem curItem;
                    ListViewItem.ListViewSubItem SubItem_PlanetObject;
                    while (reader.Read())
                    {
                        curItem = DataListView.Items.Add(reader["OwnerName"].ToString());
                        curItem.SubItems.Add(reader["OwnerAllianceName"].ToString());
                        curItem.SubItems.Add(reader["PlanetName"].ToString());
                        curItem.SubItems.Add(reader["PlanetType"].ToString());
                        curItem.SubItems.Add(reader["PlanetPoints"].ToString());
                        curItem.SubItems.Add(reader["FlightTime"].ToString());

                        SubItem_PlanetObject = new ListViewItem.ListViewSubItem();
                        SubItem_PlanetObject.Name = "PlanetObject";
                        SubItem_PlanetObject.Tag = _GalaxyMap.FindPlanet(reader["PlanetId"].ToString());

                        curItem.SubItems.Add(SubItem_PlanetObject);
                        
                        curItem.Group = iDestinationGroup;
                    }
                }
            }
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

            if (iSortColumn == ColAlly)
                _lstPlanet.Sort(delegate(Planet p1, Planet p2)
                {
                    if (iSorting == SortDirection.Ascending)
                        return p1._alliance_name.CompareTo(p2._alliance_name);
                    else
                        return p2._alliance_name.CompareTo(p1._alliance_name);
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
                
                #region store todays galaxy data
                using (SQLiteTransaction mytransaction = sqlight.BeginTransaction())
                {
                    using (SQLiteCommand cmd = sqlight.NewCommand())
                    {
                        SQLiteParameter Id = new SQLiteParameter();
                        SQLiteParameter PlanetId = new SQLiteParameter();
                        SQLiteParameter PlanetPoints = new SQLiteParameter();
                        SQLiteParameter PlanetName = new SQLiteParameter();
                        SQLiteParameter PlanetType = new SQLiteParameter();
                        SQLiteParameter OwnerId = new SQLiteParameter();
                        SQLiteParameter OwnerName = new SQLiteParameter();
                        SQLiteParameter OwnerAllianceName = new SQLiteParameter();
                        SQLiteParameter ScanDate = new SQLiteParameter();
                        SQLiteParameter FlightTime = new SQLiteParameter();

                        cmd.CommandText = "INSERT INTO [PlanetGrowing] ([ID],[PlanetId],[PlanetPoints],[PlanetName],[PlanetType],[OwnerId],[OwnerName],[OwnerAllianceName],[ScanDate],[FlightTime]) VALUES(?,?,?,?,?,?,?,?,?,?)";
                        
                        cmd.Parameters.Add(Id);
                        cmd.Parameters.Add(PlanetId);
                        cmd.Parameters.Add(PlanetPoints);
                        cmd.Parameters.Add(PlanetName);
                        cmd.Parameters.Add(PlanetType);
                        cmd.Parameters.Add(OwnerId);
                        cmd.Parameters.Add(OwnerName);
                        cmd.Parameters.Add(OwnerAllianceName);
                        cmd.Parameters.Add(ScanDate);
                        cmd.Parameters.Add(FlightTime);

                        for (int i = 0; i < _lstPlanet.Count; i++)
                        {
                            Id.Value = Guid.NewGuid().ToString();
                            PlanetId.Value = _lstPlanet[i]._planet_id;
                            PlanetPoints.Value = _lstPlanet[i]._inhabitants;
                            PlanetName.Value = _lstPlanet[i]._planet_name;
                            PlanetType.Value = _lstPlanet[i].Type.ToString("g");
                            OwnerId.Value = _lstPlanet[i]._user_id;
                            OwnerName.Value = _lstPlanet[i]._player_name;
                            OwnerAllianceName.Value = _lstPlanet[i]._alliance_name;
                            ScanDate.Value = DateTime.Now.ToString("dd.MM.yyyy");
                            FlightTime.Value = _lstPlanet[i]._tag.ToString();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    mytransaction.Commit();
                }
                #endregion
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
            using (SqLight sqlight = new SqLight())
            {
                sqlight.ExecuteSql("Delete from PlanetGrowing where ScanDate = '" + DateTime.Now.ToString("dd.MM.yyyy") + "'");
            }
        }

        /// <summary>
        /// Sort list by column
        /// </summary>
        private void DataListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortListByColumn(DataListView.Columns[e.Column]);
        }

        private void btnUserFilter_Click(object sender, EventArgs e)
        {
            if (DataListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Es sind keine Einträge in der Liste markiert", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RemovePlanetsWhereOwnerIsNotSelected();
        }

        /// <summary>
        /// Will remove all Planets from Listview if the owner is currently not selected
        /// </summary>
        private void RemovePlanetsWhereOwnerIsNotSelected()
        {
            List<string> SelectedUsers = new List<string>();
            for (int i = 0; i < DataListView.SelectedItems.Count; i++)
            {
                SelectedUsers.Add(DataListView.SelectedItems[i].Text);
            }
            
            DataListView.BeginUpdate();
            for (int i = 0; i < DataListView.Items.Count; i++)
            {
                if (!SelectedUsers.Contains(DataListView.Items[i].Text))
                {
                    DataListView.Items.RemoveAt(i);
                    i--; //decrement i because item list will be smaller now
                }
            }
            DataListView.EndUpdate();
            DataListView.Refresh();
        }

        private void DataListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = DataListView.GetItemAt(e.X, e.Y);
            
            if (clickedItem != null)
                Tools.OpenFleetBaseOfPlanet(_ownerForm.GetCurrentBrowser() , (Planet)clickedItem.SubItems["PlanetObject"].Tag);
        }

        private void btnResetView_Click(object sender, EventArgs e)
        {
            InitListView();
        }

        private void frmPlanetGrowing_Shown(object sender, EventArgs e)
        {
            LoadGalaxyData();
            InitListView();
        }

        private void frmPlanetGrowing_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Hotkeys.Dispose();
        }

        private void btnShowChartOfSelectedUsers_Click(object sender, EventArgs e)
        {
            if (DataListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Es sind keine Einträge in der Liste markiert", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<string> UniqueUserIds = ExtractUserIdsOfListViewSelection();

            if (UniqueUserIds.Count > 10)
            {
                MessageBox.Show("Es wird momentan nicht unterstützt, mehr als 10 Benutzer gleichzeitig an zu zeigen."
                                + "Bitte weniger selektieren", "Achtung", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            frmPlanetGrowingGraph frmGraph = new frmPlanetGrowingGraph();

            //Load all selected users into the form
            for (int i = 0; i < UniqueUserIds.Count; i++)
                frmGraph.AddUserId(UniqueUserIds[i]);

            //Paint the Graph
            frmGraph.CreateGraphOfUsers();

            //finally show the form
            frmGraph.ShowDialog();
            frmGraph.Dispose();
        }

        private List<string> ExtractUserIdsOfListViewSelection()
        {
            List<string> result = new List<string>();
            
            
            Planet tempPlanet;
            
            for (int i = 0; i < DataListView.SelectedItems.Count; i++)
            {
                tempPlanet = (Planet)DataListView.SelectedItems[i].SubItems["PlanetObject"].Tag;
                if (!result.Contains(tempPlanet._user_id))
                    result.Add(tempPlanet._user_id);
            }

            return result;
        }
    }
}
