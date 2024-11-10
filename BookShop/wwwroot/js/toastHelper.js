function notifySuccess(message) {
    $.toast({
        heading: "موفقیت",
        text: message,
        position: "bottom-left",
        loaderBg: "#5ba035",
        icon: "success",
        hideAfter: 3e3,
        stack: 1
    })
}

function notifyWarning(message) {
    $.toast({
        heading: "هشدار",
        text: message,
        position: "bottom-left",
        loaderBg: "#da8609",
        icon: "warning",
        hideAfter: 3e3,
        stack: 1
    })
}

function notifyError(message) {
    $.toast({
        heading: "خطا",
        text: message,
        position: "bottom-left",
        loaderBg: "##bf441d",
        icon: "error",
        hideAfter: 3e3,
        stack: 1
    })
}