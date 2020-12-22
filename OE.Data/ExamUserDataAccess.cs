using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using OE.Business.Entities;


namespace OE.Data
{
    public class ExamUserDataAccess
    {
        #region UserLogin
        public Student StudExmUserLogin(String username, String password,bool isModExam)
        {
            Student student = new Student();
            DataSet dsUsers = new DataSet();
            Database db = ConnectDatabase.Conn();
            String strsql = "Proc_AuthenticateStudExam";
            DbCommand userCmd = db.GetStoredProcCommand(strsql);
            db.AddInParameter(userCmd, "StudLoginId", DbType.String, username);
            // db.AddInParameter(userCmd, "Password", DbType.String, CryptoGraphy.Encrypt(password));
            db.AddInParameter(userCmd, "Password", DbType.String, password);
            db.AddInParameter(userCmd, "IsModuleTest", DbType.Boolean, isModExam);
            dsUsers = db.ExecuteDataSet(userCmd);
            if (dsUsers.Tables[0].Rows.Count > 0)
            {

                student = MapUser(dsUsers.Tables[0],isModExam);

            }
            else
            {
                student = null;
            }
            return student;
        }

        public Student MapUser(DataTable dtUser,bool isModExam)
        {
            Student student = new Student();
            DataRow drUser = dtUser.Rows[0];
            if (dtUser.Columns.Contains("ResDet_Id") && drUser["ResDet_Id"] != DBNull.Value)
            {
                student.ExamResultDetail.ExmResultDetailId = Convert.ToInt32(drUser["ResDet_Id"]);
            }
            if (dtUser.Columns.Contains("ResDet_Stud_ID") && drUser["ResDet_Stud_ID"] != DBNull.Value)
            {
                student.StudentId = Convert.ToInt32(drUser["ResDet_Stud_ID"].ToString());
            }
            if (dtUser.Columns.Contains("ResDet_Product_ID") && drUser["ResDet_Product_ID"] != DBNull.Value)
            {
                student.Product.UniqueId = Convert.ToInt32(drUser["ResDet_Product_ID"].ToString());
            }
            if (dtUser.Columns.Contains("ResDet_Sem_Id") && drUser["ResDet_Sem_Id"] != DBNull.Value)
            {
                student.ExamResultDetail.Semester.SemesterId = Convert.ToInt32(drUser["ResDet_Sem_Id"].ToString());
            }
            if (dtUser.Columns.Contains("Stud_FirstName") && drUser["Stud_FirstName"] != DBNull.Value)
            {
                student.StudentName = drUser["Stud_FirstName"].ToString();
            }
            if (dtUser.Columns.Contains("Product_Name") && drUser["Product_Name"] != DBNull.Value)
            {
                student.Product.ProductName = drUser["Product_Name"].ToString();
            }
            if (dtUser.Columns.Contains("Sem_Name") && drUser["Sem_Name"] != DBNull.Value)
            {
                student.ExamResultDetail.Semester.SemesterName = drUser["Sem_Name"].ToString();
            }
            if (dtUser.Columns.Contains("Stud_RegNo") && drUser["Stud_RegNo"] != DBNull.Value)
            {
                student.StudentRegNo = drUser["Stud_RegNo"].ToString();
            }
            if (dtUser.Columns.Contains("MaxMarks") && drUser["MaxMarks"] != DBNull.Value)
            {
                student.MaxMarks = Convert.ToInt32(drUser["MaxMarks"].ToString());
            }
            if (dtUser.Columns.Contains("PassMarks") && drUser["PassMarks"] != DBNull.Value)
            {
                student.PassMarks = Convert.ToInt32(drUser["PassMarks"].ToString());
            }
            if (dtUser.Columns.Contains("Duration") && drUser["Duration"] != DBNull.Value)
            {
                student.Duration = Convert.ToInt32(drUser["Duration"].ToString());
            }
            if (dtUser.Columns.Contains("ExSch_Id") && drUser["ExSch_Id"] != DBNull.Value)
            {
                student.ExSchId = Convert.ToInt32(drUser["ExSch_Id"].ToString());
            }
            if (dtUser.Columns.Contains("ValidTill") && drUser["ValidTill"] != DBNull.Value)
            {
                student.ValidTill = Convert.ToDateTime(drUser["ValidTill"].ToString());
            }
            if (dtUser.Columns.Contains("Centre_Id") && drUser["Centre_Id"] != DBNull.Value)
            {
                student.StudentCentre.CentreId = Convert.ToInt32(drUser["Centre_Id"].ToString());
            }
            if (dtUser.Columns.Contains("Centre_Name") && drUser["Centre_Name"] != DBNull.Value)
            {
                student.StudentCentre.CentreName = Convert.ToString(drUser["Centre_Name"].ToString());
            }
            if (dtUser.Columns.Contains("ResDet_ExStatus_Id") && drUser["ResDet_ExStatus_Id"] != DBNull.Value)
            {
                student.ExamResultDetail.status = Convert.ToInt32(drUser["ResDet_ExStatus_Id"].ToString());
            }
            if (dtUser.Columns.Contains("ISStatusAllowed") && drUser["ISStatusAllowed"] != DBNull.Value)
            {
                student.isStatus = Convert.ToBoolean(drUser["ISStatusAllowed"].ToString());
            }
            if (dtUser.Columns.Contains("IsExpired") && drUser["IsExpired"] != DBNull.Value)
            {
                student.isExpired = Convert.ToBoolean(drUser["IsExpired"].ToString());
            }
            student.isModExam = isModExam;
            return student;
        }
        #endregion

        #region GenerateQuestions
        /// <summary>
        /// Function Saves the new Generate Questions
        /// </summary>
        /// <param name="_ques"></param>
        /// <returns></returns>
        public int GenerateQuestions(int studId, int courseId, int SchId, int ResDetId, int SemId = 0,bool isModExam = false)
        {
            int success;
            Database db = ConnectDatabase.Conn();
            //string QuesXml = Utilities.Serialize(_Ques.LstQuestionOptions);
            string str = "Proc_GenerateQuestions";
            DbCommand QuesCommand = db.GetStoredProcCommand(str);
            db.AddInParameter(QuesCommand, "StudId", DbType.Int32, studId);
            db.AddInParameter(QuesCommand, "CourseId", DbType.Int32, courseId);
            if (SemId != 0)
                db.AddInParameter(QuesCommand, "SemID", DbType.Int32, SemId);
            db.AddInParameter(QuesCommand, "ScheduleId", DbType.Int32, SchId);
            db.AddInParameter(QuesCommand, "ResDetId", DbType.Int32, ResDetId);
            db.AddInParameter(QuesCommand, "IsModExam", DbType.Boolean, isModExam);

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    success = Convert.ToInt32(db.ExecuteScalar(QuesCommand, trans));
                    trans.Commit();
                    //if (dbPO.GetParameterValue(pOCommand, "PONo") != DBNull.Value)
                    //    _purchaseOrder.PONumber = Convert.ToString(dbPO.GetParameterValue(pOCommand, "PONo"));

                }
                catch (Exception)
                {
                    trans.Rollback();
                    success = 1;
                }
                finally
                {
                    conn.Close();
                }

            }
            return success;
        }
        #endregion

        #region GetQuestionaires
        /// <summary>
        /// Function returns a list of Questions allocated based on studentId and ResdetId
        /// </summary>
        /// <returns></returns>
        public List<QnStudentExamDet> GetQuestionaires(int ExamDetId, string saveAns, int TypeId, int StudId, int ResDetId, int SeqNo = 0,int Fin=0,bool isModExam = false)
        {
            DataSet dsQues = new DataSet();

            DataTable dtQues = new DataTable();
            List<QnStudentExamDet> _lstQues = new List<QnStudentExamDet>();

            Database dbQues = ConnectDatabase.Conn();
            String str = "Proc_GetQuestionnaire";
            DbCommand QuesCommand = dbQues.GetStoredProcCommand(str);
            dbQues.AddInParameter(QuesCommand, "ExamDetId", DbType.Int32, ExamDetId);
            dbQues.AddInParameter(QuesCommand, "SeqNo", DbType.String, saveAns);
            dbQues.AddInParameter(QuesCommand, "QnTypeID", DbType.Int32, TypeId);
            dbQues.AddInParameter(QuesCommand, "StudId", DbType.Int32, StudId);
            dbQues.AddInParameter(QuesCommand, "ResDetId", DbType.Int32, ResDetId);
            if (SeqNo != 0)
                dbQues.AddInParameter(QuesCommand, "QnSeqId", DbType.Int32, SeqNo);
            if (Fin != 0)
                dbQues.AddInParameter(QuesCommand, "Fin", DbType.Int32, Fin);
            dbQues.AddInParameter(QuesCommand, "IsModExam", DbType.Boolean, isModExam);
            
            dsQues = dbQues.ExecuteDataSet(QuesCommand);
            if (Fin != 1)
            {
                dtQues = dsQues.Tables[0];
                _lstQues = MapQuestions(ref dtQues);
            }
            return _lstQues;
        }

        /// <summary>
        /// Maps a Datatable to a Generic List of BatchStatus.
        /// </summary>
        /// <param name="dtBatchStatusList">DataTable to be Mapped</param>
        /// <returns></returns>
        public List<QnStudentExamDet> MapQuestions(ref DataTable dtQues)
        {
            List<QnStudentExamDet> _lstQues = new List<QnStudentExamDet>();
            foreach (DataRow drQues in dtQues.Rows)
            {
                QnStudentExamDet _questions = new QnStudentExamDet();
                if (dtQues.Columns.Contains("ExamDet_SeqNo") && drQues["ExamDet_SeqNo"] != DBNull.Value)
                {
                    _questions.SeqNo = Convert.ToInt32(drQues["ExamDet_SeqNo"]);
                }

                if (dtQues.Columns.Contains("ExamDet_Quest_Id") && drQues["ExamDet_Quest_Id"] != DBNull.Value)
                {
                    _questions.QuestionMaster.Id = Convert.ToInt32(drQues["ExamDet_Quest_Id"]);
                }
                if (dtQues.Columns.Contains("ExamDet_Id") && drQues["ExamDet_Id"] != DBNull.Value)
                {
                    _questions.ExamDetId = Convert.ToInt32(drQues["ExamDet_Id"]);
                }
                if (dtQues.Columns.Contains("Quest_Desc") && drQues["Quest_Desc"] != DBNull.Value)
                {
                    _questions.QuestionMaster.Description = Convert.ToString(drQues["Quest_Desc"]);
                }
                if (dtQues.Columns.Contains("Quest_QnType_ID") && drQues["Quest_QnType_ID"] != DBNull.Value)
                {
                    _questions.TypeId = Convert.ToInt32(drQues["Quest_QnType_ID"]);
                }
                if (dtQues.Columns.Contains("Quest_Marks") && drQues["Quest_Marks"] != DBNull.Value)
                {
                    _questions.QuestionMaster.Marks = Convert.ToInt32(drQues["Quest_Marks"]);
                }
                if (dtQues.Columns.Contains("Option_Desc") && drQues["Option_Desc"] != DBNull.Value)
                {
                    _questions.Desc = Convert.ToString(drQues["Option_Desc"]);
                }
                if (dtQues.Columns.Contains("Option_SeqNo") && drQues["Option_SeqNo"] != DBNull.Value)
                {
                    _questions.OptionSeqNo = Convert.ToInt32(drQues["Option_SeqNo"]);
                }
                if (dtQues.Columns.Contains("IsAnswer") && drQues["IsAnswer"] != DBNull.Value)
                {
                    _questions.isSelected = Convert.ToBoolean(drQues["IsAnswer"]);
                }
                if (dtQues.Columns.Contains("Quest_imgFileName") && drQues["Quest_imgFileName"] != DBNull.Value)
                {
                    _questions.QuestionMaster.ImgFileName = Convert.ToString(drQues["Quest_imgFileName"]);
                }

                _lstQues.Add(_questions);
            }
            return _lstQues;
        }
        #endregion

        #region ViewQuestion
        /// <summary>
        /// Function returns a list of Question Details
        /// </summary>
        /// <returns>List</returns>

        public void ViewQuestion(int QuestId, ref QuestionMaster _QueslateDetails, ref List<QuestionOptions> lstQuesDetails)
        {
            DataSet dsViewquesDetails = new DataSet();
            Database dbViewquesDetails = ConnectDatabase.Conn();
            String sqlDetails = "Proc_ViewQuestion";
            DbCommand quesDetailsCmd = dbViewquesDetails.GetStoredProcCommand(sqlDetails);
            dbViewquesDetails.AddInParameter(quesDetailsCmd, "QuestId", DbType.Int32, QuestId);

            dsViewquesDetails = dbViewquesDetails.ExecuteDataSet(quesDetailsCmd);
            if (dsViewquesDetails.Tables.Count > 0)
            {
                _QueslateDetails = Mapqueslate(dsViewquesDetails.Tables[0]);
                lstQuesDetails = MapquesDetails(dsViewquesDetails.Tables[1]);
            }

        }

        /// <summary>
        /// Maps a Datatable to a Generic List of Questions
        /// </summary>
        /// <param name="dtquesDetails"></param>
        /// <returns>List</returns>
        public QuestionMaster Mapqueslate(DataTable dtquesDetails)
        {
            QuestionMaster _question = new QuestionMaster();
            foreach (DataRow drques in dtquesDetails.Rows)
            {
                if (dtquesDetails.Columns.Contains("Quest_Id") && drques["Quest_Id"] != DBNull.Value)
                {
                    _question.Id = Convert.ToInt32(drques["Quest_Id"]);
                }
                if (dtquesDetails.Columns.Contains("Product_Id") && drques["Product_Id"] != DBNull.Value)
                {
                    _question.Product.UniqueId = Convert.ToInt32(drques["Product_Id"]);
                }
                if (dtquesDetails.Columns.Contains("QnType_Id") && drques["QnType_Id"] != DBNull.Value)
                {
                    _question.typeId = Convert.ToInt32(drques["QnType_Id"]);
                }
                if (dtquesDetails.Columns.Contains("Sem_Id") && drques["Sem_Id"] != DBNull.Value)
                {
                    _question.Semester.SemesterId = Convert.ToInt32(drques["Sem_Id"]);
                }
                if (dtquesDetails.Columns.Contains("Quest_Complexity") && drques["Quest_Complexity"] != DBNull.Value)
                {
                    _question.Complexity = Convert.ToChar(drques["Quest_Complexity"]);
                }
                if (dtquesDetails.Columns.Contains("Quest_Desc") && drques["Quest_Desc"] != DBNull.Value)
                {
                    _question.Description = Convert.ToString(drques["Quest_Desc"]);
                }
                if (dtquesDetails.Columns.Contains("Quest_Marks") && drques["Quest_Marks"] != DBNull.Value)
                {
                    _question.Marks = Convert.ToInt32(drques["Quest_Marks"]);
                }
                if (dtquesDetails.Columns.Contains("Quest_IsActive") && drques["Quest_IsActive"] != DBNull.Value)
                {
                    _question.IsActive = Convert.ToBoolean(drques["Quest_IsActive"]);
                }
                if (dtquesDetails.Columns.Contains("Quest_IsNegativeMark") && drques["Quest_IsNegativeMark"] != DBNull.Value)
                {
                    _question.IsNegativeMark = Convert.ToBoolean(drques["Quest_IsNegativeMark"]);
                }
            }
            return _question;
        }
        public List<QuestionOptions> MapquesDetails(DataTable dtquesOptDetails)
        {
            List<QuestionOptions> _lstquesOpt = new List<QuestionOptions>();

            foreach (DataRow drquesDetails in dtquesOptDetails.Rows)
            {
                QuestionOptions _quesDetails = new QuestionOptions();

                if (dtquesOptDetails.Columns.Contains("Option_Id") && drquesDetails["Option_Id"] != DBNull.Value)
                {
                    _quesDetails.OptionId = Convert.ToInt32(drquesDetails["Option_Id"]);
                }
                if (dtquesOptDetails.Columns.Contains("Option_SeqNo") && drquesDetails["Option_SeqNo"] != DBNull.Value)
                {
                    _quesDetails.SequenceNo = Convert.ToInt32(drquesDetails["Option_SeqNo"]);
                }
                if (dtquesOptDetails.Columns.Contains("Option_Desc") && drquesDetails["Option_Desc"] != DBNull.Value)
                {
                    _quesDetails.Description = Convert.ToString(drquesDetails["Option_Desc"]);
                }
                if (dtquesOptDetails.Columns.Contains("Option_IsAnswer") && drquesDetails["Option_IsAnswer"] != DBNull.Value)
                {
                    _quesDetails.IsAnswer = Convert.ToBoolean(drquesDetails["Option_IsAnswer"]);
                }

                _lstquesOpt.Add(_quesDetails);
            }
            return _lstquesOpt;
        }

        #endregion

        #region SaveAnswers
        ///<summary>
        ///Functions Saves the Answers to QnStudExamResult
        ///</summary>
        ///<param name="_Answer"></param>
        ///<return></return>
        public int SaveAnswer(int ExamDetId, string SeqNo, int TypeId)
        {
            int success;
            Database db = ConnectDatabase.Conn();
            string str = "Proc_SaveAnswer";
            DbCommand ExResCommand = db.GetStoredProcCommand(str);
            db.AddInParameter(ExResCommand, "ExamDetId", DbType.Int32, ExamDetId);
            db.AddInParameter(ExResCommand, "SeqNo", DbType.String, SeqNo);
            db.AddInParameter(ExResCommand, "QnTypeID", DbType.Int32, TypeId);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    success = Convert.ToInt32(db.ExecuteScalar(ExResCommand, trans));
                    trans.Commit();

                }
                catch (Exception)
                {
                    trans.Rollback();
                    success = 1;
                }
                finally
                {
                    conn.Close();
                }

            }
            return success;
        }
        #endregion

        #region Update Result
        ///<summary>
        ///Functions Saves the Result
        ///</summary>
        ///<param name="_Answer"></param>
        ///<return></return>
        public int UpdateResult(int ResDetId, int StudId, string fileName, bool IsModuleTest=false)
        {
            int success;
            Database db = ConnectDatabase.Conn();
            string str = "Proc_UpdateExamResult";
            DbCommand ResDetCommand = db.GetStoredProcCommand(str);
            db.AddInParameter(ResDetCommand, "ResDetId", DbType.Int32, ResDetId);
            db.AddInParameter(ResDetCommand, "StudentId", DbType.Int32, StudId);
            db.AddInParameter(ResDetCommand, "FileName", DbType.String, fileName);
            db.AddInParameter(ResDetCommand, "IsModuleTest", DbType.Boolean, IsModuleTest);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    success = Convert.ToInt32(db.ExecuteScalar(ResDetCommand, trans));
                    trans.Commit();

                }
                catch (Exception)
                {
                    trans.Rollback();
                    success = 1;
                }
                finally
                {
                    conn.Close();
                }

            }
            return success;
        }

        #endregion

        #region Print result RDLC
        //get Company infor as Dataset for result print in Nov-2020
        public DataSet GetCompInfo()
        {
            DataSet dsCompInfo = new DataSet();
            Database dbCompInfo = ConnectDatabase.Conn();
            String sqlDetails = "Proc_RptCompInfo";
            DbCommand cmdCompInfo = dbCompInfo.GetStoredProcCommand(sqlDetails);
            //dbCompInfo.AddInParameter(CompInfo, "QuestId", DbType.Int32, QuestId);

            dsCompInfo = dbCompInfo.ExecuteDataSet(cmdCompInfo);
            return dsCompInfo;
        }
        //get result output as Dataset for result print added in Nov-2020
        public DataSet GetExamResultPrint(int ResDetId, int StudId, int table, bool IsModuleTest = false)
        {
            DataSet dsResPrint = new DataSet();
            Database dbCompInfo = ConnectDatabase.Conn();
            String sqlDetails = "Proc_RptExamResultPrint";
            DbCommand cmdResPrint = dbCompInfo.GetStoredProcCommand(sqlDetails);
            dbCompInfo.AddInParameter(cmdResPrint, "StudentId", DbType.Int32, StudId);
            dbCompInfo.AddInParameter(cmdResPrint, "ResDetId", DbType.Int32, ResDetId);
            dbCompInfo.AddInParameter(cmdResPrint, "table", DbType.Int32, table);
            dbCompInfo.AddInParameter(cmdResPrint, "isModExam", DbType.Boolean, IsModuleTest);

            dsResPrint = dbCompInfo.ExecuteDataSet(cmdResPrint);
            return dsResPrint;
        }
        #endregion
    }
}
