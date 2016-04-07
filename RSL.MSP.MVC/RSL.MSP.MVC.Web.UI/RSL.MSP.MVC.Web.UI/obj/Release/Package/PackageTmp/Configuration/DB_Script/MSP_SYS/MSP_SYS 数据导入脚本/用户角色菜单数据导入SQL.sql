/* Formatted on 2015/11/17 11:55:22 (QP5 v5.136.908.31019) */
INSERT INTO MSP_SYS.D_USER (USER_ACCOUNT,
                            USER_NAME,
                            USER_PWD,
                            USER_EMAIL,
                            USER_TYPE,
                            IS_VALID,
                            CREATE_DATE,
                            CREATE_BY)
    VALUES ('XCOM',
            '系统管理员',
            'E99A18C428CB38D5F260853678922E03',
            'test@163.com',
            1,
            1,
            SYSDATGE,
            'XCOM');                                                                                                                                                       ---XCOM 密码为：abc123



INSERT INTO MSP_SYS.D_ROLE (ROLE_NAME,
                            ROLE_REMARK,
                            IS_VALID,
                            CREATE_DATE,
                            CREATE_BY)
    VALUES ('系统管理员',
            '系统管理员',
            1,
            SYSDATE,
            'XCOM');

INSERT INTO MSP_SYS.D_USER_ROLE_RELATION (USER_ID,
                                          ROLE_ID,
                                          IS_VALID,
                                          CREATE_DATE,
                                          CREATE_BY)
    VALUES (1,
            1,
            1,
            SYSDATE,
            'XCOM');



INSERT INTO MSP_SYS.D_MENU (P_MENU_ID,
                            MENU_NAME,
                            MENU_URL,
                            MENU_SEQ,
                            IS_VALID,
                            CREATE_DATE,
                            CREATE_BY,
                            MENU_LEVEL)
    VALUES (0,
            '系统管理',
            '',
            1,
            1,
            SYSDATE,
            'XCOM',
            1);



INSERT INTO MSP_SYS.D_MENU (P_MENU_ID,
                            MENU_NAME,
                            MENU_URL,
                            MENU_SEQ,
                            IS_VALID,
                            CREATE_DATE,
                            CREATE_BY,
                            MENU_LEVEL)
    VALUES (1,
            '用户管理',
            'Framework\UserManagement\UserInfoList.aspx',
            1,
            1,
            SYSDATE,
            'XCOM',
            2);



INSERT INTO MSP_SYS.D_MENU (P_MENU_ID,
                            MENU_NAME,
                            MENU_URL,
                            MENU_SEQ,
                            IS_VALID,
                            CREATE_DATE,
                            CREATE_BY,
                            MENU_LEVEL)
    VALUES (1,
            '角色管理',
            'Framework\RoleManagement\RoleInfoList.aspx',
            2,
            1,
            SYSDATE,
            'XCOM',
            2);

INSERT INTO MSP_SYS.D_MENU (P_MENU_ID,
                            MENU_NAME,
                            MENU_URL,
                            MENU_SEQ,
                            IS_VALID,
                            CREATE_DATE,
                            CREATE_BY,
                            MENU_LEVEL)
    VALUES (1,
            '菜单管理',
            'Framework\MenuManagement\MenuInfoList.aspx',
            3,
            1,
            SYSDATE,
            'XCOM',
            2);



INSERT INTO MSP_SYS.D_ROLE_MENU_RELATION (MENU_ID,
                                          ROLE_ID,
                                          IS_VALID,
                                          CREATE_DATE,
                                          CREATE_BY)
    VALUES (1,
            1,
            1,
            SYSDATE,
            'XCOM');

INSERT INTO MSP_SYS.D_ROLE_MENU_RELATION (MENU_ID,
                                          ROLE_ID,
                                          IS_VALID,
                                          CREATE_DATE,
                                          CREATE_BY)
    VALUES (2,
            1,
            1,
            SYSDATE,
            'XCOM');

INSERT INTO MSP_SYS.D_ROLE_MENU_RELATION (MENU_ID,
                                          ROLE_ID,
                                          IS_VALID,
                                          CREATE_DATE,
                                          CREATE_BY)
    VALUES (2,
            1,
            1,
            SYSDATE,
            'XCOM');

INSERT INTO MSP_SYS.D_ROLE_MENU_RELATION (MENU_ID,
                                          ROLE_ID,
                                          IS_VALID,
                                          CREATE_DATE,
                                          CREATE_BY)
    VALUES (2,
            1,
            1,
            SYSDATE,
            'XCOM');



            /* 动作按钮导入脚本 */

INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('View',
            '查看(View)',
            1,
            1,
            SYSDATE,
            'XCOM');



INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('Add',
            '新增(Add)',
            2,
            1,
            SYSDATE,
            'XCOM');

INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('Save',
            '保存(Save)',
            3,
            1,
            SYSDATE,
            'XCOM');


INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('Edit',
            '编辑(Edit)',
            4,
            1,
            SYSDATE,
            'XCOM');


INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('Delete',
            '删除(Delete)',
            5,
            1,
            SYSDATE,
            'XCOM');


INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('Cancel',
            '取消(Cancel)',
            6,
            1,
            SYSDATE,
            'XCOM');



INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('Invalid',
            '作废(Invalid)',
            7,
            1,
            SYSDATE,
            'XCOM');


INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('Upload',
            '上传(Upload)',
            8,
            1,
            SYSDATE,
            'XCOM');



INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('Excel',
            '导出(Excel)',
            9,
            1,
            SYSDATE,
            'XCOM');



INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('Print',
            '打印(Print)',
            10,
            1,
            SYSDATE,
            'XCOM');