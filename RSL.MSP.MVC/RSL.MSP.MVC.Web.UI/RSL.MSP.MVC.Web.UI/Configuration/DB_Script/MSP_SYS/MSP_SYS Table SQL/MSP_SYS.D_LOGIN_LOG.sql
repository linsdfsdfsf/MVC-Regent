DROP TABLE MSP_SYS.D_LOGIN_LOG CASCADE CONSTRAINTS;

CREATE TABLE MSP_SYS.D_LOGIN_LOG
(
  LOG_ID        INTEGER                         NOT NULL,
  USER_ACCOUNT  VARCHAR2(20 BYTE)               NOT NULL,
  LOGIN_TIME    DATE                            NOT NULL,
  LOGIN_IP      VARCHAR2(20 BYTE),
  HOST_NAME     VARCHAR2(20 BYTE)
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

COMMENT ON TABLE MSP_SYS.D_LOGIN_LOG IS '用户登录log表';

COMMENT ON COLUMN MSP_SYS.D_LOGIN_LOG.LOG_ID IS 'log ID';

COMMENT ON COLUMN MSP_SYS.D_LOGIN_LOG.USER_ACCOUNT IS '用户账户';

COMMENT ON COLUMN MSP_SYS.D_LOGIN_LOG.LOGIN_TIME IS '登录时间';

COMMENT ON COLUMN MSP_SYS.D_LOGIN_LOG.LOGIN_IP IS '登录IP';

COMMENT ON COLUMN MSP_SYS.D_LOGIN_LOG.HOST_NAME IS '登录HOST';


CREATE OR REPLACE TRIGGER MSP_SYS.TR_D_LOGIN_LOG
   BEFORE INSERT
   ON MSP_SYS.D_LOGIN_LOG    FOR EACH ROW
BEGIN
   SELECT SEQ_D_USER_ROLE_RELATION.NEXTVAL INTO :NEW.LOG_ID FROM DUAL;
END TR_D_LOGIN_LOG;
/
