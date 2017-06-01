using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ToDoList
{
    public partial class todo : System.Web.UI.Page
    {
        public class Task
        {
            public string taskName;
            public bool completed;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string json;
            Task t = new Task();
            t.taskName = txtTask.Text.Trim();
            t.completed = false;
            try
            {
                using (StreamReader sr = new StreamReader(Server.MapPath("~/") + @"taskList.json"))
                {
                    json = sr.ReadToEnd();
                    List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(json);
                    if (tasks == null)
                        json = JsonConvert.SerializeObject(t, Formatting.Indented);
                    else
                    {
                        tasks.Add(t);
                        json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                    }
                }

                File.WriteAllText(Server.MapPath("~/") + @"taskList.json", json);
                Response.Write("<script>alert('Task Added Succesfully');</script>");
            }
  
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + "Error in adding task');</script>");
            }

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBoxList1.Visible = true;   
                CheckBoxList1.Items.Clear();
                btnModify.Visible = true;
                using (StreamReader sr = new StreamReader(Server.MapPath("~/") + @"taskList.json"))
                {
                    List<ListItem> ck = new List<ListItem>();
                    //ck.ID = "check1";
                    string json = sr.ReadToEnd();
                    dynamic items = JsonConvert.DeserializeObject(json);
                    foreach(var item in items)
                    {
                        ListItem c = new ListItem();
                        c.Text = item.taskName;
                        c.Value = item.completed;
                        if (item.completed == false)
                            c.Selected = false;
                        else
                            c.Selected = true;
                        CheckBoxList1.Items.Add(c);
                    }
                    //CheckBoxList1.DataSource = ck;
                    //CheckBoxList1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + "Error in viewing tasks');</script>");
            }
        }

        protected void btnViewComplete_Click(object sender, EventArgs e)
        {
            CheckBoxList1.Visible = false;
            btnModify.Visible = false;
            using (StreamReader sr = new StreamReader(Server.MapPath("~/") + @"taskList.json"))
            {
                string json = sr.ReadToEnd();
                dynamic items = JsonConvert.DeserializeObject(json);
                StringBuilder html = new StringBuilder();
                html.Append("<thead class='text-danger'>");
                html.Append("<tr>");
                html.Append("<th class='text-center'>"); html.Append("Task Name"); html.Append("</th>");
                html.Append("<th class='text-center'>"); html.Append("Completed"); html.Append("</th>");
                html.Append("</tr>");
                html.Append("</thead>");
                html.Append("<tbody>");
                foreach (var item in items)
                {
                    html.Append("<tr>");
                    html.Append("<td>"); html.Append(item.taskName); html.Append("</td>");
                    if (item.completed == false)
                    { html.Append("<td class='text text-danger'>"); html.Append("Not Completed"); html.Append("</td>"); }
                    else
                    { html.Append("<td class='text text-info'>"); html.Append("Completed"); html.Append("</td>"); }
                        html.Append("</tr>");
                }
                html.Append("</tbody>");
                PlaceHolder1.Controls.Clear();
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBoxList1.Visible = true;
                List<Task> tasks = new List<Task>();
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    Task t = new Task();
                    t.taskName = item.Text;
                    t.completed = item.Selected;
                    tasks.Add(t);
                }
                string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                File.WriteAllText(Server.MapPath("~/") + @"taskList.json", json);
                Response.Write("<script>alert('Tasks Modified Succesfully');</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + "Error in modifying tasks information');</script>");
            }
        }
    }
}