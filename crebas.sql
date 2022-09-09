alter table TOOL_COLLECTIONS 
   drop foreign key FK_TOOL_COL_RELATIONS_TOOL_PLA;

alter table TOOL_ENTRIES 
   drop foreign key FK_TOOL_ENT_RELATIONS_TOOL_TYP;

alter table TOOL_ENTRIES 
   drop foreign key FK_TOOL_ENT_RELATIONS_TOOL_COL;


alter table TOOL_COLLECTIONS 
   drop foreign key FK_TOOL_COL_RELATIONS_TOOL_PLA;

drop table if exists TOOL_COLLECTIONS;


alter table TOOL_ENTRIES 
   drop foreign key FK_TOOL_ENT_RELATIONS_TOOL_TYP;

alter table TOOL_ENTRIES 
   drop foreign key FK_TOOL_ENT_RELATIONS_TOOL_COL;

drop table if exists TOOL_ENTRIES;

drop table if exists TOOL_PLAYERS;

drop table if exists TOOL_TYPES;

create table TOOL_COLLECTIONS
(
   COLLECTION_ID        int not null,
   PLAYER_ID            int not null,
   CREATED_AT           datetime,
   primary key (COLLECTION_ID)
);

create table TOOL_ENTRIES
(
   TYPE_ID              int not null,
   COLLECTION_ID        int not null,
   VALUE                int  comment '',
   primary key (TYPE_ID, COLLECTION_ID)
);

create table TOOL_PLAYERS
(
   PLAYER_ID            int not null,
   NAME                 varchar(255),
   primary key (PLAYER_ID)
);

create table TOOL_TYPES
(
   TYPE_ID              int not null,
   IDENTIFIER           varchar(255),
   DESCRIPTION          varchar(255),
   primary key (TYPE_ID)
);

alter table TOOL_COLLECTIONS add constraint FK_TOOL_COL_RELATIONS_TOOL_PLA foreign key (PLAYER_ID)
      references TOOL_PLAYERS (PLAYER_ID) on delete restrict on update restrict;

alter table TOOL_ENTRIES add constraint FK_TOOL_ENT_RELATIONS_TOOL_TYP foreign key (TYPE_ID)
      references TOOL_TYPES (TYPE_ID) on delete restrict on update restrict;

alter table TOOL_ENTRIES add constraint FK_TOOL_ENT_RELATIONS_TOOL_COL foreign key (COLLECTION_ID)
      references TOOL_COLLECTIONS (COLLECTION_ID) on delete restrict on update restrict;

