window.ShowToastr = (type, message) => {
    if (type === "success") {
        /*        toastr.success('We do have the Kaqua suite available.', 'Turtle Bay Resort', { timeOut: 5000 });*/
        //toastr.success(message, "Operation Successful", { timeOut: 5000 });
        toastr.success(message, 'Operation Successful', { timeOut: 5000 });
    }
if (type === "error") {
        /*        toastr.success('We do have the Kaqua suite available.', 'Turtle Bay Resort', { timeOut: 5000 });*/
        toastr.error(message, 'Operation Failed', { timeOut: 5000 });
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success Notification',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Error Notification',
            message,
            'error'
        )
    }
}

function ShowDeleteConfirmationModel() {
     $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModel() {
    $('#deleteConfirmationModal').modal('hide');
}

