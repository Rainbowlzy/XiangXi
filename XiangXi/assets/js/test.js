require(['jquery', 'jquery.cookie', 'bootstrap', 'bootstrap-table', 'bootstrap-select', 'fileinput', 'fileinput_locale_zh'], function ($) {
    accountCheck(1);
    loadCommonModule('population');
    var $table = $('#table'),
    $remove = $('#table-remove'),
    selections = [];
    $table.attr("data-url", "/XiangXiService/Population.svc/getBasicPopulationList?districtID=" + $.cookie('JTZH_districtID') + "&");
    function initTable() {
        $table.bootstrapTable({
            striped: true,
            height: getHeight(),
            columns: [
                [
                    {
                        field: 'state',
                        checkbox: true,
                        align: 'center',
                        valign: 'middle'
                    }, {
                        field: 'id',
                        align: 'center',
                        valign: 'middle',
                        visible: false
                    }, {
                        field: 'name',
                        title: '姓名',
                        sortable: true,
                        align: 'center'
                    }, {
                        field: 'sex',
                        title: '性别',
                        sortable: true,
                        editable: false,
                        align: 'center'
                    }, {
                        field: 'IDCard',
                        title: '身份证',
                        sortable: true,
                        editable: false,
                        align: 'center'
                    }, {
                        field: 'nation',
                        title: '民族',
                        sortable: true,
                        editable: false,
                        align: 'center'
                    }, {
                        field: 'marriageStatus',
                        title: '婚姻状况',
                        sortable: true,
                        editable: false,
                        align: 'center'
                    }, {
                        field: 'politicsStatus',
                        title: '政治面貌',
                        sortable: true,
                        editable: false,
                        align: 'center'
                    }, {
                        field: 'address',
                        title: '地址',
                        sortable: true,
                        editable: false,
                        align: 'center'
                    }, {
                        field: 'district',
                        title: '区域',
                        sortable: true,
                        editable: false,
                        align: 'center'
                    }, {
                        //操作栏，所有操作集中一起
                        field: 'operate',
                        title: '操作',
                        align: 'center',
                        events: operateEvents,
                        formatter: operateFormatter
                    }
                ]
            ],
            //data:data1
        });

        // sometimes footer render error.超时操作
        setTimeout(function () {
            $table.bootstrapTable('resetView');
        }, 200);

        //checkBox多选操作（删除），多选之后就使得删除按钮可用，删除操作还需另写
        $table.on('check.bs.table uncheck.bs.table ' +
                'check-all.bs.table uncheck-all.bs.table', function () {
                    $remove.prop('disabled', !$table.bootstrapTable('getSelections').length);
                    //console.log($remove);

                    // save your data, here just save the current page，这里需要考虑编辑保存的操作
                    selections = getIdSelections();

                    //console.log(selections);//可以通过向后台输出数组这样的形式来操作
                    //console.log(JSON.stringify(selections));
                    // push or splice the selections if you want to save all data selections，若想对所有保存项操作，需要进行数据拼接

                });

        //加号展开
        $table.on('expand-row.bs.table', function (e, index, row, $detail) {
            $detail.html('<image src="' + row.ImageUrl + '">');
            $.get('LICENSE', function (res) {
                $detail.html(res.replace(/\n/g, '<br>'));
            });
        });
        //输出所有
        //$table.on('all.bs.table', function (e, name, args) {
        //    console.log(name, args);
        //});

        //删除按钮操作，具体操作还需请求接口，当前为前台删除，此方法好处是可以不需要刷新
        //需要判断选择的是一个还是多个，分别请求不同的接口
        $remove.click(function () {
            var ids = getIdSelections();
            console.log(ids.toString());
            $.ajax({
                url: SVC_POP + "/deleteMultiBasicPopulation?",    //后台webservice里的方法名称 
                data: {
                    idStr: ids.toString()
                },
                type: "get",
                success: function (data) {
                    console.log(data);
                    $table.bootstrapTable('remove', {
                        field: 'id',
                        values: ids
                    });
                    $remove.prop('disabled', true);//删除后按钮继续disabled
                },
                error: function (msg) {
                    alert("获取角色信息失败！");
                }
            })
        });
        //调整浏览器窗口大小
        $(window).resize(function () {
            $table.bootstrapTable('resetView', {
                height: getHeight()
            });
        });


    }
    //通过选中选择ID
    function getIdSelections() {
        return $.map($table.bootstrapTable('getSelections'), function (row) {
            return row.id
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
            html.push('<p><b>' + key + ':</b> ' + value + '</p>');
        });
        return html.join('');
    }
    //操作图标
    function operateFormatter(value, row, index) {
        return [

            '<a class=" edit am-btn"   href="javascript:void(0)"  data-am-modal="{target:\'#my-popup3\'}"  title="编辑" >',
            '<i class="glyphicon glyphicon-edit"></i>编辑',
            '</a>  ',
            '<a class="remove am-btn" href="javascript:void(0)" title="登出">',
            '<i class="glyphicon glyphicon-remove"></i>登出',
            '</a>'
        ].join('');
    }

    //具体操作：打开网页，编辑，删除
    window.operateEvents = {
        //查看
        'click .check': function (e, value, row, index) {

        },

        //编辑
        'click .edit': function (e, value, row, index) {
            $('#table_edit_modal .modal-title').html('编辑人口');
            $('#table_edit_modal .modal-body').html(
                  '<form role="form" class="row form-horizontal">' +
                        '<div class="col-md-6">' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="IDCard">身份证</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="IDCard" placeholder="请输入身份证,请确保已在基础人口中登记">' +
                                '</div>' +
                            '</div>' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="name">姓名</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="name" placeholder="请输入姓名">' +
                                '</div>' +
                            '</div>' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="sex">性别</label>' +
                                '<div class="col-sm-9">' +
                                    '<label class="radio-inline">' +
                                        '<input type="radio" name="sex" value="男" > 男' +
                                    '</label>' +
                                    '<label class="radio-inline">' +
                                        '<input type="radio" name="sex" value="女"> 女' +
                                    '</label>' +
                                '</div>' +
                            '</div>' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="address">住址</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="address" placeholder="请输入住址">' +
                                '</div>' +
                            '</div>' +
                              '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="guardian">监护人</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="guardian" placeholder="请输入监护人">' +
                                '</div>' +
                            '</div>' +
                        '</div>' +
                        '<div class="col-lg-6">' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="disableNum">残疾证号</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="disableNum" placeholder="请输入残疾证号">' +
                                '</div>' +
                            '</div>' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="disablelevel">残疾等级</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="disablelevel" placeholder="请输入残疾等级">' +
                                '</div>' +
                            '</div>' +
                             '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="relieffunds">救助金额</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="relieffunds" placeholder="请输入救助金额">' +
                                '</div>' +
                            '</div>' +
                             '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="district">所在区域</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="district" placeholder="请输入所在区域">' +
                                '</div>' +
                            '</div>' +
                             '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="explain">备注说明</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="explain" placeholder="请输入备注说明">' +
                                '</div>' +
                            '</div>' +
                        '</div>' +
                    '</form>');
            $('.selectpicker').selectpicker({
                style: 'btn-default',
                size: 10
            });
            $('#name').val(row.name);
            $('#IDCard').val(row.IDCard);
            $('#disableNum').val(row.disableNum);
            $('#disablelevel').val(row.disablelevel);
            $('#relieffunds').val(row.relieffunds);
            $('#guardian').val(row.guardian);
            $('#explain').val(row.explain);
            $('#address').val(row.address);
            $('#district').val(row.district);
            if (row.sex == '男') {
                $("input[type=radio][name=sex][value=男]").attr("checked", 'checked')
            } else if (row.sex == '女') {
                $("input[type=radio][name=sex][value=女]").attr("checked", 'checked')
            }
            $('#table_edit_modal').modal();
            $('#table_edit_modal .btn-success').click(function () {
                $.ajax({
                    url: SVC_POP + "/editDisabled",
                    type: "GET",
                    data: {
                        id: row.id,
                        name: $('#name').val(),
                        sex: $('#sex').val(),
                        IDCard: $('#IDCard').val(),
                        disableNum: $('#disableNum').val(),
                        disablelevel: $('#disablelevel').val(),
                        relieffunds: $('#relieffunds').val(),
                        guardian: $('#guardian').val(),
                        explain: $('#explain').val(),
                    },
                    success: function (data) {
                        console.log(data);
                        //$table.bootstrapTable
                        $('#table_edit_modal').modal('hide');
                        $table.bootstrapTable('refresh');
                    }
                })
            })

        },

        //删除
        'click .remove': function (e, value, row, index) {
            //前台删除
            console.log(row.id);
            $table.bootstrapTable('remove', {
                field: 'id',
                values: [row.id]
            });
            //后台删除
            $.ajax({
                type: "GET",
                url: SVC_POP + "/deleteBasicPopulation",
                data: {
                    id: row.id
                },
                success: function (data) {//成功后需要刷新一下？前台已经删了，不用刷新的
                    console.log(data);
                    $table.bootstrapTable('refresh');
                },
                error: function (data) {
                    console.log(data);
                }
            })
        }
    };


    //获取table高度
    function getHeight() {
        return $(window).height() - $('h1').innerHeight(true) - $('#container').innerHeight(true);
    }

    //扩展功能
    $(function () {
        var scripts = [
                '../assets/js/0-common/bootstrap-table.js',
                '../assets/js/0-common/bootstrap-table-export.js',
                '../assets/js/0-common/tableExport.js',
                '../assets/js/0-common/bootstrap-table-editable.js',
                '../assets/js/0-common/bootstrap-editable.js'
        ],
            eachSeries = function (arr, iterator, callback) {
                callback = callback || function () { };
                if (!arr.length) {
                    return callback();
                }
                var completed = 0;
                var iterate = function () {
                    iterator(arr[completed], function (err) {
                        if (err) {
                            callback(err);
                            callback = function () { };
                        }
                        else {
                            completed += 1;
                            if (completed >= arr.length) {
                                callback(null);
                            }
                            else {
                                iterate();
                            }
                        }
                    });
                };
                iterate();
            };

        eachSeries(scripts, getScript, initTable);
    });
    //加载辅助js文件
    function getScript(url, callback) {
        var head = document.getElementsByTagName('head')[0];
        var script = document.createElement('script');
        script.src = url;

        var done = false;
        // Attach handlers for all browsers
        script.onload = script.onreadystatechange = function () {
            if (!done && (!this.readyState ||
                    this.readyState == 'loaded' || this.readyState == 'complete')) {
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

    //新增
    $('#table-add').click(function () {
        $('#table_add_modal .modal-title').html('新增人口');
        $('#table_add_modal .modal-body').html(
                '<form role="form" class="row form-horizontal">' +
                        '<div class="col-md-6">' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="name">姓名</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="name" placeholder="请输入姓名">' +
                                '</div>' +
                            '</div>' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="IDCard">身份证</label>' +
                                '<div class="col-sm-9">' +
                                    '<input class="form-control" type="text" id="IDCard" placeholder="请输入身份证">' +
                                '</div>' +
                            '</div>' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="sex">性别</label>' +
                                '<div class="col-sm-9">' +
                                   '<label class="radio-inline">' +
                                        '<input type="radio"  name="sex" value="男"> 男' +
                                    '</label>' +
                                   '<label class="radio-inline">' +
                                   '<input type="radio"  name="sex" value="女"> 女' +
                                    '</label>' +
                                '</div>' +
                            '</div>' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="nation">民族</label>' +
                                '<div class="col-sm-9">' +
                                    '<select id="nation" class="form-control selectpicker">' +
                                       '<option value="汉族">汉族</option><option value="壮族">壮族</option><option value="满族">满族</option><option value="回族">回族</option><option value="苗族">苗族</option><option value="维吾尔族">维吾尔族</option><option value="土家族">土家族</option><option value="彝族">彝族</option><option value="蒙古族">蒙古族</option><option value="藏族">藏族</option><option value="布依族">布依族</option><option value="侗族">侗族</option><option value="瑶族">瑶族</option><option value="朝鲜族">朝鲜族</option><option value="白族">白族</option><option value="哈尼族">哈尼族</option><option value="哈萨克族">哈萨克族</option><option value="黎族">黎族</option><option value="傣族">傣族</option><option value="畲族">畲族</option><option value="傈僳族">傈僳族</option><option value="仡佬族">仡佬族</option><option value="东乡族">东乡族</option><option value="高山族">高山族</option><option value="拉祜族">拉祜族</option><option value="水族">水族</option><option value="佤族">佤族</option><option value="纳西族">纳西族</option><option value="羌族">羌族</option><option value="土族">土族</option><option value="仫佬族">仫佬族</option><option value="锡伯族">锡伯族</option><option value="柯尔克孜族">柯尔克孜族</option><option value="达斡尔族">达斡尔族</option><option value="景颇族">景颇族</option><option value="毛南族">毛南族</option><option value="撒拉族">撒拉族</option><option value="布朗族">布朗族</option><option value="塔吉克族">塔吉克族</option><option value="阿昌族">阿昌族</option><option value="普米族">普米族</option><option value="鄂温克族">鄂温克族</option><option value="怒族">怒族</option><option value="京族">京族</option><option value="基诺族">基诺族</option><option value="德昂族">德昂族</option><option value="保安族">保安族</option><option value="俄罗斯族">俄罗斯族</option><option value="裕固族">裕固族</option><option value="乌孜别克族">乌孜别克族</option><option value="门巴族">门巴族</option><option value="鄂伦春族">鄂伦春族</option><option value="独龙族">独龙族</option><option value="塔塔尔族">塔塔尔族</option><option value="赫哲族">赫哲族</option><option value="珞巴族">珞巴族</option>' +
                                    '</select>' +
                                '</div>' +
                            '</div>' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="">家庭住址</label>' +
                                '<div class="col-sm-9">' +

                                    '<select id="districtID" class="form-control" disabled>' +
                                       ' <option value="潦里">潦里</option>' +
                                    '</select>' +

                                    '<select id="plot" class="form-control selectpicker" title="小区/组">' +
                                        '<option value="杜康小区">杜康小区</option>' +
                                    '</select>' +
                                    '<select id="houseNum" class="form-control selectpicker" title="门牌号">' +
                                        '<option value="">1001</option>' +
                                        '<option value="">1002</option>' +
                                   ' </select>' +

                                '</div>' +
                           '</div>' +
                           '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="bookletNum">户口本号</label>' +
                                '<div class="col-sm-9">' +
                                   ' <input class="form-control" type="text" id="bookletNum" placeholder="请输入户口本号">' +
                               ' </div>' +
                           ' </div>' +
                            '<div class="form-group">' +
                                '<label class="col-sm-3 control-label" for="relationship">与户主关系</label>' +
                                '<div class="col-sm-9">' +
                                   ' <label class="radio-inline">' +
                                        '<input type="radio" name="relationship" value="户主"> 户主' +
                                   ' </label>' +
                                    '<label class="radio-inline">' +
                                       ' <input type="radio" name="relationship" value="配偶"> 配偶' +
                                    '</label>' +
                                   ' <label class="radio-inline">' +
                                     '   <input type="radio" name="relationship" value="子女"> 子女' +
                                   ' </label>' +
                                   ' <label class="radio-inline">' +
                                     '   <input type="radio" name="relationship" value="父母"> 父母' +
                                   ' </label>' +
                                   ' <label class="radio-inline">' +
                                       ' <input type="radio" name="relationship" value="其他"> 其他' +
                                    '</label>' +
                               ' </div>' +
                           ' </div>' +
                      '  </div>' +
                        '<div class="col-lg-6">' +
                           ' <div class="form-group">' +
                               ' <label class="col-sm-3 control-label" for="censusRegister">户籍地址</label>' +
                               ' <div class="col-sm-9">' +
                                   ' <input class="form-control" type="text" id="censusRegister" placeholder="请输入户籍地址">' +
                               ' </div>' +
                           ' </div>' +
                           ' <div class="form-group">' +
                               ' <label class="col-sm-3 control-label" for="populationType">人口类型</label>' +
                              '  <div class="col-sm-9">' +
                                  '  <select id="populationType" class="form-control selectpicker" title="人口类型">' +
                                     '   <option value="农业人口">农业人口</option>' +
                                       ' <option value="非农业人口">非农业人口</option>' +
                                   ' </select>' +
                               ' </div>' +
                           ' </div>' +
                           ' <div class="form-group">' +
                              '  <label class="col-sm-3 control-label" for="politicsStatus">政治面貌</label>' +
                              '  <div class="col-sm-9">' +
                                   ' <select id="politicsStatus" class="form-control selectpicker" title="政治面貌">' +
                                      '  <option value="党员">党员</option>' +
                                       ' <option value="团员">团员</option>' +
                                      '  <option value="群众">群众</option>' +
                                   ' </select>' +
                               ' </div>' +
                           ' </div>' +
                           ' <div class="form-group">' +
                              '  <label class="col-sm-3 control-label" for="marriageStatus">婚姻状况</label>' +
                              '  <div class="col-sm-9">' +
                                  '  <select id="marriageStatus" class="form-control selectpicker" title="婚姻状况">' +
                                     '   <option value="已婚">已婚</option>' +
                                      '  <option value="未婚">未婚</option>' +
                                     '   <option value="离异">离异</option>' +
                                       ' <option value="丧偶">丧偶</option>' +
                                    '</select>' +
                               ' </div>' +
                           ' </div>' +
                           ' <div class="form-group">' +
                             '   <label class="col-sm-3 control-label" for="educationDegree">教育水平</label>' +
                              '  <div class="col-sm-9">' +
                                  '  <select id="educationDegree" class="form-control selectpicker" title="教育水平">' +
                                      '  <option value="小学">小学</option>' +
                                      '  <option value="初中">初中</option>' +
                                      '  <option value="中专">中专</option>' +
                                      '  <option value="大专">大专</option>' +
                                       ' <option value="本科">本科</option>' +
                                      '  <option value="硕士">硕士</option>' +
                                      '  <option value="博士">博士</option>' +
                                   ' </select>' +
                               ' </div>' +
                           ' </div>' +
                           ' <div class="form-group">' +
                               ' <label class="col-sm-3 control-label" for="phone">电话</label>' +
                               ' <div class="col-sm-9">' +
                                 '   <input class="form-control" type="text" id="phone" placeholder="请输入电话">' +
                                '</div>' +
                           ' </div>' +
                           ' <div class="form-group">' +
                              '  <label class="col-sm-3 control-label" for="workPlace">工作单位</label>' +
                               ' <div class="col-sm-9">' +
                                  '  <input class="form-control" type="text" id="workPlace" placeholder="请输入工作单位">' +
                                '</div>' +
                           ' </div>' +
                       ' </div>' +
                   ' </form>');

        $('.selectpicker').selectpicker({
            style: 'btn-default',
            size: 10
        });
        $('#table_add_modal .alert').hide();
        $('#table_add_modal').modal();
        $('#table_add_modal .btn-success').click(function () {
            $.ajax({
                url: SVC_POP + "/addBasicPopulation",
                type: "GET",
                data: {
                    name: $('#name').val(),
                    IDCard: $('#IDCard').val(),
                    sex: $('input:radio[name="sex"]:checked').val(),
                    nation: $('#nation').val(),
                    plot: $('#plot').val(),
                    houseNum: $('#houseNum').val(),
                    bookletNum: $('#bookletNum').val(),
                    relationship: $('input:radio[name="relationship"]:checked').val(),
                    censusRegister: $('#censusRegister').val(),
                    populationType: $('#populationType').val(),
                    politicsStatus: $('#politicsStatus').val(),
                    marriageStatus: $('#marriageStatus').val(),
                    educationDegree: $('#educationDegree').val(),
                    phone: $('#phone').val(),
                    workPlace: $('#workPlace').val(),
                    districtID: $.cookie('JTZH_districtID')
                },
                success: function (data) {
                    if (data.success == true) {
                        $table.bootstrapTable('refresh');
                        $('#table_add_modal').modal('hide');
                    } else {
                        $('#table_add_modal .alert').html(data.message);
                        $('#table_add_modal .alert').show();
                    }

                },
                error: function () {
                    $('#table_add_modal .alert').html("网络错误！");
                    $('#table_add_modal .alert').show();
                }
            })
        })
        $('#table_add_modal .btn-info').click(function () {
            $('#table_add_modal').modal('hide');
            $('#table_excel_modal-population .modal-body').html('<input id="excel_file" class="input-file form-control" type="file">');
            $("#excel_file").fileinput({
                language: 'zh', //设置语言
                uploadUrl: "../Data/ExcelImport.ashx?fileType=population", //上传的地址
                allowedFileExtensions: ['xls'],//接收的文件后缀,
                showUpload: true, //是否显示上传按钮
                dropZoneEnabled: true,
                showCaption: true,//是否显示标题
                browseClass: "btn btn-primary", //按钮样式             
                previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
                msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！"
            });
            $('#table_excel_modal-population').modal('show');
        })
        $('#table_add_modal .btn-warning').click(function () {
            $('#table_add_modal').modal('hide');
            $('#table_excel_modal-building .modal-body').html('<input id="excel_file" class="input-file form-control" type="file">');
            $("#excel_file").fileinput({
                language: 'zh', //设置语言
                uploadUrl: "../Data/ExcelImport.ashx?fileType=fitBuilding", //上传的地址
                allowedFileExtensions: ['xls'],//接收的文件后缀,
                showUpload: true, //是否显示上传按钮
                dropZoneEnabled: true,
                showCaption: true,//是否显示标题
                browseClass: "btn btn-primary", //按钮样式             
                previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
                msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！"
            });
            $('#table_excel_modal-building').modal('show');
        })
    })
})