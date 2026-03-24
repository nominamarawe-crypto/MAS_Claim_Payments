<%@LANGUAGE="VBSCRIPT" CODEPAGE="1252"%> 
<!--#include file="../../../Connections/ConnOra.asp" -->
<html>
<head>
<STYLE TYPE="text/css">
     P.breakhere {page-break-before: always}
</STYLE> 
<meta HTTP-EQUIV="expires" CONTENT="0">
<meta HTTP-EQUIV="Pragma" CONTENT="no_cache">
</head>

<body>
<%
Public Function NumToString(ByVal nNumber)
Dim bNegative
Dim bHundred
If nNumber < 0 Then
    bNegative = True
End If
nNumber = Abs(Int(nNumber))
If nNumber < 1000 Then
    If nNumber \ 100 > 0 Then
        NumToString = NumToString &""&NumToString(nNumber \ 100) & " hundred"
        bHundred = True
    End If
    nNumber = nNumber - ((nNumber \ 100) * 100)
    Dim bNoFirstDigit
    bNoFirstDigit = False
    Select Case nNumber \ 10
        Case 0
            Select Case nNumber Mod 10
                Case 0
                    If Not bHundred Then
                        NumToString = NumToString & " zero"
                    End If
                Case 1: NumToString = NumToString & " one"
                Case 2: NumToString = NumToString & " two"
                Case 3: NumToString = NumToString & " three"
                Case 4: NumToString = NumToString & " four"
                Case 5: NumToString = NumToString & " five"
                Case 6: NumToString = NumToString & " six"
                Case 7: NumToString = NumToString & " seven"
                Case 8: NumToString = NumToString & " eight"
                Case 9: NumToString = NumToString & " nine"
            End Select
            bNoFirstDigit = True
        Case 1
            Select Case nNumber Mod 10
                Case 0: NumToString = NumToString & " ten"
                Case 1: NumToString = NumToString & " eleven"
                Case 2: NumToString = NumToString & " twelve"
                Case 3: NumToString = NumToString & " thirteen"
                Case 4: NumToString = NumToString & " fourteen"
                Case 5: NumToString = NumToString & " fifteen"
                Case 6: NumToString = NumToString & " sixteen"
                Case 7: NumToString = NumToString & " seventeen"
                Case 8: NumToString = NumToString & " eighteen"
                Case 9: NumToString = NumToString & " nineteen"
            End Select
            bNoFirstDigit = True
        Case 2: NumToString = NumToString & " twenty"
        Case 3: NumToString = NumToString & " thirty"
        Case 4: NumToString = NumToString & " forty"
        Case 5: NumToString = NumToString & " fifty"
        Case 6: NumToString = NumToString & " sixty"
        Case 7: NumToString = NumToString & " seventy"
        Case 8: NumToString = NumToString & " eighty"
        Case 9: NumToString = NumToString & " ninety"
       End Select
    If Not bNoFirstDigit Then
        If nNumber Mod 10 <> 0 Then
            NumToString = NumToString & " " & Mid(NumToString(nNumber Mod 10), 2)
        End If
    End If
Else    
    Dim nTemp 
    nTemp = 10 ^ 12 'trillion
    Do While nTemp >= 1
        If nNumber >= nTemp Then
            NumToString = NumToString &""& NumToString(Int(nNumber / nTemp))
            Select Case Int(Log(nTemp) / Log(10) + 0.5)
                Case 12: NumToString = NumToString & " trillion"
                Case 9: NumToString = NumToString & " billion"
                Case 6: NumToString = NumToString & " million"
                Case 3: NumToString = NumToString & " thousand"
            End Select
           
            nNumber = nNumber - (Int(nNumber / nTemp) * nTemp)
        End If
        nTemp = nTemp / 1000
    Loop
End If

If bNegative Then
    NumToString = " negative" & NumToString
End If
    
End Function
Public Function AmountToString(ByVal nAmount)
    Dim nDollar    
    Dim nCent
    
    nDollar = Int(nAmount)
    ''nCent = (Abs(nAmount) * 100) Mod 100   //over flow error >9
    ''// Develop code
Dim nPos
   nPos = InStr(1, nAmount, ".", vbTextCompare)
    'nPos = InStr(nAmount, ".")
   
   nCent = Mid(nAmount, nPos + 1, 2)
   
   if (Len(nCent) = 1) then
   		nCent = nCent * 10
   else
   		nCent = nCent
   end if
    
    AmountToString = NumToString(nDollar)
    
    
   'If Abs(nDollar) <> 1 Then
   '    AmountToString = AmountToString & "s"
   'End If
    
        If nCent <> 0 Then
            AmountToString = AmountToString & " and" & _
                              " cents" & NumToString(nCent)
        End If     
        

    
    If Abs(nCent) <> 1 Then
        AmountToString = AmountToString & ""
    End If
    AmountToString = AmountToString & " only"
End Function

/////////////////////////////////////////////// VALUE IN WORDS
  
Dim dataSource
dataSource = ConnOra 

set rs = Server.CreateObject("ADODB.Recordset")
rs.ActiveConnection = dataSource 

set rs5 = Server.CreateObject("ADODB.Recordset")
rs5.ActiveConnection = dataSource 

%>


<form action="Addconfirm.asp" method="post" onsubmit="return FrontPage_Form1_Validator(this)" language="JavaScript" id=form1 name=FrontPage_Form1>
  <h2 align="left"><b><font color="#000000" face="Trebuchet MS" size="3"> </font></b></h2>
 
<p align="center">
<font color="#1251BE">
<%

claimno2=Ucase(Mid(session("Clmno"), 3,10))
claimno=session("Clmno")

Bank =   trim(request.form("Bank"))  
Bankbr =   Trim(request.form("Bankbr"))  	
Accno =   trim(request.form("Accno")) 
NVoucher =   trim(request.form("Nvoucher")) 
if  trim(request.form("Yname")) <> "" then
	AName= trim(request.form("Yname")) 
else
	AName=""
end if


Comdate=Session("Cdate")
TableTerm=Session("table")&" - "&Session("Term")
Netpay = cdbl( total ) - cdbl( totalded )
netpay = formatnumber(netpay,2,0)
if cdbl(session("DfPrm")) = 0 then
	demand=" No Outstanding demands"
end if 
Tot= "*****"& Total 
Totded= "*****"& Totalded 
if netpay > 0 then
	Netpay1= "*****"&Netpay
else
	Netpay1="Please check the Amounts."
end if 

Add1= Trim(Request.form("Add1"))
Add2=Trim(Request.form("Add2"))
Add3=Trim( Request.form("Add3"))
Add4=Trim( Request.form("Add4"))
nAME1=Trim( Request.form("Name1"))
	
set rs1 = Server.CreateObject("ADODB.Recordset")
rs1.ActiveConnection = dataSource 

sql="select * from lclm.valfile where ValPOL=" & chr(39) &_
session("Polno") & chr(39) 
rs1.open( sql)
if not rs1.EOF  then
	AgeV= rs1.fields("VALAGE1")
else
	ageV =0
end if
rs1.Close

B0="1"

sql="select * from lclm.lcmmast where Pclaimno=" & chr(39) &_
session("Clmno") & chr(39)  &_
"And PTyp=" & chr(39) &_
B0 & chr(39) 
rs.open(sql)

If rs.EOF and rs.BOF then

%>
	&nbsp;<br>
	<font face="Trebuchet MS" size="2" color="#800000"><b>
	Claim Number is incorrect./No details available. </b></font>
 
	
<table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="92%" id="AutoNumber2">
  <tr> 
    <td width="13%"></td>
    <td width="13%"></td>
    <td width="12%"></td>
    <td width="12%"> </td>
    <td width="50%"> </td>
  </tr>
  <tr> 
    <td height="23"></td>
    <td></td>
    <td></td>
    <td>&nbsp;</td>
    <td></td>
  </tr>
  <tr> 
    <td width="13%"></td>
    <td width="13%"></td>
    <td width="12%"></td>
      <td width="12%"> <font color="#B96532">&nbsp;</font> </td>
    <td width="50%"> </td>
  </tr>
  <tr> 
    <td width="13%">&nbsp;</td>
    <td width="13%">&nbsp;</td>
    <td width="12%">&nbsp;</td>
    <td width="12%"> </td>
    <td width="50%">&nbsp; </td>
  </tr>
</table>
<%
else
'***********************

claimno2=right(session("Clmno"),8)

Sumass= rs.fields("PSUM")
Sumass=formatnumber(sumass,2,0)
paidup=formatnumber(rs.fields("ppayamt"),2,0)
addsum=formatnumber(rs.fields("padsum"),2,0)
Excess=formatnumber(rs.fields("pelprm"),2,0)
Deposit=formatnumber(rs.fields("peldep"),2,0)
vbonus=formatnumber(rs.fields("pvbonus"),2,0)
ibonus=formatnumber(rs.fields("pibonus"),2,0)
sjamt=formatnumber(rs.fields("padsja"),2,0)
Addpa=formatnumber(rs.fields("paoad1"),2,0)
Other=formatnumber(rs.fields("paoad2"),2,0)
dedam1=rs.fields("pdedam1")
dedam2=rs.fields("pdedam2")
Total= cdbl(Other) + cdbl(ADDPA) + cdbl(SJAMT) + cdbl(paidup) + cdbl(VBonus) + cdbl(IBonus)
total=formatnumber(total,2,0)


Dfprm=session("Dfprm") 'formatnumber(rs.fields("PDEFPRM"),2,0)
Dfprm=formatnumber(Dfprm,2,0)
DPInt=session("DPInt") 'formatnumber(rs.fields("pdefint"),2,0)
DPInt=formatnumber(DPInt,2,0)
Maturity= cdbl(session("Dfprm") ) + cdbl(session("DPInt"))
Maturity= formatnumber(Maturity,2,0)
Capital1=formatnumber(rs.fields("ploncap"),2,0)
interest1=formatnumber(rs.fields("plonint"),2,0)
Ldfpr=formatnumber(rs.fields("pdiffpr"),2,0)
Ldpint=formatnumber(rs.fields("pdiffin"),2,0)
Sbonus=formatnumber(rs.fields("psbonus"),2,0)
Sbonuy=formatnumber(rs.fields("psbonuy"),2,0)
ODed=cdbl(rs.fields("Pdedam1")) + cdbl(rs.fields("Pdedam2"))

Otherded=formatnumber(Oded,2,0)
Totalded= cdbl(capital1) + cdbl(interest1)+ cdbl(sbonus) +cdbl(ldfpr) + cdbl(ldpint) + cdbl(otherded) + cdbl(dfprm) + cdbl(dpint)
totalded= formatnumber(totalded,2,0)

Netpay = cdbl( total ) - cdbl( totalded)
netpay = formatnumber(netpay,2,0)
if cdbl(session("DfPrm")) = 0 then
	demand=" No Outstanding demands"
end if 
Tot= "*****"& Total 
Totded= "*****"& Totalded 
if netpay > 0 then
	Netpay1= "*****"&Netpay
else
	Netpay1="Please check the Amounts."
end if 

'************************		
Set Conn = Server.CreateObject("ADODB.Connection")
		Conn.Open ConnOra  
		'Conn.Open   dataSource
	'Start RollBack/Commit--------------------------------
	Conn.BeginTrans	
'************************

B1A=rs.fields("POBRN")
A1=rs.fields("PTable")
A2=rs.fields("PTerm")
Epf = 5966
if session("userid") <>"" then
	ADDUSR=session("userid")
else
	ADDUSR=""
end if

Dim a,  DemandArray(100,2)
b = request.form("count1")

for a = 1 to b 
 DemandArray(a,1) =   request.form("demanddue"&a)  
  DemandArray(a,2) =   request.form("Demand"&a) 
	next
		B1=3

			'	***********Modified 2006/07/18**********
		if cdbl(total) > cdbl(session("Capital")) then
			B2=cdbl(session("Capital"))
		else 
			B2= cdbl(total)
		End if
		
		if netpay > 0 then	
			B3=cdbl(session("Interest"))
		elseif cdbl(total) > cdbl(session("Capital")) then
			B3=cdbl(total)-cdbl(session("Capital"))
		else
			B3 = 0
		end if
		if netpay <= 0 then
			WR=cdbl(session("Capital")) + cdbl(session("Interest")) - cdbl(total)
		else
			WR=0
		end if
		'****************
		
		
epf=Session("Epfnum")
B5=clng(Epf)
CMDDAT=left(Session("Cdate"),4)&mid(Session("Cdate"),6,2)& right(Session("Cdate"),2)
comdate1=clng(cmddat)
Yeard= year(date)
Monthd= Month(date)
Dayd=  day(date)


if cint(monthd) < 10   then
	monthd = 0 &monthd
end if   
   
if cint(Dayd) < 10   then
	dayd = 0 &dayd
end if  
enterdate =  Yeard & Monthd &  Dayd 
DateP =  Yeard &"/"& Monthd &"/"&  Dayd 
B6=  clng(enterdate)
B6A=Time
B6B=LCase(Request.ServerVariables("REMOTE_ADDR"))    ' Client's IP address
B7=clng(Session("Brcode"))
B8= clng(enterdate)
B9=9
	
if  cdbl(session("Capital")) > 0   Then  

	set rs3 = Server.CreateObject("ADODB.Recordset")
	rs3.ActiveConnection = dataSource 
	sql="select  max(RCNO) from lpay.rcptno where rcyear="  &_
	Yeard   &_
	"AND  RCBRNO ="   &_
	B7    &_
	"AND Rctype="    &_
	B9   &_
	"ORDER BY RCYEAR, RCBRNO, RCTYPE"
	rs3.open( sql)
	
	if not  rs3.EOF  then 
       	B10 =151 ' clng(rs3.fields("max(RCNO)")) + 1
       	
		SQL = "UPDATE lpay.rcptno set RCNO="& B10 &" where ((RCBRNO="& B7 &") And (RCYEAR="& Yeard&") And (RCTYPE="& B9&"))" 
		rs5.open(Sql)		
	else
		B10=1
	  	SQL = "insert into lpay.rcptno (RCBRNO,RCYEAR,RCTYPE,RCNO) VALUES ("& B7 &","& Yeard &","& B9 &","& B10 &")"
	  	rs5.open(Sql)	   		
	end if
	rs3.Close

end if
		
B11=cdbl(session("Capital"))
B12=cdbl(session("Interest"))
    
SQL = "UPDATE lclm.lcmmast set PDocno="& B1 &",PLoncap2="& B2 &",PLonint2="& B3 &" ,PLonWRT="& WR &" where ((Pclaimno='"& claimno &"') And (PTyp='"& B0 &"'))" 
rs5.open(SQL)

BF1=claimno
B20=clng(Session("Loanno")) 
B21=clng(Session("Polno")) 
BF2=clng(paidup)
BF3=cdbl(addsum)
BF4=cdbl(SJamt)
BF5=cdbl(Addpa)
BF6=cdbl(Other)
	
if   session("Lstatus") = "Inforce" then
	BF7="I"
elseif  session("Lstatus") = "Lapse" then
	BF7="L"
end if 

If trim(request.form("AGEADD"))= "Yes" Then
	BF8="Y"
elseif   trim(request.form("AGEADD")) = "No" then
	BF8="N"
end if 

BF9=trim(request.form("ASSADD"))
BF10=cdbl(excess)
BF11=cdbl(deposit)
BF12=cdbl(session("Dfprm"))
BF13=cdbl(session("DPInt"))
BF14=Cdbl(Ldfpr)
BF15=cdbl(Ldpint)
BF16= Dedrs1

BF17=cdbl(dedam1)
BF18= Pdedrs2 
BF19=cdbl(dedam2)
BF20=cdbl(Vbonus) + cdbl(Ibonus)
BF21= cdbl(sbonuy)
BF22= cdbl(sbonus)
BF23=cdbl(Vbonus)
BF24=cdbl(Ibonus)
BF25=trim(request.form("YNAME"))
BF26=NVoucher
if netpay > 0 then
	BF27=cdbl(netpay)
else
	BF27=0
end if 

set rs3 = Server.CreateObject("ADODB.Recordset")
rs3.ActiveConnection = dataSource 
sql="select * from LCLM.LCLMFNL where PCLAIMNO=" & chr(39) &_
claimno & chr(39)  &_
"And PPTYPE=" & chr(39) &_
B0 & chr(39) 
rs3.open( sql)

if rs3.EOF  then

	'SQL = "insert into  LCLM.LCLMFNL (PPTYPE,PCLAIMNO,PDOCNO,PPOLNO,PPAYAMT) VALUES ('"& B0 &"','"& BF1 &"',"& B1 &","& B21 &","& BF2 &")"
	SQL = "insert into lclm.lclmfnl (Pptype,Pclaimno,PDocno,Ppolno,Ppayamt,Padsum,Padsja,Paoad1,Paoad2,Pppstat,paadd,Pascd,Pelprm,Peldep,plonno,ploncap,plonint,Pdefprm,Pdefint,PDiffpr,PDiffin,Pdedrs1,Pdedam1,Pdedrs2,Pdedam2,Pbonus,PSbonuy,PSbonus,PVBonus,PIBonus,Petri,Peepf,Pedat,Pasna,Pvou,Pnettot) VALUES ('"& B0 &"','"& BF1 &"',"& B1 &","& B21 &","& BF2 &","& BF3 &","& BF4 &","& BF5 &","& BF6 &",'"& BF7 &"','"& BF8 &"','"& BF9 &"',"& BF10 &","& BF11 &","& B20 &","& B11 &","& B12 &","& BF12 &","& BF13 &","& BF14 &","& BF15 &",'"& BF16 &"',"& BF17 &",'"& BF18 &"',"& BF19 &","& BF20 &","& BF21 &","& BF22 &","& BF23 &","& BF24&",'"& B6B &"',"& B5 &","& B6 &",'"& BF25&"',"& BF26&","& BF27&")"
	rs5.open( sql)
end if
'rs5.Close
rs3.Close

'  2006/05/19 ****************************Loan File

set rs2 = Server.CreateObject("ADODB.Recordset")
rs2.ActiveConnection = dataSource 
sql="select * from lphs.lplmast where LMPOL=" & chr(39) &_
session("Polno") & chr(39)  &_
"AND Lmlon=" & chr(39)  &_
Session("Loanno")  & chr(39)
rs2.open( sql)
	
if not rs2.EOF  then

'2006/08/11 ****************************Loan History  File

L0=clng(rs2.fields("Lmlon"))
if  Not(isNull(trim(rs2.fields("Lmpdt")))) then
	L1=clng(rs2.fields("Lmpdt"))
else 
	L1=0
end if

if  Not(isNull(trim(rs2.fields("Lmpcp")))) then
	L2=cdbl(rs2.fields("Lmpcp"))
else 
	L2=0
end if

if  Not(isNull(trim(rs2.fields("Lmpit")))) then
	L3=cdbl(rs2.fields("Lmpit"))
else 
	L3=0
end if

if  Not(isNull(trim(rs2.fields("Lmnid")))) then
	L4=clng(rs2.fields("Lmnid"))
else 
	L4=0
end if

if  Not(isNull(trim(rs2.fields("Lmncp")))) then
	L5=cdbl(rs2.fields("Lmncp"))
else 
	L5=0
end if

if  Not(isNull(trim(rs2.fields("Lmnit")))) then
	L6=cdbl(rs2.fields("Lmnit"))
else 
	L6=0
end if

if  Not(isNull(trim(rs2.fields("Lmebr")))) then
	L7=clng(rs2.fields("Lmebr"))
else 
	L7=0
end if

if  Not(isNull(trim(rs2.fields("Lmlrd")))) then
	L8=clng(rs2.fields("Lmlrd"))
else 
	L8=0
end if

if  Not(isNull(trim(rs2.fields("Lmsbr")))) then
	L9=clng(rs2.fields("Lmsbr"))
else 
	L9=0
end if

if  Not(isNull(trim(rs2.fields("Lmpty")))) then
	L10=cdbl(rs2.fields("Lmpty"))
else 
	L10=0
end if

if  Not(isNull(trim(rs2.fields("Lmrnb")))) then
	L11=clng(rs2.fields("Lmrnb"))
else 
	L11=0
end if

if  Not(isNull(trim(rs2.fields("Lmcpy")))) then
	L12=cdbl(rs2.fields("Lmcpy"))
else 
	L12=0
end if

if  Not(isNull(trim(rs2.fields("Lmipy")))) then
	L13=cdbl(rs2.fields("Lmipy"))
else 
	L13=""
end if

if  Not(isNull(trim(rs2.fields("Lmccp")))) then
	L14=cdbl(rs2.fields("Lmccp"))
else 
	L14=0
end if

if  Not(isNull(trim(rs2.fields("Lmcit")))) then
	L15=cdbl(rs2.fields("Lmcit"))
else 
	L15=0
end if

if  Not(isNull(trim(rs2.fields("Lmepf")))) then
	L16=clng(rs2.fields("Lmepf"))
else 
	L16=0
end if

if  Not(isNull(trim(rs2.fields("Lmedt")))) then
	L17=clng(rs2.fields("Lmedt"))
else 
	L17= 0
end if

L18=clng(B7)
L19=Clng(B8)
L20=5
L21=clng(B10)
L22=clng(rs2.fields("Lmlsuf"))

set rs3 = Server.CreateObject("ADODB.Recordset")
rs3.ActiveConnection = dataSource 
sql="select * from lpay.lpaytrn " 
rs3.open(sql)
rs3.close

SQL = "insert into lpay.lpaytrn (Ltlon,Ltpdt,LTPCP,LTPIT,LTNID,LTNCP,LTNIT,LTEBR,LTLRD,LTSBR,LTPTY,LTRNB,LTCPY,LTIPY,LTCCP,LTCIT,LTEPF,ltedt,ltebrc,Ltlrdc,Ltptyc,Ltrnbc,Ltlsuf) VALUES ("& L0 &","& L1 &","& L2 &","& L3 &","& L4 &","& L5 &","& L6 &","& L7 &","& L8 &","& L9 &","& L10 &","& L11 &","& L12 &","& L13 &","& L14 &","& L15 &","& L16 &","& L17 &","& L18 &","& L19 &","& L20 &","& L21 &","& L22 &")"

'SQL = "insert into lpay.lpaytrn (Ltlon,LTPDT,LTPCP,LTPIT,LTNID,LTNCP,LTNIT,LTEBR,LTLRD,LTSBR,LTPTY,LTRNB,LTCPY,LTIPY,LTCCP,LTCIT,LTEPF,ltedt,ltebrc,Ltlrdc,Ltptyc,Ltrnbc,Ltlsuf) VALUES ("& L0 &","& L1 &"',"& L2 &","& L3 &","& L4 &","& L5 &","& L6 &","& L7 &","& L8 &","& L9 &","& L10 &","& L11 &","& L12 &","& L13 &","& L14 &","& L15 &","& L16 &","& L17 &","& L18 &","& L19 &","& L20 &","& L21 &","& L22 &")"
'SQL = "insert into lpay.lpaytrn (Ltlon,LTPDT,LTPCP,LTPIT,LTNID,LTNCP,LTNIT,LTEBR,LTLRD,LTSBR,LTPTY,LTRNB,LTCPY,LTIPY,LTCCP,LTCIT,LTEPF,ltedt,Ltlsuf) VALUES ("& L0 &","& L1 &"',"& L2 &","& L3 &","& L4 &","& L5 &","& L6 &","& L7 &","& L8 &","& L9 &","& L10 &","& L11 &","& L12 &","& L13 &","& L14 &","& L15 &","& L16 &","& L17 &","& L22 &")"
 rs5.open(sql)

'SQL = "insert into lpay.lpaytrn (Ltlon,LTPDT,LTPCP,LTPIT,LTNID,LTNCP,LTNIT,LTEBR,LTLRD,LTSBR,LTPTY,LTRNB,LTCPY,LTIPY,LTCCP,LTCIT,LTEPF,ltedt,ltebrc,Ltlrdc,Ltptyc,Ltrnbc,Ltlsuf) VALUES ("& L0 &","& L1 &"',"& L2 &","& L3 &","& L4 &","& L5 &","& L6 &","& L7 &","& L8 &","& L9 &","& L10 &","& L11 &","& L12 &","& L13 &","& L14 &","& L15 &","& L16 &","& L17 &","& L18 &","& L19 &","& L20 &","& L21 &","& L22 &")"
' rs3.open( sql)
'***************2006/08/28***************************** 
'***************2006/08/15*****************************
	
B13=cdbl(session("Capital")) + cdbl(rs2.fields("LMCCP"))
B14=cdbl(session("Interest")) + cdbl(rs2.fields("LMCIT"))
B15=cdbl(rs2.fields("LMLSUF")) + 1
B18="Y" 'LMSET		
B19="C"'LMCD3
	
SQL = "UPDATE lphs.lplmast set LMEBR="& B7 &",Lmlrd="& B8 &",Lmpty="& B9 &",Lmrnb="& B10 &",LMCPY="& B11 &",LmIpy="& B12 &",LmCCP="& B13 &",Lmcit="& B14 &",LMLSUF="& B15 &",Lmcepf="& B5 &",Lmcedt="& B6 &",Lmset='"& B18 &"',lmcd3='"& B19 &"'  where Lmlon=" &_ 
Session("Loanno")				
rs5.open(SQL)
 
end if
rs2.close
'rs5.Close


'* 2006/05/19 *************************88
if  cdbl(session("Capital")) > 0   Then 
	B20=cdbl(Session("Loanno")) 
	B21=cdbl(Session("Polno")) 
	B22="C"
	if cdbl(Netpay) > 0 then
		B23=cdbl(session("Interest")) + cdbl(session("Capital"))
		B24 =0 ' Short Amount/ Write Off Amount
	else
		B23=Cdbl(Total) 
		B24=cdbl(WR)
	End if

	set rs2 = Server.CreateObject("ADODB.Recordset")
	rs2.ActiveConnection = dataSource 
	sql="select * from lpay.lplledg" 
	rs2.open( sql)
	rs2.close
	
   	SQL = "insert into lpay.lplledg (LLON,LSUF,LPOL,LREC,LPDT,LPTP,LPBR,LCAP,LINT,LTYP1,LAMT1) VALUES ("& B20 &","& B15 &","& B21 &","& B10 &","& B6 &","& B9 &","& B7 &","& B11 &","& B12 &",'"& B22 &"',"& B23 &")"
	rs5.open(Sql)
end if

 if  cdbl(session("Capital")) > 0   Then 
	'**************2006/05/22********************************	
	B24="3"  'Type=Loan,claim
	B25="5"  'Type=Loan,claim 'LPMD1
	B26=2235 ' ACCOUNT CODE
	B27="LKR" ' Currency Code

	set rs3 = Server.CreateObject("ADODB.Recordset")
	rs3.ActiveConnection = dataSource 

	sql="select  * from lpay.lpaymas where lpptd="  &_
	B6  &_
	"AND LPBRN =" & chr(39)   &_
	B7  & chr(39)  &_
	"AND LPBTP="  & chr(39)  &_
	B24 & chr(39)&_
	"AND LPREC="    &_
	B10  
	rs3.open( sql)

	if  rs3.EOF  then
	BP="0"
		SQL = "insert into  lpay.lpaymas(LPBRN,LPPTD,LPBTP,LPREC,LPBOC,LPPOL,LPPTP,LPMD1,LPAM1,LPCA1,LPCA2,LPCA4,LPSBR,LPEDT,LPTIM,LPIPA,LPACD,LPOPR, LPSTA,LPCUR) VALUES ("& B7 &","& B6 &",'"& B24 &"',"& B10 &","& B20 &","& B21 &",'"& B24 &"','"& B25 &"',"& B23 &","& B11 &","& B12 &","& WR &","& B1A &","& B6 &",'"& B6A &"','"& B6B &"',"& B26 &","& B5 &",'"& BP &"','"& B27 &"')"
		'SQL = "insert into  lpay.lpaymas (LPBRN,LPPDT,LPBTP,LPREC,LPBOC,LPPOL,LPPTP,LPMD1,LPAM1,LPEDT,LPTIM,LPACD,LPOPR) VALUES ("& B7 &","& B6 &",'"& B24 &"',"& B10 &","& B20 &","& B21 &",'"& B24 &"','"& B25 &"',"& B23 &","& B6 &",'"& B6A &"',"& B26 &","& B5 &")"
		rs5.open(Sql)
	
	end if
	rs3.Close
	
end if 

 '*************** Indika RollBack*********
	
 %>

 </p>
</font>

 <tr height=7 style='height:12.75pt'>
  <td height=17 width=272 style='height:12.75pt;width:204pt'></td>
  <td class=xl26 width=16 style='width:12pt'></td>
  <td width=320 style='width:240pt'></td>
 </tr>
 <tr height=7 style='height:12.75pt'>
    <td height=17 class=xl24 style='height:12.75pt'> <p align="center">&nbsp;
      <p align="center">&nbsp;
      <p align="center">&nbsp;
</td>
    <td class=xl25>&nbsp;</td>
    <td class=xl25>&nbsp;</td>
  </tr>
  <table x:str border="0" cellpadding="0" cellspacing="0" width="719" style="border-collapse:
 collapse;width:434pt">
    <colgroup>
    <col width="272" style="width: 204pt">
    <col width="16" style="width: 12pt">
    <col width="92" style="width: 69pt">
    <col width="106" style="width: 80pt">
    <col width="17" style="width: 13pt">
    <col width="74" style="width: 56pt">
    </colgroup>
    <tr height="7" style="height:12.75pt"> 
      <td width="136" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">MATURITY 
        <span style='mso-spacerun:yes'>  </span>CLAIMS<span
  style='mso-spacerun:yes'>  </span>-<span style='mso-spacerun:yes'>FINAL   </span>PAYMENT<span style='mso-spacerun:yes'>  
        </span>MEMO</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Claim&nbsp; Number</td>
      <td width="93" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td width="20" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=session("Clmno")%></font></td>
      <td width="226" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Policy&nbsp; Number</td>
      <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td width="80" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=session("Polno")%></font></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Date&nbsp; of Commencement</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Comdate%></font></td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Table&nbsp; &amp;&nbsp; Term</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><b><font color="#002E5B"><%=TableTerm%></font><font size="2" face="Verdana" color="#CC3300"></font></b></font></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Date&nbsp; of Maturity</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=session("MatDate")%></font></td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Policy&nbsp; Status</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><b><font color="#002E5B"><%=session("Lstatus")%></font></b></font></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Sum&nbsp; Assured</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=session("Sumass")%></font></td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><b><font color="#002E5B"> 
        <b><font color="#002E5B"> </font></b> </font></b></font></td>
    </tr>
    <tr height="18" style="height: 13.5pt"> 
      <td height="18" colspan="2" style="height: 13.5pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Assured's&nbsp; Name</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td colspan="4" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Response.Write(Name1)%></font></td>
    </tr>
    
   
    <tr height="17" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        ADDITIONS</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="17" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="17" style="height:12.75pt"> 
      <td height="7" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Sum&nbsp; Assured</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=Paidup%></font></div></td>
    </tr>
    <tr height="17" style="height:12.75pt"> 
      <td height="7" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Vested&nbsp; Bonus</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=VBonus %></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Interim&nbsp; Bonus</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=IBonus %></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Swarna&nbsp; Jayanthi&nbsp; Amount</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=SJAmt%></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="5" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Difference of Premium of Age - Over Stated</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=Addpa%></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Other&nbsp; Additions</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=Other%></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Total&nbsp; Additions</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><strong><%=tot%></strong></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        DEDUCTIONS</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Default&nbsp; Premium</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=formatNumber(session("Dfprm"),2,0)%></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Interest thereon</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=FormatNumber(session("DPInt"),2,0)%></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Loan <font color="#002E5B"><%=Response.write("     ")%> <strong><%=session("loanno")%></strong></font></td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=session("Capital")%></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Interest&nbsp; on Loan</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=session("Interest")%></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Difference of Premium of Age - Under Stated</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=Ldfpr%></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Interest thereon</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=LDpInt%></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Bonus&nbsp; Surrender</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">:</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=session("STotalBonus")%></font></div></td>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Other Deductions</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">:</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=FormatNumber(Session("OtherDed"),2,0)%></font></div></td>
    <tr height="8" style="height: 13.5pt"> 
      <td height="18" colspan="2" style="height: 13.5pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Total&nbsp; Deductions</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">:</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><strong><%=totded%></strong></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Net&nbsp; Amount&nbsp; Payable</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">:</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><b><font color="#002E5B"><em><%=NetPay1%></em></font></b></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Deposit&nbsp; to be&nbsp; Refunded</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">:</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=session("deposit")%></font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Outstanding&nbsp; Demands </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">:</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><b><font color="#002E5B"><%=response.write(trim(demand))%></font></b></font></div></td>
    </tr >
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><b></b></font></td>
  </table>
     <table width="614" cellpadding="0" cellspacing="0" bordercolor="#111111" bordercolorlight="#CC3300" style="border-collapse: collapse">
      
<%  

set rs1 = Server.CreateObject("ADODB.Recordset")
rs1.ActiveConnection = dataSource 

sql="select * from lphs.demand where pdPOL=" & chr(39) &_
session("Polno") & chr(39)  &_ 
"order by pddue"
rs1.open( sql)
 
While not rs1.EOF
  
	if (rs1.fields("pdcod") = "1" or  rs1.fields("pdcod") = "2"  or  rs1.fields("pdcod") = "3") then

 		DYear= Left(rs1.Fields("Pddue"),4) 
 		dMonth= right(rs1.Fields ("Pddue"),2) 
 		Demanddue=Dyear & " / " &Dmonth 
 
 		if rs1.fields("pdcod") = "1" then
 			pdcode="DEF"
 		elseif rs1.fields("pdcod") = "2" then
  			pdcode="GRP"
 		elseif rs1.fields("pdcod") = "3" then
 			pdcode="NGR"
 		End if 
 		amount= formatNumber(rs1.fields("pdprm"),2,0)
 		for a= 1 to b 
			if    (DemandArray(a,1)=trim(rs1.Fields("pddue"))) then
				if (DemandArray(a,2)="N") then
					DemandT= " Not Received"
					' Demand file Update 2006/05/23
					'*******************
				elseif (DemandArray(a,2)="X") then
					DemandT= "Waved" 
				end if
			
		
%>
      <td height="10" width="278" bgcolor="#F0F0F0" bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" style="border-style: solid; border-width: 1"> 
        <p align="rightt"><font color="#000000"> 
          <%Response.Write(demanddue &"  -  " &pdcode&"  -  "&Amount&"  -  "&DemandT)%>
		  
		   		 </td>
<%
	
			Exit for
		end if
	next
	end if

rs1.moveNext
wend 
rs1.Close 
%>

  </table>
 

<table x:str border="0" cellpadding="0" cellspacing="0" width="623" style="border-collapse:
 collapse;width:434pt">
  <tr height="7" style="height:12.75pt"> 
    <td height="17" colspan="7" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">Particulars 
      of the Bank Account </font> <font color="#000000">&nbsp; </font> <font color="#002E5B">&nbsp; 
      </font> </td>
  </tr>
  <tr>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">Bank 
      &amp; Bank Branch</font> <font color="#000000">&nbsp; </font> <font color="#002E5B">&nbsp; 
      </font> </td>
     <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="left"><font color="#002E5B"><%=Response.Write(trim(Bank) &"  " &trim(BankBr))%></font></div></td>
    </tr>
  <tr>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">Account 
      Number</font> <font color="#000000">&nbsp; </font> <font color="#002E5B">&nbsp; 
      </font> </td>
    <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><%=Response.Write(Accno)%></td>
  </tr>
   <tr>
      <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000"> 
        Number</font> <font color="#000000">of Vouchers issued&nbsp; </font> <font color="#002E5B">&nbsp; 
        </font> </td>
    <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><%=Response.Write(NVoucher)%></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="51" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
      </font> </td>
    <td width="12" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
      </font> </td>
    <td width="13" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
    </td>
    <td width="13" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B">&nbsp; 
      </font></td>
    <td width="92" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
    </td>
    <td width="86" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
    </td>
    <td width="164" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">
    <%Response.Write(Date &"  " & Time)%>
    <td width="13" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
      </font> </td>
    <td width="92" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
    </td>
    <td width="86" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><strong>.....................</strong></font></td>
    <td width="164" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="center"><font color="#002E5B"><strong>..........................</strong></font></div></td>
    <td width="24" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td width="124" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
    </td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      Date :</td>
    <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
    </td>
    <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
    </td>
    <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">Prepared 
      By </td>
    <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="center">Checked By</div></td>
  </tr>
</table>


	
<table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="92%" id="AutoNumber2">
  <tr> 
    <td width="13%"></td>
    <td width="13%"></td>
    <td width="12%"></td>
    <td width="12%"> </td>
    <td width="50%"> </td>
  </tr>
  <tr> 
    <td height="23"></td>
    <td></td>
    <td></td>
    <td>&nbsp;</td>
    <td></td>
  </tr>
  <tr> 
    <td width="13%"></td>
    <td width="13%"></td>
    <td width="12%"></td>
    <td width="12%"> <font color="#B96532">&nbsp;</font> </td>
    <td width="50%"> </td>
  </tr>
  <tr> 
    <td width="13%">&nbsp;</td>
    <td width="13%">&nbsp;</td>
    <td width="12%">&nbsp;</td>
    <td width="12%"> </td>
    <td width="50%">&nbsp; </td>
  </tr>
</table>

<P CLASS="breakhere" > 

<% 
if  cdbl(session("Dfprm")) > 0   Then
	'***********2006/07/25********
	R9=8
	set rs4 = Server.CreateObject("ADODB.Recordset")
	rs4.ActiveConnection = dataSource 
	sql="select  max(RCNO) as maxrecno from lpay.rcptno where rcyear="  &_
	Yeard   &_
	"AND  RCBRNO =" & chr(39)   &_
	B7  & chr(39)  &_
	"AND Rctype="    &_
	R9   &_
	"ORDER BY RCYEAR, RCBRNO, RCTYPE"
	rs4.open(sql)
	
	if  not  rs4.EOF  then
	if  Not(isNull(trim(rs4.fields("maxrecno")))) then
		'response.write(rs4.fields("maxrecno"))
      	R10 = cint(rs4.fields("maxrecno")) + 1
	else
		R10=1
		end if	
		SQL = "UPDATE lpay.rcptno set RCNO="& R10 &" where ((RCBRNO="& B7 &") And (RCYEAR="& Yeard&") And (RCTYPE="& R9&"))" 
		rs5.open( sql)
	else
		R10=1
	  	SQL = "insert into lpay.rcptno (RCBRNO,RCYEAR,RCTYPE,RCNO) VALUES ("& B7 &","& Yeard &","& R9 &","& R10 &")"
		rs5.open(Sql)
	end if
	
	rs4.Close
	
	R11=cdbl(session("Dfprm"))
	R12=session("DPInt")
	R23=cdbl(session("Dfprm"))+session("DPInt")
	R24="6"  'Type=Loan,claim
	B25="5"  'Type=Loan,claim 'LPMD1
	B26=2235 ' ACCOUNT CODE
	B27="LKR" ' Currency Code
	set rs3 = Server.CreateObject("ADODB.Recordset")
	rs3.ActiveConnection = dataSource 
		sql="select  * from lpay.lpaymas where lpptd="  &_
	B6  &_
	"AND LPBRN =" & chr(39)   &_
	B7  & chr(39)  &_
	"AND LPBTP="  & chr(39)  &_
	R24 & chr(39)&_
	"AND LPREC="    &_
	R10   
	rs3.open(sql)
	if  rs3.EOF  then
	BP="0"
	'SQL = "insert into  lpay.lpaymas(LPBRN,LPPTD,LPBTP,LPREC,LPPOL,LPPTP,LPMD1,LPAM1,LPCA1,LPCA2,LPSBR,LPEDT,LPTIM,LPIPA,LPACD,LPOPR,LPCUR) VALUES ("& B7 &","& B6 &",'"& R24 &"',"& R10 &","& B21 &",'"& R24 &"','"& B25 &"',"& R23 &","& R11 &","& R12 &","& B1A &","& B6 &",'"& B6A &"','"& B6B &"',"& B26 &","& B5 &",'"& B27 &"')"

		SQL = "insert into  lpay.lpaymas(LPBRN,LPPTD,LPBTP,LPREC,LPBOC,LPPOL,LPPTP,LPMD1,LPAM1,LPCA1,LPCA2,LPSBR,LPEDT,LPTIM,LPIPA,LPACD,LPOPR, LPSTA,LPCUR) VALUES ("& B7 &","& B6 &",'"& R24 &"',"& R10 &","& B20 &","& B21 &",'"& R24 &"','"& B25 &"',"& R23 &","& R11 &","& R12 &","& B1A &","& B6 &",'"& B6A &"','"& B6B &"',"& B26 &","& B5 &",'"& BP &"','"& B27 &"')"
       'SQL = "insert into  lpay.lpaymas(LPBRN,LPPTD,LPBTP,LPREC,LPBOC,LPPOL,LPPTP,LPMD1,LPAM1,LPEDT,LPTIM,LPACD,LPOPR) VALUES ("& B7 &","& B6 &",'"& R24 &"',"& R10 &","& B20 &","& B21 &",'"& B24 &"','"& B25 &"',"& B23 &","& B6 &",'"& B6A &"',"& B26 &","& B5 &")"
		'rs5.open(Sql)
		
	end if
 	rs3.Close

%>
  <table x:str border="0" cellpadding="0" cellspacing="0" width="750" style="border-collapse:
 collapse;width:434pt">
  <colgroup>
  <col width="272" style="width: 204pt">
  <col width="16" style="width: 12pt">
  <col width="92" style="width: 69pt">
  <col width="106" style="width: 80pt">
  <col width="17" style="width: 13pt">
  <col width="74" style="width: 56pt">
  </colgroup>
  <tr height="7" style="height:12.75pt"> 
  
<table width="620" border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:434pt" x:str dwcopytype="CopyTableRow">
  <colgroup>
  <col width="72" style="width: 40pt">
  <col width="16" style="width: 12pt">
  <col width="92" style="width: 69pt">
  <col width="106" style="width: 80pt">
  <col width="17" style="width: 13pt">
  <col width="74" style="width: 56pt">
  </colgroup>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td width="119" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="right"><font color="#002E5B"> </font> </div></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="right"><font color="#002E5B"> </font> </div></td>
    <td width="23" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="right"><font color="#002E5B"> </font> </div></td>
  </tr></tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="right"><font color="#002E5B"> </font> <font color="#002E5B"></font> 
      </div></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="right"><font color="#002E5B"> </font> <font color="#002E5B"></font> 
      </div></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="right"><font color="#002E5B"> </font> </div></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="center"><u>ADJUSTMENT VOUCHER</u></div></td>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="right"><font color="#002E5B"> </font> </div></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="left"><font color="#002E5B">Life Claims</font></div></td>
    <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <div align="right"><font color="#002E5B">Year of Account :200..... </font></div>
      <div align="right"></div>
      <div align="right"></div></td>
  </tr
 
  ><tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B">Colombo</font></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <font color="#002E5B">&nbsp; </font> <font color="#002E5B"><b></b></font></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <font color="#002E5B"><b> To Account Department.</b></font></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="20" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <font color="#002E5B"> Claim Number : 100/<%=claimno2%></font></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <font color="#002E5B">&nbsp; </font><font color="#002E5B"><font color="#002E5B"> 
      </font></font></td>
  </tr
      >
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <font color="#002E5B"><font color="#002E5B">Please adjust towards Policy 
      No. : <%=session("Polno")%> </font></font></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Response.Write(Pname)%></font> 
    </td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="6" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
      <font color="#002E5B">&nbsp; </font></td>

  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="3"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" ; style="border-style: solid; border-width: 1" > 
      <div align="left"><font color="#002E5B">DEBIT ACCOUNT</font></div></td>
	 <td height="17" colspan="3"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" ; style="border-style: solid; border-width: 1" > 
      <div align="left"><font color="#002E5B">|CREDIT ACCOUNT</font></div></td>
	      </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="2"  > <div align="left"><font color="#002E5B">Claims 
        : Maturity</font></div></td>
      <td height="17" colspan="-2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" ; style="border-style: solid; border-width: 1"> 
      <div align="right"><font color="#002E5B" ><%=Maturity%></font></div></td>
    <td height="17" colspan="2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0""> 
      <div align="left">| Default Premium </div></td>
    <td width="20" height="17"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" border-right-style:solid; border-right-width:1><div align="right"><font color="#002E5B"><%=session("Dfprm")%></font></div></td>
  </tr>


  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="2"  > <div align="left"><font color="#002E5B"> </font></div></td>
    <td height="17" colspan="-2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" border-right-style:solid; border-right-width:1"> 
      <div align="right"><font color="#002E5B"> </font></div></td>
	     
<% 
		
set rs1 = Server.CreateObject("ADODB.Recordset")
rs1.ActiveConnection = dataSource 

sql="select * from lphs.demand where pdPOL=" & chr(39) &_
session("Polno") & chr(39)  &_ 
"order by pddue" 
rs1.open(sql)

if not rs1.EOF  then
	 While not rs1.EOF  
  		for a= 1 to b 
  			if ((DemandArray(a,1)=trim(rs1.Fields("pddue"))) AND (DemandArray(a,2)="N")) then
	 
 				if (rs1.fields("pdcod") = "1" or  rs1.fields("pdcod") = "2"  or  rs1.fields("pdcod") = "3") then

					DemandYear= cint(Left(rs1.Fields ("pddue"),4))
					DemandMonth=  Right(rs1.Fields ("pddue"),2)
					Demanddue =Demandyear & " / " &Demandmonth
%>
 <td height="17" colspan="2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0"> 
      <%Response.Write(demanddue &"  " )%> </td>
	     
<%		
				'if ((DemandArray(a,1)=trim(rs1.Fields("pddue"))) AND (DemandArray(a,2)="N")) then
					B34=8'Demand set-off by maturity claim
					'Response.write(B34&" ***  ")
					SQL = "UPDATE lphs.demand set PDCOD="& B34 &", PDPDT="& B6 &" where  pdPOL=" &_ 
					Session("Polno") &_
					"AND   PDDUE=" &_
					DemandArray(a,1)
					rs5.open(Sql)
			'	end if	
					'SQL = "UPDATE lphs.demand set PDCOD="& B34 &", PDPDT="& B6 &" where  pdPOL=" &_ 
					'Session("Polno")
				'	rs5.open(Sql)
		
					B31="4" 'Demand
					B32=cdbl(rs1.Fields ("pddue"))
					B33=cdbl(rs1.Fields ("pdprm"))
					
					if cdbl(rs1.Fields ("pdpac")) => 34 then
						B30= 4
					elseif cdbl(rs1.Fields ("pdpac")) >= 31 and cdbl(rs1.Fields ("pdpac")) <= 33 then
						B30= 3
					elseif cdbl(rs1.Fields ("pdpac")) >= 21 and cdbl(rs1.Fields ("pdpac")) <= 26 then
						B30= 2
					elseif cdbl(rs1.Fields ("pdpac")) >= 1 and cdbl(rs1.Fields ("pdpac")) <= 20 then
						B30= 1
					end if

'*******************2006/10/03

					
					set rs2 = Server.CreateObject("ADODB.Recordset")
					rs2.ActiveConnection = dataSource 
					sql="select * from lpay.lpaycom" 
					'where LCPOL=" &_ 
					'Session("Polno")  &_
					'"AND LCDUE=" &_
					rs2.open(sql)
					rs2.close
					cno="1"&session("Clmno")
					
  					'SQL = "insert into  lpay.lpaymas(LPBRN,LPPTD,LPBTP,LPREC,LPBOC,LPPOL,LPPTP,LPMD1,LPAM1,LPCA1,LPCA2,LPSBR,LPEDT,LPTIM,LPIPA,LPACD,LPOPR,LPCUR) VALUES ("& B7 &","& B6 &",'"& B24 &"',"& B10 &","& B20 &","& B21 &",'"& B24 &"','"& B25 &"',"& B23 &","& B11 &","& B12 &","& B1A &","& B6 &",'"& B6A &"','"& B6B &"',"& B26 &","& B5 &",'"& B27 &"')"
   					SQL = "insert into  lpay.lpaycom(LCPBR,LCPDT,LCBTP,LCPOL,LCDUE,LCTBL,LCTRM,LCMOD,LCPRM,LCCDT,LCREC) VALUES ("& B7 &","& B6 &",'"& B31 &"',"& B21 &","& B32 &","& A1 &","& A2 &","& B30 &","& B33 &","& comdate1 &",'"& cno &"')"
   
					rs2.open(Sql)

					set rs3 = Server.CreateObject("ADODB.Recordset")
					rs3.ActiveConnection = dataSource 
					LType=0
					sql="select * from lclm.ledger" 
					rs3.open(sql)
					'rs3.close
 
    '				SQL = "insert into  lclm.ledger(LLPOL,LLDUE,LLTYP,LLPRM,LLMOD,LLDAT,LLPBR) VALUES ("& B21 &","& B32 &","& B34 &","& B33 &","& B30 &","& B6 &","& B7 &")"
    				SQL = "insert into  lclm.ledger(LLPOL,LLDUE,LLTYP,LLPRM,LLMOD,LLDAT,LLPBR,LLREC) VALUES ("& B21 &","& B32 &","& B34 &","& B33 &","& B30 &","& B6 &","& B7 &",'"& cno &"')"
 					rs5.open(Sql)
'**************************
     
				end if
										
				Exit for
			end if
			'Exit for
		next
 	rs1.moveNext
	wend
else
	'response.write("No Demands")			
End if
rs1.close 

If Conn.Errors.Count = 0 Then
	Conn.RollbackTrans
	Conn.Errors.Clear
	Conn.close
	Set Conn=Nothing
	%>	
	<script language="VBScript">
				MsgBox "Record is not added due to error ",vbinformation,"Life Claim Payment Final Memo System"
			</script>	
		
	<%	 else
	'Conn.RollbackTrans %>
	
			
		<%	Conn.CommitTrans
			'Conn.close
			'Set Conn=Nothing
			'Response.Redirect("lclaimno1.asp") %>
				<script language="VBScript">
				MsgBox "Record has been  added sucessfully ",vbinformation,"Life Claim Payment Final Memo System"
			</script>
<%End If   

%>
   
    <td height="17"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" border-right-style:solid; border-right-width:1><div align="right"><font color="#002E5B"> 
        </font></div></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="2"  > <div align="left"><font color="#002E5B"> </font></div></td>
    <td height="17" colspan="-2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" border-right-style:solid; border-right-width:1"> 
      <div align="right"><font color="#002E5B"> </font></div></td>
    <td height="17" colspan="2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0""> 
      <div align="left"> | Interest</div></td>
    <td height="17"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" border-right-style:solid; border-right-width:1><div align="right"><font color="#002E5B"><%=session("DPInt")%></font></div></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="2"  > <div align="left"><font color="#002E5B"> </font></div></td>
    <td height="17" colspan="-2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" border-right-style:solid; border-right-width:1"> 
      <div align="right"><font color="#002E5B"> </font></div></td>
    <td height="17" colspan="2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0""> 
      <div align="left">| </div></td>
    <td height="17"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" border-right-style:solid; border-right-width:1><div align="right"><font color="#002E5B"> 
        </font></div></td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="17" colspan="2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" ; style="border-style: solid; border-width: 1" > 
      <div align="left"><font color="#002E5B">Total</font></div></td>
    <td height="17" colspan="-2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" ; style="border-style: solid; border-width: 1"> 
      <div align="right"><font color="#002E5B" ><%=Maturity%></font></div></td>
    <td height="17" colspan="2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" ; style="border-style: solid; border-width: 1"> 
      <div align="left"><font color="#002E5B">| Total</font></div></td>
	     <td height="17" colspan="-2"  bordercolorlight="#C0C0C0" bordercolordark="#C0C0C0" ; style="border-style: solid; border-width: 1"> 
      <div align="right"><font color="#002E5B" ><%=Maturity%></font></div></td>
    </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td width="156" height="27" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td width="87" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <td height="27" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
  </tr>
  <tr height="7" style="height:12.75pt"> 
    <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
    </td>
    <td colspan="7" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">Prepared 
      By : 
      <%Response.Write(Epf&"  " &Date &"  " &Time)%>
    </td>
  </tr>
</table>
<% end if  %>
	<P CLASS="breakhere" > 
	
<% if  cdbl(session("Capital")) > 0   Then %>

<p align="center">
<font color="#1251BE">
  <table x:str border="0" cellpadding="0" cellspacing="0" width="719" style="border-collapse:
 collapse;width:434pt">
    <colgroup>
    <col width="272" style="width: 204pt">
    <col width="16" style="width: 12pt">
    <col width="92" style="width: 69pt">
    <col width="106" style="width: 80pt">
    <col width="17" style="width: 13pt">
    <col width="74" style="width: 56pt">
    </colgroup>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="center"><span style='mso-spacerun:yes'> 
          </span><span style='mso-spacerun:yes'> </span>LIFE POLICY LOANS</div></td>
      <td height="17" colspan="5" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right">REPAYMENTS-CLAIM 
          PAYMENT<span style='mso-spacerun:yes'> </span> </div></td>
    </tr>

<% 
    if len(B10) <2 Then
		num="000"&B10
	elseif len(B10) <3 Then
		num="00"&B10
	elseif len(B10) <4 Then
		num="0"&B10
	end if

%>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Receipt No</td>
      <td width="20" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td colspan="2" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Response.write(enterdate&"/"&dayd&num&"/  CL")%></font> 
        <div align="right"></div></td>
      <td width="20" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td width="100" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">Date:</td>
      <td width="101" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Date%></font></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">Policy 
        No </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">: 
      </td>
      <td width="119" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=session("Polno")%></font></td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><b><font size="2" face="Verdana" color="#CC3300"></font></b></font></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">Loan 
        No </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><strong><%=session("loanno")%></strong> 
        </font></td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><b></b></font></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Paid by</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td colspan="5" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Response.Write(Name1)%></font> 
        <font color="#002E5B"><b><font color="#002E5B"> <b></b> </font></b></font></td>
    </tr>
    <tr height="18" style="height: 13.5pt"> 
      <td height="18" style="height: 13.5pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Address &nbsp; </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        :</td>
      <td colspan="5" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Response.Write(Add1)%></font></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="5" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Response.Write(Add2)%></font></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="5" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Response.Write(Add3)%></font></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="5" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Response.Write(Add4)%></font></td>
    </tr>
    <tr height="17" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Capital </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B">&nbsp; 
        </font></td>
      <td colspan="2" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=session("Capital")%></font></div></td>
      <td colspan="2" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Interest </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B">&nbsp; 
        </font></td>
      <td colspan="2" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=session("Interest")%></font></div></td>
      <td colspan="2" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>

<%
	LoanAMt =  cdbl(session("Capital")) +  cdbl(session("Interest"))
  	LoanAmt = FormatNumber(loanAmt,2,0)
  	if netpay > 0 then
  		AmtRcv=LoanAmt
  	else
  		AmtRcv=Total
  	end if 
  	totvalword = trim(AmountToString(AmtRcv))%>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Total </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B">&nbsp; 
        </font></td>
      <td colspan="2" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"><%=LoanAmt%></font></div></td>
      <td colspan="2" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="17" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="17" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">Claim 
        Amount </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=session("Clmno")%></font></td>
      <td colspan="2" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        <div align="right"><font color="#002E5B"><%=LoanAmt%></font> </div></td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="17" style="height:12.75pt"> 
      <td height="7" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"> 
          </font></div></td>
    </tr>
    <tr height="17" style="height:12.75pt"> 
      <td height="7" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Amount Received</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td colspan="2" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        <div align="right"><font color="#002E5B"><%=AmtRcv%></font></div></td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"> 
          </font></div></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
	<% If netpay <=0 then %>
	<tr height="17" style="height:12.75pt"> 
      <td height="7" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Amount Write-Off</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td colspan="2" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        <div align="right"><font color="#002E5B"><%=WR%></font></div></td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="right"><font color="#002E5B"> 
          </font></div></td>
    </tr>
	<% end if%>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="7" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Rs. <font color="#002E5B"><b><font color="#002E5B"><%=TOTVALWORD%></font></b></font></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">...........................</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td colspan="2" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border-left: medium none; border-right: medium none; border-top: medium none; border-bottom: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px">Cashier 
      </td>
    <tr height="7" style="height:12.75pt"> 
      <td width="117" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="27" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="27" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td width="117" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="27" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="27" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="8" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Prepared By : 
        <%Response.Write(Epf&"  " &Date &"  " &Time)%>
      </td>
    </tr>
  </table>
  
	<%if netpay <= 0 then  %>
  	<P CLASS="breakhere" > 
  	<table x:str border="0" cellpadding="0" cellspacing="0" width="750" style="border-collapse:
 	collapse;width:434pt">
    <colgroup>
    <col width="272" style="width: 204pt">
    <col width="16" style="width: 12pt">
    <col width="92" style="width: 69pt">
    <col width="106" style="width: 80pt">
    <col width="17" style="width: 13pt">
    <col width="74" style="width: 56pt">
    </colgroup>
<tr height="7" style="height:12.75pt"> 
    <table width="746" border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:434pt" x:str dwcopytype="CopyTableRow">
      <colgroup>
      <col width="72" style="width: 40pt">
      <col width="16" style="width: 12pt">
      <col width="92" style="width: 69pt">
      <col width="106" style="width: 80pt">
      <col width="17" style="width: 13pt">
      <col width="74" style="width: 56pt">
      </colgroup>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="right"><font color="#002E5B"> </font> <font color="#002E5B"></font> 
          </div></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="right"><font color="#002E5B"> </font> <font color="#002E5B"></font> 
          </div></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="right"><font color="#002E5B"> </font> <font color="#002E5B"></font> 
          </div></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="right"><font color="#002E5B"> </font> <font color="#002E5B"></font> 
          </div></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="right"><font color="#002E5B"> </font>Our Ref :100<font color="#002E5B">/<%=claimno2%></font> 
          </div></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <font color="#002E5B">&nbsp; </font> <div align="right">Date:<font color="#002E5B"><%=DateP%></font></div></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Name1%></font> 
          <font color="#002E5B">&nbsp; </font> <font color="#002E5B"><b><font size="2" face="Verdana" color="#CC3300"></font></b></font></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <font color="#002E5B"> <%=Add1%> </font> <font color="#002E5B"><b></b></font></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <font color="#002E5B"><%=Add2%></font><font color="#002E5B"><b><font color="#002E5B"> 
          <b></b> </font></b></font></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <font color="#002E5B"> <%=Add3%> </font> <font color="#002E5B"><b></b></font></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <font color="#002E5B"> <%=Add4%> </font> <font color="#002E5B"><b></b></font></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <font color="#002E5B">&nbsp;</font><font color="#002E5B">&nbsp; </font> 
          <font color="#002E5B"><b></b></font></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <font color="#002E5B"> Dear Sir/Madam,&nbsp; </font> <font color="#002E5B"><b></b></font></td>
        <td width="309" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="58" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <font color="#002E5B">&nbsp; </font></td>
        <td width="114" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B">Policy 
          No :</font></td>
        <td width="242" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=session("Polno")%></font></td>
        <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="27" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
        </td>
        <td height="27" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="27" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      </tr>
      <tr height="17" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="9" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="justify">We 
            write to inform you that the above policy has matured on <font color="#002E5B"><%=session("MatDate")%>.</font></div></td>
      </tr>
	  <tr height="17" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="9" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="justify"> 
            We observe that the policy has not been maintained by you till the 
            maturity</div></td>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="justify">and therefore. Only the proportionately reduced 
            sum assured is due for payment.</div></td>
      </tr>
	  <tr height="17" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="9" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="justify">However, 
            the loan obtained by you and the interest thereon both of which remained</div></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="justify">unsettled as at the date of maturity have exceeded 
            the maturity proceeds and</div></td>
			</tr>
			
      <tr height="7" style="height:12.75pt"> 
        <td width="23" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="4" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="justify">as such, there is nothing payable on the maturity 
            of the above policy.</div></td>
			</tr>
    </table>
    <table width="750" border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:434pt" x:str dwcopytype="CopyTableRow">
      <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          . 
          <div align="right"></div></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="22" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="20" colspan="4" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="left">Particulars 
          </div></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="22" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="28" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
        </td>
        <td width="363" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="left">Amount of Loan</div></td>
        <td width="40" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">RS.</td>
        <td width="101" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=session("Capital")%></font></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="22" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="28" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
        </td>
        <td width="363" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="left">Interest on Loan</div></td>
        <td width="40" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">RS.</td>
        <td width="101" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=session("Interest")%></font></td>
    <%PMT=cdbl(session("Capital"))+cdbl(session("Interest"))%>
	 </tr>
	   <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="22" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="28" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
        </td>
        <td width="363" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="left">Total</div></td>
        <td width="40" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">RS.</td>
        <td width="101" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=PMT%></font></td>
      </tr>
	   <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          . 
          <div align="right"></div></td>
      </tr>
	  
	  <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="22" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="20" colspan="4" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><div align="left">Less</div></td>
      </tr>
      <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="22" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="28" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
        </td>
        <td width="363" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="left">Paid-Up-Value of the policy</div></td>
        <td width="40" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">RS.</td>
        <td width="101" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Paidup%></font></td>
      </tr>
       <%Bonus=cdbl(Vbonus)+cdbl(IBonus)%>
	  <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="22" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="28" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
        </td>
        <td width="363" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="left">Bonus From <font color="#002E5B"><%=Comdate%> to</font></div></td>
        <td width="40" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">RS.</td>
        <td width="101" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Bonus%></font></td>
  
	 </tr>
	  <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="22" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="28" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
        </td>
        <td width="363" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="left"> </div></td>
        <td width="40" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
        </td>
        <td width="101" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B">&nbsp; 
          </font></td>
      </tr>
       <%Bonus=cdbl(Vbonus)+cdbl(IBonus)%>
	  <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="22" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="28" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
        </td>
        <td width="363" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
          <div align="left">Balance</div></td>
        <td width="40" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">.</td>
        <td width="101" height="20" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B"><%=Response.write("Nil")%></font></td>
  
	 </tr>
  
      <tr height="7" style="height:12.75pt"> 
        <td width="25" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="22" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td width="28" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="20" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      </tr>
    </table>
  <table width="750" border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:434pt" x:str dwcopytype="CopyTableRow">
   
       <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><strong>Yours 
        Faithfully ,</strong></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><strong>SRI 
        LANKA INSURANCE CORPORATION LTD.</strong></td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">For 
        Life Manager</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">Life 
        Claim Section</td>
    <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">21, 
        Vauxhall Street</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">Colombo 
        02 </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
        <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">Hot 
          line 011-2357357, 011-235700</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td width="29" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td height="17" colspan="3" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
  </table></FORM>
  <table x:str border="0" cellpadding="0" cellspacing="0" width="750" style="border-collapse:
 collapse;width:434pt">
    <tr height="7" style="height:12.75pt"> 
      <td width="63" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
        </font> </td>
      <td width="43" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
        </font> </td>
      <td width="10" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td width="10" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#002E5B">&nbsp; 
        </font></td>
      <td width="71" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td width="142" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td width="142" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td width="63" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
        </font> </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="7" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
        </font> <font color="#000000">&nbsp; </font> <font color="#002E5B">&nbsp; 
        </font> </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="7" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
        </font> <font color="#000000">&nbsp; </font> <font color="#002E5B">&nbsp; 
        </font> </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="7" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
        </font> <font color="#000000">&nbsp; </font> <font color="#002E5B">&nbsp; 
        </font> </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="7" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
        </font> <font color="#000000">&nbsp; </font> <font color="#002E5B">&nbsp; 
        </font> </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="7" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
        </font> <font color="#000000">&nbsp; </font> <font color="#002E5B">&nbsp; 
        </font> </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" colspan="2" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">
      <td width="10" height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"><font color="#000000">&nbsp; 
        </font> </td>
      <td width="71" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
      <td width="142" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td width="142" style="color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td width="35" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp;</td>
      <td width="205" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px">&nbsp; 
      </td>
    </tr>
    <tr height="7" style="height:12.75pt"> 
      <td height="17" style="height: 12.75pt; color: windowtext; font-size: 11.0pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Arial; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        Date :</td>
      <td colspan="5" style="font-weight: 700; font-family: Arial, sans-serif; color: windowtext; font-size: 11.0pt; font-style: normal; text-decoration: none; text-align: general; vertical-align: bottom; white-space: nowrap; border: medium none; padding-left: 1px; padding-right: 1px; padding-top: 1px"> 
        <%Response.Write(Date &"  " &Time&"  " &IP)%>
      </td>
    </tr>
  </table>
<% 
 	end if
%>
  
</FORM>

<% 	
end if
end if
rs.Close
%>
</font> 
<p align="center">&nbsp;</p>
<p align="center">&nbsp;</p>
 </body>
</html>