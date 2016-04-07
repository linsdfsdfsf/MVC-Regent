DROP TABLE MSP_SYS.D_ROLE_MENU_RELATION CASCADE CONSTRAINTS;

CREATE TABLE MSP_SYS.D_ROLE_MENU_RELATION
(
  RELATION_ID    INTEGER                        NOT NULL,
  MENU_ID        INTEGER                        NOT NULL,
  ROLE_ID        INTEGER                        NOT NULL,
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

COMMENT ON TABLE MSP_SYS.D_ROLE_MENU_RELATION IS '角色菜单关系表';

COMMENT ON COLUMN MSP_SYS.D_ROLE_MENU_RELATION.RELATION_ID IS '关系ID';

COMMENT ON COLUMN MSP_SYS.D_ROLE_MENU_RELATION.MENU_ID IS '菜单ID';

COMMENT ON COLUMN MSP_SYS.D_ROLE_MENU_RELATION.ROLE_ID IS '角色ID';

COMMENT ON COLUMN MSP_SYS.D_ROLE_MENU_RELATION.IS_VALID IS '关系是否有效，1有效；0，无效；';

COMMENT ON COLUMN MSP_SYS.D_ROLE_MENU_RELATION.CREATE_DATE IS '创建日期';

COMMENT ON COLUMN MSP_SYS.D_ROLE_MENU_RELATION.CREATE_BY IS '修改人';

COMMENT ON COLUMN MSP_SYS.D_ROLE_MENU_RELATION.LASTEDIT_DATE IS '最后修改时间';

COMMENT ON COLUMN MSP_SYS.D_ROLE_MENU_RELATION.LASTEDIT_BY IS '最后修改人';


CREATE UNIQUE INDEX MSP_SYS.D_ROLE_MENU_RELATION_PK ON MSP_SYS.D_ROLE_MENU_RELATION
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


CREATE OR REPLACE TRIGGER MSP_SYS.TR_D_ROLE_MENU_RELATION
   BEFORE INSERT
   ON MSP_SYS.D_ROLE_MENU_RELATION    FOR EACH ROW
BEGIN
   SELECT SEQ_D_USER_ROLE_RELATION.NEXTVAL INTO :NEW.RELATION_ID FROM DUAL;
END TR_D_ROLE_MENU_RELATION;
/
