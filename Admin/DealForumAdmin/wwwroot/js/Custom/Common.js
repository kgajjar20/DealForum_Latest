//LOCAL
var SiteURL = 'https://localhost:44342/';




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
