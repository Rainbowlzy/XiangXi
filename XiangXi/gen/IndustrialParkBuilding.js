
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
    "fileinput_locale_zh",
	"bootstrap-typeahead",
	"cmodules"
], function(Vue, $) {
    $(document).ready(function() {
        var request = GetRequest();
		if(request)
		for(var p in request){
			if(request[p].indexOf('%')!=-1)request[p] = decodeURIComponent(request[p])
		}
		var vm = {};
        var created = function () {
            $(".form_datetime").datetimepicker({
                format: "yyyy/mm/dd",
                language: "zh-CN",
                weekStart: 1,
                minView: 2,
                maxView: 4,
                startView: 4,
                autoclose: true
            })
            .on('changeDate', function (ev) {
				vm[$(this).attr('id')] = $(this).val();
            });
            $(".portrait").fileinput({
                language: "zh", //设置语言
                uploadUrl: "../ImageUpload.ashx?", //上传的地址
                allowedFileExtensions: ["jpg", "png", "gif", "JPEG"], //接收的文件后缀,
                showUpload: true, //是否显示上传按钮
                dropZoneEnabled: false,
                showCaption: true, //是否显示标题
                browseClass: "btn btn-primary", //按钮样式             
                previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
                msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！"
            })
			$(".portrait").on("fileuploaded", function(event, data, previewId, index) {
                $(".imageURL").val(data.response.imageURL);
				vm[$(this).attr('id')] = data.response.imageURL;
            });
			$("input[type=text]:first").focus();
			$('.excel-import-button-IndustrialParkBuilding').click(function () {
				$('.table_add_modal').modal('hide');
				$('.table_excel_modal-IndustrialParkBuilding').on('shown.bs.modal',function(){
					$('.table_excel_modal-IndustrialParkBuilding .modal-body').html('<input class="excel_file input-file form-control" type="file">');
					$(".excel_file").fileinput({
						language: 'zh', //设置语言
						uploadUrl: "../Data/ExcelImport.ashx?fileType=IndustrialParkBuilding", //上传的地址
						allowedFileExtensions: ['xls'],//接收的文件后缀,
						showUpload: true, //是否显示上传按钮
						dropZoneEnabled: true,
						showCaption: true,//是否显示标题
						browseClass: "btn btn-primary", //按钮样式             
						previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
						msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！"
					});
					$(".excel_file").on("fileuploaded",function(){
						window.location.href = site_gen+"IndustrialParkBuildingList.html"
					});
				})

				$('.table_excel_modal-IndustrialParkBuilding').modal('show');
			})
			$("#IndustrialParkBuilding").show();
        };
        var method = {
			log(o){
				(o)
				return o;
			},

            save() {
                var datum = this.$data;
				datum.districtID = $.cookie("JTZH_districtID");
				datum.VersionNo = parseInt(datum.VersionNo)
                $.call("SaveIndustrialParkBuilding", datum, function(data) {
					if(!data) return bootstrap_alert('返回数据为空')
					if(!data.success) return bootstrap_alert(data.message)
					window.location.href = site_gen+"IndustrialParkBuildingList.html?table=IndustrialParkBuilding"
                });
            },

			back(){
				window.location.href = site_gen+"IndustrialParkBuilding.html?table=IndustrialParkBuilding"
			},

			changeSelect(val){
				selector = 'option.'+val.target.value;
				var s = ''
				// N级联动，子集选择控件设置为空
				$(selector).parent().val('')
				// 子集中所有option单位隐藏
				$(selector).parent().children().hide()
				// 显示联动部分
				$(selector).show()
				// 刷新父控件
				$(selector).parent().selectpicker('refresh').selectpicker('toggle')
				vm[$(selector).parent().attr("id")]=val.target.value
			}
        };
			if(request && request.data) request = JSON.parse(decodeURIComponent(decodeURIComponent(request.data)));
			if (!request || request.id === undefined) {
				$.call("GetIndustrialParkBuildingEmpty", {}, function(data) {
					data = data||{};
					data.table = 'IndustrialParkBuilding'
					vm = new Vue({
						el: "#IndustrialParkBuilding",
						data: data||{},
						methods: method,
						mounted:created
					});
					$(".selectpicker1").selectpicker('refresh')
					console.log('picker');
				});
				return;
			}else{
				request.table = 'IndustrialParkBuilding'
				vm = new Vue({
					el: "#IndustrialParkBuilding",
					data: request||{},
					methods: method,
					mounted:created
				});
				$(".selectpicker1").selectpicker('refresh')
					console.log('picker');
			}
    });
});

