"use strict";

require(["vue", "jquery", "jquery.cookie", "bootstrap", "bootstrap-table", "bootstrap-select", "bootstrap-datetimepicker", "bootstrap-datetimepicker.zh-CN", "fileinput", "fileinput_locale_zh", "cmodules"], function (Vue, $) {

    $(document).ready(function () {
        $('.excel-import-button-BasicInformationOfVideoSurveillance').click(function () {
            $('.table_add_modal').modal('hide');
            $('.table_excel_modal-BasicInformationOfVideoSurveillance').on('shown.bs.modal', function () {
                $('.table_excel_modal-BasicInformationOfVideoSurveillance .modal-body').html('<input class="excel_file-BasicInformationOfVideoSurveillance input-file form-control" type="file">');
                $(".excel_file-BasicInformationOfVideoSurveillance").fileinput({
                    language: 'zh', //设置语言
                    uploadUrl: "../Data/ExcelImport.ashx?fileType=BasicInformationOfVideoSurveillance", //上传的地址
                    allowedFileExtensions: ['xls'], //接收的文件后缀,
                    showUpload: true, //是否显示上传按钮
                    dropZoneEnabled: true,
                    showCaption: true, //是否显示标题
                    browseClass: "btn btn-primary", //按钮样式             
                    previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
                    msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！"
                });
                $(".excel_file-BasicInformationOfVideoSurveillance").on("fileuploaded", function () {
                    window.location.href = site_gen + "BasicInformationOfVideoSurveillanceList.html?table=BasicInformationOfVideoSurveillance";
                });
            });
            $('.table_excel_modal-BasicInformationOfVideoSurveillance').modal('show');
        });
        var vm = new Vue({
            el: "#cnavBasicInformationOfVideoSurveillance",
            data: {
                request: GetRequest()
            }
        });
        //$("#table-add").attr("href",$("#table-add").attr("href")+parseParam(vm.$data.request))
        $('#BasicInformationOfVideoSurveillance').show();
    });
    var $table = $("#tableBasicInformationOfVideoSurveillance"),
        $remove = $("#table-remove"),
        selections = [];
    //表格传区域ID参数
    var url = "";
    if (location.href.indexOf('?') != -1) url = location.href.substr(location.href.indexOf('?') + 1);
    // $table.attr("data-url", "/XiangXi/gen/SVC.svc/getBasicInformationOfVideoSurveillanceList?districtID=" + $.cookie("JTZH_districtID") + "&" + url + "&");
    $table.attr("data-url", "/XiangXi/DefaultHandler.ashx?method=getBasicInformationOfVideoSurveillanceList&districtID=" + $.cookie("JTZH_districtID") + "&" + url + "&");

    function initTable() {

        $table.bootstrapTable({
            striped: true,
            height: getHeight(),
            columns: [[{
                field: "BIOVSDeviceName",
                title: "设备名称",

                sortable: true,
                align: "center"
            }, {
                field: "BIOVSIP协议",
                title: "IP地址",

                sortable: true,
                align: "center"
            }, {
                field: "BIOVSPort",
                title: "端口",

                sortable: true,
                align: "center"
            }, {
                field: "BIOVSGetuserrolelist",
                title: "用户名",

                sortable: true,
                align: "center"
            }, {
                field: "BIOVSCode",
                title: "密码",

                sortable: true,
                align: "center"
            }, {
                field: "BIOVSWhetherThePasswordIsCipherOrNot",
                title: "密码是否密文",

                sortable: true,
                align: "center"
            }, {
                field: "BIOVSAffiliatedArea",
                title: "所属地区",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSPersonalNumber",
                title: "编号",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSEquipmentType",
                title: "设备类型",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSRegistrationType",
                title: "注册类型",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSSerialNumber",
                title: "序列号",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVS",
                title: "vag名称",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDomain",
                title: "所属网域",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSAlarmInput",
                title: "报警输入",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSAlarmOutput",
                title: "报警输出",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSIntercomChannel",
                title: "对讲通道",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSAnalogChannelNumber",
                title: "模拟通道数",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSNumberChannel",
                title: "数字通道数",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSFirstRoad1",
                title: "第1路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSSecondRoad2",
                title: "第2路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSThirdRoad3",
                title: "第3路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSFourthRoad4",
                title: "第4路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSFifthRoad5",
                title: "第5路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSSixthRoad6",
                title: "第6路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSSeventhRoad7",
                title: "第7路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSEighthRoad8",
                title: "第8路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSNinthRoad9",
                title: "第9路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTenthRoad10",
                title: "第10路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSEleventhRoad11",
                title: "第11路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwelfthRoad12",
                title: "第12路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSThirteenthRoad13",
                title: "第13路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSFourteenthRoad14",
                title: "第14路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSFifteenthRoad15",
                title: "第15路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSSixteenthRoad16",
                title: "第16路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSSeventeenthRoad17",
                title: "第17路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSEighteenthRoad18",
                title: "第18路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSNineteenthRoad19",
                title: "第19路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwentiethRoad20",
                title: "第20路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwentyFirstRoad21",
                title: "第21路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwentySecondRoad22",
                title: "第22路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwentyThirdRoad23",
                title: "第23路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwentyFourthRoad24",
                title: "第24路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwentyFifthRoad25",
                title: "第25路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwentySixthRoad26",
                title: "第26路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwentySeventhRoad27",
                title: "第27路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwentyEighthRoad28",
                title: "第28路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSTwentyNinthRoad29",
                title: "第29路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSThirtiethRoad30",
                title: "第30路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSThirtyFirstRoad31",
                title: "第31路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSThirtySecondRoad32",
                title: "第32路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalFirst1",
                title: "数字第1路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalSecond2",
                title: "数字第2路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalThird3",
                title: "数字第3路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalFourth4",
                title: "数字第4路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalFifth5",
                title: "数字第5路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalSixth6",
                title: "数字第6路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalSeventh7",
                title: "数字第7路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalEighth8",
                title: "数字第8路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalNinth9",
                title: "数字第9路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTenth10",
                title: "数字第10路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalEleventh11",
                title: "数字第11路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwelfth12",
                title: "数字第12路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalThirteenth13",
                title: "数字第13路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalFourteenth14",
                title: "数字第14路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalFifteenth15",
                title: "数字第15路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalSixteenth16",
                title: "数字第16路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalSeventeenth17",
                title: "数字第17路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalEighteenth18",
                title: "数字第18路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalNineteenth19",
                title: "数字第19路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwentieth20",
                title: "数字第20路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwentyFirst21",
                title: "数字第21路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwentySecond22",
                title: "数字第22路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwentyThird23",
                title: "数字第23路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwentyFourth24",
                title: "数字第24路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwentyFifth25",
                title: "数字第25路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwentySixth26",
                title: "数字第26路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwentySeventh27",
                title: "数字第27路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwentyEighth28",
                title: "数字第28路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalTwentyNinth29",
                title: "数字第29路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalThirtieth30",
                title: "数字第30路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalThirtyFirst31",
                title: "数字第31路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSDigitalThirtySecond32",
                title: "数字第32路",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "BIOVSAddress",
                title: "地址",
                visible: false,
                sortable: true,
                align: "center"
            }, {
                field: "operate",
                title: "操作",
                align: "center",
                events: operateEvents,
                formatter: operateFormatter
            }]]
        });

        $("input[type=text]:first").focus();
        // sometimes footer render error.超时操作
        setTimeout(function () {
            $table.bootstrapTable("resetView");
        }, 200);
        //checkBox多选操作（删除），多选之后就使得删除按钮可用，删除操作还需另写
        $table.on("check.bs.table uncheck.bs.table " + "check-all.bs.table uncheck-all.bs.table", function () {
            $remove.prop("disabled", !$table.bootstrapTable("getSelections").length);
            selections = getIdSelections();
        });
        //加号展开
        $table.on("expand-row.bs.table", function (e, index, row, $detail) {
            $detail.html('<image src="' + row.ImageUrl + '">');
            $.get("LICENSE", function (res) {
                $detail.html(res.replace(/\n/g, "<br>"));
            });
        });
        var dropdowns = [];
        //删除按钮操作，具体操作还需请求接口，当前为前台删除，此方法好处是可以不需要刷新
        //需要判断选择的是一个还是多个，分别请求不同的接口
        $remove.click(function () {
            var ids = getIdSelections();
            $.ajax({
                url: SVC_DYNC + "/deleteMultiInformation?", //后台webservice里的方法名称 
                data: {
                    idStr: ids.toString()
                },
                type: "get",
                success: function success(data) {

                    $table.bootstrapTable("remove", {
                        field: "id",
                        values: ids
                    });
                    $remove.prop("disabled", true); //删除后按钮继续disabled
                },
                error: function error(msg) {
                    alert("获取角色信息失败！");
                }
            });
        });
        //调整浏览器窗口大小
        $(window).resize(function () {
            $table.bootstrapTable("resetView", {
                height: getHeight()
            });
        });
    }

    //扩展功能
    $(function () {

        //加载辅助js文件
        function getScript(url, callback) {
            var head = document.getElementsByTagName("head")[0];
            var script = document.createElement("script");
            script.src = url;
            var done = false;
            // Attach handlers for all browsers
            script.onload = script.onreadystatechange = function () {
                if (!done && (!this.readyState || this.readyState == "loaded" || this.readyState == "complete")) {
                    done = true;
                    if (callback) callback();

                    // Handle memory leak in IE
                    script.onload = script.onreadystatechange = null;
                }
            };

            head.appendChild(script);

            // We handle everything using the script element injection
            return undefined;
        }
        var scripts = ["../assets/js/0-common/bootstrap-table.js", "../assets/js/0-common/bootstrap-table-export.js", "../assets/js/0-common/tableExport.js", "../assets/js/0-common/bootstrap-table-editable.js", "../assets/js/0-common/bootstrap-editable.js"],
            eachSeries = function eachSeries(arr, iterator, callback) {
            callback = callback || function () {};
            if (!arr.length) {
                return callback();
            }
            var completed = 0;
            var iterate = function iterate() {
                iterator(arr[completed], function (err) {
                    if (err) {
                        callback(err);
                        callback = function callback() {};
                    } else {
                        completed += 1;
                        if (completed >= arr.length) {
                            callback(null);
                        } else {
                            iterate();
                        }
                    }
                });
            };
            iterate();
        };
        eachSeries(scripts, getScript, initTable);
    });

    //通过选中选择ID
    function getIdSelections() {
        return $.map($table.bootstrapTable("getSelections"), function (row) {
            return row.id;
        });
    }

    //？
    function responseHandler(res) {
        $.each(res.rows, function (i, row) {
            row.state = $.inArray(row.id, selections) !== -1;
        });
        return res;
    }

    //？
    function detailFormatter(index, row) {
        var html = [];
        $.each(row, function (key, value) {
            html.push("<p><b>" + key + ":</b> " + value + "</p>");
        });
        return html.join("");
    }

    function imgFormatter(col) {
        return function (value, row, index) {
            if (row[col] && row[col].indexOf(',') != -1) return [row[col] ? row[col].split(',').map(function (i) {
                return '<img src="' + i + '" width="40" height="40" />';
            }).join('') : ''];
            return [row[col] ? '<img src="' + row[col] + '" width="40" height="40" />' : ''];
        };
    }
    function linkFormatter(col) {
        return function (value, row, index) {
            ;
            return [row[col] ? $('<a></a>').attr('href', row[col]).text(strlimit(row[col], 30)).get(0).outerHTML : ''];
        };
    }
    function limitFormatter(col) {
        return function (value, row, index) {
            ;
            return [row[col] ? strlimit(row[col], 20) : ''];
        };
    }
    //操作图标
    function operateFormatter(value, row, index) {
        var statusButton = "";
        var k = 'BIOVSAddress';
        row.address = row[k];
        var positionurl = '/XiangXi/2_map/full_map.html?data=' + encodeURIComponent(JSON.stringify(row));
        if (row.address) {
            var positionbutton = ['<a class=" position am-btn"   href="', positionurl, '"  title="位置" >', '<i class="glyphicon glyphicon-globe"></i>位置', '</a>'].join("");
        }
        return [statusButton, positionbutton, '<a class=" edit am-btn"   href="javascript:void(0)"  title="编辑" >', '<i class="glyphicon glyphicon-edit"></i>编辑', '</a>'].join("");
    }

    //操作日期
    function dateformat(value, row, index) {
        return [(changeDateFormat(row.date) || "").substr(0, 10)].join("");
    }

    //具体操作：打开网页，编辑，删除
    window.operateEvents = {
        //编辑
        'click .edit': function clickEdit(e, value, row, index) {
            for (var p in row) {
                if (row[p] && row[p][0] === '/' && row[p].indexOf('/Date') === 0) row[p] = slashDate2yyyyMMdd(row[p]);
            }
            window.location.href = "/XiangXi/gen/BasicInformationOfVideoSurveillance.html?table=BasicInformationOfVideoSurveillance&data=" + encodeURIComponent(JSON.stringify(row));
        },
        'click .transfer': function clickTransfer(e, value, row, index) {
            var statusButton = "";
        },
        //删除
        'click .remove': function clickRemove(e, value, row, index) {
            //前台删除
            $table.bootstrapTable("remove", {
                field: "id",
                values: [row.id]
            });
            //后台删除
            $.call('DeleteBasicInformationOfVideoSurveillance', row, function (data) {
                $table.bootstrapTable("refresh");
            });
        }
    };

    //获取table高度
    function getHeight() {
        return $(window).height() - $("h1").innerHeight(true) - $("#container").innerHeight(true);
    }
});

//# sourceMappingURL=BasicInformationOfVideoSurveillanceList-compiled.js.map