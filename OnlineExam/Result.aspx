<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExam.Master" AutoEventWireup="true"
    CodeBehind="Result.aspx.cs" Inherits="OnlineExam.Result" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       
        
        function Logout() {
            //window.close();
            //window.open('welcome.aspx', '', 'toolbar=no,menubar=no,location=no,status=yes,fullscreen=yes,titlebar=no')
            var closeurl = "Result.aspx";
            var popurl = "Login.aspx";
            winpops = window.open(popurl, "HMSAJAX", "toolbar=yes,menubar=yes, resizable=yes,status=yes,scrollbars=yes,fullscreen=no");
            window.open('', '_self', '');
            window.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTitle" runat="server">
    <div class=" float-left PageTitle">
        <img id="img" runat="server" src="~/Images/Logo.png" alt="" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Body" runat="server">
    <div class="section">
        <!--[if !IE]>start title wrapper<![endif]-->
        <div class="title_wrapper">
            <div class="float-left">
            <asp:HiddenField ID="hdnFileName" runat="server" />
                <h2>
                    Result</h2>
            </div>
        </div>
        <div class="Heading" style="margin-left:330px;font-size:50pt;">
            Congratulations !!</div>
            <div class="clear">
        </div>
        <br />
        <br />
        <br />
        <div class="Heading" style="margin-left:180px;font-size:30pt">
            You have Completed your exam successfully.
          </div>
        <div class="clear">
        </div>
        <br />
        <br />
        <br />
        <br />
        <div id="divView" runat="server" style="float: left; padding: 5px 5px 5px 500px">
            <span class="button dark_blue_btn"><span><span>View Result</span></span>
                <asp:Button ID="btnView" Text="Search" runat="server" OnClick="btnView_Click" /></span>
        </div>
        <div style="float: left; padding: 5px">
            <span class="button red_btn"><span><span>Close</span></span>
                <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
            </span>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
