// JScript File

   function IsValidNIC(textBox)
   {
    var reNIC = /(\d{9}[\sX|x|V|v])/;
        return reNIC.test(textBox);
    
   } 

