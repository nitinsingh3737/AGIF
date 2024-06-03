
function SetSuffixLetter(obj) {


    var arr1 = [], arr2 = [];
    var ArmyNumber = $(obj).val();
    var fixed = "98765432";
    arr1 = ArmyNumber.split('');
    arr2 = fixed.split('');
    var len = arr2.length - arr1.length;
    if (len == 1) {
        ArmyNumber = "0" + ArmyNumber;
    }
    if (len == 2) {
        ArmyNumber = "00" + ArmyNumber;
    }
    if (len == 3) {
        ArmyNumber = "000" + ArmyNumber;
    }
    if (len == 4) {
        ArmyNumber = "0000" + ArmyNumber;
    }
    if (len == 5) {
        ArmyNumber = "00000" + ArmyNumber;
    }
    if (len == 6) {
        ArmyNumber = "000000" + ArmyNumber;
    }
    if (len == 7) {
        ArmyNumber = "0000000" + ArmyNumber;
    }

    var total = 0;
    arr1 = ArmyNumber.split('');
    for (var i = 0; i < arr1.length; i++) {
        var val1 = arr1[i];
        var val2 = arr2[i];
        total += parseInt(val1) * parseInt(val2);
    }
    var rem = total % 11;
    var Sletter = '';
    switch (rem.toString()) {
        case '0':
            Sletter = 'A'
            break;
        case '1':
            Sletter = 'F'
            break;
        case '2':
            Sletter = 'H'
            break;
        case '3':
            Sletter = 'K'
            break;
        case '4':
            Sletter = 'L'
            break;
        case '5':
            Sletter = 'M'
            break;
        case '6':
            Sletter = 'N'
            break;
        case '7':
            Sletter = 'P'
            break;
        case '8':
            Sletter = 'W'
            break;
        case '9':
            Sletter = 'X'
            break;
        case '10':
            Sletter = 'Y'
            break;

    }
    $('#SuffixLetter').val(Sletter.toString());

    var Prefix = document.getElementById("dropdownSelect").value;

    $('#dropdownSelect1').val(Prefix);
    $('#oldIC').val(ArmyNumber);
    var Suffix = document.getElementById("SuffixLetter").value;
    $('#oldsufixnum').val(Suffix);

}



$("#DataFill").click(function () {
    // Generate a random number
    function getRandomNumber(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    // Generate unique data
    var randomNum = getRandomNumber(1000, 9999); // Adjust the range as needed

    $('#Name').val("AK PATIL" + randomNum);
    $('#dropdownSelect').val("IC");
    $('.ic').val("4567" + randomNum);
    $('#SuffixLetter').val("M");

    $('#Rank').val("19");
    $('#Regt_Corps').val("ASSAM");
    $('#Unit').val("ASDC");
    $('#Date_Of_Birth').val("01/04/2000");
    $('#Enrollment_Date').val("01/04/2018");
    $('#Year_Of_Service').val("6");
    $('#Adhar_No').val("16679750" + randomNum);
    $('#Pan_No').val("TYSSS9" + randomNum);
    $('#Mobile_No').val("852726" + randomNum);
    $('#Email_Id').val("ajaysingh" + randomNum + "@gmail.com");

    $('#Purpose_of_withdrawal').val("Marriage of ward");
    $('#House_Building_Advance_Loan').val("YES");
    $('#Conveyance_Advance_Loan').val("YES");
    $('#Computer_Advance_Loan').val("YES");
    $('#House_Building_Date_of_Loan_taken').val("01/04/2024");
    $('#Conveyance_Date_of_Loan_taken').val("01/04/2024");
    $('#Computer_Date_of_Loan_taken').val("01/04/2024");
    $('#House_Building_Duration_of_Loan').val("6");
    $('#Conveyance_Duration_of_Loan').val("6");
    $('#Computer_Duration_of_Loan').val("6");
    $('#House_Building_Amount_Taken').val("63443");
    $('#Conveyance_Amount_Taken').val("64434");
    $('#Computer_Amount_Taken').val("63345");
    $('#Amount_of_withdrawal').val("63343");
    $('#Name_of_Child').val("TEST3CHILD");
    $('#date_of_Birth_Child').val("01/04/2000");
    $('#DO_Part_II_No').val("344345");
    $('#DO_Part_II_Date').val("01/04/2000");
    $('#Presently_studying').val("XYZ");
    $('#Course').val("XYZ");
    $('#College_Name').val("ABC");
    $('#Total_Expenditure_Amount').val("36645");
    $('#Age').val("26");
    $('#Date_of_Mairrage').val("01/04/2010");
    $('#Address').val("NEW DELHI");
    $('#Name_of_Property_holder').val("AMIT");
    $('#Estimated_Cost_of_Expenditure').val("56896");
    $('#Date_of_Retirement').val("01/04/2024");
    $('#No_of_withdrawal').val("First");
    $('#Reason_for_first_withdrawal').val("ABC");
    $('#Amount_Paid').val("52698");
    $('#Date_of_withdrawal').val("01/04/2050");
    $('#Name_of_Bank').val("SBI");
    $('#Branch_Name').val("Banthra lucknow");
    $('#Account_No').val("7778888" + randomNum + "N");
    $('#IFSC_Code').val("FNSE4545");
    $('#Bank_Address').val("New DELHI");

    $('#Contact_No_of_Bank').val("552896" + randomNum);
});
