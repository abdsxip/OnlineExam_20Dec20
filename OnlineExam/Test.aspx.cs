﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineExam.Common;
using OE.Business.Components;
using OE.Business.Entities;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Net;

namespace OnlineExam
{
    public partial class Test : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int studId = CurrentSession.CurrStudent.StudentId;
                int CourseId = CurrentSession.CurrStudent.Product.UniqueId;
                int SemId = CurrentSession.CurrStudent.ExamResultDetail.Semester.SemesterId;
                int SchId = CurrentSession.CurrStudent.ExSchId;
                int ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
                bool isModExam = CurrentSession.CurrStudent.isModExam;
                ExamUserComponent euc = new ExamUserComponent();
                int success = 0;

                success = euc.GenerateQuestions(studId, CourseId, SchId, ResDetId, SemId, isModExam);

                rdbtnQuesNo.DataSource = euc.GetQuestionaires(1, "1", 1, studId, ResDetId, 0, 0, isModExam);
                rdbtnQuesNo.DataBind();
                rdbtnQuesNo.SelectedIndex = 0;
                //GetQuestions();
                int SeqNo = Convert.ToInt32(rdbtnQuesNo.SelectedItem.Text);

                SaveAnswerAndGetQuestion(1, "NoSave", 1, studId, ResDetId, SeqNo, 0, isModExam);
                divPrev.Visible = false;

                CurrentSession.ExamPrevId = rdbtnQuesNo.SelectedValue;
                //hdnPrevExamDetId.Value = rdbtnQuesNo.SelectedValue;
                //Session["PrevExamDetId"] = rdbtnQuesNo.SelectedValue;
                //ViewState["seconds"] = 0;
                hdnDuration.Value = CurrentSession.CurrStudent.Duration.ToString();
            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //SaveAnswers(Convert.ToInt32(rdbtnQuesNo.SelectedValue));
            //divPrev.Visible = true;
            //int count = rdbtnQuesNo.Items.Count;
            //int index = rdbtnQuesNo.SelectedIndex;
            //index = index + 1;
            //if (count == index + 1)
            //{
            //    divNext.Visible = false;
            //    divFinish.Visible = true;
            //}
            //rdbtnQuesNo.SelectedIndex = index;
            //ViewState["PrevExamDetId"] = rdbtnQuesNo.SelectedValue;
            //GetQuestions();

            int ExamDetId, typeId, StudId, ResDetId, SeqNo, index;
            string Ans = "";
            StudId = CurrentSession.CurrStudent.StudentId;
            ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
            ExamDetId = Convert.ToInt32(rdbtnQuesNo.SelectedValue);
            typeId = Convert.ToInt32(lblTypeId.Text);
            bool isModExam = CurrentSession.CurrStudent.isModExam;

            if (typeId == 1)
            {
                Ans = rdbtnAns.SelectedValue;
            }
            else
            {
                foreach (ListItem lst in chkAns.Items)
                {
                    if (lst.Selected)
                    {
                        Ans += lst.Value + ",";
                    }
                }
            }
            index = rdbtnQuesNo.SelectedIndex;
            divPrev.Visible = true;
            int count = rdbtnQuesNo.Items.Count;
            //int index = rdbtnQuesNo.SelectedIndex;
            index = index + 1;
            if (count == index + 1)
            {
                divNext.Visible = false;
                divFinish.Visible = true;
            }
            rdbtnQuesNo.SelectedIndex = index;
            CurrentSession.ExamPrevId = rdbtnQuesNo.SelectedValue;

            //Session["PrevExamDetId"] = rdbtnQuesNo.SelectedValue;
            //hdnPrevExamDetId.Value = rdbtnQuesNo.SelectedValue;
            //divFinish.Visible = false;
            SeqNo = Convert.ToInt32(rdbtnQuesNo.SelectedItem.Text);

            SaveAnswerAndGetQuestion(ExamDetId, Ans, typeId, StudId, ResDetId, SeqNo, 0, isModExam);

        }
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            //SaveAnswers(Convert.ToInt32(rdbtnQuesNo.SelectedValue));
            //divNext.Visible = true;
            //int index = rdbtnQuesNo.SelectedIndex;
            //if (rdbtnQuesNo.SelectedIndex == 1)
            //    divPrev.Visible = false;

            //index = index - 1;
            //rdbtnQuesNo.SelectedIndex = index;
            //ViewState["PrevExamDetId"] = rdbtnQuesNo.SelectedValue;
            //divFinish.Visible = false;
            //GetQuestions();

            int ExamDetId, typeId, StudId, ResDetId, SeqNo, index;
            string Ans = "";
            StudId = CurrentSession.CurrStudent.StudentId;
            ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
            ExamDetId = Convert.ToInt32(rdbtnQuesNo.SelectedValue);
            typeId = Convert.ToInt32(lblTypeId.Text);
            bool isModExam = CurrentSession.CurrStudent.isModExam;

            if (typeId == 1)
            {
                Ans = rdbtnAns.SelectedValue;
            }
            else
            {
                foreach (ListItem lst in chkAns.Items)
                {
                    if (lst.Selected)
                    {
                        Ans += lst.Value + ",";
                    }
                }
            }
            index = rdbtnQuesNo.SelectedIndex;
            divNext.Visible = true;
            if (rdbtnQuesNo.SelectedIndex == 1)
                divPrev.Visible = false;
            index = index - 1;
            rdbtnQuesNo.SelectedIndex = index;

            CurrentSession.ExamPrevId = rdbtnQuesNo.SelectedValue;

            //Session["PrevExamDetId"] = rdbtnQuesNo.SelectedValue;
            //hdnPrevExamDetId.Value = rdbtnQuesNo.SelectedValue;
            divFinish.Visible = false;
            SeqNo = Convert.ToInt32(rdbtnQuesNo.SelectedItem.Text);

            SaveAnswerAndGetQuestion(ExamDetId, Ans, typeId, StudId, ResDetId, SeqNo, 0, isModExam);

        }
        private void SaveAnswerAndGetQuestion(int ExamDetId, string Answer, int TypeId, int StudId, int ResDetId, int SeqId = 0, int fin = 0, bool isModExam = false)
        {
            ExamUserComponent euc = new ExamUserComponent();

            List<QnStudentExamDet> lstExamDet = new List<QnStudentExamDet>();
            lstExamDet = euc.GetQuestionaires(ExamDetId, Answer, TypeId, StudId, ResDetId, SeqId, fin, isModExam);

            if (fin != 1)
            {
                lblMarks.Text = "Marks : " + lstExamDet[0].QuestionMaster.Marks.ToString();
                lblQues.Text = Server.HtmlEncode(lstExamDet[0].QuestionMaster.Description);
                string QuesNo;
                QuesNo = rdbtnQuesNo.SelectedItem.Text;
                lblQuestionNo.Text = "Question No : " + QuesNo;
                lblTypeId.Text = lstExamDet[0].TypeId.ToString();
                if (lstExamDet[0].TypeId == 1)
                {
                    rdbtnAns.Visible = true;
                    chkAns.Visible = false;
                    rdbtnAns.DataSource = lstExamDet;
                    rdbtnAns.DataBind();
                    foreach (ListItem rdnlst in rdbtnAns.Items)
                    {
                        rdnlst.Text = Server.HtmlEncode(rdnlst.Text);
                    }
                    foreach (QnStudentExamDet _examDet in lstExamDet)
                    {
                        if (_examDet.isSelected == true)
                        {
                            rdbtnAns.SelectedValue = _examDet.OptionSeqNo.ToString();
                            break;
                        }
                    }

                    //Abdul
                    if (lstExamDet[0].QuestionMaster.ImgFileName != null)//code to show image from solution folder
                    {

                        //string path = Server.MapPath("~/QuestImage/" + lstExamDet[0].QuestionMaster.ImgFileName);
                        string path = ConfigurationManager.AppSettings["QstImgUrl"].ToString() + lstExamDet[0].QuestionMaster.ImgFileName;

                        if (File.Exists(path))
                        {
                            plnImage.Visible = true;

                            string photoName = lstExamDet[0].QuestionMaster.ImgFileName;
                            string filenopic = string.Format("~/QuestImage/" + photoName, photoName, "e");
                            imgPhoto.ImageUrl = path; //filenopic;
                        }
                        else
                        {
                            plnImage.Visible = false;

                        }

                    }
                    else
                    {
                        imgPhoto.ImageUrl = "";
                        plnImage.Visible = false;
                    }

                    //Abdul

                }
                else
                {
                    rdbtnAns.Visible = false;
                    chkAns.Visible = true;
                    chkAns.DataSource = lstExamDet;
                    chkAns.DataBind();
                    foreach (ListItem chklst in chkAns.Items)
                    {
                        chklst.Text = Server.HtmlEncode(chklst.Text);
                    }
                    int i;
                    for (i = 0; i < lstExamDet.Count; i++)
                    {
                        if (chkAns.Items[i].Value == lstExamDet[i].OptionSeqNo.ToString())
                        {
                            if (lstExamDet[i].isSelected)
                                chkAns.Items[i].Selected = true;
                        }
                        //if (_examDet.isSelected == true)
                        //    chkAns.SelectedValue = _examDet.OptionSeqNo.ToString();

                    }
                    //Abdul
                    if (lstExamDet[0].QuestionMaster.ImgFileName != null)//code to show image from solution folder
                    {
                        string newpath = Server.MapPath("~/QuestImage/" + lstExamDet[0].QuestionMaster.ImgFileName);
                        string srcPath = ConfigurationManager.AppSettings["QstImgUrl"].ToString() + lstExamDet[0].QuestionMaster.ImgFileName;

                        getImage(srcPath, newpath);
                        if (File.Exists(newpath))
                        {
                            plnImage.Visible = true;

                            string photoName = lstExamDet[0].QuestionMaster.ImgFileName;
                            string filenopic = string.Format("~/QuestImage/" + photoName, photoName, "e");
                            imgPhoto.ImageUrl = filenopic;
                        }
                        else
                        {
                            plnImage.Visible = false;
                        }
                    }
                    else
                    {
                        imgPhoto.ImageUrl = "";
                        plnImage.Visible = false;
                    }
                    //Abdul
                }
            }
        }
        
        protected void rdbtnQuesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ExamDetId, typeId, StudId, ResDetId, SeqNo, index, count;
            string Ans = "";
            StudId = CurrentSession.CurrStudent.StudentId;
            ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
            //ExamDetId = Convert.ToInt32(Session["PrevExamDetId"]);
            ExamDetId = Convert.ToInt32(CurrentSession.ExamPrevId);
            typeId = Convert.ToInt32(lblTypeId.Text);
            bool isModExam = CurrentSession.CurrStudent.isModExam;
            //hdnPrevExamDetId.Value = rdbtnQuesNo.SelectedValue;
            //Session["PrevExamDetId"] = rdbtnQuesNo.SelectedValue;
            CurrentSession.ExamPrevId = rdbtnQuesNo.SelectedValue;
            count = rdbtnQuesNo.Items.Count;
            index = rdbtnQuesNo.SelectedIndex;

            divFinish.Visible = false;
            if (index == 0)
            {
                divPrev.Visible = false;
                divNext.Visible = true;
            }
            else if (count == index + 1)
            {
                divPrev.Visible = true;
                divNext.Visible = false;
                divFinish.Visible = true;
            }
            else
            {
                divPrev.Visible = true;
                divNext.Visible = true;
            }

            if (typeId == 1)
            {
                Ans = rdbtnAns.SelectedValue;
            }
            else
            {
                foreach (ListItem lst in chkAns.Items)
                {
                    if (lst.Selected)
                    {
                        Ans += lst.Value + ",";
                    }
                }
            }
            SeqNo = Convert.ToInt32(rdbtnQuesNo.SelectedItem.Text);

            SaveAnswerAndGetQuestion(ExamDetId, Ans, typeId, StudId, ResDetId, SeqNo, 0, isModExam);
        }
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            //UpdateResult();
            //SaveAnswers(Convert.ToInt32(rdbtnQuesNo.SelectedValue));
            CurrentSession.RemoveSession(CurrentSession.ExamPrevId);
            int ExamDetId = Convert.ToInt32(rdbtnQuesNo.SelectedValue);
            int typeId = Convert.ToInt32(lblTypeId.Text);
            string Ans = "";
            if (typeId == 1)
            {
                Ans = rdbtnAns.SelectedValue;
            }
            else
            {
                foreach (ListItem lst in chkAns.Items)
                {
                    if (lst.Selected)
                    {
                        Ans += lst.Value + ",";
                    }
                }
            }
            SaveAnswerAndGetQuestion(ExamDetId, Ans, typeId, 1, 1, 1, 1);
            Response.Redirect("Result.aspx");
            //ScriptManager.RegisterClientScriptBlock(this,this.GetType(), "Close", "btnFinish_Click()", true);
        }

        private void getImage(string path,string newPath)   //ref string newPath
        {

            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData("http://localhost/image.gif");
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            img.Save(newPath);

            //using (WebClient webClient = new WebClient())
            //{
            //    byte[] data = webClient.DownloadData("https://fbcdn-sphotos-h-a.akamaihd.net/hphotos-ak-xpf1/v/t34.0-12/10555140_10201501435212873_1318258071_n.jpg?oh=97ebc03895b7acee9aebbde7d6b002bf&oe=53C9ABB0&__gda__=1405685729_110e04e71d9");

            //    using (MemoryStream mem = new MemoryStream(data))
            //    {
            //        using (var yourImage = Image.FromStream(mem))
            //        {
            //            // If you want it as Png
            //            yourImage.Save("path_to_your_file.png", ImageFormat.Png);

            //            // If you want it as Jpeg
            //            yourImage.Save("path_to_your_file.jpg", ImageFormat.Jpeg);
            //        }
            //    }

            //}
        }

        //private void GetQuestions()
        //{
        //    ExamUserComponent euc = new ExamUserComponent();
        //    int studId = CurrentSession.CurrStudent.StudentId;
        //    int ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
        //    int SeqNo = Convert.ToInt32(rdbtnQuesNo.SelectedItem.Text);

        //    List<QnStudentExamDet> lstExamDet = new List<QnStudentExamDet>();
        //    lstExamDet = euc.GetQuestionaires(studId, ResDetId, SeqNo);


        //    lblMarks.Text = "Marks : " + lstExamDet[0].QuestionMaster.Marks.ToString();
        //    lblQues.Text = lstExamDet[0].QuestionMaster.Description;
        //    string QuesNo;
        //    QuesNo = rdbtnQuesNo.SelectedItem.Text;
        //    lblQuestionNo.Text = "Question No : " + QuesNo;
        //    lblTypeId.Text = lstExamDet[0].TypeId.ToString();
        //    if (lstExamDet[0].TypeId == 1)
        //    {
        //        rdbtnAns.Visible = true;
        //        chkAns.Visible = false;
        //        rdbtnAns.DataSource = lstExamDet;
        //        rdbtnAns.DataBind();
        //        foreach (QnStudentExamDet _examDet in lstExamDet)
        //        {
        //            if (_examDet.isSelected == true)
        //            {
        //                rdbtnAns.SelectedValue = _examDet.OptionSeqNo.ToString();
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        rdbtnAns.Visible = false;
        //        chkAns.Visible = true;
        //        chkAns.DataSource = lstExamDet;
        //        chkAns.DataBind();
        //        int i;
        //        for (i = 0; i < lstExamDet.Count; i++)
        //        {
        //            if (chkAns.Items[i].Value == lstExamDet[i].OptionSeqNo.ToString())
        //            {
        //                if (lstExamDet[i].isSelected)
        //                    chkAns.Items[i].Selected = true;
        //            }
        //            //if (_examDet.isSelected == true)
        //            //    chkAns.SelectedValue = _examDet.OptionSeqNo.ToString();

        //        }
        //    }
        //}
        //private void SaveAnswers(int ExamDetId)
        //{

        //    ExamUserComponent euc = new ExamUserComponent();

        //    //int ExmDetId = Convert.ToInt32(ViewState["PrevExamDetId"]);//rdbtnQuesNo.SelectedValue);
        //    string SeqNo = "";
        //    int TypeId = Convert.ToInt32(lblTypeId.Text);
        //    if (TypeId == 1)
        //    {
        //        SeqNo = rdbtnAns.SelectedValue;
        //    }
        //    else
        //    {
        //        foreach (ListItem lst in chkAns.Items)
        //        {
        //            if (lst.Selected)
        //            {
        //                SeqNo += lst.Value + ",";
        //            }
        //        }
        //    }

        //    int success;
        //    success = euc.SaveAnswer(ExamDetId, SeqNo, TypeId);

        //}
        //private void UpdateResult()
        //{
        //    int ResDetId = CurrentSession.CurrStudent.ExamResultDetail.ExmResultDetailId;
        //    int StudId = CurrentSession.CurrStudent.StudentId;
        //    string getDate = DateTime.Now.ToString("dd-MM-yyyy");
        //    string getTime = DateTime.Now.ToShortTimeString();
        //    getTime = getTime.Replace(":", "");
        //    string fileName = "EXM" + "_" + getDate + "_" + getTime;
        //    Session["fileName"] = fileName;
        //    ExamUserComponent ec = new ExamUserComponent();

        //    int success;
        //    success = ec.UpdateResult(ResDetId, StudId, fileName);
        //}

        //SaveAnswers(Convert.ToInt32(ViewState["PrevExamDetId"]));
        //ViewState["PrevExamDetId"] = rdbtnQuesNo.SelectedValue;

        //int index = rdbtnQuesNo.SelectedIndex;
        //divFinish.Visible = false;
        //if (index == 0)
        //{
        //    divPrev.Visible = false;
        //    divNext.Visible = true;
        //}
        //else if (count == index + 1)
        //{
        //    divPrev.Visible = true;
        //    divNext.Visible = false;
        //    divFinish.Visible = true;
        //}
        //else
        //{
        //    divPrev.Visible = true;
        //    divNext.Visible = true;
        //}

        //GetQuestions();
    }
}