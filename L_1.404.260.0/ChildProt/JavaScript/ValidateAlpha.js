// JScript File

var lwr = 'abcdefghijklmnopqrstuvwxyz ';
var upr = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ ';

function checkNumeric(objName,period)
{
//debugger
	var Stringfield = objName;
	if (chkString(objName,period) == false)
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

function chkString(objName,period)
{
    // only allow A-Z be entered, plus any values passed
    // (can be in any order, and don't have to be comma, period, or hyphen)
    // if all numbers allow commas, periods, hyphens or whatever,
    // just hard code it here and take out the passed parameters
    var checkOK = upr +lwr+ period ;
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
