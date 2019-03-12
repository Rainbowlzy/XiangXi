const menuList = [
  {
    "id": "483e05c5-e820-49f7-a667-443ad49ea2e1",
    "parentId": "0",
    "label": "我的工作",
    "icon": "fa-briefcase",
    "routerLink": null,
    "items": [
      {
        "id": "cb508e0c-bd0b-41ee-bc7d-2d2e362b1287",
        "parentId": "483e05c5-e820-49f7-a667-443ad49ea2e1",
        "label": "待办事宜",
        "icon": "fa-bookmark",
        "routerLink": "/platform/bpm/task/pendingMatters.do",
        "items": null
      },
      {
        "id": "f7d379c5-7070-469c-a91f-4817389f7647",
        "parentId": "483e05c5-e820-49f7-a667-443ad49ea2e1",
        "label": "我的草稿",
        "icon": "fa-bookmark",
        "routerLink": "/platform/bpm/processRun/myForm.do",
        "items": null
      },
      {
        "id": "2013982b-2a6b-431b-908a-3c3675b652b2",
        "parentId": "483e05c5-e820-49f7-a667-443ad49ea2e1",
        "label": "代理授权",
        "icon": "fa-bookmark",
        "routerLink": "/platform/bpm/agentSetting/list.do",
        "items": null
      }
    ]
  },
  {
    "id": "29941eab-9bdf-445a-99de-4687cb3d1435",
    "parentId": "0",
    "label": "农房管理",
    "icon": "fa-bank",
    "routerLink": "/house/houseBase/list.do",
    "items": null
  },
  {
    "id": "49035ebd-6bf7-47d5-ac3c-01063c8a1d09",
    "parentId": "0",
    "label": "巡查监管",
    "icon": "fa-taxi",
    "routerLink": "/house/housePatrol/list.do",
    "items": null
  },
  {
    "id": "0f15cd17-d024-4902-9c97-3c5932e9d29f",
    "parentId": "0",
    "label": "综合考评",
    "icon": "fa-star-o",
    "routerLink": "#",
    "items": null
  },
  {
    "id": "10000000060000",
    "parentId": "0",
    "label": "测试流程",
    "icon": "",
    "routerLink": null,
    "items": [
      {
        "id": "10000000060001",
        "parentId": "10000000060000",
        "label": "test",
        "icon": "",
        "routerLink": "/platform/form/bpmDataTemplate/preview.do?__displayId__=021f3e7d494343d2b2ccc814514300ff",
        "items": null
      },
      {
        "id": "10000000140028",
        "parentId": "10000000060000",
        "label": "报销流程",
        "icon": "",
        "routerLink": "/platform/form/bpmDataTemplate/preview.do?__displayId__=b0529263383343da8ecc45670c92eb34",
        "items": null
      },
      {
        "id": "60f0c7d3-5fef-407a-856c-093b8b4e721a",
        "parentId": "10000000060000",
        "label": "农房档案",
        "icon": "fa-database",
        "routerLink": "/house/houseBase/list.do",
        "items": null
      },
      {
        "id": "b7fc703e-968e-4608-8ad6-2ca60bf7ec73",
        "parentId": "10000000060000",
        "label": "加班单",
        "icon": "fa-align-justify",
        "routerLink": "/platform/form/bpmDataTemplate/preview.do?__displayId__=404701c76f774f25931fed48a890e5c6",
        "items": null
      },
      {
        "id": "f0491970-3041-4773-8a4d-9acea24ad19a",
        "parentId": "10000000060000",
        "label": "巡查记录",
        "icon": "fa-copy",
        "routerLink": "/house/housePatrol/list.do",
        "items": null
      },
      {
        "id": "10000000060002",
        "parentId": "10000000060000",
        "label": "请假申请",
        "icon": "",
        "routerLink": "/platform/form/bpmDataTemplate/preview.do?__displayId__=87a64c18c62e407aad8e0dec8c060f9c",
        "items": null
      }
    ]
  },
  {
    "id": "73",
    "parentId": "0",
    "label": "个人办公",
    "icon": "fa-briefcase",
    "routerLink": null,
    "items": [
      {
        "id": "82",
        "parentId": "73",
        "label": "流程中心",
        "icon": "fa-file-text-o",
        "routerLink": "",
        "items": [
          {
            "id": "83",
            "parentId": "82",
            "label": "我发起的流程",
            "icon": "fa-file-text-o",
            "routerLink": "",
            "items": [
              {
                "id": "84",
                "parentId": "83",
                "label": "新建流程",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/bpmDefinition/forMe.do",
                "items": null
              },
              {
                "id": "85",
                "parentId": "83",
                "label": "我的请求",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/processRun/myRequest.do",
                "items": null
              },
              {
                "id": "86",
                "parentId": "83",
                "label": "我的办结",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/processRun/myCompleted.do",
                "items": null
              },
              {
                "id": "87",
                "parentId": "83",
                "label": "我的草稿",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/processRun/myForm.do",
                "items": null
              }
            ]
          },
          {
            "id": "89",
            "parentId": "82",
            "label": "我承接的流程",
            "icon": "fa-file-text-o",
            "routerLink": "",
            "items": [
              {
                "id": "90",
                "parentId": "89",
                "label": "待办事宜",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/task/pendingMatters.do",
                "items": null
              },
              {
                "id": "91",
                "parentId": "89",
                "label": "已办事宜",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/processRun/alreadyMatters.do",
                "items": null
              },
              {
                "id": "92",
                "parentId": "89",
                "label": "办结事宜",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/processRun/completedMatters.do",
                "items": null
              },
              {
                "id": "93",
                "parentId": "89",
                "label": "转办代理事宜",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/bpmTaskExe/accordingMatters.do",
                "items": null
              },
              {
                "id": "94",
                "parentId": "89",
                "label": "加签流转事宜",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/bpmProTransTo/matters.do",
                "items": null
              },
              {
                "id": "95",
                "parentId": "89",
                "label": "抄送转发事宜",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/bpmProCopyto/myList.do",
                "items": null
              }
            ]
          },
          {
            "id": "96",
            "parentId": "82",
            "label": "我的流程日志",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/bpm/bpmRunLog/mylist.do",
            "items": null
          }
        ]
      },
      {
        "id": "74",
        "parentId": "73",
        "label": "设置中心",
        "icon": "fa-file-text-o",
        "routerLink": "",
        "items": [
          {
            "id": "75",
            "parentId": "74",
            "label": "常用语设置",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/bpm/taskApprovalItems/list.do?isAdmin=0",
            "items": null
          },
          {
            "id": "77",
            "parentId": "74",
            "label": "流程代理授权",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/bpm/agentSetting/list.do",
            "items": null
          },
          {
            "id": "195",
            "parentId": "74",
            "label": "首页布局设计",
            "icon": "fa-arrows-alt",
            "routerLink": "/platform/system/sysIndexMylayout/design.do",
            "items": null
          }
        ]
      },
      {
        "id": "97",
        "parentId": "73",
        "label": "内部消息",
        "icon": "fa-file-text-o",
        "routerLink": "/platform/system/messageSend/form.do",
        "items": [
          {
            "id": "98",
            "parentId": "97",
            "label": "收到的消息",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/messageReceiver/list.do",
            "items": null
          },
          {
            "id": "99",
            "parentId": "97",
            "label": "已发送消息",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/messageSend/list.do",
            "items": null
          },
          {
            "id": "100",
            "parentId": "97",
            "label": "发送消息",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/messageSend/edit.do",
            "items": null
          }
        ]
      },
      {
        "id": "101",
        "parentId": "73",
        "label": "邮件管理",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": null
      },
      {
        "id": "113",
        "parentId": "73",
        "label": "我的日程",
        "icon": "fa-file-text-o",
        "routerLink": "/platform/calendar/calendar.do",
        "items": null
      },
      {
        "id": "114",
        "parentId": "73",
        "label": "下属管理",
        "icon": "fa-file-text-o",
        "routerLink": "/platform/system/userUnder/list.do",
        "items": null
      },
      {
        "id": "116",
        "parentId": "73",
        "label": "查看个人资料",
        "icon": "fa-file-text-o",
        "routerLink": "/platform/system/sysUser/get.do",
        "items": null
      }
    ]
  },
  {
    "id": "200",
    "parentId": "0",
    "label": "敏捷开发",
    "icon": "fa-fighter-jet",
    "routerLink": null,
    "items": [
      {
        "id": "201",
        "parentId": "200",
        "label": "数据建模",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": [
          {
            "id": "14",
            "parentId": "201",
            "label": "自定义表",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/form/bpmFormTable/list.do",
            "items": null
          },
          {
            "id": "16",
            "parentId": "201",
            "label": "自定义sql查询",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysQuerySql/list.do",
            "items": null
          }
        ]
      },
      {
        "id": "2",
        "parentId": "200",
        "label": "表单设计",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": [
          {
            "id": "3",
            "parentId": "2",
            "label": "创建视图",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/form/bpmFormTable/createView.do",
            "items": null
          },
          {
            "id": "4",
            "parentId": "2",
            "label": "自定义表单",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/form/bpmFormDef/manage.do",
            "items": null
          },
          {
            "id": "6",
            "parentId": "2",
            "label": "自定义查询",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/bpm/bpmFormQuery/list.do",
            "items": null
          },
          {
            "id": "7",
            "parentId": "2",
            "label": "自定义对话框",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/form/bpmFormDialog/manage.do",
            "items": null
          },
          {
            "id": "9",
            "parentId": "2",
            "label": "表单规则验证",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/form/bpmFormRule/list.do",
            "items": null
          },
          {
            "id": "10",
            "parentId": "2",
            "label": "自定义表单模板",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/form/bpmFormTemplate/list.do",
            "items": null
          }
        ]
      },
      {
        "id": "1",
        "parentId": "200",
        "label": "流程建模与配置",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": [
          {
            "id": "17",
            "parentId": "1",
            "label": "流程管理",
            "icon": "fa-file-text-o",
            "routerLink": "",
            "items": [
              {
                "id": "25",
                "parentId": "17",
                "label": "流程分管授权",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/bpmDefAuthorize/list.do",
                "items": null
              },
              {
                "id": "26",
                "parentId": "17",
                "label": "常用语设置",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/taskApprovalItems/list.do?isAdmin=1",
                "items": null
              },
              {
                "id": "18",
                "parentId": "17",
                "label": "流程定义管理",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/bpmDefinition/manage.do",
                "items": null
              },
              {
                "id": "27",
                "parentId": "17",
                "label": "流程任务管理",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/task/list.do",
                "items": null
              },
              {
                "id": "29",
                "parentId": "17",
                "label": "流程实例管理",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/processRun/list.do",
                "items": null
              },
              {
                "id": "35",
                "parentId": "17",
                "label": "代理配置管理",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/agentSetting/manageList.do",
                "items": null
              },
              {
                "id": "31",
                "parentId": "17",
                "label": "流程历史管理",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/processRun/history.do",
                "items": null
              },
              {
                "id": "33",
                "parentId": "17",
                "label": "流程操作日志",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/bpmRunLog/list.do",
                "items": null
              },
              {
                "id": "34",
                "parentId": "17",
                "label": "转办代理实例",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/bpm/bpmTaskExe/list.do",
                "items": null
              }
            ]
          }
        ]
      },
      {
        "id": "148",
        "parentId": "200",
        "label": "流程开发辅助",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": [
          {
            "id": "150",
            "parentId": "148",
            "label": "脚本管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/script/list.do",
            "items": null
          },
          {
            "id": "154",
            "parentId": "148",
            "label": "流水号管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/identity/list.do",
            "items": null
          },
          {
            "id": "156",
            "parentId": "148",
            "label": "短信邮件模板",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysTemplate/list.do",
            "items": null
          },
          {
            "id": "161",
            "parentId": "148",
            "label": "条件脚本管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/conditionScript/list.do",
            "items": null
          },
          {
            "id": "157",
            "parentId": "148",
            "label": "人员脚本管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/personScript/list.do",
            "items": null
          }
        ]
      },
      {
        "id": "142",
        "parentId": "200",
        "label": "报表管理",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": null
      },
      {
        "id": "124",
        "parentId": "200",
        "label": "代码生成器",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": null
      }
    ]
  },
  {
    "id": "117",
    "parentId": "0",
    "label": "系统管理",
    "icon": "fa-cogs",
    "routerLink": null,
    "items": [
      {
        "id": "127",
        "parentId": "117",
        "label": "高级查询",
        "icon": "fa-file-text-o",
        "routerLink": "",
        "items": null
      },
      {
        "id": "40",
        "parentId": "117",
        "label": "用户组织管理",
        "icon": "fa-file-text-o",
        "routerLink": "",
        "items": [
          {
            "id": "41",
            "parentId": "40",
            "label": "用户管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysUser/list.do",
            "items": null
          },
          {
            "id": "51",
            "parentId": "40",
            "label": "组织管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysOrg/list.do",
            "items": null
          },
          {
            "id": "57",
            "parentId": "40",
            "label": "角色管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysRole/list.do",
            "items": null
          },
          {
            "id": "68",
            "parentId": "40",
            "label": "职务管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/job/list.do",
            "items": null
          },
          {
            "id": "71",
            "parentId": "40",
            "label": "组织人员属性",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysParam/list.do",
            "items": null
          },
          {
            "id": "72",
            "parentId": "40",
            "label": "人员维度管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/demension/list.do",
            "items": null
          },
          {
            "id": "191",
            "parentId": "40",
            "label": "分级组织管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/grade/manage.do",
            "items": null
          }
        ]
      },
      {
        "id": "196",
        "parentId": "117",
        "label": "SAP管理",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": null
      },
      {
        "id": "129",
        "parentId": "117",
        "label": "日历管理",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": [
          {
            "id": "130",
            "parentId": "129",
            "label": "法定假期设置",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/worktime/vacation/list.do",
            "items": null
          },
          {
            "id": "131",
            "parentId": "129",
            "label": "班次设置管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/worktime/workTimeSetting/list.do",
            "items": null
          },
          {
            "id": "132",
            "parentId": "129",
            "label": "工作日历设置",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/worktime/sysCalendar/list.do",
            "items": null
          },
          {
            "id": "133",
            "parentId": "129",
            "label": "工作日历分配",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/worktime/calendarAssign/list.do",
            "items": null
          },
          {
            "id": "134",
            "parentId": "129",
            "label": "加班请假管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/worktime/overTime/list.do",
            "items": null
          }
        ]
      },
      {
        "id": "135",
        "parentId": "117",
        "label": "首页管理",
        "icon": "fa-bank",
        "routerLink": null,
        "items": [
          {
            "id": "136",
            "parentId": "135",
            "label": "首页布局",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysIndexLayout/list.do",
            "items": null
          },
          {
            "id": "139",
            "parentId": "135",
            "label": "首页栏目",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysIndexColumn/list.do",
            "items": null
          }
        ]
      },
      {
        "id": "162",
        "parentId": "117",
        "label": "系统配置",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": [
          {
            "id": "168",
            "parentId": "162",
            "label": "资源管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/resources/tree.do",
            "items": null
          },
          {
            "id": "169",
            "parentId": "162",
            "label": "定时计划",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/scheduler/getJobList.do",
            "items": null
          },
          {
            "id": "171",
            "parentId": "162",
            "label": "系统附件",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysFile/list.do",
            "items": null
          },
          {
            "id": "173",
            "parentId": "162",
            "label": "索引重建",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/bpmIndexRebuild/indexList.do",
            "items": null
          },
          {
            "id": "174",
            "parentId": "162",
            "label": "分类管理",
            "icon": "fa-file-text-o",
            "routerLink": "",
            "items": [
              {
                "id": "178",
                "parentId": "174",
                "label": "数据字典",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/system/dictionary/tree.do",
                "items": null
              },
              {
                "id": "179",
                "parentId": "174",
                "label": "系统分类",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/system/globalType/tree.do",
                "items": null
              },
              {
                "id": "175",
                "parentId": "174",
                "label": "分类标识管理",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/system/sysTypeKey/list.do",
                "items": null
              }
            ]
          },
          {
            "id": "180",
            "parentId": "162",
            "label": "系统日志",
            "icon": "fa-file-text-o",
            "routerLink": "",
            "items": [
              {
                "id": "181",
                "parentId": "180",
                "label": "日志开关",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/system/sysLogSwitch/management.do",
                "items": null
              },
              {
                "id": "182",
                "parentId": "180",
                "label": "系统日志",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/system/sysAudit/list.do",
                "items": null
              },
              {
                "id": "183",
                "parentId": "180",
                "label": "错误日志",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/system/sysErrorLog/list.do",
                "items": null
              },
              {
                "id": "184",
                "parentId": "180",
                "label": "消息日志管理",
                "icon": "fa-file-text-o",
                "routerLink": "/platform/system/messageLog/list.do",
                "items": null
              }
            ]
          },
          {
            "id": "188",
            "parentId": "162",
            "label": "子系统管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/subSystem/list.do",
            "items": null
          },
          {
            "id": "167",
            "parentId": "162",
            "label": "URL拦截管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysUrlPermission/list.do",
            "items": null
          },
          {
            "id": "164",
            "parentId": "162",
            "label": "访问地址管理",
            "icon": "fa-file-text-o",
            "routerLink": "/platform/system/sysAcceptIp/list.do",
            "items": null
          }
        ]
      },
      {
        "id": "118",
        "parentId": "117",
        "label": "系统监控",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": null
      },
      {
        "id": "121",
        "parentId": "117",
        "label": "Office相关配置",
        "icon": "fa-file-text-o",
        "routerLink": null,
        "items": null
      }
    ]
  }
]
export default menuList