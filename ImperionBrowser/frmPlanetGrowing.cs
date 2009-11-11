using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ImperionBrowser
{
    public partial class frmPlanetGrowing : Form
    {
        /// <summary>
        /// This class is used to sort the ListView by columns
        /// </summary>
        public class ListViewColumnSorter : IComparer
        {
            /// <summary>
            /// Specifies the column to be sorted
            /// </summary>
            private int ColumnToSort;
            /// <summary>
            /// Specifies the order in which to sort (i.e. 'Ascending').
            /// </summary>
            private SortOrder OrderOfSort;
            /// <summary>
            /// Case insensitive comparer object
            /// </summary>
            private CaseInsensitiveComparer ObjectCompare;

            /// <summary>
            /// Class constructor.  Initializes various elements
            /// </summary>
            public ListViewColumnSorter()
            {
                // Initialize the column to '0'
                ColumnToSort = 0;

                // Initialize the sort order to 'none'
                OrderOfSort = SortOrder.None;

                // Initialize the CaseInsensitiveComparer object
                ObjectCompare = new CaseInsensitiveComparer();
            }

            /// <summary>
            /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
            /// </summary>
            /// <param name="x">First object to be compared</param>
            /// <param name="y">Second object to be compared</param>
            /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX, listviewY;

                // Cast the objects to be compared to ListViewItem objects
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                // Compare the two items
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

                // Calculate correct return value based on object comparison
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                else
                {
                    // Return '0' to indicate they are equal
                    return 0;
                }
            }

            /// <summary>
            /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
            /// </summary>
            public int SortColumn
            {
                set { ColumnToSort = value; }
                get { return ColumnToSort; }
            }

            /// <summary>
            /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
            /// </summary>
            public SortOrder Order
            {
                set { OrderOfSort = value; }
                get { return OrderOfSort; }
            }
        }
        
        private GalaxyMap _GalaxyMap;
        private frmMain _ownerForm;
        private ListViewColumnSorter _lvwColumnSorter = new ListViewColumnSorter();
        private List<Planet> _lstPlanet;
        
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

            pnlProgress.Visible = true;
            progressBar.Value = 0;
            progressBar.Maximum = _lstPlanet.Count;

            DataListView.BeginUpdate();
            DataListView.Items.Clear();

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
                
            DataListView.EndUpdate();
            DataListView.Refresh();
            pnlProgress.Visible = false;
        }

        private void SortListByColumn(ColumnHeader iSortColumn)
        {
            if (iSortColumn == colFlightTime)
                _lstPlanet.Sort(delegate(Planet p1, Planet p2) { return p1._tag.ToString().CompareTo(p2._tag.ToString()); });

            if (iSortColumn == colOwner)
                _lstPlanet.Sort(delegate(Planet p1, Planet p2) { return p1._player_name.CompareTo(p2._player_name); });

            if (iSortColumn == colPlanetPoints)
                _lstPlanet.Sort(delegate(Planet p1, Planet p2) { return p1._inhabitants.CompareTo(p2._inhabitants); });

            InitListView();
        }

        private void frmPlanetGrowing_Load(object sender, EventArgs e)
        {
            DataListView.ListViewItemSorter = _lvwColumnSorter;
            
            #region Collect data and do default sorting

            _lstPlanet = _GalaxyMap.GetPlanets(PlanetFilterCondition.hasOwner, PlanetType.Desert, PlanetType.Earth, PlanetType.Ice, PlanetType.Vulcan, PlanetType.Water);

            for (int i = 0; i < _lstPlanet.Count; i++)
            {
                //store flight time at planet because of sorting reasons
                _lstPlanet[i]._tag = FlightTime.GetFlightTime(_ownerForm._CurSystemId, _lstPlanet[i]._system_id, _lstPlanet[i]._planet_id, (int)TerranSpaceShip.ssKleinerTransporter, typeof(Planet));
            }

            SortListByColumn(colFlightTime);
            InitListView();

            #endregion
        }

        private void DataListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortListByColumn(DataListView.Columns[e.Column]);
        }
    }
}
