$(document).ready(function () {

    $("#DataFill").click(function () {

        /* Personal Details */
       
        $('#Loanee_Name').val("AK PATIL");

        $('#dropdownSelect').val("IC");
        $('#IC').val("45678833");
        $('#SuffixLetter').val("M");

        $('#dropdownSelect1').val("IC");
        $('#oldIC').val("45678833");
        $('#oldsufixnum').val("M");

        $('#Rank').val("SUB");
        $('#Regt_Corps').val("ASSAM");
        $('#Unit').val("ASDC");
        $('#Next_Fmn_Hq').val("DGIS");
        $('#Unit_Pin').val("567654");

        $('#Unit_Address').val("c/o 56 APO");
        $('#CDA_PAO').val("TEST1");
        $('#Date_Of_Birth').val("01/04/2000");
        $('#Enrollment_Date').val("01/04/2018");
        $('#Extension_of_Service_in_Present_Rank').val("Yes");
        

        $('#ExtentionfileUpload').val("abc.pdf");
        $('#Promotion_Date').val("01/04/2024");
        $('#Retirement_Date').val("01/04/2050");
        
        $('#Year_Of_Service').val("6");
        $('#Residual_Service').val("26");
        $('#ApplicationType').val("CAR");
        $('#CarLoanType').val("New Car");
        $('#AadharNo').val("166797505883");
        $('#PANNo').val("TYSSS9899B");



       /* Salary Details */
        $('#Salary_Slip_Month_Year').val("April 2024");
        $('#CDA_Account_No').val("77/788/889999N");
        $('#Basic_Salary').val("78654");

        $('#PLI').val("31");
        $('#Rank_Grade_Pay').val("33");
        $('#Rev_IT').val("33");
        $('#MSP').val("33");
        $('#AGIF').val("33");
        $('#NPA_X_Pay').val("33");
        $('#Income_Tax_Monthly').val("33");
        $('#Tech_Pay').val("33");
        $('#DSOP_AFPP').val("33");

        $('#DA').val("33");
        $('#MISC').val("33");
        $('#TPTL_Pay').val("33");
        $('#MISC_Pay').val("33");
       
        /*Dealers Details*/

        $('#Dealer_Name').val("AutoNation");

        $('#Vehicle_Name').val("rx433t");
        $('#Veh_Type').val("Electric");
        $('#Vehicle_Make').val("abcCompany");

        $('#Total_Cost').val("675465");

        /*Loan Details*/

        $('#Amt_Eligible_for_loan').val("1000000");
        $('#EMI_Eligible_for_loan').val("60");
        $('#Loan_amount_admissible').val("15000000");

        $('#Amount_Applied_For_Loan').val("900000");
        $('#No_Of_EMI_Applied').val('30');

     /*   Address Details*/
        

        $('#Pers_Address_Line1').val("NEW DELHI");
        $('#Permanent_Addr_Line2').val("NEW DELHI");
        $('#Pers_Address_Line3').val("NEW DELHI");
        $('#Pers_Address_Line4').val("NEW DELHI");
        $('#Pin_Code').val("110067");

        /*Payee Account Details*/
        $('#Payee_Account_No').val("6786968576896785");
        $('#IFSC_Code').val("FCSA4995387");
        $('#Mobile_No').val("8527262163");
        $('#E_Mail_Id').val("ajaysingh945464@gmail.com");
        $('#Previous_Loan_Purpose').val("HBA");
        $('#Amount').val("567654");
        $('#EMI').val("45");
        $('#Previous_Loan_Is_Paid').val("Yes")

    });

    $('#Rank').change(function () {
      
        $('#Date_Of_Birth').val('');
        $('#Promotion_Date').val('');
        $('#Enrollment_Date').val('');
        $('#Retirement_Date').val('');
        $('#Residual_Service').val('');
        $('#Year_Of_Service').val('');
    });

    //$('#dropdownSelect').change(function () {
    //    var prefix = $(this).val(); 
    //    alert(prefix);
    //    if (prefix === "JC" || prefix === "OR") {
    //        // Disable the input field if prefix is "JC" or "OR"
    //        $('#CDA_Account_No').prop('disabled', true);
    //    } else {
    //        // Enable the input field for other prefixes
        
    //        $('#CDA_Account_No').prop('disabled', false);
    //    }
    //});


    $('#dropdownSelect').change(function () {
        var prefix = $(this).val(); 
        if (prefix === "JC" || prefix === "OR") {
            $('#CDA_Account_No').val("random");
            $('#CDA_Account_No').prop('readonly',true); 
        } else {
            $('#CDA_Account_No').prop('readonly', false);
        }
    });


   
    $('#Promotion_Date').datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: 'dd/mm/yy'
    });
    var data = $('#prefixnum').val();
  

    //var selectedValue = $("#extensionSelect").val();
    $('#Veh_Type').change(function () {
       
        var prefix = $('#dropdownSelect').val();
        
        var Admissiable_Amount = 0;
        var ApplicationType = $('#ApplicationType').val();
        var CarLoanType = $('#CarLoanType').val();
        if (prefix == "JC" || prefix == "OR") {
            if (ApplicationType == "Car") {

                if (CarLoanType === 5) {
                    /* NEW CAR*/
                    Admissiable_Amount = 10;
                }
                else if (CarLoanType === 6) {
                    /* OLD CAR*/
                    Admissiable_Amount = 5;
                }
                else if (CarLoanType == 7) {
                    /*EV*/
                    Admissiable_Amount = 15;
                }

            }
            else {
                Admissiable_Amount = 2;

            }

        }
        else {
            if (ApplicationType == "Car") {

                if (CarLoanType === 5) {
                    /* NEW CAR*/
                    Admissiable_Amount = 20;
                }
                else if (CarLoanType === 6) {
                    /* OLD CAR*/
                    Admissiable_Amount = 10;
                }
                else if (CarLoanType == 7) {
                    /*EV*/
                    Admissiable_Amount = 25;
                }

            }
            else {
                Admissiable_Amount = 10;

            }
        }

        $('#Loan_amount_admissible').val(Admissiable_Amount);

    });
});
var Rank;

//Tab next back 
var currentTab = 0; // Current tab is set to be the first tab (0)
showTab(currentTab); // Display the crurrent tab

function showTab(n) {

    // This function will display the specified tab of the form...
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    //... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
        document.getElementById("create").style.display = "none";
    } else {
        document.getElementById("prevBtn").style.display = "inline";
        document.getElementById("create").style.display = "none";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").style.display = "none";
        document.getElementById("create").style.display = "inline";
    } else {
        document.getElementById("nextBtn").innerHTML = "Next";
        document.getElementById("nextBtn").style.display = "inline";
        document.getElementById("create").style.display = "none";
    }
    //... and run a function that will display the correct step indicator:
    fixStepIndicator(n)
}

function nextPrev(n) {
   
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:

    if (n == 1 && !validateForm()) return false;
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form...
    if (currentTab >= x.length) {
        // ... the form gets submitted:
        document.getElementById("regForm").submit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}



function fixStepIndicator(n) {
    
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    //... and adds the "active" class on the current step:
    x[n].className += " active";
}

/*Set Automatically Suffix*/


/*Set Automatically Suffix*/
function SetOldSuffixLetter(obj) {


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
    $('#oldsufixnum').val(Sletter.toString());

    var Prefix = document.getElementById("dropdownSelect1").value;

    $('#dropdownSelect1').val(Prefix);
    $('#oldIC').val(ArmyNumber);
    var Suffix = document.getElementById("SuffixLetter").value;


}

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


/*date handler */
function diff_years(dt2, dt1) {
     
    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60 * 60 * 24);
    return Math.abs(Math.round(diff / 365.25));

}

//function diff_years(dt2, dt1) {
//    var diff = (dt1.getTime() - dt2.getTime()) / 1000;
//    diff /= (60 * 60 * 24);
//    var years = Math.round(diff / 365.25);
//    return years >= 0 ? "+" + years : years;
//}



function calallser1(e) {
    var ser;
    var ranks = $('#Rank').val(); // Assuming rank is a string repr+esenting an integer
    var rank = parseInt(ranks);

    var Regiment = $('#Regt_Corps').val().toUpperCase();
   
    
    if (!rank) {
        alert("Rank value is empty. Please enter a valid rank.");
        $('#Date_Of_Birth').val('');
        return;
    }
    if (Regiment == '') {
        alert("Regt/Corps value is empty. Please enter a valid Regt/Corps.");
        $('#Date_Of_Birth').val('');
        return;
    }
   
    var dateOfBirthString = e;
    
     
    var dateParts = dateOfBirthString.split('/');

    // Ensure that the dateParts array has three elements
    if (dateParts.length === 3) {
        var day  = parseInt(dateParts[0], 10);
        var month = parseInt(dateParts[1], 10) - 1; // Months are zero-based (0-11)
        var year = parseInt(dateParts[2], 10);

        // Check if the parsed values are valid
        if (!isNaN(year) && !isNaN(month) && !isNaN(day)) {

            var BirthDate = new Date(year + 0, month, day);
          
            var enrollmentDate = new Date(year + 18, month, day); // Enrollment after 18 years
            /*var retirementAge = 65;*/ // Retirement age is assumed to be 65

            if (rank < 10) {
                switch (Regiment) {
                    case "INF":
                    case "ASSAM":
                    case "PBG":
                    case "GUARDS": 
                    case "PARA":
                    case "PUNJAB":
                    case "MADRAS":
                    case "GREN":
                    case "MARATHA LI":
                    case "RAJ RIF":
                    case "RAJPUT":
                    case "JAT":
                    case "SIKH":
                    case "SIKH LI":
                    case "DOGRA":

                    case "GARH RIF":
                    case "KUMAON":
                    case "BIHAR":
                    case "MAHAR":
                    case "JAK RIF":
                    case "LS":
                    case "NAGA":
                    case "JAK LI":
                    case "1GR":
                    case "3GR":
                    case "4GR":
                    case "5GR":
                    case "8GR":
                    case "9GR":
                    case "11GR":


                    case "MECH INF":
                    case "39 GTC":
                    case "GS":
                    case "JAG":
                    case "MF":
                    case "14GR":
                    case "58GTC":
                    
                    
                        switch (rank) {
                            case 1:
                                ser = 60;
                                break;
                            case 2:
                                ser = 60;
                                break;
                            case 3:
                                ser = 58;
                                break;
                            case 4:
                                ser = 56;
                                break;
                            case 5:
                                ser = 54;
                                break;
                            case 6:
                                ser = 54;
                                break;
                            //case 7:
                            //    ser = 54;
                            //    break;
                            case 8:
                                ser = 52;
                                break;

                            default:
                                break;
                        }
                        break;
                    case "ASC":
                    case "AOC":
                    case "EME":
                    case "PIONEER CORPS":
                        switch (rank) {
                            case 1:
                                ser = 60;
                                break;
                            case 2:
                                ser = 60;
                                break;
                            case 3:
                                ser = 58;
                                break;
                            case 4:
                                ser = 56;
                                break;
                            case 5:
                                ser = 54;
                                break;
                            case 6:
                                ser = 54;
                                break;
                            //case 7:
                            //    ser = 54;
                            //    break;
                            case 8:
                                ser = 54;
                                break;
                           
                            default:
                                break;
                        }
                        break;
                    case "AMC":
                    case "ADC":
                    case "RVC":
                    case "MNS":
                        switch (rank) {
                            case 1:
                                ser = 61;
                                break;
                            case 2:
                                ser = 61;
                                break;
                            case 3:
                                ser = 60;
                                break;
                            case 4:
                                ser = 59;
                                break;
                            case 5:
                                ser = 58;
                                break;
                            case 6:
                                ser = 56;
                                break;
                            
                            default:
                                break;
                        }
                        break;
                    case "AMC(NT)OFFRS":
                        switch (rank) {
                            case 1:
                                ser = 60;
                                break;
                            case 2:
                                ser = 60;
                                break;
                            case 3:
                                ser = 60;
                                break;
                            case 4:
                                ser = 59;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "SL(RO)":
                    case "SL(QM)":
                    case "SL(TECH)":
                    case "APTC":
                        switch (rank) {
                            case 1:
                                ser = 60;
                                break;
                            case 2:
                                ser = 60;
                                break;
                            case 3:
                                ser = 59;
                                break;
                            case 4:
                                ser = 58;
                                break;
                            case 5:
                                ser = 57;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "JAG":
                    case "AEC":
                    case "MF":
                    case "SCO":
                    case "FOOD INSPECTION ORG":
                        switch (rank) {
                            case 1:
                                ser = 60;
                                break;
                            case 2:
                                ser = 60;
                                break;
                            case 3:
                                ser = 59;
                                break;
                            case 4:
                                ser = 58;
                                break;
                            case 5:
                                ser = 57;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "All Short Service Commission Offrs":
                        ser = 10 + 4;
                        break;
                    case "RT JCO":
                        ser = 57;
                        break;
                    default:
                        break;
                }
            }
            //else {
            //    // Handle the case when rank is 10 or greater
            //}
            else {
                switch (Regiment) {
                    case "ALL ARMS/SERVICE":
                        switch (rank) {
                            //case 10:
                            //    ser = 60;
                            //    break;
                            //case 11:
                            //    ser = 60;
                            //    break;
                            case 12:
                                ser = 32;
                                break;
                            case 13:
                                ser = 28;
                                break;
                            case 14:
                                ser = 26;
                                break;
                            case 15:
                                ser = 24;
                                break;
                            case 16:
                                ser = 22;
                                break;
                            //case 17:
                            //    ser = 54;
                            //    break;
                            case 18:
                                ser = 17;
                                break;
                            case 44:
                                ser = 20;
                                break;
                            case 55:
                                ser = 20;
                                break;
                            case 56:
                                ser = 20;
                                break;
                            case 57:
                                ser = 20;
                                break;
                            case 58:
                                ser = 20;
                                break;
                            case 59:
                                ser = 20;
                                break;
                            case 60:
                                ser = 20;
                                break;
                            case 61:
                                ser = 20;
                                break;
                            case 62:
                                ser = 20;
                                break;
                            case 63:
                                ser = 20;
                                break;
                           
                            default:
                                break;
                        }
                        break;
                    case "EME":
                        switch (rank) {
                            case 64:
                                ser = 20;
                                break;
                        }
                        break;
                    case "ASC":
                    case "AOC":
                        switch (rank) {
                            case 65:
                                ser = 20;
                                break;
                        }
                        break;
                    case "ENGR":
                        switch (rank) {
                            case 66:
                                ser = 20;
                                break;
                        }
                        break;
                }
            }
             
            if (ser != null) {
                if (rank < 10) {

                    var retirementDate = new Date(BirthDate.getFullYear() + ser, BirthDate.getMonth(), BirthDate.getDate());
                    retirementDate.setFullYear(retirementDate.getFullYear());
                }
                else {
                    var retirementDate = new Date(enrollmentDate.getFullYear() + ser, enrollmentDate.getMonth(), enrollmentDate.getDate());
                    retirementDate.setFullYear(retirementDate.getFullYear());
                }

            }
            else {
                var retirementDate = new Date(enrollmentDate.getFullYear() + 30, enrollmentDate.getMonth(), enrollmentDate.getDate());
            }
           

            var formattedEnrollmentDate = formatDate(enrollmentDate);
            var formattedRetirementDate = formatDate(retirementDate);

            // Set the values to the appropriate input fields
            $('#Enrollment_Date').val(formattedEnrollmentDate);
            $('#Retirement_Date').val(formattedRetirementDate);

            // Alert the dates (optional for debugging)
           /* alert("Enrollment Date: " + formattedEnrollmentDate + "\nRetirement Date: " + formattedRetirementDate);*/
        } else {
            console.error('Invalid date.');
        }
    } else {
        console.error('Invalid date string.');
    }
}

function formatDate(date) {
     
    var year = date.getFullYear();
    var month = ("0" + (date.getMonth() + 1)).slice(-2);
    var day = ("0" + date.getDate()).slice(-2);
    return day + "/" + month + "/" + year ;
}


function handler(e) {
  
    $('#mess').text("This field has been calculated based on your system DateTime. Ensure system DateTime is correct.");

    var dateString = $('#Enrollment_Date').val();

    var dateParts = dateString.split("/");

    var dateObject = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);

    dt1 = new Date(dateObject);
    dt2 = new Date();
    $('#Year_Of_Service').val(diff_years(dt1, dt2));
    //console.log(diff_years(dt1, dt2));
    
    var d1 = new Date($('#Enrollment_Date').val());
    var d2 = new Date($('#Retirement_Date').val());
  


    var reds = diff_years(d1, d2);

    $('#Residual_Service').val(reds - parseInt($('#Year_Of_Service').val()));


}



function calculateResidual_Service(e) {
     
    var dateString = $('#Enrollment_Date').val();

    var dateParts = dateString.split("/");

    var dateObject = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);


    var dateString2 = $('#Retirement_Date').val();

    var dateParts2 = dateString2.split("/");

    var dateObject2 = new Date(+dateParts2[2], dateParts2[1] - 1, +dateParts2[0]);

    var d1 = new Date(dateObject);
    var d2 = new Date(dateObject2);

    var reds = diff_years(d1, d2);

    $('#Residual_Service').val(reds - parseInt($('#Year_Of_Service').val()));
}


function handleExtensionChange(event) {
    var selectedValue = event.target.value;
    var date = $('#Date_Of_Birth').val();
    var Rank = $('#Rank').val();

    // Check if Date of Birth is empty
    if (!date) {
        alert("Date of Birth value is empty. Please enter a valid Date of Birth.");
        $('#Date_Of_Birth').val('');
        $('#extensionSelect').val('0');
        return;
    }

    // Check if Rank is 12
    if (Rank === '12') {
        
        var promotionDate = $('#Promotion_Date').val();

        // Check if Promotion Date is empty
        if (!promotionDate) {
            alert("Promotion Date value is empty. Please enter a valid Promotion Date");
            $('#extensionSelect').val('0');
            return;
        }

        
        if (selectedValue.toLowerCase() === "yes") {

            var retirementDate = new Date(promotionDate);
            retirementDate.setFullYear(retirementDate.getFullYear() + 4);
            var RetirementDate = extensionFormatDate(retirementDate);

            $('#Retirement_Date').val(RetirementDate);


              /* For Residual Service*/
            var dateString = $('#Enrollment_Date').val();

            var dateParts = dateString.split("/");

            var dateObject = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);

            dt1 = new Date(dateObject);
            dt2 = new Date();
            $('#Year_Of_Service').val(diff_years(dt1, dt2));
            var d1 = new Date($('#Enrollment_Date').val());
            var d2 = new Date($('#Retirement_Date').val());
            var reds = diff_years(d1, d2);
            $('#Residual_Service').val(reds - parseInt($('#Year_Of_Service').val()));
            $('#mess').text('');
        } else {
          
            var dt = $('#Date_Of_Birth').val();
            calallser1(dt);

            $('#Promotion_Date').val('');
            $('#Residual_Service').val('');
            $('#Year_Of_Service').val('');
            $('#mess').text('');
        }
    } else {
       
        if (selectedValue.toLowerCase() === "yes") {
            var retirementDate = new Date($('#Retirement_Date').val());
            retirementDate.setFullYear(retirementDate.getFullYear() + 2);

            var RetirementDate = extensionFormatDate(retirementDate);

            $('#Retirement_Date').val(RetirementDate);
            $('#Year_Of_Service').val('');
            $('#Residual_Service').val('');
            $('#Promotion_Date').val('');
            $('#mess').text('');
        } else {
            document.getElementById("uploadOption").style.display = "none"; // Hide upload option
            $('#ExtentionfileUpload').val(''); // Clear the value
            $('#fileUploadError').text(""); // Clear any previous error message

            var retirementDate = new Date($('#Retirement_Date').val());
            retirementDate.setFullYear(retirementDate.getFullYear() - 2);

            var RetirementDate1 = extensionFormatDate(retirementDate);
            $('#Retirement_Date').val(RetirementDate1);
            $('#Year_Of_Service').val('');
            $('#Residual_Service').val('');
            $('#Promotion_Date').val('');
            $('#mess').text('');
        }
    }
}




// Function to format date for extension
function extensionFormatDate(date) {
    var month = '' + (date.getMonth() + 1);
    var day = '' + date.getDate();
    var year = date.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [day,month,year ].join('/');
}


// Function to handle file upload validation
$('#fileUpload').change(function () {
    var fileInput = this;
    var filePath = fileInput.value;
    var allowedExtensions = /(\.pdf)$/i; // Regular expression to match only PDF files

    if (!allowedExtensions.exec(filePath)) {
        // If the uploaded file is not a PDF, display an error message
        $('#fileUploadError').text("Only PDF files are allowed.");
        fileInput.value = ''; // Clear the file input
        return false;
    }
    // Clear any previous error message if a PDF file is selected
    $('#fileUploadError').text("");
});





function formatDates(date) {
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    return (day < 10 ? '0' : '') + day + '/' + (month < 10 ? '0' : '') + month + '/' + year;
}



//Validating the form

//function validateForm() {

//     
//    var x, y, z, a, i, valid = true;
//    x = document.getElementsByClassName("tab");
//    y = x[currentTab].getElementsByTagName("input");


//    for (i = 0; i < y.length; i++) {


//        if (currentTab == 0) {
//            if (y[1].value.trim() == "") {
//                y[1].value = "ok";
//            }
//            if (y[4].value.trim() == "") {
//                y[4].value = "ok";
//            }
//            if (y[11].value == "") {


//                y[11].value = "2011-03-03";
//            }
//        }
//        if (y[i].value.trim() == "") {

//            y[i].className += " invalid";

//            valid = false;

//        }

//        /*ajay 03-04-24*/

//       // if (currentTab == 0) {
//       //  if (y[18].value.length != 12 || y[19].value.length != 10) {
//       //      valid = false;
//       //    }
//       //}


//        if (currentTab == 0) {
//            if (y[1].value == "ok") {
//                y[1].value = "";
//            }
//            if (y[1].value == "ok") {
//                y[4].value = "";
//            }
//            if (y[11].value == "2011-03-03") {
//                y[11].value = "";
//            }
//        }
//    }


//    if (valid) {
//        document.getElementsByClassName("step")[currentTab].className += " finish";
//    }
//    return valid;
//}



function validateResidualService() {
     
    var ResidualService = $('#Residual_Service').val();
    
    if (ResidualService <= 2) {
        // Set error message if fileUpload is empty
        $('#Residual_ServiceError').text("Retirement date of more than 02 yrs (24 months) only to be accepted");
        return false;
        // Field is invalid
    }
    // Clear error message if fileUpload is not empty
    $('#Residual_ServiceError').text("");
    return true;
     // Field is valid
}

function validateYearOfService() {
    
    var Year_Of_Service = $('#Year_Of_Service').val();
   
    var prefix = $('#dropdownSelect').val();
    if (prefix == "JC" || prefix == "OR") {
        if (Year_Of_Service <= 5) {
            // Set error message if fileUpload is empty
            $('#Year_Of_ServiceError').text("Retirement date of more than 02 yrs (24 months) only to be accepted");
            return false;
            // Field is invalid
        }
        else {
            $('#Year_Of_ServiceError').text("");
            return true;
        }
    } else {
        $('#Year_Of_ServiceError').text("");
        return true;
    }
    // Clear error message if fileUpload is not empty
   
    // Field is valid
}

function validateForm() {
    debugger;
    // This function deals with validation of the form fields
    var x, y, i, valid = true;
    // Validate FileUpload field
    
    valid = validateYearOfService() && valid;

    valid = validateResidualService() && valid;

    x = document.getElementsByClassName("tab");
    y = x[currentTab].getElementsByTagName("input");
   // A loop that checks every input field in the current tab:
   /* y = document.querySelectorAll('input');*/

    // A loop that checks every input field:
    for (i = 0; i < y.length; i++) {
        // If a field is empty...
        if (y[i].value.trim() === "") {
            // add an "invalid" class to the field:
            y[i].classList.add("invalid");

            // Get the name attribute of the input field
            var fieldName = y[i].getAttribute("name");

            // Create a new span element for the error message
            var errorMessage = document.createElement("span");
            errorMessage.className = "error";
            errorMessage.textContent = fieldName + " is required";

            // Insert the error message after the input field
            y[i].parentNode.insertBefore(errorMessage, y[i].nextSibling);

            // and set the current valid status to false
            valid = false;
        } else {
            // If the field is not empty, remove any existing error message
            if (y[i].nextSibling && y[i].nextSibling.className === "error") {
                y[i].parentNode.removeChild(y[i].nextSibling);
            }
        }

        // Add event listener to detect changes in the input field
        y[i].addEventListener("change", function () {
            if (this.value.trim() !== "") {
                // If the field is filled, remove any existing error message
                if (this.nextSibling && this.nextSibling.className === "error") {
                    this.parentNode.removeChild(this.nextSibling);
                }
            }
        });
    }

    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("step")[currentTab].classList.add("finish");
    }
    return valid; // return the valid status
}



//Salary slip Month year date picker


function Validate_Salary_Slip_date(event) {
    var selectedDate = new Date(document.getElementById("Salary_Slip_Month_Year").value);
    var currentDate = new Date();
    var threeMonthsAgo = new Date();
    threeMonthsAgo.setMonth(currentDate.getMonth() - 3);

    if (selectedDate < threeMonthsAgo) {
        alert("Please select a date within the last three months.");
        // Prevent the form from being submitted
        event.preventDefault();
        // Clear the input field using vanilla JavaScript
        document.getElementById("Salary_Slip_Month_Year").value = '';
        
        // If you're sure jQuery is properly included, you can also use:
        // $('#Salary_Slip_Month_Year').val('');
    }
}

//Fetching the value of the Regt/Corps


// Get references to dropdown and input field
 
var dropdown = document.getElementById("Regt_Corps");
var inputField = document.getElementById("CDA_PAO");

// Add event listener to dropdown
dropdown.addEventListener("change", function () {
    var selectedOption = dropdown.options[dropdown.selectedIndex];

    var selectedId = selectedOption.value;
  

    var selectedOption = $(this).find('option:selected');
    var selectedId = selectedOption.val();
    fetch(`/Car_PC_Advance_Application/LoadDropdownOptions?parameter=${encodeURIComponent(selectedId)}`)
        .then(response => response.json())
        .then(data => {
            if (data && data.length > 0) {
                const firstUnit = data[0]; 
                if (firstUnit && firstUnit.unitName !== undefined) {
                    inputField.value = firstUnit.CDA_PAO;
                } else {
                    console.error('unitName is undefined or null in the  unit:', firstUnit);
                }
            } else {
                console.error('Data is null or empty');
            }
        })
        .catch(error => {
            console.error('Fetch Error:', error); // Log any fetch errors
        });



});




var dropdown1 = document.getElementById("Rank");

// Add event listener to dropdown
dropdown1.addEventListener("change", function () {
    Rank = dropdown1.options[dropdown.selectedIndex];

    var selectedId = Rank.value;


    var selectedOption = $(this).find('option:selected');
    var selectedId = selectedOption.val();
   
 



});


jQuery(document).ready(function ($) {


    $(function () {
        $('.monthPicker').datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'MM yy',
            onClose: function (dateText, inst) {
                $(this).datepicker('setDate', new Date(inst.selectedYear, inst.selectedMonth, 1));
            }
        });

        function my_date(date_string) {
            var date_components = date_string.split("/");
            var day = date_components[0];
            var month = date_components[1];
            var year = date_components[2];
            return new Date(year, month - 1, day);
        }
         
        $('#Date_Of_Birth').datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'dd/mm/yy',
            yearRange: '1900:3000',
            onSelect: function () {
                var dt = $('#Date_Of_Birth').val();
              
                var newdt = new Date(my_date(dt));
                newdt.setFullYear(newdt.getFullYear() + 18);

                $('#Enrollment_Date').datepicker({
                    changeMonth: true,
                    changeYear: true,
                    showButtonPanel: true,
                    dateFormat: 'dd/mm/yy',
                    minDate: newdt,

                    startDate: '01/01/2010'


                });
            }
        });

 

        $('#Promotion_Date').datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'dd/mm/yy'

        });

        $('#Retirement_Date').datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'dd/mm/yy'
        });

    });
});








//08-05-24

$("#FrequencyOfLoan").change(function () {
    debugger;
    // Get the selected value of #FrequencyOfLoan
    var selectedValue = $(this).val();
    var armyNo = $('#dropdownSelect').val() + $('.ic').val() + $('#SuffixLetter').val();
    // Make the AJAX call with the selected value as a parameter
    $.ajax({
        url: "/Car_PC_Advance_Application/CheckArmyNo",
        type: "GET",
        dataType: "json",
        data: { frequency: armyNo }, // Pass the parameter here
        //success: function (data) {
        //    $("#dataContainer").html(data);
        //},
        success: function (data) {
            if (data.length >= 1) {
                // Show SweetAlert message
                Swal.fire({
                    title: 'Warning!',
                    text: 'You have already applied for a loan in this category.',
                    icon: 'warning',
                    confirmButtonText: 'OK'
                }).then(function () {
                    // Redirect or do whatever action you want here to restrict page movement
                    // For example, redirect to a specific page
                    window.location.href = "/Car_PC_Advance_Application/Create"; // Replace with your desired URL
                });
            } else {
                // Proceed with normal operations
                // Initialize the DataTable or any other action you want to perform
                $('#dataTable').DataTable();
            }
        },
        error: function () {
            alert('Error occurred while fetching data.');
        }
    });
});



    