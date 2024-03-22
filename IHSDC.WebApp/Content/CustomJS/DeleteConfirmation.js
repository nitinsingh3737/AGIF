function DeleteConfirmation(obj, ActionName) {	
	swal({
		title: "Are you want to sure Delete this Data?",
		text: "",
		type: "warning",
		showCancelButton: true,
		confirmButtonColor: "#DD6B55",
		confirmButtonText: "Yes, delete it!",
		cancelButtonText: "No, cancel ",
		closeOnConfirm: false,
		closeOnCancel: false
	},
		function (isConfirm) {
			if (isConfirm) {
				var encrypted = $(obj).attr('data-id');
				location.href = ActionName + '?id=' + encrypted;
			} else {
				swal("Data will be not Deleted because proccess is Cancelled!", "", "info");
			}
		}
	);
}


