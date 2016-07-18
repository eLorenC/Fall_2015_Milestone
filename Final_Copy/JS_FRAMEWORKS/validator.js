var validatorJs = function () {
    var name = document.forms['mailForm'].getElementById('senderEmail');
    var Regex = new RegExp('^([^\n\b\t\r\s][\w\.]{1,30})((\.){0,25})([@]{1})([\w]{1,30})(\.{1})([A-Za-z]{1,25})');
    var matchSuccess = name.value.match(Regex);
    if (!matchSuccess) {
        name.toggleClass
    }
}