$(function () {
    var svcHeader = (window.location.protocol ? (window.location.protocol + "//")
        : "")
        + window.location.host;
    var SCV_BUS = svcHeader + "/XiangXiService/Business.svc";
    $('#account-info').click(function () {
        $('#account-info-modal').modal()
    })

    // 初始化FileInput
    $("#cover").fileinput({
        language: 'zh', //设置语言
        uploadUrl: "/Test1/weixin/updatephoto?",
        // uploadUrl: "../Data/CoverUpload.ashx?",//上传的地址
        allowedFileExtensions: ['jpg', 'png', 'gif', 'JPEG'],//接收的文件后缀,
        showUpload: true, //是否显示上传按钮
        dropZoneEnabled: false,
        showCaption: true,//是否显示标题
        browseClass: "btn btn-primary", //按钮样式
        previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
        msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！"
    });

    $('#cover').on('fileuploaded', function (event, data, previewId, index) {
        console.log(data);
        $("#imageURL").val(data.response.imageURL);
    })
    //初始化UEditor
    var editor = UE.getEditor('mainText');


    var logout = function () {
        $.cookie("JTZH_userID", null, { path: "/" });
        $.cookie("JTZH_districtID", null, { path: '/' })
        window.location.href = "../login.html";
    }

    $('#release').click(function () {
        $.ajax({
            url:"/Test1/fabuwenzhang",
            data:{},
            success:function (data) {
                alert("发布成功！")

            }
        })
    })
    $('#submit').click(function () {
        //发布范围
        //var value = "";
        //for (var i = 0; i < range.length; i++) {
        //    if (range[i].checked) { //判断复选框是否选中
        //        value = value + range[i].value + "  "; //值的拼凑 .. 具体处理看你的需要,
        //    }
        //}
        //alert(value);//输出你选中的那些复选框的值
        // var title = $("#title").val();
        // var id = $("#thumb_media_id").val();
        // var author = $("#author").val();
        // var userID = $.cookie('JTZH_userID');
        // var districtID = $.cookie('JTZH_districtID');
        // var digest = $("#digest").val();
        // var pic = $("#show_cover_pic").val();
        // var content = $("#content").val();
        // var htmlContent = editor.getContent();



        var obj = {};
        $("input,select").each(function () {
            obj[$(this).attr("id")] = $(this).val()
        })
        obj.content = editor.getContent()
        alert(JSON.stringify(obj))

        // console.log(title, thumb_media_id, author, digest, show_cover_pic, mainText, content_source_url, time);
        var title = $("#title").val();
        var thumb_media_id = $("#thumbMediaId").val();
        var author = $("#author").val();
        // var userID = $.cookie('JTZH_userID');
        // var districtID = $.cookie('JTZH_districtID');
        var digest = $("#digest").val();
        var show_cover_pic = $("#showCoverPic").val();
        var mainText = $("#mainText").val();
        var content_source_url = $("#contentSourceUrl").val();
        // // var htmlContent = editor.getContent();
        // // console.log(title, type, peek, htmlContent, userID, districtID, imageURL);
        // if (title == "" || thumb_media_id == "" || author == "" || digest == "" || show_cover_pic == "" || mainText == "" || time == "" || content_source_url == "") {
        //     $('#common-alert .modal-title').html('');
        //     $('#common-alert .modal-title').html('提示');
        //     $('#common-alert .modal-body').html('');
        //     $('#common-alert .modal-body').html('信息填写不完全，请检查后重写！');
        //     $('#common-alert').modal();
        // } else {
        //     $.ajax({
        //         type: "POST",
        //         url: "/Test1/tianjiawenzhang",
        //         contentType: "application/json",
        //         data:obj,
        //         dataType: "JSON",
        //         processData: true,
        //         success: function (data) {
        //             console.log(data);
        //             $('#common-alert .modal-title').html('');
        //             $('#common-alert .modal-title').html('提示');
        //             $('#common-alert .modal-body').html('');
        //             $('#common-alert .modal-body').html('您已成功发布信息！请主动关闭本页面,或者等待3秒后自动跳转。。。');
        //             $('#common-alert').modal();
        //             //setTimeout(function () {
        //             //    window.location.href = "DYNC_Information.html";
        //             //}, 1500);
        //         }
        //     })
        $.post("/Test1/tianjiawenzhang", obj, function (data) {
            alert("添加成功！");
        })

    })

})




//     var obj = {};
//     $("input,select").each(function(){
//         obj[$(this).attr("id")] = $(this).val()
//     })
//     obj.content = editor.getContent()
//     alert(JSON.stringify(obj))
//
//
//     $.post("/Test1/fabuwenzhang", obj, function(data){
//         alert(JSON.stringify(data));
//     })
//     // }
// })