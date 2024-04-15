$(document).ready(function () {

    $('#Promotion_Date').datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: 'dd/mm/yy'
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
    debugger;
    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60 * 60 * 24);
    return Math.abs(Math.round(diff / 365.25));

}


function calallser1(e) {
    var ser;
    var ranks = $('#Rank').val(); // Assuming rank is a string representing an integer
    var rank = parseInt(ranks);

    var Regiment = $('#Regt_Corps').val().toUpperCase();
   
    alert(Regiment);
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
    alert(dateOfBirthString);
    debugger;
    var dateParts = dateOfBirthString.split('/');

    // Ensure that the dateParts array has three elements
    if (dateParts.length === 3) {
        var day  = parseInt(dateParts[0], 10);
        var month = parseInt(dateParts[1], 10) - 1; // Months are zero-based (0-11)
        var year = parseInt(dateParts[2], 10);

        // Check if the parsed values are valid
        if (!isNaN(year) && !isNaN(month) && !isNaN(day)) {

            var BirthDate = new Date(year + 0, month, day);
            alert(BirthDate);
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
            debugger;
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
            alert("Enrollment Date: " + formattedEnrollmentDate + "\nRetirement Date: " + formattedRetirementDate);
        } else {
            console.error('Invalid date.');
        }
    } else {
        console.error('Invalid date string.');
    }
}

function formatDate(date) {
    debugger;
    var year = date.getFullYear();
    var month = ("0" + (date.getMonth() + 1)).slice(-2);
    var day = ("0" + date.getDate()).slice(-2);
    return day + "/" + month + "/" + year ;
}


function handler(e) {
    alert("hii bhai");
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
    debugger;
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

/*increase or extention in service by 2 years*/
function handleExtensionChange(event) {
    var selectedValue = event.target.value;
    if (selectedValue === "1" || selectedValue.toLowerCase() === "yes") {

        document.getElementById("uploadOption").style.display = "block";
    } else {

        document.getElementById("uploadOption").style.display = "none";
    }

    if (selectedValue === "1") {

        alert("Please upload a copy of the pt order of extension of service.");

        var retirementDate = document.getElementById("Retirement_Date").value;
      
        var retirementDateInput = document.getElementById("Retirement_Date");
        var currentDate = new Date(retirementDateInput.value);
        var newRetirementDate = new Date(currentDate.getFullYear() + 2, currentDate.getMonth(), currentDate.getDate());
        var RetirementDate = formatDate(newRetirementDate);

        $('#Retirement_Date').val(RetirementDate);
    }
}

function formatDates(date) {
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    return (day < 10 ? '0' : '') + day + '/' + (month < 10 ? '0' : '') + month + '/' + year;
}



//Validating the form

function validateForm() {
    // This function deals with validation of the form fields
    
    var x, y, z, a, i, valid = true;
    x = document.getElementsByClassName("tab");
    y = x[currentTab].getElementsByTagName("input");

    // A loop that checks every input field in the current tab:
    for (i = 0; i < y.length; i++) {
        // If a field is empty...

        if (currentTab == 0) {
            if (y[1].value.trim() == "") {
                y[1].value = "ok";
            }
            if (y[4].value.trim() == "") {
                y[4].value = "ok";
            }
            if (y[11].value == "") {


                y[11].value = "2011-03-03";
            }
        }
        if (y[i].value.trim() == "") {
            // add an "invalid" class to the field:
            y[i].className += " invalid";
            //y[1].classList.remove("invalid");
            // y[4].classList.remove("invalid");
            // and set the current valid status to false
            valid = false;

        }

        /*ajay 03-04-24*/

        //if (currentTab == 0) {
        //    if (y[15].value.length != 12 || y[16].value.length != 10) {
        //        valid = false;
        //    }
        //}
        /*ajay 03-04-24*/
        if (currentTab == 0) {
            if (y[15].value.length != 12 || y[16].value.length != 10) {
                valid = true;
            }
        }
        //if (y[16].value.length != 10) {
        //    valid = false;
        //}
        if (currentTab == 0) {
            if (y[1].value == "ok") {
                y[1].value = "";
            }
            if (y[1].value == "ok") {
                y[4].value = "";
            }
            if (y[11].value == "2011-03-03") {
                y[11].value = "";
            }
        }
    }

    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}

//Salary slip Month year date picker


function validateDate() {
    
    var selectedDate = new Date(document.getElementById("Salary_Slip_Month_Year").value);
    var currentDate = new Date();
    var threeMonthsAgo = new Date();
    threeMonthsAgo.setMonth(currentDate.getMonth() - 3);

    if (selectedDate < threeMonthsAgo) {
        alert("Please select a date within the last three months.");
        document.getElementById("Salary_Slip_Month_Year").value = ""; // Clear the input field
    }
}


//Fetching the value of the Regt/Corps


// Get references to dropdown and input field
debugger;
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
    alert(selectedId);
 



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
        debugger;
        $('#Date_Of_Birth').datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'dd/mm/yy',
            yearRange: '1900:3000',
            onSelect: function () {
                var dt = $('#Date_Of_Birth').val();
                alert("ajay" + dt);
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