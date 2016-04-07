DROP TABLE MSP_SYS.D_USER_STORE_RELATION CASCADE CONSTRAINTS;

CREATE TABLE MSP_SYS.D_USER_STORE_RELATION
(
  RELATION_ID    NUMBER                         NOT NULL,
  USER_ID        NUMBER                         NOT NULL,
  STORE_ID       VARCHAR2(10 BYTE)              NOT NULL,
  SITE_ID        VARCHAR2(10 BYTE)              NOT NULL,
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

COMMENT ON TABLE MSP_SYS.D_USER_STORE_RELATION IS '用户承租户关系表';

COMMENT ON COLUMN MSP_SYS.D_USER_STORE_RELATION.RELATION_ID IS '关系ID';

COMMENT ON COLUMN MSP_SYS.D_USER_STORE_RELATION.USER_ID IS '用户ID';

COMMENT ON COLUMN MSP_SYS.D_USER_STORE_RELATION.STORE_ID IS '承租户ID';

COMMENT ON COLUMN MSP_SYS.D_USER_STORE_RELATION.SITE_ID IS '分店ID';

COMMENT ON COLUMN MSP_SYS.D_USER_STORE_RELATION.IS_VALID IS '关系是否有效，1有效；0，无效；';


CREATE UNIQUE INDEX MSP_SYS.D_USER_STORE_RELATION_PK ON MSP_SYS.D_USER_STORE_RELATION
(RELATION_ID)
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

DROP SEQUENCE MSP_SYS.SEQ_D_USER_STORE_RELATION;

CREATE SEQUENCE MSP_SYS.SEQ_D_USER_STORE_RELATION
  START WITH 278
  MAXVALUE 999999999999999999999999999
  MINVALUE 1
  NOCYCLE
  NOCACHE
  NOORDER;



CREATE OR REPLACE TRIGGER MSP_SYS.TR_D_USER_STORE_RELATION
   BEFORE INSERT
   ON MSP_SYS.D_USER_STORE_RELATION    FOR EACH ROW
BEGIN
   SELECT SEQ_D_USER_STORE_RELATION.NEXTVAL INTO :NEW.RELATION_ID FROM DUAL;
END TR_D_USER_STORE_RELATION;

