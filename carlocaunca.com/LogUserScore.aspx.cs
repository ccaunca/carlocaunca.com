using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FallDownDatabase;

namespace carlocaunca.com
{
    public partial class LogUserScore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.HttpMethod == "POST")
            {
                string name = (Request.Form["Name"]);
                string score = (Request.Form["Score"]);
                try
                {
                    using (var db = new FallDownContext())
                    {
                        HighScore highScore = new HighScore
                        {
                            Name = name,
                            Score = Convert.ToInt32(score),
                            InsertDatetime = DateTime.Now
                        };
                        db.AddToHighScores(highScore);
                        db.SaveChanges();
                    }
                    Response.Clear();
                    Response.ContentType = "application/text; charset=utf-8";
                    Response.Write("True");
                    Response.End();
                }
                catch(Exception ex)
                {
                    Response.Clear();
                    Response.ContentType = "application/text; charset=utf-8";
                    Response.Write("False");
                    Response.End();
                    throw ex;
                }
            }
        }
    }
}