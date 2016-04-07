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
            'ϵͳ����Ա',
            'E99A18C428CB38D5F260853678922E03',
            'test@163.com',
            1,
            1,
            SYSDATGE,
            'XCOM');                                                                                                                                                       ---XCOM ����Ϊ��abc123



INSERT INTO MSP_SYS.D_ROLE (ROLE_NAME,
                            ROLE_REMARK,
                            IS_VALID,
                            CREATE_DATE,
                            CREATE_BY)
    VALUES ('ϵͳ����Ա',
            'ϵͳ����Ա',
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
            'ϵͳ����',
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
            '�û�����',
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
            '��ɫ����',
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
            '�˵�����',
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



            /* ������ť����ű� */

INSERT INTO MSP_SYS.D_ACTION_LIST (ACTION_TYPE,
                                   ACTION_NAME,
                                   ACTION_SORT,
                                   IS_VALID,
                                   CREATE_DATE,
                                   CREATE_BY)
    VALUES ('View',
            '�鿴(View)',
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
            '����(Add)',
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
            '����(Save)',
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
            '�༭(Edit)',
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
            'ɾ��(Delete)',
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
            'ȡ��(Cancel)',
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
            '����(Invalid)',
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
            '�ϴ�(Upload)',
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
            '����(Excel)',
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
            '��ӡ(Print)',
            10,
            1,
            SYSDATE,
            'XCOM');