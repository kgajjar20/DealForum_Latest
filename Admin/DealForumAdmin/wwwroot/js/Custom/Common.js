
$(this).ajaxError(function (event, request, settings) {
    if (request.status === 401) {
        if (request.responseJSON !== undefined && request.responseJSON !== null) {
            var resJSON = request.responseJSON;
            if (resJSON.RedirectURL !== undefined && resJSON.RedirectURL !== null) {
                window.location.href = resJSON.RedirectURL;
            }
        }
    }
});

$(document).on('focus', '.dateMask', function () {
    $(this).inputmask({
        alias: "datetime",
        clearIncomplete: true
    });
});

function DateMask() {
    $(".dateMask").inputmask({
        alias: "datetime",
        clearIncomplete: true
    });
}

function OpenWebsite(ele) {
    var url = $(ele).data("website");
    window.open(url, "_blank");
}

function copyToClipboard(element) {
    var $temp = $("<input>");
    $("body").append($temp);
    $temp.val($(element).text()).select();
    document.execCommand("copy");
    $temp.remove();
    SuccessToastr("Copied");

}


function copyTextToClipboard(text) {
    var input = document.createElement('textarea');
    input.innerHTML = text;
    document.body.appendChild(input);
    input.select();
    input.setSelectionRange(0, 99999); /* For mobile devices */
    /* Copy the text inside the text field */
    document.execCommand("copy");
    input.parentNode.removeChild(input);
    SuccessToastr("Copied");
}

function CopyLink(ele) {
    var text = $(ele).data("copytext");
    copyTextToClipboard(text);
}
function SuccessToastr(msg)
{
    toastr.success(msg);
}

