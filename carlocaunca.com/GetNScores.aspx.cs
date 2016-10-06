using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FallDownDatabase;

namespace carlocaunca.com
{
    public partial class GetNScores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.HttpMethod == "POST")
            {
                int n = Convert.ToInt32((Request.Form["Number"]));
                List<HighScore> topNScores = new List<HighScore>();
                using (var db = new FallDownContext())
                {
                    var query = (from hs in db.HighScores
                                 orderby hs.Score
                                 select hs).Take(n);
                    
                    foreach (var score in query)
                    {
                        topNScores.Add(score);
                    }
                }
                Response.Clear();
                Response.ContentType = "application/text; charset=utf-8";
                Response.Write(topNScores);
                Response.End();
            }
        }
    }
}