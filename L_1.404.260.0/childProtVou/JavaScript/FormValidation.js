
function IsDate(sText)
{
   var ValidChars = "0123456789/"; //"0123456789";
   var IsNumber=true;
   var Char;

  for (i = 0; i < sText.length && IsNumber == true; i++) 
      { 
      Char = sText.charAt(i); 
      if (ValidChars.indexOf(Char) == -1) 
         {IsNumber = false;}
      }
   return IsNumber;
}

function Isid(sText)
{
   var ValidChars = "0123456789VXvx"; //"0123456789";
   var IsNumber=true;
   var Char;

  for (i = 0; i < sText.length && IsNumber == true; i++) 
      { 
      Char = sText.charAt(i); 
      if (ValidChars.indexOf(Char) == -1) 
         {IsNumber = false;}
      }
   return IsNumber;
}

function FMaxlength(iLength,iMax)
{ 
	if (iLength==iMax)
			{return true;}
	else
			{return false;}
}



function IsEmptySelect(aComboField)
	 	{
   			
			
			if ((aComboField=="--Select--") || (aComboField==""))
   			{return true;}
   			else
   			{return false;}
		}

function IsString(sText)
{
   var ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ() "; 
   var IsNumber=true;
   var Char;

  for (i = 0; i < sText.length && IsNumber == true; i++) 
      { 
      Char = sText.charAt(i); 
      if (ValidChars.indexOf(Char) == -1) 
         {IsNumber = false;}
      }
   return IsNumber;
}

function IsChar(sText)
{
   var ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 "; 
   var IsNumber=true;
   var Char;

  for (i = 0; i < sText.length && IsNumber == true; i++) 
      { 
      Char = sText.charAt(i); 
      if (ValidChars.indexOf(Char) == -1) 
         {IsNumber = false;}
      }
   return IsNumber;
}



function IsInitials(sText)
{
   var ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; 
   var IsNumber=true;
   var Char;

  for (i = 0; i < sText.length && IsNumber == true; i++) 
      { 
      Char = sText.charAt(i); 
      if (ValidChars.indexOf(Char) == -1) 
         {IsNumber = false;}
      }
   return IsNumber;
}


function IsNumeric(sText)
{
   var ValidChars = "0123456789"; //"0123456789";
   var IsNumber=true;
   var Char;

  for (i = 0; i < sText.length && IsNumber == true; i++) 
      { 
      Char = sText.charAt(i); 
      if (ValidChars.indexOf(Char) == -1) 
         {IsNumber = false;}
      }
   return IsNumber;
}

function IsNumeric02(sText)
{
   var ValidChars = "0123456789."; //"0123456789";
   var IsNumber=true;
   var Char;

  for (i = 0; i < sText.length && IsNumber == true; i++) 
      { 
      Char = sText.charAt(i); 
      if (ValidChars.indexOf(Char) == -1) 
         {IsNumber = false;}
      }
   return IsNumber;
}

function IsEmptyField(aTextField)
	 	{
   			if ((aTextField.length==0) || (aTextField==null))
   			{return true;}
   			else
   			{return false;}
   		}

function IsEmail(sText)
{
if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(sText))
{
return (true)
}
return (false)
}



function getDtsOfMnth(mm,yyyy)
{
var dates
if (( mm == 1 ) ||( mm == 3 ) ||( mm == 5 ) ||( mm == 7 ) ||( mm == 8 ) ||( mm == 10 ) || ( mm == 12 ) )
       dates = 31

 else if (( mm == 4 ) ||( mm == 6 ) ||( mm == 9 ) ||( mm == 11 ) )
       dates = 30

else if ( (mm == 2) && ((yyyy % 4) != 0))
       dates = 28

 else if ( (mm == 2) && ((yyyy % 4) == 0))
       dates = 29
       else
       dates = -1
       return dates;
}


function DateValidation(strDate)
{
 	
		/*if(IsEmptyField(strDate)) 
              	{
              		alert( 'Please Enter Date');
                	return false;
              	}*/
              
              
              if (!IsDate(strDate))
               {
                alert( 'Please Enter Correct Format');
                return false;
               }


               if ((strDate.length != 10 ) && (strDate != ""))
               {
               alert( 'Date field should have 10 digits');
               return false;
               }
               
		else
               {
		var arr = strDate.split('/'); 
   		
     		var iDate = parseFloat(arr[0]);
     		var iMonth= parseFloat(arr[1]);
    		var iYear = parseFloat(arr[2]);           
                       
                      
						
                var iNOfDts = getDtsOfMnth(iMonth,iYear)
                       if(iYear < 1900)
                       {
                               alert( 'Invalid Date! \n' + ' Year Should be greater than 1900'  );
                               return false;
                       }
                       else if((iMonth > 12) || (iMonth == 0))
                       {
                               alert( 'Invalid Date! \n' + ' month Should be less than 13 \n but it can not be zero' );
                               return false;
                       }
                       else if((iNOfDts  < iDate) || (iDate == 0))
                       {
                               alert( 'Invalid Date! \n' + ' This month has only ' + iNOfDts +' dates' );
                               return false;
                       }
                       else
                       return true;

               }



      
}
 
 

