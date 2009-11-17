using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Data.SQLite;

namespace ImperionBrowser
{
    public partial class frmPlanetGrowingGraph : Form
    {

        private List<string> _UserIds = new List<string>();

        public frmPlanetGrowingGraph()
        {
            InitializeComponent();
        }

        private void frmGraph_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void SetSize()
        {
            //zedGraph_PlanetGrowing.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            //zedGraph_PlanetGrowing.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }

        private void frmGraph_Load(object sender, EventArgs e)
        {
            // Size the control to fill the form with a margin
            SetSize();
        }
        
        /// <summary>
        /// Adds a new user to the user list, duplications are filtered automatically
        /// </summary>
        /// <param name="iIdOfuser"></param>
        public void AddUserId(string iIdOfUser)
        {
            if (_UserIds.Count == 10)
                throw new Exception("More than 10 cant be displayed at the same time");
            
            if (!_UserIds.Contains(iIdOfUser))
                _UserIds.Add(iIdOfUser);
        }
        
        /// <summary>
        /// Will display a line chart for all users thas has been added to List _UserIds
        /// 10 users at same time is maximum
        /// 
        /// datasource: sqlight table 'PlanetGrowing'
        /// </summary>
        public void CreateGraphOfUsers()
        {
            if (_UserIds.Count > 10)
                throw new Exception("More than 10 cant be displayed at the same time");
            
            SetDefaultLayoutOfGraph();
            
            Color[] ColorDefinitions = { Color.Red, Color.Blue, Color.Olive, Color.Green, Color.Black, 
                                           Color.Orange, Color.Brown, Color.DarkBlue, Color.Gray, Color.Pink  };

            PointPairList currentCurveDefinition;
            string LegendLabel = String.Empty;
            for (int i = 0; i < _UserIds.Count; i++)
            {
                LegendLabel = GetUserNameById(_UserIds[i]);
                currentCurveDefinition = GetCurveDefinitionOfUser(_UserIds[i]);
                zedGraph_PlanetGrowing.GraphPane.AddCurve(LegendLabel, currentCurveDefinition, ColorDefinitions[i],(SymbolType)i);
            }

            //Apply changes
            zedGraph_PlanetGrowing.GraphPane.AxisChange();
        }
        
        /// <summary>
        /// Try to get the User Name by given ID
        /// data source: sqlight table 'PlanetGrowing'
        /// </summary>
        /// <param name="iIdOfUser">id of user</param>
        /// <returns>on success: username on error: iIdOfUser</returns>
        private string GetUserNameById(string iIdOfUser)
        {
            string result = String.Empty;
            
            using (SqLight sqlight = new SqLight())
            {
                result = sqlight.SqlGetStrValue("Select OwnerName from PlanetGrowing where OwnerId = '" + iIdOfUser + "'");
            }

            return result;
        }

        /// <summary>
        /// Sumerize points of a given user and returns the last 6 days as lineitem for zend graph
        /// datasource: sqlight table 'PlanetGrowing'
        /// </summary>
        /// <param name="iUserId">id of user / planet owner</param>
        /// <returns>LineItem with coordinates for one week</returns>
        private PointPairList GetCurveDefinitionOfUser(string iUserId)
        {
            PointPairList result = new PointPairList();

            using (SqLight sqlight = new SqLight())
            {
                DateTime currentDate;
                string PlanetPoints;
                string sql = String.Empty;
                
                //collect data from the last 6 days
                for (int i = 6; i > -1; i--)
                {
                    currentDate = DateTime.Now.AddDays(- i); 

                    sql = "select Sum(PlanetPoints) from PlanetGrowing "
                        + " where OwnerId = '" + iUserId + "' "
                        + " and ScanDate = '" + currentDate.ToString("dd.MM.yyyy") + "'";

                    PlanetPoints = sqlight.SqlGetStrValue(sql);

                    //set points to zero if no data could be found
                    //this could happen if a user dosnt make a scan every day
                    if (String.IsNullOrEmpty(PlanetPoints))
                        PlanetPoints = "0";
                        
                    result.Add(i, float.Parse(PlanetPoints));
                    
                }
            }

            return result;
        }

        /// <summary>
        /// Method for testing reasons, dont call in real application
        /// </summary>
        /// <param name="iDestinationGraph">the zendgraph</param>
        private void CreateTestGraph(ZedGraphControl iDestinationGraph)
        {
            //Set default layout
            SetDefaultLayoutOfGraph();

            #region predefined test data
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            
            list1.Add(0, 2000);
            list1.Add(1, 2100);
            list1.Add(2, 2200);
            list1.Add(3, 2300);
            list1.Add(4, 2400);
            list1.Add(5, 2500);
            list1.Add(6, 2600);

            list2.Add(0, 1800);
            list2.Add(1, 2400);
            list2.Add(2, 2600);
            list2.Add(3, 2620);
            list2.Add(4, 2620);
            list2.Add(5, 2640);
            list2.Add(6, 2700);

            list3.Add(0, 1900);
            list3.Add(1, 2500);
            list3.Add(2, 2700);
            list3.Add(3, 2820);
            list3.Add(4, 2820);
            list3.Add(5, 2840);
            list3.Add(6, 2850);
            #endregion

            GraphPane myGraphPane = iDestinationGraph.GraphPane;

            //add curves
            LineItem myCurve = myGraphPane.AddCurve("Jessi [DSF]", list1, Color.Red, SymbolType.Diamond);
            LineItem myCurve2 = myGraphPane.AddCurve("Grrbrr [ID]", list2, Color.Blue, SymbolType.Circle);
            LineItem myCurve3 = myGraphPane.AddCurve("Roxxteady [ID]", list3, Color.Green, SymbolType.Triangle);

            //Apply changes
            iDestinationGraph.AxisChange();
        }

        /// <summary>
        /// Set Default layout for a zend graph
        /// </summary>
        /// <param name="iDestinationGraph">the graph wich should be changed</param>
        private void SetDefaultLayoutOfGraph()
        {
            zedGraph_PlanetGrowing.GraphPane.Title.Text = "Planetenwachstum";
            zedGraph_PlanetGrowing.GraphPane.XAxis.Title.Text = "";
            zedGraph_PlanetGrowing.GraphPane.YAxis.Title.Text = "Punkte";
            zedGraph_PlanetGrowing.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zedGraph_PlanetGrowing.GraphPane.YAxis.MajorGrid.IsVisible = true;
            zedGraph_PlanetGrowing.GraphPane.XAxis.Type = AxisType.Text;
            
            string[] labels = { "Vor 6 Tagen", "Vor 5 Tagen", "Vor 4 Tagen", "Vor 3 Tagen", "Vor 2 Tagen", "Gestern", "Heute" };
            zedGraph_PlanetGrowing.GraphPane.XAxis.Scale.TextLabels = labels;
            zedGraph_PlanetGrowing.GraphPane.XAxis.Scale.FontSpec.Angle = 90;

            //Apply Changes
            zedGraph_PlanetGrowing.AxisChange();
        }

        /// <summary>
        /// Show mouse coordinates in statusbar
        /// </summary>
        private bool zedGraph_PlanetGrowing_MouseMoveEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            // Save the mouse location
            PointF mousePt = new PointF(e.X, e.Y);

            // Find the Chart rect that contains the current mouse location
            GraphPane pane = sender.MasterPane.FindChartRect(mousePt);

            // If pane is non-null, we have a valid location.  Otherwise, the mouse is not
            // within any chart rect.
            if (pane != null)
            {
                double x, y;
                // Convert the mouse location to X, and Y scale values
                pane.ReverseTransform(mousePt, out x, out y);
                // Format the status label text
                lblXYCoordinates.Text = "(" + x.ToString("f2") + ", " + y.ToString("f2") + ")";
            }
            else
                // If there is no valid data, then clear the status label text
                lblXYCoordinates.Text = string.Empty;

            // Return false to indicate we have not processed the MouseMoveEvent
            // ZedGraphControl should still go ahead and handle it
            return false;

        }

    }
}
