require(['vue', 'jquery', 'bootstrap','fullcalendar'], function (Vue, $) {
    $(document).ready(function () {
        var vm = new Vue({
            el: "#container",
            data(){
                var json = $.callsync("GetMenuConfigurationByAuth", {"offset": 0, "limit": 800});
                if(!json)return {};
                var rows = json.rows;
                if (!rows) return {};
                var hlink = '/XiangXi/1_index/business.html?data=';
                var data = {
                    rows:rows
                        .filter(i => ",村务管理,党建信息管理,人口管理,村务地图,动态社区,厂房管理,统计管理,运维管理,合同管理,工业园和三产,".indexOf(',' + i.MCCaption + ',') != -1)
                        .map(i=>({
                            MCCaption:i.MCCaption,
                            MCLink: '/XiangXi/1_index/business.html?data='+encodeURIComponent(JSON.stringify(i)),
                            MCPicture:i.MCPicture,
                        }))
                }
                return data;
            },
            mount(){
            }
        });
        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay,listWeek'
            },
            defaultDate: '2018-03-12',
            navLinks: true, // can click day/week names to navigate views
            editable: true,
            eventLimit: true, // allow "more" link when too many events
            events: [
                {
                    title: '外出走访老兵',
                    start: '2018-03-01',
                },
                {
                    title: '使用会议室3002',
                    start: '2018-03-07',
                    end: '2018-03-10'
                },
                {
                    id: 999,
                    title: '提交工作日报',
                    start: '2018-03-09T16:00:00'
                },
                {
                    id: 999,
                    title: '参加党课',
                    start: '2018-03-16T16:00:00'
                },
                {
                    title: '讨论工作细节',
                    start: '2018-03-11',
                    end: '2018-03-13'
                },
                {
                    title: '监督第三方公司',
                    start: '2018-03-12T10:30:00',
                    end: '2018-03-12T12:30:00'
                },
                {
                    title: '参加党课',
                    start: '2018-03-12T12:00:00'
                },
                {
                    title: '提交工作日报',
                    start: '2018-03-12T14:30:00'
                },
                {
                    title: '提交工作日报',
                    start: '2018-03-12T17:30:00'
                },
                {
                    title: '参加党课',
                    start: '2018-03-12T20:00:00'
                },
                {
                    title: '参加党课',
                    start: '2018-03-13T07:00:00'
                },
                {
                    title: '参加党课',
                    url: 'http://google.com/',
                    start: '2018-03-28'
                }
            ]
        });

        $("#part2 #content div").mouseover(function () {
            $(this).css({"background": "rgba(255, 255, 255, 0.46)", "cursor": "pointer"});
        }).mouseleave(function () {
            $(this).css("background", "none");
        })
        $("#part2 #content div").dblclick(function () {
            alert($(this).attr("id"));
        })
    });

})