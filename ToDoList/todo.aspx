<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="todo.aspx.cs" Inherits="ToDoList.todo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="description" content="author:udit agrawal" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
<link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />   
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
<script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <title>Tasks</title>
    <style>
        body {
    background-color : whitesmoke;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div><br /><br />
        <div class="container">
     <br /><br />
            <div class ="row">
                <div class="col-md-offset-4 col-md-2"><asp:TextBox ID="txtTask" runat="server" placeholder="Enter Task"></asp:TextBox></div>&nbsp;&nbsp;
                <div class="col-md-2"><asp:Button ID="btnAdd" runat="server" Text="Add Task" CssClass="btn btn-primary" Enabled="true" OnClick="btnAdd_Click" /></div>
            </div><br /><br />
            <div class="row">
                <div class="col-md-offset-4 col-md-1"><asp:Button ID="btnView" runat="server" Text="View Tasks" CssClass="btn btn-info" Enabled="true" OnClick="btnView_Click" /></div>
                &nbsp;
                <div class="col-md-2"><asp:Button ID="btnViewComplete" runat="server" Text="View Completed tasks" CssClass="btn btn-info" Enabled="true" OnClick="btnViewComplete_Click" /></div>
                </div>
                </div>
            <br /><br />

            <div class="row">
                <div class="col-md-offset-3 col-md-6 text-center">
                    <table class="table table-condensed table-bordered table-responsive lead">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </table>
                    </div>
            </div>

            <div class="row">
                 <div class="col-md-offset-5 col-md-6">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" Visible="false"></asp:CheckBoxList>                         
                            <asp:Button ID="btnModify" runat="server" Text="Modify Tasks" CssClass="btn btn-primary" Visible="false" OnClick="btnModify_Click" />
                </div>
                </div>
    </div>
    <div>
    
    </div>
    </form>
</body>
</html>
