$(function () {
    $('[data-toggle="tooltip"]').tooltip();

    $('.navbar-nav a').each(function () {
        if ($(this).attr('href') === window.location.pathname) {
            //console.log($(this).text());
            $('#navbar-header-name').text($(this).text());
            if ($(this).text()=='Dashboard') {
                $(this).addClass('current');
            } else {
                $(this).addClass('active-link');
                $(this).parent().parent().parent().parent().children('.sidebar-link').addClass('current');
                $(this).parent().parent().parent().parent().children('.collapse').addClass('show');
            }         
        }
    });

    $('.datepicker').datepicker({
        todayHighlight: true,
        format: 'yyyy/mm/dd'
    });

    $(document).bind("ajaxSend", function () {
        Loading(true);
    }).bind("ajaxStop", function () {
        Loading(false);
    }).bind("ajaxError", function () {
        Loading(true);
    });
});

function generateActionButtonForList(id,modalName){
    var content = '';
    content += '<button class="btn btn-secondary btn-sm rounded-circle" title="Delete" data-target="#delete" data-title="Delete" data-toggle="modal" data-id=' + id + '><i class="material-icons">delete</i></button >&nbsp;';
    content += '<button class="btn btn-secondary btn-sm rounded-circle" title="Update" data-target="#' + modalName + '" data-title="Update" data-toggle="modal"  data-id=' + id + '><i class="material-icons">edit</i></button>&nbsp;';
    if (modalName =='menuGrpModal') {
        content += '<button class="btn btn-secondary btn-sm rounded-circle" title="Menu Assign" data-target="#menuAssignModal" data-title="Menu Assign" data-toggle="modal"  data-id=' + id + '><i class="material-icons">menu</i></button>';
    }
    return content;
}

function resetInput(elementId) {
    $(elementId).find('input[type=text],input[type=email],textarea').val('');
    $(elementId).find('input[type=checkbox]').attr('checked', false);
    $(elementId).find('select').val('').change();
    $(elementId).find('img').attr('src', '');
    $('div').removeClass('has-error');
    $('input').prop('readonly', false);
}

function resetInputFile(elementId) {
    $(elementId).find('input[type=file]').val('');
    $(elementId).find('label').removeClass('selected');
    $(elementId).find('.custom-file-label').html('');
}

function checkImageFormat(fileName) {
    var validity = false;   
    if (fileName.toLowerCase().includes('.jpg')) {
        validity = true;
    } else if (fileName.toLowerCase().includes('.jpeg')) {
        validity = true;
    } else if (fileName.toLowerCase().includes('.png')) {
        validity = true;
    } else if (fileName.toLowerCase().includes('.gif')) {
        validity = true;
    }
    return validity;
}

function toggleFullScreen() {
    if (!document.fullscreenElement &&    // alternative standard method
        !document.mozFullScreenElement && !document.webkitFullscreenElement && !document.msFullscreenElement) {  // current working methods
        if (document.documentElement.requestFullscreen) {
            document.documentElement.requestFullscreen();
        } else if (document.documentElement.msRequestFullscreen) {
            document.documentElement.msRequestFullscreen();
        } else if (document.documentElement.mozRequestFullScreen) {
            document.documentElement.mozRequestFullScreen();
        } else if (document.documentElement.webkitRequestFullscreen) {
            document.documentElement.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
        }
    } else {
        if (document.exitFullscreen) {
            document.exitFullscreen();
        } else if (document.msExitFullscreen) {
            document.msExitFullscreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.webkitExitFullscreen) {
            document.webkitExitFullscreen();
        }
    }
}

function lockOpen() {
    $('#lockModal').modal('hide');
}

