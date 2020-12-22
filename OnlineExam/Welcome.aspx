<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExam.Master" AutoEventWireup="true"
    CodeBehind="Welcome.aspx.cs" Inherits="OnlineExam.Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        
        //function btnStart_Click() {

            //window.open('Test.aspx', '', 'toolbar=no,menubar=no,location=no,status=no,fullscreen=no');
            //window.self.close();
        //}
        //shortcut.add("Alt+F4", function () {
            //alert("Alt Tab Pressed!");
            //return false;
        //});
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
        <div class="pageWidth">
            <div class="Heading">
                WELCOME TO ONLINE EXAMINATION
            </div>
            <div class="clear">
            </div>
            <div class="box">
            <asp:HiddenField ID="hdnStatusId" runat="server" />
                <div class="column4" style="min-width:50px">
                    <asp:Label ID="lblName" runat="server" Text="Name : " CssClass="label-class"></asp:Label>
                </div>
                <div class="column3" style="min-width:300px">
                    <asp:Label ID="lblNameVal" runat="server" CssClass="label-class-small"></asp:Label>
                </div>
                <div class="column4">
                    <asp:Label ID="lblEnrolNo" runat="server" Text="Enrol No. : " CssClass="label-class"></asp:Label>
                </div>
                <div class="column3">
                    <asp:Label ID="lblEnrolNoVal" runat="server" CssClass="label-class-small"></asp:Label>
                </div>
                
                <div class="column4">
                    <asp:Label ID="lblValidTill" runat="server" Text="Valid Till : " CssClass="label-class"></asp:Label>
                </div>
                <div class="column3">
                    <asp:Label ID="lblValidTillVal" runat="server"  CssClass="label-class-small"></asp:Label>
                </div>
                
                <div class="clear">
                </div>
                <div class="column4" style="min-width:50px">
                    <asp:Label ID="lblCourse" runat="server" Text="Course : " CssClass="label-class"></asp:Label>
                </div>
                <div class="column3" style="min-width: 300px">
                    <asp:Label ID="lblCourseVal" runat="server"  CssClass="label-class-small"></asp:Label>
                </div>
                
                <div class="column4">
                    <asp:Label ID="lblMaxMarks" runat="server" Text="Max Marks : " CssClass="label-class"></asp:Label>
                </div>
                <div class="column3">
                    <asp:Label ID="lblMaxMarksVal" runat="server" CssClass="label-class-small"></asp:Label>
                </div>
                <div class="column4">
                    <asp:Label ID="lblPassMrk" runat="server" Text="Pass % : " CssClass="label-class"></asp:Label>
                </div>
                <div class="column3">
                    <asp:Label ID="lblPassMrkVal" runat="server" CssClass="label-class-small"></asp:Label>
                </div>
                
                <div class="clear">
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="Heading">
                INSTRUCTIONS
            </div>
            <div class="box" style="background-color: #beb85e; color: #000; font-size: 14px;">
                <p>
                    <h2 style="font-weight: 500;">
                        Read the Instructions carefully and stick to the guidelines before you start the
                        examination.</h2>
                    <br />
                    1. Your time starts once you click the start button.
                    <br />
                    <br />
                    2. After answering all the questions, click the finish button.
                    <br />
                    <br />
                    3. If you do not submit your test within the stipulated time , it will get automatically submitted.
                    <br />
                    <br />
                    4. No negative marking for wrong answers.
                    <br />
                    <br />
                    5. Marks would be divided equally when there are multiple right answers.
                    <br />
                    <br />
                    6. Mobile phones are not allowed during Examination.
                    <br />
                    <br />
                    <h2 style="font-weight: 500;"> Technical Instructions </h2>
                    <br />
                    1. Do not press <b>Alt + Tab, Ctrl + Alt + Del or Ctrl + Tab, F5</b> Shortcuts. It will be considered as malpractice. 
                    <br />
                    <br />
                    2. This exam will be considered as incomplete if you try to move out of this window or minimize or close the window.
                    <br />
                    <br />
                    3. Incomplete exams will not be considered to produce the result. In that case student has to take the exam once again.
                    <br />
                    <br />
                    4. System allows only one time login agianst each scheduled exam.
                </p>
            </div>
            <div class="clear">
            </div>
            <div class="column5">
                <span class="button dark_blue_btn"><span><span>Start</span></span>
                    <asp:Button ID="btnStart" runat="server" Text="Start" TabIndex="1" OnClick="btnStart_Click" />
                </span>
            </div>
            <div class="column8">
                <span class="button red_btn"><span><span>Exit</span></span>
                    <asp:Button ID="btnExit" runat="server" Text="Exit" TabIndex="1" OnClick="btnExit_Click" />
                </span>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
