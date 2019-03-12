//require(['jquery', 'jquery.cookie', 'bootstrap', 'moment', 'fullcalendar', 'fullcalendar-zh-cn', 'bootstrap-datetimepicker', 'bootstrap-datetimepicker.zh-CN'], function ($) {
$(function () {
    accountCheck('bus00103');
    loadCommonModule_Z('business_Z');
    $("#reserveformID").validationEngine({
        validationEventTriggers: "keyup blur",//证验框架，触发的事件
        openDebug: true
    });
    $("#start").timepicker({
        dateFormat: 'yy-mm-dd', timeFormat: 'hh:mm', hourMin: 5, hourMax: 24, hourGrid: 3, minuteGrid: 15, timeText: '时间', hourText: '时', minuteText: '分', timeOnlyTitle: '选择时间',
    });
    $("#end").timepicker({
        dateFormat: 'yy-mm-dd', hourMin: 5, hourMax: 23, hourGrid: 3, minuteGrid: 15, timeText: '时间', hourText: '时', minuteText: '分',
    });
    $("#edit_start").timepicker({
        dateFormat: 'yy-mm-dd', timeFormat: 'hh:mm', hourMin: 5, hourMax: 24, hourGrid: 3, minuteGrid: 15, timeText: '时间', hourText: '时', minuteText: '分', timeOnlyTitle: '选择时间',
    });
    $("#edit_end").timepicker({
        dateFormat: 'yy-mm-dd', hourMin: 5, hourMax: 23, hourGrid: 3, minuteGrid: 15, timeText: '时间', hourText: '时', minuteText: '分',
    });
    //$("#start").timepicker({ dateFormat: 'yy-mm-dd', timeFormat: 'hh:mm', hourMin: 5, hourMax: 24, hourGrid: 3, minuteGrid: 15 });
    //$("#end").timepicker({ dateFormat: 'yy-mm-dd', timeFormat: 'hh:mm', hourMin: 5, hourMax: 24, hourGrid: 3, minuteGrid: 15 });
    $("#addhelper").hide();
    $('#calendar').fullCalendar({
        header: {
            right: 'prev,next today',
        },
        theme: true,
        editable: true,
        allDaySlot: false,
        monthNames: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
        monthNamesShort: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
        dayNames: ["周日", "周一", "周二", "周三", "周四", "周五", "周六"],
        dayNamesShort: ["周日", "周一", "周二", "周三", "周四", "周五", "周六"],
        today: ["今天"],
        firstDay: 1,
        buttonText: {
            today: '本月',
            prev: '上一月',
            next: '下一月'
        },
        viewDisplay: function (view) {//动态把数据查出，按照月份动态查询

            var viewStart = $.fullCalendar.formatDate(view.start, "yyyy-MM-dd HH:mm:ss");
            var viewEnd = $.fullCalendar.formatDate(view.end, "yyyy-MM-dd HH:mm:ss");
            $("#calendar").fullCalendar('removeEvents');//清空
            console.log(viewStart, viewEnd);
            var schdata = [{
                "id": "1",
                "title": "开会",
                "start": "2016-09-14 00:00",
                "end": "2016-09-14 08:00",
                "url": null,
                "fullname": "党员思想汇报大会",
                "details": "传达习大大讲话精神",
                "color": "#360"
            }, {
                "id": "2",
                "title": "开会",
                "start": "2016-09-15 00:00",
                "end": "2016-09-15 08:00",
                "url": null,
                "fullname": "街道开会",
                "details": "下半年经济建设规划",
                "color": "#360"
            }, {
                "id": "3",
                "title": "开会",
                "start": "2016-09-5 00:00",
                "end": "2016-09-5 08:00",
                "url": null,
                "fullname": "环境卫生和治安会议",
                "details": "保护环境，人人有责",
                "color": "#360"
            }]

            $.ajax({
                type: "GET",
                url: svc_bus + "/getSchedule",
                data: {
                    start: viewStart,
                    end: viewEnd
                },
                success: function (data) {
                    console.log(data.data);
                    $.each(data.data, function (index, term) {
                        $("#calendar").fullCalendar('renderEvent', term, true);
                    });
                }
            })
            //$.post("http://www.cnblogs.com/sr/AccessDate.ashx", { start: viewStart, end: viewEnd }, function (data) {

            //    var resultCollection = jQuery.parseJSON(data);//将格式完好的JSON字符串转为与之对应的JavaScript对象
            //    $.each(resultCollection, function (index, term) {
            //        $("#calendar").fullCalendar('renderEvent', term, true);
            //    });

            //}); //把从后台取出的数据进行封装以后在页面上以fullCalendar的方式进行显示
        },

        //events: "../sr/AccessDate.ashx",
        dayClick: function (date, allDay, jsEvent, view) {            //日期点击后弹出的jq ui的框，添加日程记录
            var selectdate = $.fullCalendar.formatDate(date, "yyyy-MM-dd");//选择当前日期的时间转换
            $("#reservebox").dialog({
                autoOpen: false,
                height: 450,
                width: 400,
                title: '设定时间： ' + selectdate,
                modal: true,
                position: "center",
                draggable: false,
                beforeClose: function (event, ui) {
                    //$.validationEngine.closePrompt("#meeting");
                    $.validationEngine.closePrompt("#start");
                    $.validationEngine.closePrompt("#end");
                },
                buttons: {
                    "关闭": function () {
                        $(this).dialog("close");
                    },
                    "添加": function () {

                        var startdatestr = $("#start").val();
                        var enddatestr = $("#end").val();
                        var title = $("#title").val();
                        var details = $("#details").val();
                        var startdate2 = $.fullCalendar.parseDate(selectdate + "T" + startdatestr);//时间和日期拼接
                        var enddate2 = $.fullCalendar.parseDate(selectdate + "T" + enddatestr);
                        var startdate = $.fullCalendar.formatDate(startdate2, "yyyy-MM-dd HH:mm:ss");
                        var enddate = $.fullCalendar.formatDate(enddate2, "yyyy-MM-dd HH:mm:ss");
                        var schdata = { start: startdate, end: enddate, title: title, fullname: title, description: details, };
                        $.ajax({
                            type: "POST", //使用post方法访问后台
                            url: "/XiangXiService/Business.svc/addSchedule?", //要访问的后台地址
                            contentType: "application/json",
                            dataType: "JSON",
                            data: '{"end":"' + enddate + '","start":"' + startdate + '","title":"' + title + '","fullname":"' + title + '","description":"' + details + '"}',
                            success: function (data) {
                                //对话框里面的数据提交完成，data为操作结果
                                console.log(data);
                                id2 = data;
                                var schdata2 = { start: startdate, end: enddate, title: title, fullname: title, description: details, id: id2 };
                                $('#calendar').fullCalendar('renderEvent', schdata2, true);
                                $("#start").val(''); //开始时间
                                $("#end").val(''); //结束时间
                                $("#title").val(''); //标题
                                $("#details").val(''); //内容 
                            }
                        });
                    }

                }
            });
            $("#reservebox").dialog("open");
            return false;
        },
        timeFormat: 'HH:mm{ - HH:mm}',
        eventClick: function (event) {

            var fstart = $.fullCalendar.formatDate(event.start, "HH:mm");//"yyyy-MM-dd HH:mm:ss" 
            var fend = $.fullCalendar.formatDate(event.end, "HH:mm");
            var ffstart = $.fullCalendar.formatDate(event.start, "yyyy-MM-dd");
            var ffend = $.fullCalendar.formatDate(event.end, "yyyy-MM-dd");

            console.log(ffstart);
            console.log(ffend);
            $("#edit_title").val(event.title);

            $("#edit_start").val(fstart);
            $("#edit_end").val(fend);
            $("#edit_details").val(event.description);
            $("#reserveinfo").dialog({
                autoOpen: false,
                height: 459,
                width: 400,
                modal: true,
                position: "center",
                draggable: false,
                buttons: {
                    "close": function () {
                        $(this).dialog("close");
                    }
                }
            });
            $("#reserveinfo").dialog("option", "buttons", {
                "关闭": function () {
                    $(this).dialog("close");
                },

                "删除": function () {

                    var answer = confirm("确定要删除该日程吗?");
                    if (answer) {

                        $.ajax({
                            type: "POST", //使用post方法访问后台
                            contentType: "application/json",
                            dataType: "JSON",
                            url: svc_bus + "/deleteSchedule", //要访问的后台地址
                            data: '{"id":"' + event.id + '"}',//要发送的数据
                            success: function (data) {
                                $('#calendar').fullCalendar('removeEvents', event.id);
                            }
                        });

                    }
                },
                "修改": function () {
                    var startdatestr = $("#edit_start").val();
                    var enddatestr = $("#edit_end").val();
                    var title = $("#edit_title").val();
                    var details = $("#edit_details").val();

                    var startdate2 = $.fullCalendar.parseDate(ffstart + "T" + startdatestr);//时间和日期拼接
                    var enddate2 = $.fullCalendar.parseDate(ffend + "T" + enddatestr);
                    var startdate = $.fullCalendar.formatDate(startdate2, "yyyy-MM-dd HH:mm:ss");
                    var enddate = $.fullCalendar.formatDate(enddate2, "yyyy-MM-dd HH:mm:ss");
                    var schdata = { start: startdate, end: enddate, title: title, fullname: title, description: details, };
                    console.log(startdate, enddate, details, title);
                    $.ajax({
                        type: "POST", //使用post方法访问后台
                        url: svc_bus + "/editSchedule", //要访问的后台地址
                        contentType: "application/json",
                        dataType: "JSON",
                        data: '{"id":"' + event.id + '","end":"' + enddate + '","start":"' + startdate + '","title":"' + title + '","fullname":"' + title + '","description":"' + details + '"}',
                        success: function (data) {
                            //对话框里面的数据提交完成，data为操作结果
                            console.log(data);
                            id2 = event.id;
                            var schdata2 = { start: startdate, end: enddate, title: title, fullname: title, description: details, id: id2 };
                            $('#calendar').fullCalendar('removeEvents', event.id);
                            $('#calendar').fullCalendar('renderEvent', schdata2, true);
                            $("#start").val(''); //开始时间
                            $("#end").val(''); //结束时间
                            $("#title").val(''); //标题
                            $("#details").val(''); //内容 
                            //$('#calendar').fullCalendar('updateEvent', event);
                        }
                    });
                }
            });
            var showtopic = '';
            showtopic = event.title;
            $("#revdesc").html('<div>' + showtopic + "</div>" + '<div style="padding: 10px 0px 3px">' + '<div>' + '&nbsp;' + '</div><div>' + event.description + '</div><div style="clear:both"></div></div>');

            $("#reserveinfo").dialog(
                { title: fstart + "-" + fend }
            );
            $("#reserveinfo").dialog("open");
            return false;
        },
        loading: function (bool) {
            if (bool) $('#loading').show();
            else $('#loading').hide();
        },
        eventMouseover: function (calEvent, jsEvent, view) {
            var fstart = $.fullCalendar.formatDate(calEvent.start, "yyyy/MM/dd HH:mm");
            var fend = $.fullCalendar.formatDate(calEvent.end, "HH:mm");
            $(this).attr('title', fstart + " - " + fend + " " + calEvent.topic + " : " + calEvent.description);
            $(this).css('font-weight', 'normal');
            $(this).tooltip({
                effect: 'toggle',
                cancelDefault: true
            });
        },
        eventMouseout: function (calEvent, jsEvent, view) {
            $(this).css('font-weight', 'normal');
        },
        eventRender: function (event, element) {
            var fstart = $.fullCalendar.formatDate(event.start, "HH:mm");
            var fend = $.fullCalendar.formatDate(event.end, "HH:mm");

        },
        eventAfterRender: function (event, element, view) {              //数据绑定上去后添加相应信息在页面上
            var fstart = $.fullCalendar.formatDate(event.start, "HH:mm");
            var fend = $.fullCalendar.formatDate(event.end, "HH:mm");
            //element.html('<a href=#><div>Time: ' + fstart + "-" +  fend + '</div><div>Room:' + event.confname + '</div><div style=color:#E5E5E5>Host:' +  event.fullname + "</div></a>");


            var confbg = '';
            if (event.confid == 1) {
                confbg = confbg + '<span class="fc-event-bg"></span>';
            } else if (event.confid == 2) {
                confbg = confbg + '<span class="fc-event-bg"></span>';
            } else if (event.confid == 3) {
                confbg = confbg + '<span class="fc-event-bg"></span>';
            } else if (event.confid == 4) {
                confbg = confbg + '<span class="fc-event-bg"></span>';
            } else if (event.confid == 5) {
                confbg = confbg + '<span class="fc-event-bg"></span>';
            } else if (event.confid == 6) {
                confbg = confbg + '<span class="fc-event-bg"></span>';
            } else {
                confbg = confbg + '<span class="fc-event-bg"></span>';
            }
            if (view.name == "month") {
                var evtcontent = '<div class="fc-event-vert"><a>';
                evtcontent = evtcontent + confbg;
                evtcontent = evtcontent + '<span class="fc-event-titlebg">' + fstart + " - " + fend + event.fullname + '</span>';
                evtcontent = evtcontent + '</a><div class="ui-resizable-handle ui-resizable-e"></div></div>';
                element.html(evtcontent);
            }

        },
        eventDragStart: function (event, jsEvent, ui, view) {
            ui.helper.draggable("option", "revert", true);
        },
        eventDragStop: function (event, jsEvent, ui, view) {
        },
        eventDrop: function (event, dayDelta, minuteDelta, allDay, revertFunc, jsEvent, ui, view) {
            if (1 == 1 || 2 == event.uid) {
                var schdata = { startdate: event.start, enddate: event.end, confid: event.confid, sid: event.sid };
            } else {
                revertFunc();
            }

        },
        eventResizeStart: function (event, jsEvent, ui, view) {

            //alert('resizing');

        },
        eventResize: function (event, dayDelta, minuteDelta, revertFunc) {

            if (1 == 1 || 2 == event.uid) {
                var schdata = { startdate: event.start, enddate: event.end, confid: event.confid, sid: event.sid };

            } else {
                revertFunc();
            }

        }

    });
    //$('#calendar').fullCalendar({
    //    lang: 'zh-CN',
    //    // put your options and callbacks here
    //    weekends: false, // will hide Saturdays and Sundays
    //    dayClick: function () {
    //        alert('a day has been clicked!');
    //    },
    //    header: {
    //        left: 'prev,next today myCustomButton',
    //        center: 'title',
    //        right: 'month,agendaWeek,agendaDay'
    //    },
    //    customButtons: {
    //        myCustomButton: {
    //            text: '快速添加日程',
    //            click: function () {
    //                $('#table_add_modal .modal-title').html('新增日程');
    //                $('#table_add_modal .modal-body').html(
    //                '<form role="form">' +
    //                    '<div class="form-group">'+
    //                        '<label class="control-label" for="IDCard">事件</label>'+
    //                        '<input class="form-control" type="text" id="IDCard" placeholder="输入事件">'+
    //                    '</div>'+
    //                    '<div class="form-group">'+
    //                        '<label class="control-label" for="workPlace">时间</label>'+
    //                        '<input size="16" type="text" readonly class="form_datetime form-control">'+
    //                    '</div>'+
    //                '</form>');
    //                $('#table_add_modal').modal();
    //                $('.form_datetime').datetimepicker({
    //                    format: 'yyyy/mm/dd',
    //                    language: 'zh-CN',
    //                    weekStart: 1,
    //                    minView: 2,
    //                    maxView: 4,
    //                    startView: 4,
    //                    autoclose: true
    //                });
    //            }
    //        }
    //    }
    //})
})