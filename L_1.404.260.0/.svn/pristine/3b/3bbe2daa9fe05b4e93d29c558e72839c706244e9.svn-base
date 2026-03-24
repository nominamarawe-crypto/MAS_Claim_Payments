 ///JScript File

 function DateValidate(textBox)
    {
     var a=document.getElementById(textBox).value;  
     var yeara=a.substring(0,4);
     var montha=a.substring(4,6);
     var datea=a.substring(6,8);
    
 //     alert("  yeara "+a);
     
     
     if ((a.length != 8 ) && (a != ""))
               {
               alert( 'Date field should have 8 digits');
               return false;
               }
               else
               {
               return true;
               }
      if(parseFloat(montha)> 12)
      {
           alert(' Invalid month  ! \n'+' month Should be less than 13 \n but it can not be zero' ) ;  
           return false;      
      }
      else
      {
       return true;
      }
      if(parseFloat(yeara)<1900)
      {
           alert(" Invalid Year  '\n'" + " Year Should be greater than 1900"); 
           return false;     
       }
       else
       {
       return true;
       }
     if( parseFloat(montha)== 1 ||parseFloat(montha)== 3||parseFloat(montha)==5||parseFloat(montha)==7||parseFloat(montha)==8||parseFloat(montha)==10||parseFloat(montha)==12)
       {
            if(parseFloat(datea)> 31)
               {
                  alert('Invalid Date! \n' + ' This month has only 31 dates' ) 
                  return false;    
               }
             else
               {
                return true;
               }
       } 
      
           
      if(parseFloat(montha)== 4||parseFloat(montha)== 6||parseFloat(montha)==9||parseFloat(montha)==11)
       {
            if(parseFloat(datea)> 30)
               {
                  alert('Invalid Date! \n' + ' This month has only 30 dates' ) 
                  return false;    
              }
              else
              {
              return true;
              }
      }
     else
       {
             if(parseFloat(yeara)%4 ==0 )
               {
                   if(parseFloat(datea)> 29)
                      {
                          alert('Invalid Date! \n' + ' This month has only 29 dates' ) 
                          return false;    
                      }
                      else
                      {
                      return true;
                      }
               }
              else
               {
                 if(parseFloat(datea)> 28)
                     {
                       alert('Invalid Date! \n' + ' This month has only 28 dates' ) 
                       return false;    
                     }
                     else
                     {
                     return true;
                     }     
               }   
     }
     
   NoofDays()
     
  }
//======================================================

//==========================================Validate Exit Date ============================
function ValidateExitDate(textBox)
{//debugger
  DueDate=document.getElementById('txtnweffdt').value;  
  
  //validate whether taxt field contain numbers only
  var intno="0123456789";
    var checkOK = intno ;
    var checkStr = textBox;
    var allValid = true;    
    
    for (i = 0;  i < DueDate.length;  i++)
    {
        ch = DueDate.charAt(i);
        for (j = 0;  j < checkOK.length;j++)
        if (ch == checkOK.charAt(j))
        break;
        if (j == checkOK.length)
        {
        allValid = false;
        break;
        }       

    }
    if (!allValid)
    {	
    alertsay = "Please enter only these values \""
    alertsay = alertsay + checkOK + "\" in the Text field."
    alert(alertsay);
    return (false);
        } 
  //=======================================================
  
  today=new Date(); // Initialize Date in raw form
  day = today.getDay(); 
  month=today.getMonth()+1; 
  year=today.getFullYear();
  date=year+""+month;
  year=DueDate.substring(0,4);
  month=DueDate.substring(4,6);
  if ((DueDate.length != 6 ) && (DueDate != ""))
  {
  alert('This Field should have 6 digits!!');
  }
  if((parseFloat(month)>12) ||(parseFloat(month)==0))
  {
  alert('Invalid Month . Month Cannot be greater than 12 or Equal to Zero!!');
  }
 if(parseFloat(year)<1962)
 {
  alert('Invalid Year . Year Cannot be less than 1962!!');
 }
 else if(parseFloat(DueDate)>parseFloat(date))
 {
 alert('You Cannot enter YearMonth more than  '+date);
 } 
 
}
//=========================================================================================


 function NoofDays()
{
    var Diff;
     var sdate=document.getElementById('textBox1').value;  
   // if(sdate!=null)
     {
     var yeara=sdate.substring(0,4);
     var montha=sdate.substring(4,6);
     var datea=sdate.substring(6,8);
     }
     
     var edate=document.getElementById('textBox2').value;   
    //  if(edate!=null)
     {
     var yearE=edate.substring(0,4);
     var monthE=edate.substring(4,6);
     var dateE=edate.substring(6,8);
     }  
   
//     if(sdate!=null && edate!=null)
//     {
        var one_day=1000*60*60*24;
        
       
        var date1=new Date(yeara,montha,datea);  
        var date2=new Date(yearE,monthE,dateE);      
        
        //Calculate difference between the two dates, and convert to days
               
        Diff=Math.ceil((date1.getTime()- date2.getTime())/(one_day));     
       
       //  setLabelText("Label3",Diff);      

    //  alert(Diff);
      
      if(parseFloat(Diff)>90 )
       { 
          setLabelText("Label3","NO");    
       }

       else if(parseFloat(Diff)<91 && parseFloat(Diff)>-1)
       {
      setLabelText("Label3","YES");    
       } 
       
       else if(parseFloat(Diff)<0)
       {
        alert(" Please Enter Correct Date ");
        setLabelText("Label3"," "); 
        return;
       }
       else
       {
         setLabelText("lblGrcPrd"," "); 
         setLabelText("Label3"," ");          
       } 
}

function setLabelText(ID, Text)
  {
    document.getElementById(ID).innerHTML = Text;
  }
  
  
  
  /////////////////////////////To Validate THe Name of the Nominee////////////
  
   function NameValidate(textBox)
    {
     var Name=document.getElementById(textBox).value;  
     var arr=Name.split('.');
  
     if (arr[0]=="")
      {
          alert( 'Name should start from a letter');
          return false;
       }
       else
       {
       return true;
       }
       for(var i=0;i<arr.length;i++ )
       {
        if(arr[i]=="" && arr[i+1]=="")
           {
              alert('You Cannot put .. in a name ');
              return false;
            }
            else
            {
            return true;
            }
       }           
   }
   
   ////////////////////// Check the Validation of NIC /////////////////////////////
   function IsValidNIC(textBox)
   {
    var reNIC = /(\d{9}[\sX|x|V|v])/;
        return reNIC.test(textBox);
    
   }   
   
   function ValidateNIC()
   {
   
      var NIC = document.getElementById("txtNIC");
        if (IsValidNIC(NIC.value))
         {
         return true;
         }
         
          else 
          {
            alert("Invalid NIC Number !");
            return false;
          } 
   

   }
   
   /////////////////////// validate the Percentage//////////////////
   
   
    function IsValidPer(textBox)
   {
    var rePer = /(\d)/;
        return rePer.test(textBox);
    
   }   
     
   function validatePercentage()
   {
    var Percent=document.getElementById('txtPercent');  
     
     if (Percent=="")
      {
          alert( 'Percentage cannot be Null  ');
          return false;
       }
     
      if (IsValidPer(Percent.value))
         {
         return true;
         }
          else 
          {
            alert("Invalid Percentage  !");
            return false;
          } 
          
   }
   
   function validateAddress(textBox)
   {
   var Address=document.getElementById(textBox).value;  
     
  
     if (Address=="")
      {
          alert( ' Please enter the Address  ');
          return false;
       }
   }
   
   
   function CheckValidationForAll()
   {
  
   var a=DateValidate('txtDOB')   
   var b=NameValidate('txtName')
   
  
   var nic=document.getElementById("txtNIC").value

   if(nic !="")
   {
 
    var c=ValidateNIC()
   }  
   if(a==false  )
   {
   return false
   }  
   
    if(b==false)
    {
    return false
    }

  }
  
  function Validatemovemntyrmn(textBox)
{//debugger
  DueDate=document.getElementById('txtmvmnyr').value;  
  
    var intno="0123456789";
    var checkOK = intno ;
    var checkStr = textBox;
    var allValid = true;    
    
    for (i = 0;  i < DueDate.length;  i++)
    {
        ch = DueDate.charAt(i);
        for (j = 0;  j < checkOK.length;j++)
        if (ch == checkOK.charAt(j))
        break;
        if (j == checkOK.length)
        {
        allValid = false;
        break;
        }       

    }
    if (!allValid)
    {	
    alertsay = "Please enter only these values \""
    alertsay = alertsay + checkOK + "\" in the Text field."
    alert(alertsay);
    return (false);
        }
  
  
  today=new Date(); // Initialize Date in raw form
  day = today.getDay(); 
  month=today.getMonth()+1; 
  year=today.getFullYear();
  date=year+""+month;
  year=DueDate.substring(0,4);
  month=DueDate.substring(4,6);
  if ((DueDate.length != 6 ) && (DueDate != ""))
  {
  alert('This Field should have 6 digits!!');
  }
  if((parseFloat(month)>12) ||(parseFloat(month)==0))
  {
  alert('Invalid Month . Month Cannot be greater than 12 or Equal to Zero!!');
  }
 if(parseFloat(year)<1962)
 {
  alert('Invalid Year . Year Cannot be less than 1962!!');
 }
 else if(parseFloat(DueDate)>parseFloat(date))
 {
 alert('You Cannot enter YearMonth more than  '+date);
 } 
 
}

//=============================================================================
function validateNexteffdate(textBox)
{
DueDate=document.getElementById('txtnexteffdt').value;  
var intno="0123456789";
    var checkOK = intno ;
    var checkStr = textBox;
    var allValid = true;    
    
    for (i = 0;  i < DueDate.length;  i++)
    {
        ch = DueDate.charAt(i);
        for (j = 0;  j < checkOK.length;j++)
        if (ch == checkOK.charAt(j))
        break;
        if (j == checkOK.length)
        {
        allValid = false;
        break;
        }       

    }
    if (!allValid)
    {	
    alertsay = "Please enter only these values \""
    alertsay = alertsay + checkOK + "\" in the Text field."
    alert(alertsay);
    return (false);
        }
  
   
  year=DueDate.substring(0,4);
  month=DueDate.substring(4,6);
  if ((DueDate.length != 6 ) && (DueDate != ""))
  {
  alert('This Field should have 6 digits!!');
  }
  if((parseFloat(month)>12) ||(parseFloat(month)==0))
  {
  alert('Invalid Month . Month Cannot be greater than 12 or Equal to Zero!!');
  }
 if(parseFloat(year)<1962)
 {
  alert('Invalid Year . Year Cannot be less than 1962!!');
 } 
}