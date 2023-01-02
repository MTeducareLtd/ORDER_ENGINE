using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using ShoppingCart.DAL;
using System.Data.SqlClient;
using ShoppingCart.BL;
using System.Configuration;
////using Encryption.BL;
namespace ShoppingCart.BL
{
    public class PaymentController
    {
        //All Functions for MT College Project

        public static DataSet GetallPaymode()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllPaymode"));
        }

        public static DataSet GetallPaymentStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllPaymentStatus"));
        }

        public static DataSet Get_Cheque_Management(string From_Date, string To_Date, string PayMode, string Ins_No, string Ins_Status, string UserId, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@From_Date", From_Date);
            SqlParameter p2 = new SqlParameter("@To_Date", To_Date);
            SqlParameter p3 = new SqlParameter("@PayMode", PayMode);
            SqlParameter p4 = new SqlParameter("@Ins_No", Ins_No);
            SqlParameter p5 = new SqlParameter("@Ins_Status", Ins_Status);
            SqlParameter p6 = new SqlParameter("@UserId", UserId);
            SqlParameter p7 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_ChequeManagement", p1, p2, p3, p4, p5, p6, p7));
        }

        public static DataSet Update_Cheque_Management(string xmlData, string UserId, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@xmlData", xmlData);
            SqlParameter p2 = new SqlParameter("@User_Id", UserId);
            SqlParameter p3 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Update_InstrumentStatus", p1, p2, p3));
        }

        public static DataSet Get_Cheque_Management_Reconcile(string Division_Code, string Zone_Code, string Centre_Code, string Acad_Year, string SBEntryCode, string ReconcileFlag, string UserId, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Zone_Code", Zone_Code);
            SqlParameter p3 = new SqlParameter("@Centre_Code", Centre_Code);
            SqlParameter p4 = new SqlParameter("@Acad_Year", Acad_Year);
            SqlParameter p5 = new SqlParameter("@SBEntryCode", SBEntryCode);
            SqlParameter p6 = new SqlParameter("@ReconcileFlag", ReconcileFlag);
            SqlParameter p7 = new SqlParameter("@UserId", UserId);
            SqlParameter p8 = new SqlParameter("@flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Cheque_Management_Reconcile", p1, p2, p3, p4, p5, p6, p7, p8));
        }

        //added by sujeer for block cheque
        public static DataSet Get_studentForRefund(string divisioncode, string acadyear, string centercode, string streamcode, string sbentrycode)
        {
            SqlParameter p1 = new SqlParameter("@Divisioncode", divisioncode);
            SqlParameter p2 = new SqlParameter("@Acadyear", acadyear);
            SqlParameter p3 = new SqlParameter("@centercode", centercode);
            SqlParameter p4 = new SqlParameter("@Streamcode", streamcode);
            SqlParameter p6 = new SqlParameter("@Sbentrycode", sbentrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Usp_Get_Studentdetails_For_Refund]", p1, p2, p3, p4,p6));
        }
        public static DataSet Update_insert_student_Refund_data(string divisioncode, string acadyear, string centercode, string sbentrycode, int amount, string remarks, string userid)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", divisioncode);
            SqlParameter p2 = new SqlParameter("@acadeyear", acadyear);
            SqlParameter p3 = new SqlParameter("@Centercode", centercode);
            SqlParameter p4 = new SqlParameter("@Sbentrycode", sbentrycode);
            SqlParameter p5 = new SqlParameter("@amount", amount);
            SqlParameter p6 = new SqlParameter("@Remarks", remarks);
            SqlParameter p7 = new SqlParameter("@CreatedBY", userid);


            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USB_Insert_update_student_Refund_details", p1, p2, p3,p4,p5,p6,p7));
        }
       //29092020
        public static DataSet Get_studentForRoboassesplusBlock(string Sbentrycode, string status, string flag)
        {
            SqlParameter p1 = new SqlParameter("@sbentrycode", Sbentrycode);
            SqlParameter p2 = new SqlParameter("@Status", status);
            SqlParameter p3 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Get_studentdata_BlockRpuls_student]", p1, p2, p3));
        }
        public static DataSet Update_insert_student_BLOCK_data(string STUDENTSTATUS, string CENTERREMARKS, string SPID, string sbentrycode, string centercode, string studentname, string userid)
        {
            SqlParameter p1 = new SqlParameter("@SPid", SPID);
            SqlParameter p2 = new SqlParameter("@sbentrycode", sbentrycode);
            SqlParameter p3 = new SqlParameter("@CenterCode", centercode);
            SqlParameter p4 = new SqlParameter("@CenterRemarks", CENTERREMARKS);
            SqlParameter p5 = new SqlParameter("@studentstatus", STUDENTSTATUS);
            SqlParameter p6 = new SqlParameter("@studentnmae", studentname);
            SqlParameter p7 = new SqlParameter("@CreatedBY", userid);


            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usb_Insert_update_blockstudent_data", p1, p2, p3, p4, p5, p6, p7));
        }
    
      
    }
}



