<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineExam.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        //Disable Mouse Right click
        var message = "Function Disabled!";
        ///////////////////////////////////

        function clickIE() {
            if (document.all) {
                alert(message); return false;
            }
        }

        function clickNS(e) {
            if (document.layers || (document.getElementById && !document.all)) {
                if (e.which == 2 || e.which == 3) {
                    alert(message); return false;
                }
            }
        }

        if (document.layers) {
            document.captureEvents(Event.MOUSEDOWN); document.onmousedown = clickNS;
        }
        else {
            document.onmouseup = clickNS; document.oncontextmenu = clickIE;
        }
        document.oncontextmenu = new Function("return false");
        //End
        function StartExam() {
            //window.close();
            //window.open('welcome.aspx', '', 'toolbar=no,menubar=no,location=no,status=yes,fullscreen=yes,titlebar=no')
            var closeurl = "Login.aspx";
            var popurl = "welcome.aspx";
            winpops = window.open(popurl, "HMSAJAX", "toolbar=no,menubar=no,location=no, resizable=no,status=yes,scrollbars=yes,fullscreen=yes");
            window.open('', '_self', '');
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LoginBg">
        <div style="margin-top: 290px; margin-left: 680px; float: left;">
            <div class="Invalid">
                <asp:Label ID="lblInvalid" runat="server"></asp:Label>
            </div>
            <div class="divUName">
                <asp:TextBox ID="txtUName" runat="server" CssClass="cssTxt"></asp:TextBox></div>
            <div class="divUName">
                <asp:TextBox ID="txtPass" runat="server" CssClass="cssTxt" TextMode="Password"></asp:TextBox></div>
            <div style="float: left; padding-top: 15px; color: White">
                <asp:CheckBox ID="chkIsModExam" runat="server" Text=" Module Exam ?" />
            </div>
            <div class="divSubmit">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="LoginBtn" OnClick="btnSubmit_Click" />
            </div>
            <div class="divReset">
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="LoginBtn" OnClick="btnReset_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
