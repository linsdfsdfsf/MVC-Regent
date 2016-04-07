var lastsel = 0;
var RSLO2O = {
    InitTable: function (config, iselect) {
        var jqGrid = !config.id ? $("#jqGridList") : $("#" + config.id);
        jqGrid.jqGrid({
            caption: config.title,
            url: config.url,
            mtype: "GET",
            styleUI: 'Bootstrap',
            datatype: "json",
            colNames: config.colNames,
            colModel: config.colModel,
            viewrecords: true,
            multiselect: iselect,
            autowidth: true,
            height: "100%",
            rowNum: 20,
            rownumbers: true, // show row numbers
            rownumWidth: 35, // the width of the row numbers columns
            pager: !config.pagerId ? "#jqGridPager" : "#" + config.pagerId,
            subGrid: config.subGrid ? true : false,
            subGridRowExpanded: config.subGridRowExpanded ? config.subGridRowExpanded : null
        });
        // Add responsive to jqGrid
        $(window).bind('resize', function () {
            var width = $('.jqGrid_wrapper').width();
            jqGrid.setGridWidth(width);
        });
    },
    //获取jqgrid的编辑内容
    GetDataTableEditeData: function () {
        var id = $('#jqGridList').jqGrid('getGridParam', 'selrow');
        if (id)
            return $('#jqGridList').jqGrid("getRowData", id);
        else
            return null;
    },
    //获取jqgrid要删除的内容
    GetDataTableDeleteData: function () {
        return RSLO2O.GetAllSelected("jqGridList");
    },

    GetAllSelected: function (id) {
        var res = {
            Len: 0,
            Data: []
        };
        var grid = $("#" + id);
        var rowKey = grid.getGridParam("selrow");

        if (rowKey) {
            var selectedIDs = grid.getGridParam("selarrrow");
            var result = "";
            for (var i = 0; i < selectedIDs.length; i++) {
                res.Data.push(selectedIDs[i]);
            }
        }
        res.Len = res.Data.length;
        return res;
    },

    InitEditor: function (id) {
        //编辑器
        $('#' + id).summernote({
            lang: "zh-CN",
            height: 400,
            onImageUpload: function (files, editor, $editable) {
                var file = files[0];
                var filename = false;
                try {
                    filename = file['name'];
                } catch (e) {
                    filename = false;
                }
                if (!filename) {
                    alert("请选择文件");
                }
                //以上防止在图片在编辑器内拖拽引发第二次上传导致的提示错误
                var ext = filename.substr(filename.lastIndexOf("."));
                ext = ext.toUpperCase();
                var timestamp = new Date().getTime();
                var name = timestamp + "_" + $("#txtContents").attr('aid') + ext;
                //name是文件名，自己随意定义，aid是我自己增加的属性用于区分文件用户
                data = new FormData();
                data.append("file", file);
                data.append("key", "动态页面");
                $.ajax({
                    data: data,
                    type: "POST",
                    url: "/adm/upload/UploadBase64ImageData",
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (data) {
                        //data是返回的hash,key之类的值，key是定义的文件名
                        //editor.insertImage($editable, data['data']);
                        $('#txtContents').summernote('editor.insertImage', data['data']);
                        alert("上传成功");

                    },
                    error: function () {
                        alert("上传失败");
                    }
                });
            }
        });
    }
};

var XPage = {
    SaveData: function (url, postData) {
        if ($("#validateList").valid()) {
            var btn = $("#btnSave");
            btn.button('loading');
            $.post(url, postData, function (res, status, jqXHR) {
                if (res.flag) {
                    alert("操作成功");
                } else {
                    alert("操作失败：" + res.msg);
                }
            }).error(function () {
                alert("服务器程序错误");
            }).complete(function () {
                btn.button('reset');
            });
        }
    },

    SaveDataWithNoValid: function (url, postData) {
        var btn = $("#btnSave");
        btn.button('loading');
        $.ajax({
            url: url,
            type: "POST",
            dataType: "JSON",
            data: JSON.stringify(postData),
            contentType: "application/json, charset=utf-8",
            success: function (res) {
                btn.button('reset');
                if (res.flag) {
                    alert("保存成功");
                } else {
                    alert("保存失败：" + res.msg);
                }
            },
            error: function () {
                alert("服务器程序错误");
            },
            complete: function () {
                btn.button('reset');
            }
        });
    },

    DelData: function (url) {
        var delDatas = RSLO2O.GetDataTableDeleteData();
        if (delDatas.Len > 0 && delDatas.Data.length > 0) {
            if (confirm("确认要删除这" + delDatas.Len + "条数据？")) {
                var btn = $("#btnDel");
                btn.button('loading');
                $.ajax({
                    url: url,
                    type: "POST",
                    dataType: "json",
                    data: JSON.stringify({ ids: delDatas.Data }),
                    contentType: "application/json, charset=utf-8",
                    success: function (res) {
                        btn.button('reset');
                        if (res.flag) {
                            alert("删除成功");
                            $("#jqGridList").trigger("reloadGrid");
                        } else {
                            alert("删除失败：" + res.msg);
                        }
                    }
                });
            }
        } else {
            alert("请选择要删除的数据！");
        }
    },

    BindDropdown: function (ddlId, url) {
        $.ajax({
            url: url,
            type: 'get',
            dataType: 'json',
            success: function (res) {
                if (res.flag) {
                    var dt = res.data;
                    var htmls = [];
                    for (var i = 0, item; item = dt[i]; i++) {
                        htmls.push(["<option value='", item.Value, "'>", item.Name, "</option>"].join(''));
                    }
                    $("#" + ddlId).append(htmls.join(''));
                } else {
                    alert("加载失败：" + res.msg);
                }
            }
        });
    },

    GoTo: function (url) {
        $("#btnBack").button("loading");
        window.location.href = url;
    },

    //搜索jqGrid
    Search: function (json) {
        var postData = $("#jqGridList").jqGrid("getGridParam", "postData");
        $.extend(postData, json);
        $("#jqGridList").setGridParam({ search: true }).trigger("reloadGrid", [{ page: 1 }]);
    }
}

