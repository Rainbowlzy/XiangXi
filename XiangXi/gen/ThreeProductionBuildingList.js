  
console.group("正在加载脚本")
require([
	"vue", 
	"jquery", 
	"jquery.cookie", 
	"bootstrap", 
	"bootstrap-table", 
	"bootstrap-select", 
    "bootstrap-table-zh-CN",
	"bootstrap-datetimepicker", 
//	"bootstrap-datetimepicker.zh-CN",
	"fileinput",
	"fileinput_locale_zh",
	"cmodules"
], function(Vue,$) {
console.log("正在加载自定义逻辑")
$(document).ready(function(){
		$.call('GetMenuConfigurationEmpty')

		$('.excel-import-button-ThreeProductionBuilding').click(function () {
			$('.table_add_modal').modal('hide');
			$('.table_excel_modal-ThreeProductionBuilding').on('shown.bs.modal',function(){
				$('.table_excel_modal-ThreeProductionBuilding .modal-body').html('<input class="excel_file-ThreeProductionBuilding input-file form-control" type="file">');
				$(".excel_file-ThreeProductionBuilding").fileinput({
					language: 'zh', //设置语言
					uploadUrl: "../Data/ExcelImport.ashx?fileType=ThreeProductionBuilding", //上传的地址
					allowedFileExtensions: ['xls'],//接收的文件后缀,
					showUpload: true, //是否显示上传按钮
					dropZoneEnabled: true,
					showCaption: true,//是否显示标题
					browseClass: "btn btn-primary", //按钮样式             
					previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
					msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！"
				});
				$(".excel_file-ThreeProductionBuilding").on("fileuploaded",function(){
					window.location.href = site_gen+"ThreeProductionBuildingList.html?table=ThreeProductionBuilding"
				});
			})
			$('.table_excel_modal-ThreeProductionBuilding').modal('show');
		})
		var vm = new Vue({
			el:"#cnavThreeProductionBuilding",
			data:{
				request:GetRequest(),
				nav_list:[]
			},
			methods:{
				parseEmpty: function(nav){
					return "javascript:parent.location.href='/XiangXi/1_index/business.html?data="+encodeURIComponent(JSON.stringify(nav))+"'"
				}
			},
			mounted:function(){
				
				
				var $table = $("#tableThreeProductionBuilding")
				//表格传区域ID参数
				var url = "";
				$table.attr("data-url", "/XiangXi/DefaultHandler.ashx?method=getThreeProductionBuildingList&data=" + JSON.stringify(GetRequest()) + "&");
	
				//具体操作：打开网页，编辑，删除
				var operateEvents = {
					//编辑
					'click .edit': function(e, value, row, index) {
						for(var p in row){
							if(row[p]&&row[p][0]==='/'&&row[p].indexOf('/Date')===0) row[p] = slashDate2yyyyMMdd(row[p])
						}
						window.location.href = "/XiangXi/gen/ThreeProductionBuilding.html?table=ThreeProductionBuilding&data=" + encodeURIComponent(JSON.stringify(row));
					},
					//删除
					'click .remove': function(e, value, row, index) {
						//前台删除
						$table.bootstrapTable("remove", {
							field: "id",
							values: [row.id]
						});
						//后台删除
						$.call('DeleteThreeProductionBuilding',row,function(data){
								$table.bootstrapTable("refresh");
						})
					}
				};
				$table.bootstrapTable({
					striped: true,
					height: getHeight(),
					columns: [[{
								field: "TPBName",
								title: "名称",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TPBAddress",
								title: "地址",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TPBBuildingNumber",
								title: "楼号",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TPBUnitNumber",
								title: "单元号",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TPBDoorNumber",
								title: "门牌号",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TPBTheNameOfEnterprise",
								title: "入驻企业名称",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TPBSuperinrtendent",
								title: "负责人",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "TPBContactModeOfThePersonInCharge",
								title: "负责人联系方式",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "TPBExtent",
								title: "范围",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "TPBRemarks",
								title: "备注",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "operate",
								title: "操作",
								align: "center",
								events: operateEvents,
								formatter: operateFormatter
							}
						]
					]
				});
		
				$table.bootstrapTable('refresh');
				$("input[type=text]:first").focus();
				setTimeout(function(){
				$table.bootstrapTable('refresh');},5000)
				
				var request = GetRequest();
				if(request && request.nav){
					try{

                        $.call("querynav2",JSON.parse(request.nav),function(resp){
                            vm.$data.nav_list = resp
                        })
					}catch (e) {
						console.error(e)
                    }
				}
			}
		})
	})
	console.log("加载自定义逻辑完毕")
})
console.log("加载脚本完毕")
console.groupEnd();
