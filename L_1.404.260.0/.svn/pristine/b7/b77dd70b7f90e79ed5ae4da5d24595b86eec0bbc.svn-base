// JScript File

function checkNumeric(objName,period)
{

	var numberfield = objName;
	if (chkNumeric(objName,period) == false)
	{
		numberfield.select();
		numberfield.focus();
		return false;
	}
	else
	{
		return true;
	}
}

function chkNumeric(objName,period)
{
    // only allow 0-9 be entered, plus any values passed
    // (can be in any order, and don't have to be comma, period, or hyphen)
    // if all numbers allow commas, periods, hyphens or whatever,
    // just hard code it here and take out the passed parameters
    var checkOK = "0123456789" + period ;
    var checkStr = objName;
    var allValid = true;
    var decPoints = 0;
    var allNum = "";

    for (i = 0;  i < checkStr.value.length;  i++)
    {
        ch = checkStr.value.charAt(i);
        for (j = 0;  j < checkOK.length;j++)
        if (ch == checkOK.charAt(j))
        break;
        if (j == checkOK.length)
        {
        allValid = false;
        break;
        }
        if (ch != ",")
        allNum += ch;

    }
    if (!allValid)
    {	
    alertsay = "Please enter only these values \""
    alertsay = alertsay + checkOK + "\" in the Text field."
    alert(alertsay);
    checkStr.select();
		checkStr.focus();
    return (false);
    }

//// set the minimum and maximum
//    var chkVal = allNum;
//    var prsVal = parseInt(allNum);
//    if (chkVal != "" && !(prsVal >= minval && prsVal <= maxval))
//    {
//    alertsay = "Please enter a value greater than or "
//    alertsay = alertsay + "equal to \"" + minval + "\" and less than or "
//    alertsay = alertsay + "equal to \"" + maxval + "\" in the  field."
//    alert(alertsay);
//    return (false);
//    }
}

function checkintNum(objName)
{
//debugger
	var Stringfield = objName;
	if (validateInt(objName) == false)
	{
		Stringfield.select();
		Stringfield.focus();
		return false;
	}
	else
	{
		return true;
	}
}

function validateInt(objName)
{
//debugger
    var intno="0123456789";
    var checkOK = intno ;
    var checkStr = objName;
    var allValid = true;    
    
    for (i = 0;  i < checkStr.value.length;  i++)
    {
        ch = checkStr.value.charAt(i);
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
      
}




