
require([
	"vue", 
	"jquery", 
	"jquery.cookie", 
	"bootstrap", 
	"bootstrap-table", 
	"bootstrap-select", 
	"bootstrap-datetimepicker", 
	"bootstrap-datetimepicker.zh-CN",
	"fileinput",
	"fileinput_locale_zh"
], function(Vue,$) {


    $(document).ready(function(){
        loadCommonModule('<#=table.Key#>');
        $('.excel-import-button-<#=table.Key#>').click(function () {
            $('.table_add_modal').modal('hide');
            $('.table_excel_modal-<#=table.Key#>').on('shown.bs.modal',function(){
                $('.table_excel_modal-<#=table.Key#> .modal-body').html('<input class="excel_file-<#=table.Key#> input-file form-control" type="file">');
                $(".excel_file-<#=table.Key#>").fileinput({
                    language: 'zh', //设置语言
                    uploadUrl: "../Data/ExcelImport.ashx?fileType=<#=table.Key#>", //上传的地址
                    allowedFileExtensions: ['xls'],//接收的文件后缀,
                    showUpload: true, //是否显示上传按钮
                    dropZoneEnabled: true,
                    showCaption: true,//是否显示标题
                    browseClass: "btn btn-primary", //按钮样式             
                    previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
                    msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！"
                });
                $(".excel_file-<#=table.Key#>").on("fileuploaded",function(){
                    window.location.href = site_gen+"<#=table.Key#>List.html?table=<#=table.Key#>"
                });
            })
            $('.table_excel_modal-<#=table.Key#>').modal('show');
        })
        window.vm = new Vue({
            el:"#cnav<#=table.Key#>",
            data:{
                request:GetRequest()
            },
        })
        //$("#table-add").attr("href",$("#table-add").attr("href")+parseParam(vm.$data.request))
        $('#<#=table.Key#>').show();
    })
    loadCommonModule("<#=syscodes.rows.Where(p=>p.type=="module" && p.category==table.Key).Select(p=>p.title).FirstOrDefault()+"" #>");

    var $table = $("#table<#=table.Key#>"),
        $remove = $("#table-remove"),
        selections = [];
    //表格传区域ID参数
    $table.attr("data-url", location.href[0]==='f'?"localhost/XiangXi/gen/SVC.svc/get<#=table.Key#>List?districtID=":"/XiangXi/gen/SVC.svc/get<#=table.Key#>List?districtID=" + $.cookie("JTZH_districtID") + "&" + parseParam(GetRequest()) + "&");
	
    function initTable() {

        $table.bootstrapTable({
            striped: true,
            height: getHeight(),
            columns: [[<#
					foreach(var col in table.Value.Where(p=>!string.IsNullOrEmpty(p.column_name))){

					if(syscodes.rows.Any(p=>p.type=="hidecolumn"&&p.category==table.Key&&p.title==col.column_name) || 
					"id,districtID,TransactionID,VersionNo,IsDeleted,CreateOn,UpdateOn,CreateBy,UpdateBy".IndexOf(col.column_name)!=-1){
					    continue;
					}
						#>{<#
					
						if(col.dbtype=="datetime"){
						#>	
						    formatter: slashDate2yyyyMMdd,<#
						}else if("image,picture".Split(',').Any(s=>col.column_name.ToLower().IndexOf(s)!=-1)){
						#>	
        formatter: imgFormatter('<#=col.column_name#>'),<#
        }else if("link".Split(',').Any(s=>col.column_name.ToLower().IndexOf(s)!=-1)){
        #>	
        formatter: linkFormatter('<#=col.column_name#>'),<#
        }
						#>
						
    field: "<#=col.column_name#>",
    title: "<#=col.column_description#>",
    sortable: true,
    align: "center"
}, 
					<#
						#><#
}
						#>{
						    //操作栏，所有操作集中一起
						    field: "operate",
						    title: "操作",
						    align: "center",
						    events: operateEvents,
						    formatter: operateFormatter
						}
]
]
});
		
$("input[type=text]:first").focus();
// sometimes footer render error.超时操作
setTimeout(function() {
    $table.bootstrapTable("resetView");
}, 200);
//checkBox多选操作（删除），多选之后就使得删除按钮可用，删除操作还需另写
$table.on("check.bs.table uncheck.bs.table " +
    "check-all.bs.table uncheck-all.bs.table", function() {
        $remove.prop("disabled", !$table.bootstrapTable("getSelections").length);
        //($remove);

        // save your data, here just save the current page，这里需要考虑编辑保存的操作
        selections = getIdSelections();

        //(selections);//可以通过向后台输出数组这样的形式来操作
        //(JSON.stringify(selections));
        // push or splice the selections if you want to save all data selections，若想对所有保存项操作，需要进行数据拼接

    });
//加号展开
$table.on("expand-row.bs.table", function(e, index, row, $detail) {
    $detail.html('<image src="' + row.ImageUrl + '">');
    $.get("LICENSE", function(res) {
        $detail.html(res.replace(/\n/g, "<br>"));
    });
});
//输出所有
//$table.on('all.bs.table', function (e, name, args) {
//    (name, args);
//});

//删除按钮操作，具体操作还需请求接口，当前为前台删除，此方法好处是可以不需要刷新
//需要判断选择的是一个还是多个，分别请求不同的接口
$remove.click(function() {
    var ids = getIdSelections();
    $.ajax({
        url: SVC_DYNC + "/deleteMultiInformation?", //后台webservice里的方法名称 
        data: {
            idStr: ids.toString()
        },
        type: "get",
        success: function(data) {
            (data);
            $table.bootstrapTable("remove", {
                field: "id",
                values: ids
            });
            $remove.prop("disabled", true); //删除后按钮继续disabled
        },
        error: function(msg) {
            alert("获取角色信息失败！");
        }
    });
});
//调整浏览器窗口大小
$(window).resize(function() {
    $table.bootstrapTable("resetView", {
        height: getHeight()
    });
});
}
	
//扩展功能
$(function() {
	
    //加载辅助js文件
    function getScript(url, callback) {
        var head = document.getElementsByTagName("head")[0];
        var script = document.createElement("script");
        script.src = url;
        var done = false;
        // Attach handlers for all browsers
        script.onload = script.onreadystatechange = function() {
            if (!done && (!this.readyState ||
                this.readyState == "loaded" || this.readyState == "complete")) {
                done = true;
                if (callback)
                    callback();

                // Handle memory leak in IE
                script.onload = script.onreadystatechange = null;
            }
        };

        head.appendChild(script);

        // We handle everything using the script element injection
        return undefined;
    }
    var scripts = [
            "../assets/js/0-common/bootstrap-table.js",
            "../assets/js/0-common/bootstrap-table-export.js",
            "../assets/js/0-common/tableExport.js",
            "../assets/js/0-common/bootstrap-table-editable.js",
            "../assets/js/0-common/bootstrap-editable.js"
    ],
        eachSeries = function(arr, iterator, callback) {
            callback = callback || function() {};
            if (!arr.length) {
                return callback();
            }
            var completed = 0;
            var iterate = function() {
                iterator(arr[completed], function(err) {
                    if (err) {
                        callback(err);
                        callback = function() {};
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
    return $.map($table.bootstrapTable("getSelections"), function(row) {
        return row.id;
    });
}

//？
function responseHandler(res) {
    $.each(res.rows, function(i, row) {
        row.state = $.inArray(row.id, selections) !== -1;
    });
    return res;
}

//？
function detailFormatter(index, row) {
    var html = [];
    $.each(row, function(key, value) {
        html.push("<p><b>" + key + ":</b> " + value + "</p>");
    });
    return html.join("");
}
	
function imgFormatter(col) {
    return function(value, row, index){
        return [row[col]?'<img src="'+row[col]+'" width="40" height="40" />':'']
    }
}
function linkFormatter(col) {
    return function(value, row, index){
        return [row[col]?'<a href="'+row[col]+'">'+row[col]+'</a>':'']
    }
}
//操作图标
function operateFormatter(value, row, index) {
    return [
        //'<a class=" check am-btn"   href="javascript:void(0)"  title="查看详情" >',
        //'<i class="glyphicon glyphicon-edit"></i>查看详情',
        //"</a>  ",
        '<a class=" edit am-btn"   href="javascript:void(0)"  title="编辑" >',
        '<i class="glyphicon glyphicon-edit"></i>编辑',
        "</a>  ",
        '<a class="remove am-btn" href="javascript:void(0)" title="删除">',
        '<i class="glyphicon glyphicon-remove"></i>删除',
        '</a>'
    ].join("");
}

//操作日期
function dateformat(value, row, index) {
    return [
        (changeDateFormat(row.date) || "").substr(0, 10)
    ].join("");
}


//具体操作：打开网页，编辑，删除
window.operateEvents = {
    ////查看详情
    'click .check': function(e, value, row, index) {


        $.get("/XiangXi/3-business/BUS_Business_Review.html?" + Math.random(), null, function(pageData) {
            {
                $("#html-peek .modal-body").html("");
                $("#html-peek .modal-body").html(pageData);
                $(".type").html(row.type);
                $(".name").html(row.name);
                $(".processTime").html(row.processTime);
                $(".IDCard").html(row.IDCard);
                $(".createTime").html(row.createTime);
                $(".business").html(row.business);
                $(".service").html(row.service);
                $(".remark").html(row.remark);
                $(".phone").html(row.phone);
                $(".status").html(row.status);
                $("#html-peek").modal();

            }
        });
    },

    //编辑
    'click .edit': function(e, value, row, index) {
        for(var p in row){
            if(row[p]&&row[p][0]==='/'&&row[p].indexOf('/Date')===0) row[p] = slashDate2yyyyMMdd(row[p])
        }
        window.location.href = "/XiangXi/gen/<#=table.Key#>.html?table=<#=table.Key#>&" + parseParam(row);
    },

    //删除
    'click .remove': function(e, value, row, index) {
        //前台删除
        
        $table.bootstrapTable("remove", {
            field: "id",
            values: [row.id]
        });
        //后台删除
        Call('Delete<#=table.Key#>',row,function(data){
            $table.bootstrapTable("refresh");
        })
    }
};


//获取table高度
function getHeight() {
    return $(window).height() - $("h1").innerHeight(true) - $("#container").innerHeight(true);
}

})