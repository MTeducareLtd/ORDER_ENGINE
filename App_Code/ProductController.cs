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
    public class ProductController
    {
        //All Functions for MT College Project

        //'Function to get Menu
        public static DataSet GetMenu(int Flag, string Userid)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@Userid", Userid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_U002_Get_Master_Menu_Detail", p1, p2));
        }
        public static DataSet Getleadoppsummary(int Flag, string Userid, string Company)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@Userid", Userid);
            SqlParameter p3 = new SqlParameter("@company", Company);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_lead_opp_summary", p1, p2, p3));
        }



        public static DataSet GetAdmissionDashboard(string Userid, string AcadYear)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_PENDING_AGEING", p1, p2));
        }

        public static DataSet GetPendingAdmissionAgeing(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_PENDING_AGEING_II", p1, p2, p3, p4));
        }

        public static DataSet GetPendingAdmission(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_STREAMWISE_PENDING_ADMISSION_COUNT", p1, p2, p3, p4));
        }

        public static DataSet GetECS_Pending_Status(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ECS_STATUS", p1, p2, p3, p4));
        }

        public static DataSet GetFees_Deductions(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_DEDUCTIONS_BY_CENTERS", p1, p2, p3, p4));
        }

        public static DataSet GetPendingApprovalCount(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ALL_PENDING_APPROVALS", p1, p2, p3, p4));
        }

        public static DataSet GetECSDone(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ECS", p1, p2, p3, p4));
        }

        public static DataSet GetECS_Rejected(string Userid, string AcadYear, string DivisionCode, string CenterCode, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            SqlParameter p5 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ECS_Dashboard_Detail", p1, p2, p3, p4, p5));
        }

        public static DataSet GetCancelledAdmission(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_STREAMWISE_CANCELLED_ADMISSION_COUNT", p1, p2, p3, p4));
        }

        public static DataSet Get_Bounced_Account(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ALL_BOUNCE_CHEQUE", p1, p2, p3, p4));
        }

        public static DataSet GetCancelledAdmission_Detail(string Userid, string AcadYear, string PKey, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@PKey", PKey);
            SqlParameter p4 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_STREAMWISE_CANCELLED_ADMISSION_DETAIL", p1, p2, p3, p4));
        }

        public static DataSet GetStudentCategoryDashboard(string Userid)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_GET_OPPORTUNITY_DASHBOARD_DRILL]", p1));
        }


        public static DataSet Get_Menu_Items(int Flag, string Menu_Id, string Userid)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@Menu_id", Menu_Id);
            SqlParameter p3 = new SqlParameter("@userid", Userid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Menu_Items", p1, p2, p3));
        }

        public static string GerrolebyUserid(string Userid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[0].Value = Userid;
            p[1] = new SqlParameter("@roleid", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetRolebyUserid", p);
            return (p[1].Value.ToString());
        }

        public static string GetUserAction(string Userid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@UserCode", SqlDbType.NVarChar);
            p[0].Value = Userid;
            p[1] = new SqlParameter("@ActionCode", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_User_Action", p);
            return (p[1].Value.ToString());
        }

        public static DataSet GetCenterbyUserid(string Username)
        {
            SqlParameter P = new SqlParameter("@usr_id", SqlDbType.VarChar);
            P.Value = Username;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCentreby_Userid", P));
        }

        public static void Block(string userid, string Leadid, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@userid", userid);
            SqlParameter p2 = new SqlParameter("@blockid", Leadid);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Block", p1, p2, p3);
        }
        public static void Removerecordsifexists(string Oppid, int Flag, string Materialtype, string Orderno)
        {
            SqlParameter p1 = new SqlParameter("@Oppid", Oppid);
            SqlParameter P2 = new SqlParameter("@flag", Flag);
            SqlParameter P3 = new SqlParameter("@material_type", Materialtype);
            SqlParameter P4 = new SqlParameter("@Orderno", Orderno);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_delete_material", p1, P2, P3, P4);
        }

        public static void Removerecordsifexists_Event(string Oppid, int Flag, string Materialtype, string Orderno)
        {
            SqlParameter p1 = new SqlParameter("@Oppid", Oppid);
            SqlParameter P2 = new SqlParameter("@flag", Flag);
            SqlParameter P3 = new SqlParameter("@material_type", Materialtype);
            SqlParameter P4 = new SqlParameter("@Orderno", Orderno);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_delete_material_Event", p1, P2, P3, P4);
        }

        //Public Shared Sub InsertAddandRemoveItem(ByVal SBEntrycode As String, ByVal Subjectgrp As String, ByVal Flag As Integer)
        //    Dim p1 As New SqlParameter("@sbentrycode", SBENtrycode)
        //    Dim p2 As New SqlParameter("@subjectgrp", Subjectgrp)
        //    Dim p3 As New SqlParameter("@flag", Flag)
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Add_Event_E02_P02", p1, p2, p3)
        //End Sub
        public static void InsertAddandRemoveItem(string SBEntrycode, string Stream, int Flag, string Orderno)
        {
            SqlParameter p1 = new SqlParameter("@sbentrycode", SBEntrycode);
            SqlParameter p2 = new SqlParameter("@Stream", Stream);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            SqlParameter p4 = new SqlParameter("@Orderno", Orderno);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Add_Event_E02_P02", p1, p2, p3, p4);
        }

        public static void InsertRemoveItem(string SBEntrycode, string Stream, int Flag, string Orderno)
        {
            SqlParameter p1 = new SqlParameter("@sbentrycode", SBEntrycode);
            SqlParameter p2 = new SqlParameter("@Stream", Stream);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            SqlParameter p4 = new SqlParameter("@Orderno", Orderno);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Add_Event_E03_P03", p1, p2, p3, p4);
        }

        public static void Insertchequeallocation(string PPCode, string AMt, string sbentrycode, string Chqno, int Flag, string payeeid, string rcptid)
        {
            SqlParameter p1 = new SqlParameter("@ppcode", PPCode);
            SqlParameter p2 = new SqlParameter("@amt", AMt);
            SqlParameter p3 = new SqlParameter("@sbentrycode", sbentrycode);
            SqlParameter p4 = new SqlParameter("@chqno", Chqno);
            SqlParameter p5 = new SqlParameter("@flag", Flag);
            SqlParameter p6 = new SqlParameter("@payee_id", payeeid);
            SqlParameter p7 = new SqlParameter("@rcpt_id", rcptid);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_cheque_entry", p1, p2, p3, p4, p5, p6, p7);
        }
        //Public Shared Function GerrolebyUserid(ByVal userid As String) As DataSet
        //    Dim P As New SqlParameter("@Userid", SqlDbType.NVarChar)
        //    P.Value = userid
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetRolebyUserid", P))
        //End Function

        public static string CheckDuplicateAppno(string Company, string Division, string Center, string Stream, string Appno)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@company", SqlDbType.NVarChar);
            p[0].Value = Company;
            p[1] = new SqlParameter("@division", SqlDbType.NVarChar);
            p[1].Value = Division;
            p[2] = new SqlParameter("@center", SqlDbType.NVarChar);
            p[2].Value = Center;
            p[3] = new SqlParameter("@stream", SqlDbType.NVarChar);
            p[3].Value = Stream;
            p[4] = new SqlParameter("@app_no", SqlDbType.NVarChar);
            p[4].Value = Appno;
            p[5] = new SqlParameter("@flag", SqlDbType.NVarChar, 100);
            p[5].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_CheckAppNo", p);
            return (p[5].Value.ToString());
        }

        public static string CheckDuplicateAppnoreturnoppid(string Company, string Division, string Center, string Stream, string Appno)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@company", SqlDbType.NVarChar);
            p[0].Value = Company;
            p[1] = new SqlParameter("@division", SqlDbType.NVarChar);
            p[1].Value = Division;
            p[2] = new SqlParameter("@center", SqlDbType.NVarChar);
            p[2].Value = Center;
            p[3] = new SqlParameter("@stream", SqlDbType.NVarChar);
            p[3].Value = Stream;
            p[4] = new SqlParameter("@app_no", SqlDbType.NVarChar);
            p[4].Value = Appno;
            p[5] = new SqlParameter("@flag", SqlDbType.NVarChar, 100);
            p[5].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_CheckAppNo_Return_Oppid", p);
            return (p[5].Value.ToString());
        }

        public static string CheckPrintValue(string SbEntrycode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p[0].Value = SbEntrycode;
            p[1] = new SqlParameter("@str", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_printcollegefee", p);
            return (p[1].Value.ToString());
        }

        public static string Checkispromote(string SbEntrycode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p[0].Value = SbEntrycode;
            p[1] = new SqlParameter("@promote", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Ispromote", p);
            return (p[1].Value.ToString());
        }

        public static DataSet Getallfellowupdetails(int Flag, string Userid)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@Userid", Userid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetFollowupDetails", p1, p2));
        }



        // Get All Users 


        public static DataSet Getallusers(int Flag, string Userid, string Password, string Emailid, int Status, string Username)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = Flag;
            SqlParameter p1 = new SqlParameter("@userid", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar);
            p2.Value = Password;
            SqlParameter p3 = new SqlParameter("@Status", SqlDbType.Int);
            p3.Value = Status;
            SqlParameter p4 = new SqlParameter("@Emailid", SqlDbType.VarChar);
            p4.Value = Emailid;
            SqlParameter p5 = new SqlParameter("@Username", SqlDbType.VarChar);
            p5.Value = Username;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllUsers", P, p1, p2, p3, p4, p5));
        }

        public static SqlDataReader GetUserdetailsbyuserid(string Userid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@usrid", SqlDbType.NVarChar);
            p[0].Value = Userid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UserdetailsbyUserid", p));
        }


        public static DataSet GetallRoles(int Flag, string Roleid, string Rolename, string Roledesc, int Status, string Userid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Roleid", SqlDbType.VarChar);
            p1.Value = Roleid;
            SqlParameter p2 = new SqlParameter("@RoleName", SqlDbType.VarChar);
            p2.Value = Rolename;
            SqlParameter p3 = new SqlParameter("@Roledesc", SqlDbType.VarChar);
            p3.Value = Roledesc;
            SqlParameter p4 = new SqlParameter("@Status", SqlDbType.Int);
            p4.Value = Status;
            SqlParameter p5 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p5.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllRoleAction", P, p1, p2, p3, p4, p5));
        }

        public static SqlDataReader GetRoledetailsbyRoleid(string Roleid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Roleid", SqlDbType.NVarChar);
            p[0].Value = Roleid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_RoledetailsbyRoleid", p));
        }

        public static string InsertRole(int Flag, string Roleid, string Rolename, string Roledesc, int Status, string Userid)
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@Flag", SqlDbType.NVarChar);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@Roleid", SqlDbType.NVarChar);
            p[1].Value = Roleid;
            p[2] = new SqlParameter("@RoleName", SqlDbType.VarChar);
            p[2].Value = Rolename;
            p[3] = new SqlParameter("@Roledesc", SqlDbType.NVarChar);
            p[3].Value = Roledesc;
            p[4] = new SqlParameter("@Status", SqlDbType.Int);
            p[4].Value = Status;
            p[5] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[5].Value = Userid;
            p[6] = new SqlParameter("@Roleiddd", SqlDbType.NVarChar, 100);
            p[6].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertRole", p);
            return (p[6].Value.ToString());
        }

        public static DataSet GetAllMenuItems()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllMenuItems"));
        }
        public static DataSet GetAllFeehead()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_getall_pricinginfo"));
        }

        public static DataSet GetAllChequeStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_chkstatus"));
        }
        public static DataSet GetallUom(int flag, string Uomid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = flag;
            SqlParameter p1 = new SqlParameter("@UOMID", SqlDbType.VarChar);
            p1.Value = Uomid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_BindUnitOfMeasurement", P, p1));
        }
        public static SqlDataReader GetallUomReader(int Flag, string Uomid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@flag", SqlDbType.Int);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@UOMID", SqlDbType.NVarChar);
            p[1].Value = Uomid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_BindUnitOfMeasurement", p));
        }

        public static DataSet GetallBouncecharge(int flag, string Bounceid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = flag;
            SqlParameter p1 = new SqlParameter("@bounceid", SqlDbType.VarChar);
            p1.Value = Bounceid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_bouncedcharges", P, p1));
        }
        public static DataSet GetallMenubyRoles(string Roleid)
        {
            SqlParameter P = new SqlParameter("@Roleid", SqlDbType.VarChar);
            P.Value = Roleid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSelectedMenuItems", P));
        }
        public static DataSet GetallUnselectedMenubyRoles(string Roleid)
        {
            SqlParameter P = new SqlParameter("@Roleid", SqlDbType.VarChar);
            P.Value = Roleid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetMenuitemsUnselected", P));
        }
        public static DataSet InsertRolemenu(int Flag, string Userid, string Roleid, string Menuname, string Menuid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Roleid", SqlDbType.VarChar);
            p1.Value = Roleid;
            SqlParameter p2 = new SqlParameter("@MenuName", SqlDbType.VarChar);
            p2.Value = Menuname;
            SqlParameter p3 = new SqlParameter("@MenuId", SqlDbType.VarChar);
            p3.Value = Menuid;
            SqlParameter p4 = new SqlParameter("@userid", SqlDbType.VarChar);
            p4.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertRoleMenu", P, p1, p2, p3, p4));
        }

        public static DataSet GetallCollege(int Flag, string CollegeCode, string Collegename, string Collegeaddress, int Countryid, int Stateid, int Cityid, string Collegepincode, string Website, string Collegeemail,
        string Collegephone, string CollegeContactPerson, string ContactPersonMail, string CollegeContactMobile, int Status, string Userid, int Compnyid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = Flag;
            SqlParameter p1 = new SqlParameter("@C_Name", SqlDbType.VarChar);
            p1.Value = Collegename;
            SqlParameter p2 = new SqlParameter("@C_Code", SqlDbType.VarChar);
            p2.Value = CollegeCode;
            SqlParameter p3 = new SqlParameter("@C_Address", SqlDbType.VarChar);
            p3.Value = Collegeaddress;
            SqlParameter p4 = new SqlParameter("@C_CountyId", SqlDbType.Int);
            p4.Value = Countryid;
            SqlParameter p5 = new SqlParameter("@C_StateId", SqlDbType.Int);
            p5.Value = Stateid;
            SqlParameter p6 = new SqlParameter("@C_CityId", SqlDbType.Int);
            p6.Value = Cityid;
            SqlParameter p7 = new SqlParameter("@C_pin", SqlDbType.VarChar);
            p7.Value = Collegepincode;
            SqlParameter p8 = new SqlParameter("@C_Website", SqlDbType.VarChar);
            p8.Value = Website;
            SqlParameter p9 = new SqlParameter("@C_Email", SqlDbType.VarChar);
            p9.Value = Collegeemail;
            SqlParameter p10 = new SqlParameter("@C_phone", SqlDbType.VarChar);
            p10.Value = Collegephone;
            SqlParameter p11 = new SqlParameter("@C_person", SqlDbType.VarChar);
            p11.Value = CollegeContactPerson;
            SqlParameter p12 = new SqlParameter("@c_person_mail", SqlDbType.VarChar);
            p12.Value = ContactPersonMail;
            SqlParameter p13 = new SqlParameter("@c_person_mobile", SqlDbType.VarChar);
            p13.Value = CollegeContactMobile;
            SqlParameter p14 = new SqlParameter("@c_status", SqlDbType.Int);
            p14.Value = Status;
            SqlParameter p15 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p15.Value = Userid;
            SqlParameter p16 = new SqlParameter("@C_Compid", SqlDbType.Int);
            p16.Value = Compnyid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Config_College", P, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));
        }

        //Company, Division, Zone, Center'

        //Public Shared Function GetAllActiveCompany() As DataSet
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveCompany"))
        //End Function
        public static DataSet GetUser_Company_Division_Zone_Center(int Flag, string Userid, string Divisioncode, string Zonecode, string Companycode)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@division_code", SqlDbType.VarChar);
            p2.Value = Divisioncode;
            SqlParameter p3 = new SqlParameter("@Zone_code", SqlDbType.VarChar);
            p3.Value = Zonecode;
            SqlParameter p4 = new SqlParameter("@Company_Code", SqlDbType.VarChar);
            p4.Value = Companycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center", p, p1, p2, p3, p4));
        }
        public static DataSet Get_Center_By_Company_Division_Stream(string Companycode, string Divisioncode, string Stream_Code, int Flag)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@company_code", SqlDbType.VarChar);
            p1.Value = Companycode;
            SqlParameter p2 = new SqlParameter("@division_code", SqlDbType.VarChar);
            p2.Value = Divisioncode;
            SqlParameter p3 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p3.Value = Stream_Code;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Center_by_Company_Division_Stream", p, p1, p2, p3));
        }

        public static DataSet GetAllAcadyear()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAcadyear"));
        }

        public static DataSet GetAcademicYearbyCenter(string Centercode)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = Centercode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getAcadyear_byCenter", p));
        }

        public static DataSet GetAcademicYearbyCenter_Promote(string Centercode, string CurrentAyString)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = Centercode;
            SqlParameter p1 = new SqlParameter("@CurrentayString", SqlDbType.VarChar);
            p1.Value = CurrentAyString;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getAcadyear_byCenter_Promote", p, p1));
        }

        public static DataSet GetTaxValue(int flag, string Sbentrycode, float vouchervalue, string Centercode)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@SBEntryCode", SqlDbType.VarChar);
            p1.Value = Sbentrycode;
            SqlParameter p2 = new SqlParameter("@VoucherValue", SqlDbType.Float);
            p2.Value = vouchervalue;
            SqlParameter p3 = new SqlParameter("@CenterCode", SqlDbType.VarChar);
            p3.Value = Centercode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Tax_Value_by_Amt", p, p1, p2, p3));
        }

        public static string GetApplication_Rights(string Userid, string Sbentrycode)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@UserCode", SqlDbType.NVarChar);
            p[0].Value = Userid;
            p[1] = new SqlParameter("@Sbentrycode", SqlDbType.NVarChar);
            p[1].Value = Sbentrycode;
            p[2] = new SqlParameter("@ActionCode", SqlDbType.NVarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Application_Rights", p);
            return (p[2].Value.ToString());
        }

        public static DataSet GetStreamby_Center_AcademicYear(string CenterCode, string AcademicYear)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_byCenter_Acadyear", p, p1));
        }
        public static DataSet GetStreambyAcadyear_Division(string Division, string AcademicYear, int Flag, string Company)
        {
            SqlParameter p = new SqlParameter("@division", SqlDbType.VarChar);
            p.Value = Division;
            SqlParameter p1 = new SqlParameter("@year", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            SqlParameter p2 = new SqlParameter("@flag", SqlDbType.Int);
            p2.Value = Flag;
            SqlParameter p3 = new SqlParameter("@company", SqlDbType.VarChar);
            p3.Value = Company;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllStreambyAcadyear", p, p1, p2, p3));
        }
        public static DataSet GetStreamby_Center_AcademicYear_All(string CenterCode, string AcademicYear)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_byCenter_Acadyear_All", p, p1));
        }

        public static DataSet GetStreamby_Center_AcademicYear_Dest(string CenterCode, string AcademicYear, string StreamCode)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            SqlParameter p2 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p2.Value = StreamCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_fordesccenter", p, p1, p2));
        }

        public static DataSet GetStreamby_Center_AcademicYear_Promote(string CenterCode, string AcademicYear)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_byCenter_Acadyear_Promote", p, p1));
        }
        public static DataSet GetRequestReason(int Flag, string Company, string Division, string Requestid, string Promote_type)
        {
            SqlParameter p = new SqlParameter("@Company", SqlDbType.VarChar);
            p.Value = Company;
            SqlParameter p1 = new SqlParameter("@Division", SqlDbType.VarChar);
            p1.Value = Division;
            SqlParameter p2 = new SqlParameter("@Request_code", SqlDbType.VarChar);
            p2.Value = Requestid;
            SqlParameter p3 = new SqlParameter("@Promote_type", SqlDbType.VarChar);
            p3.Value = Promote_type;
            SqlParameter p4 = new SqlParameter("@flag", SqlDbType.VarChar);
            p4.Value = Flag;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_promoteapproval", p, p1, p2, p3, p4));
        }

        public static SqlDataReader GetMandatesubjectsbyStream(int flag, string Stream_Code, string Center_Code)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@Flag", SqlDbType.Int);
            p[0].Value = flag;
            p[1] = new SqlParameter("@Stream_Code", SqlDbType.NVarChar);
            p[1].Value = Stream_Code;
            p[2] = new SqlParameter("@Center_Code", SqlDbType.NVarChar);
            p[2].Value = Center_Code;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetSubjectby_CenterStream", p));
        }
        public static DataSet GetMandatesubjectsbyStreamds(int flag, string Stream_Code, string Center_Code)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.VarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetSubjectby_CenterStream", p, p1, p2));
        }
        public static DataSet GetMandatesubjectsbyStreamforedit(int flag, string Opp_Id)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.VarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@oppid", SqlDbType.VarChar);
            p1.Value = Opp_Id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetSub_Preference", p, p1));
        }

        public static DataSet GetSubjectsbyStreamCode(int flag, string Stream_Code, string Center_Code)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetSubjectby_CenterStream", p, p1, p2));
        }
        public static DataSet Getproductsforremove(int flag, string Stream_Code, string Center_Code, string Sbentrycode, string Userid)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            SqlParameter p3 = new SqlParameter("@SBentrycode", SqlDbType.VarChar);
            p3.Value = Sbentrycode;
            SqlParameter p4 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p4.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Remove_Material", p, p1, p2, p3, p4));
        }

        public static DataSet GetproductsforAdd(int flag, string Stream_Code, string Center_Code, string Sbentrycode, string Userid)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            SqlParameter p3 = new SqlParameter("@SBentrycode", SqlDbType.VarChar);
            p3.Value = Sbentrycode;
            SqlParameter p4 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p4.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Add_material", p, p1, p2, p3, p4));
        }

        public static DataSet GetproductsforPayplan(int flag, string Stream_Code, string Center_Code, string Sbentrycode, string Userid)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            SqlParameter p3 = new SqlParameter("@SBentrycode", SqlDbType.VarChar);
            p3.Value = Sbentrycode;
            SqlParameter p4 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p4.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Customer_Material", p, p1, p2, p3, p4));
        }

        public static DataSet Getorder(int flag, string Stream_Code, string Center_Code, string Sbentrycode, string Userid)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            SqlParameter p3 = new SqlParameter("@SBentrycode", SqlDbType.VarChar);
            p3.Value = Sbentrycode;
            SqlParameter p4 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p4.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_DisplayOrder", p, p1, p2, p3, p4));
        }


        public static SqlDataReader GetContactsbyOppid(string Oppid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Oppid", SqlDbType.VarChar);
            p[0].Value = Oppid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetcontactsbyOppid", p));
        }
        public static SqlDataReader GetEnrollmentbyOppid(string Oppid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Oppid", SqlDbType.VarChar);
            p[0].Value = Oppid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetEnrollDetailsby_Oppid", p));
        }
        //Public Shared Function GetAllActiveDivision(ByVal CompanyCode As String) As DataSet
        //    Dim P As New SqlParameter("@Company_Code", SqlDbType.NVarChar)
        //    P.Value = CompanyCode
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveviDivision", P))
        //End Function
        //Public Shared Function GetAllActiveDivision(ByVal CompanyCode As String, ByVal Userid As String) As DataSet
        //    Dim P As New SqlParameter("@Company_Code", SqlDbType.NVarChar)
        //    P.Value = CompanyCode
        //    Dim P1 As New SqlParameter("@Company_Code", SqlDbType.NVarChar)
        //    P1.Value = Userid
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveviDivision", P, P1))
        //End Function

        public static DataSet GetAllSubjectMarks(int flag, string Oppid, string Subject, string Maxmarks, string Marksobtained, string Userid, int id)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.SmallInt);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Opp_id", SqlDbType.VarChar);
            p1.Value = Oppid;
            SqlParameter p2 = new SqlParameter("@Subject", SqlDbType.VarChar);
            p2.Value = Subject;
            SqlParameter p3 = new SqlParameter("@max_marks", SqlDbType.VarChar);
            p3.Value = Maxmarks;
            SqlParameter p4 = new SqlParameter("@Marks_Obtained", SqlDbType.VarChar);
            p4.Value = Marksobtained;
            SqlParameter p5 = new SqlParameter("@User_id", SqlDbType.VarChar);
            p5.Value = Userid;
            SqlParameter p6 = new SqlParameter("@id", SqlDbType.BigInt);
            p6.Value = id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertSubjectMarks", p, p1, p2, p3, p4, p5, p6));
        }
        public static SqlDataReader GetSubjectdetailsbyid(int flag, string Oppid, string Subject, string Maxmarks, string Marksobtained, string Userid, int id)
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@flag", SqlDbType.NVarChar);
            p[0].Value = flag;
            p[1] = new SqlParameter("@Opp_id", SqlDbType.NVarChar);
            p[1].Value = Oppid;
            p[2] = new SqlParameter("@Subject", SqlDbType.NVarChar);
            p[2].Value = Subject;
            p[3] = new SqlParameter("@max_marks", SqlDbType.NVarChar);
            p[3].Value = Maxmarks;
            p[4] = new SqlParameter("@Marks_Obtained", SqlDbType.NVarChar);
            p[4].Value = Marksobtained;
            p[5] = new SqlParameter("@User_id", SqlDbType.NVarChar);
            p[5].Value = Userid;
            p[6] = new SqlParameter("@id", SqlDbType.BigInt);
            p[6].Value = id;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertSubjectMarks", p));
        }

        public static void InsertMarks(int flag, string Oppid, string Subject, string Maxmarks, string Marksobtained, string Userid, int id)
        {
            SqlParameter p1 = new SqlParameter("@Flag", flag);
            SqlParameter p2 = new SqlParameter("@Opp_id", Oppid);
            SqlParameter p3 = new SqlParameter("@Subject", Subject);
            SqlParameter p4 = new SqlParameter("@max_marks", Maxmarks);
            SqlParameter p5 = new SqlParameter("@Marks_Obtained", Marksobtained);
            SqlParameter p6 = new SqlParameter("@User_id", Userid);
            SqlParameter p7 = new SqlParameter("@id", id);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertSubjectMarks", p1, p2, p3, p4, p5, p6, p7);
        }

        public static DataSet GetAllScore(int flag, string Oppid, string Scoretypeid, string Score, string Userid, int id)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.SmallInt);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Opp_id", SqlDbType.VarChar);
            p1.Value = Oppid;
            SqlParameter p2 = new SqlParameter("@Scoretypeid", SqlDbType.VarChar);
            p2.Value = Scoretypeid;
            SqlParameter p3 = new SqlParameter("@Score", SqlDbType.VarChar);
            p3.Value = Score;
            SqlParameter p4 = new SqlParameter("@User_id", SqlDbType.VarChar);
            p4.Value = Userid;
            SqlParameter p5 = new SqlParameter("@id", SqlDbType.BigInt);
            p5.Value = id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ScoreAll", p, p1, p2, p3, p4, p5));
        }
        public static void InsertScore(int flag, string Oppid, string Scoretypeid, string Score, string Userid, int id)
        {
            SqlParameter p1 = new SqlParameter("@Flag", flag);
            SqlParameter p2 = new SqlParameter("@Opp_id", Oppid);
            SqlParameter p3 = new SqlParameter("@Scoretypeid", Scoretypeid);
            SqlParameter p4 = new SqlParameter("@Score", Score);
            SqlParameter p5 = new SqlParameter("@User_id", Userid);
            SqlParameter p6 = new SqlParameter("@id", id);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ScoreAll", p1, p2, p3, p4, p5, p6);
        }
        public static void InsertUserSettings(string userid, string acadyear, string yeareducation, string leadsource, string leadstatus, string createdfrom, string createdto)
        {
            SqlParameter p1 = new SqlParameter("@userid", userid);
            SqlParameter p2 = new SqlParameter("@acadyear", acadyear);
            SqlParameter p3 = new SqlParameter("@yeareducation", yeareducation);
            SqlParameter p4 = new SqlParameter("@leadsource", leadsource);
            SqlParameter p5 = new SqlParameter("@leadstatus", leadstatus);
            SqlParameter p6 = new SqlParameter("@createdfrom", createdfrom);
            SqlParameter p7 = new SqlParameter("@createdto", createdto);

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_configure_usersettings", p1, p2, p3, p4, p5, p6, p7);

        }
        public static DataSet Extracurricular(int flag, string Oppid, int Curricular_Activity_id, string Description, string Userid, int id)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.SmallInt);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Opp_id", SqlDbType.VarChar);
            p1.Value = Oppid;
            SqlParameter p2 = new SqlParameter("@Curricular_Activity_id", SqlDbType.BigInt);
            p2.Value = Curricular_Activity_id;
            SqlParameter p3 = new SqlParameter("@Description", SqlDbType.VarChar);
            p3.Value = Description;
            SqlParameter p4 = new SqlParameter("@User_id", SqlDbType.VarChar);
            p4.Value = Userid;
            SqlParameter p5 = new SqlParameter("@id", SqlDbType.BigInt);
            p5.Value = id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ExtraCurricular", p, p1, p2, p3, p4, p5));
        }
        public static SqlDataReader Getextracurricularbyid(int flag, string Oppid, int Curricular_Activity_id, string Description, string Userid, int id)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@flag", SqlDbType.NVarChar);
            p[0].Value = flag;
            p[1] = new SqlParameter("@Opp_id", SqlDbType.NVarChar);
            p[1].Value = Oppid;
            p[2] = new SqlParameter("@Curricular_Activity_id", SqlDbType.BigInt);
            p[2].Value = Curricular_Activity_id;
            p[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
            p[3].Value = Description;
            p[4] = new SqlParameter("@User_id", SqlDbType.NVarChar);
            p[4].Value = Userid;
            p[5] = new SqlParameter("@id", SqlDbType.BigInt);
            p[5].Value = id;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ExtraCurricular", p));
        }

        public static void InsertExtraactivity(int flag, string Oppid, int Curricular_Activity_id, string Description, string Userid, int id)
        {
            SqlParameter p1 = new SqlParameter("@Flag", flag);
            SqlParameter p2 = new SqlParameter("@Opp_id", Oppid);
            SqlParameter p3 = new SqlParameter("@Curricular_Activity_id", Curricular_Activity_id);
            SqlParameter p4 = new SqlParameter("@Description", Description);
            SqlParameter p5 = new SqlParameter("@User_id", Userid);
            SqlParameter p6 = new SqlParameter("@id", id);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ExtraCurricular", p1, p2, p3, p4, p5, p6);
        }




        //Country, State, City, Nationality
        public static DataSet GetallCountry()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllCountry"));
        }

        public static DataSet GetallStatebyCountry(int Countrycode)
        {
            SqlParameter P = new SqlParameter("@Cid", SqlDbType.Int);
            P.Value = Countrycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllStatebyCountryId", P));
        }

        public static DataSet GetallCitybyState(int StateCode)
        {
            SqlParameter P = new SqlParameter("@Sid", SqlDbType.Int);
            P.Value = StateCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllCityByStateId", P));
        }

        public static DataSet GetallCity(int Flag, int Countryid, int Stateid, string Cityname, string CityCode, int Status, string Userid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = Flag;
            SqlParameter p1 = new SqlParameter("@C_CountryId", SqlDbType.Int);
            p1.Value = Countryid;
            SqlParameter p2 = new SqlParameter("@C_StateId", SqlDbType.Int);
            p2.Value = Stateid;
            SqlParameter p3 = new SqlParameter("@C_CityName", SqlDbType.VarChar);
            p3.Value = Cityname;
            SqlParameter p4 = new SqlParameter("@C_CityCode", SqlDbType.VarChar);
            p4.Value = CityCode;
            SqlParameter p5 = new SqlParameter("@c_status", SqlDbType.Int);
            p5.Value = Status;
            SqlParameter p6 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p6.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Config_City", P, p1, p2, p3, p4, p5, p6));
        }

        public static SqlDataReader GetCityDetailsbyCityid(string Citycode)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@code", SqlDbType.VarChar);
            p[0].Value = Citycode;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllCityByCode", p));
        }

        public static DataSet GetallNationality()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllNationality"));
        }

        public static DataSet GetallMothertongue()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllMotherTongue"));
        }

        public static DataSet GetallReligion()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllReligion"));
        }

        public static DataSet GetallCaste()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCasteNew"));
        }
        public static DataSet GetallCardtype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCardType"));
        }


        //Public Shared Function GetallCastebyreligion(ByVal Religionid As String) As DataSet
        //    Dim P As New SqlParameter("@religionid", SqlDbType.VarChar)
        //    P.Value = Religionid
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCaste", P))
        //End Function

        public static DataSet GetallStudentcastegroup()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStudentGroup"));
        }

        public static DataSet GetallMediumofInstruction()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllMediumofInstruction"));
        }

        public static DataSet GetallStay()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStay"));
        }

        public static DataSet GetallMonthofpassing()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllPassingmonth"));
        }

        public static DataSet GetallSportlevel()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSportlevel"));
        }

        //College details
        public static SqlDataReader GetCollegeDetailsbyCollegeid(int Collegeid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@cid", SqlDbType.Int);
            p[0].Value = Collegeid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCollegebyId", p));
        }
















        //Old Functions used for LMS


        //public static string Validatefilename(string Filename)
        //{
        //    SqlParameter p = new SqlParameter("@Import_File_Name", Filename);
        //    return (int.Parse(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_CheckExcelFile", p).ToString()));
        //}


        public static int FindliastnumusedS006(string tblname)
        {
            SqlParameter p = new SqlParameter("@Table_Name", tblname);
            return (int.Parse(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_find_last_num_S006", p).ToString()));
        }


        public static string InsertT009(string flag, string Import_Run_No, DateTime Import_Date, string Import_File_Name, string tag_name, string record_count, string tag_desc, string Created_by)
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@Flag", SqlDbType.NVarChar);
            p[0].Value = flag;
            p[1] = new SqlParameter("@Import_Run_No", SqlDbType.NVarChar);
            p[1].Value = Import_File_Name;
            p[2] = new SqlParameter("@Import_Date", SqlDbType.DateTime);
            p[2].Value = Import_Date;
            p[3] = new SqlParameter("@Import_File_Name", SqlDbType.NVarChar);
            p[3].Value = Import_File_Name;
            p[4] = new SqlParameter("@Tag_Name", SqlDbType.NVarChar);
            p[4].Value = tag_name;
            p[5] = new SqlParameter("@Record_Count", SqlDbType.NVarChar);
            p[5].Value = record_count;
            p[6] = new SqlParameter("@TagDescription", SqlDbType.NVarChar);
            p[6].Value = tag_desc;
            p[7] = new SqlParameter("@Created_By", SqlDbType.NVarChar);
            p[7].Value = Created_by;
            p[8] = new SqlParameter("@Run_Number", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Import_T009_Lead_Import", p);
            return (p[8].Value.ToString());
        }

        public static string InsertLeadContact(string CON_ID, string CON_TYPE_ID, string CON_TYPE_DESC, string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal Percentile, int AreaRank,
        int OverallRank, string Score_Range_Type, string Handphone1, string handphone2, string landline, string Emailid, string Flatno, string Buildingname, string Streetname, string Country,
        string State, string City, string Pincode, string Lead_Code, string Lead_Source_Code, string lead_src_desc, string Lead_Type_Code, string Lead_Status_Code, string lead_status_desc, string lead_campgn_id,
        string prod_interest, string time_join, string Lead_Contact_Code, string Contact_Source_Company, string Contact_Source_Division, string Contact_Source_Center, string Contact_Source_Zone, string Contact_role, string Contact_assignto, string last_modified_by,
        string Created_By, string Import_Run_No, string Stream_code, string MTStudentNotes, string Contact_Target_Company, string Contact_Target_Division, string Contact_Target_Zone, string Contact_Target_Center, string Discipline_Desc, string Field_Interested,
        string Competitive_exam, string lead_Type_Desc, string Category_Type, string InstitutionTypedesc, string Institutiondesc, string Current_Standard_desc, string AdditionalDesc, string Boarddesc, string Sectiondesc, string Yearofpassingdesc,
        string CurrentYeardesc, string Studentid, string Lastcourseopted, DateTime expectedtimejoin)
        {
            SqlParameter[] p = new SqlParameter[64];
            p[0] = new SqlParameter("@CON_ID", SqlDbType.NVarChar);
            p[0].Value = CON_ID;
            p[1] = new SqlParameter("@CON_TYPE_ID", SqlDbType.NVarChar);
            p[1].Value = CON_TYPE_ID;
            p[2] = new SqlParameter("@CON_TYPE_DESC", SqlDbType.NVarChar);
            p[2].Value = CON_TYPE_DESC;
            p[3] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[3].Value = CON_TITLE;
            p[4] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[4].Value = CON_FIRSTNAME;
            p[5] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[5].Value = CON_MNAME;
            p[6] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[6].Value = CON_LNAME;
            p[7] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[7].Direction = ParameterDirection.Output;

            p[8] = new SqlParameter("@score", SqlDbType.Decimal);
            p[8].Value = Score;
            p[9] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[9].Value = Percentile;
            p[10] = new SqlParameter("@Area_Rank", SqlDbType.Int);
            p[10].Value = AreaRank;
            p[11] = new SqlParameter("@Overall_Rank", SqlDbType.Int);
            p[11].Value = OverallRank;
            p[12] = new SqlParameter("@Score_Range_Type", SqlDbType.NVarChar);
            p[12].Value = Score_Range_Type;
            p[13] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[13].Value = Handphone1;
            p[14] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[14].Value = handphone2;
            p[15] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[15].Value = landline;
            p[16] = new SqlParameter("@Emailid", SqlDbType.NVarChar);
            p[16].Value = Emailid;

            p[17] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[17].Value = Flatno;
            p[18] = new SqlParameter("@BuildingName", SqlDbType.NVarChar);
            p[18].Value = Buildingname;
            p[19] = new SqlParameter("@StreetName", SqlDbType.NVarChar);
            p[19].Value = Streetname;
            p[20] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[20].Value = Country;
            p[21] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[21].Value = State;
            p[22] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[22].Value = City;
            p[23] = new SqlParameter("@Pincode", SqlDbType.NVarChar);
            p[23].Value = Pincode;



            p[24] = new SqlParameter("@Lead_Code", SqlDbType.NVarChar);
            p[24].Value = Lead_Code;
            p[25] = new SqlParameter("@Lead_Source_Code", SqlDbType.NVarChar);
            p[25].Value = Lead_Source_Code;
            p[26] = new SqlParameter("@lead_Src_desc", SqlDbType.NVarChar);
            p[26].Value = lead_src_desc;
            p[27] = new SqlParameter("@Lead_Type_Code", SqlDbType.NVarChar);
            p[27].Value = Lead_Type_Code;
            p[28] = new SqlParameter("@Lead_Status_Code", SqlDbType.NVarChar);
            p[28].Value = Lead_Status_Code;
            p[29] = new SqlParameter("@lead_status_desc", SqlDbType.NVarChar);
            p[29].Value = lead_status_desc;
            p[30] = new SqlParameter("@lead_campgn_id", SqlDbType.NVarChar);
            p[30].Value = lead_campgn_id;
            p[31] = new SqlParameter("@prod_interest", SqlDbType.NVarChar);
            p[31].Value = prod_interest;
            //p(32) = New SqlParameter("@time_join", SqlDbType.NVarChar)
            //p(32).Value = time_join
            p[32] = new SqlParameter("@Lead_Contact_Code", SqlDbType.NVarChar);
            p[32].Value = Lead_Contact_Code;
            p[33] = new SqlParameter("@Contact_Source_Company", SqlDbType.NVarChar);
            p[33].Value = Contact_Source_Company;

            p[34] = new SqlParameter("@Contact_Source_Division", SqlDbType.NVarChar);
            p[34].Value = Contact_Source_Division;
            p[35] = new SqlParameter("@Contact_Source_Center", SqlDbType.NVarChar);
            p[35].Value = Contact_Source_Center;
            p[36] = new SqlParameter("@Contact_Source_Zone", SqlDbType.NVarChar);
            p[36].Value = Contact_Source_Zone;
            p[37] = new SqlParameter("@contact_role", SqlDbType.NVarChar);
            p[37].Value = Contact_role;
            p[38] = new SqlParameter("@contact_assignto", SqlDbType.NVarChar);
            p[38].Value = Contact_assignto;
            p[39] = new SqlParameter("@Last_modified_by", SqlDbType.NVarChar);
            p[39].Value = last_modified_by;
            p[40] = new SqlParameter("@createdby", SqlDbType.NVarChar);
            p[40].Value = Created_By;
            p[41] = new SqlParameter("@import_run_no", SqlDbType.NVarChar);
            p[41].Value = Import_Run_No;

            p[42] = new SqlParameter("@stream_code", SqlDbType.NVarChar);
            p[42].Value = Stream_code;
            p[43] = new SqlParameter("@MTStudentNotes", SqlDbType.NVarChar);
            p[43].Value = MTStudentNotes;

            p[44] = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p[44].Value = Contact_Target_Company;
            p[45] = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p[45].Value = Contact_Target_Division;
            p[46] = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p[46].Value = Contact_Target_Zone;
            p[47] = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p[47].Value = Contact_Target_Center;

            p[48] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[48].Value = Discipline_Desc;
            p[49] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[49].Value = Field_Interested;
            p[50] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[50].Value = Competitive_exam;

            p[51] = new SqlParameter("@Lead_Type_Desc", SqlDbType.NVarChar);
            p[51].Value = lead_Type_Desc;

            p[52] = new SqlParameter("@Category_Type", SqlDbType.NVarChar);
            p[52].Value = Category_Type;

            p[53] = new SqlParameter("@Institution_Type_Desc", SqlDbType.NVarChar);
            p[53].Value = InstitutionTypedesc;
            p[54] = new SqlParameter("@Institution_Description", SqlDbType.NVarChar);
            p[54].Value = Institutiondesc;
            p[55] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[55].Value = Current_Standard_desc;
            p[56] = new SqlParameter("@Additional_Desc", SqlDbType.NVarChar);
            p[56].Value = AdditionalDesc;
            p[57] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[57].Value = Boarddesc;
            p[58] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[58].Value = Sectiondesc;
            p[59] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[59].Value = Yearofpassingdesc;
            p[60] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[60].Value = CurrentYeardesc;
            p[61] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
            p[61].Value = Studentid;
            p[62] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[62].Value = Lastcourseopted;
            p[63] = new SqlParameter("@time_join", SqlDbType.DateTime);
            p[63].Value = expectedtimejoin;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Import_Lead_Contact", p);
            return (p[7].Value.ToString());
        }


        //Public Shared Function GetMenu(ByVal Flag As Integer, ByVal Userid As String) As DataSet
        //    Dim p1 As New SqlParameter("@FLAG", Flag)
        //    Dim p2 As New SqlParameter("@Userid", Userid)
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_U002_Get_Master_Menu_Detail", p1, p2))
        //End Function



        //Public Shared Function Get_Menu_Items(ByVal Flag As Integer, ByVal Menu_Id As String, ByVal Userid As String) As DataSet
        //    Dim p1 As New SqlParameter("@FLAG", Flag)
        //    Dim p2 As New SqlParameter("@Menu_id", Menu_Id)
        //    Dim p3 As New SqlParameter("@userid", Userid)
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Menu_Items", p1, p2, p3))
        //End Function

        //Public Shared Function GerrolebyUserid(ByVal userid As String) As DataSet
        //    Dim P As New SqlParameter("@Userid", SqlDbType.NVarChar)
        //    P.Value = userid
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetRolebyUserid", P))
        //End Function

        //Public Shared Function GerrolebyUserid(ByVal Userid As String) As String
        //    Dim p As SqlParameter() = New SqlParameter(1) {}
        //    p(0) = New SqlParameter("@Userid", SqlDbType.NVarChar)
        //    p(0).Value = Userid
        //    p(1) = New SqlParameter("@roleid", SqlDbType.NVarChar, 100)
        //    p(1).Direction = ParameterDirection.Output
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetRolebyUserid", p)
        //    Return (p(1).Value.ToString())
        //End Function

        //Public Shared Function Getleadcount() As DataSet
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetLeadCount"))
        //End Function
        public static DataSet GetallOpporProductCategory()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllOpporProductCategory"));
        }

        public static DataSet GetAllSalesChannel()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllSalesChannel"));
        }
        //Public Shared Function GetallOpporSalesStage() As DataSet
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllOpporProductCategory"))
        //End Function
        public static DataSet GetAllOpporStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllOpporProductCategory"));
        }


        public static SqlDataReader Getleadcount(string Userid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Userid", SqlDbType.VarChar);
            p[0].Value = Userid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetLeadCount", p));
        }
        public static SqlDataReader GetOpportunitycount(string Userid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Userid", SqlDbType.VarChar);
            p[0].Value = Userid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetOpportunityCount", p));
        }
        public static SqlDataReader GetAccountcount(string Userid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Userid", SqlDbType.VarChar);
            p[0].Value = Userid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAccountCount", p));
        }

        public static SqlDataReader Get_SecondaryContactbyLeadidforfield(string Leadid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Leadid", SqlDbType.VarChar);
            p[0].Value = Leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_SecContactdetailsbyleadid", p));
        }
        public static SqlDataReader Get_SecondaryContactbyLeadidforfield1(string Conid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Conid", SqlDbType.VarChar);
            p[0].Value = Conid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_SecContactdetailsbyConid", p));
        }
        public static SqlDataReader Get_ContactbyLeadidforfield(int Flag, string Leadid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@lead_opp_id", SqlDbType.VarChar);
            p[1].Value = Leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETCONID", p));
        }
        public static SqlDataReader Get_ContactbyOppuridforfield(int Flag, string Leadid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@lead_opp_id", SqlDbType.VarChar);
            p[1].Value = Leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETCONID", p));
        }

        public static SqlDataReader Get_SecondaryContactbyOppididforfield(string Oppid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Oppid", SqlDbType.VarChar);
            p[0].Value = Oppid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_SecContactdetailsbyOppid", p));
        }
        //Public Shared Function Get_ContactbyOppididforSecondaryCon(ByVal Flag As String, ByVal Oppid As String) As SqlDataReader
        //    Dim p As SqlParameter() = New SqlParameter(1) {}
        //    p(0) = New SqlParameter("@Flag", SqlDbType.VarChar)
        //    p(0).Value = Flag
        //    p(1) = New SqlParameter("@Oppid", SqlDbType.VarChar)
        //    p(1).Value = Oppid
        //    Return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_getsecondaryinfo", p))
        //End Function
        public static DataSet Getallactiveleadtype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllActiveLeadTYpe"));
        }


        public static DataSet GetallactiveleadSource()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveLeadSource"));
        }

        public static DataSet GetAllActiveSchool()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveSchoolCollege"));
        }

        public static DataSet GetAllActiveSchoolContact()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveSchoolCollege_Contacts"));
        }

        public static DataSet GetallactiveExam()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveExam"));
        }

        public static DataSet GetallExamStatusbyExam(string Examid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@ExamId", SqlDbType.VarChar);
            p[0].Value = Examid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETALLEXAMSTATUSBYEXAMID", p));
        }

        public static DataSet GetallactiveleadStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveLeadstatus"));
        }

        public static DataSet GetallInteractedwith()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllInteractedWith"));
        }


        public static DataSet GetallProductCategory()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllProductCategory"));
        }

        public static DataSet GetallSalesStage()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSalesStage"));
        }

        public static DataSet GetallactiveContactType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllContactTYpe"));
        }
        public static DataSet GetallactiveContactTypeinrelation()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllContactTYpe_Allrelation"));
        }
        public static DataSet GetallactiveContactTypeSecondary()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSecondaryContactType"));
        }
        //USP_GetAllSContactTYpebyPContactTYpe

        public static DataSet GetAllSContactTypebyPContactType(string Primary_Contact_Type)
        {
            SqlParameter P = new SqlParameter("@Primary_Contact_ID", SqlDbType.VarChar);
            P.Value = Primary_Contact_Type;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSContactTYpebyPContactTYpe", P));
        }

        public static DataSet GetallResidenceType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllResidencetype"));
        }
        public static DataSet GetallQualification()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllQualification"));
        }
        //Public Shared Function GetallCountry() As DataSet
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCountry"))
        //End Function

        public static DataSet GetAllDivisionSection()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallDivisionSection"));
        }

        public static DataSet GetAllCurrentyear()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallCurrentYear"));
        }
        public static DataSet GetAllCurrentyearEducation()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Getall_CurrentYearEducation"));
        }
        public static DataSet GetallInstituteType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllInstituteType"));
        }
        public static DataSet GetallEventtype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_DispEvents"));
        }
        public static DataSet GetallBoard()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallBoard"));
        }
        public static DataSet GetallBoardbyinstitutetype(string InstituteTypeid)
        {
            SqlParameter P = new SqlParameter("@Insid", SqlDbType.VarChar);
            P.Value = InstituteTypeid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Getboardby_INSID", P));
        }
        public static DataSet GetallYearofpassing()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallYearofpassing"));
        }

        public static DataSet GetallCurrentStudyingin(string InstituteTypeid)
        {
            SqlParameter P = new SqlParameter("@Institute_Type_Id", SqlDbType.VarChar);
            P.Value = InstituteTypeid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallCurrentStudyingin", P));
        }

        public static DataSet GetallDiscipline()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllDiscipline"));
        }

        public static DataSet GetAllFieldInterestedByDisciplineid(int Discipline_Id)
        {
            SqlParameter P = new SqlParameter("@DisciplineId", SqlDbType.Int);
            P.Value = Discipline_Id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllFieldbyDiscipline", P));
        }

        public static DataSet GetallStatebyCountry(string Countrycode)
        {
            SqlParameter P = new SqlParameter("@Countrycode", SqlDbType.NVarChar);
            P.Value = Countrycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStatebyCountry", P));
        }

        public static DataSet GetallCitybyState(string StateCode)
        {
            SqlParameter P = new SqlParameter("@Statecode", SqlDbType.NVarChar);
            P.Value = StateCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCitybyState", P));
        }
        public static DataSet GetallLocationbycity(string Citycode)
        {
            SqlParameter P = new SqlParameter("@Citycode", SqlDbType.NVarChar);
            P.Value = Citycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllLocationbyCity", P));
        }

        public static DataSet GetAllZones()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllZone"));
        }

        public static DataSet GetAllZonebyDivision(string DivisionCode)
        {
            SqlParameter P = new SqlParameter("@DivisionCode", SqlDbType.NVarChar);
            P.Value = DivisionCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllZoneByOnlyDivision", P));
        }



        public static DataSet GetAllProductbyDivision(string DivisionCode)
        {
            SqlParameter P = new SqlParameter("@DivisionCode", SqlDbType.NVarChar);
            P.Value = DivisionCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllProductbyDivision", P));
        }

        //Public Shared Function GetAllProductbyCenter(ByVal DivisionCode As String) As DataSet
        //    Dim P As New SqlParameter("@DivisionCode", SqlDbType.NVarChar)
        //    P.Value = DivisionCode
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllProductbyDivision", P))
        //End Function

        public static DataSet GetallCentersByDivision(string DivsionCode)
        {
            SqlParameter P = new SqlParameter("@divisioncode", SqlDbType.NVarChar);
            P.Value = DivsionCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetCentersbyDivisionCode", P));
        }

        public static DataSet GetAllDivision()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllDivision"));
        }

        public static DataSet GetallZonebyDivision(string CompanyCode, string DivisonCode)
        {
            SqlParameter P = new SqlParameter("@Company_Code", SqlDbType.NVarChar);
            P.Value = CompanyCode;
            SqlParameter p1 = new SqlParameter("@Source_Division_Code", SqlDbType.NVarChar);
            p1.Value = DivisonCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallZonebyDivision", P, p1));
        }

        public static DataSet GetAllCenterbyZone(string ZoneCode)
        {
            SqlParameter P = new SqlParameter("@Zone_Code", SqlDbType.NVarChar);
            P.Value = ZoneCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCenterbyZone", P));
        }

        public static DataSet GetAllLeadfeedbackbyLeadid(string Leadid)
        {
            SqlParameter P = new SqlParameter("@leadid", SqlDbType.NVarChar);
            P.Value = Leadid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllfeedbackbyLeadid", P));
        }

        public static DataSet GetAllOpporfeedbackbyOpporid(string Opporid)
        {
            SqlParameter P = new SqlParameter("@oppor_id", SqlDbType.NVarChar);
            P.Value = Opporid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllfeedbackbyOpporid", P));
        }

        public static DataSet GetAllStudentType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallStudentType"));
        }

        public static DataSet GetSalesStage(int Flag)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetSalesStage", p));
        }


        public static DataSet GetScorerange()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetScorerange"));
        }

        public static DataSet GetallRoles()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllRoles"));
        }

        public static DataSet GetallLeadtype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallLeadtype"));
        }

        public static DataSet GetallLeadSource()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallLeadSource"));
        }

        public static DataSet GetallLeadStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallLeadStatus"));
        }

        public static DataSet GetallContactType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallGContactType"));
        }

        public static DataSet GetallScorerangetype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallScorerangeType"));
        }

        public static DataSet Getallusers()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllUsers"));
        }

        public static DataSet Getallusersbyusername(string Username)
        {
            SqlParameter P = new SqlParameter("@Username", SqlDbType.NVarChar);
            P.Value = Username;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllUsersbyusername", P));

        }

        public static void InsertLeadType(string Leaddesc)
        {
            SqlParameter p1 = new SqlParameter("@description", Leaddesc);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadtype", p1);
        }


        public static void InsertLeadSource(string LeadStatus)
        {
            SqlParameter p1 = new SqlParameter("@description", LeadStatus);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadSource", p1);
        }


        public static void InsertLeadStatus(string Leadstatus)
        {
            SqlParameter p1 = new SqlParameter("@description", Leadstatus);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadStatus", p1);
        }

        public static void InsertReceiptforevent(int flag, string sbentrycode, string userid, string newsbentrycode, float Zrefamt)
        {
            SqlParameter p1 = new SqlParameter("@flag", flag);
            SqlParameter p2 = new SqlParameter("@sbentryCode", sbentrycode);
            SqlParameter p3 = new SqlParameter("@userid", userid);
            SqlParameter p4 = new SqlParameter("@NewSbentrycode", newsbentrycode);
            SqlParameter p5 = new SqlParameter("@Zref_amt", Zrefamt);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Receipt_for_Events", p1, p2, p3, p4, p5);
        }



        public static void InsertContactType(string Contactype)
        {
            SqlParameter p1 = new SqlParameter("@description", Contactype);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertContactType", p1);
        }

        public static void InsertScorerangeType(string Scorerangetype)
        {
            SqlParameter p1 = new SqlParameter("@description", Scorerangetype);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertScorerangetype", p1);
        }


        public static DataSet Getuserbyuserid(string Userid)
        {
            SqlParameter P = new SqlParameter("@Userid", SqlDbType.NVarChar);
            P.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetUsersbyuserid", P));
        }

        public static DataSet Get_SecondaryContactbyLeadid(string Leadid)
        {
            SqlParameter P = new SqlParameter("@Leadid", SqlDbType.NVarChar);
            P.Value = Leadid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_SecContactdetailsbyleadid", P));
        }
        public static DataSet Get_SecondaryContactbyOpporid(string Opporid)
        {
            SqlParameter P = new SqlParameter("@Oppid", SqlDbType.NVarChar);
            P.Value = Opporid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_SecContactdetailsbyOppid", P));
        }
        //for Chart

        public static DataSet GetOpportunityCountbySalesstage(string Userid)
        {
            SqlParameter P = new SqlParameter("@Userid", SqlDbType.NVarChar);
            P.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GetOpportunityCountbySalesstage", P));
        }

        public static DataSet GetLeadCountbyleadstatus(string Userid)
        {
            SqlParameter P = new SqlParameter("@Userid", SqlDbType.NVarChar);
            P.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GetLeadCountbyleadstatus", P));
        }

        public static DataSet GetDashboardValues(string Userid)
        {
            SqlParameter P = new SqlParameter("@Userid", SqlDbType.NVarChar);
            P.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_DASHBOARD", P));
        }

        public static DataSet GetDashboardValues_TM(string Userid, int Flag, string Year, string DivisionCode)
        {
            SqlParameter P = new SqlParameter("@Userid", SqlDbType.NVarChar);
            P.Value = Userid;
            SqlParameter P1 = new SqlParameter("@Flag", SqlDbType.Int);
            P1.Value = Flag;
            SqlParameter P2 = new SqlParameter("@Year", SqlDbType.VarChar);
            P2.Value = Year;
            SqlParameter P3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            P3.Value = DivisionCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_DASHBOARD_TM", P, P1, P2, P3));
        }


        public static DataSet GetTotalPipelinebySalesStage(string UserId)
        {
            SqlParameter P = new SqlParameter("@Userid", SqlDbType.NVarChar);
            P.Value = UserId;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GetTotalPipelinebySalesStage", P));
        }

        public static DataSet GetConvertedLeadsMonthlyStatistics()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GetConvertedLeadsMonthlyStatistics"));
        }

        public static DataSet GetConvertedOpportunityMonthlyStatistics()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GetConvertedOpportunityMonthlyStatistics"));
        }

        //end Chart
        public static DataSet GetFileNameForAttachment(int flag, string ProcessNum, string ProcessType, string UserID, string DocNotes, string DocumentName)
        {

            SqlParameter p = new SqlParameter("@ProcessNumber", SqlDbType.NVarChar);
            p.Value = ProcessNum;
            SqlParameter p1 = new SqlParameter("@ProcessType", SqlDbType.NVarChar);
            p1.Value = ProcessType;
            SqlParameter p2 = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p2.Value = UserID;
            SqlParameter p3 = new SqlParameter("@DocNotes", SqlDbType.NVarChar);
            p3.Value = DocNotes;
            SqlParameter p4 = new SqlParameter("@flagID", SqlDbType.Int);
            p4.Value = flag;
            SqlParameter p5 = new SqlParameter("@DocumentName", SqlDbType.VarChar);
            p5.Value = DocumentName;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "isp_AttachDocument", p, p1, p2, p3, p4, p5));
        }

        public static DataSet GetSelectedSubjectGroupsInLeadByStreamCode(string LeadID, string StreamID)
        {
            SqlParameter p = new SqlParameter("@OppCode", SqlDbType.NVarChar);
            p.Value = LeadID;
            SqlParameter p1 = new SqlParameter("@OppCode", SqlDbType.NVarChar);
            p1.Value = StreamID;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "vsp_FetchSubjectgroupCodeByID", p));
        }



        public static void AssignroletoUser(string userid, string roleid, string Createdby)
        {
            SqlParameter p1 = new SqlParameter("@Userid", userid);
            SqlParameter p2 = new SqlParameter("@Roleid", roleid);
            SqlParameter p3 = new SqlParameter("@createdby", Createdby);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_AssignUseridtoRoleid", p1, p2, p3);
        }

        public static void AssignCenterstoZone(string CenterCode, string ZoneCode)
        {
            SqlParameter p1 = new SqlParameter("@ZoneCode", ZoneCode);
            SqlParameter p2 = new SqlParameter("@CenterCode", CenterCode);

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_AssignCenterstoZone", p1, p2);
        }

        public static void CreateZones(string CompanyCode, string DivisionCode, string Zonename)
        {
            SqlParameter p1 = new SqlParameter("@CompanyCode", CompanyCode);
            SqlParameter p2 = new SqlParameter("@DivisionCode", DivisionCode);
            SqlParameter p3 = new SqlParameter("@Zonename", Zonename);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CreateZones", p1, p2, p3);
        }


        //Subject Add, Remove and Change
        public static DataSet GetSubjectgroupbysbentrycode(string Bid)
        {
            SqlParameter p = new SqlParameter("@SbentryCode", SqlDbType.NVarChar);
            p.Value = Bid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_fill_newsubgrp", p));
        }

        public static DataSet ManageSubjectgroupbysbentrycode(string Bid)
        {
            SqlParameter p = new SqlParameter("@SbentryCode", SqlDbType.NVarChar);
            p.Value = Bid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "vsp_ManageSubjectGroup", p));
        }

        public static DataSet GetSubjectgroupToberemovedbysbentrycode(string Bid)
        {
            SqlParameter p = new SqlParameter("@SbentryCode", SqlDbType.NVarChar);
            p.Value = Bid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_Fill_Remove_SG", p));
        }

        public static DataSet GetCentersbyDivision(string DivisionCode)
        {
            SqlParameter p = new SqlParameter("@division_code", SqlDbType.NVarChar);
            p.Value = DivisionCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_CenterbyDivision", p));
        }


        //Public Shared Function GetUserRoleid(ByVal UserID As String, ByVal inp As Integer, ByVal RoleID As String, ByVal MenuCode As String) As DataSet
        //    Dim p As New SqlParameter("@flag", SqlDbType.Int)
        //    p.Value = inp
        //    Dim p1 As New SqlParameter("@UserID", SqlDbType.NVarChar)
        //    p1.Value = UserID
        //    Dim p2 As New SqlParameter("@RoleID", SqlDbType.NVarChar)
        //    p2.Value = RoleID
        //    Dim p3 As New SqlParameter("@MenuCode", SqlDbType.NVarChar)
        //    p3.Value = MenuCode
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "User_Authorization", p, p1, p2, p3))
        //End Function

        public static SqlDataReader GetUserRoleid(string UserID, int inp, string RoleID, string MenuCode)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@flag", SqlDbType.Int);
            p[0].Value = inp;
            p[1] = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p[1].Value = UserID;
            p[2] = new SqlParameter("@RoleID", SqlDbType.NVarChar);
            p[2].Value = RoleID;
            p[3] = new SqlParameter("@MenuCode", SqlDbType.NVarChar);
            p[3].Value = MenuCode;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "User_Authorization", p));
        }



        public static string GetNewSbntrycodebyOldSbnetrycode(int flag, string sbentrycode)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@flag", SqlDbType.Int);
            p[0].Value = flag;
            p[1] = new SqlParameter("@sbentryCode", SqlDbType.NVarChar);
            p[1].Value = sbentrycode;
            p[2] = new SqlParameter("@NewSbentrycode", SqlDbType.NVarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Newsbentrycodebyoldsbentrycode", p);
            return (p[2].Value.ToString());
        }


        public static void EventSTS(string OldSBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@OldSBentrycode", OldSBEntrycode);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_EVENT_STS", p1);
        }



        public static string InsertAddManualLeadContact(string CON_ID, string CON_TYPE_ID, string CON_TYPE_DESC, string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank,
        int Overallrank, string Scorerange, string Lead_Code, string Lead_Source_Code, string lead_src_desc, string Lead_Type_Code, string Lead_Status_Code, string lead_status_desc, string lead_campgn_id, string prod_interest,
        string Lead_Contact_Code, string Contact_Source_company, string Contact_Source_Division, string Contact_Source_Center, string Contact_Source_Zone, string Contact_role, string Contact_assignto, string last_modified_by, string Created_By, string Import_Run_No,
        string Stream_code, string MTStudentNotes, string Contact_Target_Company, string Contact_Target_Division, string Contact_Target_Zone, string Contact_Target_Center, string Handphone1, string handphone2, string landline, string emailid,
        string Flatno, string buildingname, string streetname, string Countryname, string State, string City, string pincode, int discipline_id, string Discipline_desc, int Field_Id,
        string Field_Desc, string Competitive_Exam, string Lead_Type_Desc, string Category_Type_Id, string Category_Type, string InstituteTypeid, string InstituteTypeDesc, string Institute_desc, string Current_Standardid, string Current_StandardDesc,
        string AdditionalDesc, string Boardid, string Boarddesc, string Sectionid, string Sectiondesc, string Yearofpassingid, string Yearofpassingdesc, string CurrentYearid, string CurrentYeardesc, string Studentid,
        string LastCourseOpted, DateTime Timejoin, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname, string Sechphone1, string Sechphone2, string Seclandline,
        string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity, string Secpincode, string SecContactDesc, int Totalmsmarks,
        int Totalmsmarksobt, string Leadsourcedesc, string Dob, string Examination, string Location, string Gender, int C_Year_Education)
        {
            SqlParameter[] p = new SqlParameter[98];
            p[0] = new SqlParameter("@CON_ID", SqlDbType.NVarChar);
            p[0].Value = CON_ID;
            p[1] = new SqlParameter("@CON_TYPE_ID", SqlDbType.NVarChar);
            p[1].Value = CON_TYPE_ID;
            p[2] = new SqlParameter("@CON_TYPE_DESC", SqlDbType.NVarChar);
            p[2].Value = CON_TYPE_DESC;
            p[3] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[3].Value = CON_TITLE;
            p[4] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[4].Value = CON_FIRSTNAME;
            p[5] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[5].Value = CON_MNAME;
            p[6] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[6].Value = CON_LNAME;
            p[7] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[7].Value = Score;
            p[8] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[8].Value = percentile;
            p[9] = new SqlParameter("@Area_rank", SqlDbType.Int);
            p[9].Value = Area_rank;
            p[10] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[10].Value = Overallrank;
            p[11] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[11].Value = Scorerange;
            p[12] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[12].Direction = ParameterDirection.Output;


            p[13] = new SqlParameter("@lead_no", SqlDbType.NVarChar);
            p[13].Value = Lead_Code;
            p[14] = new SqlParameter("@lead_src_id", SqlDbType.NVarChar);
            p[14].Value = Lead_Source_Code;
            p[15] = new SqlParameter("@lead_Src_desc", SqlDbType.NVarChar);
            p[15].Value = lead_src_desc;
            p[16] = new SqlParameter("@Lead_Type_Id", SqlDbType.NVarChar);
            p[16].Value = Lead_Type_Code;
            p[17] = new SqlParameter("@lead_status_id", SqlDbType.NVarChar);
            p[17].Value = Lead_Status_Code;
            p[18] = new SqlParameter("@lead_status_desc", SqlDbType.NVarChar);
            p[18].Value = lead_status_desc;
            p[19] = new SqlParameter("@lead_campgn_id", SqlDbType.NVarChar);
            p[19].Value = lead_campgn_id;
            p[20] = new SqlParameter("@prod_interest", SqlDbType.NVarChar);
            p[20].Value = prod_interest;
            p[21] = new SqlParameter("@lead_Con_id", SqlDbType.NVarChar);
            p[21].Value = Lead_Contact_Code;
            p[22] = new SqlParameter("@contact_Source_company", SqlDbType.NVarChar);
            p[22].Value = Contact_Source_company;

            p[23] = new SqlParameter("@contact_Source_Division", SqlDbType.NVarChar);
            p[23].Value = Contact_Source_Division;
            p[24] = new SqlParameter("@contact_Source_Center", SqlDbType.NVarChar);
            p[24].Value = Contact_Source_Center;
            p[25] = new SqlParameter("@contact_Source_zone", SqlDbType.NVarChar);
            p[25].Value = Contact_Source_Zone;
            p[26] = new SqlParameter("@contact_role", SqlDbType.NVarChar);
            p[26].Value = Contact_role;
            p[27] = new SqlParameter("@contact_assignto", SqlDbType.NVarChar);
            p[27].Value = Contact_assignto;
            p[28] = new SqlParameter("@Last_modified_by", SqlDbType.NVarChar);
            p[28].Value = last_modified_by;
            p[29] = new SqlParameter("@createdby", SqlDbType.NVarChar);
            p[29].Value = Created_By;
            p[30] = new SqlParameter("@import_run_no", SqlDbType.NVarChar);
            p[30].Value = Import_Run_No;

            p[31] = new SqlParameter("@stream_code", SqlDbType.NVarChar);
            p[31].Value = Stream_code;
            p[32] = new SqlParameter("@MTStudentNotes", SqlDbType.NVarChar);
            p[32].Value = MTStudentNotes;

            p[33] = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p[33].Value = Contact_Target_Company;
            p[34] = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p[34].Value = Contact_Target_Division;
            p[35] = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p[35].Value = Contact_Target_Zone;
            p[36] = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p[36].Value = Contact_Target_Center;

            p[37] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[37].Value = Handphone1;
            p[38] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[38].Value = handphone2;
            p[39] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[39].Value = landline;
            p[40] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[40].Value = emailid;
            p[41] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[41].Value = Flatno;
            p[42] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[42].Value = buildingname;
            p[43] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[43].Value = streetname;
            p[44] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[44].Value = Countryname;
            p[45] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[45].Value = State;
            p[46] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[46].Value = City;
            p[47] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[47].Value = pincode;

            p[48] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[48].Value = discipline_id;
            p[49] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[49].Value = Discipline_desc;
            p[50] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[50].Value = Field_Id;
            p[51] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[51].Value = Field_Desc;
            p[52] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[52].Value = Competitive_Exam;

            p[53] = new SqlParameter("@Lead_Type_Desc", SqlDbType.NVarChar);
            p[53].Value = Lead_Type_Desc;

            p[54] = new SqlParameter("@Category_Type_Id", SqlDbType.NVarChar);
            p[54].Value = Category_Type_Id;
            p[55] = new SqlParameter("@Category_Type", SqlDbType.NVarChar);
            p[55].Value = Category_Type;

            p[56] = new SqlParameter("@Institute_Type_Id", SqlDbType.NVarChar);
            p[56].Value = InstituteTypeid;
            p[57] = new SqlParameter("@institute_Type_Desc", SqlDbType.NVarChar);
            p[57].Value = InstituteTypeDesc;
            p[58] = new SqlParameter("@Institution_Desc", SqlDbType.NVarChar);
            p[58].Value = Institute_desc;
            p[59] = new SqlParameter("@Current_Standard_id", SqlDbType.NVarChar);
            p[59].Value = Current_Standardid;
            p[60] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[60].Value = Current_StandardDesc;
            p[61] = new SqlParameter("@Additional_desc", SqlDbType.NVarChar);
            p[61].Value = AdditionalDesc;
            p[62] = new SqlParameter("@Board_Id", SqlDbType.NVarChar);
            p[62].Value = Boardid;
            p[63] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[63].Value = Boarddesc;
            p[64] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[64].Value = Sectionid;
            p[65] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[65].Value = Sectiondesc;
            p[66] = new SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar);
            p[66].Value = Yearofpassingid;
            p[67] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[67].Value = Yearofpassingdesc;
            p[68] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[68].Value = CurrentYearid;
            p[69] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[69].Value = CurrentYeardesc;
            p[70] = new SqlParameter("@Studentid", SqlDbType.NVarChar);
            p[70].Value = Studentid;
            p[71] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[71].Value = LastCourseOpted;
            p[72] = new SqlParameter("@Time_join", SqlDbType.DateTime);
            p[72].Value = Timejoin;

            p[73] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[73].Value = SecContactType;
            p[74] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[74].Value = SecTitle;
            p[75] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[75].Value = Secfname;
            p[76] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[76].Value = SecMname;
            p[77] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[77].Value = SecLname;
            p[78] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[78].Value = Sechphone1;
            p[79] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[79].Value = Sechphone2;
            p[80] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[80].Value = Seclandline;
            p[81] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[81].Value = Secemail;
            p[82] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[82].Value = SecAdd1;
            p[83] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[83].Value = Secadd2;
            p[84] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[84].Value = SecStreetname;
            p[85] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[85].Value = SecCountryname;
            p[86] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[86].Value = SecState;
            p[87] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[87].Value = SecCity;
            p[88] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[88].Value = Secpincode;
            p[89] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[89].Value = SecContactDesc;
            p[90] = new SqlParameter("@total_ms_marks", SqlDbType.Int);
            p[90].Value = Totalmsmarks;
            p[91] = new SqlParameter("@total_ms_marks_obt", SqlDbType.Int);
            p[91].Value = Totalmsmarksobt;
            p[92] = new SqlParameter("@Lead_Source_Desc", SqlDbType.NVarChar);
            p[92].Value = Leadsourcedesc;
            p[93] = new SqlParameter("@DOB", SqlDbType.NVarChar);
            p[93].Value = Dob;
            p[94] = new SqlParameter("@Last_Exam", SqlDbType.NVarChar);
            p[94].Value = Examination;
            p[95] = new SqlParameter("@location", SqlDbType.NVarChar);
            p[95].Value = Location;
            p[96] = new SqlParameter("@gender", SqlDbType.NVarChar);
            p[96].Value = Gender;
            p[97] = new SqlParameter("@C_Year_Education", SqlDbType.Int);
            p[97].Value = C_Year_Education;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Add_Lead_Contact", p);
            return (p[12].Value.ToString());
        }

        public static string InsertSecondaryLeadContact(string PrimaryConId, string Conid, string InstituteTypeid, string InstituteTypeDesc, string Institute_desc, string Current_Standardid, string Current_StandardDesc, string AdditionalDesc, string Boardid, string Boarddesc,
        string Sectionid, string Sectiondesc, string Yearofpassingid, string Yearofpassingdesc, string CurrentYearid, string CurrentYeardesc, string SecContactTypeid, string SecContactDesc, string SecTitle, string Secfname,
        string SecMname, string SecLname, string Sechphone1, string Sechphone2, string Seclandline, string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname,
        string SecState, string SecCity, string Secpincode, string location, string Gender, string Dob)
        {
            SqlParameter[] p = new SqlParameter[37];
            p[0] = new SqlParameter("@primary_con_id", SqlDbType.NVarChar);
            p[0].Value = PrimaryConId;
            p[1] = new SqlParameter("@CON_ID", SqlDbType.NVarChar);
            p[1].Value = Conid;
            p[2] = new SqlParameter("@Institute_Type_Id", SqlDbType.NVarChar);
            p[2].Value = InstituteTypeid;
            p[3] = new SqlParameter("@institute_Type_Desc", SqlDbType.NVarChar);
            p[3].Value = InstituteTypeDesc;
            p[4] = new SqlParameter("@Institution_Desc", SqlDbType.NVarChar);
            p[4].Value = Institute_desc;
            p[5] = new SqlParameter("@Current_Standard_id", SqlDbType.NVarChar);
            p[5].Value = Current_Standardid;
            p[6] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[6].Value = Current_StandardDesc;
            p[7] = new SqlParameter("@Additional_desc", SqlDbType.NVarChar);
            p[7].Value = AdditionalDesc;
            p[8] = new SqlParameter("@Board_Id", SqlDbType.NVarChar);
            p[8].Value = Boardid;
            p[9] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[9].Value = Boarddesc;
            p[10] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[10].Value = Sectionid;
            p[11] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[11].Value = Sectiondesc;
            p[12] = new SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar);
            p[12].Value = Yearofpassingid;
            p[13] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[13].Value = Yearofpassingdesc;
            p[14] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[14].Value = CurrentYearid;
            p[15] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[15].Value = CurrentYeardesc;
            p[16] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[16].Value = SecContactTypeid;
            p[17] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[17].Value = SecContactDesc;
            p[18] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[18].Value = SecTitle;
            p[19] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[19].Value = Secfname;
            p[20] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[20].Value = SecMname;
            p[21] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[21].Value = SecLname;
            p[22] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[22].Value = Sechphone1;
            p[23] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[23].Value = Sechphone2;
            p[24] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[24].Value = Seclandline;
            p[25] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[25].Value = Secemail;
            p[26] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[26].Value = SecAdd1;
            p[27] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[27].Value = Secadd2;
            p[28] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[28].Value = SecStreetname;
            p[29] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[29].Value = SecCountryname;
            p[30] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[30].Value = SecState;
            p[31] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[31].Value = SecCity;
            p[32] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[32].Value = Secpincode;
            p[33] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[33].Direction = ParameterDirection.Output;
            p[34] = new SqlParameter("@location", SqlDbType.NVarChar);
            p[34].Value = location;
            p[35] = new SqlParameter("@gender", SqlDbType.NVarChar);
            p[35].Value = Gender;
            p[36] = new SqlParameter("@dob", SqlDbType.NVarChar);
            p[36].Value = Dob;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Add_Sec_Contact", p);
            return (p[33].Value.ToString());
        }



        public static string UpdateManualLeadContact(string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank, int Overallrank, string Scorerange, string Handphone1,
        string handphone2, string landline, string emailid, string Flatno, string buildingname, string streetname, string Countryname, string State, string City, string pincode,
        string Lead_Code, string Lead_Contact_Code, string Contact_Source_company, string Contact_Source_Division, string Contact_Source_Center, string Contact_Source_Zone, string Contact_assignto, string last_modified_by, string Contact_Target_Company, string Contact_Target_Division,
        string Contact_Target_Zone, string Contact_Target_Center, int discipline_id, string Discipline_desc, int Field_Id, string Field_Desc, string Competitive_Exam, string Category_Type_Id, string Category_Type, string Institution_Type_Id,
        string Institution_Type_Desc, string Institution_Description, string Current_Standard_Id, string Current_Standard_Desc, string Additional_Desc, string Board_Id, string Board_Desc, string Section_Id, string Section_Desc, string Year_of_Passing_ID,
        string Year_of_Passing_Desc, string Current_Year_Id, string Current_Year_Desc, string Student_Id, string Last_Course_Opted, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname,
        string Sechphone1, string Sechphone2, string Seclandline, string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity,
        string Secpincode, string SecContactDesc, int TotalMSmarks, int TotalMSmarksobt, string Sourcedesc, string dob, string Examination, string Location)
        {
            SqlParameter[] p = new SqlParameter[79];
            p[0] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[0].Value = CON_TITLE;
            p[1] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[1].Value = CON_FIRSTNAME;
            p[2] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[2].Value = CON_MNAME;
            p[3] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[3].Value = CON_LNAME;
            p[4] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[4].Value = Score;
            p[5] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[5].Value = percentile;
            p[6] = new SqlParameter("@Area_rank", SqlDbType.NVarChar);
            p[6].Value = Area_rank;
            p[7] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[7].Value = Overallrank;
            p[8] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[8].Value = Scorerange;
            p[9] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[9].Direction = ParameterDirection.Output;
            p[10] = new SqlParameter("@Lead_No", SqlDbType.NVarChar);
            p[10].Value = Lead_Code;

            p[11] = new SqlParameter("@Lead_Con_id", SqlDbType.NVarChar);
            p[11].Value = Lead_Contact_Code;
            p[12] = new SqlParameter("@contact_Source_company", SqlDbType.NVarChar);
            p[12].Value = Contact_Source_company;
            p[13] = new SqlParameter("@contact_Source_Division", SqlDbType.NVarChar);
            p[13].Value = Contact_Source_Division;
            p[14] = new SqlParameter("@contact_Source_Center", SqlDbType.NVarChar);
            p[14].Value = Contact_Source_Center;
            p[15] = new SqlParameter("@contact_Source_zone", SqlDbType.NVarChar);
            p[15].Value = Contact_Source_Zone;

            p[16] = new SqlParameter("@contact_assignto", SqlDbType.NVarChar);
            p[16].Value = Contact_assignto;
            p[17] = new SqlParameter("@Last_modified_by", SqlDbType.NVarChar);
            p[17].Value = last_modified_by;


            p[18] = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p[18].Value = Contact_Target_Company;
            p[19] = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p[19].Value = Contact_Target_Division;
            p[20] = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p[20].Value = Contact_Target_Zone;
            p[21] = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p[21].Value = Contact_Target_Center;

            p[22] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[22].Value = Handphone1;
            p[23] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[23].Value = handphone2;
            p[24] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[24].Value = landline;
            p[25] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[25].Value = emailid;
            p[26] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[26].Value = Flatno;
            p[27] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[27].Value = buildingname;
            p[28] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[28].Value = streetname;
            p[29] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[29].Value = Countryname;
            p[30] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[30].Value = State;
            p[31] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[31].Value = City;
            p[32] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[32].Value = pincode;

            p[33] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[33].Value = discipline_id;
            p[34] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[34].Value = Discipline_desc;
            p[35] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[35].Value = Field_Id;
            p[36] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[36].Value = Field_Desc;
            p[37] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[37].Value = Competitive_Exam;

            p[38] = new SqlParameter("@category_TYpe_id", SqlDbType.NVarChar);
            p[38].Value = Category_Type_Id;
            p[39] = new SqlParameter("@category_Type", SqlDbType.NVarChar);
            p[39].Value = Category_Type;
            p[40] = new SqlParameter("@Institution_Type_Id", SqlDbType.NVarChar);
            p[40].Value = Institution_Type_Id;
            p[41] = new SqlParameter("@Institution_Type_Desc", SqlDbType.NVarChar);
            p[41].Value = Institution_Type_Desc;
            p[42] = new SqlParameter("@Institution_Description", SqlDbType.NVarChar);
            p[42].Value = Institution_Description;
            p[43] = new SqlParameter("@Current_Standard_Id", SqlDbType.NVarChar);
            p[43].Value = Current_Standard_Id;
            p[44] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[44].Value = Current_Standard_Desc;
            p[45] = new SqlParameter("@Additional_Desc", SqlDbType.NVarChar);
            p[45].Value = Additional_Desc;
            p[46] = new SqlParameter("@Board_Id", SqlDbType.NVarChar);
            p[46].Value = Board_Id;
            p[47] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[47].Value = Board_Desc;
            p[48] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[48].Value = Section_Id;
            p[49] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[49].Value = Section_Desc;
            p[50] = new SqlParameter("@Year_of_Passing_ID", SqlDbType.NVarChar);
            p[50].Value = Year_of_Passing_ID;
            p[51] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[51].Value = Year_of_Passing_Desc;
            p[52] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[52].Value = Current_Year_Id;
            p[53] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[53].Value = Current_Year_Desc;
            p[54] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
            p[54].Value = Student_Id;
            p[55] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[55].Value = Last_Course_Opted;

            p[56] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[56].Value = SecContactType;
            p[57] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[57].Value = SecTitle;
            p[58] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[58].Value = Secfname;
            p[59] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[59].Value = SecMname;
            p[60] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[60].Value = SecLname;
            p[61] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[61].Value = Sechphone1;
            p[62] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[62].Value = Sechphone2;
            p[63] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[63].Value = Seclandline;
            p[64] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[64].Value = Secemail;
            p[65] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[65].Value = SecAdd1;
            p[66] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[66].Value = Secadd2;
            p[67] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[67].Value = SecStreetname;
            p[68] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[68].Value = SecCountryname;
            p[69] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[69].Value = SecState;
            p[70] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[70].Value = SecCity;
            p[71] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[71].Value = Secpincode;
            p[72] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[72].Value = SecContactDesc;
            p[73] = new SqlParameter("@total_ms_marks", SqlDbType.Int);
            p[73].Value = TotalMSmarks;
            p[74] = new SqlParameter("@total_ms_marks_obt", SqlDbType.Int);
            p[74].Value = TotalMSmarksobt;
            p[75] = new SqlParameter("@lead_Source_desc", SqlDbType.NVarChar);
            p[75].Value = Sourcedesc;
            p[76] = new SqlParameter("@dob", SqlDbType.NVarChar);
            p[76].Value = dob;
            p[77] = new SqlParameter("@last_exam", SqlDbType.NVarChar);
            p[77].Value = Examination;
            p[78] = new SqlParameter("@location", SqlDbType.NVarChar);
            p[78].Value = Location;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Lead_Contact", p);
            return (p[9].Value.ToString());
        }

        public static DataSet Get_center_target_analysis(string flag, string UserID, string source, string category, string company, string division, string zone, string center, string year, string product,
        string fromdate, string todate, string yeareducation)
        {

            SqlParameter p = new SqlParameter("@flag", SqlDbType.NVarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p1.Value = UserID;
            SqlParameter p2 = new SqlParameter("@source", SqlDbType.NVarChar);
            p2.Value = source;
            SqlParameter p3 = new SqlParameter("@category", SqlDbType.NVarChar);
            p3.Value = category;
            SqlParameter p4 = new SqlParameter("@company", SqlDbType.NVarChar);
            p4.Value = company;
            SqlParameter p5 = new SqlParameter("@division", SqlDbType.NVarChar);
            p5.Value = division;
            SqlParameter p6 = new SqlParameter("@zone", SqlDbType.NVarChar);
            p6.Value = zone;
            SqlParameter p7 = new SqlParameter("@center", SqlDbType.NVarChar);
            p7.Value = center;
            SqlParameter p8 = new SqlParameter("@year", SqlDbType.NVarChar);
            p8.Value = year;
            SqlParameter p9 = new SqlParameter("@product", SqlDbType.NVarChar);
            p9.Value = product;
            SqlParameter p10 = new SqlParameter("@fromdate", SqlDbType.NVarChar);
            p10.Value = fromdate;
            SqlParameter p11 = new SqlParameter("@todate", SqlDbType.NVarChar);
            p11.Value = todate;
            SqlParameter p12 = new SqlParameter("@yeareducation", SqlDbType.NVarChar);
            p12.Value = yeareducation;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Analysis_Source_Target_Center", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12));
        }
        public static DataSet ShowImportData(string flag, string Acadyear, string yeareducation, string userid, string LeadSource, string Leadstatus, string createdfrom, string createdto, string response)
        {

            SqlParameter p = new SqlParameter("@flag", SqlDbType.NVarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@year1", SqlDbType.NVarChar);
            p1.Value = Acadyear;
            SqlParameter p2 = new SqlParameter("@yr_education", SqlDbType.NVarChar);
            p2.Value = yeareducation;
            SqlParameter p3 = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p3.Value = userid;
            SqlParameter p4 = new SqlParameter("@source", SqlDbType.NVarChar);
            p4.Value = LeadSource;
            SqlParameter p5 = new SqlParameter("@status", SqlDbType.NVarChar);
            p5.Value = Leadstatus;
            SqlParameter p6 = new SqlParameter("@from", SqlDbType.NVarChar);
            p6.Value = createdfrom;
            SqlParameter p7 = new SqlParameter("@to", SqlDbType.NVarChar);
            p7.Value = createdto;
            SqlParameter p8 = new SqlParameter("@responseid", SqlDbType.NVarChar);
            p8.Value = response;


            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Import_LeadContacts", p, p1, p2, p3, p4, p5, p6,
            p7, p8));
        }
        public static string ImportData(string flag, string Acadyear, string yeareducation, string userid, string LeadSource, string Leadstatus, string createdfrom, string createdto, string response)
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@flag", SqlDbType.NVarChar);
            p[0].Value = flag;
            p[1] = new SqlParameter("@year1", SqlDbType.NVarChar);
            p[1].Value = Acadyear;
            p[2] = new SqlParameter("@yr_education", SqlDbType.NVarChar);
            p[2].Value = yeareducation;
            p[3] = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p[3].Value = userid;
            p[4] = new SqlParameter("@source", SqlDbType.NVarChar);
            p[4].Value = LeadSource;
            p[5] = new SqlParameter("@status", SqlDbType.NVarChar);
            p[5].Value = Leadstatus;
            p[6] = new SqlParameter("@from", SqlDbType.NVarChar);
            p[6].Value = createdfrom;
            p[7] = new SqlParameter("@to", SqlDbType.NVarChar);
            p[7].Value = createdto;
            p[8] = new SqlParameter("@responseid", SqlDbType.NVarChar, 10);
            p[8].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Import_LeadContacts", p);
            return (p[8].Value.ToString());
            //Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Import_LeadContacts", p, p1, p2, p3, p4, p5, p6, p7, p8))
        }

        public static DataSet Get_Score_analysis(string flag, string UserID, string source, string category, string company, string division, string zone, string center, string year, string product,
        string fromdate, string todate, string scoref1, string scoret1, string scoref2, string scoret2, string scoref3, string scoret3, string scoref4, string scoret4)
        {

            SqlParameter p = new SqlParameter("@flag", SqlDbType.NVarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p1.Value = UserID;
            SqlParameter p2 = new SqlParameter("@source", SqlDbType.NVarChar);
            p2.Value = source;
            SqlParameter p3 = new SqlParameter("@category", SqlDbType.NVarChar);
            p3.Value = category;
            SqlParameter p4 = new SqlParameter("@company", SqlDbType.NVarChar);
            p4.Value = company;
            SqlParameter p5 = new SqlParameter("@division", SqlDbType.NVarChar);
            p5.Value = division;
            SqlParameter p6 = new SqlParameter("@zone", SqlDbType.NVarChar);
            p6.Value = zone;
            SqlParameter p7 = new SqlParameter("@center", SqlDbType.NVarChar);
            p7.Value = center;
            SqlParameter p8 = new SqlParameter("@year", SqlDbType.NVarChar);
            p8.Value = year;
            SqlParameter p9 = new SqlParameter("@product", SqlDbType.NVarChar);
            p9.Value = product;
            SqlParameter p10 = new SqlParameter("@fromdate", SqlDbType.NVarChar);
            p10.Value = fromdate;
            SqlParameter p11 = new SqlParameter("@todate", SqlDbType.NVarChar);
            p11.Value = todate;
            SqlParameter p12 = new SqlParameter("@scoref1", SqlDbType.NVarChar);
            p12.Value = scoref1;
            SqlParameter p13 = new SqlParameter("@scoret1", SqlDbType.NVarChar);
            p13.Value = scoret1;
            SqlParameter p14 = new SqlParameter("@scoref2", SqlDbType.NVarChar);
            p14.Value = scoref2;
            SqlParameter p15 = new SqlParameter("@scoret2", SqlDbType.NVarChar);
            p15.Value = scoret2;
            SqlParameter p16 = new SqlParameter("@scoref3", SqlDbType.NVarChar);
            p16.Value = scoref3;
            SqlParameter p17 = new SqlParameter("@scoret3", SqlDbType.NVarChar);
            p17.Value = scoret3;
            SqlParameter p18 = new SqlParameter("@scoref4", SqlDbType.NVarChar);
            p18.Value = scoref4;
            SqlParameter p19 = new SqlParameter("@scoret4", SqlDbType.NVarChar);
            p19.Value = scoret4;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Score_Analysis", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
            p17, p18, p19));
        }
        public static DataSet Get_Lead_Contact_Search_Results(string leadtypeid, string leadstatusid, string leadsourceid, string Userid, string Contact_Company, string Contact_Source_Division, string Contact_Source_Zone, string Contact_Source_Center, string Contact_Target_Division, string Contact_Target_Zone,
        string Contact_Target_Center, string Studentname, string Leadcreatedonfrom, string Leadcreatedonto, string Country, string State, string City, string Customertype, string Institutiontype, string Board,
        string Standard, string Year, string Courseinterested, string Followupfrom, string Followupto, int Overdue, string agefrom, string ageto, string Blocked, string Examinationdetails,
        string Scoretype, string Conditiontype, string Score, string Gender, string acadyear, string yeareducation)
        {
            SqlParameter p = new SqlParameter("@Leadtypeid", SqlDbType.NVarChar);
            p.Value = leadtypeid;
            SqlParameter p1 = new SqlParameter("@leadsourceid", SqlDbType.NVarChar);
            p1.Value = leadsourceid;
            SqlParameter p2 = new SqlParameter("@leadstatusid", SqlDbType.NVarChar);
            p2.Value = leadstatusid;
            SqlParameter p3 = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p3.Value = Userid;
            SqlParameter p4 = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p4.Value = Contact_Company;
            SqlParameter p5 = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p5.Value = Contact_Source_Division;
            SqlParameter p6 = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p6.Value = Contact_Source_Zone;
            SqlParameter p7 = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p7.Value = Contact_Source_Center;
            SqlParameter p8 = new SqlParameter("@Contact_Source_Division", SqlDbType.NVarChar);
            p8.Value = Contact_Target_Division;
            SqlParameter p9 = new SqlParameter("@Contact_Source_Zone", SqlDbType.NVarChar);
            p9.Value = Contact_Target_Zone;
            SqlParameter p10 = new SqlParameter("@Contact_Source_Center", SqlDbType.NVarChar);
            p10.Value = Contact_Target_Center;
            SqlParameter p11 = new SqlParameter("@Studentname", SqlDbType.NVarChar);
            p11.Value = Studentname;

            SqlParameter p12 = new SqlParameter("@leadcreatedon_from", SqlDbType.NVarChar);
            p12.Value = Leadcreatedonfrom;
            SqlParameter p13 = new SqlParameter("@leadcreatedon_to", SqlDbType.NVarChar);
            p13.Value = Leadcreatedonto;
            SqlParameter p14 = new SqlParameter("@country", SqlDbType.NVarChar);
            p14.Value = Country;
            SqlParameter p15 = new SqlParameter("@state", SqlDbType.NVarChar);
            p15.Value = State;
            SqlParameter p16 = new SqlParameter("@city", SqlDbType.NVarChar);
            p16.Value = City;
            SqlParameter p17 = new SqlParameter("@customertype", SqlDbType.NVarChar);
            p17.Value = Customertype;
            SqlParameter p18 = new SqlParameter("@institutiontype", SqlDbType.NVarChar);
            p18.Value = Institutiontype;
            SqlParameter p19 = new SqlParameter("@board", SqlDbType.NVarChar);
            p19.Value = Board;
            SqlParameter p20 = new SqlParameter("@standard", SqlDbType.NVarChar);
            p20.Value = Standard;
            SqlParameter p21 = new SqlParameter("@year", SqlDbType.NVarChar);
            p21.Value = Year;

            SqlParameter p22 = new SqlParameter("@course_interest", SqlDbType.NVarChar);
            p22.Value = Courseinterested;
            SqlParameter p23 = new SqlParameter("@followup_from", SqlDbType.NVarChar);
            p23.Value = Followupfrom;
            SqlParameter p24 = new SqlParameter("@followup_to", SqlDbType.NVarChar);
            p24.Value = Followupto;
            SqlParameter p25 = new SqlParameter("@overdue", SqlDbType.Int);
            p25.Value = Overdue;

            SqlParameter p26 = new SqlParameter("@agefrom", SqlDbType.NVarChar);
            p26.Value = agefrom;
            SqlParameter p27 = new SqlParameter("@ageto", SqlDbType.NVarChar);
            p27.Value = ageto;
            SqlParameter p28 = new SqlParameter("@blocked", SqlDbType.NVarChar);
            p28.Value = Blocked;
            SqlParameter p29 = new SqlParameter("@xam_details", SqlDbType.NVarChar);
            p29.Value = Examinationdetails;

            SqlParameter p30 = new SqlParameter("@scoretype", SqlDbType.NVarChar);
            p30.Value = Scoretype;
            SqlParameter p31 = new SqlParameter("@condition", SqlDbType.NVarChar);
            p31.Value = Conditiontype;
            SqlParameter p32 = new SqlParameter("@score", SqlDbType.NVarChar);
            p32.Value = Score;
            SqlParameter p33 = new SqlParameter("@gender", SqlDbType.NVarChar);
            p33.Value = Gender;
            SqlParameter p34 = new SqlParameter("@acadyear", SqlDbType.NVarChar);
            p34.Value = acadyear;
            SqlParameter p35 = new SqlParameter("@yeareducation", SqlDbType.NVarChar);
            p35.Value = yeareducation;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_Contact_Search_Results", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
            p17, p18, p19, p20, p21, p22, p23, p24, p25, p26,
            p27, p28, p29, p30, p31, p32, p33, p34, p35));
        }

        //Public Shared Function Get_Opportunity_Search_Results(ByVal Productcategory As String, ByVal Salesstage As String, _
        //                                                       ByVal OpporStatus As String, ByVal Userid As String, ByVal isadmin As String, _
        //                                                       ByVal Contact_Company As String, _
        //                                                       ByVal Contact_Division As String, ByVal Contact_Zone As String, _
        //                                                       ByVal Contact_Center As String, ByVal Studentname As String) As DataSet
        //    Dim p As New SqlParameter("@Productcategory", SqlDbType.NVarChar)
        //    p.Value = Productcategory
        //    Dim p1 As New SqlParameter("@Salesstage", SqlDbType.NVarChar)
        //    p1.Value = Salesstage
        //    Dim p2 As New SqlParameter("@OpporStatus", SqlDbType.NVarChar)
        //    p2.Value = OpporStatus
        //    Dim p3 As New SqlParameter("@Userid", SqlDbType.NVarChar)
        //    p3.Value = Userid
        //    Dim p4 As New SqlParameter("@is_admin", SqlDbType.NVarChar)
        //    p4.Value = isadmin

        //    Dim p5 As New SqlParameter("@Contact_Company", SqlDbType.NVarChar)
        //    p5.Value = Contact_Company
        //    Dim p6 As New SqlParameter("@Contact_Division", SqlDbType.NVarChar)
        //    p6.Value = Contact_Division
        //    Dim p7 As New SqlParameter("@Contact_Zone", SqlDbType.NVarChar)
        //    p7.Value = Contact_Zone
        //    Dim p8 As New SqlParameter("@Contact_Center", SqlDbType.NVarChar)
        //    p8.Value = Contact_Center
        //    Dim p9 As New SqlParameter("@Studentname", SqlDbType.NVarChar)
        //    p9.Value = Studentname
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Opportunity_Search_Results", p, p1, p2, p3, p4, p5, p6, p7, p8, p9))
        //End Function

        //Public Shared Function Get_Opportunity_Search_Results(ByVal Productcategory As String, ByVal Salesstage As String, _
        //                                                       ByVal OpporStatus As String, ByVal Userid As String, _
        //                                                       ByVal Contact_Company As String, _
        //                                                       ByVal Contact_Division As String, ByVal Contact_Zone As String, _
        //                                                       ByVal Contact_Center As String, ByVal Studentname As String) As DataSet
        //    Dim p As New SqlParameter("@Productcategory", SqlDbType.NVarChar)
        //    p.Value = Productcategory
        //    Dim p1 As New SqlParameter("@Salesstage", SqlDbType.NVarChar)
        //    p1.Value = Salesstage
        //    Dim p2 As New SqlParameter("@OpporStatus", SqlDbType.NVarChar)
        //    p2.Value = OpporStatus
        //    Dim p3 As New SqlParameter("@Userid", SqlDbType.NVarChar)
        //    p3.Value = Userid
        //    Dim p4 As New SqlParameter("@Contact_Company", SqlDbType.NVarChar)
        //    p4.Value = Contact_Company
        //    Dim p5 As New SqlParameter("@Contact_Division", SqlDbType.NVarChar)
        //    p5.Value = Contact_Division
        //    Dim p6 As New SqlParameter("@Contact_Zone", SqlDbType.NVarChar)
        //    p6.Value = Contact_Zone
        //    Dim p7 As New SqlParameter("@Contact_Center", SqlDbType.NVarChar)
        //    p7.Value = Contact_Center
        //    Dim p8 As New SqlParameter("@Studentname", SqlDbType.NVarChar)
        //    p8.Value = Studentname
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Opportunity_Search_Results", p, p1, p2, p3, p4, p5, p6, p7, p8))
        //End Function



        public static DataSet Get_Contact_Search_Results(string leadtypeid, string leadstatusid, string leadsourceid, string Userid, string Contact_Company, string Contact_Source_Division, string Contact_Source_Zone, string Contact_Source_Center, string Contact_Target_Division, string Contact_Target_Zone,
        string Contact_Target_Center, string Studentname)
        {
            SqlParameter p = new SqlParameter("@Leadtypeid", SqlDbType.NVarChar);
            p.Value = leadtypeid;
            SqlParameter p1 = new SqlParameter("@leadsourceid", SqlDbType.NVarChar);
            p1.Value = leadsourceid;
            SqlParameter p2 = new SqlParameter("@leadstatusid", SqlDbType.NVarChar);
            p2.Value = leadstatusid;
            SqlParameter p3 = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p3.Value = Userid;
            SqlParameter p4 = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p4.Value = Contact_Company;
            SqlParameter p5 = new SqlParameter("@Contact_Source_Division", SqlDbType.NVarChar);
            p5.Value = Contact_Source_Division;
            SqlParameter p6 = new SqlParameter("@Contact_Source_Zone", SqlDbType.NVarChar);
            p6.Value = Contact_Source_Zone;
            SqlParameter p7 = new SqlParameter("@Contact_Source_Center", SqlDbType.NVarChar);
            p7.Value = Contact_Source_Center;
            SqlParameter p8 = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p8.Value = Contact_Target_Division;
            SqlParameter p9 = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p9.Value = Contact_Target_Zone;
            SqlParameter p10 = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p10.Value = Contact_Target_Center;
            SqlParameter p11 = new SqlParameter("@Studentname", SqlDbType.NVarChar);
            p11.Value = Studentname;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_Contact_Search_Results", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11));
        }



        //Public Shared Function Getleaddetailsbyleadid(ByVal leadid As String) As DataSet
        //    Dim p As New SqlParameter("@Leadtypeid", SqlDbType.NVarChar)
        //    p.Value = leadid
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_Contact_Search_Results", p, p1, p2))
        //End Function

        public static SqlDataReader Getleaddetailsbyleadid(string leadid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@leadid", SqlDbType.NVarChar);
            p[0].Value = leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_LeadContactdetailsbyleadid", p));
        }

        public static SqlDataReader GetProbabiltyPercent(string SalesStageid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@SalesStageid", SqlDbType.NVarChar);
            p[0].Value = SalesStageid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetProbabilityPercentbySalesStageid", p));
        }

        public static SqlDataReader Getreceiptdetailsbyreceiptid(string Receiptid, int Flag)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@receiptcode", SqlDbType.NVarChar);
            p[0].Value = Receiptid;
            p[1] = new SqlParameter("@flag", SqlDbType.Int);
            p[1].Value = Flag;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_EditAllocate_Cheques", p));
        }

        public static SqlDataReader GetOppordetailsbyOpporid(string leadid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Opporid", SqlDbType.NVarChar);
            p[0].Value = leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_OpporContactdetailsbyOpporid", p));
        }


        public static string InsertFeedback(string Feedbackid, string Taskid, string Leadid, string Interacted_With, string Interacted_Relation, string Interacted_On, string Feedback, string Feedback_Status, string Updatedby, string SeminarStatus,
        string NextFollowupdate)
        {
            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@feedbackid", SqlDbType.NVarChar);
            p[0].Value = Feedbackid;
            p[1] = new SqlParameter("@task_id", SqlDbType.NVarChar);
            p[1].Value = Taskid;
            p[2] = new SqlParameter("@Lead_id", SqlDbType.NVarChar);
            p[2].Value = Leadid;
            p[3] = new SqlParameter("@Interactedwith", SqlDbType.NVarChar);
            p[3].Value = Interacted_With;
            p[4] = new SqlParameter("@InteractedRelation", SqlDbType.NVarChar);
            p[4].Value = Interacted_Relation;
            p[5] = new SqlParameter("@Interacted_On", SqlDbType.NVarChar);
            p[5].Value = Interacted_On;
            p[6] = new SqlParameter("@feedback", SqlDbType.NVarChar);
            p[6].Value = Feedback;
            p[7] = new SqlParameter("@Feedback_Status", SqlDbType.NVarChar);
            p[7].Value = Feedback_Status;
            p[8] = new SqlParameter("@feedback_Out", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            p[9] = new SqlParameter("@Updated_By", SqlDbType.NVarChar);
            p[9].Value = Updatedby;
            p[10] = new SqlParameter("@SeminarStatus", SqlDbType.NVarChar);
            p[10].Value = SeminarStatus;
            p[11] = new SqlParameter("@NextFollowupDate", SqlDbType.NVarChar);
            p[11].Value = NextFollowupdate;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadfeedback", p);
            return (p[8].Value.ToString());
        }

        public static string InsertFeedbackOpportunity(string Feedbackid, string Taskid, string Leadid, string Interacted_With, string Interacted_Relation, string Interacted_On, string Feedback, string Feedback_Status, string Updatedby, string SeminarStatus,
        string Oppor_Sales_Stage, string Oppor_Sales_Stage_id, string NextFollowupdate, string Appno)
        {
            SqlParameter[] p = new SqlParameter[15];
            p[0] = new SqlParameter("@feedbackid", SqlDbType.NVarChar);
            p[0].Value = Feedbackid;
            p[1] = new SqlParameter("@task_id", SqlDbType.NVarChar);
            p[1].Value = Taskid;
            p[2] = new SqlParameter("@lead_Id", SqlDbType.NVarChar);
            p[2].Value = Leadid;
            p[3] = new SqlParameter("@Interactedwith", SqlDbType.NVarChar);
            p[3].Value = Interacted_With;
            p[4] = new SqlParameter("@InteractedRelation", SqlDbType.NVarChar);
            p[4].Value = Interacted_Relation;
            p[5] = new SqlParameter("@Interacted_On", SqlDbType.NVarChar);
            p[5].Value = Interacted_On;
            p[6] = new SqlParameter("@feedback", SqlDbType.NVarChar);
            p[6].Value = Feedback;
            p[7] = new SqlParameter("@Feedback_Status", SqlDbType.NVarChar);
            p[7].Value = Feedback_Status;
            p[8] = new SqlParameter("@feedback_Out", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            p[9] = new SqlParameter("@Updated_By", SqlDbType.NVarChar);
            p[9].Value = Updatedby;
            p[10] = new SqlParameter("@SeminarStatus", SqlDbType.NVarChar);
            p[10].Value = SeminarStatus;
            p[11] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[11].Value = Oppor_Sales_Stage;
            p[12] = new SqlParameter("@Sales_Stage_id", SqlDbType.NVarChar);
            p[12].Value = Oppor_Sales_Stage_id;
            p[13] = new SqlParameter("@NextFollowupDate", SqlDbType.NVarChar);
            p[13].Value = NextFollowupdate;
            p[14] = new SqlParameter("@AppNo", SqlDbType.NVarChar, 10);
            p[14].Value = Appno;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadfeedbackOpportunity", p);
            return (p[8].Value.ToString());
        }

        public static string InsertOpportunity(string Opportunity_id, string Opp_TYpe_Id, string Opp_Name, string Leadid, string Product_Category, string Product_Code, string Sales_Stage, System.DateTime Opp_Join_Date, System.DateTime Opp_Expected_Close_Date, string Opp_Probability_Percent,
        string Opp_Next_Step, decimal Opp_Value, decimal Opp_Disc, string Opp_Contact_Company, string Opp_Contact_Division, string Opp_Contact_Center, string Opp_Contact_Zone, string Opp_Contact_Role, string Opp_Contact_AssignTo, string Created_By,
        string last_Modified_By, string Opp_Status, string Opp_Status_id, string Oppor_product, string Oppor_Product_id, string Acad_Year, string App_no, string SalesChannel_Id, string SalesChannel, string Disc_remark)
        {
            SqlParameter[] p = new SqlParameter[31];
            p[0] = new SqlParameter("@Oppur_Id", SqlDbType.NVarChar);
            p[0].Value = Opportunity_id;
            p[1] = new SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar);
            p[1].Value = Opp_TYpe_Id;
            p[2] = new SqlParameter("@Opp_Name", SqlDbType.NVarChar);
            p[2].Value = Opp_Name;
            p[3] = new SqlParameter("@Lead_Id", SqlDbType.NVarChar);
            p[3].Value = Leadid;
            p[4] = new SqlParameter("@Product_Category", SqlDbType.NVarChar);
            p[4].Value = Product_Category;
            p[5] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
            p[5].Value = Product_Code;
            p[6] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[6].Value = Sales_Stage;
            p[7] = new SqlParameter("@Opp_Join_Date", SqlDbType.DateTime);
            p[7].Value = Opp_Join_Date;

            p[8] = new SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime);
            p[8].Value = Opp_Expected_Close_Date;
            p[9] = new SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar);
            p[9].Value = Opp_Probability_Percent;
            p[10] = new SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar);
            p[10].Value = Opp_Next_Step;
            p[11] = new SqlParameter("@Opp_Value", SqlDbType.Decimal);
            p[11].Value = Opp_Value;
            p[12] = new SqlParameter("@Opp_Disc", SqlDbType.Decimal);
            p[12].Value = Opp_Disc;

            p[13] = new SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar);
            p[13].Value = Opp_Contact_Company;
            p[14] = new SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar);
            p[14].Value = Opp_Contact_Division;
            p[15] = new SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar);
            p[15].Value = Opp_Contact_Center;
            p[16] = new SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar);
            p[16].Value = Opp_Contact_Zone;

            p[17] = new SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar);
            p[17].Value = Opp_Contact_Role;
            p[18] = new SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar);
            p[18].Value = Opp_Contact_AssignTo;
            p[19] = new SqlParameter("@Created_By", SqlDbType.NVarChar);
            p[19].Value = Created_By;
            p[20] = new SqlParameter("@last_Modified_By", SqlDbType.NVarChar);
            p[20].Value = last_Modified_By;

            p[21] = new SqlParameter("@Opp_Status", SqlDbType.NVarChar);
            p[21].Value = Opp_Status;
            p[22] = new SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar);
            p[22].Value = Opp_Status_id;

            p[23] = new SqlParameter("@Oppor_Product", SqlDbType.NVarChar);
            p[23].Value = Oppor_product;
            p[24] = new SqlParameter("@Oppor_Product_Id", SqlDbType.VarChar, 50);
            p[24].Value = Oppor_Product_id;

            p[25] = new SqlParameter("@Oppor_Id_Out", SqlDbType.NVarChar, 100);
            p[25].Direction = ParameterDirection.Output;

            p[26] = new SqlParameter("@Acad_year", SqlDbType.NVarChar);
            p[26].Value = Acad_Year;
            p[27] = new SqlParameter("@App_no", SqlDbType.NVarChar);
            p[27].Value = App_no;

            p[28] = new SqlParameter("@SalesStage_Id", SqlDbType.NVarChar);
            p[28].Value = SalesChannel_Id;
            p[29] = new SqlParameter("@SalesStage_Desc", SqlDbType.NVarChar);
            p[29].Value = SalesChannel;

            p[30] = new SqlParameter("@Disc_Remark", SqlDbType.NVarChar);
            p[30].Value = Disc_remark;


            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertOpportunity", p);
            return (p[25].Value.ToString());
        }


        //public static string UpdateOpportunityContact(string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank, int Overallrank, string Scorerange, string Handphone1,
        //string handphone2, string landline, string emailid, string Flatno, string buildingname, string streetname, string Countryname, string State, string City, string pincode,
        //string Category_Type_Id, string Category_Type, string Institution_Type_Id, string Institution_Type_Desc, string Institution_Description, string Current_Standard_Id, string Current_Standard_Desc, string Additional_Desc, string Board_Id, string Board_Desc,
        //string Section_Id, string Section_Desc, string Year_of_Passing_ID, string Year_of_Passing_Desc, string Current_Year_Id, string Current_Year_Desc, string Student_Id, string Last_Course_Opted, string Opp_Type_ID, string Opp_Name,
        //string Product_Category, string Product_Code, string Sales_Stage, System.DateTime Opp_Join_Date, System.DateTime Opp_Expected_Close_Date, string Opp_Probability_Percent, string Opp_Next_Step, decimal Opp_Value, decimal Opp_Disc, string Opp_Contact_Company,
        //string Opp_ContactSource_Division, string Opp_ContactSource_Center, string Opp_ContactSource_Zone, string Opp_Contact_Division, string Opp_Contact_Center, string Opp_Contact_Zone, string Opp_Contact_Role, string Opp_Contact_Assignto, string Last_Modified_By, string Opp_Status,
        //string Opp_Status_Id, string Oppor_Product, string Oppor_Product_Id, string oppid, string appno, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname,
        //string Sechphone1, string Sechphone2, string Seclandline, string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity,
        //string Secpincode, string SecContactDesc, int discipline_id, string Discipline_desc, int Field_Id, string Field_Desc, string Competitive_Exam, int Totalmsmarks, int Totalmsmarksobt, string Opp_Contact_target_Company,
        //string dob, string last_exam, string location, string gender, string discountnotes)
        //{
        //    SqlParameter[] p = new SqlParameter[96];
        //    p[0] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
        //    p[0].Value = CON_TITLE;
        //    p[1] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
        //    p[1].Value = CON_FIRSTNAME;
        //    p[2] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
        //    p[2].Value = CON_MNAME;
        //    p[3] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
        //    p[3].Value = CON_LNAME;
        //    p[4] = new SqlParameter("@Score", SqlDbType.Decimal);
        //    p[4].Value = Score;
        //    p[5] = new SqlParameter("@Percentile", SqlDbType.Decimal);
        //    p[5].Value = percentile;
        //    p[6] = new SqlParameter("@Area_rank", SqlDbType.NVarChar);
        //    p[6].Value = Area_rank;
        //    p[7] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
        //    p[7].Value = Overallrank;
        //    p[8] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
        //    p[8].Value = Scorerange;
        //    p[9] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
        //    p[9].Value = Handphone1;
        //    p[10] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
        //    p[10].Value = handphone2;
        //    p[11] = new SqlParameter("@Landline", SqlDbType.NVarChar);
        //    p[11].Value = landline;
        //    p[12] = new SqlParameter("@emailid", SqlDbType.NVarChar);
        //    p[12].Value = emailid;
        //    p[13] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
        //    p[13].Value = Flatno;
        //    p[14] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
        //    p[14].Value = buildingname;
        //    p[15] = new SqlParameter("@streetname", SqlDbType.NVarChar);
        //    p[15].Value = streetname;
        //    p[16] = new SqlParameter("@Country", SqlDbType.NVarChar);
        //    p[16].Value = Countryname;
        //    p[17] = new SqlParameter("@State", SqlDbType.NVarChar);
        //    p[17].Value = State;
        //    p[18] = new SqlParameter("@City", SqlDbType.NVarChar);
        //    p[18].Value = City;
        //    p[19] = new SqlParameter("@pincode", SqlDbType.NVarChar);
        //    p[19].Value = pincode;
        //    p[20] = new SqlParameter("@Category_Type_Id", SqlDbType.NVarChar);
        //    p[20].Value = Category_Type_Id;
        //    p[21] = new SqlParameter("@Category_Type", SqlDbType.NVarChar);
        //    p[21].Value = Category_Type;

        //    p[22] = new SqlParameter("@Institution_Type_Id", SqlDbType.NVarChar);
        //    p[22].Value = Institution_Type_Id;
        //    p[23] = new SqlParameter("@Institution_Type_Desc", SqlDbType.NVarChar);
        //    p[23].Value = Institution_Type_Desc;
        //    p[24] = new SqlParameter("@Institution_Description", SqlDbType.NVarChar);
        //    p[24].Value = Institution_Description;
        //    p[25] = new SqlParameter("@Current_Standard_id", SqlDbType.NVarChar);
        //    p[25].Value = Current_Standard_Id;
        //    p[26] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
        //    p[26].Value = Current_Standard_Desc;
        //    p[27] = new SqlParameter("@Additional_desc", SqlDbType.NVarChar);
        //    p[27].Value = Additional_Desc;
        //    p[28] = new SqlParameter("@Board_Id", SqlDbType.VarChar);
        //    p[28].Value = Board_Id;
        //    p[29] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
        //    p[29].Value = Board_Desc;
        //    p[30] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
        //    p[30].Value = Section_Id;
        //    p[31] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
        //    p[31].Value = Section_Desc;
        //    p[32] = new SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar);
        //    p[32].Value = Year_of_Passing_ID;
        //    p[33] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
        //    p[33].Value = Year_of_Passing_Desc;
        //    p[34] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
        //    p[34].Value = Current_Year_Id;
        //    p[35] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
        //    p[35].Value = Current_Year_Desc;
        //    p[36] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
        //    p[36].Value = Student_Id;
        //    p[37] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
        //    p[37].Value = Last_Course_Opted;

        //    p[38] = new SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar);
        //    p[38].Value = Opp_Type_ID;
        //    p[39] = new SqlParameter("@Opp_Name", SqlDbType.NVarChar);
        //    p[39].Value = Opp_Name;

        //    p[40] = new SqlParameter("@Product_Category", SqlDbType.NVarChar);
        //    p[40].Value = Product_Category;
        //    p[41] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
        //    p[41].Value = Product_Code;
        //    p[42] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
        //    p[42].Value = Sales_Stage;
        //    p[43] = new SqlParameter("@Opp_Join_Date", SqlDbType.DateTime);
        //    p[43].Value = Opp_Join_Date;

        //    p[44] = new SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime);
        //    p[44].Value = Opp_Expected_Close_Date;
        //    p[45] = new SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar);
        //    p[45].Value = Opp_Probability_Percent;
        //    p[46] = new SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar);
        //    p[46].Value = Opp_Next_Step;
        //    p[47] = new SqlParameter("@Opp_Value", SqlDbType.Decimal);
        //    p[47].Value = Opp_Value;
        //    p[48] = new SqlParameter("@Opp_Disc", SqlDbType.Decimal);
        //    p[48].Value = Opp_Disc;

        //    p[49] = new SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar);
        //    p[49].Value = Opp_Contact_Company;
        //    p[50] = new SqlParameter("@Opp_ContactSource_Division", SqlDbType.NVarChar);
        //    p[50].Value = Opp_ContactSource_Division;
        //    p[51] = new SqlParameter("@Opp_ContactSource_Center", SqlDbType.NVarChar);
        //    p[51].Value = Opp_ContactSource_Center;
        //    p[52] = new SqlParameter("@Opp_ContactSource_Zone", SqlDbType.NVarChar);
        //    p[52].Value = Opp_ContactSource_Zone;

        //    p[53] = new SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar);
        //    p[53].Value = Opp_Contact_Division;
        //    p[54] = new SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar);
        //    p[54].Value = Opp_Contact_Center;
        //    p[55] = new SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar);
        //    p[55].Value = Opp_Contact_Zone;

        //    p[56] = new SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar);
        //    p[56].Value = Opp_Contact_Role;
        //    p[57] = new SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar);
        //    p[57].Value = Opp_Contact_Assignto;

        //    p[58] = new SqlParameter("@Userid", SqlDbType.NVarChar);
        //    p[58].Value = Last_Modified_By;
        //    p[59] = new SqlParameter("@Opp_Status", SqlDbType.NVarChar);
        //    p[59].Value = Opp_Status;
        //    p[60] = new SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar);
        //    p[60].Value = Opp_Status_Id;
        //    p[61] = new SqlParameter("@Oppor_Product", SqlDbType.NVarChar);
        //    p[61].Value = Oppor_Product;
        //    p[62] = new SqlParameter("@Oppor_Product_Id", SqlDbType.NVarChar, 100);
        //    p[62].Value = Oppor_Product_Id;
        //    p[63] = new SqlParameter("@oppid", SqlDbType.NVarChar);
        //    p[63].Value = oppid;
        //    p[64] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
        //    p[64].Direction = ParameterDirection.Output;
        //    p[65] = new SqlParameter("@appno", SqlDbType.NVarChar);
        //    p[65].Value = appno;

        //    p[66] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
        //    p[66].Value = SecContactType;
        //    p[67] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
        //    p[67].Value = SecTitle;
        //    p[68] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
        //    p[68].Value = Secfname;
        //    p[69] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
        //    p[69].Value = SecMname;
        //    p[70] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
        //    p[70].Value = SecLname;
        //    p[71] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
        //    p[71].Value = Sechphone1;
        //    p[72] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
        //    p[72].Value = Sechphone2;
        //    p[73] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
        //    p[73].Value = Seclandline;
        //    p[74] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
        //    p[74].Value = Secemail;
        //    p[75] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
        //    p[75].Value = SecAdd1;
        //    p[76] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
        //    p[76].Value = Secadd2;
        //    p[77] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
        //    p[77].Value = SecStreetname;
        //    p[78] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
        //    p[78].Value = SecCountryname;
        //    p[79] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
        //    p[79].Value = SecState;
        //    p[80] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
        //    p[80].Value = SecCity;
        //    p[81] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
        //    p[81].Value = Secpincode;
        //    p[82] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
        //    p[82].Value = SecContactDesc;
        //    p[83] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
        //    p[83].Value = discipline_id;
        //    p[84] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
        //    p[84].Value = Discipline_desc;
        //    p[85] = new SqlParameter("@Field_ID", SqlDbType.Int);
        //    p[85].Value = Field_Id;
        //    p[86] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
        //    p[86].Value = Field_Desc;
        //    p[87] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
        //    p[87].Value = Competitive_Exam;
        //    p[88] = new SqlParameter("@Total_ms_Marks", SqlDbType.Int);
        //    p[88].Value = Totalmsmarks;
        //    p[89] = new SqlParameter("@Total_ms_Marks_obt", SqlDbType.Int);
        //    p[89].Value = Totalmsmarksobt;
        //    p[90] = new SqlParameter("@Opp_Contact_Target_Company", SqlDbType.VarChar);
        //    p[90].Value = Opp_Contact_target_Company;

        //    p[91] = new SqlParameter("@dob", SqlDbType.VarChar);
        //    p[91].Value = dob;
        //    p[92] = new SqlParameter("@xam_details", SqlDbType.VarChar);
        //    p[92].Value = last_exam;
        //    p[93] = new SqlParameter("@location", SqlDbType.VarChar);
        //    p[93].Value = location;
        //    p[94] = new SqlParameter("@gender", SqlDbType.VarChar);
        //    p[94].Value = gender;
        //    p[95] = new SqlParameter("@discnotes", SqlDbType.VarChar);
        //    p[95].Value = discountnotes;
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Opp_Contact", p);
        //    return (p[64].Value.ToString());
        //}

        public static string UpdateOpportunityContact(string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank, int Overallrank, string Scorerange, string Handphone1,
        string handphone2, string landline, string emailid, string Flatno, string buildingname, string streetname, string Countryname, string State, string City, string pincode,
        string Category_Type_Id, string Category_Type, string Institution_Type_Id, string Institution_Type_Desc, string Institution_Description, string Current_Standard_Id, string Current_Standard_Desc, string Additional_Desc, string Board_Id, string Board_Desc,
        string Section_Id, string Section_Desc, string Year_of_Passing_ID, string Year_of_Passing_Desc, string Current_Year_Id, string Current_Year_Desc, string Student_Id, string Last_Course_Opted, string Opp_Type_ID, string Opp_Name,
        string Product_Category, string Product_Code, string Sales_Stage, System.DateTime Opp_Join_Date, System.DateTime Opp_Expected_Close_Date, string Opp_Probability_Percent, string Opp_Next_Step, decimal Opp_Value, decimal Opp_Disc, string Opp_Contact_Company,
        string Opp_ContactSource_Division, string Opp_ContactSource_Center, string Opp_ContactSource_Zone, string Opp_Contact_Division, string Opp_Contact_Center, string Opp_Contact_Zone, string Opp_Contact_Role, string Opp_Contact_Assignto, string Last_Modified_By, string Opp_Status,
        string Opp_Status_Id, string Oppor_Product, string Oppor_Product_Id, string oppid, string appno, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname,
        string Sechphone1, string Sechphone2, string Seclandline, string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity,
        string Secpincode, string SecContactDesc, int discipline_id, string Discipline_desc, int Field_Id, string Field_Desc, string Competitive_Exam, int Totalmsmarks, int Totalmsmarksobt, string Opp_Contact_target_Company,
        string dob, string last_exam, string location, string gender, string discountnotes, string Is_Branch_Topper, string Branch_Topper_Division, string Branch_Topper_Center,
        string Is_School_Ranker, string School_Name, string School_Division, string School_Rank,
          string Apply_Additional_Discount, string Discount_Type)
        {
            SqlParameter[] p = new SqlParameter[105];
            p[0] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[0].Value = CON_TITLE;
            p[1] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[1].Value = CON_FIRSTNAME;
            p[2] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[2].Value = CON_MNAME;
            p[3] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[3].Value = CON_LNAME;
            p[4] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[4].Value = Score;
            p[5] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[5].Value = percentile;
            p[6] = new SqlParameter("@Area_rank", SqlDbType.NVarChar);
            p[6].Value = Area_rank;
            p[7] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[7].Value = Overallrank;
            p[8] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[8].Value = Scorerange;
            p[9] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[9].Value = Handphone1;
            p[10] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[10].Value = handphone2;
            p[11] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[11].Value = landline;
            p[12] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[12].Value = emailid;
            p[13] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[13].Value = Flatno;
            p[14] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[14].Value = buildingname;
            p[15] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[15].Value = streetname;
            p[16] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[16].Value = Countryname;
            p[17] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[17].Value = State;
            p[18] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[18].Value = City;
            p[19] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[19].Value = pincode;
            p[20] = new SqlParameter("@Category_Type_Id", SqlDbType.NVarChar);
            p[20].Value = Category_Type_Id;
            p[21] = new SqlParameter("@Category_Type", SqlDbType.NVarChar);
            p[21].Value = Category_Type;

            p[22] = new SqlParameter("@Institution_Type_Id", SqlDbType.NVarChar);
            p[22].Value = Institution_Type_Id;
            p[23] = new SqlParameter("@Institution_Type_Desc", SqlDbType.NVarChar);
            p[23].Value = Institution_Type_Desc;
            p[24] = new SqlParameter("@Institution_Description", SqlDbType.NVarChar);
            p[24].Value = Institution_Description;
            p[25] = new SqlParameter("@Current_Standard_id", SqlDbType.NVarChar);
            p[25].Value = Current_Standard_Id;
            p[26] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[26].Value = Current_Standard_Desc;
            p[27] = new SqlParameter("@Additional_desc", SqlDbType.NVarChar);
            p[27].Value = Additional_Desc;
            p[28] = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            p[28].Value = Board_Id;
            p[29] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[29].Value = Board_Desc;
            p[30] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[30].Value = Section_Id;
            p[31] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[31].Value = Section_Desc;
            p[32] = new SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar);
            p[32].Value = Year_of_Passing_ID;
            p[33] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[33].Value = Year_of_Passing_Desc;
            p[34] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[34].Value = Current_Year_Id;
            p[35] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[35].Value = Current_Year_Desc;
            p[36] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
            p[36].Value = Student_Id;
            p[37] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[37].Value = Last_Course_Opted;

            p[38] = new SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar);
            p[38].Value = Opp_Type_ID;
            p[39] = new SqlParameter("@Opp_Name", SqlDbType.NVarChar);
            p[39].Value = Opp_Name;

            p[40] = new SqlParameter("@Product_Category", SqlDbType.NVarChar);
            p[40].Value = Product_Category;
            p[41] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
            p[41].Value = Product_Code;
            p[42] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[42].Value = Sales_Stage;
            p[43] = new SqlParameter("@Opp_Join_Date", SqlDbType.DateTime);
            p[43].Value = Opp_Join_Date;

            p[44] = new SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime);
            p[44].Value = Opp_Expected_Close_Date;
            p[45] = new SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar);
            p[45].Value = Opp_Probability_Percent;
            p[46] = new SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar);
            p[46].Value = Opp_Next_Step;
            p[47] = new SqlParameter("@Opp_Value", SqlDbType.Decimal);
            p[47].Value = Opp_Value;
            p[48] = new SqlParameter("@Opp_Disc", SqlDbType.Decimal);
            p[48].Value = Opp_Disc;

            p[49] = new SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar);
            p[49].Value = Opp_Contact_Company;
            p[50] = new SqlParameter("@Opp_ContactSource_Division", SqlDbType.NVarChar);
            p[50].Value = Opp_ContactSource_Division;
            p[51] = new SqlParameter("@Opp_ContactSource_Center", SqlDbType.NVarChar);
            p[51].Value = Opp_ContactSource_Center;
            p[52] = new SqlParameter("@Opp_ContactSource_Zone", SqlDbType.NVarChar);
            p[52].Value = Opp_ContactSource_Zone;

            p[53] = new SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar);
            p[53].Value = Opp_Contact_Division;
            p[54] = new SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar);
            p[54].Value = Opp_Contact_Center;
            p[55] = new SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar);
            p[55].Value = Opp_Contact_Zone;

            p[56] = new SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar);
            p[56].Value = Opp_Contact_Role;
            p[57] = new SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar);
            p[57].Value = Opp_Contact_Assignto;

            p[58] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[58].Value = Last_Modified_By;
            p[59] = new SqlParameter("@Opp_Status", SqlDbType.NVarChar);
            p[59].Value = Opp_Status;
            p[60] = new SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar);
            p[60].Value = Opp_Status_Id;
            p[61] = new SqlParameter("@Oppor_Product", SqlDbType.NVarChar);
            p[61].Value = Oppor_Product;
            p[62] = new SqlParameter("@Oppor_Product_Id", SqlDbType.NVarChar, 100);
            p[62].Value = Oppor_Product_Id;
            p[63] = new SqlParameter("@oppid", SqlDbType.NVarChar);
            p[63].Value = oppid;
            p[64] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[64].Direction = ParameterDirection.Output;
            p[65] = new SqlParameter("@appno", SqlDbType.NVarChar);
            p[65].Value = appno;

            p[66] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[66].Value = SecContactType;
            p[67] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[67].Value = SecTitle;
            p[68] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[68].Value = Secfname;
            p[69] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[69].Value = SecMname;
            p[70] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[70].Value = SecLname;
            p[71] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[71].Value = Sechphone1;
            p[72] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[72].Value = Sechphone2;
            p[73] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[73].Value = Seclandline;
            p[74] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[74].Value = Secemail;
            p[75] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[75].Value = SecAdd1;
            p[76] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[76].Value = Secadd2;
            p[77] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[77].Value = SecStreetname;
            p[78] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[78].Value = SecCountryname;
            p[79] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[79].Value = SecState;
            p[80] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[80].Value = SecCity;
            p[81] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[81].Value = Secpincode;
            p[82] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[82].Value = SecContactDesc;
            p[83] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[83].Value = discipline_id;
            p[84] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[84].Value = Discipline_desc;
            p[85] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[85].Value = Field_Id;
            p[86] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[86].Value = Field_Desc;
            p[87] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[87].Value = Competitive_Exam;
            p[88] = new SqlParameter("@Total_ms_Marks", SqlDbType.Int);
            p[88].Value = Totalmsmarks;
            p[89] = new SqlParameter("@Total_ms_Marks_obt", SqlDbType.Int);
            p[89].Value = Totalmsmarksobt;
            p[90] = new SqlParameter("@Opp_Contact_Target_Company", SqlDbType.VarChar);
            p[90].Value = Opp_Contact_target_Company;

            p[91] = new SqlParameter("@dob", SqlDbType.VarChar);
            p[91].Value = dob;
            p[92] = new SqlParameter("@xam_details", SqlDbType.VarChar);
            p[92].Value = last_exam;
            p[93] = new SqlParameter("@location", SqlDbType.VarChar);
            p[93].Value = location;
            p[94] = new SqlParameter("@gender", SqlDbType.VarChar);
            p[94].Value = gender;
            p[95] = new SqlParameter("@discnotes", SqlDbType.VarChar);
            p[95].Value = discountnotes;

            p[96] = new SqlParameter("@Is_Branch_Topper", SqlDbType.VarChar);
            p[96].Value = Is_Branch_Topper;
            p[97] = new SqlParameter("@Branch_Topper_Division", SqlDbType.VarChar);
            p[97].Value = Branch_Topper_Division;
            p[98] = new SqlParameter("@Branch_Topper_Center", SqlDbType.VarChar);
            p[98].Value = Branch_Topper_Center;
            p[99] = new SqlParameter("@Is_School_Ranker", SqlDbType.VarChar);
            p[99].Value = Is_School_Ranker;
            p[100] = new SqlParameter("@School_Name", SqlDbType.VarChar);
            p[100].Value = School_Name;
            p[101] = new SqlParameter("@School_Division", SqlDbType.VarChar);
            p[101].Value = School_Division;

            p[102] = new SqlParameter("@School_Rank", SqlDbType.VarChar);
            p[102].Value = School_Rank;
            p[103] = new SqlParameter("@Apply_Additional_Discount", SqlDbType.VarChar);
            p[103].Value = Apply_Additional_Discount;
            p[104] = new SqlParameter("@Discount_Type", SqlDbType.VarChar);
            p[104].Value = Discount_Type;



            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Opp_Contact", p);
            return (p[64].Value.ToString());
        }


        public static SqlDataReader GetOppdetailsbyoppid(string oppid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Oppid", SqlDbType.NVarChar);
            p[0].Value = oppid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_OppurtunityContactdetails_byOppid", p));
        }
        //USP_Add_Opportunity

        //Public Shared Function InsertAddOpportunity(
        //                                                 ByVal CON_ID As String, ByVal CON_TYPE_ID As String, _
        //                                        ByVal CON_TYPE_DESC As String, ByVal CON_TITLE As String, ByVal CON_FIRSTNAME As String, _
        //                                        ByVal CON_MNAME As String, ByVal CON_LNAME As String, _
        //                                        ByVal Score As Integer, ByVal percentile As Integer, _
        //                                        ByVal Area_rank As Integer, ByVal Overallrank As Integer, _
        //                                        ByVal Scorerange As String, ByVal Handphone1 As String, ByVal handphone2 As String, _
        //                                        ByVal landline As String, ByVal emailid As String, ByVal Flatno As String, ByVal buildingname As String, _
        //                                        ByVal streetname As String, ByVal Countryname As String, ByVal State As String, ByVal City As String, _
        //                                        ByVal pincode As String, _
        //                                        ByVal Category_Type_Id As String, ByVal Category_Type As String, _
        //                                        ByVal InstituteTypeid As String, ByVal InstituteTypeDesc As String, ByVal Institute_desc As String, _
        //                                        ByVal Current_Standardid As String, ByVal Current_StandardDesc As String, ByVal AdditionalDesc As String, _
        //                                        ByVal Boardid As String, ByVal Boarddesc As String, ByVal Sectionid As String, ByVal Sectiondesc As String, _
        //                                        ByVal Yearofpassingid As String, ByVal Yearofpassingdesc As String, ByVal CurrentYearid As String, _
        //                                        ByVal CurrentYeardesc As String, ByVal Studentid As String, ByVal LastCourseOpted As String, _
        //                                        ByVal Opportunity_id As String, ByVal Opp_TYpe_Id As String, ByVal Opp_Name As String, ByVal Leadid As String, _
        //                                        ByVal Product_Category As String, ByVal Product_Code As String, ByVal Sales_Stage As String, _
        //                                        ByVal Opp_Join_Date As Date, ByVal Opp_Expected_Close_Date As Date, ByVal Opp_Probability_Percent As String, _
        //                                        ByVal Opp_Next_Step As String, ByVal Opp_Value As Decimal, ByVal Opp_Disc As Decimal, ByVal Opp_Contact_Company As String, _
        //                                        ByVal Opp_Contact_Division As String, ByVal Opp_Contact_Center As String, ByVal Opp_Contact_Zone As String, ByVal Opp_Contact_Role As String, _
        //                                        ByVal Opp_Contact_AssignTo As String, ByVal Created_By As String, ByVal last_Modified_By As String, ByVal Opp_Status As String, ByVal Opp_Status_id As String,
        //                                        ByVal Oppor_product As String, ByVal Oppor_Product_id As String) As String
        //    Dim p As SqlParameter() = New SqlParameter(66) {}
        //    p(0) = New SqlParameter("@CON_ID", SqlDbType.NVarChar)
        //    p(0).Value = CON_ID
        //    p(1) = New SqlParameter("@CON_TYPE_ID", SqlDbType.NVarChar)
        //    p(1).Value = CON_TYPE_ID
        //    p(2) = New SqlParameter("@CON_TYPE_DESC", SqlDbType.NVarChar)
        //    p(2).Value = CON_TYPE_DESC
        //    p(3) = New SqlParameter("@CON_TITLE", SqlDbType.NVarChar)
        //    p(3).Value = CON_TITLE
        //    p(4) = New SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar)
        //    p(4).Value = CON_FIRSTNAME
        //    p(5) = New SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar)
        //    p(5).Value = CON_MNAME
        //    p(6) = New SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar)
        //    p(6).Value = CON_LNAME
        //    p(7) = New SqlParameter("@Score", SqlDbType.NVarChar)
        //    p(7).Value = Score
        //    p(8) = New SqlParameter("@Percentile", SqlDbType.NVarChar)
        //    p(8).Value = percentile
        //    p(9) = New SqlParameter("@Area_rank", SqlDbType.NVarChar)
        //    p(9).Value = Area_rank
        //    p(10) = New SqlParameter("@OverallRank", SqlDbType.NVarChar)
        //    p(10).Value = Overallrank
        //    p(11) = New SqlParameter("@score_Range_Type", SqlDbType.NVarChar)
        //    p(11).Value = Scorerange
        //    p(12) = New SqlParameter("@Handphone1", SqlDbType.NVarChar)
        //    p(12).Value = Handphone1
        //    p(13) = New SqlParameter("@Handphone2", SqlDbType.NVarChar)
        //    p(13).Value = handphone2
        //    p(14) = New SqlParameter("@Landline", SqlDbType.NVarChar)
        //    p(14).Value = landline
        //    p(15) = New SqlParameter("@emailid", SqlDbType.NVarChar)
        //    p(15).Value = emailid
        //    p(16) = New SqlParameter("@Flatno", SqlDbType.NVarChar)
        //    p(16).Value = Flatno
        //    p(17) = New SqlParameter("@buildingname", SqlDbType.NVarChar)
        //    p(17).Value = buildingname
        //    p(18) = New SqlParameter("@streetname", SqlDbType.NVarChar)
        //    p(18).Value = streetname
        //    p(19) = New SqlParameter("@Country", SqlDbType.NVarChar)
        //    p(19).Value = Countryname
        //    p(20) = New SqlParameter("@State", SqlDbType.NVarChar)
        //    p(20).Value = State
        //    p(21) = New SqlParameter("@City", SqlDbType.NVarChar)
        //    p(21).Value = City
        //    p(22) = New SqlParameter("@pincode", SqlDbType.NVarChar)
        //    p(22).Value = pincode
        //    p(23) = New SqlParameter("@Category_Type_Id", SqlDbType.NVarChar)
        //    p(23).Value = Category_Type_Id
        //    p(24) = New SqlParameter("@Category_Type", SqlDbType.NVarChar)
        //    p(24).Value = Category_Type

        //    p(25) = New SqlParameter("@Institute_Type_Id", SqlDbType.NVarChar)
        //    p(25).Value = InstituteTypeid
        //    p(26) = New SqlParameter("@institute_Type_Desc", SqlDbType.NVarChar)
        //    p(26).Value = InstituteTypeDesc
        //    p(27) = New SqlParameter("@Institution_Desc", SqlDbType.NVarChar)
        //    p(27).Value = Institute_desc
        //    p(28) = New SqlParameter("@Current_Standard_id", SqlDbType.NVarChar)
        //    p(28).Value = Current_Standardid
        //    p(29) = New SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar)
        //    p(29).Value = Current_StandardDesc
        //    p(30) = New SqlParameter("@Additional_desc", SqlDbType.NVarChar)
        //    p(30).Value = AdditionalDesc
        //    p(31) = New SqlParameter("@Board_Id", SqlDbType.NVarChar)
        //    p(31).Value = Boardid
        //    p(32) = New SqlParameter("@Board_Desc", SqlDbType.NVarChar)
        //    p(32).Value = Boarddesc
        //    p(33) = New SqlParameter("@Section_Id", SqlDbType.NVarChar)
        //    p(33).Value = Sectionid
        //    p(34) = New SqlParameter("@Section_Desc", SqlDbType.NVarChar)
        //    p(34).Value = Sectiondesc
        //    p(35) = New SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar)
        //    p(35).Value = Yearofpassingid
        //    p(36) = New SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar)
        //    p(36).Value = Yearofpassingdesc
        //    p(37) = New SqlParameter("@Current_Year_Id", SqlDbType.NVarChar)
        //    p(37).Value = CurrentYearid
        //    p(38) = New SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar)
        //    p(38).Value = CurrentYeardesc
        //    p(39) = New SqlParameter("@Studentid", SqlDbType.NVarChar)
        //    p(39).Value = Studentid
        //    p(40) = New SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar)
        //    p(40).Value = LastCourseOpted

        //    p(41) = New SqlParameter("@Opportunity_Code", SqlDbType.NVarChar)
        //    p(41).Value = Opportunity_id
        //    p(42) = New SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar)
        //    p(42).Value = Opp_TYpe_Id
        //    p(43) = New SqlParameter("@Opp_Name", SqlDbType.NVarChar)
        //    p(43).Value = Opp_Name
        //    p(44) = New SqlParameter("@Lead_Code", SqlDbType.NVarChar)
        //    p(44).Value = Leadid
        //    p(45) = New SqlParameter("@Product_Category", SqlDbType.NVarChar)
        //    p(45).Value = Product_Category
        //    p(46) = New SqlParameter("@Product_Code", SqlDbType.NVarChar)
        //    p(46).Value = Product_Code
        //    p(47) = New SqlParameter("@Sales_Stage", SqlDbType.NVarChar)
        //    p(47).Value = Sales_Stage
        //    p(48) = New SqlParameter("@Opp_Join_Date", SqlDbType.DateTime)
        //    p(48).Value = Opp_Join_Date

        //    p(49) = New SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime)
        //    p(49).Value = Opp_Expected_Close_Date
        //    p(50) = New SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar)
        //    p(50).Value = Opp_Probability_Percent
        //    p(51) = New SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar)
        //    p(51).Value = Opp_Next_Step
        //    p(52) = New SqlParameter("@Opp_Value", SqlDbType.Decimal)
        //    p(52).Value = Opp_Value
        //    p(53) = New SqlParameter("@Opp_Disc", SqlDbType.Decimal)
        //    p(53).Value = Opp_Disc

        //    p(54) = New SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar)
        //    p(54).Value = Opp_Contact_Company
        //    p(55) = New SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar)
        //    p(55).Value = Opp_Contact_Division
        //    p(56) = New SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar)
        //    p(56).Value = Opp_Contact_Center
        //    p(57) = New SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar)
        //    p(57).Value = Opp_Contact_Zone
        //    p(58) = New SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar)
        //    p(58).Value = Opp_Contact_Role
        //    p(59) = New SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar)
        //    p(59).Value = Opp_Contact_AssignTo
        //    p(60) = New SqlParameter("@Created_By", SqlDbType.NVarChar)
        //    p(60).Value = Created_By
        //    p(61) = New SqlParameter("@last_Modified_By", SqlDbType.NVarChar)
        //    p(61).Value = last_Modified_By
        //    p(62) = New SqlParameter("@Opp_Status", SqlDbType.NVarChar)
        //    p(62).Value = Opp_Status
        //    p(63) = New SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar)
        //    p(63).Value = Opp_Status_id
        //    p(64) = New SqlParameter("@Oppor_Product", SqlDbType.NVarChar)
        //    p(64).Value = Oppor_product
        //    p(65) = New SqlParameter("@Oppor_Product_Id", SqlDbType.NVarChar)
        //    p(65).Value = Oppor_Product_id
        //    p(66) = New SqlParameter("@Oppor_Id_Out", SqlDbType.NVarChar, 100)
        //    p(66).Direction = ParameterDirection.Output
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Add_Opportunity", p)
        //    Return (p(66).Value.ToString())
        //End Function

        public static string InsertAddOpportunity(string CON_ID, string CON_TYPE_ID, string CON_TYPE_DESC, string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank,
        int Overallrank, string Scorerange, string Handphone1, string handphone2, string landline, string emailid, string Flatno, string buildingname, string streetname, string Countryname,
        string State, string City, string pincode, string Category_Type_Id, string Category_Type, string InstituteTypeid, string InstituteTypeDesc, string Institute_desc, string Current_Standardid, string Current_StandardDesc,
        string AdditionalDesc, string Boardid, string Boarddesc, string Sectionid, string Sectiondesc, string Yearofpassingid, string Yearofpassingdesc, string CurrentYearid, string CurrentYeardesc, string Studentid,
        string LastCourseOpted, string Opportunity_id, string Opp_TYpe_Id, string Opp_Name, string Leadid, string Product_Category, string Product_Code, string Sales_Stage, System.DateTime Opp_Join_Date, System.DateTime Opp_Expected_Close_Date,
        string Opp_Probability_Percent, string Opp_Next_Step, decimal Opp_Value, int Opp_Disc, string Opp_Contact_Company, string Opp_Contact_Division, string Opp_Contact_Center, string Opp_Contact_Zone, string Opp_Contact_Role, string Opp_Contact_AssignTo,
        string Created_By, string last_Modified_By, string Opp_Status, string Opp_Status_id, string Opp_Contact_SDivision, string Opp_Contact_SCenter, string Opp_Contact_SZone, string Oppor_product, string Oppor_Product_id, string App_No,
        string SalesChannel_Id, string SalesChannel, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname, string Sechphone1, string Sechphone2, string Seclandline,
        string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity, string Secpincode, string SecContactDesc, int discipline_id,
        string Discipline_desc, int Field_Id, string Field_Desc, string Competitive_Exam, int Totalmsmarks, int Totalmsmarksobt, string Opp_Contact_Target_Company, string Dob, string Examination, string location,
        string Gender, string Is_Branch_Topper, string Branch_Topper_Division, string Branch_Topper_Center,
        string Is_School_Ranker, string School_Name, string School_Division, string School_Rank,
          string Apply_Additional_Discount, string Discount_Type)
        {
            SqlParameter[] p = new SqlParameter[111];
            p[0] = new SqlParameter("@CON_ID", SqlDbType.NVarChar);
            p[0].Value = CON_ID;
            p[1] = new SqlParameter("@CON_TYPE_ID", SqlDbType.NVarChar);
            p[1].Value = CON_TYPE_ID;
            p[2] = new SqlParameter("@CON_TYPE_DESC", SqlDbType.NVarChar);
            p[2].Value = CON_TYPE_DESC;
            p[3] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[3].Value = CON_TITLE;
            p[4] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[4].Value = CON_FIRSTNAME;
            p[5] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[5].Value = CON_MNAME;
            p[6] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[6].Value = CON_LNAME;
            p[7] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[7].Value = Score;
            p[8] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[8].Value = percentile;
            p[9] = new SqlParameter("@Area_rank", SqlDbType.NVarChar);
            p[9].Value = Area_rank;
            p[10] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[10].Value = Overallrank;
            p[11] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[11].Value = Scorerange;
            p[12] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[12].Value = Handphone1;
            p[13] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[13].Value = handphone2;
            p[14] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[14].Value = landline;
            p[15] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[15].Value = emailid;
            p[16] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[16].Value = Flatno;
            p[17] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[17].Value = buildingname;
            p[18] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[18].Value = streetname;
            p[19] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[19].Value = Countryname;
            p[20] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[20].Value = State;
            p[21] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[21].Value = City;
            p[22] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[22].Value = pincode;
            p[23] = new SqlParameter("@Category_Type_Id", SqlDbType.NVarChar);
            p[23].Value = Category_Type_Id;
            p[24] = new SqlParameter("@Category_Type", SqlDbType.NVarChar);
            p[24].Value = Category_Type;

            p[25] = new SqlParameter("@Institute_Type_Id", SqlDbType.NVarChar);
            p[25].Value = InstituteTypeid;
            p[26] = new SqlParameter("@institute_Type_Desc", SqlDbType.NVarChar);
            p[26].Value = InstituteTypeDesc;
            p[27] = new SqlParameter("@Institution_Desc", SqlDbType.NVarChar);
            p[27].Value = Institute_desc;
            p[28] = new SqlParameter("@Current_Standard_id", SqlDbType.NVarChar);
            p[28].Value = Current_Standardid;
            p[29] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[29].Value = Current_StandardDesc;
            p[30] = new SqlParameter("@Additional_desc", SqlDbType.NVarChar);
            p[30].Value = AdditionalDesc;
            p[31] = new SqlParameter("@Board_Id", SqlDbType.NVarChar);
            p[31].Value = Boardid;
            p[32] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[32].Value = Boarddesc;
            p[33] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[33].Value = Sectionid;
            p[34] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[34].Value = Sectiondesc;
            p[35] = new SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar);
            p[35].Value = Yearofpassingid;
            p[36] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[36].Value = Yearofpassingdesc;
            p[37] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[37].Value = CurrentYearid;
            p[38] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[38].Value = CurrentYeardesc;
            p[39] = new SqlParameter("@Studentid", SqlDbType.NVarChar);
            p[39].Value = Studentid;
            p[40] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[40].Value = LastCourseOpted;

            p[41] = new SqlParameter("@Oppur_Id", SqlDbType.NVarChar);
            p[41].Value = Opportunity_id;
            p[42] = new SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar);
            p[42].Value = Opp_TYpe_Id;
            p[43] = new SqlParameter("@Opp_Name", SqlDbType.NVarChar);
            p[43].Value = Opp_Name;
            p[44] = new SqlParameter("@Lead_id", SqlDbType.NVarChar);
            p[44].Value = Leadid;
            p[45] = new SqlParameter("@Product_Category", SqlDbType.NVarChar);
            p[45].Value = Product_Category;
            p[46] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
            p[46].Value = Product_Code;
            p[47] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[47].Value = Sales_Stage;
            p[48] = new SqlParameter("@Opp_Join_Date", SqlDbType.DateTime);
            p[48].Value = Opp_Join_Date;

            p[49] = new SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime);
            p[49].Value = Opp_Expected_Close_Date;
            p[50] = new SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar);
            p[50].Value = Opp_Probability_Percent;
            p[51] = new SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar);
            p[51].Value = Opp_Next_Step;
            p[52] = new SqlParameter("@Opp_Value", SqlDbType.Decimal);
            p[52].Value = Opp_Value;
            p[53] = new SqlParameter("@Opp_Disc", SqlDbType.Int);
            p[53].Value = Opp_Disc;

            p[54] = new SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar);
            p[54].Value = Opp_Contact_Company;
            p[55] = new SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar);
            p[55].Value = Opp_Contact_Division;
            p[56] = new SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar);
            p[56].Value = Opp_Contact_Center;
            p[57] = new SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar);
            p[57].Value = Opp_Contact_Zone;
            p[58] = new SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar);
            p[58].Value = Opp_Contact_Role;
            p[59] = new SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar);
            p[59].Value = Opp_Contact_AssignTo;
            p[60] = new SqlParameter("@Created_By", SqlDbType.NVarChar);
            p[60].Value = Created_By;
            p[61] = new SqlParameter("@last_Modified_By", SqlDbType.NVarChar);
            p[61].Value = last_Modified_By;
            p[62] = new SqlParameter("@Opp_Status", SqlDbType.NVarChar);
            p[62].Value = Opp_Status;
            p[63] = new SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar);
            p[63].Value = Opp_Status_id;
            p[64] = new SqlParameter("@Oppor_Product", SqlDbType.NVarChar);
            p[64].Value = Oppor_product;

            p[65] = new SqlParameter("@Opp_ContactSource_Division", SqlDbType.NVarChar);
            p[65].Value = Opp_Contact_SDivision;
            p[66] = new SqlParameter("@Opp_ContactSource_Center", SqlDbType.NVarChar);
            p[66].Value = Opp_Contact_SCenter;
            p[67] = new SqlParameter("@Opp_ContactSource_Zone", SqlDbType.NVarChar);
            p[67].Value = Opp_Contact_SZone;

            p[68] = new SqlParameter("@Oppor_Product_Id", SqlDbType.NVarChar, 100);
            p[68].Value = Oppor_Product_id;
            p[69] = new SqlParameter("@Oppor_Id_Out", SqlDbType.NVarChar, 100);
            p[69].Direction = ParameterDirection.Output;
            p[70] = new SqlParameter("@appno", SqlDbType.NVarChar);
            p[70].Value = App_No;
            p[71] = new SqlParameter("@SalesStage_Id", SqlDbType.NVarChar);
            p[71].Value = SalesChannel_Id;
            p[72] = new SqlParameter("@SalesStage_Desc", SqlDbType.NVarChar);
            p[72].Value = SalesChannel;

            p[73] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[73].Value = SecContactType;
            p[74] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[74].Value = SecTitle;
            p[75] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[75].Value = Secfname;
            p[76] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[76].Value = SecMname;
            p[77] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[77].Value = SecLname;
            p[78] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[78].Value = Sechphone1;
            p[79] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[79].Value = Sechphone2;
            p[80] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[80].Value = Seclandline;
            p[81] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[81].Value = Secemail;
            p[82] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[82].Value = SecAdd1;
            p[83] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[83].Value = Secadd2;
            p[84] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[84].Value = SecStreetname;
            p[85] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[85].Value = SecCountryname;
            p[86] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[86].Value = SecState;
            p[87] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[87].Value = SecCity;
            p[88] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[88].Value = Secpincode;
            p[89] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[89].Value = SecContactDesc;
            p[90] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[90].Value = discipline_id;
            p[91] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[91].Value = Discipline_desc;
            p[92] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[92].Value = Field_Id;
            p[93] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[93].Value = Field_Desc;
            p[94] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[94].Value = Competitive_Exam;
            p[95] = new SqlParameter("@Total_ms_Marks", SqlDbType.Int);
            p[95].Value = Totalmsmarks;
            p[96] = new SqlParameter("@Total_ms_Marks_obt", SqlDbType.Int);
            p[96].Value = Totalmsmarksobt;
            p[97] = new SqlParameter("@Opp_Contact_Target_Company", SqlDbType.VarChar);
            p[97].Value = Opp_Contact_Target_Company;

            p[98] = new SqlParameter("@dob", SqlDbType.VarChar);
            p[98].Value = Dob;
            p[99] = new SqlParameter("@last_exam", SqlDbType.VarChar);
            p[99].Value = Examination;
            p[100] = new SqlParameter("@location", SqlDbType.VarChar);
            p[100].Value = location;
            p[101] = new SqlParameter("@gender", SqlDbType.VarChar);
            p[101].Value = Gender;
            p[102] = new SqlParameter("@Is_Branch_Topper", SqlDbType.VarChar);
            p[102].Value = Is_Branch_Topper;
            p[103] = new SqlParameter("@Branch_Topper_Division", SqlDbType.VarChar);
            p[103].Value = Branch_Topper_Division;
            p[104] = new SqlParameter("@Branch_Topper_Center", SqlDbType.VarChar);
            p[104].Value = Branch_Topper_Center;
            p[105] = new SqlParameter("@Is_School_Ranker", SqlDbType.VarChar);
            p[105].Value = Is_School_Ranker;
            p[106] = new SqlParameter("@School_Name", SqlDbType.VarChar);
            p[106].Value = School_Name;
            p[107] = new SqlParameter("@School_Division", SqlDbType.VarChar);
            p[107].Value = School_Division;

            p[108] = new SqlParameter("@School_Rank", SqlDbType.VarChar);
            p[108].Value = School_Rank;
            p[109] = new SqlParameter("@Apply_Additional_Discount", SqlDbType.VarChar);
            p[109].Value = Apply_Additional_Discount;
            p[110] = new SqlParameter("@Discount_Type", SqlDbType.VarChar);
            p[110].Value = Discount_Type;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Add_Opportunity", p);
            return (p[69].Value.ToString());
        }

        public static string InsertAccount(string Accountid, string Opporid, string Sbentrycode, System.DateTime Account_ConvertDate, string Notes, string Createdby, string Modifiedby)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@Accountid", SqlDbType.NVarChar);
            p[0].Value = Accountid;
            p[1] = new SqlParameter("@Oppor_id", SqlDbType.NVarChar);
            p[1].Value = Opporid;
            p[2] = new SqlParameter("@Sbentrycode", SqlDbType.NVarChar);
            p[2].Value = Sbentrycode;
            p[3] = new SqlParameter("@Account_Convert_Date", SqlDbType.DateTime);
            p[3].Value = Account_ConvertDate;
            p[4] = new SqlParameter("@Notes", SqlDbType.NVarChar);
            p[4].Value = Notes;
            p[5] = new SqlParameter("@Createdby", SqlDbType.NVarChar);
            p[5].Value = Createdby;
            p[6] = new SqlParameter("@modifiedby", SqlDbType.NVarChar);
            p[6].Value = Modifiedby;
            p[7] = new SqlParameter("@Account_Id_Out", SqlDbType.NVarChar, 100);
            p[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertAccount", p);
            return (p[7].Value.ToString());
        }

        public static string InsertFeesAdjustment(string Sbentrycode, string Vouchertype, string VoucherDate,
            float Amount, string Pricing_Procedure_Code, string Material_Code, string User_Code)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@SBEntryCode", SqlDbType.VarChar);
            p[0].Value = Sbentrycode;
            p[1] = new SqlParameter("@VoucherType", SqlDbType.VarChar);
            p[1].Value = Vouchertype;
            p[2] = new SqlParameter("@VoucherDate", SqlDbType.VarChar);
            p[2].Value = VoucherDate;
            p[3] = new SqlParameter("@Amount", SqlDbType.Float);
            p[3].Value = Amount;
            p[4] = new SqlParameter("@Pricing_Procedure_Code", SqlDbType.VarChar);
            p[4].Value = Pricing_Procedure_Code;
            p[5] = new SqlParameter("@Material_Code", SqlDbType.VarChar);
            p[5].Value = Material_Code;
            p[6] = new SqlParameter("@User_Code", SqlDbType.VarChar);
            p[6].Value = User_Code;
            p[7] = new SqlParameter("@Account_OUT_ID", SqlDbType.VarChar, 100);
            p[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Student_Voucher", p);
            return (p[7].Value.ToString());
        }

        public static string GetVoucherValuebySbentrycode(int flag, string Sbentrycode, string Vouchertype)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@flag", SqlDbType.Int);
            p[0].Value = flag;
            p[1] = new SqlParameter("@SBEntryCode", SqlDbType.VarChar);
            p[1].Value = Sbentrycode;
            p[2] = new SqlParameter("@VoucherType", SqlDbType.VarChar);
            p[2].Value = Vouchertype;
            p[3] = new SqlParameter("@Account_OUT_ID", SqlDbType.VarChar, 100);
            p[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_CRF_ValuebySBENtrycode", p);
            return (p[3].Value.ToString());
        }


        public static string GetOppidbyContactid(int flag, string Conid)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@flag", SqlDbType.Int);
            p[0].Value = flag;
            p[1] = new SqlParameter("@Conid", SqlDbType.VarChar);
            p[1].Value = Conid;
            p[2] = new SqlParameter("@Opportunityid", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Usp_Get_OpportunityidbyContactid]", p);
            return (p[2].Value.ToString());
        }

        //public static string InsertDifferentialCRF(string Sbentrycode, string Vouchertype, string VoucherDate,
        //    float Amount, string Pricing_Procedure_Code, string Material_Code, string User_Code)
        //{
        //    SqlParameter[] p = new SqlParameter[8];
        //    p[0] = new SqlParameter("@SBEntryCode", SqlDbType.VarChar);
        //    p[0].Value = Sbentrycode;
        //    p[1] = new SqlParameter("@VoucherType", SqlDbType.VarChar);
        //    p[1].Value = Vouchertype;
        //    p[2] = new SqlParameter("@VoucherDate", SqlDbType.VarChar);
        //    p[2].Value = VoucherDate;
        //    p[3] = new SqlParameter("@Amount", SqlDbType.Float);
        //    p[3].Value = Amount;
        //    p[4] = new SqlParameter("@Pricing_Procedure_Code", SqlDbType.VarChar);
        //    p[4].Value = Pricing_Procedure_Code;
        //    p[5] = new SqlParameter("@Material_Code", SqlDbType.VarChar);
        //    p[5].Value = Material_Code;
        //    p[6] = new SqlParameter("@User_Code", SqlDbType.VarChar);
        //    p[6].Value = User_Code;
        //    p[7] = new SqlParameter("@Account_OUT_ID", SqlDbType.VarChar, 100);
        //    p[7].Direction = ParameterDirection.Output;

        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Student_Voucher", p);
        //    return (p[7].Value.ToString());
        //}

        //Enrollment Check 
        public static string CheckStudentInfobyOppid(string Oppid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Oppid", SqlDbType.NVarChar);
            p[0].Value = Oppid;
            p[1] = new SqlParameter("@Val", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETVALUE_BYOPPID", p);
            return (p[1].Value.ToString());
        }
        public static DataSet UpdateImagePath(string SBEntrycode, string fileext)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBEntrycode);
            SqlParameter p2 = new SqlParameter("@fileext", fileext);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdateImagePath", p1, p2));

        }


        //For Batch Creation
        #region "Batch Creation"

        //public static DataSet GetAllActive_Standard_ForYear(string Division_Code, string YearName)
        //{
        //    SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
        //    SqlParameter p2 = new SqlParameter("@YearName", YearName);
        //    SqlParameter p3 = new SqlParameter("@Flag", 1);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetStandard", p1, p2, p3));
        //}

        public static DataSet GetAllActive_Standard_ForYear(string Division_Code, string YearName)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Flag", 1);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetStandard_New", p1, p2, p3));
        }

        public static DataSet GetAllActiveUser_AcadYear()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallCurrentYear"));
        }

        public static DataSet GetBatchBy_Division_Year_Standard_Centre(string Division_Code, string YearName, string StandardCode, string CentreCode, string BatchName)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@Centre_Code", CentreCode);
            SqlParameter p5 = new SqlParameter("@BatchName", BatchName);
            SqlParameter p6 = new SqlParameter("@Flag", 1);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatchBy_Division_Year_Standard_Centre", p1, p2, p3, p4, p5, p6));
        }

        public static DataSet GetBatchBy_Division_Year_Standard_Centre_Cross_Batch(string Division_Code, string YearName, string StandardCode, string CentreCode, string BatchName)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@Centre_Code", CentreCode);
            SqlParameter p5 = new SqlParameter("@BatchName", BatchName);
            SqlParameter p6 = new SqlParameter("@Flag", 1);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatchBy_Division_Year_Standard_Centre_Cross_Batch", p1, p2, p3, p4, p5, p6));
        }

        public static DataSet GetallSubjectGroupbyStreamCode(string streamcode)
        {
            SqlParameter p1 = new SqlParameter("@Stream_Code", streamcode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetSubjectGroup_StreamCode", p1));
        }

        public static DataSet GetallInstitutename()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllInstitution"));
        }

        public static DataSet GetBatchBY_PKey(string PKey)
        {
            //Try
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@DBSource", "CDB");
            SqlParameter p3 = new SqlParameter("@Flag", 1);
            DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatch_ByPKey", p1, p2, p3);
            return (XYZ);
        }

        public static DataSet GetBatchStudentDetailBY_PKey(string PKey, int Flag)
        {
            //Try
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatchStudentDetail_ByPKey", p1, p2);
            return (XYZ);
        }

        public static DataSet GetBatchBY_PKey_Cross_Batch(string PKey)
        {
            //Try
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@DBSource", "CDB");
            SqlParameter p3 = new SqlParameter("@Flag", 1);
            DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatch_ByPKey_Cross_Batch", p1, p2, p3);
            return (XYZ);
        }

        public static DataSet GetBatchBY_PKey_SubjectGrp(string PKey, string subjectgrpup, string institute, string StreamCode)
        {
            //Try
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@DBSource", "CDB");
            SqlParameter p3 = new SqlParameter("@Flag", 1);
            SqlParameter p4 = new SqlParameter("@SubjectGroup", subjectgrpup);
            SqlParameter p5 = new SqlParameter("@InstituteName", institute);
            SqlParameter p6 = new SqlParameter("@StreamCode", StreamCode);
            DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatch_ByPKey_Subjectgroup", p1, p2, p3, p4, p5, p6);
            return (XYZ);
        }

        public static DataSet GetAllClassroomProduct_ByPKEY(string PKey)
        {
            //Try
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@DBSource", "CDB");
            SqlParameter p3 = new SqlParameter("@Flag", 1);
            DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatch_ByPKey_Classroom", p1, p2, p3);
            return (XYZ);
        }

        public static DataSet GetAllActiveUser_Company_Division_Zone_Center(string User_ID, string Company_Code, string Division_Code, string Zone_Code, string Flag, string DBName)
        {
            SqlParameter p1 = new SqlParameter("@user_id", User_ID);
            SqlParameter p2 = new SqlParameter("@company_code", Company_Code);
            SqlParameter p3 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p4 = new SqlParameter("@Zone_Code", Zone_Code);
            SqlParameter p5 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center", p1, p2, p3, p4, p5));

        }

        //public static DataSet GetAllActive_AllStandard(string Division_Code)
        //{
        //    SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStandard", p1));
        //}

        public static DataSet GetAllActive_AllStandard(string Division_Code)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStandard_New", p1));
        }

        public static string Raise_Error(string Error_Code)
        {
            string Error_Desc = null;

            switch (Error_Code)
            {
                case "0000":
                    Error_Desc = "Record saved successfully";
                    break;
                case "0001":
                    Error_Desc = "Select Division";
                    break;
                case "0002":
                    Error_Desc = "Select Academic Year";
                    break;
                case "0003":
                    Error_Desc = "Select Standard";
                    break;
                case "0004":
                    Error_Desc = "Select Product";
                    break;
                case "0005":
                    Error_Desc = "Select Subject";
                    break;
                case "0006":
                    Error_Desc = "Select Centre";
                    break;
                case "0007":
                    Error_Desc = "Select Student(s)";
                    break;
                case "0008":
                    Error_Desc = "Number of Students selected is more than Maximum Batch Strength";
                    break;
                case "0009":
                    Error_Desc = "Enter New Batch Count";
                    break;
                case "0010":
                    Error_Desc = "Select Chapter(s)";
                    break;
                case "0011":
                    Error_Desc = "Select Test Mode";
                    break;
                case "0012":
                    Error_Desc = "Select Test Category";
                    break;
                case "0013":
                    Error_Desc = "Select Test Type";
                    break;
                case "0014":
                    Error_Desc = "Select Test Duration";
                    break;
                case "0015":
                    Error_Desc = "Select Batch";
                    break;
                case "0016":
                    Error_Desc = "Select Test Name";
                    break;
                case "0017":
                    Error_Desc = "Enter Maximum Marks";
                    break;
                case "0018":
                    Error_Desc = "Invalid Start Time";
                    break;
                case "0019":
                    Error_Desc = "Invalid End Time";
                    break;
                case "0020":
                    Error_Desc = "Start Time can't be after End Time";
                    break;
                case "0021":
                    Error_Desc = "Select Entity Type";
                    break;
                case "0022":
                    Error_Desc = "Select CSV File that you want to upload using Browse button";
                    break;
                case "0023":
                    Error_Desc = "File with the same name already processed for this test";
                    break;
                case "0024":
                    Error_Desc = "Invalid file format";
                    break;
                case "0025":
                    Error_Desc = "Enter Name of the column where Student ID is stored";
                    break;
                case "0026":
                    Error_Desc = "Invalid ID Column name";
                    break;
                case "0027":
                    Error_Desc = "No records found for importing";
                    break;
                case "0028":
                    Error_Desc = "Select Conduct Number";
                    break;
                case "0029":
                    Error_Desc = "Duplicate Test Name";
                    break;
                case "0030":
                    Error_Desc = "Select Student";
                    break;
                case "0031":
                    Error_Desc = "Attendance Authorisation can't be done as attendance of few Students is not marked";
                    break;
                case "0032":
                    Error_Desc = "Attendance Authorisation done successfully";
                    break;
                case "0033":
                    Error_Desc = "Attendance Authorisation removed successfully";
                    break;
                case "0034":
                    Error_Desc = "Marks Authorisation done successfully";
                    break;
                case "0035":
                    Error_Desc = "Marks Authorisation removed successfully";
                    break;
                case "0036":
                    Error_Desc = "Marks Authorisation can't be done as marks of few students are not entered";
                    break;
                case "0037":
                    Error_Desc = "File not found";
                    break;
                case "0038":
                    Error_Desc = "Test names matching with search options not found";
                    break;
                case "0039":
                    Error_Desc = "Student Answers reprocessed successfully";
                    break;
                case "0040":
                    Error_Desc = "Select Country";
                    break;
                case "0041":
                    Error_Desc = "Select State";
                    break;
                case "0042":
                    Error_Desc = "Select City";
                    break;
                case "0043":
                    Error_Desc = "Select Company";
                    break;
                case "0044":
                    Error_Desc = "Select Location";
                    break;
                case "0045":
                    Error_Desc = "Select Classroom Type";
                    break;
                case "0046":
                    Error_Desc = "Enter Classroom Length (in feet)";
                    break;
                case "0047":
                    Error_Desc = "Enter Classroom Width (in feet)";
                    break;
                case "0048":
                    Error_Desc = "Enter Classroom Height (in feet)";
                    break;
                case "0049":
                    Error_Desc = "Duplicate Classroom name";
                    break;
                case "0050":
                    Error_Desc = "Select Primary Owner Centre for the Classroom";
                    break;
                case "0051":
                    Error_Desc = "Select only 1 Centre as Primary Owner Centre for the Classroom";
                    break;
                case "0052":
                    Error_Desc = "Select Unit of Measurement for Classroom Capacity";
                    break;
                case "0053":
                    Error_Desc = "Select Title";
                    break;
                case "0054":
                    Error_Desc = "Enter First Name";
                    break;
                case "0055":
                    Error_Desc = "Enter Hand Phone number (1)";
                    break;
                case "0056":
                    Error_Desc = "Select Gender";
                    break;
                case "0057":
                    Error_Desc = "Select Activity";
                    break;
                case "0058":
                    Error_Desc = "Duplicate Partner details";
                    break;
                case "0059":
                    Error_Desc = "Invalid Hand Phone number (1)";
                    break;
                case "0060":
                    Error_Desc = "Invalid Hand Phone number (2)";
                    break;
                case "0061":
                    Error_Desc = "Enter Size of Premises in Sq. Feet";
                    break;
                case "0062":
                    Error_Desc = "Duplicate Premises name";
                    break;
                case "0063":
                    Error_Desc = "Select Premises Type";
                    break;
                case "0064":
                    Error_Desc = "Test Removal Request Approved successfully.";
                    break;
                case "0065":
                    Error_Desc = "Test Removal Request Rejected successfully";
                    break;
                case "0066":
                    Error_Desc = "Select Action";
                    break;
                case "0067":
                    Error_Desc = "Record deleted successfully";
                    break;
                case "0068":
                    Error_Desc = "Select Issuer Type";
                    break;
                case "0069":
                    Error_Desc = "Select Receiver Type";
                    break;
                case "0070":
                    Error_Desc = "Select Date Range";
                    break;
                default:
                    Error_Desc = Error_Code;
                    break;
            }
            return Error_Desc;
        }

        //public static DataSet GetAllActiveSubjectsBy_Stream_AAG(string Stream_Code, string AAG, int Flag)
        //{
        //    SqlParameter p1 = new SqlParameter("@stream_code", Stream_Code);
        //    SqlParameter p2 = new SqlParameter("@AAG", AAG);
        //    SqlParameter p3 = new SqlParameter("@Flag", Flag);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSubjectsBy_Stream_AAG", p1, p2, p3));
        //}

        public static DataSet GetAllActiveSubjectsBy_Stream_AAG(string Stream_Code, string AAG, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@stream_code", Stream_Code);
            SqlParameter p2 = new SqlParameter("@AAG", AAG);
            SqlParameter p3 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSubjectsBy_Stream_AAG_New", p1, p2, p3));
        }

        public static DataSet GetAllActiveLMSProductBy_Stream(string Stream_Code, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@stream_code", Stream_Code);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_GetAllLMSProductBy_Stream]", p1, p2));
        }

        public static DataSet GetAllActiveLMSProductBy_Stream_Cross_Division(string Stream_Code, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@stream_code", Stream_Code);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllLMSProductBy_Stream__Cross_Division", p1, p2));
        }

        public static int Insert_Batches(string DivisionCode, string YearName, string StandardCode, string ProductCode, string SubjectCode, string CentreCode, int MaxBatchStrength, string CreatedBy, string LMS_ProductCode)
        {
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@DivisionCode", DivisionCode);
            p[1] = new SqlParameter("@YearName", YearName);
            p[2] = new SqlParameter("@StandardCode", StandardCode);
            p[3] = new SqlParameter("@ProductCode", ProductCode);
            p[4] = new SqlParameter("@SubjectCode", SubjectCode);
            p[5] = new SqlParameter("@CentreCode", CentreCode);
            p[6] = new SqlParameter("@MaxBatchStrength", MaxBatchStrength);
            p[7] = new SqlParameter("@CreatedBy", CreatedBy);
            p[8] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[9] = new SqlParameter("@LMS_ProductCode", LMS_ProductCode);
            p[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertBatch", p);
            return (int.Parse(p[8].Value.ToString()));
        }

        public static int Insert_Batches_Cross_Division(string DivisionCode, string YearName, string StandardCode, string ProductCode, string SubjectCode, string CentreCode, int MaxBatchStrength, string CreatedBy, string LMS_ProductCode, string Dest_Center_Code)
        {
            SqlParameter[] p = new SqlParameter[11];
            p[0] = new SqlParameter("@DivisionCode", DivisionCode);
            p[1] = new SqlParameter("@YearName", YearName);
            p[2] = new SqlParameter("@StandardCode", StandardCode);
            p[3] = new SqlParameter("@ProductCode", ProductCode);
            p[4] = new SqlParameter("@SubjectCode", SubjectCode);
            p[5] = new SqlParameter("@CentreCode", CentreCode);
            p[6] = new SqlParameter("@MaxBatchStrength", MaxBatchStrength);
            p[7] = new SqlParameter("@CreatedBy", CreatedBy);
            p[8] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[9] = new SqlParameter("@LMS_ProductCode", LMS_ProductCode);
            p[10] = new SqlParameter("@Dest_Center_Code", Dest_Center_Code);
            p[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertBatch_Cross_Division", p);
            return (int.Parse(p[8].Value.ToString()));
        }

        public static int Insert_Batches_LikeExistingBatch(string PKey, string CentreCode, int NewBatchCount, string CreatedBy, string LMS_ProductCode)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@CentreCode", CentreCode);
            p[2] = new SqlParameter("@NewBatchCount", NewBatchCount);
            p[3] = new SqlParameter("@CreatedBy", CreatedBy);
            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[5] = new SqlParameter("@LMS_ProductCode", LMS_ProductCode);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertBatch_LikeExistingBatch", p);
            return (int.Parse(p[4].Value.ToString()));
        }

        public static int Update_Batch(string PKey, string ProductCode, string SubjectCode, int MaxBatchStrength, string BatchShortName, int IsActiveFlag, string AlteredBy)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@ProductCode", ProductCode);
            p[2] = new SqlParameter("@SubjectCode", SubjectCode);
            p[3] = new SqlParameter("@MaxBatchStrength", MaxBatchStrength);
            p[4] = new SqlParameter("@BatchShortName", BatchShortName);
            p[5] = new SqlParameter("@IsActiveFlag", IsActiveFlag);
            p[6] = new SqlParameter("@AlteredBy", AlteredBy);
            p[7] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[7].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdateBatch", p);
            return (int.Parse(p[7].Value.ToString()));
        }

        public static int Insert_Batch_Students(string PKey, string SBEntryCode, int ActionFlag, string CreatedBy)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@SBEntryCode", SBEntryCode);
            p[2] = new SqlParameter("@CreatedBy", CreatedBy);
            p[3] = new SqlParameter("@ActionFlag", ActionFlag);
            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertBatch_Student", p);
            return (int.Parse(p[4].Value.ToString()));
        }

        public static int Update_Batch_ShortName(string PKey, string BatchShortName, string CreatedBy)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@BatchShortName", BatchShortName);
            p[2] = new SqlParameter("@CreatedBy", CreatedBy);
            p[3] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Batch_ShortName", p);
            return (int.Parse(p[3].Value.ToString()));
        }

        public static int Update_Batch_Student_RollNo(string PKey, string SBEntryCode, string NewRollNo, string CreatedBy)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@SBEntryCode", SBEntryCode);
            p[2] = new SqlParameter("@CreatedBy", CreatedBy);
            p[3] = new SqlParameter("@NewRollNo", NewRollNo);
            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Batch_Student_RollNo", p);
            return (int.Parse(p[4].Value.ToString()));
        }
        public static int Update_Test(string TestCode, string DivisionCode, string YearName, string StandardCode, string TestModeCode, string TestCategoryCode, string TestTypeCode, string SubjectCode, string CentreCode, string ChapterCode,
        double MaxMarks, int TestDuration, int QPSetCount, int QuestionCount, string TestName, string TestDescription, string Remarks, int NegativeMarkingFlag, string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[20];
            p[0] = new SqlParameter("@DivisionCode", DivisionCode);
            p[1] = new SqlParameter("@YearName", YearName);
            p[2] = new SqlParameter("@StandardCode", StandardCode);
            p[3] = new SqlParameter("@TestModeCode", TestModeCode);
            p[4] = new SqlParameter("@TestCategoryCode", TestCategoryCode);
            p[5] = new SqlParameter("@TestTypeCode", TestTypeCode);
            p[6] = new SqlParameter("@TestName", TestName);
            p[7] = new SqlParameter("@TestDescription", TestDescription);
            p[8] = new SqlParameter("@Remarks", Remarks);
            p[9] = new SqlParameter("@SubjectCode", SubjectCode);
            p[10] = new SqlParameter("@CentreCode", CentreCode);
            p[11] = new SqlParameter("@ChapterCode", ChapterCode);
            p[12] = new SqlParameter("@QPSetCnt", QPSetCount);
            p[13] = new SqlParameter("@MaxMarks", MaxMarks);
            p[14] = new SqlParameter("@TestDuration", TestDuration);
            p[15] = new SqlParameter("@CreatedBy", CreatedBy);
            p[16] = new SqlParameter("@QuestionCount", QuestionCount);
            //
            p[17] = new SqlParameter("@NegativeMarkingFlag", NegativeMarkingFlag);
            p[18] = new SqlParameter("@TestCode", TestCode);
            p[19] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[19].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdateTest", p);
            return (int.Parse(p[19].Value.ToString()));
        }


        /////////
        public static DataSet GetAllActiveStreamsBy_Division_Year(string Division_Code, string Acad_Year, string AAG, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acad_Year", Acad_Year);
            SqlParameter p3 = new SqlParameter("@AAG", AAG);
            SqlParameter p4 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStreamsBy_Division_Year_AAG", p1, p2, p3, p4));
        }

        public static DataSet GetAllActiveStreamsBy_Division_Year_Cross_Division(string Division_Code, string Acad_Year, string AAG, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acad_Year", Acad_Year);
            SqlParameter p3 = new SqlParameter("@AAG", AAG);
            SqlParameter p4 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStreamsBy_Division_Year_AAG_Cross_Division", p1, p2, p3, p4));
        }

        ///New One
        //public static DataSet GetAllActiveStreamsBy_Division_Year(string Division_Code, string Acad_Year, string AAG, string Flag, string CenterCode)
        //{
        //    SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
        //    SqlParameter p2 = new SqlParameter("@Acad_Year", Acad_Year);
        //    SqlParameter p3 = new SqlParameter("@AAG", AAG);
        //    SqlParameter p4 = new SqlParameter("@Flag", Flag);
        //    SqlParameter p5 = new SqlParameter("@CenterCode", CenterCode);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStreamsBy_Division_Year_AAG", p1, p2, p3, p4, p5));
        //}

        //public static DataSet Getallsubjectgroupbystreams(string flag, string stream)
        //{
        //    SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
        //    SqlParameter p2 = new SqlParameter("@Acad_Year", Acad_Year);
        //    SqlParameter p3 = new SqlParameter("@AAG", AAG);
        //    SqlParameter p4 = new SqlParameter("@Flag", Flag);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStreamsBy_Division_Year_AAG", p1, p2, p3, p4));
        //}





        #endregion

        #region "Classroom Creation"
        public static DataSet GetPremisesMasterBy_Country_State_City(string Country_Code, string State_Code, string City_Code, string Location_Code, string PremisesName, string PremisesType_Id, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Country_Code", Country_Code);
            SqlParameter p2 = new SqlParameter("@State_Code", State_Code);
            SqlParameter p3 = new SqlParameter("@City_Code", City_Code);
            SqlParameter p4 = new SqlParameter("@Location_Code", Location_Code);
            SqlParameter p5 = new SqlParameter("@PremisesName", PremisesName);
            SqlParameter p6 = new SqlParameter("@PremisesType_Id", PremisesType_Id);
            SqlParameter p7 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetPremisesMasterBy_Country_State_City", p1, p2, p3, p4, p5, p6, p7));
        }
        public static DataSet GetPremisesMaster_ByPKey(string PKey, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetPremisesMaster_ByPKey", p1, p2));
        }
        public static DataSet GetClassroomMaster_ByPKey(string PKey, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetClassroomMaster_ByPKey", p1, p2));
        }
        public static DataSet GetAllActivePremisesType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActivePremisesType"));
        }
        public static DataSet GetAllActiveClassroomType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveClassroomType"));
        }
        //public static DataSet GetAllActiveUser_Company_Division_Zone_Center(string User_ID, string Company_Code, string Division_Code, string Zone_Code, string Flag, string DBName)
        //{
        //    SqlParameter p1 = new SqlParameter("@user_id", User_ID);
        //    SqlParameter p2 = new SqlParameter("@company_code", Company_Code);
        //    SqlParameter p3 = new SqlParameter("@division_code", Division_Code);
        //    SqlParameter p4 = new SqlParameter("@Zone_Code", Zone_Code);
        //    SqlParameter p5 = new SqlParameter("@Flag", Flag);

        //    if (DBName == "MTEducare")
        //    {
        //        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center_MTEducare", p1, p2, p3, p4, p5));
        //    }
        //    else
        //    {
        //        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center", p1, p2, p3, p4, p5));
        //    }

        //}
        public static DataSet GetAllActiveState(string Country_Code)
        {
            SqlParameter p1 = new SqlParameter("@Countrycode", Country_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStatebyCountry", p1));
        }
        public static DataSet GetAllActiveCity(string State_Code)
        {
            SqlParameter p1 = new SqlParameter("@Statecode", State_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCitybyState", p1));
        }
        public static DataSet GetAllActiveLocation(string City_Code)
        {
            SqlParameter p1 = new SqlParameter("@CityCode", City_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllLocationByCity", p1));
        }
        public static string Insert_Premises(string CompanyCode, string Country_Code, string State_Code, string City_Code, string Location_Code, string Premises_LName, string Premises_SName, double Area_inSQFeet, string PremisesType_Id, int IsActive,
        string Premises_Address, string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[13];
            p[0] = new SqlParameter("@CompanyCode", CompanyCode);
            p[1] = new SqlParameter("@Country_Code", Country_Code);
            p[2] = new SqlParameter("@State_Code", State_Code);
            p[3] = new SqlParameter("@City_Code", City_Code);
            p[4] = new SqlParameter("@Location_Code", Location_Code);
            p[5] = new SqlParameter("@Premises_LName", Premises_LName);
            p[6] = new SqlParameter("@Premises_SName", Premises_SName);
            p[7] = new SqlParameter("@Area_inSQFeet", Area_inSQFeet);
            p[8] = new SqlParameter("@PremisesType_Id", PremisesType_Id);
            p[9] = new SqlParameter("@IsActive", IsActive);
            p[10] = new SqlParameter("@CreatedBy", CreatedBy);
            p[11] = new SqlParameter("@Premises_Address", Premises_Address);
            p[12] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[12].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertPremises", p);
            return (p[12].Value.ToString());
        }
        public static string Update_Premises(string Premises_Code, string Location_Code, string Premises_LName, string Premises_SName, double Area_inSQFeet, string PremisesType_Id, int IsActive, string Premises_Address, string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@Premises_Code", Premises_Code);
            p[1] = new SqlParameter("@Location_Code", Location_Code);
            p[2] = new SqlParameter("@Premises_LName", Premises_LName);
            p[3] = new SqlParameter("@Premises_SName", Premises_SName);
            p[4] = new SqlParameter("@Area_inSQFeet", Area_inSQFeet);
            p[5] = new SqlParameter("@PremisesType_Id", PremisesType_Id);
            p[6] = new SqlParameter("@IsActive", IsActive);
            p[7] = new SqlParameter("@CreatedBy", CreatedBy);
            p[8] = new SqlParameter("@Premises_Address", Premises_Address);
            p[9] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[9].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdatePremises", p);
            return (p[9].Value.ToString());
        }
        public static DataSet GetAllActiveActivity(string ClassroomType_Id, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@ClassroomType_Id", ClassroomType_Id);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllActiveActivityType", p1, p2));
        }
        public static DataSet GetAllActiveUnitOfMeasurement()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveUnitOfMeasurement"));
        }
        public static string Insert_Classroom(string Classroom_LName, string Classroom_SName, double Length_inFeet, double Width_inFeet, double Height_inFeet, double Area_inSQFeet, string ClassroomType_Id, int IsActive, string Premises_Code, string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[11];
            p[0] = new SqlParameter("@Classroom_LName", Classroom_LName);
            p[1] = new SqlParameter("@Classroom_SName", Classroom_SName);
            p[2] = new SqlParameter("@Length_inFeet", Length_inFeet);
            p[3] = new SqlParameter("@Width_inFeet", Width_inFeet);
            p[4] = new SqlParameter("@Height_inFeet", Height_inFeet);
            p[5] = new SqlParameter("@Area_inSQFeet", Area_inSQFeet);
            p[6] = new SqlParameter("@ClassroomType_Id", ClassroomType_Id);
            p[7] = new SqlParameter("@IsActive", IsActive);
            p[8] = new SqlParameter("@Premises_Code", Premises_Code);
            p[9] = new SqlParameter("@CreatedBy", CreatedBy);
            p[10] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[10].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertClassroom", p);
            return (p[10].Value.ToString());
        }
        public static int Insert_ClassroomCentre(string Classroom_Code, string Primary_Centre_Code, string Centre_Code, string Created_By)
        {

            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@Classroom_Code", Classroom_Code);
            p[1] = new SqlParameter("@Primary_Centre_Code", Primary_Centre_Code);
            p[2] = new SqlParameter("@Centre_Code", Centre_Code);
            p[3] = new SqlParameter("@Created_By", Created_By);

            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertClassroom_Centre", p);
            return (int.Parse(p[4].Value.ToString()));
        }
        public static int Insert_ClassroomCapacity(string Classroom_Code, string Activity_Id, int Capacity, string UOM)
        {

            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@Classroom_Code", Classroom_Code);
            p[1] = new SqlParameter("@Activity_Id", Activity_Id);
            p[2] = new SqlParameter("@Capacity", Capacity);
            p[3] = new SqlParameter("@UOM", UOM);

            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertClassroom_Capacity", p);
            return (int.Parse(p[4].Value.ToString()));
        }
        public static string Update_Classroom(string Classroom_Code, string Premises_Code, string Classroom_LName, string Classroom_SName, double Length_inFeet, double Width_inFeet, double Height_inFeet, double Area_inSQFeet, string ClassroomType_Id, int IsActive,
        string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@Classroom_Code", Classroom_Code);
            p[1] = new SqlParameter("@Premises_Code", Premises_Code);
            p[2] = new SqlParameter("@Classroom_LName", Classroom_LName);
            p[3] = new SqlParameter("@Classroom_SName", Classroom_SName);
            p[4] = new SqlParameter("@Length_inFeet", Length_inFeet);
            p[5] = new SqlParameter("@Width_inFeet", Width_inFeet);
            p[6] = new SqlParameter("@Height_inFeet", Height_inFeet);
            p[7] = new SqlParameter("@Area_inSQFeet", Area_inSQFeet);
            p[8] = new SqlParameter("@ClassroomType_Id", ClassroomType_Id);
            p[9] = new SqlParameter("@IsActive", IsActive);
            p[10] = new SqlParameter("@CreatedBy", CreatedBy);
            p[11] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[11].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdateClassroom", p);
            return (p[11].Value.ToString());
        }
        public static DataSet GetAllActiveCountry()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCountry"));
        }
        //public static int Insert_ClassroomCentre(string Classroom_Code, string Primary_Centre_Code, string Centre_Code, string Created_By)
        //{

        //    SqlParameter[] p = new SqlParameter[5];
        //    p[0] = new SqlParameter("@Classroom_Code", Classroom_Code);
        //    p[1] = new SqlParameter("@Primary_Centre_Code", Primary_Centre_Code);
        //    p[2] = new SqlParameter("@Centre_Code", Centre_Code);
        //    p[3] = new SqlParameter("@Created_By", Created_By);

        //    p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
        //    p[4].Direction = ParameterDirection.Output;
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertClassroom_Centre", p);
        //    return (int.Parse(p[4].Value.ToString()));
        //}




        //public static int Insert_ClassroomCapacity(string Classroom_Code, string Activity_Id, int Capacity, string UOM)
        //{

        //    SqlParameter[] p = new SqlParameter[5];
        //    p[0] = new SqlParameter("@Classroom_Code", Classroom_Code);
        //    p[1] = new SqlParameter("@Activity_Id", Activity_Id);
        //    p[2] = new SqlParameter("@Capacity", Capacity);
        //    p[3] = new SqlParameter("@UOM", UOM);

        //    p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
        //    p[4].Direction = ParameterDirection.Output;
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertClassroom_Capacity", p);
        //    return (int.Parse(p[4].Value.ToString()));
        //}
        #endregion

        public static DataSet GetStudentDetailsBySBEntrycode(string SBEntrycode, int flag)
        {
            SqlParameter p1 = new SqlParameter("@SBEntryCode", SBEntrycode);
            SqlParameter p2 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetStudentDetailsBySBEntryCode", p1, p2));
        }

        /// <summary>
        /// LMS Integration
        /// </summary>
        /// <param name="Pkey"></param>
        /// <returns></returns>
        public static DataSet LMS_PassAllStudentdetailstoLMSApp(string Pkey)
        {
            SqlParameter p1 = new SqlParameter("@PKey", Pkey);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_LMS_PassAllStudentdetailstoLMSApp", p1));
        }

        public static DataSet LMS_PassAllStudentdetailstoLMSApp_Cross_Division(string Pkey)
        {
            SqlParameter p1 = new SqlParameter("@PKey", Pkey);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_LMS_PassAllStudentdetailstoLMSApp_Cross_batch", p1));
        }

        public static DataSet LMS_PassAllStudentdetailstoLMSApponConfirmation(string SBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBEntrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_LMS_PassAllStudentdetails", p1));
        }

        public static DataSet GetDiscount_Types(int Flag, string Division_Code, string Company)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@Company", Company);
            SqlParameter p3 = new SqlParameter("@Division_Code", Division_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetDiscount_Types", p1, p2, p3));
        }


        /// <summary>
        /// Used for Loan Dispatch
        /// </summary>
        /// <param name="ApplyLoanFlag"></param>
        /// <param name="ApplyLoanDate"></param>
        /// <param name="SBEntrycode"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public static int InsertBankLoanForStudent(int ApplyLoanFlag, string ApplyLoanDate, string SBEntrycode, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@ApplyLoanFlag", ApplyLoanFlag);
            SqlParameter p2 = new SqlParameter("@ApplyLoanDate ", ApplyLoanDate);
            SqlParameter p3 = new SqlParameter("@SBEntrycode", SBEntrycode);
            SqlParameter p4 = new SqlParameter("@Flag", Flag);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_BankLoanDetailForStudent", p1, p2, p3, p4));
        }

        /// <summary>
        /// Remove Receipt
        /// </summary>
        /// <param name="chequeidno"></param>
        /// <param name="SBEntrycode"></param>
        /// <param name="ModifiedBy"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>

        public static int DeleteCheque(string chequeidno, string SBEntrycode, string ModifiedBy, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@chequeidno", chequeidno);
            SqlParameter p2 = new SqlParameter("@ModifiedBy ", ModifiedBy);
            SqlParameter p3 = new SqlParameter("@SBEntrycode", SBEntrycode);
            SqlParameter p4 = new SqlParameter("@Flag", Flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Delete_Cheque", p1, p2, p3, p4));
        }


        public static int Insert_LMS_LOG(string SPID, string SBEntrycode, string SBEntryCodeOld, string StudentAccountId, string CenterCodeJoining, string CenterCodeCurrent, string flag, string Createdby)
        {
            SqlParameter p1 = new SqlParameter("@SPID", SPID);
            SqlParameter p2 = new SqlParameter("@SBEntrycode ", SBEntrycode);
            SqlParameter p3 = new SqlParameter("@SBEntrycodeOld", SBEntryCodeOld);
            SqlParameter p4 = new SqlParameter("@StudentAccountId", StudentAccountId);
            SqlParameter p5 = new SqlParameter("@CenterCodeJoining", CenterCodeJoining);
            SqlParameter p6 = new SqlParameter("@CenterCodeCurrent", CenterCodeCurrent);
            SqlParameter p7 = new SqlParameter("@Flag", flag);
            SqlParameter p8 = new SqlParameter("@Created_By", Createdby);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_LMS_STUDENT_LOG]", p1, p2, p3, p4, p5, p6, p7, p8));

        }


        public static DataSet GetDashboardValuesbyAcadYear(string Userid, string AcadYear)
        {
            SqlParameter P = new SqlParameter("@Userid", SqlDbType.NVarChar);
            P.Value = Userid;
            SqlParameter P1 = new SqlParameter("@Acad_Year", SqlDbType.NVarChar);
            P1.Value = AcadYear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_DASHBOARD", P, P1));
        }

        public static DataSet GetICardImagePath(int flag, string Division_Code)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.VarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p1.Value = Division_Code;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetICardImagePath", p, p1));
        }


        /// <summary>
        /// Campaign Code starts here
        /// </summary>


        public static int Insert_Update_CompaignRawData(string Import_Run_No, string Data_Source_Name, string Reference_Id, string Process_Status, string Live_Status, string Student_First_Name, string Student_Last_Name, string Parent_First_Name, string Parent_Last_Name, string EmailId, string Handphone_1, string Handphone_2,
            string Contact_No, string Address1, string Address2, string Address3, string Country, string State, string City, string Location, string Pincode, string ProductInterest, string Present_Status, string Created_By, string flag)
        {
            SqlParameter p0 = new SqlParameter("@Import_Run_No", Import_Run_No);
            SqlParameter p1 = new SqlParameter("@Data_Source_Name", Data_Source_Name);
            SqlParameter p2 = new SqlParameter("@Reference_Id ", Reference_Id);
            SqlParameter p3 = new SqlParameter("@Process_Status", Process_Status);
            SqlParameter p4 = new SqlParameter("@Live_Status", Live_Status);
            SqlParameter p5 = new SqlParameter("@Student_First_Name", Student_First_Name);
            SqlParameter p6 = new SqlParameter("@Student_Last_Name", Student_Last_Name);
            SqlParameter p7 = new SqlParameter("@Parent_First_Name", Parent_First_Name);
            SqlParameter p8 = new SqlParameter("@Parent_Last_Name", Parent_Last_Name);
            SqlParameter p9 = new SqlParameter("@Handphone_1", Handphone_1);
            SqlParameter p10 = new SqlParameter("@Handphone_2", Handphone_2);
            SqlParameter p11 = new SqlParameter("@Contact_No", Contact_No);
            SqlParameter p12 = new SqlParameter("@Address1", Address1);
            SqlParameter p13 = new SqlParameter("@Address2", Address2);
            SqlParameter p14 = new SqlParameter("@Address3", Address3);
            SqlParameter p15 = new SqlParameter("@Country", Country);
            SqlParameter p16 = new SqlParameter("@State", State);
            SqlParameter p17 = new SqlParameter("@City", City);
            SqlParameter p18 = new SqlParameter("@Location", Location);
            SqlParameter p19 = new SqlParameter("@Pincode", Pincode);
            SqlParameter p20 = new SqlParameter("@ProductInterest", ProductInterest);
            SqlParameter p21 = new SqlParameter("@Present_Status", Present_Status);
            SqlParameter p22 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p23 = new SqlParameter("@flag", flag);
            SqlParameter p24 = new SqlParameter("@EmailId", EmailId);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Usp_Insert_Update_CampaignRawData]", p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24));

        }


        public static string Insert_CompaignRawData_ExcelInfo(string Import_Run_No, string Import_File_Name, string Tag_Name, string Tag_Description, string TotalRecordCount, string SaveRecordCount, string Created_By, string flag)
        {
            SqlParameter p0 = new SqlParameter("@Import_Run_No", Import_Run_No);
            SqlParameter p1 = new SqlParameter("@Import_File_Name", Import_File_Name);
            SqlParameter p2 = new SqlParameter("@Tag_Name", Tag_Name);
            SqlParameter p3 = new SqlParameter("@Tag_Description", Tag_Description);
            SqlParameter p4 = new SqlParameter("@TotalRecordCount", TotalRecordCount);
            SqlParameter p5 = new SqlParameter("@SaveRecordCount", SaveRecordCount);
            SqlParameter p6 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p7 = new SqlParameter("@flag", flag);
            return Convert.ToString(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Usp_Insert_CampaignRawData_ExcelInfo]", p0, p1, p2, p3, p4, p5, p6, p7));

        }

        public static DataSet GetExcelSheetName(string ExcelName, int flag)
        {
            SqlParameter p1 = new SqlParameter("@ExcelName", ExcelName);
            SqlParameter p2 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Campaign_ExcelName", p1, p2));
        }

        public static DataSet GetExcelSheetRecord(string Import_Run_No, int flag)
        {
            SqlParameter p1 = new SqlParameter("@Import_Run_No", Import_Run_No);
            SqlParameter p2 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_CampaignRawData_PreLead", p1, p2));
        }

        public static DataSet Insert_PreLeadData(string Data_Id, string AllImport_Run_No, string Created_By, int flag)
        {
            SqlParameter p1 = new SqlParameter("@Data_Id", Data_Id);
            SqlParameter p2 = new SqlParameter("@AllImport_Run_No", AllImport_Run_No);
            SqlParameter p3 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p4 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Campaign_PreLead", p1, p2, p3, p4));
        }


        public static DataSet GetUser_Role_Campaign(int Flag, string Userid, string Campaign_Type, string Campaign_Name, string Acadyear, string status)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Type", SqlDbType.VarChar);
            p2.Value = Campaign_Type;
            SqlParameter p3 = new SqlParameter("@Campaign_Name", SqlDbType.VarChar);
            p3.Value = Campaign_Name;
            SqlParameter p4 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p4.Value = Acadyear;
            SqlParameter p5 = new SqlParameter("@CampignStatus", SqlDbType.VarChar);
            p5.Value = status;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_CampaignDetail", p, p1, p2, p3, p4, p5));
        }

        public static DataSet GetUser_Company_Division_Zone_Center_Campaign(int Flag, string Userid, string Divisioncode, string Zonecode, string Companycode)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@division_code", SqlDbType.VarChar);
            p2.Value = Divisioncode;
            SqlParameter p3 = new SqlParameter("@Zone_code", SqlDbType.VarChar);
            p3.Value = Zonecode;
            SqlParameter p4 = new SqlParameter("@Company_Code", SqlDbType.VarChar);
            p4.Value = Companycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center_Campaign", p, p1, p2, p3, p4));
        }


        public static DataSet Insert_Update_CampaignDetail(int Flag, string Campaign_Id, string Campaign_Type, string Campaign_Name, string Campaign_Status,
                    string Target_Audience, string Campaign_Sponsor, string Sponsor_Desc, string ExpectedCloseDate, string TargetSize, string NumSent, string Campaign_Owner,
            string Company_code, string Division_Code, string Zone_Code, string Center_Code, string Role_Code, string Campaign_Product, string Assigned_To, string Budget_Coast,
            string Actual_Coast, string Expected_Response, string Expected_Revenue, string Expected_SalesCount, string Actual_SalesCount, string Expected_ResponseCount,
            string Actual_ResponseCount, string Expected_ROI, string Actual_ROI, string Resourse_StartDate, string Resourse_EndDate, string Source, string AproxCoast,
            string Created_By, string Excel_Import_Run_No, string Acad_Year)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p1.Value = Campaign_Id;
            SqlParameter p2 = new SqlParameter("@Campaign_Type", SqlDbType.VarChar);
            p2.Value = Campaign_Type;
            SqlParameter p3 = new SqlParameter("@Campaign_Name", SqlDbType.VarChar);
            p3.Value = Campaign_Name;
            SqlParameter p4 = new SqlParameter("@Campaign_Status", SqlDbType.VarChar);
            p4.Value = Campaign_Status;
            SqlParameter p5 = new SqlParameter("@Target_Audience", SqlDbType.VarChar);
            p5.Value = Target_Audience;
            SqlParameter p6 = new SqlParameter("@Campaign_Sponsor", SqlDbType.VarChar);
            p6.Value = Campaign_Sponsor;
            SqlParameter p7 = new SqlParameter("@Sponsor_Desc", SqlDbType.VarChar);
            p7.Value = Sponsor_Desc;
            SqlParameter p8 = new SqlParameter("@ExpectedCloseDate", SqlDbType.VarChar);
            p8.Value = ExpectedCloseDate;
            SqlParameter p9 = new SqlParameter("@TargetSize", SqlDbType.VarChar);
            p9.Value = TargetSize;
            SqlParameter p10 = new SqlParameter("@NumSent", SqlDbType.VarChar);
            p10.Value = NumSent;
            SqlParameter p11 = new SqlParameter("@Campaign_Owner", SqlDbType.VarChar);
            p11.Value = Campaign_Owner;
            SqlParameter p12 = new SqlParameter("@Company_code", SqlDbType.VarChar);
            p12.Value = Company_code;
            SqlParameter p13 = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p13.Value = Division_Code;
            SqlParameter p14 = new SqlParameter("@Zone_Code", SqlDbType.VarChar);
            p14.Value = Zone_Code;
            SqlParameter p15 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p15.Value = Center_Code;
            SqlParameter p16 = new SqlParameter("@Role_Code", SqlDbType.VarChar);
            p16.Value = Role_Code;
            SqlParameter p17 = new SqlParameter("@Campaign_Product", SqlDbType.VarChar);
            p17.Value = Campaign_Product;
            SqlParameter p18 = new SqlParameter("@Assigned_To", SqlDbType.VarChar);
            p18.Value = Assigned_To;
            SqlParameter p19 = new SqlParameter("@Budget_Coast", SqlDbType.VarChar);
            p19.Value = Budget_Coast;
            SqlParameter p20 = new SqlParameter("@Actual_Coast", SqlDbType.VarChar);
            p20.Value = Actual_Coast;
            SqlParameter p21 = new SqlParameter("@Expected_Response", SqlDbType.VarChar);
            p21.Value = Expected_Response;
            SqlParameter p22 = new SqlParameter("@Expected_Revenue", SqlDbType.VarChar);
            p22.Value = Expected_Revenue;
            SqlParameter p23 = new SqlParameter("@Expected_SalesCount", SqlDbType.VarChar);
            p23.Value = Expected_SalesCount;
            SqlParameter p24 = new SqlParameter("@Actual_SalesCount", SqlDbType.VarChar);
            p24.Value = Actual_SalesCount;
            SqlParameter p25 = new SqlParameter("@Expected_ResponseCount", SqlDbType.VarChar);
            p25.Value = Expected_ResponseCount;
            SqlParameter p26 = new SqlParameter("@Actual_ResponseCount", SqlDbType.VarChar);
            p26.Value = Actual_ResponseCount;
            SqlParameter p27 = new SqlParameter("@Expected_ROI", SqlDbType.VarChar);
            p27.Value = Expected_ROI;
            SqlParameter p28 = new SqlParameter("@Actual_ROI", SqlDbType.VarChar);
            p28.Value = Actual_ROI;
            SqlParameter p29 = new SqlParameter("@Resourse_StartDate", SqlDbType.VarChar);
            p29.Value = Resourse_StartDate;
            SqlParameter p30 = new SqlParameter("@Resourse_EndDate", SqlDbType.VarChar);
            p30.Value = Resourse_EndDate;
            SqlParameter p31 = new SqlParameter("@Source", SqlDbType.VarChar);
            p31.Value = Source;
            SqlParameter p32 = new SqlParameter("@AproxCoast", SqlDbType.VarChar);
            p32.Value = AproxCoast;
            SqlParameter p33 = new SqlParameter("@Created_By ", SqlDbType.VarChar);
            p33.Value = Created_By;
            SqlParameter p34 = new SqlParameter("@Excel_Import_Run_No ", SqlDbType.VarChar);
            p34.Value = Excel_Import_Run_No;
            SqlParameter p35 = new SqlParameter("@Acad_Year ", SqlDbType.VarChar);
            p35.Value = Acad_Year;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_Campaign_Detail", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35));
        }

        public static DataSet Get_CampaignDetailByPKey(int Flag, string Userid, string Campaign_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p2.Value = Campaign_Id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_CampaignDetailByPKey", p, p1, p2));
        }

        public static DataSet Insert_Delete_Campaign_Contact(int Flag, string Userid, string Campaign_Id, string PreLeadId)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p2.Value = Campaign_Id;
            SqlParameter p3 = new SqlParameter("@PreLead_Id", SqlDbType.VarChar);
            p3.Value = PreLeadId;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertDelete_CampaignContactByPKey", p, p1, p2, p3));
        }

        public static DataSet GetStreamby_Center_AcademicYear_AllAfterCourseDuration(string CenterCode, string AcademicYear)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_byCenter_Acadyear_All_AfterCourseDuration", p, p1));
        }

        public static DataSet Get_Campaign_Contacts(int Flag, string Userid, string Value, string Opearator2, string ColName, string Opearator1)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Value", SqlDbType.VarChar);
            p2.Value = Value;
            SqlParameter p3 = new SqlParameter("@Opearator2", SqlDbType.VarChar);
            p3.Value = Opearator2;
            SqlParameter p4 = new SqlParameter("@ColName", SqlDbType.VarChar);
            p4.Value = ColName;
            SqlParameter p5 = new SqlParameter("@Opearator1", SqlDbType.VarChar);
            p5.Value = Opearator1;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Campaign_Contacts", p, p1, p2, p3, p4, p5));
        }


        public static DataSet Get_Campaign_Contacts(int Flag, string Userid, string Value, string Opearator2, string ColName, string Opearator1, string Page_Number, string Campaign_Id)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Value", SqlDbType.VarChar);
            p2.Value = Value;
            SqlParameter p3 = new SqlParameter("@Opearator2", SqlDbType.VarChar);
            p3.Value = Opearator2;
            SqlParameter p4 = new SqlParameter("@ColName", SqlDbType.VarChar);
            p4.Value = ColName;
            SqlParameter p5 = new SqlParameter("@Opearator1", SqlDbType.VarChar);
            p5.Value = Opearator1;
            SqlParameter p6 = new SqlParameter("@Page_Number", SqlDbType.VarChar);
            p6.Value = Page_Number;
            SqlParameter p7 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p7.Value = Campaign_Id;


            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Campaign_Contacts", p, p1, p2, p3, p4, p5, p6, p7));
        }

        public static DataSet Insert_UPdate_Campaign_Contacts(string Flag, string Campaign_Id, string Contacts_Id_Add, string Created_By, string AgentUserCode)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.VarChar);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p1.Value = Campaign_Id;
            SqlParameter p2 = new SqlParameter("@Contacts_Id_Add", SqlDbType.VarChar);
            p2.Value = Contacts_Id_Add;
            //SqlParameter p3 = new SqlParameter("@Contacts_Id_Remove", SqlDbType.VarChar);
            //p3.Value = Contacts_Id_Remove;
            SqlParameter p3 = new SqlParameter("@Created_By", SqlDbType.VarChar);
            p3.Value = Created_By;
            SqlParameter p4 = new SqlParameter("@AgentUserCode", SqlDbType.VarChar);
            p4.Value = AgentUserCode;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Update_Campaign_Students", p, p1, p2, p3, p4));
        }


        //21 Jan 2015       

        public static DataSet Get_ContactbyContactId(int Flag, string Leadid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@lead_opp_id", SqlDbType.VarChar);
            p[1].Value = Leadid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETCONID", p));
        }

        public static DataSet Insert_Update_Contact_AcadInfo(string Institution_Type_Id, string Institution_Type_Desc, string Institution_Desc, string Board_Id, string Board_Desc, string Cur_Standard_Id, string Cur_Standard_Desc,
                string Section_Id, string Section_Desc, string YearOfPassing_Id, string YearOfPassing_Desc, string Aditional_Desc, string ExamName, string FinalMarksObt, string FinalMarksTotal, string Grade,
                string Percentage, string CON_ID, string Created_By, string Record_No, string Flag, string Exam_Id, string Exam_Status_id, string Exam_Status_Desc, string Exam_Rank, string School_College_Id, string School_College_Name)
        {
            SqlParameter p20 = new SqlParameter("@Institution_Type_Id", SqlDbType.VarChar);
            p20.Value = Institution_Type_Id;
            SqlParameter p21 = new SqlParameter("@Institution_Type_Desc", SqlDbType.VarChar);
            p21.Value = Institution_Type_Desc;
            SqlParameter p22 = new SqlParameter("@Institution_Desc", SqlDbType.VarChar);
            p22.Value = Institution_Desc;
            SqlParameter p23 = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            p23.Value = Board_Id;
            SqlParameter p24 = new SqlParameter("@Board_Desc", SqlDbType.VarChar);
            p24.Value = Board_Desc;
            SqlParameter p25 = new SqlParameter("@Cur_Standard_Id", SqlDbType.VarChar);
            p25.Value = Cur_Standard_Id;
            SqlParameter p26 = new SqlParameter("@Cur_Standard_Desc", SqlDbType.VarChar);
            p26.Value = Cur_Standard_Desc;
            SqlParameter p27 = new SqlParameter("@Section_Id", SqlDbType.VarChar);
            p27.Value = Section_Id;
            SqlParameter p28 = new SqlParameter("@Section_Desc", SqlDbType.VarChar);
            p28.Value = Section_Desc;
            SqlParameter p29 = new SqlParameter("@YearOfPassing_Id", SqlDbType.VarChar);
            p29.Value = YearOfPassing_Id;
            SqlParameter p30 = new SqlParameter("@YearOfPassing_Desc", SqlDbType.VarChar);
            p30.Value = YearOfPassing_Desc;
            SqlParameter p31 = new SqlParameter("@Aditional_Desc", SqlDbType.VarChar);
            p31.Value = Aditional_Desc;
            SqlParameter p32 = new SqlParameter("@ExamName", SqlDbType.VarChar);
            p32.Value = ExamName;
            SqlParameter p33 = new SqlParameter("@FinalMarksObt", SqlDbType.VarChar);
            p33.Value = FinalMarksObt;
            SqlParameter p34 = new SqlParameter("@FinalMarksTotal", SqlDbType.VarChar);
            p34.Value = FinalMarksTotal;
            SqlParameter p35 = new SqlParameter("@Grade", SqlDbType.VarChar);
            p35.Value = Grade;
            SqlParameter p36 = new SqlParameter("@Percentage", SqlDbType.VarChar);
            p36.Value = Percentage;
            SqlParameter p37 = new SqlParameter("@CON_ID", SqlDbType.VarChar);
            p37.Value = CON_ID;
            SqlParameter p38 = new SqlParameter("@Created_By", SqlDbType.VarChar);
            p38.Value = Created_By;
            SqlParameter p39 = new SqlParameter("@Record_No", SqlDbType.VarChar);
            p39.Value = Record_No;
            SqlParameter p40 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p40.Value = Flag;
            SqlParameter p41 = new SqlParameter("@Exam_Id", SqlDbType.VarChar);
            p41.Value = Exam_Id;
            SqlParameter p42 = new SqlParameter("@Exam_Status_id", SqlDbType.VarChar);
            p42.Value = Exam_Status_id;
            SqlParameter p43 = new SqlParameter("@Exam_Status_Desc", SqlDbType.VarChar);
            p43.Value = Exam_Status_Desc;
            SqlParameter p44 = new SqlParameter("@Exam_Rank", SqlDbType.VarChar);
            p44.Value = Exam_Rank;
            SqlParameter p45 = new SqlParameter("@School_Id", SqlDbType.VarChar);
            p45.Value = School_College_Id;
            SqlParameter p46 = new SqlParameter("@School_Name", SqlDbType.VarChar);
            p46.Value = School_College_Name;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Update_Conatct_Detail", p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35, p36, p37, p38, p39, p40, p41, p42, p43, p44, p45, p46));
        }

        public static DataSet Insert_Update_Secondory_Contact(string CON_ID, string SecCon_TypeId, string SecCon_Type, string SecCon_Title, string SecCon_FName, string SecCon_MName, string SecCon_LName, string SecCon_Handphone1, string SecCon_Handphone2,
                string SecCon_Landline, string SecCon_EmailId, string SecCon_Gender, string SecCon_Occupation, string SecCon_Organization, string SecCon_Designation, string SecCon_OfficePhone, string Created_By, string Flag)
        {
            SqlParameter p35 = new SqlParameter("@CON_ID", SqlDbType.VarChar);
            p35.Value = CON_ID;
            SqlParameter p36 = new SqlParameter("@SecCon_TypeId", SqlDbType.VarChar);
            p36.Value = SecCon_TypeId;
            SqlParameter p37 = new SqlParameter("@SecCon_Type", SqlDbType.VarChar);
            p37.Value = SecCon_Type;
            SqlParameter p38 = new SqlParameter("@SecCon_Title", SqlDbType.VarChar);
            p38.Value = SecCon_Title;
            SqlParameter p39 = new SqlParameter("@SecCon_FName", SqlDbType.VarChar);
            p39.Value = SecCon_FName;
            SqlParameter p40 = new SqlParameter("@SecCon_MName", SqlDbType.VarChar);
            p40.Value = SecCon_MName;
            SqlParameter p41 = new SqlParameter("@SecCon_LName", SqlDbType.VarChar);
            p41.Value = SecCon_LName;
            SqlParameter p42 = new SqlParameter("@SecCon_Handphone1", SqlDbType.VarChar);
            p42.Value = SecCon_Handphone1;
            SqlParameter p43 = new SqlParameter("@SecCon_Handphone2", SqlDbType.VarChar);
            p43.Value = SecCon_Handphone2;
            SqlParameter p44 = new SqlParameter("@SecCon_Landline", SqlDbType.VarChar);
            p44.Value = SecCon_Landline;
            SqlParameter p45 = new SqlParameter("@SecCon_EmailId", SqlDbType.VarChar);
            p45.Value = SecCon_EmailId;
            SqlParameter p46 = new SqlParameter("@SecCon_Gender", SqlDbType.VarChar);
            p46.Value = SecCon_Gender;
            SqlParameter p47 = new SqlParameter("@SecCon_Occupation", SqlDbType.VarChar);
            p47.Value = SecCon_Occupation;
            SqlParameter p48 = new SqlParameter("@SecCon_Organization", SqlDbType.VarChar);
            p48.Value = SecCon_Organization;
            SqlParameter p49 = new SqlParameter("@SecCon_Designation", SqlDbType.VarChar);
            p49.Value = SecCon_Designation;
            SqlParameter p50 = new SqlParameter("@SecCon_OfficePhone", SqlDbType.VarChar);
            p50.Value = SecCon_OfficePhone;
            SqlParameter p51 = new SqlParameter("@Created_By", SqlDbType.VarChar);
            p51.Value = Created_By;
            SqlParameter p52 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p52.Value = Flag;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Update_Conatct_Detail", p35, p36, p37, p38, p39, p40, p41, p42, p43, p44, p45, p46, p47, p48, p49, p50, p51, p52));
        }

        public static DataSet Insert_Update_Contact_Detail(string Con_Type_Id, string Con_Type_Desc, string Category_Type_Id, string Category_Type_Desc, string Con_Title, string Con_FName, string Con_MName, string Con_LName,
                string Con_Gender, string Con_DOB, string Con_Handphone1, string Con_Handphone2, string Con_Landline, string Con_Address1, string Con_Address2, string Con_Street, string Con_Country, string Con_State, string Con_City, string Con_PostalCode,
                string Con_EmailId, string CON_ID, string Created_By, string Flag)
        {
            SqlParameter p = new SqlParameter("@Con_Type_Id", SqlDbType.VarChar);
            p.Value = Con_Type_Id;
            SqlParameter p1 = new SqlParameter("@Con_Type_Desc", SqlDbType.VarChar);
            p1.Value = Con_Type_Desc;
            SqlParameter p2 = new SqlParameter("@Category_Type_Id", SqlDbType.VarChar);
            p2.Value = Category_Type_Id;
            SqlParameter p3 = new SqlParameter("@Category_Type_Desc", SqlDbType.VarChar);
            p3.Value = Category_Type_Desc;
            SqlParameter p4 = new SqlParameter("@Con_Title", SqlDbType.VarChar);
            p4.Value = Con_Title;
            SqlParameter p5 = new SqlParameter("@Con_FName", SqlDbType.VarChar);
            p5.Value = Con_FName;
            SqlParameter p6 = new SqlParameter("@Con_MName", SqlDbType.VarChar);
            p6.Value = Con_MName;
            SqlParameter p7 = new SqlParameter("@Con_LName", SqlDbType.VarChar);
            p7.Value = Con_LName;
            SqlParameter p8 = new SqlParameter("@Con_Gender", SqlDbType.VarChar);
            p8.Value = Con_Gender;
            SqlParameter p9 = new SqlParameter("@Con_DOB", SqlDbType.VarChar);
            p9.Value = Con_DOB;
            SqlParameter p10 = new SqlParameter("@Con_Handphone1", SqlDbType.VarChar);
            p10.Value = Con_Handphone1;
            SqlParameter p11 = new SqlParameter("@Con_Handphone2", SqlDbType.VarChar);
            p11.Value = Con_Handphone2;
            SqlParameter p12 = new SqlParameter("@Con_Landline", SqlDbType.VarChar);
            p12.Value = Con_Landline;
            SqlParameter p13 = new SqlParameter("@Con_Address1", SqlDbType.VarChar);
            p13.Value = Con_Address1;
            SqlParameter p14 = new SqlParameter("@Con_Address2", SqlDbType.VarChar);
            p14.Value = Con_Address2;
            SqlParameter p15 = new SqlParameter("@Con_Street", SqlDbType.VarChar);
            p15.Value = Con_Street;
            SqlParameter p16 = new SqlParameter("@Con_Country", SqlDbType.VarChar);
            p16.Value = Con_Country;
            SqlParameter p17 = new SqlParameter("@Con_State", SqlDbType.VarChar);
            p17.Value = Con_State;
            SqlParameter p18 = new SqlParameter("@Con_City", SqlDbType.VarChar);
            p18.Value = Con_City;
            SqlParameter p19 = new SqlParameter("@Con_PostalCode", SqlDbType.VarChar);
            p19.Value = Con_PostalCode;
            SqlParameter p20 = new SqlParameter("@Con_EmailId", SqlDbType.VarChar);
            p20.Value = Con_EmailId;
            SqlParameter p21 = new SqlParameter("@CON_ID", SqlDbType.VarChar);
            p21.Value = CON_ID;
            SqlParameter p22 = new SqlParameter("@Created_By", SqlDbType.VarChar);
            p22.Value = Created_By;
            SqlParameter p23 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p23.Value = Flag;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Update_Conatct_Detail", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23));
        }


        //25 Jan 2015



        //27 Jan 2016
        public static string UpdateOpportunityContact_New(string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank, int Overallrank, string Scorerange, string Handphone1,
        string handphone2, string landline, string emailid, string Flatno, string buildingname, string streetname, string Countryname, string State, string City, string pincode,
        string Category_Type_Id, string Category_Type, string Institution_Type_Id, string Institution_Type_Desc, string Institution_Description, string Current_Standard_Id, string Current_Standard_Desc, string Additional_Desc, string Board_Id, string Board_Desc,
        string Section_Id, string Section_Desc, string Year_of_Passing_ID, string Year_of_Passing_Desc, string Current_Year_Id, string Current_Year_Desc, string Student_Id, string Last_Course_Opted, string Opp_Type_ID, string Opp_Name,
        string Product_Category, string Product_Code, string Sales_Stage, System.DateTime Opp_Join_Date, System.DateTime Opp_Expected_Close_Date, string Opp_Probability_Percent, string Opp_Next_Step, decimal Opp_Value, decimal Opp_Disc, string Opp_Contact_Company,
        string Opp_ContactSource_Division, string Opp_ContactSource_Center, string Opp_ContactSource_Zone, string Opp_Contact_Division, string Opp_Contact_Center, string Opp_Contact_Zone, string Opp_Contact_Role, string Opp_Contact_Assignto, string Last_Modified_By, string Opp_Status,
        string Opp_Status_Id, string Oppor_Product, string Oppor_Product_Id, string oppid, string appno, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname,
        string Sechphone1, string Sechphone2, string Seclandline, string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity,
        string Secpincode, string SecContactDesc, int discipline_id, string Discipline_desc, int Field_Id, string Field_Desc, string Competitive_Exam, int Totalmsmarks, int Totalmsmarksobt, string Opp_Contact_target_Company,
        string dob, string last_exam, string location, string gender, string discountnotes, string Is_Branch_Topper, string Branch_Topper_Division, string Branch_Topper_Center,
        string Is_School_Ranker, string School_Name, string School_Division, string School_Rank,
          string Apply_Additional_Discount, string Discount_Type, string Flag)
        {
            SqlParameter[] p = new SqlParameter[106];
            p[0] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[0].Value = CON_TITLE;
            p[1] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[1].Value = CON_FIRSTNAME;
            p[2] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[2].Value = CON_MNAME;
            p[3] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[3].Value = CON_LNAME;
            p[4] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[4].Value = Score;
            p[5] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[5].Value = percentile;
            p[6] = new SqlParameter("@Area_rank", SqlDbType.NVarChar);
            p[6].Value = Area_rank;
            p[7] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[7].Value = Overallrank;
            p[8] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[8].Value = Scorerange;
            p[9] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[9].Value = Handphone1;
            p[10] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[10].Value = handphone2;
            p[11] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[11].Value = landline;
            p[12] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[12].Value = emailid;
            p[13] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[13].Value = Flatno;
            p[14] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[14].Value = buildingname;
            p[15] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[15].Value = streetname;
            p[16] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[16].Value = Countryname;
            p[17] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[17].Value = State;
            p[18] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[18].Value = City;
            p[19] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[19].Value = pincode;
            p[20] = new SqlParameter("@Category_Type_Id", SqlDbType.NVarChar);
            p[20].Value = Category_Type_Id;
            p[21] = new SqlParameter("@Category_Type", SqlDbType.NVarChar);
            p[21].Value = Category_Type;

            p[22] = new SqlParameter("@Institution_Type_Id", SqlDbType.NVarChar);
            p[22].Value = Institution_Type_Id;
            p[23] = new SqlParameter("@Institution_Type_Desc", SqlDbType.NVarChar);
            p[23].Value = Institution_Type_Desc;
            p[24] = new SqlParameter("@Institution_Description", SqlDbType.NVarChar);
            p[24].Value = Institution_Description;
            p[25] = new SqlParameter("@Current_Standard_id", SqlDbType.NVarChar);
            p[25].Value = Current_Standard_Id;
            p[26] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[26].Value = Current_Standard_Desc;
            p[27] = new SqlParameter("@Additional_desc", SqlDbType.NVarChar);
            p[27].Value = Additional_Desc;
            p[28] = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            p[28].Value = Board_Id;
            p[29] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[29].Value = Board_Desc;
            p[30] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[30].Value = Section_Id;
            p[31] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[31].Value = Section_Desc;
            p[32] = new SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar);
            p[32].Value = Year_of_Passing_ID;
            p[33] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[33].Value = Year_of_Passing_Desc;
            p[34] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[34].Value = Current_Year_Id;
            p[35] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[35].Value = Current_Year_Desc;
            p[36] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
            p[36].Value = Student_Id;
            p[37] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[37].Value = Last_Course_Opted;

            p[38] = new SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar);
            p[38].Value = Opp_Type_ID;
            p[39] = new SqlParameter("@Opp_Name", SqlDbType.NVarChar);
            p[39].Value = Opp_Name;

            p[40] = new SqlParameter("@Product_Category", SqlDbType.NVarChar);
            p[40].Value = Product_Category;
            p[41] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
            p[41].Value = Product_Code;
            p[42] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[42].Value = Sales_Stage;
            p[43] = new SqlParameter("@Opp_Join_Date", SqlDbType.DateTime);
            p[43].Value = Opp_Join_Date;

            p[44] = new SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime);
            p[44].Value = Opp_Expected_Close_Date;
            p[45] = new SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar);
            p[45].Value = Opp_Probability_Percent;
            p[46] = new SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar);
            p[46].Value = Opp_Next_Step;
            p[47] = new SqlParameter("@Opp_Value", SqlDbType.Decimal);
            p[47].Value = Opp_Value;
            p[48] = new SqlParameter("@Opp_Disc", SqlDbType.Decimal);
            p[48].Value = Opp_Disc;

            p[49] = new SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar);
            p[49].Value = Opp_Contact_Company;
            p[50] = new SqlParameter("@Opp_ContactSource_Division", SqlDbType.NVarChar);
            p[50].Value = Opp_ContactSource_Division;
            p[51] = new SqlParameter("@Opp_ContactSource_Center", SqlDbType.NVarChar);
            p[51].Value = Opp_ContactSource_Center;
            p[52] = new SqlParameter("@Opp_ContactSource_Zone", SqlDbType.NVarChar);
            p[52].Value = Opp_ContactSource_Zone;

            p[53] = new SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar);
            p[53].Value = Opp_Contact_Division;
            p[54] = new SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar);
            p[54].Value = Opp_Contact_Center;
            p[55] = new SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar);
            p[55].Value = Opp_Contact_Zone;

            p[56] = new SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar);
            p[56].Value = Opp_Contact_Role;
            p[57] = new SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar);
            p[57].Value = Opp_Contact_Assignto;

            p[58] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[58].Value = Last_Modified_By;
            p[59] = new SqlParameter("@Opp_Status", SqlDbType.NVarChar);
            p[59].Value = Opp_Status;
            p[60] = new SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar);
            p[60].Value = Opp_Status_Id;
            p[61] = new SqlParameter("@Oppor_Product", SqlDbType.NVarChar);
            p[61].Value = Oppor_Product;
            p[62] = new SqlParameter("@Oppor_Product_Id", SqlDbType.NVarChar, 100);
            p[62].Value = Oppor_Product_Id;
            p[63] = new SqlParameter("@oppid", SqlDbType.NVarChar);
            p[63].Value = oppid;
            p[64] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[64].Direction = ParameterDirection.Output;
            p[65] = new SqlParameter("@appno", SqlDbType.NVarChar);
            p[65].Value = appno;

            p[66] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[66].Value = SecContactType;
            p[67] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[67].Value = SecTitle;
            p[68] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[68].Value = Secfname;
            p[69] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[69].Value = SecMname;
            p[70] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[70].Value = SecLname;
            p[71] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[71].Value = Sechphone1;
            p[72] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[72].Value = Sechphone2;
            p[73] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[73].Value = Seclandline;
            p[74] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[74].Value = Secemail;
            p[75] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[75].Value = SecAdd1;
            p[76] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[76].Value = Secadd2;
            p[77] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[77].Value = SecStreetname;
            p[78] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[78].Value = SecCountryname;
            p[79] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[79].Value = SecState;
            p[80] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[80].Value = SecCity;
            p[81] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[81].Value = Secpincode;
            p[82] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[82].Value = SecContactDesc;
            p[83] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[83].Value = discipline_id;
            p[84] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[84].Value = Discipline_desc;
            p[85] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[85].Value = Field_Id;
            p[86] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[86].Value = Field_Desc;
            p[87] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[87].Value = Competitive_Exam;
            p[88] = new SqlParameter("@Total_ms_Marks", SqlDbType.Int);
            p[88].Value = Totalmsmarks;
            p[89] = new SqlParameter("@Total_ms_Marks_obt", SqlDbType.Int);
            p[89].Value = Totalmsmarksobt;
            p[90] = new SqlParameter("@Opp_Contact_Target_Company", SqlDbType.VarChar);
            p[90].Value = Opp_Contact_target_Company;

            p[91] = new SqlParameter("@dob", SqlDbType.VarChar);
            p[91].Value = dob;
            p[92] = new SqlParameter("@xam_details", SqlDbType.VarChar);
            p[92].Value = last_exam;
            p[93] = new SqlParameter("@location", SqlDbType.VarChar);
            p[93].Value = location;
            p[94] = new SqlParameter("@gender", SqlDbType.VarChar);
            p[94].Value = gender;
            p[95] = new SqlParameter("@discnotes", SqlDbType.VarChar);
            p[95].Value = discountnotes;

            p[96] = new SqlParameter("@Is_Branch_Topper", SqlDbType.VarChar);
            p[96].Value = Is_Branch_Topper;
            p[97] = new SqlParameter("@Branch_Topper_Division", SqlDbType.VarChar);
            p[97].Value = Branch_Topper_Division;
            p[98] = new SqlParameter("@Branch_Topper_Center", SqlDbType.VarChar);
            p[98].Value = Branch_Topper_Center;
            p[99] = new SqlParameter("@Is_School_Ranker", SqlDbType.VarChar);
            p[99].Value = Is_School_Ranker;
            p[100] = new SqlParameter("@School_Name", SqlDbType.VarChar);
            p[100].Value = School_Name;
            p[101] = new SqlParameter("@School_Division", SqlDbType.VarChar);
            p[101].Value = School_Division;

            p[102] = new SqlParameter("@School_Rank", SqlDbType.VarChar);
            p[102].Value = School_Rank;
            p[103] = new SqlParameter("@Apply_Additional_Discount", SqlDbType.VarChar);
            p[103].Value = Apply_Additional_Discount;
            p[104] = new SqlParameter("@Discount_Type", SqlDbType.VarChar);
            p[104].Value = Discount_Type;
            p[105] = new SqlParameter("@Flag", SqlDbType.VarChar);
            p[105].Value = Flag;


            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Opp_Contact", p);
            return (p[64].Value.ToString());
        }
        //28 Jan 2016

        public static DataSet Insert_Convert_Contact_To_Lead(string lead_src_id, string lead_src_desc, string Lead_type_id, string Lead_status_id, string Lead_status_desc, string Lead_campgn_id, string Prod_Interest,
        string Time_join, string Lead_Con_id, string contact_Source_company, string contact_Source_Division, string contact_Source_Center, string contact_Source_zone, string Contact_Assignto, string Last_modified_by,
        string Createdby, string Contact_Target_Company, string Contact_Target_Division, string Contact_Target_Zone, string Contact_Target_Center, int Discipline_Id, string Discipline_Desc, int Field_ID, string Field_Interested_Desc, string Competitive_Exam,
        string Lead_Type_Desc, string lead_source_desc, string last_exam, int C_Year_Education, string Expected_Joining_Acad_Year)
        {
            SqlParameter[] p = new SqlParameter[31];
            p[0] = new SqlParameter("@lead_src_id", SqlDbType.NVarChar);
            p[0].Value = lead_src_id;
            p[1] = new SqlParameter("@lead_src_desc", SqlDbType.NVarChar);
            p[1].Value = lead_src_desc;
            p[2] = new SqlParameter("@Lead_type_id", SqlDbType.NVarChar);
            p[2].Value = Lead_type_id;
            p[3] = new SqlParameter("@Lead_status_id", SqlDbType.NVarChar);
            p[3].Value = Lead_status_id;
            p[4] = new SqlParameter("@Lead_status_desc", SqlDbType.NVarChar);
            p[4].Value = Lead_status_desc;
            p[5] = new SqlParameter("@Lead_campgn_id", SqlDbType.NVarChar);
            p[5].Value = Lead_campgn_id;
            p[6] = new SqlParameter("@Prod_Interest", SqlDbType.NVarChar);
            p[6].Value = Prod_Interest;
            p[7] = new SqlParameter("@Time_join", SqlDbType.NVarChar);
            p[7].Value = Time_join;
            p[8] = new SqlParameter("@Lead_Con_id", SqlDbType.NVarChar);
            p[8].Value = Lead_Con_id;
            p[9] = new SqlParameter("@contact_Source_company", SqlDbType.NVarChar);
            p[9].Value = contact_Source_company;
            p[10] = new SqlParameter("@contact_Source_Division", SqlDbType.NVarChar);
            p[10].Value = contact_Source_Division;
            p[11] = new SqlParameter("@contact_Source_Center", SqlDbType.NVarChar);
            p[11].Value = contact_Source_Center;

            p[12] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[12].Direction = ParameterDirection.Output;

            p[13] = new SqlParameter("@contact_Source_zone", SqlDbType.NVarChar);
            p[13].Value = contact_Source_zone;
            p[14] = new SqlParameter("@Contact_Assignto", SqlDbType.NVarChar);
            p[14].Value = Contact_Assignto;
            p[15] = new SqlParameter("@Last_modified_by", SqlDbType.NVarChar);
            p[15].Value = Last_modified_by;
            p[16] = new SqlParameter("@Createdby", SqlDbType.NVarChar);
            p[16].Value = Createdby;
            p[17] = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p[17].Value = Contact_Target_Company;
            p[18] = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p[18].Value = Contact_Target_Division;
            p[19] = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p[19].Value = Contact_Target_Zone;
            p[20] = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p[20].Value = Contact_Target_Center;
            p[21] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[21].Value = Discipline_Id;
            p[22] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[22].Value = Discipline_Desc;
            p[23] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[23].Value = Field_ID;
            p[24] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[24].Value = Field_Interested_Desc;
            p[25] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[25].Value = Competitive_Exam;
            p[26] = new SqlParameter("@Lead_Type_Desc", SqlDbType.NVarChar);
            p[26].Value = Lead_Type_Desc;
            p[27] = new SqlParameter("@lead_source_desc", SqlDbType.NVarChar);
            p[27].Value = lead_source_desc;
            p[28] = new SqlParameter("@last_exam", SqlDbType.NVarChar);
            p[28].Value = last_exam;
            p[29] = new SqlParameter("@C_Year_Education", SqlDbType.Int);
            p[29].Value = C_Year_Education;
            p[30] = new SqlParameter("@Expected_Joining_Acad_Year", SqlDbType.NVarChar);
            p[30].Value = Expected_Joining_Acad_Year;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Convert_ContactTo_Lead", p));
            //SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Convert_ContactTo_Lead", p);
            //return (p[12].Value.ToString());
        }

        public static DataSet UpdateManualLeadContact_New(string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank, int Overallrank, string Scorerange, string Handphone1,
        string handphone2, string landline, string emailid, string Flatno, string buildingname, string streetname, string Countryname, string State, string City, string pincode,
        string Lead_Code, string Lead_Contact_Code, string Contact_Source_company, string Contact_Source_Division, string Contact_Source_Center, string Contact_Source_Zone, string Contact_assignto, string last_modified_by, string Contact_Target_Company, string Contact_Target_Division,
        string Contact_Target_Zone, string Contact_Target_Center, int discipline_id, string Discipline_desc, int Field_Id, string Field_Desc, string Competitive_Exam, string Category_Type_Id, string Category_Type, string Institution_Type_Id,
        string Institution_Type_Desc, string Institution_Description, string Current_Standard_Id, string Current_Standard_Desc, string Additional_Desc, string Board_Id, string Board_Desc, string Section_Id, string Section_Desc, string Year_of_Passing_ID,
        string Year_of_Passing_Desc, string Current_Year_Id, string Current_Year_Desc, string Student_Id, string Last_Course_Opted, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname,
        string Sechphone1, string Sechphone2, string Seclandline, string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity,
        string Secpincode, string SecContactDesc, int TotalMSmarks, int TotalMSmarksobt, string Sourcedesc, string dob, string Examination, string Location, string Expected_Joining_Acad_Year, string flag)
        {
            SqlParameter[] p = new SqlParameter[81];
            p[0] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[0].Value = CON_TITLE;
            p[1] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[1].Value = CON_FIRSTNAME;
            p[2] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[2].Value = CON_MNAME;
            p[3] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[3].Value = CON_LNAME;
            p[4] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[4].Value = Score;
            p[5] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[5].Value = percentile;
            p[6] = new SqlParameter("@Area_rank", SqlDbType.NVarChar);
            p[6].Value = Area_rank;
            p[7] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[7].Value = Overallrank;
            p[8] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[8].Value = Scorerange;
            p[9] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[9].Direction = ParameterDirection.Output;
            p[10] = new SqlParameter("@Lead_No", SqlDbType.NVarChar);
            p[10].Value = Lead_Code;

            p[11] = new SqlParameter("@Lead_Con_id", SqlDbType.NVarChar);
            p[11].Value = Lead_Contact_Code;
            p[12] = new SqlParameter("@contact_Source_company", SqlDbType.NVarChar);
            p[12].Value = Contact_Source_company;
            p[13] = new SqlParameter("@contact_Source_Division", SqlDbType.NVarChar);
            p[13].Value = Contact_Source_Division;
            p[14] = new SqlParameter("@contact_Source_Center", SqlDbType.NVarChar);
            p[14].Value = Contact_Source_Center;
            p[15] = new SqlParameter("@contact_Source_zone", SqlDbType.NVarChar);
            p[15].Value = Contact_Source_Zone;

            p[16] = new SqlParameter("@contact_assignto", SqlDbType.NVarChar);
            p[16].Value = Contact_assignto;
            p[17] = new SqlParameter("@Last_modified_by", SqlDbType.NVarChar);
            p[17].Value = last_modified_by;


            p[18] = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p[18].Value = Contact_Target_Company;
            p[19] = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p[19].Value = Contact_Target_Division;
            p[20] = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p[20].Value = Contact_Target_Zone;
            p[21] = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p[21].Value = Contact_Target_Center;

            p[22] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[22].Value = Handphone1;
            p[23] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[23].Value = handphone2;
            p[24] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[24].Value = landline;
            p[25] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[25].Value = emailid;
            p[26] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[26].Value = Flatno;
            p[27] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[27].Value = buildingname;
            p[28] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[28].Value = streetname;
            p[29] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[29].Value = Countryname;
            p[30] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[30].Value = State;
            p[31] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[31].Value = City;
            p[32] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[32].Value = pincode;

            p[33] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[33].Value = discipline_id;
            p[34] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[34].Value = Discipline_desc;
            p[35] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[35].Value = Field_Id;
            p[36] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[36].Value = Field_Desc;
            p[37] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[37].Value = Competitive_Exam;

            p[38] = new SqlParameter("@category_TYpe_id", SqlDbType.NVarChar);
            p[38].Value = Category_Type_Id;
            p[39] = new SqlParameter("@category_Type", SqlDbType.NVarChar);
            p[39].Value = Category_Type;
            p[40] = new SqlParameter("@Institution_Type_Id", SqlDbType.NVarChar);
            p[40].Value = Institution_Type_Id;
            p[41] = new SqlParameter("@Institution_Type_Desc", SqlDbType.NVarChar);
            p[41].Value = Institution_Type_Desc;
            p[42] = new SqlParameter("@Institution_Description", SqlDbType.NVarChar);
            p[42].Value = Institution_Description;
            p[43] = new SqlParameter("@Current_Standard_Id", SqlDbType.NVarChar);
            p[43].Value = Current_Standard_Id;
            p[44] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[44].Value = Current_Standard_Desc;
            p[45] = new SqlParameter("@Additional_Desc", SqlDbType.NVarChar);
            p[45].Value = Additional_Desc;
            p[46] = new SqlParameter("@Board_Id", SqlDbType.NVarChar);
            p[46].Value = Board_Id;
            p[47] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[47].Value = Board_Desc;
            p[48] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[48].Value = Section_Id;
            p[49] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[49].Value = Section_Desc;
            p[50] = new SqlParameter("@Year_of_Passing_ID", SqlDbType.NVarChar);
            p[50].Value = Year_of_Passing_ID;
            p[51] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[51].Value = Year_of_Passing_Desc;
            p[52] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[52].Value = Current_Year_Id;
            p[53] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[53].Value = Current_Year_Desc;
            p[54] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
            p[54].Value = Student_Id;
            p[55] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[55].Value = Last_Course_Opted;

            p[56] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[56].Value = SecContactType;
            p[57] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[57].Value = SecTitle;
            p[58] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[58].Value = Secfname;
            p[59] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[59].Value = SecMname;
            p[60] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[60].Value = SecLname;
            p[61] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[61].Value = Sechphone1;
            p[62] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[62].Value = Sechphone2;
            p[63] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[63].Value = Seclandline;
            p[64] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[64].Value = Secemail;
            p[65] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[65].Value = SecAdd1;
            p[66] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[66].Value = Secadd2;
            p[67] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[67].Value = SecStreetname;
            p[68] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[68].Value = SecCountryname;
            p[69] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[69].Value = SecState;
            p[70] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[70].Value = SecCity;
            p[71] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[71].Value = Secpincode;
            p[72] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[72].Value = SecContactDesc;
            p[73] = new SqlParameter("@total_ms_marks", SqlDbType.Int);
            p[73].Value = TotalMSmarks;
            p[74] = new SqlParameter("@total_ms_marks_obt", SqlDbType.Int);
            p[74].Value = TotalMSmarksobt;
            p[75] = new SqlParameter("@lead_Source_desc", SqlDbType.NVarChar);
            p[75].Value = Sourcedesc;
            p[76] = new SqlParameter("@dob", SqlDbType.NVarChar);
            p[76].Value = dob;
            p[77] = new SqlParameter("@last_exam", SqlDbType.NVarChar);
            p[77].Value = Examination;
            p[78] = new SqlParameter("@location", SqlDbType.NVarChar);
            p[78].Value = Location;
            p[79] = new SqlParameter("@Expected_Joining_Acad_Year", SqlDbType.NVarChar);
            p[79].Value = Expected_Joining_Acad_Year;
            p[80] = new SqlParameter("@flag", SqlDbType.NVarChar);
            p[80].Value = flag;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Lead_Contact", p));
            //SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Lead_Contact", p);
            //return (p[9].Value.ToString());
        }

        //29 jan 2016

        public static DataSet Get_Campaign_ContactbyRecordNo(int Flag, string RecNo)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@Record_No", SqlDbType.VarChar);
            p[1].Value = RecNo;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_getCampaign_contact_RecNo", p));
        }

        public static string InsertFeedback_Campaign_Contacts(string Feedbackid, string Taskid, string RecNoOrConID, string Interacted_With, string Interacted_Relation, string Interacted_On, string Feedback, string Feedback_Status, string Updatedby, string SeminarStatus,
        string NextFollowupdate, string Flag)
        {
            SqlParameter[] p = new SqlParameter[13];
            p[0] = new SqlParameter("@feedbackid", SqlDbType.NVarChar);
            p[0].Value = Feedbackid;
            p[1] = new SqlParameter("@task_id", SqlDbType.NVarChar);
            p[1].Value = Taskid;
            p[2] = new SqlParameter("@Id", SqlDbType.NVarChar);
            p[2].Value = RecNoOrConID;
            p[3] = new SqlParameter("@Interactedwith", SqlDbType.NVarChar);
            p[3].Value = Interacted_With;
            p[4] = new SqlParameter("@InteractedRelation", SqlDbType.NVarChar);
            p[4].Value = Interacted_Relation;
            p[5] = new SqlParameter("@Interacted_On", SqlDbType.NVarChar);
            p[5].Value = Interacted_On;
            p[6] = new SqlParameter("@feedback", SqlDbType.NVarChar);
            p[6].Value = Feedback;
            p[7] = new SqlParameter("@Feedback_Status", SqlDbType.NVarChar);
            p[7].Value = Feedback_Status;
            p[8] = new SqlParameter("@feedback_Out", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            p[9] = new SqlParameter("@Updated_By", SqlDbType.NVarChar);
            p[9].Value = Updatedby;
            p[10] = new SqlParameter("@SeminarStatus", SqlDbType.NVarChar);
            p[10].Value = SeminarStatus;
            p[11] = new SqlParameter("@NextFollowupDate", SqlDbType.NVarChar);
            p[11].Value = NextFollowupdate;
            p[12] = new SqlParameter("@Flag", SqlDbType.NVarChar);
            p[12].Value = Flag;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertCampaign_Conatcts_feedback", p);
            return (p[8].Value.ToString());
        }
        //30 Jan 2016

        public static DataSet GetAllContactCampaignfeedbackbyId(string ConidOrRecNo, string Flag)
        {
            SqlParameter P = new SqlParameter("@ConidOrRecNo", SqlDbType.NVarChar);
            P.Value = ConidOrRecNo;
            SqlParameter P1 = new SqlParameter("@Flag", SqlDbType.NVarChar);
            P1.Value = Flag;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllfeedbackbyConidOrCampaign", P, P1));
        }
        //1 Feb 2016
        public static DataSet Get_Campaign_Assigned_Student(int Flag, string Userid, string Campaign_Type, string Campaign_Id, string Con_Name, string Con_Handphone, string Institution_Name, string Page_Number)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Type", SqlDbType.VarChar);
            p2.Value = Campaign_Type;
            SqlParameter p3 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p3.Value = Campaign_Id;
            SqlParameter p4 = new SqlParameter("@Con_Name", SqlDbType.VarChar);
            p4.Value = Con_Name;
            SqlParameter p5 = new SqlParameter("@Con_Handphone", SqlDbType.VarChar);
            p5.Value = Con_Handphone;
            SqlParameter p6 = new SqlParameter("@Institution_Name", SqlDbType.VarChar);
            p6.Value = Institution_Name;
            SqlParameter p7 = new SqlParameter("@Page_Number", SqlDbType.VarChar);
            p7.Value = Page_Number;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Campaign_Assigned_Student", p, p1, p2, p3, p4, p5, p6, p7));
        }
        //01 Feb 2016 New
        public static string Insert_ConvertLeadTo_Opportunity(string Opportunity_id, string Opp_TYpe_Id, string Opp_Name, string Leadid, string Product_Category, string Product_Code, string Sales_Stage, System.DateTime Opp_Join_Date, System.DateTime Opp_Expected_Close_Date, string Opp_Probability_Percent,
           string Opp_Next_Step, decimal Opp_Value, decimal Opp_Disc, string Opp_Contact_Company, string Opp_Contact_Division, string Opp_Contact_Center, string Opp_Contact_Zone, string Opp_Contact_Role, string Opp_Contact_AssignTo, string Created_By,
           string last_Modified_By, string Opp_Status, string Opp_Status_id, string Oppor_product, string Oppor_Product_id, string Acad_Year, string App_no, string SalesChannel_Id, string SalesChannel, string Disc_remark, string Is_Branch_Topper, string Branch_Topper_Division,
           string Branch_Topper_Center, string Is_School_Ranker, string School_Name, string School_Division, string School_Rank, string Apply_Additional_Discount, string Discount_Type)
        {
            SqlParameter[] p = new SqlParameter[40];
            p[0] = new SqlParameter("@Oppur_Id", SqlDbType.NVarChar);
            p[0].Value = Opportunity_id;
            p[1] = new SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar);
            p[1].Value = Opp_TYpe_Id;
            p[2] = new SqlParameter("@Opp_Name", SqlDbType.NVarChar);
            p[2].Value = Opp_Name;
            p[3] = new SqlParameter("@Lead_Id", SqlDbType.NVarChar);
            p[3].Value = Leadid;
            p[4] = new SqlParameter("@Product_Category", SqlDbType.NVarChar);
            p[4].Value = Product_Category;
            p[5] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
            p[5].Value = Product_Code;
            p[6] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[6].Value = Sales_Stage;
            p[7] = new SqlParameter("@Opp_Join_Date", SqlDbType.DateTime);
            p[7].Value = Opp_Join_Date;

            p[8] = new SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime);
            p[8].Value = Opp_Expected_Close_Date;
            p[9] = new SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar);
            p[9].Value = Opp_Probability_Percent;
            p[10] = new SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar);
            p[10].Value = Opp_Next_Step;
            p[11] = new SqlParameter("@Opp_Value", SqlDbType.Decimal);
            p[11].Value = Opp_Value;
            p[12] = new SqlParameter("@Opp_Disc", SqlDbType.Decimal);
            p[12].Value = Opp_Disc;

            p[13] = new SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar);
            p[13].Value = Opp_Contact_Company;
            p[14] = new SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar);
            p[14].Value = Opp_Contact_Division;
            p[15] = new SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar);
            p[15].Value = Opp_Contact_Center;
            p[16] = new SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar);
            p[16].Value = Opp_Contact_Zone;

            p[17] = new SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar);
            p[17].Value = Opp_Contact_Role;
            p[18] = new SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar);
            p[18].Value = Opp_Contact_AssignTo;
            p[19] = new SqlParameter("@Created_By", SqlDbType.NVarChar);
            p[19].Value = Created_By;
            p[20] = new SqlParameter("@last_Modified_By", SqlDbType.NVarChar);
            p[20].Value = last_Modified_By;

            p[21] = new SqlParameter("@Opp_Status", SqlDbType.NVarChar);
            p[21].Value = Opp_Status;
            p[22] = new SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar);
            p[22].Value = Opp_Status_id;

            p[23] = new SqlParameter("@Oppor_Product", SqlDbType.NVarChar);
            p[23].Value = Oppor_product;
            p[24] = new SqlParameter("@Oppor_Product_Id", SqlDbType.VarChar, 50);
            p[24].Value = Oppor_Product_id;

            p[25] = new SqlParameter("@Oppor_Id_Out", SqlDbType.NVarChar, 100);
            p[25].Direction = ParameterDirection.Output;

            p[26] = new SqlParameter("@Acad_year", SqlDbType.NVarChar);
            p[26].Value = Acad_Year;
            p[27] = new SqlParameter("@App_no", SqlDbType.NVarChar);
            p[27].Value = App_no;

            p[28] = new SqlParameter("@SalesStage_Id", SqlDbType.NVarChar);
            p[28].Value = SalesChannel_Id;
            p[29] = new SqlParameter("@SalesStage_Desc", SqlDbType.NVarChar);
            p[29].Value = SalesChannel;

            p[30] = new SqlParameter("@Disc_Remark", SqlDbType.NVarChar);
            p[30].Value = Disc_remark;

            p[31] = new SqlParameter("@Is_Branch_Topper", SqlDbType.NVarChar);
            p[31].Value = Is_Branch_Topper;
            p[32] = new SqlParameter("@Branch_Topper_Division", SqlDbType.NVarChar);
            p[32].Value = Branch_Topper_Division;
            p[33] = new SqlParameter("@Branch_Topper_Center", SqlDbType.NVarChar);
            p[33].Value = Branch_Topper_Center;
            p[34] = new SqlParameter("@Is_School_Ranker", SqlDbType.NVarChar);
            p[34].Value = Is_School_Ranker;
            p[35] = new SqlParameter("@School_Name", SqlDbType.NVarChar);
            p[35].Value = School_Name;
            p[36] = new SqlParameter("@School_Division", SqlDbType.NVarChar);
            p[36].Value = School_Division;
            p[37] = new SqlParameter("@School_Rank", SqlDbType.NVarChar);
            p[37].Value = School_Rank;
            p[38] = new SqlParameter("@Apply_Additional_Discount", SqlDbType.NVarChar);
            p[38].Value = Apply_Additional_Discount;
            p[39] = new SqlParameter("@Discount_Type", SqlDbType.NVarChar);
            p[39].Value = Discount_Type;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ConvertLeadToOpportunity", p);
            return (p[25].Value.ToString());
        }

        //03 Feb 2016 New


        //4 feb 2016
        public static DataSet Insert_Contacts_Detail(string Con_Source_Id, string Con_Type_Id, string Con_Type_Desc, string Category_Type_Id, string Category_Type_Desc, string Con_Title, string Con_FName, string Con_MName, string Con_LName,
               string Con_Gender, string Con_DOB, string Con_Handphone1, string Con_Handphone2, string Con_Landline, string Con_Address1, string Con_Address2, string Con_Street, string Con_Country, string Con_State, string Con_City, string Con_Location, string Con_PostalCode,
               string Con_EmailId, string Institution_Type_Id, string Institution_Type_Desc, string Institution_Desc, string Board_Id, string Board_Desc, string Cur_Standard_Id, string Cur_Standard_Desc,
               string Section_Id, string Section_Desc, string YearOfPassing_Id, string YearOfPassing_Desc, string Aditional_Desc, string ExamName, string FinalMarksObt, string FinalMarksTotal, string Grade,
               string Percentage, string SecCon_Type, string SecCon_Title, string SecCon_FName, string SecCon_MName, string SecCon_LName, string SecCon_Handphone1, string SecCon_Handphone2,
               string SecCon_Landline, string SecCon_EmailId, string SecCon_Gender, string SecCon_Occupation, string SecCon_Organization, string SecCon_Designation, string SecCon_OfficePhone, string Created_By, string Flag,
               string Examid, string Examstatusid, string Examrank, string Schoolid)
        {
            SqlParameter p = new SqlParameter("@Con_Type_Id", SqlDbType.VarChar);
            p.Value = Con_Type_Id;
            SqlParameter p1 = new SqlParameter("@Con_Type_Desc", SqlDbType.VarChar);
            p1.Value = Con_Type_Desc;
            SqlParameter p2 = new SqlParameter("@Category_Type_Id", SqlDbType.VarChar);
            p2.Value = Category_Type_Id;
            SqlParameter p3 = new SqlParameter("@Category_Type_Desc", SqlDbType.VarChar);
            p3.Value = Category_Type_Desc;
            SqlParameter p4 = new SqlParameter("@Con_Title", SqlDbType.VarChar);
            p4.Value = Con_Title;
            SqlParameter p5 = new SqlParameter("@Con_FName", SqlDbType.VarChar);
            p5.Value = Con_FName;
            SqlParameter p6 = new SqlParameter("@Con_MName", SqlDbType.VarChar);
            p6.Value = Con_MName;
            SqlParameter p7 = new SqlParameter("@Con_LName", SqlDbType.VarChar);
            p7.Value = Con_LName;
            SqlParameter p8 = new SqlParameter("@Con_Gender", SqlDbType.VarChar);
            p8.Value = Con_Gender;
            SqlParameter p9 = new SqlParameter("@Con_DOB", SqlDbType.VarChar);
            p9.Value = Con_DOB;
            SqlParameter p10 = new SqlParameter("@Con_Handphone1", SqlDbType.VarChar);
            p10.Value = Con_Handphone1;
            SqlParameter p11 = new SqlParameter("@Con_Handphone2", SqlDbType.VarChar);
            p11.Value = Con_Handphone2;
            SqlParameter p12 = new SqlParameter("@Con_Landline", SqlDbType.VarChar);
            p12.Value = Con_Landline;
            SqlParameter p13 = new SqlParameter("@Con_Address1", SqlDbType.VarChar);
            p13.Value = Con_Address1;
            SqlParameter p14 = new SqlParameter("@Con_Address2", SqlDbType.VarChar);
            p14.Value = Con_Address2;
            SqlParameter p15 = new SqlParameter("@Con_Street", SqlDbType.VarChar);
            p15.Value = Con_Street;
            SqlParameter p16 = new SqlParameter("@Con_Country", SqlDbType.VarChar);
            p16.Value = Con_Country;
            SqlParameter p17 = new SqlParameter("@Con_State", SqlDbType.VarChar);
            p17.Value = Con_State;
            SqlParameter p18 = new SqlParameter("@Con_City", SqlDbType.VarChar);
            p18.Value = Con_City;
            SqlParameter p19 = new SqlParameter("@Con_PostalCode", SqlDbType.VarChar);
            p19.Value = Con_PostalCode;
            SqlParameter p20 = new SqlParameter("@Con_EmailId", SqlDbType.VarChar);
            p20.Value = Con_EmailId;
            //Acad Info Parameters
            SqlParameter p21 = new SqlParameter("@Institution_Type_Id", SqlDbType.VarChar);
            p21.Value = Institution_Type_Id;
            SqlParameter p22 = new SqlParameter("@Institution_Type_Desc", SqlDbType.VarChar);
            p22.Value = Institution_Type_Desc;
            SqlParameter p23 = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            p23.Value = Board_Id;
            SqlParameter p24 = new SqlParameter("@Board_Desc", SqlDbType.VarChar);
            p24.Value = Board_Desc;
            SqlParameter p25 = new SqlParameter("@Cur_Standard_Id", SqlDbType.VarChar);
            p25.Value = Cur_Standard_Id;
            SqlParameter p26 = new SqlParameter("@Cur_Standard_Desc", SqlDbType.VarChar);
            p26.Value = Cur_Standard_Desc;
            SqlParameter p27 = new SqlParameter("@Section_Id", SqlDbType.VarChar);
            p27.Value = Section_Id;
            SqlParameter p28 = new SqlParameter("@Section_Desc", SqlDbType.VarChar);
            p28.Value = Section_Desc;
            SqlParameter p29 = new SqlParameter("@YearOfPassing_Id", SqlDbType.VarChar);
            p29.Value = YearOfPassing_Id;
            SqlParameter p30 = new SqlParameter("@YearOfPassing_Desc", SqlDbType.VarChar);
            p30.Value = YearOfPassing_Desc;
            SqlParameter p31 = new SqlParameter("@Aditional_Desc", SqlDbType.VarChar);
            p31.Value = Aditional_Desc;
            SqlParameter p32 = new SqlParameter("@ExamName", SqlDbType.VarChar);
            p32.Value = ExamName;
            SqlParameter p33 = new SqlParameter("@FinalMarksObt", SqlDbType.VarChar);
            p33.Value = FinalMarksObt;
            SqlParameter p34 = new SqlParameter("@FinalMarksTotal", SqlDbType.VarChar);
            p34.Value = FinalMarksTotal;
            SqlParameter p35 = new SqlParameter("@Grade", SqlDbType.VarChar);
            p35.Value = Grade;
            SqlParameter p36 = new SqlParameter("@Percentage", SqlDbType.VarChar);
            p36.Value = Percentage;
            //Secondory Contact Parameter
            SqlParameter p37 = new SqlParameter("@SecCon_Type", SqlDbType.VarChar);
            p37.Value = SecCon_Type;
            SqlParameter p38 = new SqlParameter("@SecCon_Title", SqlDbType.VarChar);
            p38.Value = SecCon_Title;
            SqlParameter p39 = new SqlParameter("@SecCon_FName", SqlDbType.VarChar);
            p39.Value = SecCon_FName;
            SqlParameter p40 = new SqlParameter("@SecCon_MName", SqlDbType.VarChar);
            p40.Value = SecCon_MName;
            SqlParameter p41 = new SqlParameter("@SecCon_LName", SqlDbType.VarChar);
            p41.Value = SecCon_LName;
            SqlParameter p42 = new SqlParameter("@SecCon_Handphone1", SqlDbType.VarChar);
            p42.Value = SecCon_Handphone1;
            SqlParameter p43 = new SqlParameter("@SecCon_Handphone2", SqlDbType.VarChar);
            p43.Value = SecCon_Handphone2;
            SqlParameter p44 = new SqlParameter("@SecCon_Landline", SqlDbType.VarChar);
            p44.Value = SecCon_Landline;
            SqlParameter p45 = new SqlParameter("@SecCon_EmailId", SqlDbType.VarChar);
            p45.Value = SecCon_EmailId;
            SqlParameter p46 = new SqlParameter("@SecCon_Gender", SqlDbType.VarChar);
            p46.Value = SecCon_Gender;
            SqlParameter p47 = new SqlParameter("@SecCon_Occupation", SqlDbType.VarChar);
            p47.Value = SecCon_Occupation;
            SqlParameter p48 = new SqlParameter("@SecCon_Organization", SqlDbType.VarChar);
            p48.Value = SecCon_Organization;
            SqlParameter p49 = new SqlParameter("@SecCon_Designation", SqlDbType.VarChar);
            p49.Value = SecCon_Designation;
            SqlParameter p50 = new SqlParameter("@SecCon_OfficePhone", SqlDbType.VarChar);
            p50.Value = SecCon_OfficePhone;
            SqlParameter p51 = new SqlParameter("@Created_By", SqlDbType.VarChar);
            p51.Value = Created_By;
            SqlParameter p52 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p52.Value = Flag;
            SqlParameter p53 = new SqlParameter("@Institution_Desc", SqlDbType.VarChar);
            p53.Value = Institution_Desc;
            SqlParameter p54 = new SqlParameter("@Con_Location", SqlDbType.VarChar);
            p54.Value = Con_Location;
            SqlParameter p55 = new SqlParameter("@Con_Source_Id", SqlDbType.VarChar);
            p55.Value = Con_Source_Id;

            SqlParameter p56 = new SqlParameter("@Exam_Id", SqlDbType.VarChar);
            p56.Value = Examid;
            SqlParameter p57 = new SqlParameter("@Exam_Status_id", SqlDbType.VarChar);
            p57.Value = Examstatusid;
            SqlParameter p58 = new SqlParameter("@Exam_Rank", SqlDbType.VarChar);
            p58.Value = Examrank;
            SqlParameter p59 = new SqlParameter("@School_Id", SqlDbType.VarChar);
            p59.Value = Schoolid;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Contacts_Detail", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35, p36, p37, p38, p39, p40, p41, p42, p43, p44, p45, p46, p47, p48, p49, p50, p51, p52, p53, p54, p55, p56, p57, p58, p59));
        }




        public static DataSet Insert_Update_Contact_Detail_New(string Con_Source_Id, string Con_Type_Id, string Con_Type_Desc, string Category_Type_Id, string Category_Type_Desc, string Con_Title, string Con_FName, string Con_MName, string Con_LName,
                string Con_Gender, string Con_DOB, string Con_Handphone1, string Con_Handphone2, string Con_Landline, string Con_Address1, string Con_Address2, string Con_Street, string Con_Country, string Con_State, string Con_City, string Con_Location, string Con_PostalCode,
                string Con_EmailId, string CON_ID, string Created_By, string Flag)
        {
            SqlParameter p = new SqlParameter("@Con_Type_Id", SqlDbType.VarChar);
            p.Value = Con_Type_Id;
            SqlParameter p1 = new SqlParameter("@Con_Type_Desc", SqlDbType.VarChar);
            p1.Value = Con_Type_Desc;
            SqlParameter p2 = new SqlParameter("@Category_Type_Id", SqlDbType.VarChar);
            p2.Value = Category_Type_Id;
            SqlParameter p3 = new SqlParameter("@Category_Type_Desc", SqlDbType.VarChar);
            p3.Value = Category_Type_Desc;
            SqlParameter p4 = new SqlParameter("@Con_Title", SqlDbType.VarChar);
            p4.Value = Con_Title;
            SqlParameter p5 = new SqlParameter("@Con_FName", SqlDbType.VarChar);
            p5.Value = Con_FName;
            SqlParameter p6 = new SqlParameter("@Con_MName", SqlDbType.VarChar);
            p6.Value = Con_MName;
            SqlParameter p7 = new SqlParameter("@Con_LName", SqlDbType.VarChar);
            p7.Value = Con_LName;
            SqlParameter p8 = new SqlParameter("@Con_Gender", SqlDbType.VarChar);
            p8.Value = Con_Gender;
            SqlParameter p9 = new SqlParameter("@Con_DOB", SqlDbType.VarChar);
            p9.Value = Con_DOB;
            SqlParameter p10 = new SqlParameter("@Con_Handphone1", SqlDbType.VarChar);
            p10.Value = Con_Handphone1;
            SqlParameter p11 = new SqlParameter("@Con_Handphone2", SqlDbType.VarChar);
            p11.Value = Con_Handphone2;
            SqlParameter p12 = new SqlParameter("@Con_Landline", SqlDbType.VarChar);
            p12.Value = Con_Landline;
            SqlParameter p13 = new SqlParameter("@Con_Address1", SqlDbType.VarChar);
            p13.Value = Con_Address1;
            SqlParameter p14 = new SqlParameter("@Con_Address2", SqlDbType.VarChar);
            p14.Value = Con_Address2;
            SqlParameter p15 = new SqlParameter("@Con_Street", SqlDbType.VarChar);
            p15.Value = Con_Street;
            SqlParameter p16 = new SqlParameter("@Con_Country", SqlDbType.VarChar);
            p16.Value = Con_Country;
            SqlParameter p17 = new SqlParameter("@Con_State", SqlDbType.VarChar);
            p17.Value = Con_State;
            SqlParameter p18 = new SqlParameter("@Con_City", SqlDbType.VarChar);
            p18.Value = Con_City;
            SqlParameter p19 = new SqlParameter("@Con_PostalCode", SqlDbType.VarChar);
            p19.Value = Con_PostalCode;
            SqlParameter p20 = new SqlParameter("@Con_EmailId", SqlDbType.VarChar);
            p20.Value = Con_EmailId;
            SqlParameter p21 = new SqlParameter("@CON_ID", SqlDbType.VarChar);
            p21.Value = CON_ID;
            SqlParameter p22 = new SqlParameter("@Created_By", SqlDbType.VarChar);
            p22.Value = Created_By;
            SqlParameter p23 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p23.Value = Flag;
            SqlParameter p24 = new SqlParameter("@Con_Location", SqlDbType.VarChar);
            p24.Value = Con_Location;
            SqlParameter p25 = new SqlParameter("@Con_Source_Id", SqlDbType.VarChar);
            p25.Value = Con_Source_Id;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Update_Conatct_Detail", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25));
        }

        //05 Feb 2016
        public static DataSet Insert_Update_Calling_Info(int Flag, string Mode_ID, string Mode_Name, string Phase, string Feedback_ID, string Contact_Type_ID_Called, string Contact_Number_Called, string Contact_Id, string Lead_Opportunity_ID, string Lead_Name,
                   string Campaign_Id, string Campaign_Name, string Process_Id, string Process_Name, string User_Id, string CRUD, string Recording_Link, string LegType, string SNUD, string OTUD, string Agent_User_Extension_Used, string TXST, string MOC,
                   string Call_Start_Time, string Call_End_Time, string Total_Call_Duration, string Call_Status)
        {
            SqlParameter[] p = new SqlParameter[27];
            p[0] = new SqlParameter("@flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@Mode_ID", SqlDbType.VarChar);
            p[1].Value = Mode_ID;
            p[2] = new SqlParameter("@Mode_Name", SqlDbType.VarChar);
            p[2].Value = Mode_Name;
            p[3] = new SqlParameter("@Phase", SqlDbType.VarChar);
            p[3].Value = Phase;
            p[4] = new SqlParameter("@Feedback_ID", SqlDbType.VarChar);
            p[4].Value = Feedback_ID;
            p[5] = new SqlParameter("@Contact_Type_ID_Called", SqlDbType.VarChar);
            p[5].Value = Contact_Type_ID_Called;
            p[6] = new SqlParameter("@Contact_Number_Called", SqlDbType.VarChar);
            p[6].Value = Contact_Number_Called;
            p[7] = new SqlParameter("@Contact_Id", SqlDbType.VarChar);
            p[7].Value = Contact_Id;
            p[8] = new SqlParameter("@Lead_Opportunity_ID", SqlDbType.VarChar);
            p[8].Value = Lead_Opportunity_ID;
            p[9] = new SqlParameter("@Lead_Name ", SqlDbType.VarChar);
            p[9].Value = Lead_Name;
            p[10] = new SqlParameter("@Campaign_Id ", SqlDbType.VarChar);
            p[10].Value = Campaign_Id;
            p[11] = new SqlParameter("@Campaign_Name ", SqlDbType.VarChar);
            p[11].Value = Campaign_Name;
            p[12] = new SqlParameter("@Process_Id ", SqlDbType.VarChar);
            p[12].Value = Process_Id;
            p[13] = new SqlParameter("@Process_Name ", SqlDbType.VarChar);
            p[13].Value = Process_Name;
            p[14] = new SqlParameter("@User_Id ", SqlDbType.VarChar);
            p[14].Value = User_Id;
            p[15] = new SqlParameter("@CRUD ", SqlDbType.VarChar);
            p[15].Value = CRUD;
            p[16] = new SqlParameter("@Recording_Link ", SqlDbType.VarChar);
            p[16].Value = Recording_Link;
            p[17] = new SqlParameter("@LegType ", SqlDbType.VarChar);
            p[17].Value = LegType;
            p[18] = new SqlParameter("@SNUD ", SqlDbType.VarChar);
            p[18].Value = SNUD;
            p[19] = new SqlParameter("@OTUD ", SqlDbType.VarChar);
            p[19].Value = OTUD;
            p[20] = new SqlParameter("@Agent_User_Extension_Used ", SqlDbType.VarChar);
            p[20].Value = Agent_User_Extension_Used;
            p[21] = new SqlParameter("@TXST ", SqlDbType.VarChar);
            p[21].Value = TXST;
            p[22] = new SqlParameter("@MOC ", SqlDbType.VarChar);
            p[22].Value = MOC;
            p[23] = new SqlParameter("@Call_Start_Time ", SqlDbType.VarChar);
            p[23].Value = Call_Start_Time;
            p[24] = new SqlParameter("@Call_End_Time ", SqlDbType.VarChar);
            p[24].Value = Call_End_Time;
            p[25] = new SqlParameter("@Total_Call_Duration ", SqlDbType.VarChar);
            p[25].Value = Total_Call_Duration;
            p[26] = new SqlParameter("@Call_Status ", SqlDbType.VarChar);
            p[26].Value = Call_Status;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_CallingLogDetail", p));
        }



        //6 Feb 2016
        public static DataSet Get_Lead_Contact_Search_Results_New(string leadtypeid, string leadstatusid, string leadsourceid, string Userid, string Contact_Company, string Contact_Source_Division, string Contact_Source_Zone, string Contact_Source_Center, string Contact_Target_Division, string Contact_Target_Zone,
        string Contact_Target_Center, string Studentname, string Leadcreatedonfrom, string Leadcreatedonto, string Country, string State, string City, string Customertype, string Institutiontype, string Board,
        string Standard, string Year, string Courseinterested, string Followupfrom, string Followupto, int Overdue, string agefrom, string ageto, string Blocked, string Examinationdetails,
        string Scoretype, string Conditiontype, string Score, string Gender, string acadyear, string yeareducation, string Handphone1)
        {
            SqlParameter p = new SqlParameter("@Leadtypeid", SqlDbType.NVarChar);
            p.Value = leadtypeid;
            SqlParameter p1 = new SqlParameter("@leadsourceid", SqlDbType.NVarChar);
            p1.Value = leadsourceid;
            SqlParameter p2 = new SqlParameter("@leadstatusid", SqlDbType.NVarChar);
            p2.Value = leadstatusid;
            SqlParameter p3 = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p3.Value = Userid;
            SqlParameter p4 = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p4.Value = Contact_Company;
            SqlParameter p5 = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p5.Value = Contact_Source_Division;
            SqlParameter p6 = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p6.Value = Contact_Source_Zone;
            SqlParameter p7 = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p7.Value = Contact_Source_Center;
            SqlParameter p8 = new SqlParameter("@Contact_Source_Division", SqlDbType.NVarChar);
            p8.Value = Contact_Target_Division;
            SqlParameter p9 = new SqlParameter("@Contact_Source_Zone", SqlDbType.NVarChar);
            p9.Value = Contact_Target_Zone;
            SqlParameter p10 = new SqlParameter("@Contact_Source_Center", SqlDbType.NVarChar);
            p10.Value = Contact_Target_Center;
            SqlParameter p11 = new SqlParameter("@Studentname", SqlDbType.NVarChar);
            p11.Value = Studentname;

            SqlParameter p12 = new SqlParameter("@leadcreatedon_from", SqlDbType.NVarChar);
            p12.Value = Leadcreatedonfrom;
            SqlParameter p13 = new SqlParameter("@leadcreatedon_to", SqlDbType.NVarChar);
            p13.Value = Leadcreatedonto;
            SqlParameter p14 = new SqlParameter("@country", SqlDbType.NVarChar);
            p14.Value = Country;
            SqlParameter p15 = new SqlParameter("@state", SqlDbType.NVarChar);
            p15.Value = State;
            SqlParameter p16 = new SqlParameter("@city", SqlDbType.NVarChar);
            p16.Value = City;
            SqlParameter p17 = new SqlParameter("@customertype", SqlDbType.NVarChar);
            p17.Value = Customertype;
            SqlParameter p18 = new SqlParameter("@institutiontype", SqlDbType.NVarChar);
            p18.Value = Institutiontype;
            SqlParameter p19 = new SqlParameter("@board", SqlDbType.NVarChar);
            p19.Value = Board;
            SqlParameter p20 = new SqlParameter("@standard", SqlDbType.NVarChar);
            p20.Value = Standard;
            SqlParameter p21 = new SqlParameter("@year", SqlDbType.NVarChar);
            p21.Value = Year;

            SqlParameter p22 = new SqlParameter("@course_interest", SqlDbType.NVarChar);
            p22.Value = Courseinterested;
            SqlParameter p23 = new SqlParameter("@followup_from", SqlDbType.NVarChar);
            p23.Value = Followupfrom;
            SqlParameter p24 = new SqlParameter("@followup_to", SqlDbType.NVarChar);
            p24.Value = Followupto;
            SqlParameter p25 = new SqlParameter("@overdue", SqlDbType.Int);
            p25.Value = Overdue;

            SqlParameter p26 = new SqlParameter("@agefrom", SqlDbType.NVarChar);
            p26.Value = agefrom;
            SqlParameter p27 = new SqlParameter("@ageto", SqlDbType.NVarChar);
            p27.Value = ageto;
            SqlParameter p28 = new SqlParameter("@blocked", SqlDbType.NVarChar);
            p28.Value = Blocked;
            SqlParameter p29 = new SqlParameter("@xam_details", SqlDbType.NVarChar);
            p29.Value = Examinationdetails;

            SqlParameter p30 = new SqlParameter("@scoretype", SqlDbType.NVarChar);
            p30.Value = Scoretype;
            SqlParameter p31 = new SqlParameter("@condition", SqlDbType.NVarChar);
            p31.Value = Conditiontype;
            SqlParameter p32 = new SqlParameter("@score", SqlDbType.NVarChar);
            p32.Value = Score;
            SqlParameter p33 = new SqlParameter("@gender", SqlDbType.NVarChar);
            p33.Value = Gender;
            SqlParameter p34 = new SqlParameter("@acadyear", SqlDbType.NVarChar);
            p34.Value = acadyear;
            SqlParameter p35 = new SqlParameter("@yeareducation", SqlDbType.NVarChar);
            p35.Value = yeareducation;
            SqlParameter p36 = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p36.Value = Handphone1;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_Contact_Search_Results_New", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
            p17, p18, p19, p20, p21, p22, p23, p24, p25, p26,
            p27, p28, p29, p30, p31, p32, p33, p34, p35, p36));
        }

        public static DataSet UpdateManualLeadContact_New(string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank, int Overallrank, string Scorerange, string Handphone1,
        string handphone2, string landline, string emailid, string Flatno, string buildingname, string streetname, string Countryname, string State, string City, string pincode,
        string Lead_Code, string Lead_Contact_Code, string Contact_Source_company, string Contact_Source_Division, string Contact_Source_Center, string Contact_Source_Zone, string Contact_assignto, string last_modified_by, string Contact_Target_Company, string Contact_Target_Division,
        string Contact_Target_Zone, string Contact_Target_Center, int discipline_id, string Discipline_desc, int Field_Id, string Field_Desc, string Competitive_Exam, string Category_Type_Id, string Category_Type, string Institution_Type_Id,
        string Institution_Type_Desc, string Institution_Description, string Current_Standard_Id, string Current_Standard_Desc, string Additional_Desc, string Board_Id, string Board_Desc, string Section_Id, string Section_Desc, string Year_of_Passing_ID,
        string Year_of_Passing_Desc, string Current_Year_Id, string Current_Year_Desc, string Student_Id, string Last_Course_Opted, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname,
        string Sechphone1, string Sechphone2, string Seclandline, string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity,
        string Secpincode, string SecContactDesc, int TotalMSmarks, int TotalMSmarksobt, string Sourcedesc, string dob, string Examination, string Location, string Expected_Joining_Acad_Year, string Productinterested, string flag)
        {
            SqlParameter[] p = new SqlParameter[82];
            p[0] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[0].Value = CON_TITLE;
            p[1] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[1].Value = CON_FIRSTNAME;
            p[2] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[2].Value = CON_MNAME;
            p[3] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[3].Value = CON_LNAME;
            p[4] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[4].Value = Score;
            p[5] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[5].Value = percentile;
            p[6] = new SqlParameter("@Area_rank", SqlDbType.NVarChar);
            p[6].Value = Area_rank;
            p[7] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[7].Value = Overallrank;
            p[8] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[8].Value = Scorerange;
            p[9] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[9].Direction = ParameterDirection.Output;
            p[10] = new SqlParameter("@Lead_No", SqlDbType.NVarChar);
            p[10].Value = Lead_Code;

            p[11] = new SqlParameter("@Lead_Con_id", SqlDbType.NVarChar);
            p[11].Value = Lead_Contact_Code;
            p[12] = new SqlParameter("@contact_Source_company", SqlDbType.NVarChar);
            p[12].Value = Contact_Source_company;
            p[13] = new SqlParameter("@contact_Source_Division", SqlDbType.NVarChar);
            p[13].Value = Contact_Source_Division;
            p[14] = new SqlParameter("@contact_Source_Center", SqlDbType.NVarChar);
            p[14].Value = Contact_Source_Center;
            p[15] = new SqlParameter("@contact_Source_zone", SqlDbType.NVarChar);
            p[15].Value = Contact_Source_Zone;

            p[16] = new SqlParameter("@contact_assignto", SqlDbType.NVarChar);
            p[16].Value = Contact_assignto;
            p[17] = new SqlParameter("@Last_modified_by", SqlDbType.NVarChar);
            p[17].Value = last_modified_by;


            p[18] = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p[18].Value = Contact_Target_Company;
            p[19] = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p[19].Value = Contact_Target_Division;
            p[20] = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p[20].Value = Contact_Target_Zone;
            p[21] = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p[21].Value = Contact_Target_Center;

            p[22] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[22].Value = Handphone1;
            p[23] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[23].Value = handphone2;
            p[24] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[24].Value = landline;
            p[25] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[25].Value = emailid;
            p[26] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[26].Value = Flatno;
            p[27] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[27].Value = buildingname;
            p[28] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[28].Value = streetname;
            p[29] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[29].Value = Countryname;
            p[30] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[30].Value = State;
            p[31] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[31].Value = City;
            p[32] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[32].Value = pincode;

            p[33] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[33].Value = discipline_id;
            p[34] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[34].Value = Discipline_desc;
            p[35] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[35].Value = Field_Id;
            p[36] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[36].Value = Field_Desc;
            p[37] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[37].Value = Competitive_Exam;

            p[38] = new SqlParameter("@category_TYpe_id", SqlDbType.NVarChar);
            p[38].Value = Category_Type_Id;
            p[39] = new SqlParameter("@category_Type", SqlDbType.NVarChar);
            p[39].Value = Category_Type;
            p[40] = new SqlParameter("@Institution_Type_Id", SqlDbType.NVarChar);
            p[40].Value = Institution_Type_Id;
            p[41] = new SqlParameter("@Institution_Type_Desc", SqlDbType.NVarChar);
            p[41].Value = Institution_Type_Desc;
            p[42] = new SqlParameter("@Institution_Description", SqlDbType.NVarChar);
            p[42].Value = Institution_Description;
            p[43] = new SqlParameter("@Current_Standard_Id", SqlDbType.NVarChar);
            p[43].Value = Current_Standard_Id;
            p[44] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[44].Value = Current_Standard_Desc;
            p[45] = new SqlParameter("@Additional_Desc", SqlDbType.NVarChar);
            p[45].Value = Additional_Desc;
            p[46] = new SqlParameter("@Board_Id", SqlDbType.NVarChar);
            p[46].Value = Board_Id;
            p[47] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[47].Value = Board_Desc;
            p[48] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[48].Value = Section_Id;
            p[49] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[49].Value = Section_Desc;
            p[50] = new SqlParameter("@Year_of_Passing_ID", SqlDbType.NVarChar);
            p[50].Value = Year_of_Passing_ID;
            p[51] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[51].Value = Year_of_Passing_Desc;
            p[52] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[52].Value = Current_Year_Id;
            p[53] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[53].Value = Current_Year_Desc;
            p[54] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
            p[54].Value = Student_Id;
            p[55] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[55].Value = Last_Course_Opted;

            p[56] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[56].Value = SecContactType;
            p[57] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[57].Value = SecTitle;
            p[58] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[58].Value = Secfname;
            p[59] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[59].Value = SecMname;
            p[60] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[60].Value = SecLname;
            p[61] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[61].Value = Sechphone1;
            p[62] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[62].Value = Sechphone2;
            p[63] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[63].Value = Seclandline;
            p[64] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[64].Value = Secemail;
            p[65] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[65].Value = SecAdd1;
            p[66] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[66].Value = Secadd2;
            p[67] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[67].Value = SecStreetname;
            p[68] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[68].Value = SecCountryname;
            p[69] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[69].Value = SecState;
            p[70] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[70].Value = SecCity;
            p[71] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[71].Value = Secpincode;
            p[72] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[72].Value = SecContactDesc;
            p[73] = new SqlParameter("@total_ms_marks", SqlDbType.Int);
            p[73].Value = TotalMSmarks;
            p[74] = new SqlParameter("@total_ms_marks_obt", SqlDbType.Int);
            p[74].Value = TotalMSmarksobt;
            p[75] = new SqlParameter("@lead_Source_desc", SqlDbType.NVarChar);
            p[75].Value = Sourcedesc;
            p[76] = new SqlParameter("@dob", SqlDbType.NVarChar);
            p[76].Value = dob;
            p[77] = new SqlParameter("@last_exam", SqlDbType.NVarChar);
            p[77].Value = Examination;
            p[78] = new SqlParameter("@location", SqlDbType.NVarChar);
            p[78].Value = Location;
            p[79] = new SqlParameter("@Expected_Joining_Acad_Year", SqlDbType.NVarChar);
            p[79].Value = Expected_Joining_Acad_Year;
            p[80] = new SqlParameter("@flag", SqlDbType.NVarChar);
            p[80].Value = flag;
            p[81] = new SqlParameter("@Productinterested", SqlDbType.NVarChar);
            p[81].Value = Productinterested;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Lead_Contact", p));
            //SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Lead_Contact", p);
            //return (p[9].Value.ToString());
        }

        public static DataSet Campaign_RemoveOrReassignContactsToUser(int Flag, string Userid, string Campaign_Id, string Assigned_User_Id, string ReAssigned_User_Id, string Contacts_Id, string PKeyRecordID)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p2.Value = Campaign_Id;
            SqlParameter p3 = new SqlParameter("@Assigned_User_Id", SqlDbType.VarChar);
            p3.Value = Assigned_User_Id;
            SqlParameter p4 = new SqlParameter("@ReAssigned_User_Id", SqlDbType.VarChar);
            p4.Value = ReAssigned_User_Id;
            SqlParameter p5 = new SqlParameter("@Contacts_Id", SqlDbType.VarChar);
            p5.Value = Contacts_Id;
            SqlParameter p6 = new SqlParameter("@PKeyRecordID ", SqlDbType.VarChar);
            p6.Value = PKeyRecordID;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_RemoveOrReassignContactsToUser", p, p1, p2, p3, p4, p5, p6));
        }

        public static DataSet Insert_Update_EComSales_Order(string Flag, string Opp_Id, string Order_No, string Order_Date, string Order_Time, string Product_Name, string CurrentStatusOfOrder, string Amount, string Remarks, string Created_By)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Opp_Id", SqlDbType.VarChar);
            p1.Value = Opp_Id;
            SqlParameter p2 = new SqlParameter("@Order_No", SqlDbType.VarChar);
            p2.Value = Order_No;
            SqlParameter p3 = new SqlParameter("@Order_Date", SqlDbType.VarChar);
            p3.Value = Order_Date;
            SqlParameter p4 = new SqlParameter("@Order_Time", SqlDbType.VarChar);
            p4.Value = Order_Time;
            SqlParameter p5 = new SqlParameter("@Product_Name", SqlDbType.VarChar);
            p5.Value = Product_Name;
            SqlParameter p6 = new SqlParameter("@CurrentStatusOfOrder", SqlDbType.VarChar);
            p6.Value = CurrentStatusOfOrder;
            SqlParameter p7 = new SqlParameter("@Amount", SqlDbType.VarChar);
            p7.Value = Amount;
            SqlParameter p8 = new SqlParameter("@Remarks", SqlDbType.VarChar);
            p8.Value = Remarks;
            SqlParameter p9 = new SqlParameter("@Created_By", SqlDbType.VarChar);
            p9.Value = Created_By;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_ECom_Sales", p, p1, p2, p3, p4, p5, p6, p7, p8, p9));
        }

        //26th Feb 2016
        public static DataSet Get_EComSales_AppNo(int Flag)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_EComSale_AppNo", p));
        }

        //29 feb 2016

        //public static DataSet Insert_Contacts_ExcelUpload(string RowNum, string ContactSource, string ContactTitle, string ContactFirstName, string ContactMidName, string ContactLastName, string Gender, string EmailID, string Handphone1,
        //        string Country, string Created_By, string ExcelName, string TotalRecord, string Flag)
        //{
        //    SqlParameter p = new SqlParameter("@RowNum", RowNum);
        //    SqlParameter p1 = new SqlParameter("@ContactSource", ContactSource);
        //    SqlParameter p2 = new SqlParameter("@ContactTitle", ContactTitle);
        //    SqlParameter p3 = new SqlParameter("@ContactFirstName", ContactFirstName);
        //    SqlParameter p4 = new SqlParameter("@ContactMidName", ContactMidName);
        //    SqlParameter p5 = new SqlParameter("@ContactLastName", ContactLastName);
        //    SqlParameter p6 = new SqlParameter("@Gender", Gender);
        //    SqlParameter p7 = new SqlParameter("@EmailID", EmailID);
        //    SqlParameter p8 = new SqlParameter("@Handphone1", Handphone1);
        //    SqlParameter p9 = new SqlParameter("@Country", Country);
        //    SqlParameter p10 = new SqlParameter("@Created_By", Created_By);
        //    SqlParameter p11 = new SqlParameter("@ExcelName", ExcelName);
        //    SqlParameter p12 = new SqlParameter("@TotalRecord", TotalRecord);
        //    SqlParameter p13 = new SqlParameter("@flag", Flag);

        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Contacts_ExcelUpload", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));
        //}

        public static DataSet Insert_Contacts_ExcelUpload(string xmlData, string Created_By, string ExcelName, string TotalRecord, string Flag)
        {
            SqlParameter p = new SqlParameter("@xmlData", xmlData);
            SqlParameter p1 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p2 = new SqlParameter("@ExcelName", ExcelName);
            SqlParameter p3 = new SqlParameter("@TotalRecord", TotalRecord);
            SqlParameter p4 = new SqlParameter("@flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Contacts_ExcelUpload", p, p1, p2, p3, p4));
        }

        public static DataSet Get_Contacts_ExcelUploadFlag(string ExcelName, string Flag)
        {
            SqlParameter p = new SqlParameter("@ExcelName", ExcelName);
            SqlParameter p1 = new SqlParameter("@flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Contacts_ExcelUploadFlag", p, p1));
        }

        public static DataSet GetDashboardValues_TM_DivisionWise(int Flag, string Year, string Divisioncode, string ZoneCode, string CenterCode)
        {
            SqlParameter P1 = new SqlParameter("@Flag", SqlDbType.Int);
            P1.Value = Flag;
            SqlParameter P2 = new SqlParameter("@Year", SqlDbType.VarChar);
            P2.Value = Year;
            SqlParameter P3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            P3.Value = Divisioncode;
            SqlParameter P4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            P4.Value = ZoneCode;
            SqlParameter P5 = new SqlParameter("@CenterCode", SqlDbType.VarChar);
            P5.Value = CenterCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_DASHBOARD_TM_DivisionWise", P1, P2, P3, P4, P5));
        }

        public static DataSet GetDashboardValues_Centers(int Flag, string Year, string Divisioncode, string ZoneCode, string CenterCode)
        {
            SqlParameter P1 = new SqlParameter("@Flag", SqlDbType.Int);
            P1.Value = Flag;
            SqlParameter P2 = new SqlParameter("@Year", SqlDbType.VarChar);
            P2.Value = Year;
            SqlParameter P3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            P3.Value = Divisioncode;
            SqlParameter P4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            P4.Value = ZoneCode;
            SqlParameter P5 = new SqlParameter("@CenterCode", SqlDbType.VarChar);
            P5.Value = CenterCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_DASHBOARD_CENTERS", P1, P2, P3, P4, P5));
        }

        public static DataSet GetDashboardValues_TM(string Userid, int Flag, string Year, string DivisionCode, string ZoneCode)
        {
            SqlParameter P = new SqlParameter("@Userid", SqlDbType.NVarChar);
            P.Value = Userid;
            SqlParameter P1 = new SqlParameter("@Flag", SqlDbType.Int);
            P1.Value = Flag;
            SqlParameter P2 = new SqlParameter("@Year", SqlDbType.VarChar);
            P2.Value = Year;
            SqlParameter P3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            P3.Value = DivisionCode;
            SqlParameter P4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            P4.Value = ZoneCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_DASHBOARD_TM", P, P1, P2, P3, P4));
        }

        public static DataSet GetDashboardValues_ETM(int Flag, string Year, string Month)
        {
            SqlParameter P1 = new SqlParameter("@Flag", SqlDbType.Int);
            P1.Value = Flag;
            SqlParameter P2 = new SqlParameter("@Year", SqlDbType.VarChar);
            P2.Value = Year;
            SqlParameter P3 = new SqlParameter("@Month", SqlDbType.VarChar);
            P3.Value = Month;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ECOMMERCE_DATA_ANALYSIS", P1, P2, P3));
        }

        public static DataSet GetDashboardValues_ETM_3D(int Flag, string Year, string Month, string Category)
        {
            SqlParameter P1 = new SqlParameter("@Flag", SqlDbType.Int);
            P1.Value = Flag;
            SqlParameter P2 = new SqlParameter("@Year", SqlDbType.VarChar);
            P2.Value = Year;
            SqlParameter P3 = new SqlParameter("@Month", SqlDbType.VarChar);
            P3.Value = Month;
            SqlParameter P4 = new SqlParameter("@Category", SqlDbType.VarChar);
            P4.Value = Category;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ECOMMERCE_3D", P1, P2, P3, P4));
        }

        public static DataSet GetDashboardValues_ETM_3D1(int Flag, string Year, string Month, string Category)
        {
            SqlParameter P1 = new SqlParameter("@Flag", SqlDbType.Int);
            P1.Value = Flag;
            SqlParameter P2 = new SqlParameter("@Year", SqlDbType.VarChar);
            P2.Value = Year;
            SqlParameter P3 = new SqlParameter("@Month", SqlDbType.VarChar);
            P3.Value = Month;
            SqlParameter P4 = new SqlParameter("@Category", SqlDbType.VarChar);
            P4.Value = Category;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ECOMMERCE_3D1", P1, P2, P3, P4));
        }

        public static DataSet Get_Contacts_ExcelUpLoad_ExcelName(string UserCode, string Flag)
        {
            SqlParameter p = new SqlParameter("@UserCode", UserCode);
            SqlParameter p1 = new SqlParameter("@flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Contacts_ExcelUpLoad_ExcelName", p, p1));
        }

        public static DataSet Get_ECom_Dashboard(string Acad_Year, string User_Code, string Flag)
        {
            SqlParameter p = new SqlParameter("@Acad_Year", Acad_Year);
            SqlParameter p1 = new SqlParameter("@User_Code", User_Code);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Dashboard_ECom_Sales", p, p1, p2));
        }

        //public static DataSet Get_ECom_Dashboard(string Acad_Year, string User_Code, string Flag)
        //{
        //    SqlParameter p = new SqlParameter("@Acad_Year", Acad_Year);
        //    SqlParameter p1 = new SqlParameter("@User_Code", User_Code);
        //    SqlParameter p2 = new SqlParameter("@Flag", Flag);

        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Dashboard_ECom_Sales", p, p1, p2));
        //}

        public static DataSet Get_Notification_Detail(string User_Code, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@User_Code", User_Code);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Notification_Detail", p1, p2));
        }

        public static DataSet Get_Notification_Followup_Detail(string User_Code, string Page_Number, string Flag)
        {
            SqlParameter p0 = new SqlParameter("@User_Code", User_Code);
            SqlParameter p1 = new SqlParameter("@Page_Number", Page_Number);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Notification_Followup_Detail", p0, p1, p2));
        }

        public static DataSet Get_Center_Dashboard(string Acad_Year, string User_Code, string Flag)
        {
            SqlParameter p = new SqlParameter("@Acad_Year", Acad_Year);
            SqlParameter p1 = new SqlParameter("@User_Code", User_Code);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Dashboard_Center", p, p1, p2));
        }


        //public static DataSet Insert_Contacts_Center_ExcelUpload(string RowNum, string ContactSource, string ContactTitle, string ContactFirstName, string ContactMidName, string ContactLastName, string Gender, string EmailID, string Handphone1,
        //       string Country, string Created_By, string ExcelName, string TotalRecord, string Flag, string Handphone2, string Landline)
        //{
        //    SqlParameter p = new SqlParameter("@RowNum", RowNum);
        //    SqlParameter p1 = new SqlParameter("@ContactSource", ContactSource);
        //    SqlParameter p2 = new SqlParameter("@ContactTitle", ContactTitle);
        //    SqlParameter p3 = new SqlParameter("@ContactFirstName", ContactFirstName);
        //    SqlParameter p4 = new SqlParameter("@ContactMidName", ContactMidName);
        //    SqlParameter p5 = new SqlParameter("@ContactLastName", ContactLastName);
        //    SqlParameter p6 = new SqlParameter("@Gender", Gender);
        //    SqlParameter p7 = new SqlParameter("@EmailID", EmailID);
        //    SqlParameter p8 = new SqlParameter("@Handphone1", Handphone1);
        //    SqlParameter p9 = new SqlParameter("@Country", Country);
        //    SqlParameter p10 = new SqlParameter("@Created_By", Created_By);
        //    SqlParameter p11 = new SqlParameter("@ExcelName", ExcelName);
        //    SqlParameter p12 = new SqlParameter("@TotalRecord", TotalRecord);
        //    SqlParameter p13 = new SqlParameter("@flag", Flag);
        //    SqlParameter p14 = new SqlParameter("@Handphone2", Handphone2);
        //    SqlParameter p15 = new SqlParameter("@Landline", Landline);

        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Contacts_Center_ExcelUpload", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13,p14,p15));
        //}

        public static DataSet Insert_Contacts_Center_ExcelUpload(string xmlData, string Created_By, string ExcelName, string TotalRecord, string Flag)
        {
            SqlParameter p = new SqlParameter("@xmlData", xmlData);
            SqlParameter p1 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p2 = new SqlParameter("@ExcelName", ExcelName);
            SqlParameter p3 = new SqlParameter("@TotalRecord", TotalRecord);
            SqlParameter p4 = new SqlParameter("@flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Contacts_Center_ExcelUpload", p, p1, p2, p3, p4));
        }

        public static DataSet GetAllStreamby_Center_AcademicYear(string CenterCode, string AcademicYear)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getAllstream_byCenter_Acadyear", p, p1));
        }

        public static DataSet GetallactiveCampaignFollowupStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActive_CampaignFollowup_Status"));
        }


        public static string InsertFeedback_Campaign_ContactsNew(string Feedbackid, string Taskid, string RecNoOrConID, string Interacted_With, string Interacted_Relation, string Interacted_On, string Feedback, string Feedback_Status, string CampaignFollowupStatus, string Updatedby, string SeminarStatus,
        string NextFollowupdate, string Flag)
        {
            SqlParameter[] p = new SqlParameter[14];
            p[0] = new SqlParameter("@feedbackid", SqlDbType.NVarChar);
            p[0].Value = Feedbackid;
            p[1] = new SqlParameter("@task_id", SqlDbType.NVarChar);
            p[1].Value = Taskid;
            p[2] = new SqlParameter("@Id", SqlDbType.NVarChar);
            p[2].Value = RecNoOrConID;
            p[3] = new SqlParameter("@Interactedwith", SqlDbType.NVarChar);
            p[3].Value = Interacted_With;
            p[4] = new SqlParameter("@InteractedRelation", SqlDbType.NVarChar);
            p[4].Value = Interacted_Relation;
            p[5] = new SqlParameter("@Interacted_On", SqlDbType.NVarChar);
            p[5].Value = Interacted_On;
            p[6] = new SqlParameter("@feedback", SqlDbType.NVarChar);
            p[6].Value = Feedback;
            p[7] = new SqlParameter("@Feedback_Status", SqlDbType.NVarChar);
            p[7].Value = Feedback_Status;
            p[8] = new SqlParameter("@feedback_Out", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            p[9] = new SqlParameter("@Updated_By", SqlDbType.NVarChar);
            p[9].Value = Updatedby;
            p[10] = new SqlParameter("@SeminarStatus", SqlDbType.NVarChar);
            p[10].Value = SeminarStatus;
            p[11] = new SqlParameter("@NextFollowupDate", SqlDbType.NVarChar);
            p[11].Value = NextFollowupdate;
            p[12] = new SqlParameter("@Flag", SqlDbType.NVarChar);
            p[12].Value = Flag;
            p[13] = new SqlParameter("@CampaignFollowup__Status", SqlDbType.NVarChar);
            p[13].Value = CampaignFollowupStatus;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertCampaign_Conatcts_feedback", p);
            return (p[8].Value.ToString());
        }

        public static string InsertFeedback_Campaign_ContactsNew(string CallingMode, string Feedbackid, string Taskid, string RecNoOrConID, string Interacted_With, string Interacted_Relation, string Interacted_On, string Feedback, string Feedback_Status, string CampaignFollowupStatus, string Updatedby, string SeminarStatus,
        string NextFollowupdate, string Flag)
        {
            SqlParameter[] p = new SqlParameter[15];
            p[0] = new SqlParameter("@feedbackid", SqlDbType.NVarChar);
            p[0].Value = Feedbackid;
            p[1] = new SqlParameter("@task_id", SqlDbType.NVarChar);
            p[1].Value = Taskid;
            p[2] = new SqlParameter("@Id", SqlDbType.NVarChar);
            p[2].Value = RecNoOrConID;
            p[3] = new SqlParameter("@Interactedwith", SqlDbType.NVarChar);
            p[3].Value = Interacted_With;
            p[4] = new SqlParameter("@InteractedRelation", SqlDbType.NVarChar);
            p[4].Value = Interacted_Relation;
            p[5] = new SqlParameter("@Interacted_On", SqlDbType.NVarChar);
            p[5].Value = Interacted_On;
            p[6] = new SqlParameter("@feedback", SqlDbType.NVarChar);
            p[6].Value = Feedback;
            p[7] = new SqlParameter("@Feedback_Status", SqlDbType.NVarChar);
            p[7].Value = Feedback_Status;
            p[8] = new SqlParameter("@feedback_Out", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            p[9] = new SqlParameter("@Updated_By", SqlDbType.NVarChar);
            p[9].Value = Updatedby;
            p[10] = new SqlParameter("@SeminarStatus", SqlDbType.NVarChar);
            p[10].Value = SeminarStatus;
            p[11] = new SqlParameter("@NextFollowupDate", SqlDbType.NVarChar);
            p[11].Value = NextFollowupdate;
            p[12] = new SqlParameter("@Flag", SqlDbType.NVarChar);
            p[12].Value = Flag;
            p[13] = new SqlParameter("@CampaignFollowup__Status", SqlDbType.NVarChar);
            p[13].Value = CampaignFollowupStatus;
            p[14] = new SqlParameter("@CallingMode", SqlDbType.NVarChar);
            p[14].Value = CallingMode;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertCampaign_Conatcts_feedback", p);
            return (p[8].Value.ToString());
        }


        public static string InsertFeedback_Campaign_Contacts(string CallingMode, string Feedbackid, string Taskid, string RecNoOrConID, string Interacted_With, string Interacted_Relation, string Interacted_On, string Feedback, string Feedback_Status, string Updatedby, string SeminarStatus,
        string NextFollowupdate, string Flag)
        {
            SqlParameter[] p = new SqlParameter[14];
            p[0] = new SqlParameter("@feedbackid", SqlDbType.NVarChar);
            p[0].Value = Feedbackid;
            p[1] = new SqlParameter("@task_id", SqlDbType.NVarChar);
            p[1].Value = Taskid;
            p[2] = new SqlParameter("@Id", SqlDbType.NVarChar);
            p[2].Value = RecNoOrConID;
            p[3] = new SqlParameter("@Interactedwith", SqlDbType.NVarChar);
            p[3].Value = Interacted_With;
            p[4] = new SqlParameter("@InteractedRelation", SqlDbType.NVarChar);
            p[4].Value = Interacted_Relation;
            p[5] = new SqlParameter("@Interacted_On", SqlDbType.NVarChar);
            p[5].Value = Interacted_On;
            p[6] = new SqlParameter("@feedback", SqlDbType.NVarChar);
            p[6].Value = Feedback;
            p[7] = new SqlParameter("@Feedback_Status", SqlDbType.NVarChar);
            p[7].Value = Feedback_Status;
            p[8] = new SqlParameter("@feedback_Out", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            p[9] = new SqlParameter("@Updated_By", SqlDbType.NVarChar);
            p[9].Value = Updatedby;
            p[10] = new SqlParameter("@SeminarStatus", SqlDbType.NVarChar);
            p[10].Value = SeminarStatus;
            p[11] = new SqlParameter("@NextFollowupDate", SqlDbType.NVarChar);
            p[11].Value = NextFollowupdate;
            p[12] = new SqlParameter("@Flag", SqlDbType.NVarChar);
            p[12].Value = Flag;
            p[13] = new SqlParameter("@CallingMode", SqlDbType.NVarChar);
            p[13].Value = CallingMode;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertCampaign_Conatcts_feedback", p);
            return (p[8].Value.ToString());
        }

        public static string InsertFeedback(string CallingMode, string Feedbackid, string Taskid, string Leadid, string Interacted_With, string Interacted_Relation, string Interacted_On, string Feedback, string Feedback_Status, string Updatedby, string SeminarStatus,
       string NextFollowupdate, string Seminar_Id, string Seminar_Date)
        {
            SqlParameter[] p = new SqlParameter[15];
            p[0] = new SqlParameter("@feedbackid", SqlDbType.NVarChar);
            p[0].Value = Feedbackid;
            p[1] = new SqlParameter("@task_id", SqlDbType.NVarChar);
            p[1].Value = Taskid;
            p[2] = new SqlParameter("@Lead_id", SqlDbType.NVarChar);
            p[2].Value = Leadid;
            p[3] = new SqlParameter("@Interactedwith", SqlDbType.NVarChar);
            p[3].Value = Interacted_With;
            p[4] = new SqlParameter("@InteractedRelation", SqlDbType.NVarChar);
            p[4].Value = Interacted_Relation;
            p[5] = new SqlParameter("@Interacted_On", SqlDbType.NVarChar);
            p[5].Value = Interacted_On;
            p[6] = new SqlParameter("@feedback", SqlDbType.NVarChar);
            p[6].Value = Feedback;
            p[7] = new SqlParameter("@Feedback_Status", SqlDbType.NVarChar);
            p[7].Value = Feedback_Status;
            p[8] = new SqlParameter("@feedback_Out", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            p[9] = new SqlParameter("@Updated_By", SqlDbType.NVarChar);
            p[9].Value = Updatedby;
            p[10] = new SqlParameter("@SeminarStatus", SqlDbType.NVarChar);
            p[10].Value = SeminarStatus;
            p[11] = new SqlParameter("@NextFollowupDate", SqlDbType.NVarChar);
            p[11].Value = NextFollowupdate;
            p[12] = new SqlParameter("@CallingMode", SqlDbType.NVarChar);
            p[12].Value = CallingMode;
            p[13] = new SqlParameter("@Seminar_Id", SqlDbType.NVarChar);
            p[13].Value = Seminar_Id;
            p[14] = new SqlParameter("@Seminar_Date", SqlDbType.NVarChar);
            p[14].Value = Seminar_Date;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadfeedback", p);
            return (p[8].Value.ToString());
        }


        public static string InsertFeedbackOpportunity(string CallingMode, string Feedbackid, string Taskid, string Leadid, string Interacted_With, string Interacted_Relation, string Interacted_On, string Feedback, string Feedback_Status, string Updatedby, string SeminarStatus,
        string Oppor_Sales_Stage, string Oppor_Sales_Stage_id, string NextFollowupdate, string Appno)
        {
            SqlParameter[] p = new SqlParameter[16];
            p[0] = new SqlParameter("@feedbackid", SqlDbType.NVarChar);
            p[0].Value = Feedbackid;
            p[1] = new SqlParameter("@task_id", SqlDbType.NVarChar);
            p[1].Value = Taskid;
            p[2] = new SqlParameter("@lead_Id", SqlDbType.NVarChar);
            p[2].Value = Leadid;
            p[3] = new SqlParameter("@Interactedwith", SqlDbType.NVarChar);
            p[3].Value = Interacted_With;
            p[4] = new SqlParameter("@InteractedRelation", SqlDbType.NVarChar);
            p[4].Value = Interacted_Relation;
            p[5] = new SqlParameter("@Interacted_On", SqlDbType.NVarChar);
            p[5].Value = Interacted_On;
            p[6] = new SqlParameter("@feedback", SqlDbType.NVarChar);
            p[6].Value = Feedback;
            p[7] = new SqlParameter("@Feedback_Status", SqlDbType.NVarChar);
            p[7].Value = Feedback_Status;
            p[8] = new SqlParameter("@feedback_Out", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            p[9] = new SqlParameter("@Updated_By", SqlDbType.NVarChar);
            p[9].Value = Updatedby;
            p[10] = new SqlParameter("@SeminarStatus", SqlDbType.NVarChar);
            p[10].Value = SeminarStatus;
            p[11] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[11].Value = Oppor_Sales_Stage;
            p[12] = new SqlParameter("@Sales_Stage_id", SqlDbType.NVarChar);
            p[12].Value = Oppor_Sales_Stage_id;
            p[13] = new SqlParameter("@NextFollowupDate", SqlDbType.NVarChar);
            p[13].Value = NextFollowupdate;
            p[14] = new SqlParameter("@AppNo", SqlDbType.NVarChar, 10);
            p[14].Value = Appno;
            p[15] = new SqlParameter("@CallingMode", SqlDbType.NVarChar);
            p[15].Value = CallingMode;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadfeedbackOpportunity", p);
            return (p[8].Value.ToString());
        }

        public static DataSet Insert_SMS_Campaign(int Flag, string user_id, string Campaign_Id, string Contacts_Id, string MobileNo, string Message)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@Flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@user_id", SqlDbType.VarChar);
            p[1].Value = user_id;
            p[2] = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p[2].Value = Campaign_Id;
            p[3] = new SqlParameter("@Contacts_Id", SqlDbType.VarChar);
            p[3].Value = Contacts_Id;
            p[4] = new SqlParameter("@MobileNo", SqlDbType.VarChar);
            p[4].Value = MobileNo;
            p[5] = new SqlParameter("@Message", SqlDbType.VarChar);
            p[5].Value = Message;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Send_Sms_Campaign", p));
        }

        public static DataSet GetUser_Company_Division_Zone_Center_Top1(int Flag, string Userid, string Divisioncode, string Zonecode, string Companycode)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@division_code", SqlDbType.VarChar);
            p2.Value = Divisioncode;
            SqlParameter p3 = new SqlParameter("@Zone_code", SqlDbType.VarChar);
            p3.Value = Zonecode;
            SqlParameter p4 = new SqlParameter("@Company_Code", SqlDbType.VarChar);
            p4.Value = Companycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center_Top1", p, p1, p2, p3, p4));
        }

        /// <summary>
        /// Dashboard Hyper Link to get pending admission list
        /// </summary>
        /// <param name="Acad_Year"></param>
        /// <param name="User_Code"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public static DataSet Get_Dashboard_Account_Detail(string Acad_Year, string User_Code, string Flag)
        {
            SqlParameter p = new SqlParameter("@academicyear", Acad_Year);
            SqlParameter p1 = new SqlParameter("@userid", User_Code);
            SqlParameter p2 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Dashboard_Account_Detail_Results", p, p1, p2));
        }

        public static DataSet Get_Seminar_Detail(string User_Code, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@userid", User_Code);
            SqlParameter p2 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Seminar_Details", p1, p2));
        }

        //public static DataSet GetallactiveCampaignFollowupStatus()
        //{
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActive_CampaignFollowup_Status"));
        //}



        public static DataSet GetAllAbsentreasons()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallAbsentReason"));
        }

        public static DataSet Get_Student_Seminar_Attendance(int flag, string SeminarId, string UserId, string SeminarDate)
        {
            SqlParameter p = new SqlParameter("@flag", flag);
            SqlParameter p1 = new SqlParameter("@SeminarId", SeminarId);
            SqlParameter p2 = new SqlParameter("@UserId", UserId);
            SqlParameter p3 = new SqlParameter("@SeminarDate", SeminarDate);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_GetStudent_ForSeminarAttendance", p, p1, p2, p3));
        }

        public static int Insert_UpdateStudent_Seminar_Attendance(string LeadId, string SeminarId, string AttendStatus, string AbsentReasonid, string AbsentReason, string Remarks, string UserId, string SeminarDate)
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@LeadId", LeadId);
            p[1] = new SqlParameter("@SeminarId", SeminarId);
            p[2] = new SqlParameter("@AttendStatus", AttendStatus);
            p[3] = new SqlParameter("@AbsentReasonid", AbsentReasonid);
            p[4] = new SqlParameter("@AbsentReason", AbsentReason);
            p[5] = new SqlParameter("@Remarks", Remarks);
            p[6] = new SqlParameter("@UserId", UserId);
            p[7] = new SqlParameter("@Result", SqlDbType.Int);
            p[8] = new SqlParameter("@SeminarDate", SeminarDate);

            p[7].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertUpdateStudent_Seminar_Attendance", p);
            return (int.Parse(p[7].Value.ToString()));
        }

        public static DataSet Get_Campaign_Detail_PendingContacts(string user_id, string Campaign_Id, string Name, string Handphone, string Page_Number, string Flag)
        {
            SqlParameter p = new SqlParameter("@user_id", user_id);
            SqlParameter p1 = new SqlParameter("@Campaign_Id", Campaign_Id);
            SqlParameter p2 = new SqlParameter("@Name", Name);
            SqlParameter p3 = new SqlParameter("@Handphone", Handphone);
            SqlParameter p4 = new SqlParameter("@Page_Number", Page_Number);
            SqlParameter p5 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Campaign_ContactDetailByPKey", p, p1, p2, p3, p4, p5));
        }


        public static DataSet Delete_Campaign_PendingContacts(string user_id, string Campaign_Id, string ContactId, string Flag)
        {
            SqlParameter p = new SqlParameter("@user_id", user_id);
            SqlParameter p1 = new SqlParameter("@Campaign_Id", Campaign_Id);
            SqlParameter p2 = new SqlParameter("@ContactId", ContactId);
            SqlParameter p3 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Delete_Campaign_Contacts", p, p1, p2, p3));
        }

        //Start ECS Detail Stored Procedure

        public static DataSet Save_ECS_Detail(string ECS_ID, string UMR_NO, string ECS_DATE, string SponsorBankCode, string UtilityCode, string Company_Name, string ToDebit, string BankAcNo,
            string WithBank, string IFSC_Code, string MICR_Code, string Amount, string Frequency, string Debit_Type, string Ref1, string Phone, string Ref2, string EmailId,
            string Period_From, string Period_To, string SBEntryCode, string SPID, string UserId, int flag, string AcountHolder_Type, string AcountHolder1, string AcountHolder2)
        {
            SqlParameter p = new SqlParameter("@ECS_ID", ECS_ID);
            SqlParameter p1 = new SqlParameter("@UMR_NO", UMR_NO);
            SqlParameter p2 = new SqlParameter("@ECS_DATE", ECS_DATE);
            SqlParameter p3 = new SqlParameter("@SponsorBankCode", SponsorBankCode);
            SqlParameter p4 = new SqlParameter("@UtilityCode", UtilityCode);
            SqlParameter p5 = new SqlParameter("@Company_Name", Company_Name);
            SqlParameter p6 = new SqlParameter("@ToDebit", ToDebit);
            SqlParameter p7 = new SqlParameter("@BankAcNo", BankAcNo);
            SqlParameter p8 = new SqlParameter("@WithBank", WithBank);
            SqlParameter p9 = new SqlParameter("@IFSC_Code", IFSC_Code);
            SqlParameter p10 = new SqlParameter("@MICR_Code", MICR_Code);
            SqlParameter p11 = new SqlParameter("@Amount", Amount);
            SqlParameter p12 = new SqlParameter("@Frequency", Frequency);
            SqlParameter p13 = new SqlParameter("@Debit_Type", Debit_Type);
            SqlParameter p14 = new SqlParameter("@Ref1", Ref1);
            SqlParameter p15 = new SqlParameter("@Phone", Phone);
            SqlParameter p16 = new SqlParameter("@Ref2", Ref2);
            SqlParameter p17 = new SqlParameter("@EmailId", EmailId);
            SqlParameter p18 = new SqlParameter("@Period_From", Period_From);
            SqlParameter p19 = new SqlParameter("@Period_To", Period_To);
            SqlParameter p20 = new SqlParameter("@SBEntryCode", SBEntryCode);
            SqlParameter p21 = new SqlParameter("@SPID", SPID);
            SqlParameter p22 = new SqlParameter("@CreatedBy", UserId);
            SqlParameter p23 = new SqlParameter("@Flag", flag);
            SqlParameter p24 = new SqlParameter("@AcountHolder_Type", AcountHolder_Type);
            SqlParameter p25 = new SqlParameter("@AcountHolder1", AcountHolder1);
            SqlParameter p26 = new SqlParameter("@AcountHolder2", AcountHolder2);


            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Save_ECS_Detail", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,
                                    p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26));
        }

        public static DataSet Get_ECS_Detail(string SBEntryCode, string User_Code, string Flag)
        {
            SqlParameter p = new SqlParameter("@SBEntryCode", SBEntryCode);
            SqlParameter p1 = new SqlParameter("@UserCode", User_Code);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetECS_Detail", p, p1, p2));
        }

        public static DataSet Get_Blank_ECS_PDF_Detail(string ECSFormDate, string ECSToDate, string BankAcNo, string BankName, string IFSC, string MICR,
                    string Amount, string StudName, string PhoneNo, string EmailID, string UserCode, string Flag, string Division, string Accountholdername)
        {
            SqlParameter p = new SqlParameter("@ECSFormDate", ECSFormDate);
            SqlParameter p1 = new SqlParameter("@ECSToDate", ECSToDate);
            SqlParameter p2 = new SqlParameter("@BankAcNo", BankAcNo);
            SqlParameter p3 = new SqlParameter("@BankName", BankName);
            SqlParameter p4 = new SqlParameter("@IFSC", IFSC);
            SqlParameter p5 = new SqlParameter("@MICR", MICR);
            SqlParameter p6 = new SqlParameter("@Amount", Amount);
            SqlParameter p7 = new SqlParameter("@StudName", StudName);
            SqlParameter p8 = new SqlParameter("@PhoneNo", PhoneNo);
            SqlParameter p9 = new SqlParameter("@EmailID", EmailID);
            SqlParameter p10 = new SqlParameter("@UserCode", UserCode);
            SqlParameter p11 = new SqlParameter("@Flag", Flag);
            SqlParameter p12 = new SqlParameter("@DivisionCode", Division);
            SqlParameter p13 = new SqlParameter("@Accountholder1name", Accountholdername);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetECS_BlankPDF", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));
        }


        public static DataSet Insert_ECS_BankDetail_ExportSave(string xmlData, string Import_File_Name, string User_Code, string Flag)
        {
            SqlParameter p = new SqlParameter("@xmlData", xmlData);
            SqlParameter p1 = new SqlParameter("@Created_By", User_Code);
            SqlParameter p2 = new SqlParameter("@Import_File_Name", Import_File_Name);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ECS_Confirmation_Bank_Excel_Upload", p, p1, p2, p3));
        }

        public static DataSet Get_ECS_BankDetail_Dupli(string Import_File_Name, string User_Code, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Created_By", User_Code);
            SqlParameter p2 = new SqlParameter("@Import_File_Name", Import_File_Name);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ECS_Get_Excel_Duplicate", p1, p2, p3));
        }


        public static DataSet Get_ECS_DepositExcelDownload(string DispatchSlipCode, string User_Code, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Created_By", User_Code);
            SqlParameter p2 = new SqlParameter("@DispatchSlipCode", DispatchSlipCode);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_ECS_DispatchSlip_ExcelDownload", p1, p2, p3));
        }


        public static DataSet Get_ECS_SAP_Bank_Statement_Dupli(string Import_File_Name, string User_Code, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Created_By", User_Code);
            SqlParameter p2 = new SqlParameter("@Import_File_Name", Import_File_Name);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ECS_SAP_Bank_Statement_Get_Excel_Duplicate", p1, p2, p3));
        }

        public static DataSet Insert_ECS_SAP_Bank_Statements_ExportSave(string xmlData, string Import_File_Name, string User_Code, string Flag)
        {
            SqlParameter p = new SqlParameter("@xmlData", xmlData);
            SqlParameter p1 = new SqlParameter("@Created_By", User_Code);
            SqlParameter p2 = new SqlParameter("@Import_File_Name", Import_File_Name);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ECS_SAP_Bank_Statement_Excel_Upload", p, p1, p2, p3));
        }

        public static DataSet Export_ECS_SAP_Bank_Statements(string ExcelFileNo, string flag)
        {
            SqlParameter p = new SqlParameter("@flag", flag);
            SqlParameter p1 = new SqlParameter("@ExcelFileNo", ExcelFileNo);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ECS_SAP_ExcelUploadData", p, p1));
        }
        //End ECS Detail Stored Procedure


        public static string GetImport_Id(int flag, string filename, string created_By, int isAcrive)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@flag", flag);
            p[1] = new SqlParameter("@File_Name", filename);
            p[2] = new SqlParameter("@CreatedBy", created_By);
            p[3] = new SqlParameter("@IsActive", isAcrive);
            p[4] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Insert_BankDetails", p);
            return (p[4].Value.ToString());

        }

        public static string InsertBankDetails(string TYPE, string CLCODE, string BANK_ACCOUNT, string PRDCODE, string LOCATION, string LOCATION_NAME, string DEPDATE,
                      string CLGTYPE, string CRDATE, string RTNDATE, string SLIPNO, string TOTAL_INSTRUMENTS, string SLIPAMOUNT, string INSTRUMENTNO, string INSTRUMENTTYPE, string INSTRUMENTDATE,
                      string INSTRUMENTAMNT, string RECOVEREDAMNT, string DRAWNON, string DRAWNONLOC, string DRWANBANK, string DRAWNBRANCH, string DRAWERNAME, string RTN, string RTN_REASON, string INST_ADD_INFO, string INST_ADD_INFO2,
                      string INST_ADD_INFO3, string INST_ADD_INFO4, string REMARKS, string STATUS, string CreastedBy, string Import_Id, int flag)
        {
            SqlParameter[] p = new SqlParameter[35];
            p[0] = new SqlParameter("@TYPE", TYPE);
            p[1] = new SqlParameter("@CLCODE", CLCODE);
            p[2] = new SqlParameter("@BANK_ACCOUNT", BANK_ACCOUNT);
            p[3] = new SqlParameter("@PRDCODE", PRDCODE);
            p[4] = new SqlParameter("@LOCATION", LOCATION);
            p[5] = new SqlParameter("@LOCATION_NAME", LOCATION_NAME);
            p[6] = new SqlParameter("@DEPDATE", DEPDATE);
            p[7] = new SqlParameter("@CLGTYPE", CLGTYPE);
            p[8] = new SqlParameter("@CRDATE", CRDATE);
            p[9] = new SqlParameter("@RTNDATE", RTNDATE);
            p[10] = new SqlParameter("@SLIPNO", SLIPNO);
            p[11] = new SqlParameter("@TOTAL_INSTRUMENTS", TOTAL_INSTRUMENTS);
            p[12] = new SqlParameter("@SLIPAMOUNT", SLIPAMOUNT);
            p[13] = new SqlParameter("@INSTRUMENTNO", INSTRUMENTNO);
            p[14] = new SqlParameter("@INSTRUMENTTYPE", INSTRUMENTTYPE);
            p[15] = new SqlParameter("@INSTRUMENTDATE", INSTRUMENTDATE);
            p[16] = new SqlParameter("@INSTRUMENTAMNT", INSTRUMENTAMNT);
            p[17] = new SqlParameter("@RECOVEREDAMNT", RECOVEREDAMNT);
            p[18] = new SqlParameter("@DRAWNON", DRAWNON);
            p[19] = new SqlParameter("@DRAWNONLOC", DRAWNONLOC);
            p[20] = new SqlParameter("@DRWANBANK", DRWANBANK);
            p[21] = new SqlParameter("@DRAWNBRANCH", DRAWNBRANCH);
            p[22] = new SqlParameter("@DRAWERNAME", DRAWERNAME);
            p[23] = new SqlParameter("@RTN", RTN);
            p[24] = new SqlParameter("@RTN_REASON", RTN_REASON);
            p[25] = new SqlParameter("@INST_ADD_INFO", INST_ADD_INFO);
            p[26] = new SqlParameter("@INST_ADD_INFO2", INST_ADD_INFO2);
            p[27] = new SqlParameter("@INST_ADD_INFO3", INST_ADD_INFO3);
            p[28] = new SqlParameter("@INST_ADD_INFO4", INST_ADD_INFO4);
            p[29] = new SqlParameter("@REMARKS", REMARKS);
            p[30] = new SqlParameter("@STATUS", STATUS);
            p[31] = new SqlParameter("@CreatedBy", CreastedBy);
            p[32] = new SqlParameter("@Import_Id", Import_Id);
            p[33] = new SqlParameter("@Flag", flag);
            p[34] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[34].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Insert_BankDetails", p);
            return (p[34].Value.ToString());
        }

        /////added by archana(05-04-2017)//////////
        public static DataSet GetStudent_DetailsFor_Remark(string Division_Code, string YearName, string CentreCode, string SBentrycode, string ChequeNo, string ChequeStatus, string Recover_Status, string FollowupDate)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acadyear", YearName);
            SqlParameter p3 = new SqlParameter("@Center_Code", CentreCode);
            SqlParameter p4 = new SqlParameter("@Sbentrycode", SBentrycode);
            SqlParameter p5 = new SqlParameter("@Chequeno", ChequeNo);
            SqlParameter p6 = new SqlParameter("@Cheque_Status", ChequeStatus);
            SqlParameter p7 = new SqlParameter("@Recovery_Status", Recover_Status);
            SqlParameter p8 = new SqlParameter("@Next_Followup_Date", FollowupDate);
            SqlParameter p9 = new SqlParameter("@Flag", 1);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Get_StudentDetails_forChequeFollowup", p1, p2, p3, p4, p5, p6, p7, p8, p9));
        }
        public static string InsertUpdate_Student_FollowupRemark(int flag, string Division_Code, string Center_Code, string Stream_Code, string SbentryCode, string CHEQUEID, string Cheque_No, string Followup_Remark, string Cheque_status, string Recovery_Status, string Panelty_Collected, string Next_Followup_Date, string Recovery_ChequeNo, string Recovery_Amount, string Recovery_AmountCollected, string Panelty_AmountCollected, string Created_by)
        {
            SqlParameter[] p = new SqlParameter[18];
            p[0] = new SqlParameter("@flag", flag);
            p[1] = new SqlParameter("@Division_Code", Division_Code);
            p[2] = new SqlParameter("@Center_Code", Center_Code);
            p[3] = new SqlParameter("@Stream_Code", Stream_Code);
            p[4] = new SqlParameter("@Sbentrycode", SbentryCode);
            p[5] = new SqlParameter("@Cheque_ID", CHEQUEID);
            p[6] = new SqlParameter("@Chequeno", Cheque_No);
            p[7] = new SqlParameter("@Followup_Remark", Followup_Remark);
            p[8] = new SqlParameter("@Cheque_Status", Cheque_status);
            p[9] = new SqlParameter("@Recovery_Status", Recovery_Status);
            p[10] = new SqlParameter("@Panelty_Collected", Panelty_Collected);
            p[11] = new SqlParameter("@Next_Followup_Date", Next_Followup_Date);
            p[12] = new SqlParameter("@Recovered_ChequeNo", Recovery_ChequeNo);
            p[13] = new SqlParameter("@Recovered_Amount", Recovery_Amount);
            p[14] = new SqlParameter("@Fees_AmountCollected", Recovery_AmountCollected);
            p[15] = new SqlParameter("@Bounced_ChargersCollected", Panelty_AmountCollected);
            p[16] = new SqlParameter("@Created_By", Created_by);
            p[17] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[17].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Get_StudentDetails_forChequeFollowup", p);
            return (p[17].Value.ToString());

        }
        public static DataSet UpdateStudent_ChequeStatus(int Flag)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Get_StudentDetails_forChequeFollowup", p1));
        }
        public static DataSet GetStudent_Details(int Flag, string pkey)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@Pkey", pkey);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Get_StudentDetails_forChequeFollowup", p1, p2));
        }
        public static DataSet GetStudent_ChequeDetails(int Flag, string Sbentrycode, string center, string chequeno)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@Sbentrycode", Sbentrycode);
            SqlParameter p3 = new SqlParameter("@Center_Code", center);
            SqlParameter p4 = new SqlParameter("@Cheque_No", chequeno);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Get_StudentDetails_forChequeFollowup", p1, p2, p3, p4));
        }

        public static DataSet GetMenuList(string Flag, string User_Code, string Menu_Code)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@User_Code", User_Code);
            SqlParameter p3 = new SqlParameter("@Menu_Code", Menu_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Menu_List", p1, p2, p3));
        }

        public static DataSet GetApplication_Url()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Application_URL"));
        }

        public static DataSet Update_RollNo_Student(string PKey, string User_Code, string Flag)
        {
            SqlParameter p = new SqlParameter("@PKey", PKey);
            SqlParameter p1 = new SqlParameter("@Createdby", User_Code);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertRollNo_Batch_Student", p, p1, p2));
        }


        //Added by sujeer for roll number
        public static DataSet GetAllActive_Product(string Division_Code, string YearName, string course, string Product, string center, string flag)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@coursecode", course);
            SqlParameter p4 = new SqlParameter("@productcode", Product);
            SqlParameter p5 = new SqlParameter("@Centercode", center);
            SqlParameter p6 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_GetLMSproduct_New]", p1, p2, p3, p4, p5, p6));
        }


        public static DataSet GetAllActive_Product1(string Division_Code, string center, string flag)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
            SqlParameter p2 = new SqlParameter("@Centercode", center);
            SqlParameter p3 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_GetLMSproduct_New]", p1, p2, p3));
        }


        public static DataSet GetStudentBy_Division_Year_Standard_Centre(string Division_Code, string streamcode, string CentreCode, string productcode, string flag)
        {
            SqlParameter p1 = new SqlParameter("@DIVISIONCODE", Division_Code);
            SqlParameter p2 = new SqlParameter("@STREAMCODE", streamcode);
            SqlParameter p3 = new SqlParameter("@CENTERCODE", CentreCode);
            SqlParameter p4 = new SqlParameter("@PRODUCTCODE", productcode);
            SqlParameter p5 = new SqlParameter("@Flag", flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USB_GET_STUDENT_DETAILS_FOR_ROLL_NUMBER", p1, p2, p3, p4, p5));
        }

        public static int Insert_Rollnumber(string DivisionCode, string StandardCode, string Productcode, string centercode, string streamcode, string sbentrycode, string spid, string rollno, string CodeForEdit, string CreatedBy, string flag)
        {
            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@DIVISIONCODE", DivisionCode);
            p[1] = new SqlParameter("@coursecode", StandardCode);
            p[2] = new SqlParameter("@Productcode", Productcode);
            p[3] = new SqlParameter("@CENTERCODE", centercode);
            p[4] = new SqlParameter("@STREAMCODE", streamcode);
            p[5] = new SqlParameter("@sbentrycode", sbentrycode);
            p[6] = new SqlParameter("@spid", spid);
            p[7] = new SqlParameter("@rollno", rollno);
            p[8] = new SqlParameter("@CodeForEdit", CodeForEdit);
            p[9] = new SqlParameter("@CreatedBy", CreatedBy);
            p[10] = new SqlParameter("@FLAG", flag);
            p[11] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[11].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USB_UPDATE_INSERT_STUDENT_DETAILS_FOR_ROLL_NUMBER", p);
            return (int.Parse(p[11].Value.ToString()));
        }

        //Campaign Event(Digambar)
        public static DataSet InsertUpdate_CampaignEvents(string Flag, string Userid, string Campaign_Id, string CampaignEventId, string CampaignEventName,
                        string CampaignEventSDate, string CampaignEventEDate, string CampaignAttendanceFlag, string CampaignFeedbackFlag)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.VarChar);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p2.Value = Campaign_Id;
            SqlParameter p3 = new SqlParameter("@CampaignEventId", SqlDbType.VarChar);
            p3.Value = CampaignEventId;
            SqlParameter p4 = new SqlParameter("@CampaignEventName", SqlDbType.VarChar);
            p4.Value = CampaignEventName;
            SqlParameter p5 = new SqlParameter("@CampaignEventSDate", SqlDbType.VarChar);
            p5.Value = CampaignEventSDate;
            SqlParameter p6 = new SqlParameter("@CampaignEventEDate", SqlDbType.VarChar);
            p6.Value = CampaignEventEDate;
            SqlParameter p7 = new SqlParameter("@CampaignAttendanceFlag", SqlDbType.VarChar);
            p7.Value = CampaignAttendanceFlag;
            SqlParameter p8 = new SqlParameter("@CampaignFeedbackFlag", SqlDbType.VarChar);
            p8.Value = CampaignFeedbackFlag;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertUpdate_CampaignEvents", p, p1, p2, p3, p4, p5, p6, p7, p8));
        }

        public static DataSet InsertUpdate_CampaignEvents_Feedback(string Flag, string Userid, string Campaign_Id, string CampaignEventId, string CampaignEventFeedbackId, string FeedbackHeader)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.VarChar);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p2.Value = Campaign_Id;
            SqlParameter p3 = new SqlParameter("@CampaignEventId", SqlDbType.VarChar);
            p3.Value = CampaignEventId;
            SqlParameter p4 = new SqlParameter("@CampaignEventFeedbackId", SqlDbType.VarChar);
            p4.Value = CampaignEventFeedbackId;
            SqlParameter p5 = new SqlParameter("@FeedbackHeader", SqlDbType.VarChar);
            p5.Value = FeedbackHeader;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertUpdate_CampaignEventsFeedback", p, p1, p2, p3, p4, p5));
        }

        public static DataSet Get_CampaignFeedbackDetailByPKey(int Flag, string Userid, string Campaign_Id, string EventId)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p2.Value = Campaign_Id;
            SqlParameter p3 = new SqlParameter("@Campaign_Event_Id", SqlDbType.VarChar);
            p3.Value = EventId;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_CampaignDetailByPKey", p, p1, p2, p3));
        }

        public static DataSet Get_CampaignFeedbackValueByPKey(int Flag, string Userid, string Campaign_Id, string EventId, string Campaign_Event_Feedback_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p2.Value = Campaign_Id;
            SqlParameter p3 = new SqlParameter("@Campaign_Event_Id", SqlDbType.VarChar);
            p3.Value = EventId;
            SqlParameter p4 = new SqlParameter("@Campaign_Event_Feedback_Id", SqlDbType.VarChar);
            p4.Value = Campaign_Event_Feedback_Id;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_CampaignDetailByPKey", p, p1, p2, p3, p4));
        }

        public static DataSet InsertUpdate_CampaignEvents_Feedback_Values(string Flag, string Userid, string Campaign_Id, string CampaignEventId, string CampaignEventFeedbackId, string CampaignEventFeedbackValueId, string FeedbackHeaderValue)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.VarChar);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p2.Value = Campaign_Id;
            SqlParameter p3 = new SqlParameter("@CampaignEventId", SqlDbType.VarChar);
            p3.Value = CampaignEventId;
            SqlParameter p4 = new SqlParameter("@CampaignEventFeedbackId", SqlDbType.VarChar);
            p4.Value = CampaignEventFeedbackId;
            SqlParameter p5 = new SqlParameter("@CampaignEventFeedbackValueId", SqlDbType.VarChar);
            p5.Value = CampaignEventFeedbackValueId;
            SqlParameter p6 = new SqlParameter("@FeedbackHeaderValue", SqlDbType.VarChar);
            p6.Value = FeedbackHeaderValue;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertUpdate_CampaignEventsFeedback_Values", p, p1, p2, p3, p4, p5, p6));
        }


        public static DataSet Get_CampaignEvents_Contacts(int Flag, string Userid, string Value, string Opearator2, string ColName, string Opearator1, string Page_Number, string Campaign_Id, string CampaignEvent_Id)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Value", SqlDbType.VarChar);
            p2.Value = Value;
            SqlParameter p3 = new SqlParameter("@Opearator2", SqlDbType.VarChar);
            p3.Value = Opearator2;
            SqlParameter p4 = new SqlParameter("@ColName", SqlDbType.VarChar);
            p4.Value = ColName;
            SqlParameter p5 = new SqlParameter("@Opearator1", SqlDbType.VarChar);
            p5.Value = Opearator1;
            SqlParameter p6 = new SqlParameter("@Page_Number", SqlDbType.VarChar);
            p6.Value = Page_Number;
            SqlParameter p7 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p7.Value = Campaign_Id;
            SqlParameter p8 = new SqlParameter("@CampaignEvent_Id", SqlDbType.VarChar);
            p8.Value = CampaignEvent_Id;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_CampaignEvents_Contacts", p, p1, p2, p3, p4, p5, p6, p7, p8));
        }

        public static DataSet Insert_UPdate_Campaign_Events_Contacts_Assignment(string Flag, string Campaign_Id, string xmlData, string Created_By)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.VarChar);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@CampaignId", SqlDbType.VarChar);
            p1.Value = Campaign_Id;
            SqlParameter p2 = new SqlParameter("@xmlData", SqlDbType.VarChar);
            p2.Value = xmlData;
            SqlParameter p3 = new SqlParameter("@Created_By", SqlDbType.VarChar);
            p3.Value = Created_By;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Campaign_Events_AssignContacts_Insert", p, p1, p2, p3));
        }

        public static DataSet Insert_UPdate_CampaignEvents_Student_Attendance_Feedback(string Flag, string xmlData)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.VarChar);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@xmlData", SqlDbType.VarChar);
            p1.Value = xmlData;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CampaignEvents_Student_Attendance_Feedback", p, p1));
        }
        //Digambar Pending Admission Reasonwise
        public static DataSet GetPendingAdmission_Reasonwise(string Userid, string AcadYear, string DivisionCode, string CenterCode, string Page_Number)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            SqlParameter p5 = new SqlParameter("@Page_Number", Page_Number);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_STUDENT_PENDING_ADMISSION_Reasonwise", p1, p2, p3, p4, p5));
        }

        public static DataSet Get_AccountCancellation_Status(string Userid, string AcadYear, string DivisionCode, string CenterCode, string Page_Number)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            SqlParameter p5 = new SqlParameter("@Page_Number", Page_Number);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ADMISSION_CANCEL_STATUS", p1, p2, p3, p4, p5));
        }

        public static DataSet InsertUpdate_PendingAdmission_Reason(string Userid, string SBEntryCode, string PendingReason_Id, string ExpectedCloseDate, string Remarks)
        {
            SqlParameter p1 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@SBEntryCode", SqlDbType.VarChar);
            p2.Value = SBEntryCode;
            SqlParameter p3 = new SqlParameter("@PendingReason_Id", SqlDbType.VarChar);
            p3.Value = PendingReason_Id;
            SqlParameter p4 = new SqlParameter("@ExpectedCloseDate", SqlDbType.VarChar);
            p4.Value = ExpectedCloseDate;
            SqlParameter p5 = new SqlParameter("@Remark", SqlDbType.VarChar);
            p5.Value = Remarks;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertUpdate_STUDENT_PENDING_ADMISSION_Reason", p1, p2, p3, p4, p5));
        }

        public static DataSet Insert_BRS_BankUpload(string flag, string XMLData)
        {
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = flag;
            SqlParameter p2 = new SqlParameter("@xmlData", SqlDbType.VarChar);
            p2.Value = XMLData;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_BankDetails_Upload", p1, p2));
        }

        //public static DataSet BRS_BankUpload_Error(string flag)
        //{
        //    SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
        //    p1.Value = flag;

        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USB_BRS_Cheque_MisMatch", p1));
        //}

        public static DataSet BRS_BankUpload_Error(string flag, string user)
        {
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = flag;
            SqlParameter p2 = new SqlParameter("@userid", SqlDbType.VarChar);
            p2.Value = user;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USB_BRS_Cheque_MisMatch", p1, p2));
        }


        // added by sujeer 17-11-2017
        public static DataSet GetPendingAdmission_detailed(string pk)
        {
            SqlParameter p1 = new SqlParameter("@pk", pk);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_STUDENT_PENDING_ADMISSION_Reasonwise_Sumarry", p1));
        }

        public static DataSet Get_Bouncechequeagine(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division_Code", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center_Code", CenterCode);
            // SqlParameter p5 = new SqlParameter("", Page_Number);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Report_AGINGWISE_CONCISE", p1, p2, p3, p4));
        }

        //added by sujeer on 29-11-2017
        public static DataSet Get_Pendingadmissionaginedetails(string Userid, string AcadYear, string DivisionCode, string CenterCode, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            SqlParameter p5 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_GET_PENDING_AGEING_DETAILED]", p1, p2, p3, p4, p5));
        }

        public static DataSet Get_Blocked_cheque(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ALL_BLOCKED_CHEQUE", p1, p2, p3, p4));
        }
        public static DataSet Get_Deposited_cheque(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_GET_ALL_Deposited_CHEQUE]", p1, p2, p3, p4));
        }
        //added by Diganber-01-12-2017
        public static DataSet GetECS_Not_Acknowledged(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ECS_Not_Acknowledged", p1, p2, p3, p4));
        }

        public static DataSet GetECS_Declined(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ECS_Declined", p1, p2, p3, p4));
        }

        public static DataSet GetECS_Acknowledged(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ECS_Acknowledged", p1, p2, p3, p4));
        }

        public static DataSet GetECS_Dispatch_Dashboard(string Userid, string AcadYear, string DivisionCode, string CenterCode)
        {
            SqlParameter p1 = new SqlParameter("@Userid", Userid);
            SqlParameter p2 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p3 = new SqlParameter("@Division", DivisionCode);
            SqlParameter p4 = new SqlParameter("@Center", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_ECS_Dispatch_DashBoard_Detail", p1, p2, p3, p4));
        }

        //ADDED BY SUJEER MPUC REGISTRATION
        public static int InsertUpdateregistration_Center(string FName, string MName, string LName, string Student_Contact_No, string Student_Email_Id, string Address, string Parent_Name, string Parent_Contact_No, string Parent_Email_Id, string acadyear, string flag,
                   string Productname, string Preferred_Center_Code, string Preferred_Center_Name, string Pay_Mode, string Cheque_No, string MICR_Code, string Amount, string Pay_Type, string Cheque_Date,
            string DOB, string city, string schoolname, string Board, string Percentage, string status, string Remarks, string Fallowup, string Hostel,
            string Productcode, string Boradcode, string Statuscode)
        {
            SqlParameter p1 = new SqlParameter("@FName", FName);
            SqlParameter p2 = new SqlParameter("@MName", MName);
            SqlParameter p3 = new SqlParameter("@LName", LName);
            SqlParameter p4 = new SqlParameter("@Student_Contact_No", Student_Contact_No);
            SqlParameter p5 = new SqlParameter("@Student_Email_Id", Student_Email_Id);
            SqlParameter p6 = new SqlParameter("@Address", Address);
            SqlParameter p7 = new SqlParameter("@Parent_Name", Parent_Name);
            SqlParameter p8 = new SqlParameter("@Parent_Contact_No", Parent_Contact_No);
            SqlParameter p9 = new SqlParameter("@Parent_Email_Id", Parent_Email_Id);
            SqlParameter p10 = new SqlParameter("@acadyear", acadyear);
            SqlParameter p11 = new SqlParameter("@flag", flag);
            SqlParameter p12 = new SqlParameter("@subejct", Productname);
            SqlParameter p13 = new SqlParameter("@Preferred_Center_Code", Preferred_Center_Code);
            SqlParameter p14 = new SqlParameter("@Preferred_Center_Name", Preferred_Center_Name);
            SqlParameter p15 = new SqlParameter("@Pay_Mode", Pay_Mode);
            SqlParameter p16 = new SqlParameter("@Cheque_No", Cheque_No);
            SqlParameter p17 = new SqlParameter("@MICR_Code", MICR_Code);
            SqlParameter p18 = new SqlParameter("@Amount", Amount);
            SqlParameter p19 = new SqlParameter("@Pay_Type", Pay_Type);
            SqlParameter p20 = new SqlParameter("@Cheque_Date", Cheque_Date);
            SqlParameter p21 = new SqlParameter("@DBO", DOB);
            SqlParameter p22 = new SqlParameter("@city", city);
            SqlParameter p23 = new SqlParameter("@Schoolname", schoolname);
            SqlParameter p24 = new SqlParameter("@Board", Board);
            SqlParameter p25 = new SqlParameter("@Percentage", Percentage);
            SqlParameter p26 = new SqlParameter("@EnquiryStatus", status);
            SqlParameter p27 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p28 = new SqlParameter("@fallowup", Fallowup);
            SqlParameter p29 = new SqlParameter("@Hostel", Hostel);
            SqlParameter p30 = new SqlParameter("@Productcode", Productcode);
            SqlParameter p31 = new SqlParameter("@Boradcode", Boradcode);
            SqlParameter p32 = new SqlParameter("@Statuscode", Statuscode);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_ZRegistrationData", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p26, p27, p28, p29, p30, p31, p32));
        }

        public static DataSet GetStreamby_Center_Seminar(string CenterCode)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_byCenter_Seminar", p));
        }

        public static DataSet GetCenter_Seminar(string Div_Code, string flag)
        {
            SqlParameter p1 = new SqlParameter("@Div_Code", Div_Code);
            SqlParameter p2 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getCenter_Seminar", p1, p2));
        }

        public static DataSet Get_RegistrationDetail_Byno(string UID, string flag)
        {
            SqlParameter p = new SqlParameter("@UID", SqlDbType.VarChar);
            p.Value = UID;
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = flag;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Usp_getStudentDetail_ByNumber]", p, p1));
        }

        //added by sujeer for petty cash--05-01-2017
        public static DataSet GetAllActivePerod(string DivisionCode, string CenterCode)
        {

            SqlParameter p1 = new SqlParameter("@DIVISIONCODE", DivisionCode);
            SqlParameter p2 = new SqlParameter("@CENTERCODE", CenterCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GET_PERIOD_FOR_PETTYCASH_ENTRY", p1, p2));
        }

        public static DataSet GetAllPettycashentry(string DivisionCode, string CenterCode, string period)
        {

            SqlParameter p1 = new SqlParameter("@Division_Code", DivisionCode);
            SqlParameter p2 = new SqlParameter("@Centercode", CenterCode);
            SqlParameter p3 = new SqlParameter("@Periodid", period);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_GetAll_Pettycash_Entry]", p1, p2, p3));
        }


        public static DataSet GetAllPettycashexpenseType(string Voucherid, string flag)
        {
            SqlParameter p1 = new SqlParameter("@voucherid", Voucherid);
            SqlParameter p2 = new SqlParameter("@flag", flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_GetAll_PettyCash_Expense_Voucher]", p1, p2));
        }

        public static int Insert_Pettycashentry(string DivisionCode, string Centercode, string PeriodId, string Transdate, string VoucherNo, string ExpenseId, string Expensedoneby, string Description, string Amount, string Flag, string CreatedBy, string pettycashedit)
        {

            SqlParameter[] p = new SqlParameter[13];
            p[0] = new SqlParameter("@DivisionCode", DivisionCode);
            p[1] = new SqlParameter("@Centercode", Centercode);
            p[2] = new SqlParameter("@PeriodId", PeriodId);
            p[3] = new SqlParameter("@TransactionDate", Transdate);
            p[4] = new SqlParameter("@Voucher_No", VoucherNo);
            p[5] = new SqlParameter("@ExpenseTypeID", ExpenseId);
            p[6] = new SqlParameter("@ExpenseDoneBy", Expensedoneby);
            p[7] = new SqlParameter("@Description", Description);
            p[8] = new SqlParameter("@Amount", Amount);
            p[9] = new SqlParameter("@flag", Flag);
            p[10] = new SqlParameter("@CreatedBy", CreatedBy);
            p[11] = new SqlParameter("@pettycashCodeForEdit", pettycashedit);
            p[12] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[12].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_PettyCash_Entry", p);
            return (int.Parse(p[12].Value.ToString()));
        }


        public static DataSet GetAllPettycashentry_for_approval(string DivisionCode, string CenterCode, string period)
        {

            SqlParameter p1 = new SqlParameter("@Division_Code", DivisionCode);
            SqlParameter p2 = new SqlParameter("@Centercode", CenterCode);
            SqlParameter p3 = new SqlParameter("@Periodid", period);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_GetAll_Pettycash_Entry_For_Approval]", p1, p2, p3));
        }


        public static int Insert_Pettycashentry_For_approvals(string DivisionCode, string Centercode, string PeriodId, string vouchertype, string amount, string createdby, string flag)
        {

            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@DivisionCode", DivisionCode);
            p[1] = new SqlParameter("@Centercode", Centercode);
            p[2] = new SqlParameter("@PeriodId", PeriodId);
            p[3] = new SqlParameter("@Voucher_No", vouchertype);
            p[4] = new SqlParameter("@Amount", amount);
            p[5] = new SqlParameter("@CreatedBy", createdby);
            p[6] = new SqlParameter("@flag", flag);
            p[7] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[7].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_PettyCash_Entry_For_Approvals", p);
            return (int.Parse(p[7].Value.ToString()));
        }
        // added sujeer 02-04-2018
        public static DataSet GetoldSbentrycodeforPrint(string Sbentrycode)
        {
            SqlParameter p1 = new SqlParameter("@sbentrycode", Sbentrycode);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Use_Get_Old_Sbentrycode_For_print", p1));
        }

        // added for Hall tikect 27-11-2018
        public static int Insert_StudentSubeject(string DivisionCode, string centercode, string streamcode, string sbentrycode, string spid, string Subjects, string subjectname, string Acadyear, string CodeForEdit, string CreatedBy, string flag)
        {
            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@DIVISIONCODE", DivisionCode);
            p[1] = new SqlParameter("@CENTERCODE", centercode);
            p[2] = new SqlParameter("@STREAMCODE", streamcode);
            p[3] = new SqlParameter("@sbentrycode", sbentrycode);
            p[4] = new SqlParameter("@spid", spid);
            p[5] = new SqlParameter("@Subjectcode", Subjects);
            p[6] = new SqlParameter("@Subjectname", subjectname);
            p[7] = new SqlParameter("@Acadyear", Acadyear);
            p[8] = new SqlParameter("@CodeForEdit", CodeForEdit);
            p[9] = new SqlParameter("@CreatedBy", CreatedBy);
            p[10] = new SqlParameter("@FLAG", flag);
            p[11] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[11].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USB_INSERT_UPDATE_STUDENT_SUB_FOR_HALLTICKET", p);
            return (int.Parse(p[11].Value.ToString()));
        }

        public static int Chk_Page_Validation(string Pagename, string userid, string ApplicationNo)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@Pagename", Pagename);
            p[1] = new SqlParameter("@User_id", userid);
            p[2] = new SqlParameter("@ApplicationNo", ApplicationNo);

            p[3] = new SqlParameter("@count", SqlDbType.VarChar, 10);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Check_PageValidation", p);
            return Convert.ToInt32(p[3].Value.ToString());
        }

        //added for batchcopy
        public static DataSet GetBatchBy_Division_Year_Standard_Centre_new(string Division_Code, string YearName, string StandardCode, string CentreCode)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@Centre_Code", CentreCode);
            SqlParameter p6 = new SqlParameter("@Flag", 1);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatch_Division_Year_Standard_Centre_Product", p1, p2, p3, p4, p6));
        }
        public static DataSet GetBatchBY_PKey_with_Product(string Division_Code, string Acad_year, string Standered_Code, string Center_Code, string Product_code, string Flag)
        {
            //Try
            SqlParameter p1 = new SqlParameter("@DivisionCode", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acadyear", Acad_year);
            SqlParameter p3 = new SqlParameter("@standredCode", Standered_Code);
            SqlParameter p4 = new SqlParameter("@centerCode", Center_Code);
            SqlParameter p5 = new SqlParameter("@ProductCode", Product_code);
            SqlParameter p6 = new SqlParameter("@Flag", Flag);
            //DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USB_GET_STUDENTDETAILS_FOR_BATCHCOPY", p1, p2, p3, p4, p5, p6);
            DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Get_StudentData_For_BatchCopy_New", p1, p2, p3, p4, p5, p6);
            return (XYZ);
        }

        public static DataSet GetBatchBy_Division_Year_Standard_Centre_ForProduct(string Division_Code, string YearName, string StandardCode, string CentreCode)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@Centre_Code", CentreCode);
            SqlParameter p6 = new SqlParameter("@Flag", 2);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatch_Division_Year_Standard_Centre_Product", p1, p2, p3, p4, p6));
        }

        public static DataSet GetAllActive_Product_Batch(string Division_Code, string YearName, string course,string CenterCode ,string Product, string batchcode, int flag)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@coursecode", course);
            SqlParameter p4 = new SqlParameter("@Centercode", CenterCode);
            SqlParameter p5 = new SqlParameter("@productcode", Product);
            SqlParameter p6 = new SqlParameter("@batchcode", batchcode);
            SqlParameter p7 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Get_Batch_Details_For_Batchcopy]", p1, p2, p3, p4, p5,p6,p7));
        }

        public static int Insert_Newbatchdetails(string DivisionCode, string StandardCode, string Productcode, string centercode, string sbentrycode, string spid, string batchcode,  string CreatedBy, string Acad_year, string flag)
        {
            SqlParameter[] p = new SqlParameter[11];
            p[0] = new SqlParameter("@DIVISIONCODE", DivisionCode);
            p[1] = new SqlParameter("@coursecode", StandardCode);
            p[2] = new SqlParameter("@Productcode", Productcode);
            p[3] = new SqlParameter("@CENTERCODE", centercode);
            p[4] = new SqlParameter("@sbentrycode", sbentrycode);
            p[5] = new SqlParameter("@spid", spid);
            p[6] = new SqlParameter("@BatchCode", batchcode);
            p[7] = new SqlParameter("@CreatedBy", CreatedBy);
            p[8] = new SqlParameter("@Acadyear", Acad_year);
            p[9] = new SqlParameter("@FLAG", flag);
            p[10] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[10].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UPDATE_INSERT_STUDENT_BACTHDETAILS_NEW", p);
            return (int.Parse(p[10].Value.ToString()));
        }

    }

}



