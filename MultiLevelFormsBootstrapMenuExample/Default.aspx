<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MultiLevelFormsBootstrapMenu.Example" %>
<%@ Register tagPrefix="bootstrap" assembly="MultiLevelFormsBootstrapMenu" namespace="MultiLevelFormsBootstrapMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>ASP.NET Multi Level Forms Bootstrap Menu Control Example</title>
    <link href="http://ajax.aspnetcdn.com/ajax/bootstrap/3.1.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="multilevelformsbootstrapmenu.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->

</head>
<body>
    <form id="form1" runat="server">   
        <div class="navbar navbar-inverse navbar-static-top" role="navigation">
            <div class="container" style="padding: 0; margin: 0;">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>
                <div class="navbar-collapse collapse">
                    <bootstrap:BootstrapMenu ID="BootstrapMenu1" runat="server" DataSourceID="mapSource"></bootstrap:BootstrapMenu>
                </div><!--/.nav-collapse -->
            </div>
        </div>
        <asp:SiteMapDataSource ID="mapSource" runat="server" ShowStartingNode="false" />
    </form>
    
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/bootstrap/3.1.0/bootstrap.min.js"></script>
</body>
</html>
