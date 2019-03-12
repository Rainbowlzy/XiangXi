  
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
			el:"#cnavFactoryBuilding",
			data:{
				request:GetRequest(),
				nav_list:[],
				current_menu:'厂房楼栋'
			},
			methods:{
				parseEmpty: function(nav){
					return "javascript:parent.location.href='/XiangXi/1_index/business.html?data="+encodeURIComponent(JSON.stringify(nav))+"'"
				}
			},
			mounted:function(){
				
				$('.excel-import-button-FactoryBuilding').click(function () {
						$('.table_add_modal').modal('hide');
						$('.table_excel_modal-FactoryBuilding').on('shown.bs.modal',function(){
							$('.table_excel_modal-FactoryBuilding .modal-body').html('<input class="excel_file input-file form-control" type="file">');
							$(".excel_file").fileinput({
								language: 'zh', //设置语言
								uploadUrl: "/XiangXi/ExcelImport.ashx?fileType=FactoryBuilding", //上传的地址
								allowedFileExtensions: ['xls','xlsx'],//接收的文件后缀,
								showUpload: true, //是否显示上传按钮
								dropZoneEnabled: true,
								showCaption: true,//是否显示标题
								browseClass: "btn btn-primary", //按钮样式             
								previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
								msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！"
							});
							$(".excel_file").on("fileuploaded",function(){
								window.location.href = site_gen+"FactoryBuildingList.html"
							});
						})

						$('.table_excel_modal-FactoryBuilding').modal('show');
					})
				
				var $table = $("#tableFactoryBuilding")
				//表格传区域ID参数
				var url = "";
				$table.attr("data-url", "/XiangXi/DefaultHandler.ashx?method=getFactoryBuildingList&data=" + JSON.stringify(GetRequest()) + "&");
	
				//具体操作：打开网页，编辑，删除
				var operateEvents = {
					//编辑
					'click .edit': function(e, value, row, index) {
						for(var p in row){
							if(row[p]&&row[p][0]==='/'&&row[p].indexOf('/Date')===0) row[p] = slashDate2yyyyMMdd(row[p])
						}
						window.location.href = "/XiangXi/gen/FactoryBuilding.html?table=FactoryBuilding&data=" + encodeURIComponent(JSON.stringify(row));
					},
					//删除
					'click .remove': function(e, value, row, index) {
						//前台删除
						$table.bootstrapTable("remove", {
							field: "id",
							values: [row.id]
						});
						//后台删除
						$.call('DeleteFactoryBuilding',row,function(data){
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
								field: "FBNameOfIndustrialPark",
								title: "工业园名称",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBSerialNumber",
								title: "序号",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBTenant",
								title: "承租户",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBStartStop",
								title: "起止",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBLesseeArea",
								title: "承租面积",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBDeposit",
								title: "押金",
			
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBUnitPrice",
								title: "单价",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBMonthlyRent",
								title: "月租金",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBAnnualRent",
								title: "年租金",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBCharteredUnitNature",
								title: "租凭单位性质",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBEnvironmentalProtectionProcedures",
								title: "环保手续",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBBuiltupArea",
								title: "建筑面积",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{	
								formatter: slashDate2yyyyMMdd,
								field: "FBStartTime",
								title: "开始时间",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{	
								formatter: slashDate2yyyyMMdd,
								field: "FBEndingTime",
								title: "结束时间",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBContacts",
								title: "联系人",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBContactNumber",
								title: "联系电话",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBApprovalDocument",
								title: "审批文件",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBBuildingNumber",
								title: "楼号",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBUnitNumber",
								title: "单元号",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBHouseNumber",
								title: "门牌号",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBPersonInCharge",
								title: "负责人",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBContactInformationOfPersonInCharge",
								title: "负责人联系方式",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBRange",
								title: "范围",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBRemarks",
								title: "备注",
											visible: false,
								sortable: true,
								align: "center"
							}, 
							{
								field: "FBAddress",
								title: "地址",
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
