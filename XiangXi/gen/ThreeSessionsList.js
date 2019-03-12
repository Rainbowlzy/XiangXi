  
/* ------------------------------------------------------------ *
 * 此文件由生成器引擎根据既有规则生成，所有手工的更改将会被覆盖
 * 生成时间：03/12/2019 13:34:36
 * 生成版本：03/12/2019 13:33:51 
 * 作者：路正遥
 * ------------------------------------------------------------ */
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
		var vm = new Vue({
			el:"#cnavThreeSessions",
			data:{
				request:GetRequest(),
				nav_list:[],
				current_menu:'三会一课'
			},
			methods:{
				parseEmpty: function(nav){
					return "javascript:parent.location.href='/XiangXi/1_index/business.html?data="+encodeURIComponent(JSON.stringify(nav))+"'"
				}
			},
			mounted:function(){
				
				$('.excel-import-button-ThreeSessions').click(function () {
						$('.table_add_modal').modal('hide');
						$('.table_excel_modal-ThreeSessions').on('shown.bs.modal',function(){
							$('.table_excel_modal-ThreeSessions .modal-body').html('<input class="excel_file input-file form-control" type="file">');
							$(".excel_file").fileinput({
								language: 'zh', //设置语言
								uploadUrl: "/XiangXi/ExcelImport.ashx?fileType=ThreeSessions", //上传的地址
								allowedFileExtensions: ['xls','xlsx'],//接收的文件后缀,
								showUpload: true, //是否显示上传按钮
								dropZoneEnabled: true,
								showCaption: true,//是否显示标题
								browseClass: "btn btn-primary", //按钮样式             
								previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
								msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！"
							});
							$(".excel_file").on("fileuploaded",function(){
								window.location.href = site_gen+"ThreeSessionsList.html"
							});
						})

						$('.table_excel_modal-ThreeSessions').modal('show');
					})
				
				var $table = $("#tableThreeSessions")
				//表格传区域ID参数
				var url = "";
				$table.attr("data-url", "/XiangXi/DefaultHandler.ashx?method=getThreeSessionsList&data=" + JSON.stringify(GetRequest()) + "&");
	
				//具体操作：打开网页，编辑，删除
				var operateEvents = {
					//编辑
					'click .edit': function(e, value, row, index) {
						for(var p in row){
							if(row[p]&&row[p][0]==='/'&&row[p].indexOf('/Date')===0) row[p] = slashDate2yyyyMMdd(row[p])
						}
						window.location.href = "/XiangXi/gen/ThreeSessions.html?table=ThreeSessions&data=" + encodeURIComponent(JSON.stringify(row));
					},
					//删除
					'click .remove': function(e, value, row, index) {
						//前台删除
						$table.bootstrapTable("remove", {
							field: "id",
							values: [row.id]
						});
						//后台删除
						$.call('DeleteThreeSessions',row,function(data){
								$table.bootstrapTable("refresh");
						})
					}
				};
				$table.bootstrapTable({
					striped: true,
					height: getHeight(),
					columns: [[
							{
								field: "id",
								title: "编号",
								sortable: true,
								visible: false,
								align: "center"
							}, 
						{	
								formatter: slashDate2yyyyMMdd,
								field: "TSDate",
								title: "日期",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TSTheme",
								title: "主题",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TSParticipant",
								title: "参与人员",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TSNumberOfParticipants",
								title: "与会人数",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TSHost",
								title: "主持人",
			
								sortable: true,
								align: "center"
							}, 
							{	
								formatter: limitFormatter('TSContent'),
								field: "TSContent",
								title: "内容",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "TSType",
								title: "类型",
											visible: false,
								sortable: true,
								align: "center"
							}, 
														{
								field: "CreateBy",
								title: "创建人",
								sortable: true,
								visible: false,
								align: "center"
							}
								,
							{
								field: "CreateOn",
								title: "创建时间",
								sortable: true,
								formatter: slashDate2yyyyMMdd,
								visible: false,
								align: "center"
							}
								,
							{
								field: "UpdateBy",
								title: "更新人",
								sortable: true,
								visible: false,
								align: "center"
							}
								,
							{
								field: "UpdateOn",
								title: "更新时间",
								sortable: true,
								formatter: slashDate2yyyyMMdd,
								visible: false,
								align: "center"
							}
								,
							{
								field: "DataLevel",
								title: "数据级别",
								sortable: true,
								visible: false,
								align: "center"
							},
							{
								field: "TransactionID",
								title: "事务编号",
								sortable: true,
								visible: false,
								align: "center"
							}
								,{
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
