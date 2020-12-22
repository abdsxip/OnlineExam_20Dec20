<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExam.Master" AutoEventWireup="true"
    CodeBehind="Test.aspx.cs" Inherits="OnlineExam.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

         //When the page loses focus. It wil redirect to result page.
        $(window).bind("load", function () {
             pageLoad();
        });

        var activeElement;

        function pageLoad() {
            activeElement = document.activeElement;
            document.onfocusout = logWindow;
        }

        function logWindow() {
            if (activeElement != document.activeElement) {
                activeElement = document.activeElement;
            }
            else {
                window.location.href = "Result.aspx";
            }

        }
        //Timer Control -- Use the Timer() function in Window OnLoad event.
        var tim;
        function Timer1() {
            var min = parseInt($("#<%=hdnDuration.ClientID %>").val());
            Timer(min);
        }
        var sec = 0;

        function Timer(min) {
            if (min == 0 && sec == 0) {
                clearTimeout(tim);
                window.location.href = "Result.aspx";
            }
            else {
                if (sec < 1) {
                    sec = 59;
                    if (min > 0)
                        min = min - 1;
                }
                else
                    sec = sec - 1;
                var mins = "", secs = "";
                if (min <= 9)
                    mins = "0" + min;
                else
                    mins = min;
                if (sec <= 9)
                    secs = "0" + sec;
                else
                    secs = sec;
                var time = "Time Left : " + mins + " : " + secs;
                $("#<%=lblTimer.ClientID %>").html(time);
                tim = setTimeout('Timer(' + min + ')', 1000);
            }
        }
        window.onload = Timer1;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <div class=" float-left PageTitle">
        <img id="img" runat="server" src="~/Images/Logo.png" alt="" />
        <asp:HiddenField ID="hdnDuration" runat="server" />
        <%--<asp:HiddenField ID="hdnPrevExamDetId" runat="server" />--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksBar" runat="server">
    <div id="DivTimer" runat="server"><asp:Label ID="lblTypeId" runat="server" Visible="false"></asp:Label></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Body" runat="server">
    <%-- <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <ProgressTemplate>
                <div style="position: relative; top: 30%; text-align: center;">
                    <img src="images/loading.gif" style="vertical-align: middle" alt="Processing" />
                    Processing ...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
        BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />--%>
    <div class="section">
        <div class="title_wrapper" style="margin-left: 0;">
            <h2>
                Online Exam</h2>
            <h2 style="float: right; padding-right: 5px">
                <asp:Label ID="lblTimer" runat="server"></asp:Label>
            </h2>
        </div>
        <asp:UpdatePanel ID="upTest" runat="server" ChildrenAsTriggers="False"
            UpdateMode="Conditional">
            <ContentTemplate>
                <div class="pageWidth">
                    <div class="leftColumn">
                        <div class="Title">
                            <asp:Label ID="lblQuesNo" runat="server" Text="Questions :"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <asp:RadioButtonList ID="rdbtnQuesNo" runat="server" RepeatDirection="Horizontal"
                                RepeatColumns="4" RepeatLayout="Table" AutoPostBack="true" CssClass="rdbtnSpacing"
                                CellSpacing="10" DataTextField="SeqNo" DataValueField="ExamDetId" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="rdbtnQuesNo_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="rightColumn">
                        <div class="QuesNo">
                            <asp:Label ID="lblQuestionNo" runat="server"></asp:Label>
                        </div>
                        <div style="padding-left: 10px; float: left; font-size: 12pt;">
                            <asp:Label ID="lblQuest" runat="server" Text="Question :"></asp:Label>
                        </div>
                        <div style="padding-left: 920px; font-size: 12pt;">
                            <asp:Label ID="lblMarks" runat="server"></asp:Label></div>
                        <div class="clear">
                        </div>
                        <div class="Ques">
                            <asp:Label ID="lblQues" runat="server"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        <!---added to disply image for image type question-->
                        <asp:Panel ID="plnImage" runat="server">
                            <div class="float-left" style="width: 100%;">
                                <fieldset style="width: 120px">
                                    <legend>Image</legend>
                                    <div style="float: left; padding: 5px 4px 5px 8px;">
                                        <asp:Image ID="imgPhoto" Style="width: 1100px; height: 200px" runat="server" ImageUrl="" />
                                    </div>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <!---end of change --->
                        <div class="clear">
                        </div>
                        <div style="padding-left: 10px; float: left; font-size: 12pt;">
                            <asp:Label ID="lblOptions" runat="server" Text="Options :"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <asp:RadioButtonList ID="rdbtnAns" runat="server" RepeatDirection="Vertical" CellSpacing="10"
                                CssClass="rdbtnSpacing1" DataTextField="Desc" DataValueField="OptionSeqNo" Width="100%">
                            </asp:RadioButtonList>
                            <asp:CheckBoxList ID="chkAns" runat="server" RepeatDirection="Vertical" CellSpacing="10"
                                CssClass="rdbtnSpacing1" Visible="false" DataTextField="Desc" DataValueField="OptionSeqNo"
                                Width="100%">
                            </asp:CheckBoxList>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <div id="divFinish" runat="server" class="column6" visible="false">
                                <span class="button red_btn"><span><span>Finish</span></span>
                                    <asp:Button ID="btnFinish" runat="server" Text="Finish" TabIndex="1" OnClick="btnFinish_Click" />
                                </span>
                            </div>
                            <div id="divNext" runat="server" class="column6">
                                <span class="button dark_blue_btn"><span><span>Next</span></span>
                                    <asp:Button ID="btnNext" runat="server" Text="Next" TabIndex="1" OnClick="btnNext_Click" />
                                </span>
                            </div>
                            <div id="divPrev" runat="server" class="column6">
                                <span class="button dark_blue_btn"><span><span>Previous</span></span>
                                    <asp:Button ID="btnPrev" runat="server" Text="Previous" TabIndex="1" OnClick="btnPrev_Click" />
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="rdbtnQuesNo" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnNext" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnPrev" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
