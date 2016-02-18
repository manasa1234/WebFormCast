using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACLGDataAaccess;
using System.Data.SqlClient; 
/// <summary>
/// Summary description for clsForm_i129H
/// </summary>
/// 
namespace WebFormCast.ACLG
{

    public class Form_i129H
    {
        string strSql = "";
        public bool isApproved = false;
        int Employee_id = 0;
        public string f1_Person_Last_Name = "";
        public string f1_Person_First_Name = "";
        public string f1_Person_Middle_Name = "";
        public string f1_Person_Telephone = "";
        public string f1_Person_Telephone_Code = "";
        public string f1_CompanyName = "";
        public string f1_CompanyPhone = "";
        public string f1_CompanyPhone_Code = "";
        public string f1_CompanyStreet = "";
        public string f1_CompanySuite = "";
        public string f1_CompanyInCareOf = "";
        public string f1_CompanyCity = "";
        public string f1_CompanyState = "";
        public string f1_CompanyCountry = "";
        public string f1_CompanyZip = "";
        public string f1_CompanyEmail = "";
        public string f1_CompanyFederalIdentification = "";
        public string f1_ComapnySocialSecurity = "";
        public string f1_CompanyIndividualTax = "";
        public string f1_ATTY_State_License = "";
        public string f2_Prior_Petition = "";
        public string f2_RequestedNonimmigrantClassification = "";
        public string f2_Totalnumberofworkersinpetition = "";
        public int f2_BasisforClassification = 0;
        public int f2_RequestedAction = 0;
        public string f2_receipt_number = "";
        public string f3_Entertainment_Group_Name = "";
        public string f3_Last_Name = "";
        public string f3_First_Name = "";
        public string f3_Middle_Name = "";
        public string f3_Other_Name1 = "";
        public string f3_Other_Name2 = "";
        public string f3_Other_Name3 = "";
        public string f3_Date_of_Birth = "";
        public string f3_US_Social_Security = "";
        public string f3_Anumber = "";
        public string f3_Country_of_Birth = "";
        public string f3_Province_of_Birth = "";
        public string f3_Country_of_Citizenship = "";
        public string f3_Date_of_Last_Arrival = "";
        public string f3_I94 = "";
        public string f3_Current_Nonimmigrant_Status = "";
        public string f3_Date_Status_Expires = "";
        public string f3_Passport_Number = "";
        public string f3_Date_Passport_Issued = "";
        public string f3_Date_Passport_Expires = "";
        public string f3_Current_US_Address = "";

        public int f4_Type_of_Office = 0;
        public string f4_Office_Address = "";
        public string f4_US_State_or_Foreign_Country = "";
        public string f4_Persons_Foreign_Address = "";
        public int f4_Have_a_valid_passpor = 0;
        public bool f4_Anyother_petitions = false;
        public string f4_Anyother_petitions_HowMany = "";
        public bool f4_Are_applications_for_replacement = false;
        public string f4_Are_applications_for_replacement_howmany = "";
        public bool f4_dependents_being_filed = false;
        public string f4_dependents_being_filed_HowMany = "";
        public bool f4_Removal_proceedings = false;
        public bool f4_Have_you_ever_filed_an_immigrant_petition = false;
        public bool f4_Thepast_seven_years1 = false;
        public bool f4_Thepast_seven_years2 = false;
        public bool f4_Ever_previously_filed_a_petition_for_this_perso = false;
        public bool f4_If_you_are_filing_for_an_entertainment_group = false;

        public string f5_Job_Title = "";
        public string f5_Nontechnical_Job_Description = "";
        public string f5_LCA_Case_Number = "";
        public string f5_NAICS_Code = "";
        public string f5_different_from_address = "";
        public bool f5_Is_this_a_fulltime_position = false;
        public string f5_Hours_per_week = "";
        public string f5_Wages_per_week_Year = "";
        public string f5_Other_Compensation = "";
        public string f5_Dates_of_intended_employment1 = "";
        public string f5_Dates_of_intended_employment2 = "";
        public int f5_Type_of_Petitioner = 0;
        public string f5_Type_of_Business = "";
        public string f5_Year_Established = "";
        public string f5_Current_Number_of_Employees = "";
        public string f5_Gross_Annual_Income = "";
        public string f5_Net_Annual_Income = "";

        public string f6_Daytime_Phone_Number1 = "";
        public string f6_Daytime_Phone_Number1_Code = "";
        public string f6_Daytime_Phone_Number2_Code = "";
        public string f6_Print_Name1 = "";
        public string f6_Date1 = "";
        public string f6_Daytime_Phone_Number2 = "";
        public string f6_Print_Name2 = "";
        public string f6_Firm_Name_and_Address = "";
        public string f6_Date2 = "";
        public string f8_Name_of_organization_filing_petition = "";
        public string f8_Name_of_person = "";
        public int f8_Classification_sought = 0;
        public string f8_Describe_the_proposed_duties = "";
        public string f8_Aliens_present_occupation = "";
        public string f8_Print_or_Type_Name1 = "";
        public string f8_Print_or_Type_Name2 = "";
        public string f8_DATE1 = "";
        public string f8_DATE2 = "";
        public string f8_SubjectsName1 = "";
        public string f8_SubjectsName2 = "";
        public string f8_SubjectsName3 = "";
        public string f8_SubjectsName4 = "";

        public string f8_Period_From1 = "";
        public string f8_Period_From2 = "";
        public string f8_Period_From3 = "";
        public string f8_Period_From4 = "";

        public string f8_Period_To1 = "";
        public string f8_Period_To2 = "";
        public string f8_Period_To3 = "";
        public string f8_Period_To4 = "";






        public string f11_Petitioners_Name = "";
        public bool f11_Is_the_petitioner_a_dependent_employer = false;
        public bool f11_found_to_be_a_willful_violator = false;
        public bool f11_exempt_H1B_nonimmigrant1 = false;
        public bool f11_exempt_H1B_nonimmigrant2 = false;
        public bool f11_BeneficiaryAnnualMaster = false;
        public string f11_Beneficiarys_Last_Name = "";
        public string f11_First_Name = "";
        public string f11_Middle_Name = "";
        public string f11_In_Care_Of = "";
        public string f11_Current_Street_Number_and_Name = "";
        public string f11_AptNo = "";
        public string f11_City = "";
        public string f11_State = "";
        public string f11_Zip = "";
        public string f11_Social_Security = "";
        public string f11_I94 = "";
        public string f11_Previous_Receipt = "";
        public int f11_Highest_Level_of_Education = 0;
        public string f11_Primary_Field_of_Study = "";
        public bool f11_higher_degree_from_a_US = false;
        public string f11_Name_of_the_US_institution = "";
        public string f11_Date_Degree_Awarded = "";
        public string f11_Type_of_US_Degree = "";
        public string f11_Address_of_the_US_institution = "";
        public string f11_Rate_of_Pay_Per_Year = "";
        public string f11_LCA_Code = "";
        public string f11_NAICS_Code = "";

        public bool f12_Fee_Exemption_1 = false;
        public bool f12_Fee_Exemption_2 = false;
        public bool f12_Fee_Exemption_3 = false;
        public bool f12_Fee_Exemption_4 = false;
        public bool f12_Fee_Exemption_5 = false;
        public bool f12_Fee_Exemption_6 = false;
        public bool f12_Fee_Exemption_7 = false;
        public bool f12_Fee_Exemption_8 = false;
        public bool f12_Fee_Exemption_9 = false;
        public bool f12_Numerical_Limitation_1 = false;
        public bool f12_Numerical_Limitation_2 = false;
        public bool f12_Numerical_Limitation_3 = false;
        public bool f12_Numerical_Limitation_4 = false;
        public bool f12_Numerical_Limitation_5 = false;
        public bool f12_Numerical_Limitation_6 = false;
        public bool f12_Numerical_Limitation_7 = false;
        public bool f12_Numerical_Limitation_8 = false;
        public string strLastError = "";



        public string f13_Print_Name = "";
        public string f13_Title = "";

        


	    public Form_i129H()
	    {
		
        }
        public Form_i129H(int intEmployeeId)
        {
            Employee_id = intEmployeeId;
            Initialize(intEmployeeId);
            //Form_I129H_SELECT

        }


        protected void Initialize(int intEmployeeId)
        {
            ACLGDB DB = new ACLGDB();

            DataSet Ds = new DataSet();

            Ds = DB.getSPResults("Form_I129H_SELECT", "@Employee_id", intEmployeeId.ToString());

            if (Ds.Tables[0].Rows.Count > 0)
            {
                isApproved = true;
                f1_Person_Last_Name=Ds.Tables[0].Rows[0]["f1_Person_Last_Name"].ToString();
                f1_Person_First_Name=Ds.Tables[0].Rows[0]["f1_Person_First_Name"].ToString();
                f1_Person_Middle_Name=Ds.Tables[0].Rows[0]["f1_Person_Middle_Name"].ToString();
                f1_Person_Telephone=Ds.Tables[0].Rows[0]["f1_Person_Telephone"].ToString();
                f1_Person_Telephone_Code = Ds.Tables[0].Rows[0]["f1_Person_Telephone_Code"].ToString();
                f1_CompanyName=Ds.Tables[0].Rows[0]["f1_CompanyName"].ToString();
                f1_CompanyPhone=Ds.Tables[0].Rows[0]["f1_CompanyPhone"].ToString();
                f1_CompanyPhone_Code  = Ds.Tables[0].Rows[0]["f1_CompanyPhone_Code"].ToString();
                f1_CompanyStreet=Ds.Tables[0].Rows[0]["f1_CompanyStreet"].ToString();
                f1_CompanySuite=Ds.Tables[0].Rows[0]["f1_CompanySuite"].ToString();
                f1_CompanyInCareOf=Ds.Tables[0].Rows[0]["f1_CompanyInCareOf"].ToString();
                f1_CompanyCity=Ds.Tables[0].Rows[0]["f1_CompanyCity"].ToString();
                f1_CompanyState=Ds.Tables[0].Rows[0]["f1_CompanyState"].ToString();
                f1_CompanyCountry=Ds.Tables[0].Rows[0]["f1_CompanyCountry"].ToString();
                f1_CompanyZip=Ds.Tables[0].Rows[0]["f1_CompanyZip"].ToString();
                f1_CompanyEmail=Ds.Tables[0].Rows[0]["f1_CompanyEmail"].ToString();
                f1_CompanyFederalIdentification=Ds.Tables[0].Rows[0]["f1_CompanyFederalIdentification"].ToString();
                f1_ComapnySocialSecurity=Ds.Tables[0].Rows[0]["f1_ComapnySocialSecurity"].ToString();
                f1_CompanyIndividualTax=Ds.Tables[0].Rows[0]["f1_CompanyIndividualTax"].ToString();
                f1_ATTY_State_License=Ds.Tables[0].Rows[0]["f1_ATTY_State_License"].ToString();
                f2_Prior_Petition=Ds.Tables[0].Rows[0]["f2_Prior_Petition"].ToString();
                f2_RequestedNonimmigrantClassification=Ds.Tables[0].Rows[0]["f2_RequestedNonimmigrantClassification"].ToString();
                f2_Totalnumberofworkersinpetition=Ds.Tables[0].Rows[0]["f2_Totalnumberofworkersinpetition"].ToString();
                if(Ds.Tables[0].Rows[0]["f2_BasisforClassification"] != DBNull.Value)
                    f2_BasisforClassification= Convert.ToInt32(Ds.Tables[0].Rows[0]["f2_BasisforClassification"].ToString());
                if(Ds.Tables[0].Rows[0]["f2_RequestedAction"].ToString()!="")
                    f2_RequestedAction= Convert.ToInt32(Ds.Tables[0].Rows[0]["f2_RequestedAction"].ToString());
                f2_receipt_number=Ds.Tables[0].Rows[0]["f2_receipt_number"].ToString();
                f3_Entertainment_Group_Name=Ds.Tables[0].Rows[0]["f3_Entertainment_Group_Name"].ToString();
                f3_Last_Name=Ds.Tables[0].Rows[0]["f3_Last_Name"].ToString();
                f3_First_Name=Ds.Tables[0].Rows[0]["f3_First_Name"].ToString();
                f3_Middle_Name=Ds.Tables[0].Rows[0]["f3_Middle_Name"].ToString();
                f3_Other_Name1=Ds.Tables[0].Rows[0]["f3_Other_Name1"].ToString();
                f3_Other_Name2=Ds.Tables[0].Rows[0]["f3_Other_Name2"].ToString();
                f3_Other_Name3=Ds.Tables[0].Rows[0]["f3_Other_Name3"].ToString();
                f3_Date_of_Birth=Ds.Tables[0].Rows[0]["f3_Date_of_Birth"].ToString();
                f3_US_Social_Security=Ds.Tables[0].Rows[0]["f3_US_Social_Security"].ToString();
                f3_Anumber=Ds.Tables[0].Rows[0]["f3_Anumber"].ToString();
                f3_Country_of_Birth=Ds.Tables[0].Rows[0]["f3_Country_of_Birth"].ToString();
                f3_Province_of_Birth=Ds.Tables[0].Rows[0]["f3_Province_of_Birth"].ToString();
                f3_Country_of_Citizenship=Ds.Tables[0].Rows[0]["f3_Country_of_Citizenship"].ToString();
                f3_Date_of_Last_Arrival=Ds.Tables[0].Rows[0]["f3_Date_of_Last_Arrival"].ToString();
                f3_I94=Ds.Tables[0].Rows[0]["f3_I94"].ToString();
                f3_Current_Nonimmigrant_Status=Ds.Tables[0].Rows[0]["f3_Current_Nonimmigrant_Status"].ToString();
                f3_Date_Status_Expires=Ds.Tables[0].Rows[0]["f3_Date_Status_Expires"].ToString();
                f3_Passport_Number=Ds.Tables[0].Rows[0]["f3_Passport_Number"].ToString();
                f3_Date_Passport_Issued=Ds.Tables[0].Rows[0]["f3_Date_Passport_Issued"].ToString();
                f3_Date_Passport_Expires=Ds.Tables[0].Rows[0]["f3_Date_Passport_Expires"].ToString();
                f3_Current_US_Address=Ds.Tables[0].Rows[0]["f3_Current_US_Address"].ToString();

                if(Ds.Tables[0].Rows[0]["f4_Type_of_Office"]!= DBNull.Value) 
                    f4_Type_of_Office= Convert.ToInt32(Ds.Tables[0].Rows[0]["f4_Type_of_Office"].ToString());

                f4_Office_Address=Ds.Tables[0].Rows[0]["f4_Office_Address"].ToString();
                f4_US_State_or_Foreign_Country=Ds.Tables[0].Rows[0]["f4_US_State_or_Foreign_Country"].ToString();
                f4_Persons_Foreign_Address=Ds.Tables[0].Rows[0]["f4_Persons_Foreign_Address"].ToString();
                if(Ds.Tables[0].Rows[0]["f4_Have_a_valid_passpor"].ToString()!="")
                    f4_Have_a_valid_passpor= Convert.ToInt32(Ds.Tables[0].Rows[0]["f4_Have_a_valid_passpor"].ToString());

                if(Ds.Tables[0].Rows[0]["f4_Anyother_petitions"].ToString()!="")
                    f4_Anyother_petitions=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f4_Anyother_petitions"].ToString());
                f4_Anyother_petitions_HowMany=Ds.Tables[0].Rows[0]["f4_Anyother_petitions_HowMany"].ToString();
                if(Ds.Tables[0].Rows[0]["f4_Are_applications_for_replacement"].ToString()!="")
                    f4_Are_applications_for_replacement=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f4_Are_applications_for_replacement"].ToString());
                f4_Are_applications_for_replacement_howmany=Ds.Tables[0].Rows[0]["f4_Are_applications_for_replacement_howmany"].ToString();
                if(Ds.Tables[0].Rows[0]["f4_dependents_being_filed"].ToString()!="")
                    f4_dependents_being_filed=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f4_dependents_being_filed"].ToString());
                f4_dependents_being_filed_HowMany=Ds.Tables[0].Rows[0]["f4_dependents_being_filed_HowMany"].ToString();
                if(Ds.Tables[0].Rows[0]["f4_Removal_proceedings"].ToString()!="")
                    f4_Removal_proceedings=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f4_Removal_proceedings"].ToString());
                if(Ds.Tables[0].Rows[0]["f4_Have_you_ever_filed_an_immigrant_petition"].ToString()!="")
                    f4_Have_you_ever_filed_an_immigrant_petition=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f4_Have_you_ever_filed_an_immigrant_petition"].ToString());
                if(Ds.Tables[0].Rows[0]["f4_Thepast_seven_years1"].ToString()!="")
                    f4_Thepast_seven_years1=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f4_Thepast_seven_years1"].ToString());
                if(Ds.Tables[0].Rows[0]["f4_Thepast_seven_years2"].ToString()!="")
                    f4_Thepast_seven_years2=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f4_Thepast_seven_years2"].ToString());
                if(Ds.Tables[0].Rows[0]["f4_Ever_previously_filed_a_petition_for_this_perso"].ToString()!="")
                    f4_Ever_previously_filed_a_petition_for_this_perso=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f4_Ever_previously_filed_a_petition_for_this_perso"].ToString());
                if(Ds.Tables[0].Rows[0]["f4_If_you_are_filing_for_an_entertainment_group"].ToString()!="")
                    f4_If_you_are_filing_for_an_entertainment_group=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f4_If_you_are_filing_for_an_entertainment_group"].ToString());
                f5_Job_Title=Ds.Tables[0].Rows[0]["f5_Job_Title"].ToString();
                f5_Nontechnical_Job_Description=Ds.Tables[0].Rows[0]["f5_Nontechnical_Job_Description"].ToString();
                f5_LCA_Case_Number=Ds.Tables[0].Rows[0]["f5_LCA_Case_Number"].ToString();
                f5_NAICS_Code=Ds.Tables[0].Rows[0]["f5_NAICS_Code"].ToString();
                f5_different_from_address=Ds.Tables[0].Rows[0]["f5_different_from_address"].ToString();
                if(Ds.Tables[0].Rows[0]["f5_Is_this_a_fulltime_position"].ToString()!="")
                    f5_Is_this_a_fulltime_position=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f5_Is_this_a_fulltime_position"].ToString());
                f5_Hours_per_week=Ds.Tables[0].Rows[0]["f5_Hours_per_week"].ToString();
                f5_Wages_per_week_Year = Ds.Tables[0].Rows[0]["f5_Wages_per_week_Year"].ToString();
                
                f5_Other_Compensation=Ds.Tables[0].Rows[0]["f5_Other_Compensation"].ToString();
                f5_Dates_of_intended_employment1=Ds.Tables[0].Rows[0]["f5_Dates_of_intended_employment1"].ToString();
                f5_Dates_of_intended_employment2=Ds.Tables[0].Rows[0]["f5_Dates_of_intended_employment2"].ToString();
                if(Ds.Tables[0].Rows[0]["f5_Type_of_Petitioner"].ToString()!="")
                    f5_Type_of_Petitioner= Convert.ToInt32(Ds.Tables[0].Rows[0]["f5_Type_of_Petitioner"].ToString());
                f5_Type_of_Business=Ds.Tables[0].Rows[0]["f5_Type_of_Business"].ToString();
                f5_Year_Established=Ds.Tables[0].Rows[0]["f5_Year_Established"].ToString();
                f5_Current_Number_of_Employees=Ds.Tables[0].Rows[0]["f5_Current_Number_of_Employees"].ToString();
                f5_Gross_Annual_Income=Ds.Tables[0].Rows[0]["f5_Gross_Annual_Income"].ToString();
                f5_Net_Annual_Income=Ds.Tables[0].Rows[0]["f5_Net_Annual_Income"].ToString();
                f6_Daytime_Phone_Number1=Ds.Tables[0].Rows[0]["f6_Daytime_Phone_Number1"].ToString();

                f6_Daytime_Phone_Number1_Code = Ds.Tables[0].Rows[0]["f6_Daytime_Phone_Number1_Code"].ToString();
                f6_Daytime_Phone_Number2_Code = Ds.Tables[0].Rows[0]["f6_Daytime_Phone_Number2_Code"].ToString();
                

                f6_Print_Name1=Ds.Tables[0].Rows[0]["f6_Print_Name1"].ToString();
                f6_Date1=Ds.Tables[0].Rows[0]["f6_Date1"].ToString();
                f6_Daytime_Phone_Number2=Ds.Tables[0].Rows[0]["f6_Daytime_Phone_Number2"].ToString();
                f6_Print_Name2=Ds.Tables[0].Rows[0]["f6_Print_Name2"].ToString();
                f6_Firm_Name_and_Address=Ds.Tables[0].Rows[0]["f6_Firm_Name_and_Address"].ToString();
                f6_Date2=Ds.Tables[0].Rows[0]["f6_Date2"].ToString();
                f8_Name_of_organization_filing_petition=Ds.Tables[0].Rows[0]["f8_Name_of_organization_filing_petition"].ToString();
                f8_Name_of_person=Ds.Tables[0].Rows[0]["f8_Name_of_person"].ToString();
                if(Ds.Tables[0].Rows[0]["f8_Classification_sought"].ToString()!="")
                    f8_Classification_sought= Convert.ToInt32(Ds.Tables[0].Rows[0]["f8_Classification_sought"].ToString());
                f8_Describe_the_proposed_duties=Ds.Tables[0].Rows[0]["f8_Describe_the_proposed_duties"].ToString();
                f8_Aliens_present_occupation=Ds.Tables[0].Rows[0]["f8_Aliens_present_occupation"].ToString();
                f8_Print_or_Type_Name1=Ds.Tables[0].Rows[0]["f8_Print_or_Type_Name1"].ToString();
                f8_Print_or_Type_Name2=Ds.Tables[0].Rows[0]["f8_Print_or_Type_Name2"].ToString();
                f8_DATE1=Ds.Tables[0].Rows[0]["f8_DATE1"].ToString();
                f8_DATE2=Ds.Tables[0].Rows[0]["f8_DATE2"].ToString();

                f8_SubjectsName1 = Ds.Tables[0].Rows[0]["f8_SubjectsName1"].ToString();
                f8_SubjectsName2 = Ds.Tables[0].Rows[0]["f8_SubjectsName2"].ToString();
                f8_SubjectsName3 = Ds.Tables[0].Rows[0]["f8_SubjectsName3"].ToString();
                f8_SubjectsName4 = Ds.Tables[0].Rows[0]["f8_SubjectsName4"].ToString();
                f8_Period_From1 = Ds.Tables[0].Rows[0]["f8_Period_From1"].ToString();
                f8_Period_From2 = Ds.Tables[0].Rows[0]["f8_Period_From2"].ToString();
                f8_Period_From3 = Ds.Tables[0].Rows[0]["f8_Period_From3"].ToString();
                f8_Period_From4 = Ds.Tables[0].Rows[0]["f8_Period_From4"].ToString();
                f8_Period_To1 = Ds.Tables[0].Rows[0]["f8_Period_To1"].ToString();
                f8_Period_To2 = Ds.Tables[0].Rows[0]["f8_Period_To2"].ToString();
                f8_Period_To3 = Ds.Tables[0].Rows[0]["f8_Period_To3"].ToString();
                f8_Period_To4 = Ds.Tables[0].Rows[0]["f8_Period_To4"].ToString();


                f11_Petitioners_Name=Ds.Tables[0].Rows[0]["f11_Petitioners_Name"].ToString();
                if(Ds.Tables[0].Rows[0]["f11_Is_the_petitioner_a_dependent_employer"].ToString()!="")
                    f11_Is_the_petitioner_a_dependent_employer=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f11_Is_the_petitioner_a_dependent_employer"].ToString());
                if(Ds.Tables[0].Rows[0]["f11_found_to_be_a_willful_violator"].ToString()!="")
                    f11_found_to_be_a_willful_violator=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f11_found_to_be_a_willful_violator"].ToString());
                if(Ds.Tables[0].Rows[0]["f11_exempt_H1B_nonimmigrant1"].ToString()!="")
                f11_exempt_H1B_nonimmigrant1=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f11_exempt_H1B_nonimmigrant1"].ToString());
                if(Ds.Tables[0].Rows[0]["f11_exempt_H1B_nonimmigrant2"].ToString()!="")
                f11_exempt_H1B_nonimmigrant2=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f11_exempt_H1B_nonimmigrant2"].ToString());

                if (Ds.Tables[0].Rows[0]["f11_BeneficiaryAnnualMaster"].ToString() != "")
                    f11_BeneficiaryAnnualMaster  = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f11_BeneficiaryAnnualMaster"].ToString());

                
                f11_Beneficiarys_Last_Name=Ds.Tables[0].Rows[0]["f11_Beneficiarys_Last_Name"].ToString();
                f11_First_Name=Ds.Tables[0].Rows[0]["f11_First_Name"].ToString();
                f11_Middle_Name=Ds.Tables[0].Rows[0]["f11_Middle_Name"].ToString();
                f11_In_Care_Of=Ds.Tables[0].Rows[0]["f11_In_Care_Of"].ToString();
                f11_Current_Street_Number_and_Name=Ds.Tables[0].Rows[0]["f11_Current_Street_Number_and_Name"].ToString();
                f11_AptNo=Ds.Tables[0].Rows[0]["f11_AptNo"].ToString();
                f11_City = Ds.Tables[0].Rows[0]["f11_City"].ToString();
                f11_State = Ds.Tables[0].Rows[0]["f11_State"].ToString();
                f11_Zip = Ds.Tables[0].Rows[0]["f11_Zip"].ToString();
                f11_Social_Security=Ds.Tables[0].Rows[0]["f11_Social_Security"].ToString();
                f11_I94=Ds.Tables[0].Rows[0]["f11_I94"].ToString();
                f11_Previous_Receipt=Ds.Tables[0].Rows[0]["f11_Previous_Receipt"].ToString();
                if(Ds.Tables[0].Rows[0]["f11_Highest_Level_of_Education"].ToString()!="")
                f11_Highest_Level_of_Education= Convert.ToInt32(Ds.Tables[0].Rows[0]["f11_Highest_Level_of_Education"].ToString());
                f11_Primary_Field_of_Study=Ds.Tables[0].Rows[0]["f11_Primary_Field_of_Study"].ToString();
                if(Ds.Tables[0].Rows[0]["f11_higher_degree_from_a_US"].ToString()!="")
                    f11_higher_degree_from_a_US=Convert.ToBoolean(Ds.Tables[0].Rows[0]["f11_higher_degree_from_a_US"].ToString());
                f11_Name_of_the_US_institution=Ds.Tables[0].Rows[0]["f11_Name_of_the_US_institution"].ToString();
                f11_Date_Degree_Awarded=Ds.Tables[0].Rows[0]["f11_Date_Degree_Awarded"].ToString();
                f11_Type_of_US_Degree=Ds.Tables[0].Rows[0]["f11_Type_of_US_Degree"].ToString();
                f11_Address_of_the_US_institution=Ds.Tables[0].Rows[0]["f11_Address_of_the_US_institution"].ToString();
                f11_Rate_of_Pay_Per_Year=Ds.Tables[0].Rows[0]["f11_Rate_of_Pay_Per_Year"].ToString();
                f11_LCA_Code=Ds.Tables[0].Rows[0]["f11_LCA_Code"].ToString();
                f11_NAICS_Code=Ds.Tables[0].Rows[0]["f11_NAICS_Code"].ToString();
                f13_Print_Name=Ds.Tables[0].Rows[0]["f13_Print_Name"].ToString();
                f13_Title=Ds.Tables[0].Rows[0]["f13_Title"].ToString();

                if (Ds.Tables[0].Rows[0]["f12_Fee_Exemption_1"].ToString() != "")
                    f12_Fee_Exemption_1 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Fee_Exemption_1"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Fee_Exemption_2"].ToString() != "")
                    f12_Fee_Exemption_2 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Fee_Exemption_2"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Fee_Exemption_3"].ToString() != "")
                    f12_Fee_Exemption_3 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Fee_Exemption_3"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Fee_Exemption_4"].ToString() != "")
                    f12_Fee_Exemption_4 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Fee_Exemption_4"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Fee_Exemption_5"].ToString() != "")
                    f12_Fee_Exemption_5 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Fee_Exemption_5"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Fee_Exemption_6"].ToString() != "")
                    f12_Fee_Exemption_6 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Fee_Exemption_6"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Fee_Exemption_7"].ToString() != "")
                    f12_Fee_Exemption_7 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Fee_Exemption_7"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Fee_Exemption_8"].ToString() != "")
                    f12_Fee_Exemption_8 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Fee_Exemption_8"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Fee_Exemption_9"].ToString() != "")
                    f12_Fee_Exemption_9 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Fee_Exemption_9"].ToString());

                if (Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_1"].ToString() != "")
                    f12_Numerical_Limitation_1 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_1"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_2"].ToString() != "")
                    f12_Numerical_Limitation_2 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_2"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_3"].ToString() != "")
                    f12_Numerical_Limitation_3 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_3"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_4"].ToString() != "")
                    f12_Numerical_Limitation_4 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_4"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_5"].ToString() != "")
                    f12_Numerical_Limitation_5 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_5"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_6"].ToString() != "")
                    f12_Numerical_Limitation_6 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_6"].ToString());
                if (Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_7"].ToString() != "")
                    f12_Numerical_Limitation_7 = Convert.ToBoolean(Ds.Tables[0].Rows[0]["f12_Numerical_Limitation_7"].ToString());
                
            }

        }


        public bool Form_01_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql = "Update Form_I129H set ";
                strSql += "f1_Person_Last_Name='" + f1_Person_Last_Name + "'";
                strSql += ",f1_Person_First_Name='" + f1_Person_First_Name + "'";
                strSql += ",f1_Person_Middle_Name='" + f1_Person_Middle_Name + "'";
                strSql += ",f1_Person_Telephone='" + f1_Person_Telephone + "'";
                strSql += ",f1_Person_Telephone_Code='" + f1_Person_Telephone_Code + "'";
                strSql += ",f1_CompanyName='" + f1_CompanyName + "'";
                strSql += ",f1_CompanyPhone='" + f1_CompanyPhone + "'";
                strSql += ",f1_CompanyPhone_Code='" + f1_CompanyPhone_Code + "'";
                strSql += ",f1_CompanyStreet='" + f1_CompanyStreet + "'";
                strSql += ",f1_CompanySuite='" + f1_CompanySuite + "'";
                strSql += ",f1_CompanyInCareOf='" + f1_CompanyInCareOf + "'";
                strSql += ",f1_CompanyCity='" + f1_CompanyCity + "'";
                strSql += ",f1_CompanyState='" + f1_CompanyState + "'";
                strSql += ",f1_CompanyCountry='" + f1_CompanyCountry + "'";
                strSql += ",f1_CompanyZip='" + f1_CompanyZip + "'";
                strSql += ",f1_CompanyEmail='" + f1_CompanyEmail + "'";
                strSql += ",f1_CompanyFederalIdentification='" + f1_CompanyFederalIdentification + "'";
                strSql += ",f1_ComapnySocialSecurity='" + f1_ComapnySocialSecurity + "'";
                strSql += ",f1_CompanyIndividualTax='" + f1_CompanyIndividualTax + "'";
                strSql += ",f1_ATTY_State_License='" + f1_ATTY_State_License + "'";
                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Form_02_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql = "Update Form_I129H set ";
                strSql += "f2_Prior_Petition='" + f2_Prior_Petition + "'";
                strSql += ",f2_RequestedNonimmigrantClassification='" + f2_RequestedNonimmigrantClassification + "'";
                strSql += ",f2_Totalnumberofworkersinpetition='" + f2_Totalnumberofworkersinpetition + "'";
                strSql += ",f2_BasisforClassification=" + f2_BasisforClassification + "";
                strSql += ",f2_RequestedAction=" + f2_RequestedAction + "";
                strSql += ",f2_receipt_number='" + f2_receipt_number + "'";

                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Form_03_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql = "Update Form_I129H set ";
                strSql += "f3_Entertainment_Group_Name='" + f3_Entertainment_Group_Name + "'";
                strSql += ",f3_Last_Name='" + f3_Last_Name + "'";
                strSql += ",f3_First_Name='" + f3_First_Name + "'";
                strSql += ",f3_Middle_Name='" + f3_Middle_Name + "'";
                strSql += ",f3_Other_Name1='" + f3_Other_Name1 + "'";
                strSql += ",f3_Other_Name2='" + f3_Other_Name2 + "'";
                strSql += ",f3_Other_Name3='" + f3_Other_Name3 + "'";
                strSql += ",f3_Date_of_Birth='" + f3_Date_of_Birth + "'";
                strSql += ",f3_US_Social_Security='" + f3_US_Social_Security + "'";
                strSql += ",f3_Anumber='" + f3_Anumber + "'";
                strSql += ",f3_Country_of_Birth='" + f3_Country_of_Birth + "'";
                strSql += ",f3_Province_of_Birth='" + f3_Province_of_Birth + "'";
                strSql += ",f3_Country_of_Citizenship='" + f3_Country_of_Citizenship + "'";
                strSql += ",f3_Date_of_Last_Arrival='" + f3_Date_of_Last_Arrival + "'";
                strSql += ",f3_I94='" + f3_I94 + "'";
                strSql += ",f3_Current_Nonimmigrant_Status='" + f3_Current_Nonimmigrant_Status + "'";
                strSql += ",f3_Date_Status_Expires='" + f3_Date_Status_Expires + "'";
                strSql += ",f3_Passport_Number='" + f3_Passport_Number + "'";
                strSql += ",f3_Date_Passport_Issued='" + f3_Date_Passport_Issued + "'";
                strSql += ",f3_Date_Passport_Expires='" + f3_Date_Passport_Expires + "'";
                strSql += ",f3_Current_US_Address='" + f3_Current_US_Address + "'";
                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Form_04_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql = "Update Form_I129H set ";
                strSql += "f4_Type_of_Office=" + f4_Type_of_Office + "";
                strSql += ",f4_Office_Address='" + f4_Office_Address + "'";
                strSql += ",f4_US_State_or_Foreign_Country='" + f4_US_State_or_Foreign_Country + "'";
                strSql += ",f4_Persons_Foreign_Address='" + f4_Persons_Foreign_Address + "'";
                strSql += ",f4_Have_a_valid_passpor=" + Convert.ToInt32(f4_Have_a_valid_passpor) + "";
                strSql += ",f4_Anyother_petitions=" + Convert.ToInt32(f4_Anyother_petitions) + "";
                strSql += ",f4_Anyother_petitions_HowMany='" + f4_Anyother_petitions_HowMany + "'";
                strSql += ",f4_Are_applications_for_replacement=" + Convert.ToInt32(f4_Are_applications_for_replacement) + "";
                strSql += ",f4_Are_applications_for_replacement_howmany='" + f4_Are_applications_for_replacement_howmany + "'";
                strSql += ",f4_dependents_being_filed=" + Convert.ToInt32(f4_dependents_being_filed) + "";
                strSql += ",f4_dependents_being_filed_HowMany='" + f4_dependents_being_filed_HowMany + "'";
                strSql += ",f4_Removal_proceedings=" + Convert.ToInt32(f4_Removal_proceedings) + "";
                strSql += ",f4_Have_you_ever_filed_an_immigrant_petition=" + Convert.ToInt32(f4_Have_you_ever_filed_an_immigrant_petition) + "";
                strSql += ",f4_Thepast_seven_years1=" + Convert.ToInt32(f4_Thepast_seven_years1) + "";
                strSql += ",f4_Thepast_seven_years2=" + Convert.ToInt32(f4_Thepast_seven_years2) + "";
                strSql += ",f4_Ever_previously_filed_a_petition_for_this_perso=" + Convert.ToInt32(f4_Ever_previously_filed_a_petition_for_this_perso) + "";
                strSql += ",f4_If_you_are_filing_for_an_entertainment_group=" + Convert.ToInt32(f4_If_you_are_filing_for_an_entertainment_group) + "";
                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Form_05_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql = "Update Form_I129H set ";
                strSql += "f5_Job_Title='" + f5_Job_Title + "'";
                strSql += ",f5_Nontechnical_Job_Description='" + f5_Nontechnical_Job_Description + "'";
                strSql += ",f5_LCA_Case_Number='" + f5_LCA_Case_Number + "'";
                strSql += ",f5_NAICS_Code='" + f5_NAICS_Code + "'";
                strSql += ",f5_different_from_address='" + f5_different_from_address + "'";
                strSql += ",f5_Is_this_a_fulltime_position=" + MyBool(f5_Is_this_a_fulltime_position) + "";
                strSql += ",f5_Hours_per_week='" + f5_Hours_per_week + "'";
                strSql += ",f5_Wages_per_week_Year='" + f5_Wages_per_week_Year + "'";
                strSql += ",f5_Other_Compensation='" + f5_Other_Compensation + "'";
                strSql += ",f5_Dates_of_intended_employment1='" + f5_Dates_of_intended_employment1 + "'";
                strSql += ",f5_Dates_of_intended_employment2='" + f5_Dates_of_intended_employment2 + "'";
                strSql += ",f5_Type_of_Petitioner=" + f5_Type_of_Petitioner + "";
                strSql += ",f5_Type_of_Business='" + f5_Type_of_Business + "'";
                strSql += ",f5_Year_Established='" + f5_Year_Established + "'";
                strSql += ",f5_Current_Number_of_Employees='" + f5_Current_Number_of_Employees + "'";
                strSql += ",f5_Gross_Annual_Income='" + f5_Gross_Annual_Income + "'";
                strSql += ",f5_Net_Annual_Income='" + f5_Net_Annual_Income + "'";
                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Form_06_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql = "Update Form_I129H set ";
                strSql += "f6_Daytime_Phone_Number1='" + f6_Daytime_Phone_Number1 + "'";
                strSql += ",f6_Daytime_Phone_Number1_Code='" + f6_Daytime_Phone_Number1_Code + "'";
                strSql += ",f6_Daytime_Phone_Number2_Code='" + f6_Daytime_Phone_Number2_Code + "'";
                strSql += ",f6_Print_Name1='" + f6_Print_Name1 + "'";
                strSql += ",f6_Date1='" + f6_Date1 + "'";
                strSql += ",f6_Daytime_Phone_Number2='" + f6_Daytime_Phone_Number2 + "'";
                strSql += ",f6_Print_Name2='" + f6_Print_Name2 + "'";
                strSql += ",f6_Firm_Name_and_Address='" + f6_Firm_Name_and_Address + "'";
                strSql += ",f6_Date2='" + f6_Date2 + "'";

                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Form_08_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql = "Update Form_I129H set ";
                strSql += "f8_Name_of_organization_filing_petition='" + f8_Name_of_organization_filing_petition + "'";
                strSql += ",f8_Name_of_person='" + f8_Name_of_person + "'";
                strSql += ",f8_Classification_sought=" + f8_Classification_sought + "";
                strSql += ",f8_Describe_the_proposed_duties='" + f8_Describe_the_proposed_duties + "'";
                strSql += ",f8_Aliens_present_occupation='" + f8_Aliens_present_occupation + "'";
                strSql += ",f8_Print_or_Type_Name1='" + f8_Print_or_Type_Name1 + "'";
                strSql += ",f8_Print_or_Type_Name2='" + f8_Print_or_Type_Name2 + "'";
                strSql += ",f8_DATE1='" + f8_DATE1 + "'";
                strSql += ",f8_DATE2='" + f8_DATE2 + "'";
                strSql += ",f8_SubjectsName1='" + f8_SubjectsName1 + "'";
                strSql += ",f8_SubjectsName2='" + f8_SubjectsName2 + "'";
                strSql += ",f8_SubjectsName3='" + f8_SubjectsName3 + "'";
                strSql += ",f8_SubjectsName4='" + f8_SubjectsName4 + "'";
                strSql += ",f8_Period_From1='" + f8_Period_From1 + "'";
                strSql += ",f8_Period_To1='" + f8_Period_To1 + "'";
                strSql += ",f8_Period_From2='" + f8_Period_From2 + "'";
                strSql += ",f8_Period_To2='" + f8_Period_To2 + "'";
                strSql += ",f8_Period_From3='" + f8_Period_From3 + "'";
                strSql += ",f8_Period_To3='" + f8_Period_To3 + "'";
                strSql += ",f8_Period_From4='" + f8_Period_From4 + "'";
                strSql += ",f8_Period_To4='" + f8_Period_To4 + "'";



                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Form_11_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql = "Update Form_I129H set ";
                strSql += "f11_Petitioners_Name='" + f11_Petitioners_Name + "'";
                strSql += ",f11_Is_the_petitioner_a_dependent_employer=" + Convert.ToInt32(f11_Is_the_petitioner_a_dependent_employer) + "";
                strSql += ",f11_found_to_be_a_willful_violator=" +  Convert.ToInt32(f11_found_to_be_a_willful_violator) + "";
                strSql += ",f11_exempt_H1B_nonimmigrant1=" +  Convert.ToInt32(f11_exempt_H1B_nonimmigrant1) + "";
                strSql += ",f11_exempt_H1B_nonimmigrant2=" +  Convert.ToInt32(f11_exempt_H1B_nonimmigrant2) + "";
                strSql += ",f11_BeneficiaryAnnualMaster=" +  Convert.ToInt32(f11_BeneficiaryAnnualMaster) + "";
                strSql += ",f11_Beneficiarys_Last_Name='" + f11_Beneficiarys_Last_Name + "'";
                strSql += ",f11_First_Name='" + f11_First_Name + "'";
                strSql += ",f11_Middle_Name='" + f11_Middle_Name + "'";
                strSql += ",f11_In_Care_Of='" + f11_In_Care_Of + "'";
                strSql += ",f11_Current_Street_Number_and_Name='" + f11_Current_Street_Number_and_Name + "'";
                strSql += ",f11_AptNo='" + f11_AptNo + "'";
                strSql += ",f11_City='" + f11_City + "'";
                strSql += ",f11_State='" + f11_State + "'";
                strSql += ",f11_Zip='" + f11_Zip + "'";
                strSql += ",f11_Social_Security='" + f11_Social_Security + "'";
                strSql += ",f11_I94='" + f11_I94 + "'";
                strSql += ",f11_Previous_Receipt='" + f11_Previous_Receipt + "'";
                strSql += ",f11_Highest_Level_of_Education=" + f11_Highest_Level_of_Education + "";
                strSql += ",f11_Primary_Field_of_Study='" + f11_Primary_Field_of_Study + "'";
                strSql += ",f11_higher_degree_from_a_US=" +  Convert.ToInt32(f11_higher_degree_from_a_US) + "";
                strSql += ",f11_Name_of_the_US_institution='" + f11_Name_of_the_US_institution + "'";
                strSql += ",f11_Date_Degree_Awarded='" + f11_Date_Degree_Awarded + "'";
                strSql += ",f11_Type_of_US_Degree='" + f11_Type_of_US_Degree + "'";
                strSql += ",f11_Address_of_the_US_institution='" + f11_Address_of_the_US_institution + "'";
                strSql += ",f11_Rate_of_Pay_Per_Year='" + f11_Rate_of_Pay_Per_Year + "'";
                strSql += ",f11_LCA_Code='" + f11_LCA_Code + "'";
                strSql += ",f11_NAICS_Code='" + f11_NAICS_Code + "'";
                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Form_12_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql = "Update Form_I129H set ";
                strSql += "f12_Fee_Exemption_1='" + Convert.ToInt32(f12_Fee_Exemption_1) + "'";
                strSql += ",f12_Fee_Exemption_2='" + Convert.ToInt32(f12_Fee_Exemption_2) + "'";
                strSql += ",f12_Fee_Exemption_3='" + Convert.ToInt32(f12_Fee_Exemption_3) + "'";
                strSql += ",f12_Fee_Exemption_4='" + Convert.ToInt32(f12_Fee_Exemption_4) + "'";
                strSql += ",f12_Fee_Exemption_5='" + Convert.ToInt32(f12_Fee_Exemption_5) + "'";
                strSql += ",f12_Fee_Exemption_6='" + Convert.ToInt32(f12_Fee_Exemption_6) + "'";
                strSql += ",f12_Fee_Exemption_7='" + Convert.ToInt32(f12_Fee_Exemption_7) + "'";
                strSql += ",f12_Fee_Exemption_8='" + Convert.ToInt32(f12_Fee_Exemption_8) + "'";
                strSql += ",f12_Fee_Exemption_9='" + Convert.ToInt32(f12_Fee_Exemption_9) + "'";
                strSql += ",f12_Numerical_Limitation_1='" + Convert.ToInt32(f12_Numerical_Limitation_1) + "'";
                strSql += ",f12_Numerical_Limitation_2='" + Convert.ToInt32(f12_Numerical_Limitation_2) + "'";
                strSql += ",f12_Numerical_Limitation_3='" + Convert.ToInt32(f12_Numerical_Limitation_3) + "'";
                strSql += ",f12_Numerical_Limitation_4='" + Convert.ToInt32(f12_Numerical_Limitation_4) + "'";
                strSql += ",f12_Numerical_Limitation_5='" + Convert.ToInt32(f12_Numerical_Limitation_5) + "'";
                strSql += ",f12_Numerical_Limitation_6='" + Convert.ToInt32(f12_Numerical_Limitation_6) + "'";
                strSql += ",f12_Numerical_Limitation_7='" + Convert.ToInt32(f12_Numerical_Limitation_7) + "'";
                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Form_13_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql = "Update Form_I129H set ";
                strSql += "f13_Print_Name='" + f13_Print_Name + "'";
                strSql += ",f13_Title='" + f13_Title + "'";
                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }
                   

        public bool Form_02_UpdateZXX()
        {

            try
            {
                //ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                //strSql = "Update Form_I129H set f2_RequestedNonimmigrantClassification='" + RequestedNonimmigrantClassification + "',f2_BasisforClassification='" + BasisforClassification + "',f2_Prior_Petition='" + Prior_Petition + "',f2_RequestedAction='" + RequestedAction + "',f2_Totalnumberofworkersinpetition='" + Totalnumberofworkersinpetition + "' where Employee_id=" + Employee_id;
                //DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Form_04_Update1()
        {

            try
            {
                //ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                //strSql += "Update Form_I129H set ";
                //strSql += "f4_Type_of_Office=" + Type_of_Office;
                //strSql += ",f4_Have_a_valid_passpor =" + Have_a_valid_passpor ;
                //strSql += ",f4_Anyother_petitions = " + Anyother_petitions;
                //strSql += ",f4_Anyother_petitions_HowMany='" + Anyother_petitions_HowMany + "'";
                strSql += ",f1_Person_Last_Name='" + f1_Person_Last_Name + "'";

                //strSql += ",f4_Are_applications_for_replacement=" + Are_applications_for_replacement;
                //strSql += ",f4_Are_applications_for_replacement_howmany='" + Are_applications_for_replacement_howmany + "'";
                //strSql += ",f4_Removal_proceedings=" + Removal_proceedings;
                //strSql += ",f4_Have_you_ever_filed_an_immigrant_petition=" + Have_you_ever_filed_an_immigrant_petition;
                //strSql += ",f4_Thepast_seven_years1=" + Thepast_seven_years1;
                //strSql += ",f4_Thepast_seven_years2=" + Thepast_seven_years2;
                //strSql += ",f4_Ever_previously_filed_a_petition_for_this_perso=" + Ever_previously_filed_a_petition_for_this_perso;
                //strSql += ",f4_If_you_are_filing_for_an_entertainment_group=" + If_you_are_filing_for_an_entertainment_group;
                //strSql += " where Employee_id=" + Employee_id;
                //DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public int MyBool(bool bval)
        {
            if (bval)
                return 1;
            else
                return 0;
        }
    }
}

