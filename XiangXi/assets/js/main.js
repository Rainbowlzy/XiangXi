//
// $(document).ready(function(){
//     $("#hq").click(function(){
//         var url = "../HTML/IntegralAcq.html";
//         var data = {type:1};
//         $.ajax({
//             type : "get",
//             async : false,  //同步请求
//             url : url,
//             data : data,
//             timeout:1000,
//             success:function(dates){
//                 //alert(dates);
//                 $("#c1").html(dates);//要刷新的div
//             },
//             error: function() {
//                 // alert("失败，请稍后再试！");
//             }
//         });
//     });
// })
// 积分获取明细
// $(document).ready(function(){
//     $("#xh").click(function(){
//         var url = "../HTML/IntegralCon.html";
//         var data = {type:1};
//         $.ajax({
//             type : "get",
//             async : false,  //同步请求
//             url : url,
//             data : data,
//             timeout:1000,
//             success:function(dates){
//                 //alert(dates);
//                 $("#c1").html(dates);//要刷新的div
//             },
//             error: function() {
//                 // alert("失败，请稍后再试！");
//             }
//         });
//     });
// })
// 积分消耗明细
$(document).ready(function(){
    $("#gz").click(function(){
        var url = "../HTML/IntegralRegualr.html";
        var data = {type:1};
        $.ajax({
            type : "get",
            async : false,  //同步请求
            url : url,
            data : data,
            timeout:1000,
            success:function(dates){
                //alert(dates);
                $("#c1").html(dates);//要刷新的div
            },
            error: function() {
                // alert("失败，请稍后再试！");
            }
        });
    });
})
// 积分定义规则

$(document).ready(function(){
    $("#jp").click(function(){
        var url = "../HTML/PrizeRules.html";
        var data = {type:1};
        $.ajax({
            type : "get",
            async : false,  //同步请求
            url : url,
            data : data,
            timeout:1000,
            success:function(dates){
                //alert(dates);
                $("#c1").html(dates);//要刷新的div
            },
            error: function() {
                // alert("失败，请稍后再试！");
            }
        });
    });
})
// 奖品规则定义
//
//  $(document).ready(function(){
//      $("#tj").click(function(){
//          var url = "../HTML/AddPrize.html";
//          var data = {type:1};
//          $.ajax({
//              type : "get",
//              async : false,  //同步请求
//              url : url,
//              data : data,
//              timeout:1000,
//              success:function(dates){
//                  //alert(dates);
//                  $("#c1").html(dates);//要刷新的div
//              },
//             error: function() {
//                  // alert("失败，请稍后再试！");
//              }
//          });
//      });
//  })

// $(document).ready(function(){
//     $("#zj").click(function(){
//         var url = "../HTML/WinningDemand.html";
//         var data = {type:1};
//         $.ajax({
//             type : "get",
//             async : false,  //同步请求
//             url : url,
//             data : data,
//             timeout:1000,
//             success:function(dates){
//                 //alert(dates);
//                 $("#c1").html(dates);//要刷新的div
//             },
//             error: function() {
//                 // alert("失败，请稍后再试！");
//             }
//         });
//     });
// })
// 中奖列表查询

$(document).ready(function(){
    $("#dh").click(function(){
        var url = "../HTML/CashPrizes.html";
        var data = {type:1};
        $.ajax({
            type : "get",
            async : false,  //同步请求
            url : url,
            data : data,
            timeout:1000,
            success:function(dates){
                //alert(dates);
                $("#c1").html(dates);//要刷新的div
            },
            error: function() {
                // alert("失败，请稍后再试！");
            }
        });
    });
})
// 兑奖记录查询

$(document).ready(function(){
    $("#yj").click(function(){
        var url = "../HTML/Warning.html";
        var data = {type:1};
        $.ajax({
            type : "get",
            async : false,  //同步请求
            url : url,
            data : data,
            timeout:1000,
            success:function(dates){
                //alert(dates);
                $("#c1").html(dates);//要刷新的div
            },
            error: function() {
                // alert("失败，请稍后再试！");
            }
        });
    });
})
// 积分预警

$(document).ready(function(){
    $("#yh").click(function(){
        var url = "../HTML/UserManager.html";
        var data = {type:1};
        $.ajax({
            type : "get",
            async : false,  //同步请求
            url : url,
            data : data,
            timeout:1000,
            success:function(dates){
                //alert(dates);
                $("#c1").html(dates);//要刷新的div
            },
            error: function() {
                // alert("失败，请稍后再试！");
            }
        });
    });
})
// 用户管理

$(document).ready(function(){
    $("#qx").click(function(){
        var url = "../HTML/AuthorityManage.html";
        var data = {type:1};
        $.ajax({
            type : "get",
            async : false,  //同步请求
            url : url,
            data : data,
            timeout:1000,
            success:function(dates){
                //alert(dates);
                $("#c1").html(dates);//要刷新的div
            },
            error: function() {
                // alert("失败，请稍后再试！");
            }
        });
    });
})
// 权限管理

$(document).ready(function(){
    $("#m1").click(function(){
        var url = "../HTML/MemberQuery.html";
        var data = {type:1};
        $.ajax({
            type : "get",
            async : false,  //同步请求
            url : url,
            data : data,
            timeout:1000,
            success:function(dates){
                //alert(dates);
                $("#c1").html(dates);//要刷新的div
            },
            error: function() {
                // alert("失败，请稍后再试！");
            }
        });
    });
})
// 会员查询

//$(document).ready(function(){
    //$("#ph").click(function(){
       // var url = "../HTML/AddTicket.html";
        //var data = {type:1};
        //$.ajax({
          //  type : "get",
          //  async : false,  //同步请求
           // url : url,
           // data : data,
           // timeout:1000,
           // success:function(dates){
                //alert(dates);
           //     $("#c1").html(dates);//要刷新的div
          //  },
          //  error: function() {
                // alert("失败，请稍后再试！");
         //   }
     //   });
  // });
//})
// 票号添加
$(document).ready(function(){
    $("#xg").click(function(){
        var url = "../HTML/ScoresEdit.html";
        var data = {type:1};
        $.ajax({
            type : "get",
            async : false,  //同步请求
            url : url,
            data : data,
            timeout:1000,
            success:function(dates){
                //alert(dates);
                $("#c1").html(dates);//要刷新的div
            },
            error: function() {
                // alert("失败，请稍后再试！");
            }
        });
    });
})
//积分数修改
$(document).ready(function(){
    $("#zp").click(function(){
        var url = "../HTML/CDRules.html";
        var data = {type:1};
        $.ajax({
            type : "get",
            async : false,  //同步请求
            url : url,
            data : data,
            timeout:1000,
            success:function(dates){
                //alert(dates);
                $("#c1").html(dates);//要刷新的div
            },
            error: function() {
                // alert("失败，请稍后再试！");
            }
        });
    });
})
// 票号添加
$(document).ready(function(){
    $("#zhuye").click(function(){
        var url = "../HTML/mainpage.html";
        var data = {type:1};
        $.ajax({
            type : "get",
            async : false,  //同步请求
            url : url,
            data : data,
            timeout:1000,
            success:function(dates){
                //alert(dates);
                $("#c1").html(dates);//要刷新的div
            },
            error: function() {
                // alert("失败，请稍后再试！");
            }
        });
    });
})

