DROP TABLE MSP_RM.MSP_NOTICE CASCADE CONSTRAINTS;

CREATE TABLE MSP_RM.MSP_NOTICE
(
  NOTICE_ID       INTEGER                       NOT NULL,
  NOTICE_TITLE    VARCHAR2(100 BYTE)            NOT NULL,
  NOTICE_TYPE     VARCHAR2(20 BYTE),
  IS_PUBLISH      INTEGER                       NOT NULL,
  NOTICE_SORT     INTEGER                       NOT NULL,
  NOTICE_CONTENT  CLOB                          NOT NULL,
  START_DATE      DATE                          NOT NULL,
  END_DATE        DATE,
  CREATE_DATE     DATE                          NOT NULL,
  CREATE_BY       VARCHAR2(20 BYTE)             NOT NULL,
  LASTEDIT_DATE   DATE,
  LASTEDIT_BY     VARCHAR2(20 BYTE)
)
TABLESPACE MSP_RM_DAT
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
LOB (NOTICE_CONTENT) STORE AS (
  ENABLE      STORAGE IN ROW
  CHUNK       8192
  RETENTION
  NOCACHE
  INDEX       (
        TABLESPACE MSP_RM_DAT
        STORAGE    (
                    INITIAL          64K
                    NEXT             1M
                    MINEXTENTS       1
                    MAXEXTENTS       UNLIMITED
                    PCTINCREASE      0
                    BUFFER_POOL      DEFAULT
                   ))
      STORAGE    (
                  INITIAL          64K
                  NEXT             1M
                  MINEXTENTS       1
                  MAXEXTENTS       UNLIMITED
                  PCTINCREASE      0
                  BUFFER_POOL      DEFAULT
                 ))
NOCACHE
NOPARALLEL
MONITORING;

COMMENT ON TABLE MSP_RM.MSP_NOTICE IS '公告表';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.LASTEDIT_BY IS '最后修改人';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.NOTICE_ID IS '公告ID';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.NOTICE_TITLE IS '公告主题';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.NOTICE_TYPE IS '公告类型';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.IS_PUBLISH IS '公告是否发布';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.NOTICE_SORT IS '公告排序';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.NOTICE_CONTENT IS '公告内容';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.START_DATE IS '公告开始时间';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.END_DATE IS '公告结束时间';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.CREATE_DATE IS '创建日期';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.CREATE_BY IS '修改人';

COMMENT ON COLUMN MSP_RM.MSP_NOTICE.LASTEDIT_DATE IS '最后修改时间';


CREATE UNIQUE INDEX MSP_RM.MSP_NOTICE_PK ON MSP_RM.MSP_NOTICE
(NOTICE_ID)
LOGGING
TABLESPACE MSP_RM_DAT
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


CREATE OR REPLACE TRIGGER MSP_RM.TR_MSP_NOTICE
   BEFORE INSERT
   ON MSP_RM.MSP_NOTICE    FOR EACH ROW
BEGIN
   SELECT MSP_RM.SEQ_MSP_NOTICE.NEXTVAL INTO :NEW.NOTICE_ID FROM DUAL;
END TR_MSP_NOTICE;
/


GRANT ALTER, DELETE, INSERT, SELECT, UPDATE ON MSP_RM.MSP_NOTICE TO MSP_SYS_ROLE;
