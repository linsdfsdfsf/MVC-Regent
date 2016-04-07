function confirmDialog(options) {
    var config = $.extend({
        title: "系統提示",
        content: "",
        buttons: [{
            name: "確定",
            func: function () { $(this).parents(".cDialog:first").modal("hide"); }
        }]
    },options||{});
    var modalConfig = {
        backdrop: "static",
        keyboard: false
    };
    var modalId = "cModal"+$(".cDialog").length;
    var dialogHtml = "<div class='modal inmodal fade cDialog' id='"+modalId+"' tabindex='-1' role='dialog' aria-hidden='true' style='display: none;'>";
    dialogHtml += "<div class='modal-dialog modal-sm'><div class='modal-content'><div class='modal-header'>";
    dialogHtml += "<button type='button' class='close' data-dismiss='modal'><span aria-hidden='true'>×</span><span class='sr-only'>Close</span></button>";
    dialogHtml += "<h4 class='modal-title'>"+config.title+"</h4></div>";
    dialogHtml += "<div class='modal-body'>"+config.content+"</div>";
    dialogHtml += "<div class='modal-footer'>"
    if (config.buttons.length > 0) {
        for (var i = 0; i < config.buttons.length; i++) {
            dialogHtml += "<button type='button' id='c_dialog_btn"+i+"' class='btn btn-primary'>"+config.buttons[i].name+"</button>";
        }
    }
    dialogHtml += "</div></div></div></div>";
    $("body").append(dialogHtml);
    $("#" + modalId).modal(modalConfig);
    $("#" + modalId).on('hidden.bs.modal', function (e) { $("#" + modalId).remove(); });
    if (config.buttons.length > 0) {
        for (var i = 0; i < config.buttons.length; i++) {
            if (typeof config.buttons[i].func === "function") {
                $("#c_dialog_btn" + i).off("click").on("click", config.buttons[i].func);
            }
        }
    }
    return modalId;
}
function loadingDialog(cmd, content, func) {
    cmd = typeof cmd !== 'undefined' ? cmd : "";
    content = typeof content !== 'undefined' ? content : "";

    if (/^show/i.test(cmd)) {
        var dialogHtml = "<div class='modal inmodal fade' id='lDialog' tabindex='-1' role='dialog' aria-hidden='true' style='display: none;'>";
        dialogHtml += "<div class='modal-dialog modal-sm'><div class='modal-content'><div class='modal-header'>";
        dialogHtml += "<h4 class='modal-title'>系統訊息</h4></div>";
        dialogHtml += "<div class='modal-body'><p><img src='/img/loading.gif' width='32px' /><br>"+content+"</p></div></div></div></div>";
        $("body").append(dialogHtml);
        $("#lDialog").modal({
            backdrop: "static",
            keyboard: false
        });
        $("#lDialog").on('hidden.bs.modal', function (e) { $("#lDialog").remove(); });
        if (typeof func === "function") { func(); }
    }
    else if (/^value$/i.test(cmd)) {
        $("#lDialog .modal-body").html(content);
    }
    else if (/^hide$/i.test(cmd)) { $("#lDialog").modal("hide"); }
}