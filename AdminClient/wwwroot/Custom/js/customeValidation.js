(function () {
    if (!('noValidate' in document.createElement('form')) || !document.createElement('a').classList) {
        return;
    }

    var elemProto = Element.prototype;
    if (!elemProto.matches) {
        elemProto.matches = elemProto.matchesSelector || elemProto.mozMatchesSelector || elemProto.webkitMatchesSelector || elemProto.msMatchesSelector || elemProto.oMatchesSelector;
    }

    Array.prototype.forEach.call(document.querySelectorAll('form.validate'), function (form) {
        form.noValidate = true;

        form.addEventListener('keyup', function (e) {
            if (e.target.matches(':invalid')) {
                setInvalid(e.target);
            } else {
                removeInvalid(e.target);
            }
        }, true);

        form.addEventListener('change', function (e) {
            if (e.target.matches(':invalid')) {
                setInvalid(e.target);
            } else {
                removeInvalid(e.target);
            }
        }, true);

        form.addEventListener('invalid', function (e) {
            setInvalid(e.target);
            commonQuerySelector(form);
        }, true);
    });

    function commonQuerySelector(form) {
        form.querySelector('input:invalid, select:invalid, textarea:invalid').focus();
    }

    function setInvalid(element) {
        var parent = element.parentNode;
        if (!parent.classList.contains('has-error')) {
            parent.classList.add('has-error');
            //$(parent).append('<div role="tooltip" class="help-block popover fade bottom in" style="top: 60px; left: 15px; display: block;"><div class="arrow" style="left: 50%;"></div><h3 class="popover-title" style="display: none;">Validation!</h3><div class="popover-content">' + element.validationMessage + '</div></div>');
        }
        //else {
        //    $(parent).find('.help-block').remove();
        //    $(parent).append('<div role="tooltip" class="help-block popover fade bottom in" style="top: 60px; left: 15px; display: block;"><div class="arrow" style="left: 50%;"></div><h3 class="popover-title" style="display: none;">Validation!</h3><div class="popover-content">' + element.validationMessage + '</div></div>');
        //}
    }

    function removeInvalid(element) {
        var parent = element.parentNode;
        if (parent.classList.contains('has-error')) {
            parent.classList.remove('has-error');
            //$(parent).find('.help-block').remove();
        }
    }
})();
