using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OE.Business.Entities;
using OE.Data;
using System.Data;

namespace OE.Business.Components
{
    public class ExamUserComponent
    {
        ExamUserDataAccess eud = new ExamUserDataAccess();
        public Student StudExmUserLogin(String username, String password,bool isModExm)
        {
            return eud.StudExmUserLogin(username, password,isModExm);
        }
        public int GenerateQuestions(int studId, int courseId, int SchId, int ResDetId,int SemId=0,bool isModExam = false)
        {
            return eud.GenerateQuestions(studId, courseId, SchId, ResDetId, SemId, isModExam);
        }
        public List<QnStudentExamDet> GetQuestionaires(int ExamDetId, string saveAns, int TypeId, int StudId, int ResDetId, int SeqNo = 0, int Fin = 0, bool isModExam = false)
        {
            return eud.GetQuestionaires(ExamDetId, saveAns, TypeId, StudId, ResDetId, SeqNo, Fin,isModExam);
        }
        public void ViewQuestion(int QuestId, ref QuestionMaster _QueslateDetails, ref List<QuestionOptions> lstQuesDetails)
        {
            eud.ViewQuestion(QuestId, ref _QueslateDetails, ref lstQuesDetails);
        }
        public int SaveAnswer(int ExamDetId, string SeqNo, int TypeId)
        {
            return eud.SaveAnswer(ExamDetId, SeqNo, TypeId);
        }
        public int UpdateResult(int ResDetId, int StudId, string fileName, bool IsModuleTest = false)
        {
            return eud.UpdateResult(ResDetId, StudId, fileName, IsModuleTest);
        }
        //Required for calling DS for RDLC
        public DataSet GetCompInfo()
        {
            return eud.GetCompInfo();
        }
        //Required for calling DS for RDLC
        public DataSet GetExamResultPrint(int ResDetId, int StudId, int table, bool IsModuleTest = false)
        {
            return eud.GetExamResultPrint(ResDetId, StudId, table, IsModuleTest);
        }
    }
    
}
