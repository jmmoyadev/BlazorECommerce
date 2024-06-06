window.showToastr = (type, message) => {
    if (type == "success") {
        toastr.success(message, "Operation successful", { timeout: 5000 });
    }
    if (type == "error") {
        toastr.error(message, "Operation failed", { timeout: 5000 });
    }
}