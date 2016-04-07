DROP TABLE MSP_SYS.D_USER CASCADE CONSTRAINTS;

CREATE TABLE MSP_SYS.D_USER
(
  USER_ID        INTEGER                        NOT NULL,
  USER_ACCOUNT   VARCHAR2(20 BYTE)              NOT NULL,
  USER_NAME      VARCHAR2(20 BYTE),
  USER_PWD       VARCHAR2(50 BYTE),
  USER_TEL       VARCHAR2(11 BYTE)              NOT NULL,
  USER_EMAIL     VARCHAR2(50 BYTE)              NOT NULL,
  USER_TYPE      INTEGER,
  IS_VALID       INTEGER,
  CREATE_DATE    DATE                           NOT NULL,
  CREATE_BY      VARCHAR2(20 BYTE)              NOT NULL,
  LASTEDIT_DATE  DATE,
  LASTEDIT_BY    VARCHAR2(20 BYTE)
)
TABLESPACE MSP_SYS_DAT
PCTUSED    0
PCTFREE    10
INITRANS   1
MAXTRANS   255
STORAGE    (
            INITIAL          1M
            NEXT             1M
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           )
LOGGING 
NOCOMPRESS 
NOCACHE
NOPARALLEL
MONITORING;

COMMENT ON TABLE MSP_SYS.D_USER IS '用户主表';

COMMENT ON COLUMN MSP_SYS.D_USER.USER_ID IS '用户ID';

COMMENT ON COLUMN MSP_SYS.D_USER.USER_ACCOUNT IS '用户账号';

COMMENT ON COLUMN MSP_SYS.D_USER.USER_NAME IS '用户姓名';

COMMENT ON COLUMN MSP_SYS.D_USER.USER_PWD IS '用户密码';

COMMENT ON COLUMN MSP_SYS.D_USER.USER_TEL IS '用户手机';

COMMENT ON COLUMN MSP_SYS.D_USER.USER_EMAIL IS '用户邮箱';

COMMENT ON COLUMN MSP_SYS.D_USER.USER_TYPE IS '用户类型';

COMMENT ON COLUMN MSP_SYS.D_USER.IS_VALID IS '用户是否有效，1有效；0，无效；';

COMMENT ON COLUMN MSP_SYS.D_USER.CREATE_DATE IS '创建日期';

COMMENT ON COLUMN MSP_SYS.D_USER.CREATE_BY IS '修改人';

COMMENT ON COLUMN MSP_SYS.D_USER.LASTEDIT_DATE IS '最后修改时间';

COMMENT ON COLUMN MSP_SYS.D_USER.LASTEDIT_BY IS '最后修改人';


CREATE UNIQUE INDEX MSP_SYS.D_USER_PK ON MSP_SYS.D_USER
(USER_ID)
LOGGING
TABLESPACE MSP_SYS_DAT
PCTFREE    10
INITRANS   2
MAXTRANS   255
STORAGE    (
            INITIAL          1M
            NEXT             1M
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            BUFFER_POOL      DEFAULT
           )
NOPARALLEL;


CREATE OR REPLACE TRIGGER MSP_SYS.TR_D_USER
   BEFORE INSERT
   ON MSP_SYS.D_USER    FOR EACH ROW
BEGIN
   SELECT SEQ_D_USER.NEXTVAL INTO :NEW.USER_ID FROM DUAL;
END TR_D_USER;
/
