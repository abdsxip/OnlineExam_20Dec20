<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="OnlineExam.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @import 'Styles/cssUpdateProgress.css';
        @import 'Styles/SiteCSS.css';
        @import 'Styles/ddsmoothmenu.css';
        @import 'Styles/jquery-ui-1.8.12.custom.css';
        @import 'Styles/jquery.alerts.css';
    </style>
    <script src="Scripts/ddsmoothmenu.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.8.12.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.alerts.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="wrapper">
            <div id="header">
                <div id="logo" style="float: left">
                </div>
                <div class="welcome_msg">
                    <asp:Label ID="lblInstName" runat="server" CssClass="label-class-tiny"></asp:Label><br />
                    <asp:Label ID="lblName" runat="server" Text="" CssClass="label-class-tiny"></asp:Label>
                    <br />
                    <asp:Label ID="lblCourse" runat="server" CssClass="label-class-tiny"></asp:Label>
                    <br />
                    <asp:Label ID="lblMaxMarks" runat="server" CssClass="label-class-tiny"></asp:Label><br />
                    <br />
                </div>
                <div>
                    <div class=" float-left PageTitle">
                        <img id="img" runat="server" src="~/Images/Logo.png" alt="" />
                    </div>
                </div>
                <br class="clear" />
            </div>
        </div>
        <!-- ############################ Content Section ########################## -->
        <div class="clear">
        </div>
        <div class="section">
            <div style="float: left;">
                <img src="images/Err_ico.gif" style="padding: 15px 10px 5px 10px" alt="" /></div>
            <div style="float: left; padding-top: 20px">
                <h2 style="font-size: x-large; color: Red">
                    ERROR!
                </h2>
            </div>
            <div class="clear">
            </div>
            <p style="font-size: 14px; padding-left: 10px;">
                An unexpected error has occured. We are sorry for the inconvenience.<br />
                Please contact System Administrator.
            </p>
            <br />
            <div style="float: left; padding: 5px;padding-left:20px">
                <span class="button red_btn"><span><span>Exit</span></span>
                    <asp:Button ID="btnExit" Text="Search" runat="server" OnClick="btnExit_Click"/></span>
            </div>
            <div class="clear">
            </div>
            <!-- ############################ Footer Section ########################## -->
            <div class="wrapper">
                <div id="copyright">
                    <%--<p class="float-left">
                Copyright &copy; 2012 - All Rights Reserved - <a href="#">Domain Name</a></p>--%>
                    <p class="float-right">
                        Maintained by <a href="#" title="Template">Tanman IT Solutions</a></p>
                    <br class="clear" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
