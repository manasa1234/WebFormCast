SQL Server 2005 Notes:
-------------------------
Server connection Strings:
Server=L7-15954\ACLGUSIT;Database=aclgusit;Uid=aclgusit;Password=aclgusit;
Server=L7-15954\ACLGUSIT
	Database=aclgusit
	Uid=sa
	Password=SbG525Aaa
Server=LX-15074\ACLGUSIT;Database=aclgusit;Uid=aclgusit;Password=aclgusit;
Prod Server=sql2005-7.reinventinc.com;Database=aclgusit;Uid=aclgusit;Password=Usit@Aclg16;

Do not give "sysadmin" role to "aclgusit" user/login. Doing so will override what ever specified default schema and switches it to "dbo" as the default schema. 
The current app is not using fully qualified names in the sql i.e. schema.table_name is not used. It is directly quering on table_names since it is using aclgusit as the userid which points to "aclgusit" schema as default.

FTP details:
---------------------------
server: ftp://ftp.webformcast.com/
username: mrvasu
password: d3c3mb3r

1) Modified web.config and changed connectionStrings to point to local test database.

APplication:
-------------
http://www.webformcast.com/attorney/index.aspx

1) Commented out "lbUserName.Text" reference in templatepdf.aspx.cs and formg28pdf.aspx.cs
2) Commented out "Response.Redirect("http://www.losrpc.com");" in Default.aspx.cs

Shivaji Notes:
--------------
shivaji - 986-613-4819
Copy these folders from the ftp site (wwwroot):

app_code
attorney
bin
css
employee
employer
images
jscripts
lang
orgpdf
scripts
(Also at the wwwroot level copy Default.aspx and web.config)

To Create a new VS project, click on File-> Open-> Web Site...-><clcik on the folder in which the above contents are copied>. 
This will automatically creates a solution file and save it accordingly.

Bugs: 4/6/10

Form-I129H Attorney's area code missing
	ref: C:\_NET\Projects\WIMS\attorney\formi129hpdf.aspx.cs         
		theDoc.Form["topmostSubform[0].Page4[0].Attorneys_PhoneNumber[0]"].Value = OF.f6_Daytime_Phone_Number2;

Changes: 11/20/10

To give all menu options same as "Admin" user to "Normal" user except "User Accounts"
	-App_Code/clsGeneral.cs
	-attorney/userlog.aspx.vb

Changes: 12/22/10

New Form 129H Changes: (password: jaws)
	-App_Code/clsGeneral.cs
	-attorney/form_i129*
	
\\ External LCA Website link
http://ibiztool.com/raminenilaw/Default.aspx 