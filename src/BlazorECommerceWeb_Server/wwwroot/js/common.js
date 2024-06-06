window.showToastr = (type, message) => {
    if (type == "success") {
        toastr.success(message, "Operation successful!", { timeout: 5000 });
    }
    else if (type == "error") {
        toastr.error(message, "Operation failed!", { timeout: 5000 });
    }
}


window.showSwal = (type, message) => {
    if (type == "success") {
        Swal.fire({
            title: "Operation successful!",
            text: message,
            icon: "success"
        });
    }
    else if (type == "error") {
        Swal.fire({
            title: "Operation failed!",
            text: message,
            icon: "error"
        });
    }
}