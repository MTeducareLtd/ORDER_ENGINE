var connection = new ActiveXObject("ADODB.Connection");
var connectionstring = "Data Source=.;Initial Catalog=EmpDetail;Persist Security Info=True;User ID=sa;Password=****;Provider=SQLOLEDB";
connection.Open(connectionstring);
var rs = new ActiveXObject("ADODB.Recordset");