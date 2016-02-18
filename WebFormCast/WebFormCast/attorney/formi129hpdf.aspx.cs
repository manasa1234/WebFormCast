using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WebFormCast.ACLG;
//using WebSupergoo.ABCpdf5;
//using WebSupergoo.ABCpdf7;
//using WebSupergoo.ABCpdf7.Objects;

public partial class attorney_formi129hpdf : System.Web.UI.Page
{
    int intEmployeeId = 0;
    int intAttorney_id = 0;
    string strEmployeeSignature = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
        }
        catch { }
        try
        {
            intEmployeeId = Convert.ToInt16(Session["Attorney_Employee_Id"]);
            //strEmployeeSignature =Session["Attorney_Employee_Signature"].ToString();
        }
        catch { }
        try
        {
            strEmployeeSignature = Request["signature"].ToString();
        }
        catch { }


        if (intAttorney_id <= 0)
        {
            Response.Redirect("index.aspx");
        }

        if (!IsPostBack)
        {
            Initialize();
        }
    }

    protected void Initialize()
    {
        //Form_i129H OF = new Form_i129H(intEmployeeId);
        
        //Doc theDoc = new Doc();
        ////theDoc.SetInfo(0, "License", "322-594-815-276-4005-092 ABCpdf .NET Pro 5");
        //theDoc.Read(Server.MapPath("../orgpdf/Form I129H.pdf"));

        ////Page1
        //theDoc.Form["form1[0].#subform[0].q1a_LastName[0]"].Value = OF.f1_Person_Last_Name;
        //theDoc.Form["form1[0].#subform[0].q1b_FirstName[0]"].Value = OF.f1_Person_First_Name;
        //theDoc.Form["form1[0].#subform[0].q1c_MiddleName[0]"].Value = OF.f1_Person_Middle_Name;
        //theDoc.Form["form1[0].#subform[0].q2_NameofCompanyorOrg[0]"].Value = OF.f1_CompanyName;
        //theDoc.Form["form1[0].#subform[0].q3a_InCareOf[0]"].Value = OF.f6_Print_Name1;
        //theDoc.Form["form1[0].#subform[0].q3b_StreetNumber[0]"].Value = OF.f1_CompanyStreet;
        //theDoc.Form["form1[0].#subform[0].q3c_Suite_Apt[0]"].Value = OF.f1_CompanySuite;
        //theDoc.Form["form1[0].#subform[0].q3d_City[0]"].Value = OF.f1_CompanyCity;
        //theDoc.Form["form1[0].#subform[0].q3e_State_Province[0]"].Value = OF.f1_CompanyState;
        //theDoc.Form["form1[0].#subform[0].Q3f_CountryOfBirthDropDownList[0]"].Value = OF.f1_CompanyCountry;
        //theDoc.Form["form1[0].#subform[0].q3g_ZipPostalCode[0]"].Value = OF.f1_CompanyZip;
        //theDoc.Form["form1[0].#subform[0].q3h_PhoneNum[0]"].Value = OF.f1_CompanyPhone_Code + OF.f1_CompanyPhone;
        //theDoc.Form["form1[0].#subform[0].q3i_EmailAddress[0]"].Value = OF.f1_CompanyEmail;
        //theDoc.Form["form1[0].#subform[0].q3j_FEIN[0]"].Value = OF.f1_CompanyFederalIdentification;
        //theDoc.Form["form1[0].#subform[0].q3k_IDTN[0]"].Value = OF.f1_CompanyIndividualTax;
        //theDoc.Form["form1[0].#subform[0].q3l_SSN[0]"].Value = OF.f1_ComapnySocialSecurity;
        ////Page2
        //theDoc.Form["form1[0].#subform[1].Part2_ClassificationSymbol[0]"].Value = OF.f2_RequestedNonimmigrantClassification;
        //theDoc.Form["form1[0].#subform[1].Part2_Quest3[0]"].Value = OF.f2_receipt_number;
        //theDoc.Form["form1[0].#subform[1].Part2_Quest5[0]"].Value = OF.f2_Totalnumberofworkersinpetition;

        //theDoc.Form["form1[0].#subform[1].new[0]"].Value = "Off";
        //theDoc.Form["form1[0].#subform[1].continuation[0]"].Value = "Off";
        //theDoc.Form["form1[0].#subform[1].previouschange[0]"].Value = "Off";
        //theDoc.Form["form1[0].#subform[1].concurrent[0]"].Value = "Off";
        //theDoc.Form["form1[0].#subform[1].change[0]"].Value = "Off";
        //theDoc.Form["form1[0].#subform[1].amended[0]"].Value = "Off";
        //if (OF.f2_BasisforClassification == 1)
        //    theDoc.Form["form1[0].#subform[1].new[0]"].Value = "1";
        //else if (OF.f2_BasisforClassification == 2)
        //    theDoc.Form["form1[0].#subform[1].continuation[0]"].Value = "1";
        //else if (OF.f2_BasisforClassification == 3)
        //    theDoc.Form["form1[0].#subform[1].previouschange[0]"].Value = "1";
        //else if (OF.f2_BasisforClassification == 4)
        //    theDoc.Form["form1[0].#subform[1].concurrent[0]"].Value = "1";
        //else if (OF.f2_BasisforClassification == 5)
        //    theDoc.Form["form1[0].#subform[1].change[0]"].Value = "1";
        //else if (OF.f2_BasisforClassification == 6)
        //    theDoc.Form["form1[0].#subform[1].amended[0]"].Value = "1";

        //theDoc.Form["form1[0].#subform[1].notify[0]"].Value = "Off";
        //theDoc.Form["form1[0].#subform[1].b_change[0]"].Value = "Off";
        //theDoc.Form["form1[0].#subform[1].extend_stay[0]"].Value = "Off";
        //theDoc.Form["form1[0].#subform[1].amend_stay[0]"].Value = "Off";
        //theDoc.Form["form1[0].#subform[1].extend_status[0]"].Value = "Off";
        //theDoc.Form["form1[0].#subform[1].change_status[0]"].Value = "Off";
        //if (OF.f2_RequestedAction == 1)
        //    theDoc.Form["form1[0].#subform[1].notify[0]"].Value = "1";
        //if (OF.f2_RequestedAction == 2)
        //    theDoc.Form["form1[0].#subform[1].b_change[0]"].Value = "1";
        //if (OF.f2_RequestedAction == 3)
        //    theDoc.Form["form1[0].#subform[1].extend_stay[0]"].Value = "1";
        //if (OF.f2_RequestedAction == 4)
        //    theDoc.Form["form1[0].#subform[1].amend_stay[0]"].Value = "1";
        //if (OF.f2_RequestedAction == 5)
        //    theDoc.Form["form1[0].#subform[1].extend_status[0]"].Value = "1";
        //if (OF.f2_RequestedAction == 6)
        //    theDoc.Form["form1[0].#subform[1].change_status[0]"].Value = "1";
        ////Page3
        //theDoc.Form["form1[0].#subform[2].GroupName1[0]"].Value = OF.f3_Entertainment_Group_Name;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest1a[0]"].Value = OF.f3_Last_Name;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest1b[0]"].Value = OF.f3_First_Name;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest1c[0]"].Value = OF.f3_Middle_Name;
        //theDoc.Form["form1[0].#subform[2].Part3_Qest1d_OtherNames[0]"].Value = OF.f3_Other_Name1;
        //theDoc.Form["form1[0].#subform[2].Part3_Qest1d_OtherNames2[0]"].Value = OF.f3_Other_Name2;
        //theDoc.Form["form1[0].#subform[2].Part3_Qest1d_OtherNames3[0]"].Value = OF.f3_Other_Name3;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest1e_DOB[0]"].Value = OF.f3_Date_of_Birth;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest1g_SSNumber[0]"].Value = OF.f3_US_Social_Security;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest1h_ANumber[0]"].Value = OF.f3_Anumber;
        //theDoc.Form["form1[0].#subform[2].Q1k_CountryOfBirthDropDownList[0]"].Value = OF.f3_Country_of_Birth;
        //theDoc.Form["form1[0].#subform[2].Q1j_ProvOfBirth[0]"].Value = OF.f3_Province_of_Birth;
        //theDoc.Form["form1[0].#subform[2].Q1k_CountryOfCitzDropDownList[0]"].Value = OF.f3_Country_of_Citizenship;

        //theDoc.Form["form1[0].#subform[2].Part3_Quest2a[0]"].Value = OF.f3_Date_of_Last_Arrival;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest2b_I94Number[0]"].Value = OF.f3_I94;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest2c[0]"].Value = OF.f3_Current_Nonimmigrant_Status;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest2d[0]"].Value = OF.f3_Date_Status_Expires;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest2g[0]"].Value = OF.f3_Passport_Number;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest2h[0]"].Value = OF.f3_Date_Passport_Issued;
        //theDoc.Form["form1[0].#subform[2].Part3_Quest2i[0]"].Value = OF.f3_Date_Passport_Expires;
        //theDoc.Form["form1[0].#subform[2].Part3_2j_Address[0]"].Value = OF.f3_Current_US_Address;

        ////Page4
        //if (OF.f4_Type_of_Office == 1)
        //    theDoc.Form["form1[0].#subform[2].Consulate[0]"].Value = "1";
        //if (OF.f4_Type_of_Office == 2)
        //    theDoc.Form["form1[0].#subform[2].Pre_flight[0]"].Value = "1";
        //if (OF.f4_Type_of_Office == 3)
        //    theDoc.Form["form1[0].#subform[2].POE[0]"].Value = "1";
        //theDoc.Form["form1[0].#subform[2].OfficeAddressCity[0]"].Value = OF.f4_Office_Address;
        //theDoc.Form["form1[0].#subform[2].Part4_1c_State_or_Country[0]"].Value = OF.f4_US_State_or_Foreign_Country;
        //theDoc.Form["form1[0].#subform[2].Part4_1d_BeneForeignAddress[0]"].Value = OF.f4_Persons_Foreign_Address;
        //if (OF.f4_Have_a_valid_passpor == 1)
        //    theDoc.Form["form1[0].#subform[3].P4_q2_notrequired[0]"].Value = "1";
        //if (OF.f4_Have_a_valid_passpor == 2)
        //    theDoc.Form["form1[0].#subform[3].P4_q2_no[0]"].Value = "1";
        //if (OF.f4_Have_a_valid_passpor == 3)
        //    theDoc.Form["form1[0].#subform[3].P4_q2_yes[0]"].Value = "1";
        //theDoc.Form["form1[0].#subform[3].P4_q3_no[0]"].Value = SetYesOff(OF.f4_Anyother_petitions, false);
        //theDoc.Form["form1[0].#subform[3].P4_q3_yes[0]"].Value = SetYesOff(OF.f4_Anyother_petitions, true);
        //theDoc.Form["form1[0].#subform[3].Part4_Q3[0]"].Value = OF.f4_Anyother_petitions_HowMany;
        //theDoc.Form["form1[0].#subform[3].P4_q4_no[0]"].Value = SetYesOff(OF.f4_Are_applications_for_replacement, false);
        //theDoc.Form["form1[0].#subform[3].P4_q4_yes[0]"].Value = SetYesOff(OF.f4_Are_applications_for_replacement, true);
        //theDoc.Form["form1[0].#subform[3].Part4_Q4[0]"].Value = OF.f4_Are_applications_for_replacement_howmany;

        //theDoc.Form["form1[0].#subform[3].P4_q5_no[0]"].Value = SetYesOff(OF.f4_dependents_being_filed, false);
        //theDoc.Form["form1[0].#subform[3].P4_q5_yes[0]"].Value = SetYesOff(OF.f4_dependents_being_filed, true);
        //theDoc.Form["form1[0].#subform[3].Part4_Q5[0]"].Value = OF.f4_dependents_being_filed_HowMany;

        //theDoc.Form["form1[0].#subform[3].P4_q6_no[0]"].Value = SetYesOff(OF.f4_Removal_proceedings, false);
        //theDoc.Form["form1[0].#subform[3].P4_q6_yes[0]"].Value = SetYesOff(OF.f4_Removal_proceedings, true);

        //theDoc.Form["form1[0].#subform[3].P4_q7_no[0]"].Value = SetYesOff(OF.f4_Have_you_ever_filed_an_immigrant_petition, false);
        //theDoc.Form["form1[0].#subform[3].P4_q7_yes[0]"].Value = SetYesOff(OF.f4_Have_you_ever_filed_an_immigrant_petition, true);

        //theDoc.Form["form1[0].#subform[3].P4_q8a_no[0]"].Value = SetYesOff(OF.f4_Thepast_seven_years1, false);
        //theDoc.Form["form1[0].#subform[3].P4_q8a_yes[0]"].Value = SetYesOff(OF.f4_Thepast_seven_years1, true);

        //theDoc.Form["form1[0].#subform[3].P4_q8b_no[0]"].Value = SetYesOff(OF.f4_Thepast_seven_years2, false);
        //theDoc.Form["form1[0].#subform[3].P4_q8b_yes[0]"].Value = SetYesOff(OF.f4_Thepast_seven_years2, true);

        //theDoc.Form["form1[0].#subform[3].P4_q9_no[0]"].Value = SetYesOff(OF.f4_Ever_previously_filed_a_petition_for_this_perso, false).ToString();
        //theDoc.Form["form1[0].#subform[3].P4_q9_yes[0]"].Value = SetYesOff(OF.f4_Ever_previously_filed_a_petition_for_this_perso, true).ToString();

        //theDoc.Form["form1[0].#subform[3].P4_q10_no[0]"].Value = SetYesOff(OF.f4_If_you_are_filing_for_an_entertainment_group, false);
        //theDoc.Form["form1[0].#subform[3].P4_q10_yes[0]"].Value = SetYesOff(OF.f4_If_you_are_filing_for_an_entertainment_group, true);

        ////Page 5
        //theDoc.Form["form1[0].#subform[3].Part5_Q1_JobTitle[0]"].Value = OF.f5_Job_Title;
        //theDoc.Form["form1[0].#subform[3].Part5_Q2_LCAorETA[0]"].Value = OF.f5_LCA_Case_Number;
        //if (OF.f5_different_from_address.Trim() != "")
        //    theDoc.Form["form1[0].#subform[3].Part5_Q3[0]"].Value = OF.f5_different_from_address;
        //else
        //    theDoc.Form["form1[0].#subform[3].Part5_Q3[0]"].Value = "Same as Part 1";
        //theDoc.Form["form1[0].#subform[4].P5_q7_no[0]"].Value = SetYesOff(OF.f5_Is_this_a_fulltime_position, false);
        //theDoc.Form["form1[0].#subform[4].P5_q7_yes[0]"].Value = SetYesOff(OF.f5_Is_this_a_fulltime_position, true);
        //theDoc.Form["form1[0].#subform[4].Part5_Q7_HoursPerWeek[0]"].Value = OF.f5_Hours_per_week;
        //theDoc.Form["form1[0].#subform[4].Part5_Q8_Wages[0]"].Value = OF.f5_Wages_per_week_Year;
        //theDoc.Form["form1[0].#subform[4].Part5_Q9_Other[0]"].Value = OF.f5_Other_Compensation;
        //theDoc.Form["form1[0].#subform[4].Part5_Q10_DateFrom[0]"].Value = OF.f5_Dates_of_intended_employment1;
        //theDoc.Form["form1[0].#subform[4].Part5_Q10_DateTo[0]"].Value = OF.f5_Dates_of_intended_employment2;
        //theDoc.Form["form1[0].#subform[4].Part5_Q11[0]"].Value = OF.f5_Type_of_Business;
        //theDoc.Form["form1[0].#subform[4].Part5_Quest12_Year[0]"].Value = OF.f5_Year_Established;
        //theDoc.Form["form1[0].#subform[4].Part5_Q13[0]"].Value = OF.f5_Current_Number_of_Employees;
        //theDoc.Form["form1[0].#subform[4].Part5_Q14[0]"].Value = OF.f5_Gross_Annual_Income;
        //theDoc.Form["form1[0].#subform[4].Part5_Q15[0]"].Value = OF.f5_Net_Annual_Income;
        ////Page 6
        //// theDoc.Form["form1[0].#subform[4].Deemed[0]"].Value = "1";
        //// theDoc.Form["form1[0].#subform[4].NoDeemed[0]"].Value = "1";
        //theDoc.Form["form1[0].#subform[5].Part7_TelephoneNumber[0]"].Value = OF.f6_Daytime_Phone_Number1_Code + OF.f6_Daytime_Phone_Number1;
        //theDoc.Form["form1[0].#subform[5].Part7_PrintedName[0]"].Value = OF.f6_Print_Name1;
        //if (OF.f6_Date1 == "")
        //    theDoc.Form["form1[0].#subform[5].Part7_DateSigned[0]"].Value = DateTime.Now.ToString("mm/dd/yyyy");
        //else
        //    theDoc.Form["form1[0].#subform[5].Part7_DateSigned[0]"].Value = OF.f6_Date1;

        //theDoc.Form["form1[0].#subform[5].Part8_TelephoneNumber[0]"].Value = OF.f6_Daytime_Phone_Number2_Code + OF.f6_Daytime_Phone_Number2;
        //theDoc.Form["form1[0].#subform[5].Part8_PrintedName[0]"].Value = OF.f6_Print_Name2;
        //if (OF.f6_Date2 == "")
        //    theDoc.Form["form1[0].#subform[5].Part8_DateSigned[0]"].Value = DateTime.Now.ToString("mm/dd/yyyy");
        //else
        //    theDoc.Form["form1[0].#subform[5].Part8_DateSigned[0]"].Value = OF.f6_Date2;

        //string txt = OF.f6_Firm_Name_and_Address;
        //string removedBreaks = txt;
        //if (string.IsNullOrEmpty(txt) == false)
        //{
        //    string replaceWith = ", ";
        //    removedBreaks = txt.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
        //}
        //theDoc.Form["form1[0].#subform[5].Part8_FirmName_and_Address[0]"].Value = removedBreaks;
        //theDoc.Form["form1[0].#subform[6].Part9_PrintedName[0]"].Value = OF.f6_Print_Name1;
        ////Page 7
        //theDoc.Form["form1[0].#subform[11].petitioner_name_HClassSupp[0]"].Value = OF.f8_Name_of_organization_filing_petition;
        //theDoc.Form["form1[0].#subform[11].beneficiaries_name_or_total_number[0]"].Value = OF.f8_Name_of_person;
        //theDoc.Form["form1[0].#subform[11].a_Specialty[0]"].Value = SetYesOff(OF.f8_Classification_sought, 1);
        //theDoc.Form["form1[0].#subform[11].b_Exceptional[0]"].Value = SetYesOff(OF.f8_Classification_sought, 2);
        //theDoc.Form["form1[0].#subform[11].c_FashionModel[0]"].Value = SetYesOff(OF.f8_Classification_sought, 3);
        //theDoc.Form["form1[0].#subform[11].e_Agricultural[0]"].Value = SetYesOff(OF.f8_Classification_sought, 4);
        //theDoc.Form["form1[0].#subform[11].f_Nonagricultural[0]"].Value = SetYesOff(OF.f8_Classification_sought, 5);
        //theDoc.Form["form1[0].#subform[11].g_Trainee[0]"].Value = SetYesOff(OF.f8_Classification_sought, 6);
        //theDoc.Form["form1[0].#subform[11].h_SpecialEducation[0]"].Value = SetYesOff(OF.f8_Classification_sought, 7);
        //theDoc.Form["form1[0].#subform[11].Sect1_Describe_duties_1[0]"].Value = OF.f8_Describe_the_proposed_duties;
        //theDoc.Form["form1[0].#subform[11].Sect1_Describe_work_experience_2[0]"].Value = OF.f8_Aliens_present_occupation;
        //theDoc.Form["form1[0].#subform[13].Sect1_PetitionerPrintedName[0]"].Value = OF.f8_Print_or_Type_Name1;
        //theDoc.Form["form1[0].#subform[13].Sect1_AuthorizedOfficialName[0]"].Value = OF.f8_Print_or_Type_Name2;
        //if (OF.f8_DATE1 != "")
        //    theDoc.Form["form1[0].#subform[13].Sect1_DateSignedByPetitioner[0]"].Value = OF.f8_DATE1;
        //else
        //    theDoc.Form["form1[0].#subform[13].Sect1_DateSignedByPetitioner[0]"].Value = DateTime.Now.ToString("MM/dd/yyyy");

        //if (OF.f8_DATE2 != "")
        //    theDoc.Form["form1[0].#subform[13].Sect1_DateSignedByAuthorizedOfficial[0]"].Value = OF.f8_DATE2;
        //else
        //    theDoc.Form["form1[0].#subform[13].Sect1_DateSignedByAuthorizedOfficial[0]"].Value = DateTime.Now.ToString("MM/dd/yyyy");

        //theDoc.Form["form1[0].#subform[11].Table1[1].Row2[0].Name_Line1[0]"].Value = OF.f8_SubjectsName1;
        //theDoc.Form["form1[0].#subform[11].Table1[1].Row2[0].DateFrom_Line1[0]"].Value = OF.f8_Period_From1;
        //theDoc.Form["form1[0].#subform[11].Table1[1].Row2[0].DateTo_Line1[0]"].Value = OF.f8_Period_To1;

        //theDoc.Form["form1[0].#subform[11].Table1[1].Row3[0].Name_Line2[0]"].Value = OF.f8_SubjectsName2;
        //theDoc.Form["form1[0].#subform[11].Table1[1].Row3[0].DateFrom_Line2[0]"].Value = OF.f8_Period_From2;
        //theDoc.Form["form1[0].#subform[11].Table1[1].Row3[0].DateTo_Line2[0]"].Value = OF.f8_Period_To2;

        //theDoc.Form["form1[0].#subform[11].Table1[1].Row4[0].Name_Line3[0]"].Value = OF.f8_SubjectsName3;
        //theDoc.Form["form1[0].#subform[11].Table1[1].Row4[0].DateFrom_Line3[0]"].Value = OF.f8_Period_From3;
        //theDoc.Form["form1[0].#subform[11].Table1[1].Row4[0].DateTo_Line3[0]"].Value = OF.f8_Period_To3;

        //theDoc.Form["form1[0].#subform[11].Table1[1].Row5[0].Name_Line4[0]"].Value = OF.f8_SubjectsName4;
        //theDoc.Form["form1[0].#subform[11].Table1[1].Row5[0].DateFrom_Line4[0]"].Value = OF.f8_Period_From4;
        //theDoc.Form["form1[0].#subform[11].Table1[1].Row5[0].DateTo_Line4[0]"].Value = OF.f8_Period_To4;
        ////Page 8
        //theDoc.Form["form1[0].#subform[18].DataCollectionSupp_PetitionerName[0]"].Value = OF.f11_Petitioners_Name;
        //theDoc.Form["form1[0].#subform[18].PartA_1a_no[0]"].Value = SetYesOff(OF.f11_Is_the_petitioner_a_dependent_employer, false);
        //theDoc.Form["form1[0].#subform[18].PartA_1a_yes[0]"].Value = SetYesOff(OF.f11_Is_the_petitioner_a_dependent_employer, true);
        //theDoc.Form["form1[0].#subform[18].PartA_1b_no[0]"].Value = SetYesOff(OF.f11_found_to_be_a_willful_violator, false);
        //theDoc.Form["form1[0].#subform[18].PartA_1b_yes[0]"].Value = SetYesOff(OF.f11_found_to_be_a_willful_violator, true);
        //theDoc.Form["form1[0].#subform[18].PartA_1c_no[0]"].Value = SetYesOff(OF.f11_exempt_H1B_nonimmigrant1, false);
        //theDoc.Form["form1[0].#subform[18].PartA_1c_yes[0]"].Value = SetYesOff(OF.f11_exempt_H1B_nonimmigrant1, true);
        //theDoc.Form["form1[0].#subform[18].PartA_1c1_no[0]"].Value = SetYesOff(OF.f11_exempt_H1B_nonimmigrant2, false);
        //theDoc.Form["form1[0].#subform[18].PartA_1c1_yes[0]"].Value = SetYesOff(OF.f11_exempt_H1B_nonimmigrant2, true);
        //theDoc.Form["form1[0].#subform[18].PartA_1c2_no[0]"].Value = SetYesOff(OF.f11_BeneficiaryAnnualMaster, false);
        //theDoc.Form["form1[0].#subform[18].PartA_1c2_yes[0]"].Value = SetYesOff(OF.f11_BeneficiaryAnnualMaster, true);

        //theDoc.Form["form1[0].#subform[18].a_no_diploma[0]"].Value = SetYesOff(OF.f11_Highest_Level_of_Education, 1);
        //theDoc.Form["form1[0].#subform[18].b_HSDiploma[0]"].Value = SetYesOff(OF.f11_Highest_Level_of_Education, 3);
        //theDoc.Form["form1[0].#subform[18].c_some_college[0]"].Value = SetYesOff(OF.f11_Highest_Level_of_Education, 5);
        //theDoc.Form["form1[0].#subform[18].d_collegeplus[0]"].Value = SetYesOff(OF.f11_Highest_Level_of_Education, 7);
        //theDoc.Form["form1[0].#subform[18].e_AssociateDegree[0]"].Value = SetYesOff(OF.f11_Highest_Level_of_Education, 2);
        //theDoc.Form["form1[0].#subform[18].f_BachelorDegree[0]"].Value = SetYesOff(OF.f11_Highest_Level_of_Education, 4);
        //theDoc.Form["form1[0].#subform[18].g_MasterDegree[0]"].Value = SetYesOff(OF.f11_Highest_Level_of_Education, 6);
        //theDoc.Form["form1[0].#subform[18].h_ProfessionalDegree[0]"].Value = SetYesOff(OF.f11_Highest_Level_of_Education, 8);
        //theDoc.Form["form1[0].#subform[18].i_DoctorateDegree[0]"].Value = SetYesOff(OF.f11_Highest_Level_of_Education, 9);

        //theDoc.Form["form1[0].#subform[18].PartA_q3_Field_of_Study[0]"].Value = OF.f11_Primary_Field_of_Study;
        //theDoc.Form["form1[0].#subform[18].PartA_q4_RateofPay[0]"].Value = OF.f11_Rate_of_Pay_Per_Year;
        //theDoc.Form["form1[0].#subform[18].PartA_q5_DOT_Code1[0]"].Value = GetChar(OF.f11_LCA_Code, 1);
        //theDoc.Form["form1[0].#subform[18].PartA_q5_DOT_Code2[0]"].Value = GetChar(OF.f11_LCA_Code, 2);
        //theDoc.Form["form1[0].#subform[18].PartA_q5_DOT_Code3[0]"].Value = GetChar(OF.f11_LCA_Code, 3);
        //theDoc.Form["form1[0].#subform[18].PartA_q6_NAICS_Code1[0]"].Value = GetChar(OF.f11_NAICS_Code, 1);
        //theDoc.Form["form1[0].#subform[18].PartA_q6_NAICS_Code2[0]"].Value = GetChar(OF.f11_NAICS_Code, 2);
        //theDoc.Form["form1[0].#subform[18].PartA_q6_NAICS_Code3[0]"].Value = GetChar(OF.f11_NAICS_Code, 3);
        //theDoc.Form["form1[0].#subform[18].PartA_q6_NAICS_Code4[0]"].Value = GetChar(OF.f11_NAICS_Code, 4);
        //theDoc.Form["form1[0].#subform[18].PartA_q6_NAICS_Code5[0]"].Value = GetChar(OF.f11_NAICS_Code, 5);
        //theDoc.Form["form1[0].#subform[18].PartA_q6_NAICS_Code6[0]"].Value = GetChar(OF.f11_NAICS_Code, 6);

        ////Page 9
        //theDoc.Form["form1[0].#subform[18].PartB_1_yes[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_1, true);
        //theDoc.Form["form1[0].#subform[18].PartB_1_no[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_1, false);
        //theDoc.Form["form1[0].#subform[18].PartB_2_yes[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_2, true);
        //theDoc.Form["form1[0].#subform[18].PartB_2_no[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_2, false);
        //theDoc.Form["form1[0].#subform[18].PartB_3_yes[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_3, true);
        //theDoc.Form["form1[0].#subform[18].PartB_3_no[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_3, false);
        //theDoc.Form["form1[0].#subform[18].PartB_4_yes[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_4, true);
        //theDoc.Form["form1[0].#subform[18].PartB_4_no[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_4, false);
        //theDoc.Form["form1[0].#subform[18].PartB_5_yes[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_5, true);
        //theDoc.Form["form1[0].#subform[18].PartB_5_no[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_5, false);
        //theDoc.Form["form1[0].#subform[19].PartB_6_yes[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_6, true);
        //theDoc.Form["form1[0].#subform[19].PartB_6_no[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_6, false);
        //theDoc.Form["form1[0].#subform[19].PartB_7_yes[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_7, true);
        //theDoc.Form["form1[0].#subform[19].PartB_7_no[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_7, false);
        //theDoc.Form["form1[0].#subform[19].PartB_8_yes[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_8, true);
        //theDoc.Form["form1[0].#subform[19].PartB_8_no[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_8, false);
        //theDoc.Form["form1[0].#subform[19].PartB_9_yes[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_9, true);
        //theDoc.Form["form1[0].#subform[19].PartB_9_no[0]"].Value = SetYesOff(OF.f12_Fee_Exemption_9, false);

        //string strTrackingNo = "";
        //string strFileName = "";
        //try
        //{
        //    strTrackingNo=Session["Attorney_Employee_TrackingNo"].ToString();
        //}
        //catch { }

        //if (strTrackingNo != "")
        //    strFileName = strTrackingNo + "_Form_I129H.PDF";
        //else
        //    strFileName = "Form_I129H.PDF";


        
        //Byte[] theData = theDoc.GetData();
        //Response.Clear();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-length", theData.Length.ToString());
        //if (Request.QueryString["attachment"] != null)
        //    Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
        //else
        //    Response.AddHeader("content-disposition", "inline; filename=" + strFileName);

        //Response.BinaryWrite(theData);
        //Response.Flush();
        //Response.Write("<script language='javascript'>window.close();</script>");

        ////theDoc.Save(Server.MapPath("eformstamp.pdf")); 
        ////txtInre.Text = oE.LastName.ToUpper() + ", " + objG.Capitilaze(oE.FirstName) + " " + objG.Capitilaze(oE.MiddleName);
        ////txtEmployerName.Text = OE1.Legal_Name.ToString();
        ////txtAptNo.Text = OE1.Add_AptNo;
        ////txtStreet.Text = OE1.Add_Street;
        ////txtCity.Text = OE1.Add_City;
        ////txtState.Text = OE1.Add_State;
        ////txtZip.Text = OE1.Add_Zip;
        ////txtAttorney_Address.Text = OA.Address;
        ////txtAttorney_Name1.Text = OA.Name;
        ////txtAttorney_Phone.Text = OA.Phone;
        ////txtAttorney_Fax.Text = OA.Fax;
        ////txtAttorney_Name2.Text = OA.Name;
        ////txtEmployeeName.Text = "In RE: " + oE.LastName.ToUpper() + " " + objG.Capitilaze(oE.FirstName) + " " + objG.Capitilaze(oE.MiddleName) + " FORM-I-539";
        ////txtEmpoyer1.Text = OE1.Person_FullName;
    }

    protected string GetChar(string v1, int p)
    {
        
        string strCh="";
        if (v1.Length >= p)
            strCh = v1.Substring(p-1, 1);
        return strCh;
    }

    protected string SetYesOff(bool v1, bool v2)
    {
        if (v1 == v2)
            return "1";
        else
            return "Off";
    }
    protected string SetYesOff(int v1, int v2)
    {
        if (v1 == v2)
            return "1";
        else
            return "Off";
    }

}

